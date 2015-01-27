namespace Idmr.CockpitEditor
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.pctMask = new System.Windows.Forms.PictureBox();
			this.cmdOpen = new System.Windows.Forms.Button();
			this.opnFile = new System.Windows.Forms.OpenFileDialog();
			this.lblFile = new System.Windows.Forms.Label();
			this.cmdPanl = new System.Windows.Forms.Button();
			this.cmdMask = new System.Windows.Forms.Button();
			this.numMaskX = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numMaskY = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numMaskWidth = new System.Windows.Forms.NumericUpDown();
			this.numMaskHeight = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numYAxis = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtLfd = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cboStatus = new System.Windows.Forms.ComboBox();
			this.panView = new System.Windows.Forms.Panel();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.cboView = new System.Windows.Forms.ComboBox();
			this.pctItem = new System.Windows.Forms.PictureBox();
			this.cmdPrev = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this.panItems = new System.Windows.Forms.Panel();
			this.panDisplayMode = new System.Windows.Forms.Panel();
			this.label14 = new System.Windows.Forms.Label();
			this.optDisplayItem = new System.Windows.Forms.RadioButton();
			this.optDisplayOutline = new System.Windows.Forms.RadioButton();
			this.optDisplayNone = new System.Windows.Forms.RadioButton();
			this.lblItem = new System.Windows.Forms.Label();
			this.panLaser = new System.Windows.Forms.Panel();
			this.optLaserLeft = new System.Windows.Forms.RadioButton();
			this.optLaserRight = new System.Windows.Forms.RadioButton();
			this.lblZoom = new System.Windows.Forms.Label();
			this.numVar2 = new System.Windows.Forms.NumericUpDown();
			this.numItemY = new System.Windows.Forms.NumericUpDown();
			this.numVar1 = new System.Windows.Forms.NumericUpDown();
			this.numItemX = new System.Windows.Forms.NumericUpDown();
			this.lblVar2 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lblVar1 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.cboItems = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.cboPanlIndex = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pctMask)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaskX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaskY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaskWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaskHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numYAxis)).BeginInit();
			this.panView.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctItem)).BeginInit();
			this.panItems.SuspendLayout();
			this.panDisplayMode.SuspendLayout();
			this.panLaser.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numVar2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numItemY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numVar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numItemX)).BeginInit();
			this.SuspendLayout();
			// 
			// pctMask
			// 
			this.pctMask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pctMask.Location = new System.Drawing.Point(149, 52);
			this.pctMask.Name = "pctMask";
			this.pctMask.Size = new System.Drawing.Size(640, 480);
			this.pctMask.TabIndex = 0;
			this.pctMask.TabStop = false;
			this.pctMask.Paint += new System.Windows.Forms.PaintEventHandler(this.pctMask_Paint);
			// 
			// cmdOpen
			// 
			this.cmdOpen.Location = new System.Drawing.Point(12, 12);
			this.cmdOpen.Name = "cmdOpen";
			this.cmdOpen.Size = new System.Drawing.Size(75, 23);
			this.cmdOpen.TabIndex = 0;
			this.cmdOpen.Text = "&Open";
			this.cmdOpen.UseVisualStyleBackColor = true;
			this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
			// 
			// opnFile
			// 
			this.opnFile.DefaultExt = "int";
			this.opnFile.Filter = "Cockpit Files|*.int";
			this.opnFile.FileOk += new System.ComponentModel.CancelEventHandler(this.opnFile_FileOk);
			// 
			// lblFile
			// 
			this.lblFile.AutoSize = true;
			this.lblFile.Location = new System.Drawing.Point(93, 17);
			this.lblFile.Name = "lblFile";
			this.lblFile.Size = new System.Drawing.Size(73, 13);
			this.lblFile.TabIndex = 3;
			this.lblFile.Text = "(No File open)";
			// 
			// cmdPanl
			// 
			this.cmdPanl.Enabled = false;
			this.cmdPanl.Location = new System.Drawing.Point(54, 43);
			this.cmdPanl.Name = "cmdPanl";
			this.cmdPanl.Size = new System.Drawing.Size(75, 23);
			this.cmdPanl.TabIndex = 2;
			this.cmdPanl.Text = "PANL";
			this.cmdPanl.UseVisualStyleBackColor = true;
			this.cmdPanl.Click += new System.EventHandler(this.cmdPanl_Click);
			// 
			// cmdMask
			// 
			this.cmdMask.Enabled = false;
			this.cmdMask.Location = new System.Drawing.Point(54, 72);
			this.cmdMask.Name = "cmdMask";
			this.cmdMask.Size = new System.Drawing.Size(75, 23);
			this.cmdMask.TabIndex = 2;
			this.cmdMask.Text = "MASK";
			this.cmdMask.UseVisualStyleBackColor = true;
			this.cmdMask.Click += new System.EventHandler(this.cmdMask_Click);
			// 
			// numMaskX
			// 
			this.numMaskX.Location = new System.Drawing.Point(79, 96);
			this.numMaskX.Maximum = new decimal(new int[] {
            639,
            0,
            0,
            0});
			this.numMaskX.Name = "numMaskX";
			this.numMaskX.Size = new System.Drawing.Size(50, 20);
			this.numMaskX.TabIndex = 3;
			this.numMaskX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numMaskX.ValueChanged += new System.EventHandler(this.numMaskX_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 98);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Mask X";
			// 
			// numMaskY
			// 
			this.numMaskY.Location = new System.Drawing.Point(79, 122);
			this.numMaskY.Maximum = new decimal(new int[] {
            455,
            0,
            0,
            0});
			this.numMaskY.Name = "numMaskY";
			this.numMaskY.Size = new System.Drawing.Size(50, 20);
			this.numMaskY.TabIndex = 4;
			this.numMaskY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numMaskY.ValueChanged += new System.EventHandler(this.numMaskY_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Mask Y";
			// 
			// numMaskWidth
			// 
			this.numMaskWidth.Location = new System.Drawing.Point(79, 148);
			this.numMaskWidth.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
			this.numMaskWidth.Name = "numMaskWidth";
			this.numMaskWidth.Size = new System.Drawing.Size(50, 20);
			this.numMaskWidth.TabIndex = 5;
			this.numMaskWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// numMaskHeight
			// 
			this.numMaskHeight.Location = new System.Drawing.Point(79, 174);
			this.numMaskHeight.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
			this.numMaskHeight.Name = "numMaskHeight";
			this.numMaskHeight.Size = new System.Drawing.Size(50, 20);
			this.numMaskHeight.TabIndex = 6;
			this.numMaskHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 150);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Mask Width";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 176);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Mask Height";
			// 
			// numYAxis
			// 
			this.numYAxis.Location = new System.Drawing.Point(79, 200);
			this.numYAxis.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
			this.numYAxis.Minimum = new decimal(new int[] {
            32767,
            0,
            0,
            -2147483648});
			this.numYAxis.Name = "numYAxis";
			this.numYAxis.Size = new System.Drawing.Size(50, 20);
			this.numYAxis.TabIndex = 7;
			this.numYAxis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 202);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Y offset";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(54, 225);
			this.txtName.MaxLength = 8;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(75, 20);
			this.txtName.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 228);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Name";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 254);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "LFD File";
			// 
			// txtLfd
			// 
			this.txtLfd.Location = new System.Drawing.Point(54, 251);
			this.txtLfd.MaxLength = 8;
			this.txtLfd.Name = "txtLfd";
			this.txtLfd.Size = new System.Drawing.Size(75, 20);
			this.txtLfd.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(5, 280);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Status";
			// 
			// cboStatus
			// 
			this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStatus.FormattingEnabled = true;
			this.cboStatus.Location = new System.Drawing.Point(5, 302);
			this.cboStatus.Name = "cboStatus";
			this.cboStatus.Size = new System.Drawing.Size(125, 21);
			this.cboStatus.TabIndex = 10;
			this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
			// 
			// panView
			// 
			this.panView.Controls.Add(this.label10);
			this.panView.Controls.Add(this.label9);
			this.panView.Controls.Add(this.cboView);
			this.panView.Controls.Add(this.cmdPanl);
			this.panView.Controls.Add(this.cboStatus);
			this.panView.Controls.Add(this.cmdMask);
			this.panView.Controls.Add(this.label8);
			this.panView.Controls.Add(this.txtLfd);
			this.panView.Controls.Add(this.label1);
			this.panView.Controls.Add(this.numMaskX);
			this.panView.Controls.Add(this.label7);
			this.panView.Controls.Add(this.numMaskWidth);
			this.panView.Controls.Add(this.txtName);
			this.panView.Controls.Add(this.label3);
			this.panView.Controls.Add(this.label6);
			this.panView.Controls.Add(this.numMaskY);
			this.panView.Controls.Add(this.label5);
			this.panView.Controls.Add(this.numYAxis);
			this.panView.Controls.Add(this.numMaskHeight);
			this.panView.Controls.Add(this.label4);
			this.panView.Controls.Add(this.label2);
			this.panView.Enabled = false;
			this.panView.Location = new System.Drawing.Point(8, 52);
			this.panView.Name = "panView";
			this.panView.Size = new System.Drawing.Size(135, 333);
			this.panView.TabIndex = 9;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(5, 60);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(37, 13);
			this.label10.TabIndex = 12;
			this.label10.Text = "Show:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(33, 13);
			this.label9.TabIndex = 11;
			this.label9.Text = "View:";
			// 
			// cboView
			// 
			this.cboView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboView.FormattingEnabled = true;
			this.cboView.Location = new System.Drawing.Point(5, 16);
			this.cboView.Name = "cboView";
			this.cboView.Size = new System.Drawing.Size(125, 21);
			this.cboView.TabIndex = 1;
			this.cboView.SelectedIndexChanged += new System.EventHandler(this.cboView_SelectedIndexChanged);
			// 
			// pctItem
			// 
			this.pctItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pctItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pctItem.Location = new System.Drawing.Point(3, 3);
			this.pctItem.Name = "pctItem";
			this.pctItem.Size = new System.Drawing.Size(350, 160);
			this.pctItem.TabIndex = 11;
			this.pctItem.TabStop = false;
			// 
			// cmdPrev
			// 
			this.cmdPrev.Enabled = false;
			this.cmdPrev.Location = new System.Drawing.Point(3, 169);
			this.cmdPrev.Name = "cmdPrev";
			this.cmdPrev.Size = new System.Drawing.Size(75, 23);
			this.cmdPrev.TabIndex = 12;
			this.cmdPrev.Text = "Prev";
			this.cmdPrev.UseVisualStyleBackColor = true;
			this.cmdPrev.Click += new System.EventHandler(this.cmdPrev_Click);
			// 
			// cmdNext
			// 
			this.cmdNext.Enabled = false;
			this.cmdNext.Location = new System.Drawing.Point(278, 169);
			this.cmdNext.Name = "cmdNext";
			this.cmdNext.Size = new System.Drawing.Size(75, 23);
			this.cmdNext.TabIndex = 12;
			this.cmdNext.Text = "Next";
			this.cmdNext.UseVisualStyleBackColor = true;
			this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
			// 
			// panItems
			// 
			this.panItems.Controls.Add(this.panDisplayMode);
			this.panItems.Controls.Add(this.lblItem);
			this.panItems.Controls.Add(this.panLaser);
			this.panItems.Controls.Add(this.lblZoom);
			this.panItems.Controls.Add(this.numVar2);
			this.panItems.Controls.Add(this.numItemY);
			this.panItems.Controls.Add(this.numVar1);
			this.panItems.Controls.Add(this.numItemX);
			this.panItems.Controls.Add(this.lblVar2);
			this.panItems.Controls.Add(this.label13);
			this.panItems.Controls.Add(this.lblVar1);
			this.panItems.Controls.Add(this.label12);
			this.panItems.Controls.Add(this.cboItems);
			this.panItems.Controls.Add(this.label11);
			this.panItems.Controls.Add(this.pctItem);
			this.panItems.Controls.Add(this.cboPanlIndex);
			this.panItems.Controls.Add(this.cmdPrev);
			this.panItems.Controls.Add(this.cmdNext);
			this.panItems.Enabled = false;
			this.panItems.Location = new System.Drawing.Point(795, 52);
			this.panItems.Name = "panItems";
			this.panItems.Size = new System.Drawing.Size(364, 480);
			this.panItems.TabIndex = 14;
			// 
			// panDisplayMode
			// 
			this.panDisplayMode.Controls.Add(this.label14);
			this.panDisplayMode.Controls.Add(this.optDisplayItem);
			this.panDisplayMode.Controls.Add(this.optDisplayOutline);
			this.panDisplayMode.Controls.Add(this.optDisplayNone);
			this.panDisplayMode.Location = new System.Drawing.Point(6, 310);
			this.panDisplayMode.Name = "panDisplayMode";
			this.panDisplayMode.Size = new System.Drawing.Size(223, 23);
			this.panDisplayMode.TabIndex = 22;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(3, 5);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(44, 13);
			this.label14.TabIndex = 1;
			this.label14.Text = "Display:";
			// 
			// optDisplayItem
			// 
			this.optDisplayItem.AutoSize = true;
			this.optDisplayItem.Checked = true;
			this.optDisplayItem.Location = new System.Drawing.Point(170, 3);
			this.optDisplayItem.Name = "optDisplayItem";
			this.optDisplayItem.Size = new System.Drawing.Size(45, 17);
			this.optDisplayItem.TabIndex = 23;
			this.optDisplayItem.TabStop = true;
			this.optDisplayItem.Text = "Item";
			this.optDisplayItem.UseVisualStyleBackColor = true;
			this.optDisplayItem.CheckedChanged += new System.EventHandler(this.optDisplay_CheckedChanged);
			// 
			// optDisplayOutline
			// 
			this.optDisplayOutline.AutoSize = true;
			this.optDisplayOutline.Location = new System.Drawing.Point(110, 3);
			this.optDisplayOutline.Name = "optDisplayOutline";
			this.optDisplayOutline.Size = new System.Drawing.Size(58, 17);
			this.optDisplayOutline.TabIndex = 21;
			this.optDisplayOutline.Text = "Outline";
			this.optDisplayOutline.UseVisualStyleBackColor = true;
			// 
			// optDisplayNone
			// 
			this.optDisplayNone.AutoSize = true;
			this.optDisplayNone.Location = new System.Drawing.Point(53, 3);
			this.optDisplayNone.Name = "optDisplayNone";
			this.optDisplayNone.Size = new System.Drawing.Size(51, 17);
			this.optDisplayNone.TabIndex = 20;
			this.optDisplayNone.Text = "None";
			this.optDisplayNone.UseVisualStyleBackColor = true;
			this.optDisplayNone.CheckedChanged += new System.EventHandler(this.optDisplay_CheckedChanged);
			// 
			// lblItem
			// 
			this.lblItem.Location = new System.Drawing.Point(82, 174);
			this.lblItem.Name = "lblItem";
			this.lblItem.Size = new System.Drawing.Size(190, 18);
			this.lblItem.TabIndex = 21;
			this.lblItem.Text = "lblItem";
			// 
			// panLaser
			// 
			this.panLaser.Controls.Add(this.optLaserLeft);
			this.panLaser.Controls.Add(this.optLaserRight);
			this.panLaser.Location = new System.Drawing.Point(224, 278);
			this.panLaser.Name = "panLaser";
			this.panLaser.Size = new System.Drawing.Size(102, 21);
			this.panLaser.TabIndex = 20;
			this.panLaser.Visible = false;
			// 
			// optLaserLeft
			// 
			this.optLaserLeft.AutoSize = true;
			this.optLaserLeft.Checked = true;
			this.optLaserLeft.Location = new System.Drawing.Point(3, 3);
			this.optLaserLeft.Name = "optLaserLeft";
			this.optLaserLeft.Size = new System.Drawing.Size(43, 17);
			this.optLaserLeft.TabIndex = 18;
			this.optLaserLeft.TabStop = true;
			this.optLaserLeft.Text = "Left";
			this.optLaserLeft.UseVisualStyleBackColor = true;
			// 
			// optLaserRight
			// 
			this.optLaserRight.AutoSize = true;
			this.optLaserRight.Location = new System.Drawing.Point(46, 3);
			this.optLaserRight.Name = "optLaserRight";
			this.optLaserRight.Size = new System.Drawing.Size(50, 17);
			this.optLaserRight.TabIndex = 19;
			this.optLaserRight.Text = "Right";
			this.optLaserRight.UseVisualStyleBackColor = true;
			this.optLaserRight.CheckedChanged += new System.EventHandler(this.optLaserRight_CheckedChanged);
			// 
			// lblZoom
			// 
			this.lblZoom.AutoSize = true;
			this.lblZoom.Location = new System.Drawing.Point(275, 195);
			this.lblZoom.Name = "lblZoom";
			this.lblZoom.Size = new System.Drawing.Size(51, 13);
			this.lblZoom.TabIndex = 18;
			this.lblZoom.Text = "Zoom: 1x";
			// 
			// numVar2
			// 
			this.numVar2.Location = new System.Drawing.Point(172, 278);
			this.numVar2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numVar2.Name = "numVar2";
			this.numVar2.Size = new System.Drawing.Size(45, 20);
			this.numVar2.TabIndex = 17;
			this.numVar2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numVar2.ValueChanged += new System.EventHandler(this.numVar2_ValueChanged);
			// 
			// numItemY
			// 
			this.numItemY.Location = new System.Drawing.Point(39, 278);
			this.numItemY.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
			this.numItemY.Name = "numItemY";
			this.numItemY.Size = new System.Drawing.Size(45, 20);
			this.numItemY.TabIndex = 15;
			this.numItemY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numItemY.ValueChanged += new System.EventHandler(this.numItemY_ValueChanged);
			// 
			// numVar1
			// 
			this.numVar1.Location = new System.Drawing.Point(172, 256);
			this.numVar1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numVar1.Name = "numVar1";
			this.numVar1.Size = new System.Drawing.Size(45, 20);
			this.numVar1.TabIndex = 16;
			this.numVar1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numVar1.ValueChanged += new System.EventHandler(this.numVar1_ValueChanged);
			// 
			// numItemX
			// 
			this.numItemX.Location = new System.Drawing.Point(39, 256);
			this.numItemX.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
			this.numItemX.Name = "numItemX";
			this.numItemX.Size = new System.Drawing.Size(45, 20);
			this.numItemX.TabIndex = 14;
			this.numItemX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numItemX.ValueChanged += new System.EventHandler(this.numItemX_ValueChanged);
			// 
			// lblVar2
			// 
			this.lblVar2.Location = new System.Drawing.Point(107, 280);
			this.lblVar2.Name = "lblVar2";
			this.lblVar2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblVar2.Size = new System.Drawing.Size(59, 18);
			this.lblVar2.TabIndex = 16;
			this.lblVar2.Text = "Var2";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(3, 280);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(14, 13);
			this.label13.TabIndex = 16;
			this.label13.Text = "Y";
			// 
			// lblVar1
			// 
			this.lblVar1.Location = new System.Drawing.Point(107, 258);
			this.lblVar1.Name = "lblVar1";
			this.lblVar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblVar1.Size = new System.Drawing.Size(59, 18);
			this.lblVar1.TabIndex = 16;
			this.lblVar1.Text = "Var1";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(3, 258);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(14, 13);
			this.label12.TabIndex = 16;
			this.label12.Text = "X";
			// 
			// cboItems
			// 
			this.cboItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboItems.FormattingEnabled = true;
			this.cboItems.Location = new System.Drawing.Point(39, 225);
			this.cboItems.Name = "cboItems";
			this.cboItems.Size = new System.Drawing.Size(175, 21);
			this.cboItems.TabIndex = 13;
			this.cboItems.SelectedIndexChanged += new System.EventHandler(this.cboItems_SelectedIndexChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(3, 225);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(30, 13);
			this.label11.TabIndex = 14;
			this.label11.Text = "Item:";
			// 
			// cboPanlIndex
			// 
			this.cboPanlIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPanlIndex.FormattingEnabled = true;
			this.cboPanlIndex.Location = new System.Drawing.Point(220, 228);
			this.cboPanlIndex.Name = "cboPanlIndex";
			this.cboPanlIndex.Size = new System.Drawing.Size(133, 21);
			this.cboPanlIndex.TabIndex = 16;
			this.cboPanlIndex.Visible = false;
			this.cboPanlIndex.SelectedIndexChanged += new System.EventHandler(this.cboPanlIndex_SelectedIndexChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1164, 540);
			this.Controls.Add(this.panItems);
			this.Controls.Add(this.panView);
			this.Controls.Add(this.lblFile);
			this.Controls.Add(this.cmdOpen);
			this.Controls.Add(this.pctMask);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Cockpit Editor";
			((System.ComponentModel.ISupportInitialize)(this.pctMask)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaskX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaskY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaskWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaskHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numYAxis)).EndInit();
			this.panView.ResumeLayout(false);
			this.panView.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctItem)).EndInit();
			this.panItems.ResumeLayout(false);
			this.panItems.PerformLayout();
			this.panDisplayMode.ResumeLayout(false);
			this.panDisplayMode.PerformLayout();
			this.panLaser.ResumeLayout(false);
			this.panLaser.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numVar2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numItemY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numVar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numItemX)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pctMask;
		private System.Windows.Forms.Button cmdOpen;
		private System.Windows.Forms.OpenFileDialog opnFile;
		private System.Windows.Forms.Label lblFile;
		private System.Windows.Forms.Button cmdPanl;
		private System.Windows.Forms.Button cmdMask;
		private System.Windows.Forms.NumericUpDown numMaskX;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numMaskY;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numMaskWidth;
		private System.Windows.Forms.NumericUpDown numMaskHeight;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numYAxis;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtLfd;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cboStatus;
		private System.Windows.Forms.Panel panView;
		private System.Windows.Forms.ComboBox cboView;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.PictureBox pctItem;
		private System.Windows.Forms.Button cmdPrev;
		private System.Windows.Forms.Button cmdNext;
		private System.Windows.Forms.Panel panItems;
		private System.Windows.Forms.ComboBox cboItems;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown numVar2;
		private System.Windows.Forms.NumericUpDown numItemY;
		private System.Windows.Forms.NumericUpDown numVar1;
		private System.Windows.Forms.NumericUpDown numItemX;
		private System.Windows.Forms.Label lblVar2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lblVar1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label lblZoom;
		private System.Windows.Forms.Panel panLaser;
		private System.Windows.Forms.RadioButton optLaserLeft;
		private System.Windows.Forms.RadioButton optLaserRight;
		private System.Windows.Forms.ComboBox cboPanlIndex;
		private System.Windows.Forms.Label lblItem;
		private System.Windows.Forms.Panel panDisplayMode;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.RadioButton optDisplayItem;
		private System.Windows.Forms.RadioButton optDisplayOutline;
		private System.Windows.Forms.RadioButton optDisplayNone;
	}
}

