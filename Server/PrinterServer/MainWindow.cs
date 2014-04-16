using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace PrinterServer
{
    public partial class MainWindow : Form
    {
        private byte[] buffer;
        private Socket SocketServer;
        private Socket SocketClient;
        private static string MyComputerName = Dns.GetHostName();
        private static string MyIP = Dns.GetHostByName(MyComputerName).AddressList[0].ToString();

        public MainWindow()
        {
            InitializeComponent();
            this.buffer = new byte[100];
            OpenSocket();
        }

        public void OpenSocket()
        {
            this.SocketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse(MyIP);
            this.SocketServer.Bind(new IPEndPoint(ipAddress, 15));
            this.SocketServer.Listen(1);
            this.SocketServer.BeginAccept(new AsyncCallback(this.connexionAcceptCallback), this.SocketServer);
        }

        private void ReceiveMessageCallback(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState;
            int read = socket.EndReceive(asyncResult);
            if (read > 0)
            {
                MessageBox.Show("Client dit :" + Encoding.ASCII.GetString(this.buffer));
                Buffer.SetByte(this.buffer, 0, 0);
                try
                {
                    this.SocketClient.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessageCallback), this.SocketClient);
                }
                catch
                {
                    MessageBox.Show("Le client s'est déconnecté");
                }
            }
        }

        private void connexionAcceptCallback(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState;
            if (socket.Handle.ToInt32() != -1)
            {
                this.SocketClient = socket.EndAccept(asyncResult);
                MessageBox.Show("Un client s'est connecté !");
                this.SocketClient.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessageCallback), this.SocketClient);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void OpenClientsWindow_Click(object sender, EventArgs e)
        {
            ListeClients liste = new ListeClients();
            liste.Show();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vitesseImprimante_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnMAJImprimante_Click(object sender, EventArgs e)
        {

        }

        private void AddPrinter_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int alea = random.Next(1,5);
            Printer newPrinter = new Printer("", "En ligne", alea, true);
        }
    }
}
