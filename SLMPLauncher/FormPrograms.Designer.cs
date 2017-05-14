namespace SLMPLauncher
{
	partial class FormPrograms
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button buttonUnpackCreationKit;
        private System.Windows.Forms.Button buttonUnpackTESVEdit;
		private System.Windows.Forms.Button buttonUnpackLodGEN;
		
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
            this.buttonUnpackCreationKit = new System.Windows.Forms.Button();
            this.buttonUnpackTESVEdit = new System.Windows.Forms.Button();
            this.buttonUnpackLodGEN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonUnpackCreationKit
            // 
            this.buttonUnpackCreationKit.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUnpackCreationKit.Location = new System.Drawing.Point(80, 65);
            this.buttonUnpackCreationKit.Name = "buttonUnpackCreationKit";
            this.buttonUnpackCreationKit.Size = new System.Drawing.Size(130, 30);
            this.buttonUnpackCreationKit.TabIndex = 0;
            this.buttonUnpackCreationKit.TabStop = false;
            this.buttonUnpackCreationKit.Text = "Creation Kit";
            this.buttonUnpackCreationKit.UseVisualStyleBackColor = true;
            this.buttonUnpackCreationKit.Click += new System.EventHandler(this.buttonUnpackCreationKit_Click);
            // 
            // buttonUnpackTESVEdit
            // 
            this.buttonUnpackTESVEdit.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUnpackTESVEdit.Location = new System.Drawing.Point(12, 101);
            this.buttonUnpackTESVEdit.Name = "buttonUnpackTESVEdit";
            this.buttonUnpackTESVEdit.Size = new System.Drawing.Size(130, 30);
            this.buttonUnpackTESVEdit.TabIndex = 0;
            this.buttonUnpackTESVEdit.TabStop = false;
            this.buttonUnpackTESVEdit.Text = "TESVEdit";
            this.buttonUnpackTESVEdit.UseVisualStyleBackColor = true;
            this.buttonUnpackTESVEdit.Click += new System.EventHandler(this.buttonUnpackTESVEdit_Click);
            // 
            // buttonUnpackLodGEN
            // 
            this.buttonUnpackLodGEN.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUnpackLodGEN.Location = new System.Drawing.Point(148, 101);
            this.buttonUnpackLodGEN.Name = "buttonUnpackLodGEN";
            this.buttonUnpackLodGEN.Size = new System.Drawing.Size(130, 30);
            this.buttonUnpackLodGEN.TabIndex = 0;
            this.buttonUnpackLodGEN.TabStop = false;
            this.buttonUnpackLodGEN.Text = "TESVLodGen";
            this.buttonUnpackLodGEN.UseVisualStyleBackColor = true;
            this.buttonUnpackLodGEN.Click += new System.EventHandler(this.buttonUnpackLodGEN_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Распаковка в корень игры\r\nпрограмм для редактирования игры:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonClose;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Location = new System.Drawing.Point(262, 8);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(20, 20);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.TabStop = false;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 143);
            this.label2.TabIndex = 0;
            // 
            // FormPrograms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SLMPLauncher.Properties.Resources.FormBackgroundNone;
            this.ClientSize = new System.Drawing.Size(290, 143);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUnpackLodGEN);
            this.Controls.Add(this.buttonUnpackTESVEdit);
            this.Controls.Add(this.buttonUnpackCreationKit);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrograms";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SLMP: Programs Install";
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label2;
	}
}
