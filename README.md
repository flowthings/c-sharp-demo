# flowthings-io-csharp-demo

This is a VERY basic demo of the C# library for flowthings.io that opens a Websocket, sends random temperature readings, and then receives and charts the results.

## Prerequisites

This demo requires the following to run:

 * Visual Studio 2013
 * .NET 4.5.1
 * The flowthings.io C# library


## Downloading the Demo

You can download the ZIP file from here, or use Visual Studio to clone this demo from git.  Either way, you will have to add a reference to the flowthings-csharp library, which you can get here: https://github.com/flowdotnet/flowthings-io-csharp or on NuGet. Open the project `flowthingsTemperatureGraphDemo.csproj`.   


# Settings

Once you've downloaded the demo files and opened the project in Visual Studio, you will need to edit line 19 in Form1.cs, and put in your token and user.

# Running the Demo

Once you've put in your user/token, all you have to do is build and run.  The demo will connect to the flowthings.io platform and send a new random temperature reading every 20 seconds.  At the same time, it will listen for new temperature readings over the Websocket and plot them on the chart in the form.

# Exploring the Code

Let's take a look at Form1.cs.  This is a very trivial example, so almost everything being done is related to either sending or receiving data from flowthings.io.

First, on line 12 we include the flowthings namespace.  On line 18 `API api;`, the API object is created.  This is what will be used to perform all of the flowthings functions.  On line 19, a token is created for connecting to flowthings.

```
public TempGraph()
{
  InitializeComponent();
  this.api = new API(MY_TOKEN);
  this.rand = new Random();
}
```

This is where we create the API object.  At a minimum, the token must be passed to the API constructor.  Once the program is started, the first thing a user must do is click the Create Flow button.  This button runs the following code:

```
private async void btnCreate_Click(object sender, EventArgs e)
{
  dynamic flow = new ExpandoObject();
  flow.path = "/" + MY_TOKEN.account + "/temp";
  flow.capacity = 100;
            
  dynamic d = await api.flow.Create(flow);
  this.flowId = d.id;
}
```

A few things to note here.  First, you will see that this function is asynchronous.  All calls to the flowthings C# library are asynchronous.  To call them, you must either `await` the result, or call `Task.WaitAll` on the returned tasks.  This code first creates a dynamic object with a `path` and a `capacity` property.  To see the other properties accepted, see the flowthings.io documentation.  Next, it calls `api.flow.Create`.  The flowthings libraries are all organized to be called this way.  In the C# library, calls are of the type `api.object.Action(...)`, where `object` is flow, track, drop, etc., and `Action` is the CRUD action to perform.  The dynamic returned from the call to `api.flow.Create` contains the created Flow object.

Next, we connect the Websocket:

```
private void btnConnect_Click(object sender, EventArgs e)
{
  if (flowId == null)
  {
    MessageBox.Show("You must click create flow first");
    return;
  }

  this.api.websocket.OnOpen += websocket_OnOpen;
  this.api.websocket.OnClose += websocket_onClose;
  this.api.websocket.OnError += websocket_onError;
  this.api.websocket.OnMessage += websocket_onMessage;

  this.api.websocket.Connect();
}
```

When the connect button is clicked, we add event handlers for all of the flowthings Websocket events (open, close, error, and message).  Then all we need to do is call `Connect`.

While the send timer is ticking, every 20 seconds, the following method will be called:

```
private void tmrSend_Tick(object sender, EventArgs e)
{
  dynamic value = new ExpandoObject();
  value.temp = (double)(100*this.rand.NextDouble());
  value.compression = (double)(100 * this.rand.NextDouble());
  value.message = "ok";

  this.api.websocket.CreateDrop(flowId, value);
}
```

This creates a new Drop object (`value`) and sets its fields (`temp`, `compression`, and `message`).  It then adds the drop to `flowId` using the Websocket connection.

When a Drop is received over the Websocket, the following method is called:

```
void websocket_onMessage(string resource, dynamic value)
{
  this.BeginInvoke((Action)(() => {

    double temp = value.elems.temp.value;
    this.chart1.Series[0].Points.Add(temp);
            
  }));
}
```

This method gets the `temp` field from the Drop and adds it to the chart.

One final note: In order to keep the Websocket alive, you need to send a heartbeat at an interval.  This can be done using a `Timer` and calling `this.api.websocket.SendHeartbeat();`
