namespace PrinterClient
{
    partial class FormIPServeur
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
            this.ButtonOkIPServeur = new System.Windows.Forms.Button();
            this.textBoxIPServeur = new System.Windows.Forms.TextBox();
            this.labelIPServeur = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonOkIPServeur
            // 
            this.ButtonOkIPServeur.Location = new System.Drawing.Point(132, 43);
            this.ButtonOkIPServeur.Name = "ButtonOkIPServeur";
            this.ButtonOkIPServeur.Size = new System.Drawing.Size(70, 20);
            this.ButtonOkIPServeur.TabIndex = 0;
            this.ButtonOkIPServeur.Text = "Ok";
            this.ButtonOkIPServeur.UseVisualStyleBackColor = true;
            this.ButtonOkIPServeur.Click += new System.EventHandler(this.ButtonOkIPServeur_Click);
            // 
            // textBoxIPServeur
            // 
            this.textBoxIPServeur.Location = new System.Drawing.Point(12, 43);
            this.textBoxIPServeur.Name = "textBoxIPServeur";
            this.textBoxIPServeur.Size = new System.Drawing.Size(100, 20);
            this.textBoxIPServeur.TabIndex = 1;
            this.textBoxIPServeur.Text = "1.2.3.4";
            this.textBoxIPServeur.TextChanged += new System.EventHandler(this.textBoxIPServeur_TextChanged);
            // 
            // labelIPServeur
            // 
            this.labelIPServeur.AutoSize = true;
            this.labelIPServeur.Location = new System.Drawing.Point(12, 13);
            this.labelIPServeur.Name = "labelIPServeur";
            this.labelIPServeur.Size = new System.Drawing.Size(223, 13);
            this.labelIPServeur.TabIndex = 2;
            this.labelIPServeur.Text = "Indiquer l\'adresse IP du Serveur d\'impression :";
            // 
            // FormIPServeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 84);
            this.Controls.Add(this.labelIPServeur);
            this.Controls.Add(this.textBoxIPServeur);
            this.Controls.Add(this.ButtonOkIPServeur);
            this.Name = "FormIPServeur";
            this.Text = "IP Serveur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOkIPServeur;
        private System.Windows.Forms.TextBox textBoxIPServeur;
        private System.Windows.Forms.Label labelIPServeur;
    }
}