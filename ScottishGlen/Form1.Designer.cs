
namespace ScottishGlen
{
    partial class Form1
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
            this.initialTitle = new System.Windows.Forms.Label();
            this.addAssetBTN = new System.Windows.Forms.Button();
            this.addAssetPanel = new System.Windows.Forms.Panel();
            this.imagePic = new System.Windows.Forms.PictureBox();
            this.submitNewAssetForm = new System.Windows.Forms.Button();
            this.addImaageButton = new System.Windows.Forms.Button();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.ipAdressTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.manuTextBox = new System.Windows.Forms.TextBox();
            this.modelTextBox = new System.Windows.Forms.TextBox();
            this.systemNameTextBox = new System.Windows.Forms.TextBox();
            this.addAssetPanelLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.systemNamegen = new System.Windows.Forms.TextBox();
            this.modelGen = new System.Windows.Forms.TextBox();
            this.manuGen = new System.Windows.Forms.TextBox();
            this.typeGen = new System.Windows.Forms.TextBox();
            this.ipGen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addAssetPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePic)).BeginInit();
            this.SuspendLayout();
            // 
            // initialTitle
            // 
            this.initialTitle.AutoSize = true;
            this.initialTitle.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialTitle.Location = new System.Drawing.Point(12, 9);
            this.initialTitle.Name = "initialTitle";
            this.initialTitle.Size = new System.Drawing.Size(717, 67);
            this.initialTitle.TabIndex = 0;
            this.initialTitle.Text = "ScottishGlen ASSET TRACKER";
            this.initialTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.initialTitle.Click += new System.EventHandler(this.initialTitle_Click);
            // 
            // addAssetBTN
            // 
            this.addAssetBTN.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAssetBTN.Location = new System.Drawing.Point(24, 114);
            this.addAssetBTN.Name = "addAssetBTN";
            this.addAssetBTN.Size = new System.Drawing.Size(223, 50);
            this.addAssetBTN.TabIndex = 1;
            this.addAssetBTN.Text = "ADD NEW ASSET";
            this.addAssetBTN.UseVisualStyleBackColor = true;
            this.addAssetBTN.Click += new System.EventHandler(this.addAssetBTN_Click);
            // 
            // addAssetPanel
            // 
            this.addAssetPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addAssetPanel.Controls.Add(this.label1);
            this.addAssetPanel.Controls.Add(this.ipGen);
            this.addAssetPanel.Controls.Add(this.typeGen);
            this.addAssetPanel.Controls.Add(this.manuGen);
            this.addAssetPanel.Controls.Add(this.modelGen);
            this.addAssetPanel.Controls.Add(this.systemNamegen);
            this.addAssetPanel.Controls.Add(this.imagePic);
            this.addAssetPanel.Controls.Add(this.submitNewAssetForm);
            this.addAssetPanel.Controls.Add(this.addImaageButton);
            this.addAssetPanel.Controls.Add(this.notesTextBox);
            this.addAssetPanel.Controls.Add(this.ipAdressTextBox);
            this.addAssetPanel.Controls.Add(this.typeTextBox);
            this.addAssetPanel.Controls.Add(this.manuTextBox);
            this.addAssetPanel.Controls.Add(this.modelTextBox);
            this.addAssetPanel.Controls.Add(this.systemNameTextBox);
            this.addAssetPanel.Controls.Add(this.addAssetPanelLabel);
            this.addAssetPanel.Location = new System.Drawing.Point(277, 114);
            this.addAssetPanel.Name = "addAssetPanel";
            this.addAssetPanel.Size = new System.Drawing.Size(777, 324);
            this.addAssetPanel.TabIndex = 2;
            this.addAssetPanel.Visible = false;
            // 
            // imagePic
            // 
            this.imagePic.Location = new System.Drawing.Point(646, 108);
            this.imagePic.Name = "imagePic";
            this.imagePic.Size = new System.Drawing.Size(112, 131);
            this.imagePic.TabIndex = 9;
            this.imagePic.TabStop = false;
            // 
            // submitNewAssetForm
            // 
            this.submitNewAssetForm.Location = new System.Drawing.Point(646, 270);
            this.submitNewAssetForm.Name = "submitNewAssetForm";
            this.submitNewAssetForm.Size = new System.Drawing.Size(112, 40);
            this.submitNewAssetForm.TabIndex = 8;
            this.submitNewAssetForm.Text = "Submit";
            this.submitNewAssetForm.UseVisualStyleBackColor = true;
            this.submitNewAssetForm.Click += new System.EventHandler(this.submitNewAssetForm_Click);
            // 
            // addImaageButton
            // 
            this.addImaageButton.Location = new System.Drawing.Point(646, 52);
            this.addImaageButton.Name = "addImaageButton";
            this.addImaageButton.Size = new System.Drawing.Size(112, 40);
            this.addImaageButton.TabIndex = 7;
            this.addImaageButton.Text = "Add Image";
            this.addImaageButton.UseVisualStyleBackColor = true;
            this.addImaageButton.Click += new System.EventHandler(this.addImaageButton_Click);
            // 
            // notesTextBox
            // 
            this.notesTextBox.Location = new System.Drawing.Point(367, 201);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(254, 109);
            this.notesTextBox.TabIndex = 6;
            this.notesTextBox.Text = "Notes";
            this.notesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ipAdressTextBox
            // 
            this.ipAdressTextBox.Location = new System.Drawing.Point(367, 164);
            this.ipAdressTextBox.Name = "ipAdressTextBox";
            this.ipAdressTextBox.Size = new System.Drawing.Size(254, 22);
            this.ipAdressTextBox.TabIndex = 5;
            this.ipAdressTextBox.Text = "IP Address";
            this.ipAdressTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(367, 136);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(254, 22);
            this.typeTextBox.TabIndex = 4;
            this.typeTextBox.Text = "Type";
            this.typeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // manuTextBox
            // 
            this.manuTextBox.Location = new System.Drawing.Point(367, 108);
            this.manuTextBox.Name = "manuTextBox";
            this.manuTextBox.Size = new System.Drawing.Size(254, 22);
            this.manuTextBox.TabIndex = 3;
            this.manuTextBox.Text = "Manufacturer";
            this.manuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // modelTextBox
            // 
            this.modelTextBox.Location = new System.Drawing.Point(367, 80);
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(254, 22);
            this.modelTextBox.TabIndex = 2;
            this.modelTextBox.Text = "Model";
            this.modelTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // systemNameTextBox
            // 
            this.systemNameTextBox.Location = new System.Drawing.Point(367, 52);
            this.systemNameTextBox.Name = "systemNameTextBox";
            this.systemNameTextBox.Size = new System.Drawing.Size(254, 22);
            this.systemNameTextBox.TabIndex = 1;
            this.systemNameTextBox.Text = "System Name";
            this.systemNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // addAssetPanelLabel
            // 
            this.addAssetPanelLabel.AutoSize = true;
            this.addAssetPanelLabel.Location = new System.Drawing.Point(433, 13);
            this.addAssetPanelLabel.Name = "addAssetPanelLabel";
            this.addAssetPanelLabel.Size = new System.Drawing.Size(257, 17);
            this.addAssetPanelLabel.TabIndex = 0;
            this.addAssetPanelLabel.Text = "Fill the data and submit to add new item";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // systemNamegen
            // 
            this.systemNamegen.Location = new System.Drawing.Point(21, 52);
            this.systemNamegen.Name = "systemNamegen";
            this.systemNamegen.ReadOnly = true;
            this.systemNamegen.Size = new System.Drawing.Size(298, 22);
            this.systemNamegen.TabIndex = 10;
            // 
            // modelGen
            // 
            this.modelGen.Location = new System.Drawing.Point(21, 80);
            this.modelGen.Name = "modelGen";
            this.modelGen.ReadOnly = true;
            this.modelGen.Size = new System.Drawing.Size(298, 22);
            this.modelGen.TabIndex = 11;
            // 
            // manuGen
            // 
            this.manuGen.Location = new System.Drawing.Point(21, 108);
            this.manuGen.Name = "manuGen";
            this.manuGen.ReadOnly = true;
            this.manuGen.Size = new System.Drawing.Size(298, 22);
            this.manuGen.TabIndex = 12;
            // 
            // typeGen
            // 
            this.typeGen.Location = new System.Drawing.Point(21, 136);
            this.typeGen.Name = "typeGen";
            this.typeGen.ReadOnly = true;
            this.typeGen.Size = new System.Drawing.Size(298, 22);
            this.typeGen.TabIndex = 13;
            // 
            // ipGen
            // 
            this.ipGen.Location = new System.Drawing.Point(21, 164);
            this.ipGen.Name = "ipGen";
            this.ipGen.ReadOnly = true;
            this.ipGen.Size = new System.Drawing.Size(298, 22);
            this.ipGen.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Current system information";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 450);
            this.Controls.Add(this.addAssetPanel);
            this.Controls.Add(this.addAssetBTN);
            this.Controls.Add(this.initialTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.addAssetPanel.ResumeLayout(false);
            this.addAssetPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label initialTitle;
        private System.Windows.Forms.Button addAssetBTN;
        private System.Windows.Forms.Panel addAssetPanel;
        private System.Windows.Forms.Label addAssetPanelLabel;
        private System.Windows.Forms.TextBox systemNameTextBox;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.TextBox ipAdressTextBox;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.TextBox manuTextBox;
        private System.Windows.Forms.TextBox modelTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button addImaageButton;
        private System.Windows.Forms.Button submitNewAssetForm;
        private System.Windows.Forms.PictureBox imagePic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipGen;
        private System.Windows.Forms.TextBox typeGen;
        private System.Windows.Forms.TextBox manuGen;
        private System.Windows.Forms.TextBox modelGen;
        private System.Windows.Forms.TextBox systemNamegen;
    }
}

