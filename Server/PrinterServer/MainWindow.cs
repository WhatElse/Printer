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
        private List<Printer> printers;
        private static string MyComputerName = Dns.GetHostName();
        private static string MyIP = Dns.GetHostByName(MyComputerName).AddressList[0].ToString();

        public MainWindow()
        {
            InitializeComponent();
            this.buffer = new byte[100];
            this.printers = new List<Printer>();
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
            if (PrinterList.Items.Count != 0)
            {
                Printer printer = selectedPrinter();
                IPAdresse.Text = printer.getIP();
                vitesseImprimante.Text = printer.getSpeed().ToString();
                PrinterName.Text = printer.getName();
                etatImprimante.Text = printer.getStateInfo(printer.getState());
                changeButtonPauseImpression(printer);
            }
            else
            {
                IPAdresse.Text = "";
                vitesseImprimante.Text = "";
                PrinterName.Text = "";
                etatImprimante.Text = "";
            }
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
            if (PrinterList.Items.Count != 0)
            {
                Printer printer = selectedPrinter();
                printer.setIP(IPAdresse.Text);
                printer.setName(PrinterName.Text);
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une imprimante");
            }
        }

        private void AddPrinter_Click(object sender, EventArgs e)
        {
            bool verif = false;
            string ip;

            //verifie si une ip n'est pas déjà ajoutée à la liste
            foreach (string item in PrinterList.Items)
            {
                ip = item.Split(' ')[0];
                if (ip == IPAdresse.Text.ToString()) verif = true;
            }

            if (!verif)
            {
                if (PrinterName.Text != "" && IPAdresse.Text != "")
                {
                    if (verifierUneIp(IPAdresse.Text.ToString()))
                    {
                        Random random = new Random();
                        int alea = random.Next(1, 5);
                        vitesseImprimante.Text = alea.ToString();

                        Printer newPrinter = new Printer(alea, PrinterName.Text.ToString(), IPAdresse.Text.ToString(), 1, false);
                        etatImprimante.Text = newPrinter.getStateInfo(newPrinter.getState());

                        PrinterList.Items.Add(IPAdresse.Text.ToString() + " - " + PrinterName.Text.ToString());
                        this.printers.Add(newPrinter);
                        if (PrinterList.Items.Count != 0) PrinterList.SelectedIndex = PrinterList.Items.Count - 1;
                    }
                    else
                    {
                        MessageBox.Show("L'adresse IP indiqué est incorrect. Format : 123.123.123.123");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez renseigner le nom et l'adresse IP de l'imprimante");
                }
            }
            else
            {
                MessageBox.Show("Cette imprimante est déjà ajoutée");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnPauseImpression_Click(object sender, EventArgs e)
        {
            if (PrinterList.Items.Count != 0)
            {
                Printer printer = selectedPrinter();
                if (printer.getState() == 1) printer.setState(0);
                else printer.setState(1);
                etatImprimante.Text = printer.getStateInfo(printer.getState());
                changeButtonPauseImpression(printer);
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une imprimante");
            }
        }

        private Printer selectedPrinter()
        {
            try
            {
                string printerSelected = PrinterList.SelectedItem.ToString();

                foreach (Printer printer in printers)
                {
                    if (printer.getIP().ToString() == printerSelected.Split(' ')[0])
                    {
                        return printer;
                    }
                }
            }
            catch { }

                return printers.First();
        }

        private void changeButtonPauseImpression(Printer printer)
        {
            if (printer.getState() == 1) btnPauseImpression.Text = "Mettre Hors ligne";
            if (printer.getState() == 0) btnPauseImpression.Text = "Mettre En ligne";
        }

        private void DeletePrinter_Click(object sender, EventArgs e)
        {
            if (PrinterList.Items.Count != 0)
            {
                Printer printer = selectedPrinter();
                printers.Remove(printer);
                PrinterList.Items.Remove(PrinterList.SelectedItem);
                PrinterList.SelectedIndex = PrinterList.Items.Count - 1;
            }
            else
            {
                MessageBox.Show("Aucune imprimante enregistrée");
            }
        }

        private bool verifierUneIp(string ip)
        {
            IPAddress address;
            if (IPAddress.TryParse(ip, out address))
            {
                switch (address.AddressFamily)
                {
                    case System.Net.Sockets.AddressFamily.InterNetwork:
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
