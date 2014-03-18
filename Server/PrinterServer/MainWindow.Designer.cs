namespace PrinterServer
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.PrinterList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddPrinter = new System.Windows.Forms.Button();
            this.DeletePrinter = new System.Windows.Forms.Button();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.PrinterName = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.Path = new System.Windows.Forms.TextBox();
            this.ExplorePath = new System.Windows.Forms.Button();
            this.PrinterAvailable = new System.Windows.Forms.CheckBox();
            this.SwitchState = new System.Windows.Forms.Button();
            this.lblDocuments = new System.Windows.Forms.Label();
            this.DocumentsList = new System.Windows.Forms.ListBox();
            this.PauseDocument = new System.Windows.Forms.Button();
            this.DeleteDocument = new System.Windows.Forms.Button();
            this.OpenClientsWindow = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PrinterList
            // 
            this.PrinterList.FormattingEnabled = true;
            this.PrinterList.Location = new System.Drawing.Point(15, 43);
            this.PrinterList.Name = "PrinterList";
            this.PrinterList.Size = new System.Drawing.Size(157, 225);
            this.PrinterList.TabIndex = 0;
            this.PrinterList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Imprimantes connectées";
            // 
            // AddPrinter
            // 
            this.AddPrinter.Location = new System.Drawing.Point(15, 275);
            this.AddPrinter.Name = "AddPrinter";
            this.AddPrinter.Size = new System.Drawing.Size(75, 23);
            this.AddPrinter.TabIndex = 2;
            this.AddPrinter.Text = "Ajouter";
            this.AddPrinter.UseVisualStyleBackColor = true;
            // 
            // DeletePrinter
            // 
            this.DeletePrinter.Location = new System.Drawing.Point(97, 275);
            this.DeletePrinter.Name = "DeletePrinter";
            this.DeletePrinter.Size = new System.Drawing.Size(75, 23);
            this.DeletePrinter.TabIndex = 3;
            this.DeletePrinter.Text = "Supprimer";
            this.DeletePrinter.UseVisualStyleBackColor = true;
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.AutoSize = true;
            this.lblPrinterName.Location = new System.Drawing.Point(217, 27);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.Size = new System.Drawing.Size(101, 13);
            this.lblPrinterName.TabIndex = 4;
            this.lblPrinterName.Text = "Nom de l\'imprimante";
            // 
            // PrinterName
            // 
            this.PrinterName.Location = new System.Drawing.Point(220, 43);
            this.PrinterName.Name = "PrinterName";
            this.PrinterName.Size = new System.Drawing.Size(315, 20);
            this.PrinterName.TabIndex = 5;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(217, 66);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(114, 13);
            this.lblPath.TabIndex = 6;
            this.lblPath.Text = "Chemin de l\'imprimante";
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(220, 83);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(315, 20);
            this.Path.TabIndex = 7;
            // 
            // ExplorePath
            // 
            this.ExplorePath.Location = new System.Drawing.Point(220, 110);
            this.ExplorePath.Name = "ExplorePath";
            this.ExplorePath.Size = new System.Drawing.Size(75, 23);
            this.ExplorePath.TabIndex = 8;
            this.ExplorePath.Text = "Parcourir";
            this.ExplorePath.UseVisualStyleBackColor = true;
            // 
            // PrinterAvailable
            // 
            this.PrinterAvailable.AutoSize = true;
            this.PrinterAvailable.Checked = true;
            this.PrinterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PrinterAvailable.Location = new System.Drawing.Point(220, 139);
            this.PrinterAvailable.Name = "PrinterAvailable";
            this.PrinterAvailable.Size = new System.Drawing.Size(109, 17);
            this.PrinterAvailable.TabIndex = 9;
            this.PrinterAvailable.Text = "Imprimante visible";
            this.PrinterAvailable.UseVisualStyleBackColor = true;
            // 
            // SwitchState
            // 
            this.SwitchState.Location = new System.Drawing.Point(220, 163);
            this.SwitchState.Name = "SwitchState";
            this.SwitchState.Size = new System.Drawing.Size(179, 23);
            this.SwitchState.TabIndex = 10;
            this.SwitchState.Text = "Mettre en pause l\'impression";
            this.SwitchState.UseVisualStyleBackColor = true;
            // 
            // lblDocuments
            // 
            this.lblDocuments.AutoSize = true;
            this.lblDocuments.Location = new System.Drawing.Point(566, 27);
            this.lblDocuments.Name = "lblDocuments";
            this.lblDocuments.Size = new System.Drawing.Size(112, 13);
            this.lblDocuments.TabIndex = 11;
            this.lblDocuments.Text = "Documents en attente";
            // 
            // DocumentsList
            // 
            this.DocumentsList.FormattingEnabled = true;
            this.DocumentsList.Location = new System.Drawing.Point(569, 43);
            this.DocumentsList.Name = "DocumentsList";
            this.DocumentsList.Size = new System.Drawing.Size(223, 225);
            this.DocumentsList.TabIndex = 12;
            // 
            // PauseDocument
            // 
            this.PauseDocument.Location = new System.Drawing.Point(569, 275);
            this.PauseDocument.Name = "PauseDocument";
            this.PauseDocument.Size = new System.Drawing.Size(137, 23);
            this.PauseDocument.TabIndex = 13;
            this.PauseDocument.Text = "Suspendre le document";
            this.PauseDocument.UseVisualStyleBackColor = true;
            // 
            // DeleteDocument
            // 
            this.DeleteDocument.Location = new System.Drawing.Point(569, 305);
            this.DeleteDocument.Name = "DeleteDocument";
            this.DeleteDocument.Size = new System.Drawing.Size(137, 23);
            this.DeleteDocument.TabIndex = 14;
            this.DeleteDocument.Text = "Annuler le document";
            this.DeleteDocument.UseVisualStyleBackColor = true;
            // 
            // OpenClientsWindow
            // 
            this.OpenClientsWindow.Location = new System.Drawing.Point(220, 347);
            this.OpenClientsWindow.Name = "OpenClientsWindow";
            this.OpenClientsWindow.Size = new System.Drawing.Size(157, 23);
            this.OpenClientsWindow.TabIndex = 15;
            this.OpenClientsWindow.Text = "Voir les clients connectés";
            this.OpenClientsWindow.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Quitter";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 382);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OpenClientsWindow);
            this.Controls.Add(this.DeleteDocument);
            this.Controls.Add(this.PauseDocument);
            this.Controls.Add(this.DocumentsList);
            this.Controls.Add(this.lblDocuments);
            this.Controls.Add(this.SwitchState);
            this.Controls.Add(this.PrinterAvailable);
            this.Controls.Add(this.ExplorePath);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.PrinterName);
            this.Controls.Add(this.lblPrinterName);
            this.Controls.Add(this.DeletePrinter);
            this.Controls.Add(this.AddPrinter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrinterList);
            this.Name = "MainWindow";
            this.Text = "FWLG Printer Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PrinterList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddPrinter;
        private System.Windows.Forms.Button DeletePrinter;
        private System.Windows.Forms.Label lblPrinterName;
        private System.Windows.Forms.TextBox PrinterName;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Button ExplorePath;
        private System.Windows.Forms.CheckBox PrinterAvailable;
        private System.Windows.Forms.Button SwitchState;
        private System.Windows.Forms.Label lblDocuments;
        private System.Windows.Forms.ListBox DocumentsList;
        private System.Windows.Forms.Button PauseDocument;
        private System.Windows.Forms.Button DeleteDocument;
        private System.Windows.Forms.Button OpenClientsWindow;
        private System.Windows.Forms.Button button1;
    }
}

