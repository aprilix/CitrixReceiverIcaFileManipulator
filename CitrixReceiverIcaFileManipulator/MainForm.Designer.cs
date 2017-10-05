namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonFindFile = new System.Windows.Forms.Button();
            this.textBoxHRes = new System.Windows.Forms.TextBox();
            this.textBoxVRes = new System.Windows.Forms.TextBox();
            this.checkBoxResolution = new System.Windows.Forms.CheckBox();
            this.labelHRes = new System.Windows.Forms.Label();
            this.labelVRes = new System.Windows.Forms.Label();
            this.checkBoxTransparentKeyPassthrough = new System.Windows.Forms.CheckBox();
            this.buttonStoreAndExecute = new System.Windows.Forms.Button();
            this.buttonStore = new System.Windows.Forms.Button();
            this.buttonDragDropStore = new System.Windows.Forms.Button();
            this.buttonDragDropStoreAndExecute = new System.Windows.Forms.Button();
            this.buttonToggleAlwaysOnTop = new System.Windows.Forms.Button();
            this.labelFileDragAndDrop = new System.Windows.Forms.Label();
            this.textBoxCitrix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFindCitrix = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFile
            // 
            this.textBoxFile.AllowDrop = true;
            resources.ApplyResources(this.textBoxFile, "textBoxFile");
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBoxFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // buttonFindFile
            // 
            resources.ApplyResources(this.buttonFindFile, "buttonFindFile");
            this.buttonFindFile.Name = "buttonFindFile";
            this.buttonFindFile.UseVisualStyleBackColor = true;
            this.buttonFindFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxHRes
            // 
            resources.ApplyResources(this.textBoxHRes, "textBoxHRes");
            this.textBoxHRes.Name = "textBoxHRes";
            this.textBoxHRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxHRes_KeyDown);
            this.textBoxHRes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHRes_KeyPress);
            // 
            // textBoxVRes
            // 
            resources.ApplyResources(this.textBoxVRes, "textBoxVRes");
            this.textBoxVRes.Name = "textBoxVRes";
            this.textBoxVRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxVRes_KeyDown);
            this.textBoxVRes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxVRes_KeyPress);
            // 
            // checkBoxResolution
            // 
            resources.ApplyResources(this.checkBoxResolution, "checkBoxResolution");
            this.checkBoxResolution.Name = "checkBoxResolution";
            this.checkBoxResolution.UseVisualStyleBackColor = true;
            // 
            // labelHRes
            // 
            resources.ApplyResources(this.labelHRes, "labelHRes");
            this.labelHRes.Name = "labelHRes";
            // 
            // labelVRes
            // 
            resources.ApplyResources(this.labelVRes, "labelVRes");
            this.labelVRes.Name = "labelVRes";
            // 
            // checkBoxTransparentKeyPassthrough
            // 
            resources.ApplyResources(this.checkBoxTransparentKeyPassthrough, "checkBoxTransparentKeyPassthrough");
            this.checkBoxTransparentKeyPassthrough.Name = "checkBoxTransparentKeyPassthrough";
            this.checkBoxTransparentKeyPassthrough.UseVisualStyleBackColor = true;
            // 
            // buttonStoreAndExecute
            // 
            resources.ApplyResources(this.buttonStoreAndExecute, "buttonStoreAndExecute");
            this.buttonStoreAndExecute.Name = "buttonStoreAndExecute";
            this.buttonStoreAndExecute.UseVisualStyleBackColor = true;
            this.buttonStoreAndExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // buttonStore
            // 
            resources.ApplyResources(this.buttonStore, "buttonStore");
            this.buttonStore.Name = "buttonStore";
            this.buttonStore.UseVisualStyleBackColor = true;
            this.buttonStore.Click += new System.EventHandler(this.buttonStore_Click);
            // 
            // buttonDragDropStore
            // 
            this.buttonDragDropStore.AllowDrop = true;
            this.buttonDragDropStore.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.store;
            resources.ApplyResources(this.buttonDragDropStore, "buttonDragDropStore");
            this.buttonDragDropStore.Name = "buttonDragDropStore";
            this.buttonDragDropStore.UseVisualStyleBackColor = true;
            this.buttonDragDropStore.DragDrop += new System.Windows.Forms.DragEventHandler(this.buttonDragDropStore_DragDrop);
            this.buttonDragDropStore.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // buttonDragDropStoreAndExecute
            // 
            this.buttonDragDropStoreAndExecute.AllowDrop = true;
            this.buttonDragDropStoreAndExecute.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.storeAndExecute;
            resources.ApplyResources(this.buttonDragDropStoreAndExecute, "buttonDragDropStoreAndExecute");
            this.buttonDragDropStoreAndExecute.Name = "buttonDragDropStoreAndExecute";
            this.buttonDragDropStoreAndExecute.UseVisualStyleBackColor = true;
            this.buttonDragDropStoreAndExecute.DragDrop += new System.Windows.Forms.DragEventHandler(this.buttonDragDropStoreAndExecute_DragDrop);
            this.buttonDragDropStoreAndExecute.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // buttonToggleAlwaysOnTop
            // 
            resources.ApplyResources(this.buttonToggleAlwaysOnTop, "buttonToggleAlwaysOnTop");
            this.buttonToggleAlwaysOnTop.Name = "buttonToggleAlwaysOnTop";
            this.buttonToggleAlwaysOnTop.UseVisualStyleBackColor = true;
            this.buttonToggleAlwaysOnTop.Click += new System.EventHandler(this.buttonToggleAlwaysOnTop_Click);
            // 
            // labelFileDragAndDrop
            // 
            resources.ApplyResources(this.labelFileDragAndDrop, "labelFileDragAndDrop");
            this.labelFileDragAndDrop.Name = "labelFileDragAndDrop";
            // 
            // textBoxCitrix
            // 
            this.textBoxCitrix.AllowDrop = true;
            resources.ApplyResources(this.textBoxCitrix, "textBoxCitrix");
            this.textBoxCitrix.Name = "textBoxCitrix";
            this.textBoxCitrix.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxCitrix_DragDrop);
            this.textBoxCitrix.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxCitrix_DragEnter);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // buttonFindCitrix
            // 
            resources.ApplyResources(this.buttonFindCitrix, "buttonFindCitrix");
            this.buttonFindCitrix.Name = "buttonFindCitrix";
            this.buttonFindCitrix.UseVisualStyleBackColor = true;
            this.buttonFindCitrix.Click += new System.EventHandler(this.buttonFindCitrix_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonFindCitrix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCitrix);
            this.Controls.Add(this.labelFileDragAndDrop);
            this.Controls.Add(this.buttonToggleAlwaysOnTop);
            this.Controls.Add(this.buttonDragDropStoreAndExecute);
            this.Controls.Add(this.buttonDragDropStore);
            this.Controls.Add(this.buttonStore);
            this.Controls.Add(this.buttonStoreAndExecute);
            this.Controls.Add(this.checkBoxTransparentKeyPassthrough);
            this.Controls.Add(this.labelVRes);
            this.Controls.Add(this.labelHRes);
            this.Controls.Add(this.checkBoxResolution);
            this.Controls.Add(this.textBoxVRes);
            this.Controls.Add(this.textBoxHRes);
            this.Controls.Add(this.buttonFindFile);
            this.Controls.Add(this.textBoxFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button buttonFindFile;
        private System.Windows.Forms.TextBox textBoxHRes;
        private System.Windows.Forms.TextBox textBoxVRes;
        private System.Windows.Forms.CheckBox checkBoxResolution;
        private System.Windows.Forms.Label labelHRes;
        private System.Windows.Forms.Label labelVRes;
        private System.Windows.Forms.CheckBox checkBoxTransparentKeyPassthrough;
        private System.Windows.Forms.Button buttonStoreAndExecute;
        private System.Windows.Forms.Button buttonStore;
        private System.Windows.Forms.Button buttonDragDropStore;
        private System.Windows.Forms.Button buttonDragDropStoreAndExecute;
        private System.Windows.Forms.Button buttonToggleAlwaysOnTop;
        private System.Windows.Forms.Label labelFileDragAndDrop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCitrix;
        private System.Windows.Forms.Button buttonFindCitrix;
    }
}

