using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormMods : Form
    {
        public static string CPFilesPath = FormMain.gameFolder + @"Skyrim\CPFiles\";

        public FormMods()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(FormMain.launcherFolder);
            if (FormMain.numberStyle > 1)
            {
                imageBackgroundImage();
            }
            RefreshFileList();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.LabelsTextColor(this, System.Drawing.SystemColors.ControlLight, System.Drawing.Color.FromArgb(30, 30, 30));
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void RefreshFileList()
        {
            if (Directory.Exists(CPFilesPath))
            {
                foreach (string line in Directory.GetFiles(CPFilesPath, "*.rar").Select(f => f.Substring((CPFilesPath).Length)))
                {
                    listBox1.Items.Add(line);
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_ModInstall_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                fileUnpack(listBox1.GetItemText(listBox1.SelectedItem));
            }
            else
            {
                MessageBox.Show("Не выбран файл.");
            }
        }
        private void fileUnpack(string filename)
        {
            FuncMisc.ToggleButtons(this, false);
            listBox1.Enabled = false;
            FuncMisc.UnPackRAR(CPFilesPath + filename);
            FuncMisc.ToggleButtons(this, true);
            listBox1.Enabled = true;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonDeleteOSA_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить OSA (OSEX)?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncClear.OSA();
            }
        }
        private void buttonDeleteAS_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить Alternate Start?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncClear.AS();
            }
        }
        private void buttonDeleteFFC_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить Frostfall (Campfire)?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncClear.FFC();
            }
        }
        private void buttonDeleteINEED_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить iNeeD?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncClear.INEED();
            }
        }
        private void buttonDeleteLAD_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить LootAndDegradation?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncClear.LAD();
            }
        }
        private void buttonDeleteORD_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить Ordinator?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncClear.ORD();
            }
        }
        private void buttonDeleteTunic_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить Tunic?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncClear.TUNIC();
            }
        }
        private void buttonEarsTails_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить EarsTails?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncClear.ET();
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}