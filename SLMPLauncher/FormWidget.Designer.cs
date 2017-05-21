namespace SLMPLauncher
{
    partial class FormWidget
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any Resource being used.
        /// </summary>
        /// <param name="disposing">true if managed Resource should be disposed; otherwise, false.</param>
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
            this.buttonStyle1 = new System.Windows.Forms.Button();
            this.buttonStyle2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonUpdates = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStyle1
            // 
            this.buttonStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStyle1.Location = new System.Drawing.Point(51, 25);
            this.buttonStyle1.Name = "buttonStyle1";
            this.buttonStyle1.Size = new System.Drawing.Size(30, 30);
            this.buttonStyle1.TabIndex = 0;
            this.buttonStyle1.TabStop = false;
            this.buttonStyle1.Text = "1";
            this.buttonStyle1.UseCompatibleTextRendering = true;
            this.buttonStyle1.UseVisualStyleBackColor = true;
            this.buttonStyle1.Click += new System.EventHandler(this.buttonStyle1_Click);
            // 
            // buttonStyle2
            // 
            this.buttonStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStyle2.Location = new System.Drawing.Point(87, 25);
            this.buttonStyle2.Name = "buttonStyle2";
            this.buttonStyle2.Size = new System.Drawing.Size(30, 30);
            this.buttonStyle2.TabIndex = 0;
            this.buttonStyle2.TabStop = false;
            this.buttonStyle2.Text = "2";
            this.buttonStyle2.UseCompatibleTextRendering = true;
            this.buttonStyle2.UseVisualStyleBackColor = true;
            this.buttonStyle2.Click += new System.EventHandler(this.buttonStyle2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Стили оформления";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 60);
            this.label2.TabIndex = 0;
            // 
            // buttonUpdates
            // 
            this.buttonUpdates.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUpdates.Location = new System.Drawing.Point(176, 12);
            this.buttonUpdates.Name = "buttonUpdates";
            this.buttonUpdates.Size = new System.Drawing.Size(105, 36);
            this.buttonUpdates.TabIndex = 1;
            this.buttonUpdates.TabStop = false;
            this.buttonUpdates.Text = "Обновления";
            this.buttonUpdates.UseVisualStyleBackColor = true;
            this.buttonUpdates.Click += new System.EventHandler(this.buttonUpdates_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SLMPLauncher.Properties.Resources.line;
            this.pictureBox1.Location = new System.Drawing.Point(167, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 62);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // FormWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::SLMPLauncher.Properties.Resources.FormBackgroundNone;
            this.ClientSize = new System.Drawing.Size(289, 60);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonUpdates);
            this.Controls.Add(this.buttonStyle2);
            this.Controls.Add(this.buttonStyle1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWidget";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SLMP: Settings Widget";
            this.Activated += new System.EventHandler(this.FormWidget_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStyle1;
        private System.Windows.Forms.Button buttonStyle2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonUpdates;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}