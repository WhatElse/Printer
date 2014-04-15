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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.PrinterList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddPrinter = new System.Windows.Forms.Button();
            this.DeletePrinter = new System.Windows.Forms.Button();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.PrinterName = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.SwitchState = new System.Windows.Forms.Button();
            this.lblDocuments = new System.Windows.Forms.Label();
            this.DocumentsList = new System.Windows.Forms.ListBox();
            this.PauseDocument = new System.Windows.Forms.Button();
            this.DeleteDocument = new System.Windows.Forms.Button();
            this.OpenClientsWindow = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnMAJImprimante = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFichierEnCours = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ServerWaiter = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.etatImprimante = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.vitesseImprimante = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrinterList
            // 
            this.PrinterList.FormattingEnabled = true;
            resources.ApplyResources(this.PrinterList, "PrinterList");
            this.PrinterList.Name = "PrinterList";
            this.PrinterList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // AddPrinter
            // 
            resources.ApplyResources(this.AddPrinter, "AddPrinter");
            this.AddPrinter.Name = "AddPrinter";
            this.AddPrinter.UseVisualStyleBackColor = true;
            this.AddPrinter.Click += new System.EventHandler(this.AddPrinter_Click);
            // 
            // DeletePrinter
            // 
            resources.ApplyResources(this.DeletePrinter, "DeletePrinter");
            this.DeletePrinter.Name = "DeletePrinter";
            this.DeletePrinter.UseVisualStyleBackColor = true;
            // 
            // lblPrinterName
            // 
            resources.ApplyResources(this.lblPrinterName, "lblPrinterName");
            this.lblPrinterName.Name = "lblPrinterName";
            // 
            // PrinterName
            // 
            resources.ApplyResources(this.PrinterName, "PrinterName");
            this.PrinterName.Name = "PrinterName";
            // 
            // lblPath
            // 
            resources.ApplyResources(this.lblPath, "lblPath");
            this.lblPath.Name = "lblPath";
            // 
            // SwitchState
            // 
            resources.ApplyResources(this.SwitchState, "SwitchState");
            this.SwitchState.Name = "SwitchState";
            this.SwitchState.UseVisualStyleBackColor = true;
            // 
            // lblDocuments
            // 
            resources.ApplyResources(this.lblDocuments, "lblDocuments");
            this.lblDocuments.Name = "lblDocuments";
            // 
            // DocumentsList
            // 
            this.DocumentsList.FormattingEnabled = true;
            resources.ApplyResources(this.DocumentsList, "DocumentsList");
            this.DocumentsList.Name = "DocumentsList";
            // 
            // PauseDocument
            // 
            resources.ApplyResources(this.PauseDocument, "PauseDocument");
            this.PauseDocument.Name = "PauseDocument";
            this.PauseDocument.UseVisualStyleBackColor = true;
            // 
            // DeleteDocument
            // 
            resources.ApplyResources(this.DeleteDocument, "DeleteDocument");
            this.DeleteDocument.Name = "DeleteDocument";
            this.DeleteDocument.UseVisualStyleBackColor = true;
            // 
            // OpenClientsWindow
            // 
            resources.ApplyResources(this.OpenClientsWindow, "OpenClientsWindow");
            this.OpenClientsWindow.Name = "OpenClientsWindow";
            this.OpenClientsWindow.UseVisualStyleBackColor = true;
            this.OpenClientsWindow.Click += new System.EventHandler(this.OpenClientsWindow_Click);
            // 
            // btnQuitter
            // 
            resources.ApplyResources(this.btnQuitter, "btnQuitter");
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnMAJImprimante
            // 
            resources.ApplyResources(this.btnMAJImprimante, "btnMAJImprimante");
            this.btnMAJImprimante.Name = "btnMAJImprimante";
            this.btnMAJImprimante.UseVisualStyleBackColor = true;
            this.btnMAJImprimante.Click += new System.EventHandler(this.btnMAJImprimante_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblFichierEnCours
            // 
            resources.ApplyResources(this.lblFichierEnCours, "lblFichierEnCours");
            this.lblFichierEnCours.Name = "lblFichierEnCours";
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // ServerWaiter
            // 
            this.ServerWaiter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.lblFichierEnCours);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // etatImprimante
            // 
            resources.ApplyResources(this.etatImprimante, "etatImprimante");
            this.etatImprimante.Name = "etatImprimante";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // vitesseImprimante
            // 
            resources.ApplyResources(this.vitesseImprimante, "vitesseImprimante");
            this.vitesseImprimante.Name = "vitesseImprimante";
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vitesseImprimante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.etatImprimante);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMAJImprimante);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.OpenClientsWindow);
            this.Controls.Add(this.DeleteDocument);
            this.Controls.Add(this.PauseDocument);
            this.Controls.Add(this.DocumentsList);
            this.Controls.Add(this.lblDocuments);
            this.Controls.Add(this.SwitchState);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.PrinterName);
            this.Controls.Add(this.lblPrinterName);
            this.Controls.Add(this.DeletePrinter);
            this.Controls.Add(this.AddPrinter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrinterList);
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button SwitchState;
        private System.Windows.Forms.Label lblDocuments;
        private System.Windows.Forms.ListBox DocumentsList;
        private System.Windows.Forms.Button PauseDocument;
        private System.Windows.Forms.Button DeleteDocument;
        private System.Windows.Forms.Button OpenClientsWindow;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnMAJImprimante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFichierEnCours;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker ServerWaiter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox etatImprimante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox vitesseImprimante;
    }
}

