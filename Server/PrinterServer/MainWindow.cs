﻿using System;
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
using System.Threading;

namespace PrinterServer
{
    public partial class MainWindow : Form
    {
        private byte[] buffer;
        private Socket SocketServer;
        private Socket SocketClient;
        private List<Printer> printers;
        private List<Document> documents;
        public static ListeClients list = new ListeClients();
        private static string MyComputerName = Dns.GetHostName();
        private static string MyIP = Dns.GetHostByName(MyComputerName).AddressList[0].ToString();
        public IPEndPoint remoteIpEndPoint;
        private delegate void RemoveClient(IPEndPoint IP);
        private delegate void AddClient(IPEndPoint IP);


        public MainWindow()
        {
            InitializeComponent();
            this.buffer = new byte[100];
            this.printers = new List<Printer>();
            Thread ThreadListening = new Thread(() => OpenSocket());
            ThreadListening.Start();
        }

        public void OpenSocket()
        {
            this.SocketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse(MyIP);
            this.SocketServer.Bind(new IPEndPoint(ipAddress, 15));
            this.SocketServer.Listen(10);
            while (true)
            {
                Thread ThreadPerClient = new Thread(() => this.SocketServer.BeginAccept(new AsyncCallback(this.connexionAcceptCallback), this.SocketServer));
                ThreadPerClient.Start();
            }
        }

        private void ReceiveMessageCallback(IAsyncResult asyncResult)
        {
            try
            {
                Socket socket = (Socket)asyncResult.AsyncState;
                int read = socket.EndReceive(asyncResult);
                if (read > 0)
                {
                    string[] clientText = Encoding.ASCII.GetString(this.buffer).Split(',');
                    MessageBox.Show(clientText[0]+" "+clientText[1]);
                    Buffer.SetByte(this.buffer, 0, 0);
                    this.SocketClient.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessageCallback), this.SocketClient);
                }
            }
            catch
            {
                remoteIpEndPoint = this.SocketClient.RemoteEndPoint as IPEndPoint;
                Thread ThreadInvokeDisconnectTheClient = new Thread(new ThreadStart(ThreadMethodRemoveClient));
                ThreadInvokeDisconnectTheClient.Start();           
            }
        }

        private void connexionAcceptCallback(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState;
            if (socket.Handle.ToInt32() != -1)
            {
                this.SocketClient = socket.EndAccept(asyncResult);           
                remoteIpEndPoint = this.SocketClient.RemoteEndPoint as IPEndPoint;
                Thread AddClientToTheList = new Thread(new ThreadStart(ThreadMethodAddClient));
                AddClientToTheList.Start();
                Thread receiveMessage = new Thread (() => this.SocketClient.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessageCallback), this.SocketClient));
                receiveMessage.Start();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PrinterList.Items.Count != 0)
            {
                Printer printer = selectedPrinter();
                ipAdress.Text = printer.getIP();
                printerSpeed.Text = printer.getSpeed().ToString();
                printerName.Text = printer.getName();
                printerState.Text = printer.getStateInfo(printer.getState());
                changeButtonPauseImpression(printer);
            }
            else
            {
                ipAdress.Text = "";
                printerSpeed.Text = "";
                printerName.Text = "";
                printerState.Text = "";
            }
        }

        private void ThreadMethodRemoveClient()
        {
            this.Invoke(new RemoveClient(RemoveClientFromTheListe), remoteIpEndPoint);
        }

        private void ThreadMethodAddClient()
        {
            this.Invoke(new AddClient(AddClientToTheListe), remoteIpEndPoint);
        }

        private void AddClientToTheListe(IPEndPoint IP)
        {
            list.AjoutClient(remoteIpEndPoint.ToString());
        }

        private void RemoveClientFromTheListe(IPEndPoint IP)
        {
            list.DeleteClient(IP.ToString());
        }

        private void OpenClientsWindow_Click(object sender, EventArgs e)
        {
            list.Show();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMAJImprimante_Click(object sender, EventArgs e)
        {
            if (PrinterList.Items.Count != 0)
            {
                Printer printer = selectedPrinter();
                printer.setIP(ipAdress.Text);
                printer.setName(printerName.Text);
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
                if (ip == ipAdress.Text.ToString()) verif = true;
            }

            if (!verif)
            {
                if (printerName.Text != "" && ipAdress.Text != "")
                {
                    if (checkAnIP(ipAdress.Text.ToString()))
                    {
                        Random random = new Random();
                        int alea = random.Next(1, 5);
                        printerSpeed.Text = alea.ToString();

                        Printer newPrinter = new Printer(alea, printerName.Text.ToString(), ipAdress.Text.ToString(), 1, false);
                        printerState.Text = newPrinter.getStateInfo(newPrinter.getState());

                        PrinterList.Items.Add(ipAdress.Text.ToString() + " - " + printerName.Text.ToString());
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

        private void btnPauseImpression_Click(object sender, EventArgs e)
        {
            if (PrinterList.Items.Count != 0)
            {
                Printer printer = selectedPrinter();
                if (printer.getState() == 1) printer.setState(0);
                else printer.setState(1);
                printerState.Text = printer.getStateInfo(printer.getState());
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
                printer = null;
                PrinterList.Items.Remove(PrinterList.SelectedItem);
                PrinterList.SelectedIndex = PrinterList.Items.Count - 1;
            }
            else
            {
                MessageBox.Show("Aucune imprimante enregistrée");
            }
        }

        private bool checkAnIP(string ip)
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

        private void DocumentsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeButtonPauseDocument(selectedDocument());
        }

        private Document selectedDocument()
        {
            try
            {
                string documentSelected = DocumentsList.SelectedItem.ToString();

                foreach (Document document in documents)
                {
                    if (document.getName().ToString() == documentSelected)
                    {
                        return document;
                    }
                }
            }
            catch { }

            return documents.First();
        }

        private void AddDocument(string name, string path, int numberPage)
        {
            Document document = new Document(name, path, numberPage);
            DocumentsList.Items.Add(name);
            this.documents.Add(document);
            DocumentsList.SelectedIndex = DocumentsList.Items.Count;
        }

        private void PauseDocument_Click(object sender, EventArgs e)
        {
            if (DocumentsList.Items.Count != 0)
            {
                Document document = selectedDocument();
                if (document.getPause())
                {
                    document.setPause(false);
                }
                else
                {
                    document.setPause(true);
                }
            }
            else
            {
                MessageBox.Show("Il n'y a aucun document en attente");
            }
        }

        private void changeButtonPauseDocument(Document document)
        {
            if (document.getPause()) PauseDocument.Text = "Reactiver le document";
            if (!document.getPause()) PauseDocument.Text = "Mettre En Pause le document";
        }

        private void DeleteDocument_Click(object sender, EventArgs e)
        {
            if (DocumentsList.Items.Count != 0)
            {
                Document document = selectedDocument();
                documents.Remove(document);
                document = null;
                DocumentsList.Items.Remove(DocumentsList.SelectedItem);
                DocumentsList.SelectedIndex = DocumentsList.Items.Count - 1;
            }
            else
            {
                MessageBox.Show("Il n'y a aucun document en attente");
            }
        }
    }
}