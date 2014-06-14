using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets; 

namespace PrinterClient
{
    public partial class ExplorerClient : Form
    {

        public List<string> pathArray = new List<string>();
        static readonly object verrou = new object();
        static string tmpDirectory = @"../../tmp/";
        private Socket SocketClient;
        private byte[] buffer;
        

        public ExplorerClient()
        {
            this.buffer = new byte[100];
            GlobalVariables.ipServeur = "192.168.0.17";

            connectToServer();

            InitializeComponent();
            deleteAllFilesInTMP();
            PopulateTreeView();
            this.treeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
        }

        public void connectToServer()
        {
            if (this.SocketClient == null || !this.SocketClient.Connected)
            {
                this.SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse(GlobalVariables.ipServeur);
                this.SocketClient.BeginConnect(new IPEndPoint(ipaddress, 15), new AsyncCallback(ConnectCallback), this.SocketClient);
            }
            else
            {
                MessageBox.Show("Désolé le serveur est down (else)");
            }
        }      

        private void ConnectCallback(IAsyncResult asyncResult)
		{
            try
            {
                Socket socket = (Socket)asyncResult.AsyncState;
                this.SocketClient = socket;
                socket.EndConnect(asyncResult);
<<<<<<< HEAD
=======
                
                //col here
                
>>>>>>> cc0db2006fa229ca8085eb80b3564c728627ed1f
            }
            catch
            {
                MessageBox.Show("Désolé le serveur est down");
            }
        }

        private void ReceiveCallback(IAsyncResult asyncResult)
		{
            Socket socket = (Socket)asyncResult.AsyncState;
            int read = socket.EndReceive(asyncResult);
            if( read > 0 )
			{
<<<<<<< HEAD
                Buffer.SetByte(this.buffer, 0, 0);
=======
                 Buffer.SetByte(this.buffer, 0, 0);
>>>>>>> cc0db2006fa229ca8085eb80b3564c728627ed1f
            }

            if( read == 0)
            {
                MessageBox.Show("Fichier NON envoyé");
			}
        }

        public void deleteAllFilesInTMP() 
        {
            if (Directory.Exists(tmpDirectory))
            {
                try
                {
                    string[] filenames = Directory.GetFiles(tmpDirectory);
                    foreach (string fName in filenames)
                    {
                        File.Delete(fName);
                    }
                }
                catch
                {}
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(tmpDirectory);
                }
                catch
                {}
            }
        }

        private void PopulateTreeView()
        {
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(@"../../");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView.Nodes.Add(rootNode);
            }
        }



        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
			listView.Items.Clear();
			DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
			ListViewItem.ListViewSubItem[] subItems;
			ListViewItem item = null;

			foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
			{
				item = new ListViewItem(dir.Name, 0);
				subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"), 
                     new ListViewItem.ListViewSubItem(item, 
						dir.LastAccessTime.ToShortDateString())};
				item.SubItems.AddRange(subItems);
				listView.Items.Add(item);
			}
			foreach (FileInfo file in nodeDirInfo.GetFiles())
			{
				item = new ListViewItem(file.Name, 1);
				subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"), 
                     new ListViewItem.ListViewSubItem(item, 
						file.LastAccessTime.ToShortDateString()),
                    new ListViewItem.ListViewSubItem(item, file.Directory.ToString())};

				item.SubItems.AddRange(subItems);
				listView.Items.Add(item);
			}

			listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listView_Click(object sender, EventArgs e)
        {
            ListView lw = (ListView)sender;
            string filename = lw.SelectedItems[0].Text;
            try
            {
                if (lw.SelectedItems[0].SubItems[1].Text == "File")
                {
                    string path = lw.SelectedItems[0].SubItems[3].Text;

                    bool exist = false;
                    foreach (string itemChecked in checkedListBoxFilePrinter.Items)
                    {
                        if (itemChecked == path + "\\" + filename)
                        {
                            exist = true;
                        }
                    }
                    if (!exist)
                    {
                        checkedListBoxFilePrinter.Items.Add(path+"\\"+filename, true);
                    }
                }
            }
            catch
            { }
        }

        private void buttonRAZ_Click(object sender, EventArgs e)
        {
            checkedListBoxFilePrinter.Items.Clear();
        }

        private void print_button_Click(object sender, EventArgs e)
        {
            //int cpt = 0;

            foreach (string itemChecked in checkedListBoxFilePrinter.CheckedItems)
            {
                //copyTheFile(itemChecked, cpt);
                //cpt += 1;

                this.buffer = Encoding.ASCII.GetBytes(itemChecked+","+itemChecked.Length.ToString());
                this.SocketClient.BeginSend(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), this.SocketClient);
            }

            //deleteAllFilesInTMP();
        }

        public void copyTheFile (string checkedItem, int compteur)
        {
            string[] filename = checkedItem.Split("\\".ToCharArray());
            string name = filename[filename.Length - 1];
            try
            {
                File.Copy(checkedItem, tmpDirectory + compteur + name, true);
            }
            catch
            {
                Directory.CreateDirectory(tmpDirectory);
                File.Copy(checkedItem, tmpDirectory + compteur + name, true);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public EndPoint ipEndPoint { get; set; }

        private void buttonIPServeur_Click(object sender, EventArgs e)
        {
            Form FormIPServeur = new FormIPServeur();
            FormIPServeur.Show();
        }

        private void ExplorerClient_Load(object sender, EventArgs e)
        {

        }
    }
}
