namespace PrinterClient
{
    partial class ExplorerClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerClient));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.print_button = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.Doc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkedListBoxFilePrinter = new System.Windows.Forms.CheckedListBox();
            this.label_file_print = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.label_file_print);
            this.splitContainer.Panel1.Controls.Add(this.checkedListBoxFilePrinter);
            this.splitContainer.Panel1.Controls.Add(this.print_button);
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Size = new System.Drawing.Size(970, 463);
            this.splitContainer.SplitterDistance = 299;
            this.splitContainer.TabIndex = 0;
            // 
            // print_button
            // 
            this.print_button.Location = new System.Drawing.Point(0, 440);
            this.print_button.Name = "print_button";
            this.print_button.Size = new System.Drawing.Size(299, 23);
            this.print_button.TabIndex = 1;
            this.print_button.Text = "Imprimer";
            this.print_button.UseVisualStyleBackColor = true;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(299, 239);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder");
            this.imageList.Images.SetKeyName(1, "document");
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Doc,
            this.Type,
            this.LastModified,
            this.Path});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(667, 463);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.Click += new System.EventHandler(this.listView_Click);
            // 
            // Doc
            // 
            this.Doc.Text = "Name";
            // 
            // Type
            // 
            this.Type.Text = "Type";
            // 
            // LastModified
            // 
            this.LastModified.Text = "Last modified";
            // 
            // Path
            // 
            this.Path.Text = "Path";
            // 
            // checkedListBoxFilePrinter
            // 
            this.checkedListBoxFilePrinter.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.checkedListBoxFilePrinter.CheckOnClick = true;
            this.checkedListBoxFilePrinter.FormattingEnabled = true;
            this.checkedListBoxFilePrinter.Location = new System.Drawing.Point(0, 256);
            this.checkedListBoxFilePrinter.Name = "checkedListBoxFilePrinter";
            this.checkedListBoxFilePrinter.Size = new System.Drawing.Size(296, 184);
            this.checkedListBoxFilePrinter.TabIndex = 2;
            // 
            // label_file_print
            // 
            this.label_file_print.AutoSize = true;
            this.label_file_print.Location = new System.Drawing.Point(96, 241);
            this.label_file_print.Name = "label_file_print";
            this.label_file_print.Size = new System.Drawing.Size(93, 13);
            this.label_file_print.TabIndex = 3;
            this.label_file_print.Text = "Fichiers à imprimer";
            // 
            // ExplorerClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 463);
            this.Controls.Add(this.splitContainer);
            this.Name = "ExplorerClient";
            this.Text = "ExplorerClient";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader Doc;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader LastModified;
        private System.Windows.Forms.Button print_button;
        private System.Windows.Forms.ColumnHeader Path;
        private System.Windows.Forms.Label label_file_print;
        private System.Windows.Forms.CheckedListBox checkedListBoxFilePrinter;
    }
}

