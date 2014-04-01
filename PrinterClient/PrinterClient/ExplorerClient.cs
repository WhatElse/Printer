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

namespace PrinterClient
{
    public partial class ExplorerClient : Form
    {

        public List<string> pathArray = new List<string>();
        static readonly object verrou = new object();


        public ExplorerClient()
        {
            InitializeComponent();
            deleteAllFilesInTMP();
            PopulateTreeView();
            this.treeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
        }


        public void deleteAllFilesInTMP() 
        {
            try
            {
                string[] filenames = Directory.GetFiles(@"../../tmp");
                foreach (string fName in filenames)
                {
                    File.Delete(fName);
                }
            }
            catch
            {
                Directory.CreateDirectory(@"../../tmp");
            }
        }

        private void PopulateTreeView()
        {
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(@"../..");
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
            int cpt = 0;

            foreach (string itemChecked in checkedListBoxFilePrinter.CheckedItems)
            {
                copyTheFile(itemChecked, cpt);
                cpt += 1;
            }
            MessageBox.Show("Envoi au serveur OK !");

            //La il fazut faire une suppression totale des fichiers contenus dans le repertoire /tmp
        }

        public void copyTheFile (string checkedItem, int compteur)
        {
            string[] filename = checkedItem.Split("\\".ToCharArray());
            string name = filename[filename.Length - 1];
            try
            {
                File.Copy(checkedItem, @"../../tmp/" + compteur + name, true);
            }
            catch
            {
                Directory.CreateDirectory(@"../../tmp/");
                File.Copy(checkedItem, @"../../tmp/" + compteur + name, true);
            }
        }

        public void destroyTheFile(string checkedItem)
        {
            try
            {
                File.Delete(checkedItem);
            }
            catch
            { }
        }


    }
}
