
namespace _0519
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imfoPanel = new System.Windows.Forms.Panel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.seriesListBox = new System.Windows.Forms.ListBox();
            this.studyListBox = new System.Windows.Forms.ListBox();
            this.patientListBox = new System.Windows.Forms.ListBox();
            this.folderBtn = new System.Windows.Forms.Button();
            this.pBoxSlicesLabel1 = new System.Windows.Forms.Label();
            this.imagePanel1 = new System.Windows.Forms.Panel();
            this.pBoxSlicesLabel2 = new System.Windows.Forms.Label();
            this.pictureBoxInputBtn2 = new System.Windows.Forms.Button();
            this.pictureBoxInputBtn1 = new System.Windows.Forms.Button();
            this.CSMU_PictureBox2 = new CSMU_DICOM_LIB.CSMU_PictureBox();
            this.CSMU_PictureBox1 = new CSMU_DICOM_LIB.CSMU_PictureBox();
            this.CSMU_PictureBox3 = new CSMU_DICOM_LIB.CSMU_PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.imfoPanel.SuspendLayout();
            this.imagePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imfoPanel
            // 
            this.imfoPanel.Controls.Add(this.messageLabel);
            this.imfoPanel.Controls.Add(this.seriesListBox);
            this.imfoPanel.Controls.Add(this.studyListBox);
            this.imfoPanel.Controls.Add(this.patientListBox);
            this.imfoPanel.Controls.Add(this.folderBtn);
            this.imfoPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.imfoPanel.Location = new System.Drawing.Point(0, 0);
            this.imfoPanel.Name = "imfoPanel";
            this.imfoPanel.Size = new System.Drawing.Size(225, 614);
            this.imfoPanel.TabIndex = 0;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(0, 408);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 19);
            this.messageLabel.TabIndex = 4;
            // 
            // seriesListBox
            // 
            this.seriesListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.seriesListBox.FormattingEnabled = true;
            this.seriesListBox.ItemHeight = 19;
            this.seriesListBox.Location = new System.Drawing.Point(0, 287);
            this.seriesListBox.Name = "seriesListBox";
            this.seriesListBox.Size = new System.Drawing.Size(225, 118);
            this.seriesListBox.TabIndex = 3;
            this.seriesListBox.SelectedIndexChanged += new System.EventHandler(this.seriesListBox_SelectedIndexChanged);
            // 
            // studyListBox
            // 
            this.studyListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.studyListBox.FormattingEnabled = true;
            this.studyListBox.ItemHeight = 19;
            this.studyListBox.Location = new System.Drawing.Point(0, 169);
            this.studyListBox.Name = "studyListBox";
            this.studyListBox.Size = new System.Drawing.Size(225, 118);
            this.studyListBox.TabIndex = 2;
            this.studyListBox.SelectedIndexChanged += new System.EventHandler(this.studyListBox_SelectedIndexChanged);
            // 
            // patientListBox
            // 
            this.patientListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.patientListBox.FormattingEnabled = true;
            this.patientListBox.ItemHeight = 19;
            this.patientListBox.Location = new System.Drawing.Point(0, 51);
            this.patientListBox.Name = "patientListBox";
            this.patientListBox.Size = new System.Drawing.Size(225, 118);
            this.patientListBox.TabIndex = 1;
            this.patientListBox.SelectedIndexChanged += new System.EventHandler(this.patientListBox_SelectedIndexChanged);
            // 
            // folderBtn
            // 
            this.folderBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.folderBtn.Location = new System.Drawing.Point(0, 0);
            this.folderBtn.Name = "folderBtn";
            this.folderBtn.Size = new System.Drawing.Size(225, 51);
            this.folderBtn.TabIndex = 0;
            this.folderBtn.Text = "Select Folder";
            this.folderBtn.UseVisualStyleBackColor = true;
            this.folderBtn.Click += new System.EventHandler(this.folderBtn_Click);
            // 
            // pBoxSlicesLabel1
            // 
            this.pBoxSlicesLabel1.AutoSize = true;
            this.pBoxSlicesLabel1.Location = new System.Drawing.Point(115, 9);
            this.pBoxSlicesLabel1.Name = "pBoxSlicesLabel1";
            this.pBoxSlicesLabel1.Size = new System.Drawing.Size(0, 19);
            this.pBoxSlicesLabel1.TabIndex = 5;
            // 
            // imagePanel1
            // 
            this.imagePanel1.Controls.Add(this.pBoxSlicesLabel2);
            this.imagePanel1.Controls.Add(this.pBoxSlicesLabel1);
            this.imagePanel1.Controls.Add(this.pictureBoxInputBtn2);
            this.imagePanel1.Controls.Add(this.pictureBoxInputBtn1);
            this.imagePanel1.Controls.Add(this.CSMU_PictureBox2);
            this.imagePanel1.Controls.Add(this.CSMU_PictureBox3);
            this.imagePanel1.Controls.Add(this.CSMU_PictureBox1);
            this.imagePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePanel1.Location = new System.Drawing.Point(225, 0);
            this.imagePanel1.Name = "imagePanel1";
            this.imagePanel1.Size = new System.Drawing.Size(835, 614);
            this.imagePanel1.TabIndex = 1;
            this.imagePanel1.TabStop = true;
            // 
            // pBoxSlicesLabel2
            // 
            this.pBoxSlicesLabel2.AutoSize = true;
            this.pBoxSlicesLabel2.Location = new System.Drawing.Point(479, 9);
            this.pBoxSlicesLabel2.Name = "pBoxSlicesLabel2";
            this.pBoxSlicesLabel2.Size = new System.Drawing.Size(0, 19);
            this.pBoxSlicesLabel2.TabIndex = 6;
            // 
            // pictureBoxInputBtn2
            // 
            this.pictureBoxInputBtn2.Enabled = false;
            this.pictureBoxInputBtn2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInputBtn2.Image")));
            this.pictureBoxInputBtn2.Location = new System.Drawing.Point(394, 110);
            this.pictureBoxInputBtn2.Name = "pictureBoxInputBtn2";
            this.pictureBoxInputBtn2.Size = new System.Drawing.Size(55, 55);
            this.pictureBoxInputBtn2.TabIndex = 3;
            this.pictureBoxInputBtn2.UseVisualStyleBackColor = true;
            this.pictureBoxInputBtn2.Click += new System.EventHandler(this.pictureBoxInputBtn2_Click);
            // 
            // pictureBoxInputBtn1
            // 
            this.pictureBoxInputBtn1.Enabled = false;
            this.pictureBoxInputBtn1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInputBtn1.Image")));
            this.pictureBoxInputBtn1.Location = new System.Drawing.Point(30, 110);
            this.pictureBoxInputBtn1.Name = "pictureBoxInputBtn1";
            this.pictureBoxInputBtn1.Size = new System.Drawing.Size(55, 55);
            this.pictureBoxInputBtn1.TabIndex = 2;
            this.pictureBoxInputBtn1.UseVisualStyleBackColor = true;
            this.pictureBoxInputBtn1.Click += new System.EventHandler(this.pictureBoxInputBtn1_Click);
            // 
            // CSMU_PictureBox2
            // 
            this.CSMU_PictureBox2.CT_Center = 40;
            this.CSMU_PictureBox2.CT_Width = 400;
            this.CSMU_PictureBox2.FocusRangeDiameter = 7D;
            this.CSMU_PictureBox2.ImageType = CSMU_DICOM_LIB.CSMU_ImageType.ImageType_CT;
            this.CSMU_PictureBox2.IntensityVolume = null;
            this.CSMU_PictureBox2.LineX = -1;
            this.CSMU_PictureBox2.LineY = -1;
            this.CSMU_PictureBox2.Location = new System.Drawing.Point(479, 0);
            this.CSMU_PictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CSMU_PictureBox2.Name = "CSMU_PictureBox2";
            this.CSMU_PictureBox2.PET_Center = 3000D;
            this.CSMU_PictureBox2.PET_Width = 3000D;
            this.CSMU_PictureBox2.ScrollBarWidth = 21;
            this.CSMU_PictureBox2.ShowFocus = true;
            this.CSMU_PictureBox2.ShowReference = false;
            this.CSMU_PictureBox2.Size = new System.Drawing.Size(249, 253);
            this.CSMU_PictureBox2.TabIndex = 1;
            this.CSMU_PictureBox2.ViewType = CSMU_DICOM_LIB.CSMU_ViewType.ViewType_AX;
            this.CSMU_PictureBox2.onScrollBarValueChanged += new CSMU_DICOM_LIB.CSMU_PictureBox.ScrollBarValueChangedHandler(this.CSMU_PictureBox2_onScrollBarValueChanged);
            // 
            // CSMU_PictureBox1
            // 
            this.CSMU_PictureBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CSMU_PictureBox1.CT_Center = 40;
            this.CSMU_PictureBox1.CT_Width = 400;
            this.CSMU_PictureBox1.FocusRangeDiameter = 7D;
            this.CSMU_PictureBox1.ImageType = CSMU_DICOM_LIB.CSMU_ImageType.ImageType_CT;
            this.CSMU_PictureBox1.IntensityVolume = null;
            this.CSMU_PictureBox1.LineX = -1;
            this.CSMU_PictureBox1.LineY = -1;
            this.CSMU_PictureBox1.Location = new System.Drawing.Point(115, 0);
            this.CSMU_PictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CSMU_PictureBox1.Name = "CSMU_PictureBox1";
            this.CSMU_PictureBox1.PET_Center = 3000D;
            this.CSMU_PictureBox1.PET_Width = 3000D;
            this.CSMU_PictureBox1.ScrollBarWidth = 21;
            this.CSMU_PictureBox1.ShowFocus = true;
            this.CSMU_PictureBox1.ShowReference = false;
            this.CSMU_PictureBox1.Size = new System.Drawing.Size(249, 253);
            this.CSMU_PictureBox1.TabIndex = 0;
            this.CSMU_PictureBox1.ViewType = CSMU_DICOM_LIB.CSMU_ViewType.ViewType_AX;
            this.CSMU_PictureBox1.onScrollBarValueChanged += new CSMU_DICOM_LIB.CSMU_PictureBox.ScrollBarValueChangedHandler(this.CSMU_PictureBox1_onScrollBarValueChanged);
            // 
            // CSMU_PictureBox3
            // 
            this.CSMU_PictureBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CSMU_PictureBox3.CT_Center = 40;
            this.CSMU_PictureBox3.CT_Width = 400;
            this.CSMU_PictureBox3.FocusRangeDiameter = 7D;
            this.CSMU_PictureBox3.ImageType = CSMU_DICOM_LIB.CSMU_ImageType.ImageType_CT;
            this.CSMU_PictureBox3.IntensityVolume = null;
            this.CSMU_PictureBox3.LineX = -1;
            this.CSMU_PictureBox3.LineY = -1;
            this.CSMU_PictureBox3.Location = new System.Drawing.Point(479, 300);
            this.CSMU_PictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CSMU_PictureBox3.Name = "CSMU_PictureBox3";
            this.CSMU_PictureBox3.PET_Center = 3000D;
            this.CSMU_PictureBox3.PET_Width = 3000D;
            this.CSMU_PictureBox3.ScrollBarWidth = 21;
            this.CSMU_PictureBox3.ShowFocus = true;
            this.CSMU_PictureBox3.ShowReference = false;
            this.CSMU_PictureBox3.Size = new System.Drawing.Size(249, 253);
            this.CSMU_PictureBox3.TabIndex = 1;
            this.CSMU_PictureBox3.ViewType = CSMU_DICOM_LIB.CSMU_ViewType.ViewType_AX;
            this.CSMU_PictureBox3.Visible = false;
            this.CSMU_PictureBox3.onScrollBarValueChanged += new CSMU_DICOM_LIB.CSMU_PictureBox.ScrollBarValueChangedHandler(this.CSMU_PictureBox2_onScrollBarValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 614);
            this.Controls.Add(this.imagePanel1);
            this.Controls.Add(this.imfoPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.imfoPanel.ResumeLayout(false);
            this.imfoPanel.PerformLayout();
            this.imagePanel1.ResumeLayout(false);
            this.imagePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel imfoPanel;
        private CSMU_DICOM_LIB.CSMU_PictureBox CSMU_PictureBox1;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.ListBox seriesListBox;
        private System.Windows.Forms.ListBox studyListBox;
        private System.Windows.Forms.ListBox patientListBox;
        private System.Windows.Forms.Button folderBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel imagePanel1;
        private CSMU_DICOM_LIB.CSMU_PictureBox CSMU_PictureBox2;
        private CSMU_DICOM_LIB.CSMU_PictureBox CSMU_PictureBox3;
        private System.Windows.Forms.Button pictureBoxInputBtn2;
        private System.Windows.Forms.Button pictureBoxInputBtn1;
        private System.Windows.Forms.Label pBoxSlicesLabel1;
        private System.Windows.Forms.Label pBoxSlicesLabel2;
    }
}

