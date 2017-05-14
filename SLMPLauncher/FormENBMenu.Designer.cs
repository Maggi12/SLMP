namespace SLMPLauncher
{
	partial class FormENBMenu
	{
		private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button deleteAllENBsFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button unpackENB;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.deleteAllENBsFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.unpackENB = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.buttonAA = new System.Windows.Forms.Button();
            this.buttonDOF = new System.Windows.Forms.Button();
            this.buttonDriver = new System.Windows.Forms.Button();
            this.buttonFPS = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonAmbientOcclusion = new System.Windows.Forms.Button();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonWaitBuffer = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonTemporalAA = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonSubPixelAA = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonAF = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(227, 53);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(243, 194);
            this.listBox1.TabIndex = 0;
            this.listBox1.TabStop = false;
            // 
            // deleteAllENBsFiles
            // 
            this.deleteAllENBsFiles.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteAllENBsFiles.Location = new System.Drawing.Point(226, 288);
            this.deleteAllENBsFiles.Name = "deleteAllENBsFiles";
            this.deleteAllENBsFiles.Size = new System.Drawing.Size(245, 30);
            this.deleteAllENBsFiles.TabIndex = 0;
            this.deleteAllENBsFiles.TabStop = false;
            this.deleteAllENBsFiles.Text = "Удалить все файлы ENB";
            this.deleteAllENBsFiles.UseVisualStyleBackColor = true;
            this.deleteAllENBsFiles.Click += new System.EventHandler(this.deleteAllENBsFiles_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(227, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Файлы доступные\r\nиз папки Skyrim\\ENB";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // unpackENB
            // 
            this.unpackENB.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unpackENB.Location = new System.Drawing.Point(226, 253);
            this.unpackENB.Name = "unpackENB";
            this.unpackENB.Size = new System.Drawing.Size(245, 30);
            this.unpackENB.TabIndex = 0;
            this.unpackENB.TabStop = false;
            this.unpackENB.Text = "Установить";
            this.unpackENB.UseVisualStyleBackColor = true;
            this.unpackENB.Click += new System.EventHandler(this.unpackENB_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.trackBar1.Enabled = false;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(1, 279);
            this.trackBar1.Maximum = 8;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(219, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TabStop = false;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "N/A";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Резервирование памяти:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::SLMPLauncher.Properties.Resources.line;
            this.pictureBox3.Location = new System.Drawing.Point(219, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1, 325);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(1, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Сглаживание";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(1, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "FPS лимит:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::SLMPLauncher.Properties.Resources.line;
            this.pictureBox2.Location = new System.Drawing.Point(0, 101);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(220, 1);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::SLMPLauncher.Properties.Resources.line;
            this.pictureBox4.Location = new System.Drawing.Point(0, 209);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(220, 1);
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonClose;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Location = new System.Drawing.Point(450, 8);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(20, 20);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.TabStop = false;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(1, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Динамический DOF";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::SLMPLauncher.Properties.Resources.line;
            this.pictureBox5.Location = new System.Drawing.Point(0, 128);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(220, 1);
            this.pictureBox5.TabIndex = 20;
            this.pictureBox5.TabStop = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(1, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Отключить драйвер";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::SLMPLauncher.Properties.Resources.line;
            this.pictureBox6.Location = new System.Drawing.Point(0, 155);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(220, 1);
            this.pictureBox6.TabIndex = 20;
            this.pictureBox6.TabStop = false;
            // 
            // buttonAA
            // 
            this.buttonAA.BackColor = System.Drawing.Color.Transparent;
            this.buttonAA.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonToggleDisable;
            this.buttonAA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAA.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAA.FlatAppearance.BorderSize = 0;
            this.buttonAA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAA.Location = new System.Drawing.Point(161, 5);
            this.buttonAA.Name = "buttonAA";
            this.buttonAA.Size = new System.Drawing.Size(50, 22);
            this.buttonAA.TabIndex = 0;
            this.buttonAA.TabStop = false;
            this.buttonAA.UseVisualStyleBackColor = false;
            this.buttonAA.Click += new System.EventHandler(this.buttonAA_Click);
            // 
            // buttonDOF
            // 
            this.buttonDOF.BackColor = System.Drawing.Color.Transparent;
            this.buttonDOF.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonToggleDisable;
            this.buttonDOF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDOF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonDOF.FlatAppearance.BorderSize = 0;
            this.buttonDOF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonDOF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonDOF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDOF.Location = new System.Drawing.Point(161, 185);
            this.buttonDOF.Name = "buttonDOF";
            this.buttonDOF.Size = new System.Drawing.Size(50, 22);
            this.buttonDOF.TabIndex = 0;
            this.buttonDOF.TabStop = false;
            this.buttonDOF.UseVisualStyleBackColor = false;
            this.buttonDOF.Click += new System.EventHandler(this.buttonDOF_Click);
            // 
            // buttonDriver
            // 
            this.buttonDriver.BackColor = System.Drawing.Color.Transparent;
            this.buttonDriver.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonToggleDisable;
            this.buttonDriver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDriver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonDriver.FlatAppearance.BorderSize = 0;
            this.buttonDriver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonDriver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDriver.Location = new System.Drawing.Point(161, 158);
            this.buttonDriver.Name = "buttonDriver";
            this.buttonDriver.Size = new System.Drawing.Size(50, 22);
            this.buttonDriver.TabIndex = 0;
            this.buttonDriver.TabStop = false;
            this.buttonDriver.UseVisualStyleBackColor = false;
            this.buttonDriver.Click += new System.EventHandler(this.buttonDriver_Click);
            // 
            // buttonFPS
            // 
            this.buttonFPS.BackColor = System.Drawing.Color.Transparent;
            this.buttonFPS.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonToggleDisable;
            this.buttonFPS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFPS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonFPS.FlatAppearance.BorderSize = 0;
            this.buttonFPS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonFPS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonFPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFPS.Location = new System.Drawing.Point(161, 104);
            this.buttonFPS.Name = "buttonFPS";
            this.buttonFPS.Size = new System.Drawing.Size(50, 22);
            this.buttonFPS.TabIndex = 0;
            this.buttonFPS.TabStop = false;
            this.buttonFPS.UseVisualStyleBackColor = false;
            this.buttonFPS.Click += new System.EventHandler(this.buttonFPS_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(478, 325);
            this.label10.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(1, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Модель Затенения";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonAmbientOcclusion
            // 
            this.buttonAmbientOcclusion.BackColor = System.Drawing.Color.Transparent;
            this.buttonAmbientOcclusion.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonToggleDisable;
            this.buttonAmbientOcclusion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAmbientOcclusion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAmbientOcclusion.FlatAppearance.BorderSize = 0;
            this.buttonAmbientOcclusion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAmbientOcclusion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAmbientOcclusion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAmbientOcclusion.Location = new System.Drawing.Point(161, 212);
            this.buttonAmbientOcclusion.Name = "buttonAmbientOcclusion";
            this.buttonAmbientOcclusion.Size = new System.Drawing.Size(50, 22);
            this.buttonAmbientOcclusion.TabIndex = 0;
            this.buttonAmbientOcclusion.TabStop = false;
            this.buttonAmbientOcclusion.UseVisualStyleBackColor = false;
            this.buttonAmbientOcclusion.Click += new System.EventHandler(this.buttonAmbientOcclusion_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImage = global::SLMPLauncher.Properties.Resources.line;
            this.pictureBox8.Location = new System.Drawing.Point(0, 182);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(220, 1);
            this.pictureBox8.TabIndex = 31;
            this.pictureBox8.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "30",
            "60"});
            this.comboBox1.Location = new System.Drawing.Point(97, 105);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(47, 21);
            this.comboBox1.TabIndex = 34;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(1, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ожидание кадра";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SLMPLauncher.Properties.Resources.line;
            this.pictureBox1.Location = new System.Drawing.Point(0, 236);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 1);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // buttonWaitBuffer
            // 
            this.buttonWaitBuffer.BackColor = System.Drawing.Color.Transparent;
            this.buttonWaitBuffer.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonToggleDisable;
            this.buttonWaitBuffer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonWaitBuffer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonWaitBuffer.FlatAppearance.BorderSize = 0;
            this.buttonWaitBuffer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonWaitBuffer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonWaitBuffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWaitBuffer.Location = new System.Drawing.Point(161, 131);
            this.buttonWaitBuffer.Name = "buttonWaitBuffer";
            this.buttonWaitBuffer.Size = new System.Drawing.Size(50, 22);
            this.buttonWaitBuffer.TabIndex = 0;
            this.buttonWaitBuffer.TabStop = false;
            this.buttonWaitBuffer.UseVisualStyleBackColor = false;
            this.buttonWaitBuffer.Click += new System.EventHandler(this.buttonWaitBuffer_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::SLMPLauncher.Properties.Resources.line;
            this.pictureBox7.Location = new System.Drawing.Point(0, 74);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(220, 1);
            this.pictureBox7.TabIndex = 19;
            this.pictureBox7.TabStop = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(35, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Временное";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonTemporalAA
            // 
            this.buttonTemporalAA.BackColor = System.Drawing.Color.Transparent;
            this.buttonTemporalAA.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonToggleDisable;
            this.buttonTemporalAA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTemporalAA.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonTemporalAA.FlatAppearance.BorderSize = 0;
            this.buttonTemporalAA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonTemporalAA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonTemporalAA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTemporalAA.Location = new System.Drawing.Point(161, 51);
            this.buttonTemporalAA.Name = "buttonTemporalAA";
            this.buttonTemporalAA.Size = new System.Drawing.Size(50, 22);
            this.buttonTemporalAA.TabIndex = 0;
            this.buttonTemporalAA.TabStop = false;
            this.buttonTemporalAA.UseVisualStyleBackColor = false;
            this.buttonTemporalAA.Click += new System.EventHandler(this.buttonTemporalAA_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(35, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Подпиксельное";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSubPixelAA
            // 
            this.buttonSubPixelAA.BackColor = System.Drawing.Color.Transparent;
            this.buttonSubPixelAA.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonToggleDisable;
            this.buttonSubPixelAA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSubPixelAA.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSubPixelAA.FlatAppearance.BorderSize = 0;
            this.buttonSubPixelAA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSubPixelAA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSubPixelAA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubPixelAA.Location = new System.Drawing.Point(161, 28);
            this.buttonSubPixelAA.Name = "buttonSubPixelAA";
            this.buttonSubPixelAA.Size = new System.Drawing.Size(50, 22);
            this.buttonSubPixelAA.TabIndex = 0;
            this.buttonSubPixelAA.TabStop = false;
            this.buttonSubPixelAA.UseVisualStyleBackColor = false;
            this.buttonSubPixelAA.Click += new System.EventHandler(this.buttonSubPixelAA_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(1, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Фильтрация";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonAF
            // 
            this.buttonAF.BackColor = System.Drawing.Color.Transparent;
            this.buttonAF.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonToggleDisable;
            this.buttonAF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAF.FlatAppearance.BorderSize = 0;
            this.buttonAF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAF.Location = new System.Drawing.Point(161, 77);
            this.buttonAF.Name = "buttonAF";
            this.buttonAF.Size = new System.Drawing.Size(50, 22);
            this.buttonAF.TabIndex = 0;
            this.buttonAF.TabStop = false;
            this.buttonAF.UseVisualStyleBackColor = false;
            this.buttonAF.Click += new System.EventHandler(this.buttonAF_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0",
            "2",
            "4",
            "8",
            "16"});
            this.comboBox2.Location = new System.Drawing.Point(97, 78);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(47, 21);
            this.comboBox2.TabIndex = 35;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // FormENBMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SLMPLauncher.Properties.Resources.FormBackgroundNone;
            this.ClientSize = new System.Drawing.Size(478, 325);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonFPS);
            this.Controls.Add(this.buttonAF);
            this.Controls.Add(this.buttonWaitBuffer);
            this.Controls.Add(this.buttonAmbientOcclusion);
            this.Controls.Add(this.buttonDriver);
            this.Controls.Add(this.buttonDOF);
            this.Controls.Add(this.buttonSubPixelAA);
            this.Controls.Add(this.buttonTemporalAA);
            this.Controls.Add(this.buttonAA);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.unpackENB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteAllENBsFiles);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormENBMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SLMP: ENB Menu";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button buttonAA;
        private System.Windows.Forms.Button buttonDOF;
        private System.Windows.Forms.Button buttonDriver;
        private System.Windows.Forms.Button buttonFPS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonAmbientOcclusion;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonWaitBuffer;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonTemporalAA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonSubPixelAA;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonAF;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}