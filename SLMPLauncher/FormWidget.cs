﻿using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormWidget : Form
    {
        FormMain mainFormStyle = null;

        public FormWidget()
        {
            InitializeComponent();
            if (FormMain.numberStyle > 1)
            {
                ImageBackgroundImage();
            }
            if (FuncParser.stringRead(FormMain.iniLauncher, "General", "HideWebButtons") == "true")
            {
                ClientSize = new System.Drawing.Size(168, 60);
                label2.Size = new System.Drawing.Size(168, 60);
                buttonUpdates.Enabled = false;
                buttonUpdates.Visible = false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void ImageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            label1.ForeColor = System.Drawing.SystemColors.ControlLight;
        }
        private void ImageBackgroundImageNone()
        {
            BackgroundImage = Properties.Resources.FormBackgroundNone;
            label1.ForeColor = System.Drawing.SystemColors.ControlText;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonStyle1_Click(object sender, System.EventArgs e)
        {
            FormMain.numberStyle = 1;
            FuncStyle_1.style_1();
            mainFormStyle = Owner as FormMain;
            mainFormStyle.RefreshStyle();
            ImageBackgroundImageNone();
            this.Owner.Focus();
        }
        private void buttonStyle2_Click(object sender, System.EventArgs e)
        {
            FormMain.numberStyle = 2;
            FuncStyle_2.style_2();
            mainFormStyle = Owner as FormMain;
            mainFormStyle.RefreshStyle();
            ImageBackgroundImage();
            this.Owner.Focus();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void label2_Click(object sender, System.EventArgs e)
        {
            this.Owner.Focus();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonUpdates_Click(object sender, System.EventArgs e)
        {
            var form = new FormUpdates();
            form.ShowDialog(this.Owner);
            form = null;
            this.Owner.Focus();
        }
    }
}