using Liplis.Cmp.Form;

namespace Liplis.MainSystem
{
    partial class LpsInputWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LpsInputWindow));
            this.txtInput = new System.Windows.Forms.TextBox();
            this.pnlSend = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnWakachi = new System.Windows.Forms.Button();
            this.btnEmotion = new System.Windows.Forms.Button();
            this.chkToneConvert = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelpVer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvEmotionSetting = new cusDataGridView();
            this.cmsDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNewCol = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBr = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiString = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringSize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringSize1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringSize2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringSize3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringSize4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringSize5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringSize6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringSize7 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringColorBlack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringColorWhite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringColorRed = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringColorGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringColorBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringColorYellow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringColorPurple = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringBold = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringItalic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStringStrike = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.divToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTag = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTagHr = new System.Windows.Forms.ToolStripMenuItem();
            this.spl = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.pnlSend.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmotionSetting)).BeginInit();
            this.cmsDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spl)).BeginInit();
            this.spl.Panel1.SuspendLayout();
            this.spl.Panel2.SuspendLayout();
            this.spl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Location = new System.Drawing.Point(0, 0);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(624, 283);
            this.txtInput.TabIndex = 0;
            // 
            // pnlSend
            // 
            this.pnlSend.Controls.Add(this.btnStop);
            this.pnlSend.Controls.Add(this.btnSend);
            this.pnlSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSend.Location = new System.Drawing.Point(0, 411);
            this.pnlSend.Name = "pnlSend";
            this.pnlSend.Size = new System.Drawing.Size(624, 30);
            this.pnlSend.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(6, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(125, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "おしゃべりスタート";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(541, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(71, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnWakachi
            // 
            this.btnWakachi.Location = new System.Drawing.Point(83, 4);
            this.btnWakachi.Name = "btnWakachi";
            this.btnWakachi.Size = new System.Drawing.Size(71, 23);
            this.btnWakachi.TabIndex = 6;
            this.btnWakachi.Text = "分かち書き";
            this.btnWakachi.UseVisualStyleBackColor = true;
            this.btnWakachi.Click += new System.EventHandler(this.btnWakachi_Click);
            // 
            // btnEmotion
            // 
            this.btnEmotion.Location = new System.Drawing.Point(6, 4);
            this.btnEmotion.Name = "btnEmotion";
            this.btnEmotion.Size = new System.Drawing.Size(71, 23);
            this.btnEmotion.TabIndex = 5;
            this.btnEmotion.Text = "感情付与";
            this.btnEmotion.UseVisualStyleBackColor = true;
            this.btnEmotion.Click += new System.EventHandler(this.btnEmotion_Click);
            // 
            // chkToneConvert
            // 
            this.chkToneConvert.AutoSize = true;
            this.chkToneConvert.Location = new System.Drawing.Point(160, 8);
            this.chkToneConvert.Name = "chkToneConvert";
            this.chkToneConvert.Size = new System.Drawing.Size(72, 16);
            this.chkToneConvert.TabIndex = 3;
            this.chkToneConvert.Text = "口調変換";
            this.chkToneConvert.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiEdit,
            this.tsmiSetting,
            this.tsmiHelpVer});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEnd});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(66, 20);
            this.tsmiFile.Text = "ファイル(&F)";
            // 
            // tsmiEnd
            // 
            this.tsmiEnd.Image = global::Liplis.Properties.Resources.ico_pow;
            this.tsmiEnd.Name = "tsmiEnd";
            this.tsmiEnd.Size = new System.Drawing.Size(113, 22);
            this.tsmiEnd.Text = "終了(&X)";
            this.tsmiEnd.Click += new System.EventHandler(this.tsmiEnd_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClear});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(57, 20);
            this.tsmiEdit.Text = "編集(&E)";
            // 
            // tsmiClear
            // 
            this.tsmiClear.Image = global::Liplis.Properties.Resources.widTest;
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(100, 22);
            this.tsmiClear.Text = "クリア";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // tsmiSetting
            // 
            this.tsmiSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenSetting});
            this.tsmiSetting.Name = "tsmiSetting";
            this.tsmiSetting.Size = new System.Drawing.Size(60, 20);
            this.tsmiSetting.Text = "設定(&O)";
            // 
            // tsmiOpenSetting
            // 
            this.tsmiOpenSetting.Image = global::Liplis.Properties.Resources.sel_setting;
            this.tsmiOpenSetting.Name = "tsmiOpenSetting";
            this.tsmiOpenSetting.Size = new System.Drawing.Size(126, 22);
            this.tsmiOpenSetting.Text = "設定を開く";
            this.tsmiOpenSetting.Click += new System.EventHandler(this.tsmiOpenSetting_Click);
            // 
            // tsmiHelpVer
            // 
            this.tsmiHelpVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHelp,
            this.tsmiVersion});
            this.tsmiHelpVer.Name = "tsmiHelpVer";
            this.tsmiHelpVer.Size = new System.Drawing.Size(109, 20);
            this.tsmiHelpVer.Text = "ツールの使い方など";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Image = global::Liplis.Properties.Resources.sel_topic;
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(151, 22);
            this.tsmiHelp.Text = "LiplisDollヘルプ";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // tsmiVersion
            // 
            this.tsmiVersion.Image = global::Liplis.Properties.Resources.sel_upd;
            this.tsmiVersion.Name = "tsmiVersion";
            this.tsmiVersion.Size = new System.Drawing.Size(151, 22);
            this.tsmiVersion.Text = "バージョン情報";
            this.tsmiVersion.Click += new System.EventHandler(this.tsmiVersion_Click);
            // 
            // dgvEmotionSetting
            // 
            this.dgvEmotionSetting.AllowUserToAddRows = false;
            this.dgvEmotionSetting.AllowUserToDeleteRows = false;
            this.dgvEmotionSetting.AllowUserToOrderColumns = true;
            this.dgvEmotionSetting.AllowUserToResizeColumns = false;
            this.dgvEmotionSetting.AllowUserToResizeRows = false;
            this.dgvEmotionSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmotionSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmotionSetting.Location = new System.Drawing.Point(0, 0);
            this.dgvEmotionSetting.Name = "dgvEmotionSetting";
            this.dgvEmotionSetting.RowTemplate.Height = 21;
            this.dgvEmotionSetting.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvEmotionSetting.Size = new System.Drawing.Size(624, 100);
            this.dgvEmotionSetting.TabIndex = 5;
            this.dgvEmotionSetting.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmotionSetting_CellMouseClick);
            this.dgvEmotionSetting.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvEmotionSetting_CellValidating);
            this.dgvEmotionSetting.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmotionSetting_CellValueChanged);
            this.dgvEmotionSetting.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvEmotionSetting_KeyDown);
            // 
            // cmsDataGrid
            // 
            this.cmsDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewCol,
            this.tsmiBr,
            this.tsmiString,
            this.tsmiBlock,
            this.tsmiTag});
            this.cmsDataGrid.Name = "cmsDataGrid";
            this.cmsDataGrid.Size = new System.Drawing.Size(138, 114);
            // 
            // tsmiNewCol
            // 
            this.tsmiNewCol.Name = "tsmiNewCol";
            this.tsmiNewCol.Size = new System.Drawing.Size(137, 22);
            this.tsmiNewCol.Text = "新規列 挿入";
            this.tsmiNewCol.Click += new System.EventHandler(this.tsmiNewCol_Click);
            // 
            // tsmiBr
            // 
            this.tsmiBr.Name = "tsmiBr";
            this.tsmiBr.Size = new System.Drawing.Size(137, 22);
            this.tsmiBr.Text = "改行挿入";
            this.tsmiBr.Click += new System.EventHandler(this.tsmiBr_Click);
            // 
            // tsmiString
            // 
            this.tsmiString.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStringSize,
            this.tsmiStringColor,
            this.tsmiStringBold,
            this.tsmiStringItalic,
            this.tsmiStringStrike});
            this.tsmiString.Name = "tsmiString";
            this.tsmiString.Size = new System.Drawing.Size(137, 22);
            this.tsmiString.Text = "文字装飾";
            // 
            // tsmiStringSize
            // 
            this.tsmiStringSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStringSize1,
            this.tsmiStringSize2,
            this.tsmiStringSize3,
            this.tsmiStringSize4,
            this.tsmiStringSize5,
            this.tsmiStringSize6,
            this.tsmiStringSize7});
            this.tsmiStringSize.Name = "tsmiStringSize";
            this.tsmiStringSize.Size = new System.Drawing.Size(161, 22);
            this.tsmiStringSize.Text = "文字の大きさ変更";
            // 
            // tsmiStringSize1
            // 
            this.tsmiStringSize1.Name = "tsmiStringSize1";
            this.tsmiStringSize1.Size = new System.Drawing.Size(80, 22);
            this.tsmiStringSize1.Text = "1";
            this.tsmiStringSize1.Click += new System.EventHandler(this.tsmiStringSize_Click);
            // 
            // tsmiStringSize2
            // 
            this.tsmiStringSize2.Name = "tsmiStringSize2";
            this.tsmiStringSize2.Size = new System.Drawing.Size(80, 22);
            this.tsmiStringSize2.Text = "2";
            this.tsmiStringSize2.Click += new System.EventHandler(this.tsmiStringSize_Click);
            // 
            // tsmiStringSize3
            // 
            this.tsmiStringSize3.Name = "tsmiStringSize3";
            this.tsmiStringSize3.Size = new System.Drawing.Size(80, 22);
            this.tsmiStringSize3.Text = "3";
            this.tsmiStringSize3.Click += new System.EventHandler(this.tsmiStringSize_Click);
            // 
            // tsmiStringSize4
            // 
            this.tsmiStringSize4.Name = "tsmiStringSize4";
            this.tsmiStringSize4.Size = new System.Drawing.Size(80, 22);
            this.tsmiStringSize4.Text = "4";
            this.tsmiStringSize4.Click += new System.EventHandler(this.tsmiStringSize_Click);
            // 
            // tsmiStringSize5
            // 
            this.tsmiStringSize5.Name = "tsmiStringSize5";
            this.tsmiStringSize5.Size = new System.Drawing.Size(80, 22);
            this.tsmiStringSize5.Text = "5";
            this.tsmiStringSize5.Click += new System.EventHandler(this.tsmiStringSize_Click);
            // 
            // tsmiStringSize6
            // 
            this.tsmiStringSize6.Name = "tsmiStringSize6";
            this.tsmiStringSize6.Size = new System.Drawing.Size(80, 22);
            this.tsmiStringSize6.Text = "6";
            this.tsmiStringSize6.Click += new System.EventHandler(this.tsmiStringSize_Click);
            // 
            // tsmiStringSize7
            // 
            this.tsmiStringSize7.Name = "tsmiStringSize7";
            this.tsmiStringSize7.Size = new System.Drawing.Size(80, 22);
            this.tsmiStringSize7.Text = "7";
            this.tsmiStringSize7.Click += new System.EventHandler(this.tsmiStringSize_Click);
            // 
            // tsmiStringColor
            // 
            this.tsmiStringColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStringColorBlack,
            this.tsmiStringColorWhite,
            this.tsmiStringColorRed,
            this.tsmiStringColorGreen,
            this.tsmiStringColorBlue,
            this.tsmiStringColorYellow,
            this.tsmiStringColorPurple});
            this.tsmiStringColor.Name = "tsmiStringColor";
            this.tsmiStringColor.Size = new System.Drawing.Size(161, 22);
            this.tsmiStringColor.Text = "文字色変更";
            // 
            // tsmiStringColorBlack
            // 
            this.tsmiStringColorBlack.BackColor = System.Drawing.Color.Black;
            this.tsmiStringColorBlack.ForeColor = System.Drawing.Color.White;
            this.tsmiStringColorBlack.Name = "tsmiStringColorBlack";
            this.tsmiStringColorBlack.Size = new System.Drawing.Size(98, 22);
            this.tsmiStringColorBlack.Tag = "Black";
            this.tsmiStringColorBlack.Text = "黒";
            this.tsmiStringColorBlack.Click += new System.EventHandler(this.tsmiStringColor_Click);
            // 
            // tsmiStringColorWhite
            // 
            this.tsmiStringColorWhite.BackColor = System.Drawing.Color.White;
            this.tsmiStringColorWhite.ForeColor = System.Drawing.Color.Black;
            this.tsmiStringColorWhite.Name = "tsmiStringColorWhite";
            this.tsmiStringColorWhite.Size = new System.Drawing.Size(98, 22);
            this.tsmiStringColorWhite.Tag = "White";
            this.tsmiStringColorWhite.Text = "白";
            this.tsmiStringColorWhite.Click += new System.EventHandler(this.tsmiStringColor_Click);
            // 
            // tsmiStringColorRed
            // 
            this.tsmiStringColorRed.BackColor = System.Drawing.Color.Red;
            this.tsmiStringColorRed.ForeColor = System.Drawing.Color.White;
            this.tsmiStringColorRed.Name = "tsmiStringColorRed";
            this.tsmiStringColorRed.Size = new System.Drawing.Size(98, 22);
            this.tsmiStringColorRed.Tag = "Red";
            this.tsmiStringColorRed.Text = "赤";
            this.tsmiStringColorRed.Click += new System.EventHandler(this.tsmiStringColor_Click);
            // 
            // tsmiStringColorGreen
            // 
            this.tsmiStringColorGreen.BackColor = System.Drawing.Color.Green;
            this.tsmiStringColorGreen.ForeColor = System.Drawing.Color.White;
            this.tsmiStringColorGreen.Name = "tsmiStringColorGreen";
            this.tsmiStringColorGreen.Size = new System.Drawing.Size(98, 22);
            this.tsmiStringColorGreen.Tag = "Green";
            this.tsmiStringColorGreen.Text = "緑";
            this.tsmiStringColorGreen.Click += new System.EventHandler(this.tsmiStringColor_Click);
            // 
            // tsmiStringColorBlue
            // 
            this.tsmiStringColorBlue.BackColor = System.Drawing.Color.Blue;
            this.tsmiStringColorBlue.ForeColor = System.Drawing.Color.White;
            this.tsmiStringColorBlue.Name = "tsmiStringColorBlue";
            this.tsmiStringColorBlue.Size = new System.Drawing.Size(98, 22);
            this.tsmiStringColorBlue.Tag = "Blue";
            this.tsmiStringColorBlue.Text = "青";
            this.tsmiStringColorBlue.Click += new System.EventHandler(this.tsmiStringColor_Click);
            // 
            // tsmiStringColorYellow
            // 
            this.tsmiStringColorYellow.BackColor = System.Drawing.Color.Yellow;
            this.tsmiStringColorYellow.Name = "tsmiStringColorYellow";
            this.tsmiStringColorYellow.Size = new System.Drawing.Size(98, 22);
            this.tsmiStringColorYellow.Tag = "yellow";
            this.tsmiStringColorYellow.Text = "黄色";
            this.tsmiStringColorYellow.Click += new System.EventHandler(this.tsmiStringColor_Click);
            // 
            // tsmiStringColorPurple
            // 
            this.tsmiStringColorPurple.BackColor = System.Drawing.Color.Purple;
            this.tsmiStringColorPurple.ForeColor = System.Drawing.Color.White;
            this.tsmiStringColorPurple.Name = "tsmiStringColorPurple";
            this.tsmiStringColorPurple.Size = new System.Drawing.Size(98, 22);
            this.tsmiStringColorPurple.Tag = "purple";
            this.tsmiStringColorPurple.Text = "紫";
            this.tsmiStringColorPurple.Click += new System.EventHandler(this.tsmiStringColor_Click);
            // 
            // tsmiStringBold
            // 
            this.tsmiStringBold.Name = "tsmiStringBold";
            this.tsmiStringBold.Size = new System.Drawing.Size(161, 22);
            this.tsmiStringBold.Text = "太字";
            this.tsmiStringBold.Click += new System.EventHandler(this.tsmiStringBold_Click);
            // 
            // tsmiStringItalic
            // 
            this.tsmiStringItalic.Name = "tsmiStringItalic";
            this.tsmiStringItalic.Size = new System.Drawing.Size(161, 22);
            this.tsmiStringItalic.Text = "斜体";
            this.tsmiStringItalic.Click += new System.EventHandler(this.tsmiStringItalic_Click);
            // 
            // tsmiStringStrike
            // 
            this.tsmiStringStrike.Name = "tsmiStringStrike";
            this.tsmiStringStrike.Size = new System.Drawing.Size(161, 22);
            this.tsmiStringStrike.Text = "取り消し線";
            this.tsmiStringStrike.Click += new System.EventHandler(this.tsmiStringStrike_Click);
            // 
            // tsmiBlock
            // 
            this.tsmiBlock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.divToolStripMenuItem,
            this.spanToolStripMenuItem});
            this.tsmiBlock.Name = "tsmiBlock";
            this.tsmiBlock.Size = new System.Drawing.Size(137, 22);
            this.tsmiBlock.Text = "ブロック挿入";
            // 
            // divToolStripMenuItem
            // 
            this.divToolStripMenuItem.Name = "divToolStripMenuItem";
            this.divToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.divToolStripMenuItem.Text = "div";
            this.divToolStripMenuItem.Click += new System.EventHandler(this.divToolStripMenuItem_Click);
            // 
            // spanToolStripMenuItem
            // 
            this.spanToolStripMenuItem.Name = "spanToolStripMenuItem";
            this.spanToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.spanToolStripMenuItem.Text = "span";
            this.spanToolStripMenuItem.Click += new System.EventHandler(this.spanToolStripMenuItem_Click);
            // 
            // tsmiTag
            // 
            this.tsmiTag.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTagHr});
            this.tsmiTag.Name = "tsmiTag";
            this.tsmiTag.Size = new System.Drawing.Size(137, 22);
            this.tsmiTag.Text = "タグ挿入";
            // 
            // tsmiTagHr
            // 
            this.tsmiTagHr.Name = "tsmiTagHr";
            this.tsmiTagHr.Size = new System.Drawing.Size(86, 22);
            this.tsmiTagHr.Text = "線";
            this.tsmiTagHr.Click += new System.EventHandler(this.tsmiTagHr_Click);
            // 
            // spl
            // 
            this.spl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spl.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spl.IsSplitterFixed = true;
            this.spl.Location = new System.Drawing.Point(0, 24);
            this.spl.Name = "spl";
            this.spl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spl.Panel1
            // 
            this.spl.Panel1.Controls.Add(this.panel1);
            this.spl.Panel1.Controls.Add(this.txtInput);
            // 
            // spl.Panel2
            // 
            this.spl.Panel2.Controls.Add(this.dgvEmotionSetting);
            this.spl.Size = new System.Drawing.Size(624, 387);
            this.spl.SplitterDistance = 283;
            this.spl.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnEmotion);
            this.panel1.Controls.Add(this.btnWakachi);
            this.panel1.Controls.Add(this.chkToneConvert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(137, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(125, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // LpsInputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.spl);
            this.Controls.Add(this.pnlSend);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LpsInputWindow";
            this.Text = "Liplis Doll おしゃべり入力ウインドウ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LpsInputWindow_FormClosing);
            this.pnlSend.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmotionSetting)).EndInit();
            this.cmsDataGrid.ResumeLayout(false);
            this.spl.Panel1.ResumeLayout(false);
            this.spl.Panel1.PerformLayout();
            this.spl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spl)).EndInit();
            this.spl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Panel pnlSend;
        private System.Windows.Forms.Button btnWakachi;
        private System.Windows.Forms.Button btnEmotion;
        private System.Windows.Forms.CheckBox chkToneConvert;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnd;
        private cusDataGridView dgvEmotionSetting;
        private System.Windows.Forms.SplitContainer spl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelpVer;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiVersion;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenSetting;
        private System.Windows.Forms.ContextMenuStrip cmsDataGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewCol;
        private System.Windows.Forms.ToolStripMenuItem tsmiBr;
        private System.Windows.Forms.ToolStripMenuItem tsmiString;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringSize;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringSize1;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringSize2;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringSize3;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringSize4;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringSize5;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringSize6;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringSize7;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringColor;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringColorBlack;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringColorWhite;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringColorRed;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringColorGreen;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringColorBlue;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringColorYellow;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringColorPurple;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringBold;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringItalic;
        private System.Windows.Forms.ToolStripMenuItem tsmiStringStrike;
        private System.Windows.Forms.ToolStripMenuItem tsmiBlock;
        private System.Windows.Forms.ToolStripMenuItem divToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiTag;
        private System.Windows.Forms.ToolStripMenuItem tsmiTagHr;
        private System.Windows.Forms.Button btnStop;
    }
}