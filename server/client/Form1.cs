using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimpleTCP.SimpleTcpClient client;

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            client.Connect(textBox1.Text, Convert.ToInt32(textBox2.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTCP.SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
          
        }
        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
            
                txtStatus.Text += e.MessageString;
             
            });
        }



        private void button2_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(3));
        }
    }
}
