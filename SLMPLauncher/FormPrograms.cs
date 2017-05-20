using System;
using System.IO;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormPrograms : Form
    {
        string programsPath = FormMain.gameFolder + @"_Programs\ProgramFiles\";

        public FormPrograms()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(FormMain.launcherFolder);
            if (FormMain.numberStyle > 1)
            {
                imageBackgroundImage();
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            label1.ForeColor = System.Drawing.SystemColors.ControlLight;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonUnpackCreationKit_Click(object sender, EventArgs e)
        {
            programsUnpack("CREATIONKIT.rar");
        }
        private void buttonUnpackTESVEdit_Click(object sender, EventArgs e)
        {
            programsUnpack("TES5EDIT.rar");
        }
        private void buttonUnpackLodGEN_Click(object sender, EventArgs e)
        {
            programsUnpack("TES5LODGEN.rar");
        }
        private void programsUnpack(string FileName)
        {
            FuncMisc.ToggleButtons(this, false);
            FuncMisc.UnPackRAR(programsPath + FileName);
            FuncMisc.ToggleButtons(this, true);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}