using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = IPhelper.GetList();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPhelper.getIP_List();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            //dialog.InitialDirectory = ".\\";
            // dialog.Filter = "xls files (*.*)|*.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(dialog.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread SocketThread = new Thread(Listener.Server);
            SocketThread.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() != null) {
                MyTcpClient.Connect(listBox1.SelectedItem.ToString(), "testing Message");
            }
        }
    }
}