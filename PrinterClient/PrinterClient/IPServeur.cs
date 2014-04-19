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

namespace PrinterClient
{
    public partial class FormIPServeur : Form
    {
        public FormIPServeur()
        {
            InitializeComponent();
            textBoxIPServeur.Text = GlobalVariables.ipServeur;
        }

        private void textBoxIPServeur_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ButtonOkIPServeur_Click(object sender, EventArgs e)
        {
            if (verifierUneIp(textBoxIPServeur.Text.ToString()))
            {
                GlobalVariables.ipServeur = textBoxIPServeur.Text.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("L'adresse IP indiquée n'est pas correcte. Format : 123.123.123.123");
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
