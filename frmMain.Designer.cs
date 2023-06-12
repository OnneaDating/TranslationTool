namespace OnneaRE
{
    partial class frmMain
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            GrdResource = new DataGridView();
            BtnLoad = new Button();
            BtnSave = new Button();
            openFileDialog1 = new OpenFileDialog();
            imageList = new ImageList(components);
            txtNameSpace = new TextBox();
            txtCodeFile = new TextBox();
            BtnTranslate = new Button();
            cboToLanguage = new ComboBox();
            cboFromLanguage = new ComboBox();
            lblFrom = new Label();
            lblToLanguage = new Label();
            txtAPIKey = new TextBox();
            lblAPIKEY = new Label();
            ((System.ComponentModel.ISupportInitialize)GrdResource).BeginInit();
            SuspendLayout();
            // 
            // GrdResource
            // 
            GrdResource.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            GrdResource.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            GrdResource.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            GrdResource.DefaultCellStyle = dataGridViewCellStyle2;
            GrdResource.Location = new Point(12, 114);
            GrdResource.Name = "GrdResource";
            GrdResource.RowTemplate.Height = 25;
            GrdResource.Size = new Size(776, 323);
            GrdResource.TabIndex = 0;
            GrdResource.CellClick += GrdResource_CellClick;
            GrdResource.CellFormatting += GrdResource_CellFormatting;
            GrdResource.CellPainting += GrdResource_CellPainting;
            GrdResource.RowStateChanged += GrdResource_RowStateChanged;
            // 
            // BtnLoad
            // 
            BtnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnLoad.Location = new Point(681, 12);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(107, 56);
            BtnLoad.TabIndex = 1;
            BtnLoad.Text = "Select Directory Where your resource files are";
            BtnLoad.UseVisualStyleBackColor = true;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // BtnSave
            // 
            BtnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnSave.Location = new Point(681, 74);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(107, 34);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "Save && Build";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth8Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "Resource.sv.resx");
            imageList.Images.SetKeyName(1, "Resource.es.resx");
            imageList.Images.SetKeyName(2, "Resource.fi.resx");
            imageList.Images.SetKeyName(3, "Resource.ru.resx");
            imageList.Images.SetKeyName(4, "Resource.de.resx");
            imageList.Images.SetKeyName(5, "Resource.fr.resx");
            imageList.Images.SetKeyName(6, "Resource.resx");
            imageList.Images.SetKeyName(7, "Resource.th.resx");
            imageList.Images.SetKeyName(8, "Resource.ar.resx");
            imageList.Images.SetKeyName(9, "Resource.ja.resx");
            imageList.Images.SetKeyName(10, "Resource.da.resx");
            imageList.Images.SetKeyName(11, "Resource.ur.resx");
            imageList.Images.SetKeyName(12, "Resource.is.resx");
            imageList.Images.SetKeyName(13, "Resource.zh.resx");
            imageList.Images.SetKeyName(14, "Resource.et.resx");
            imageList.Images.SetKeyName(15, "Resource.lv.resx");
            imageList.Images.SetKeyName(16, "Resource.lt.resx");
            imageList.Images.SetKeyName(17, "Resource.pt.resx");
            imageList.Images.SetKeyName(18, "Resource.it.resx");
            imageList.Images.SetKeyName(19, "Resource.hi.resx");
            imageList.Images.SetKeyName(20, "Resource.be.resx");
            imageList.Images.SetKeyName(21, "Resource.bg.resx");
            imageList.Images.SetKeyName(22, "Resource.id.resx");
            imageList.Images.SetKeyName(23, "Resource.nb.resx");
            imageList.Images.SetKeyName(24, "Resource.pl.resx");
            imageList.Images.SetKeyName(25, "Resource.uk.resx");
            imageList.Images.SetKeyName(26, "Resource.fa.resx");
            imageList.Images.SetKeyName(27, "Resource.he.resx");
            imageList.Images.SetKeyName(28, "Resource.cs.resx");
            imageList.Images.SetKeyName(29, "Resource.el.resx");
            imageList.Images.SetKeyName(30, "Resource.hu.resx");
            imageList.Images.SetKeyName(31, "Resource.ko.resx");
            imageList.Images.SetKeyName(32, "Resource.kn.resx");
            imageList.Images.SetKeyName(33, "Resource.ms.resx");
            imageList.Images.SetKeyName(34, "Resource.ro.resx");
            imageList.Images.SetKeyName(35, "Resource.sw.resx");
            imageList.Images.SetKeyName(36, "Resource.tr.resx");
            imageList.Images.SetKeyName(37, "Resource.vi.resx");
            imageList.Images.SetKeyName(38, "Resource.bn.resx");
            imageList.Images.SetKeyName(39, "Resource.az.resx");
            // 
            // txtNameSpace
            // 
            txtNameSpace.Location = new Point(12, 12);
            txtNameSpace.Name = "txtNameSpace";
            txtNameSpace.Size = new Size(416, 23);
            txtNameSpace.TabIndex = 3;
            txtNameSpace.Text = "Onnea.Shared.ResourceFiles";
            // 
            // txtCodeFile
            // 
            txtCodeFile.Location = new Point(12, 41);
            txtCodeFile.Name = "txtCodeFile";
            txtCodeFile.Size = new Size(416, 23);
            txtCodeFile.TabIndex = 4;
            txtCodeFile.Text = "Resource.designer.cs";
            // 
            // BtnTranslate
            // 
            BtnTranslate.Location = new Point(12, 74);
            BtnTranslate.Name = "BtnTranslate";
            BtnTranslate.Size = new Size(174, 36);
            BtnTranslate.TabIndex = 6;
            BtnTranslate.Text = "Translate with ChatGPT";
            BtnTranslate.UseVisualStyleBackColor = true;
            BtnTranslate.Click += BtnTranslate_Click;
            // 
            // cboToLanguage
            // 
            cboToLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboToLanguage.FormattingEnabled = true;
            cboToLanguage.Location = new Point(496, 74);
            cboToLanguage.Name = "cboToLanguage";
            cboToLanguage.Size = new Size(119, 23);
            cboToLanguage.TabIndex = 7;
            cboToLanguage.SelectedIndexChanged += cboToLanguage_SelectedIndexChanged;
            // 
            // cboFromLanguage
            // 
            cboFromLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFromLanguage.Location = new Point(289, 74);
            cboFromLanguage.Name = "cboFromLanguage";
            cboFromLanguage.Size = new Size(121, 23);
            cboFromLanguage.TabIndex = 11;
            cboFromLanguage.SelectedIndexChanged += cboFromLanguage_SelectedIndexChanged;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(196, 74);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(87, 15);
            lblFrom.TabIndex = 9;
            lblFrom.Text = "From language";
            // 
            // lblToLanguage
            // 
            lblToLanguage.AutoSize = true;
            lblToLanguage.Location = new Point(416, 74);
            lblToLanguage.Name = "lblToLanguage";
            lblToLanguage.Size = new Size(74, 15);
            lblToLanguage.TabIndex = 10;
            lblToLanguage.Text = "To Language";
            // 
            // txtAPIKey
            // 
            txtAPIKey.Location = new Point(434, 41);
            txtAPIKey.Name = "txtAPIKey";
            txtAPIKey.Size = new Size(229, 23);
            txtAPIKey.TabIndex = 12;
            // 
            // lblAPIKEY
            // 
            lblAPIKEY.AutoSize = true;
            lblAPIKEY.Location = new Point(437, 13);
            lblAPIKEY.Name = "lblAPIKEY";
            lblAPIKEY.Size = new Size(48, 15);
            lblAPIKEY.TabIndex = 13;
            lblAPIKEY.Text = "API KEY";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 449);
            Controls.Add(lblAPIKEY);
            Controls.Add(txtAPIKey);
            Controls.Add(lblToLanguage);
            Controls.Add(lblFrom);
            Controls.Add(cboFromLanguage);
            Controls.Add(cboToLanguage);
            Controls.Add(BtnTranslate);
            Controls.Add(txtCodeFile);
            Controls.Add(txtNameSpace);
            Controls.Add(BtnSave);
            Controls.Add(BtnLoad);
            Controls.Add(GrdResource);
            Name = "frmMain";
            Text = "Simple Translation Tool";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)GrdResource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView GrdResource;
        private Button BtnLoad;
        private Button BtnSave;
        private OpenFileDialog openFileDialog1;
        private ImageList imageList;
        private TextBox txtNameSpace;
        private TextBox txtCodeFile;
        private TextBox txtChatGpt;
        private Button BtnTranslate;
        private ComboBox cboToLanguage;
        private ComboBox cboFromLanguage;
        private Label lblFrom;
        private Label lblToLanguage;
        private TextBox txtAPIKey;
        private Label lblAPIKEY;
    }
}