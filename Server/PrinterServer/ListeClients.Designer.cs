namespace PrinterServer
{
    partial class ListeClients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listeClientsConnectes = new System.Windows.Forms.ListBox();
            this.btnFermer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listeClientsConnectes
            // 
            this.listeClientsConnectes.FormattingEnabled = true;
            this.listeClientsConnectes.Location = new System.Drawing.Point(13, 13);
            this.listeClientsConnectes.Name = "listeClientsConnectes";
            this.listeClientsConnectes.Size = new System.Drawing.Size(259, 199);
            this.listeClientsConnectes.TabIndex = 0;
            // 
            // btnFermer
            // 
            this.btnFermer.Location = new System.Drawing.Point(105, 226);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(75, 23);
            this.btnFermer.TabIndex = 1;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // ListeClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.listeClientsConnectes);
            this.Name = "ListeClients";
            this.Text = "ListeClients";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listeClientsConnectes;
        private System.Windows.Forms.Button btnFermer;
    }
}