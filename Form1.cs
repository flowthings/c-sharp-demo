using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;

using flowthings;

namespace flowthingsTemperatureGraphDemo
{
    public partial class TempGraph : Form
    {
        API api;
        Token MY_TOKEN = new Token("myaccount", "mytoken");
        string flowId = null;
        Random rand;

        public TempGraph()
        {
            InitializeComponent();
            this.api = new API(MY_TOKEN);
            this.rand = new Random();
        }

        private void TempGraph_Load(object sender, EventArgs e)
        {
        }


        void websocket_onMessage(string resource, dynamic value)
        {
            this.BeginInvoke((Action)(() => {

                double temp = value.elems.temp.value;
                this.chart1.Series[0].Points.Add(temp);
            
            }));
        }

        void websocket_onError(string message)
        {
        }

        void websocket_onClose(string reason, bool wasClean)
        {
            this.BeginInvoke((Action)(() =>
            {
                this.tmrHeartbeat.Stop();
            }));
        }

        void websocket_OnOpen()
        {
            this.BeginInvoke((Action)(() =>
            {
                this.tmrHeartbeat.Start();
            }));
            this.api.websocket.Subscribe(flowId);
        }

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

        private void TempGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.api.websocket.Dispose();
        }

        private void tmrHeartbeat_Tick(object sender, EventArgs e)
        {
            if (this.api.websocket.connected) this.api.websocket.SendHeartbeat();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrSend.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmrSend.Stop();
        }

        private void tmrSend_Tick(object sender, EventArgs e)
        {
            dynamic value = new ExpandoObject();
            value.temp = (double)(100*this.rand.NextDouble());
            value.compression = (double)(100 * this.rand.NextDouble());
            value.message = "ok";

            this.api.websocket.CreateDrop(flowId, value);
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            dynamic flow = new ExpandoObject();
            flow.path = "/" + MY_TOKEN.account + "/temp";
            flow.capacity = 100;
            
            dynamic d = await api.flow.Create(flow);
            this.flowId = d.id;
        }
    }
}
