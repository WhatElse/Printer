﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterServer
{
    public partial class ListeClients : Form
    {
        static readonly object verrou = new object();

        public ListeClients()
        {
            InitializeComponent();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void listeClientsConnectes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListeClients_Load(object sender, EventArgs e)
        {

        }

        public void AjoutClient(string ip)
        {
            lock (verrou)
            {
                listClients.Items.Add(ip.ToString());
            }
        }

        public void DeleteClient(string ip)
        {
            lock (verrou)
            {
                listClients.Items.Remove(ip);
            }
        }
    }
}
