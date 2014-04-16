using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            GlobalVariables.ipServeur = textBoxIPServeur.Text.ToString();
            this.Close();
        }
    }
}
