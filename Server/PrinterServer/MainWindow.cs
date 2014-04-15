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
        private SocketPermission permission;
        private Socket listener;
        public MainWindow()
        {
            InitializeComponent();

            IPHostEntry ipHost = Dns.GetHostEntry("");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 3333);

            this.permission = new SocketPermission(NetworkAccess.Accept, TransportType.Tcp, "", SocketPermission.AllPorts);
            this.listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(ipEndPoint);
            listener.Listen(100);

            // AsyncCallback aCallback = new AsyncCallback(...);
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
