using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormENBMenu : Form
    {
        public static string enbLocal = FormMain.gameFolder + "enblocal.ini";
        string enbSeries = FormMain.gameFolder + "enbseries.ini";
        string enbPath = FormMain.gameFolder + @"Skyrim\ENB\";
        string reservedMemory = "Резервирование памяти под эффекты ENB.";
        string driverDisable = "Отключить управление памятью драйвером и предоставить эти полномочия ENB.";
        string dinamicDOF = "Depth Of Field - динамическое размытие заднего фона, фокус.";
        string ambOcc = "Добавляет дополнительное затенение на объекты, снижает производительность.";
        string waitBuffer = "Ожидание завершения кадра видеоадаптером, помогает при мерцании изображения, снижает производительность.";
        string aaSUB = "Подпиксельное сглаживание зеркального отражения.";
        string aaTEMP = "Временное сглаживание обусловлено частотой дискретизации.";
        bool aa = false;
        bool aasub = false;
        bool aatemp = false;
        bool af = false;
        bool dof = false;
        bool driver = false;
        bool fps = false;
        bool ambocc = false;
        bool waitbuffer = false;

        public FormENBMenu()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(FormMain.launcherFolder);
            if (FormMain.numberStyle > 1)
            {
                imageBackgroundImage();
            }
            refreshFileList();
            refreshAllValue();
            FuncSettings.ENBCheck(false);
            toolTip1.SetToolTip(trackBar1, reservedMemory);
            toolTip1.SetToolTip(label2, reservedMemory);
            toolTip1.SetToolTip(label3, reservedMemory);
            toolTip1.SetToolTip(label8, dinamicDOF);
            toolTip1.SetToolTip(buttonDOF, dinamicDOF);
            toolTip1.SetToolTip(buttonDriver, driverDisable);
            toolTip1.SetToolTip(label9, driverDisable);
            toolTip1.SetToolTip(label11, ambOcc);
            toolTip1.SetToolTip(buttonAmbientOcclusion, ambOcc);
            toolTip1.SetToolTip(buttonWaitBuffer, waitBuffer);
            toolTip1.SetToolTip(label6, waitBuffer);
            toolTip1.SetToolTip(label12, aaSUB);
            toolTip1.SetToolTip(buttonSubPixelAA, aaSUB);
            toolTip1.SetToolTip(buttonTemporalAA, aaTEMP);
            toolTip1.SetToolTip(label7, aaTEMP);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.LabelsTextColor(this, System.Drawing.SystemColors.ControlLight, System.Drawing.Color.FromArgb(30, 30, 30));
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void refreshAllValue()
        {
            refreshTrackBar1();
            refreshAA();
            refresDOF();
            refresDriver();
            refreshFPS();
            refresAmbOcc();
            refresWaitBuffer();
            refreshAASUB();
            refreshAATEMP();
            refrashAF();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void refreshFileList()
        {
            if (Directory.Exists(enbPath))
            {
                foreach (string line in Directory.GetFiles(enbPath, "*.rar").Select(f => f.Substring((enbPath).Length)))
                {
                    listBox1.Items.Add(line);
                }
            }
        }
        private void unpackENB_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                FuncClear.ENB();
                enbUnpack(listBox1.GetItemText(listBox1.SelectedItem));
            }
            else
            {
                MessageBox.Show("Не выбран файл.");
            }
        }
        private void enbUnpack(string filename)
        {
            FuncMisc.ToggleButtons(this, false);
            listBox1.Enabled = false;
            trackBar1.Enabled = false;
            FuncMisc.UnPackRAR(enbPath + filename);
            FuncSettings.ENBCheck(true);
            FuncMisc.ToggleButtons(this, true);
            listBox1.Enabled = true;
            trackBar1.Enabled = true;
            refreshAllValue();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void deleteAllENBsFiles_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить все файлы ENB?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncClear.ENB();
                FuncSettings.ENBCheck(true);
                refreshAllValue();
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var trackValueExit = trackBar1.Value * 128;
            FuncParser.iniWrite(enbLocal, "MEMORY", "ReservedMemorySizeMb", trackValueExit.ToString());
            refreshTrackBar1();
        }
        private void refreshTrackBar1()
        {
            FuncMisc.RefreshTrackBar(trackBar1, enbLocal, "MEMORY", "ReservedMemorySizeMb", 128, label2);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonAA_Click(object sender, EventArgs e)
        {
            if (aa)
            {
                FuncParser.iniWrite(enbLocal, "ANTIALIASING", "EnableEdgeAA", "false");
                refreshAA();
            }
            else
            {
                FuncParser.iniWrite(enbLocal, "ANTIALIASING", "EnableEdgeAA", "true");
                refreshAA();
            }
        }
        private void refreshAA()
        {
            aa = FuncMisc.RefreshButton(buttonAA, enbLocal, "ANTIALIASING", "EnableEdgeAA", null, false);
        }
        private void buttonSubPixelAA_Click(object sender, EventArgs e)
        {
            if (aasub)
            {
                FuncParser.iniWrite(enbLocal, "ANTIALIASING", "EnableSubPixelAA", "false");
                refreshAASUB();
            }
            else
            {
                FuncParser.iniWrite(enbLocal, "ANTIALIASING", "EnableSubPixelAA", "true");
                refreshAASUB();
            }
        }
        private void refreshAASUB()
        {
            aasub = FuncMisc.RefreshButton(buttonSubPixelAA, enbLocal, "ANTIALIASING", "EnableSubPixelAA", null, false);
        }
        private void buttonTemporalAA_Click(object sender, EventArgs e)
        {
            if (aatemp)
            {
                FuncParser.iniWrite(enbLocal, "ANTIALIASING", "EnableTemporalAA", "false");
                refreshAATEMP();
            }
            else
            {
                FuncParser.iniWrite(enbLocal, "ANTIALIASING", "EnableTemporalAA", "true");
                refreshAATEMP();
            }
        }
        private void refreshAATEMP()
        {
            aatemp = FuncMisc.RefreshButton(buttonTemporalAA, enbLocal, "ANTIALIASING", "EnableTemporalAA", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonDOF_Click(object sender, EventArgs e)
        {
            if (dof)
            {
                FuncParser.iniWrite(enbSeries, "EFFECT", "EnableDepthOfField", "false");
                refresDOF();
            }
            else
            {
                FuncParser.iniWrite(enbSeries, "EFFECT", "EnableDepthOfField", "true");
                refresDOF();
            }
        }
        private void refresDOF()
        {
            dof = FuncMisc.RefreshButton(buttonDOF, enbSeries, "EFFECT", "EnableDepthOfField", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonDriver_Click(object sender, EventArgs e)
        {
            if (driver)
            {
                FuncParser.iniWrite(enbLocal, "MEMORY", "DisableDriverMemoryManager", "false");
                refresDriver();
            }
            else
            {
                FuncParser.iniWrite(enbLocal, "MEMORY", "DisableDriverMemoryManager", "true");
                refresDriver();
            }
        }
        private void refresDriver()
        {
            driver = FuncMisc.RefreshButton(buttonDriver, enbLocal, "MEMORY", "DisableDriverMemoryManager", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonAmbientOcclusion_Click(object sender, EventArgs e)
        {
            if (ambocc)
            {
                FuncParser.iniWrite(enbSeries, "EFFECT", "EnableAmbientOcclusion", "false");
                refresAmbOcc();
            }
            else
            {
                FuncParser.iniWrite(enbSeries, "EFFECT", "EnableAmbientOcclusion", "true");
                refresAmbOcc();
            }
        }
        private void refresAmbOcc()
        {
            ambocc = FuncMisc.RefreshButton(buttonAmbientOcclusion, enbSeries, "EFFECT", "EnableAmbientOcclusion", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonFPS_Click(object sender, EventArgs e)
        {
            if (fps)
            {
                FuncParser.iniWrite(enbLocal, "LIMITER", "EnableFPSLimit", "false");
                refreshFPS();
            }
            else
            {
                FuncParser.iniWrite(enbLocal, "LIMITER", "EnableFPSLimit", "true");
                refreshFPS();
            }
        }
        private void refreshFPS()
        {
            fps = FuncMisc.RefreshButton(buttonFPS, enbLocal, "LIMITER", "EnableFPSLimit", null, false);
            if (fps)
            {
                comboBox1.Enabled = true;
                string value = FuncParser.stringRead(enbLocal, "LIMITER", "FPSLimit");
                if (value == "30.0")
                {
                    comboBox1.SelectedIndex = 0;
                }
                else if (value == "60.0")
                {
                    comboBox1.SelectedIndex = 1;
                }
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.SelectedIndex = -1;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                FuncParser.iniWrite(enbLocal, "LIMITER", "FPSLimit", "30.0");
                refreshFPS();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                FuncParser.iniWrite(enbLocal, "LIMITER", "FPSLimit", "60.0");
                refreshFPS();
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonWaitBuffer_Click(object sender, EventArgs e)
        {
            if (waitbuffer)
            {
                FuncParser.iniWrite(enbLocal, "LIMITER", "WaitBusyRenderer", "false");
                refresWaitBuffer();
            }
            else
            {
                FuncParser.iniWrite(enbLocal, "LIMITER", "WaitBusyRenderer", "true");
                refresWaitBuffer();
            }
        }
        private void refresWaitBuffer()
        {
            waitbuffer = FuncMisc.RefreshButton(buttonWaitBuffer, enbLocal, "LIMITER", "WaitBusyRenderer", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonAF_Click(object sender, EventArgs e)
        {
            if (af)
            {
                FuncParser.iniWrite(enbLocal, "ENGINE", "ForceAnisotropicFiltering", "false");
                refrashAF();
            }
            else
            {
                FuncParser.iniWrite(enbLocal, "ENGINE", "ForceAnisotropicFiltering", "true");
                refrashAF();
            }
        }
        private void refrashAF()
        {
            af = FuncMisc.RefreshButton(buttonAF, enbLocal, "ENGINE", "ForceAnisotropicFiltering", null, false);
            if (af)
            {
                comboBox2.Enabled = true;
                string value = FuncParser.stringRead(enbLocal, "ENGINE", "MaxAnisotropy");
                if (value == "0")
                {
                    comboBox2.SelectedIndex = 0;
                }
                else if (value == "2")
                {
                    comboBox2.SelectedIndex = 1;
                }
                else if (value == "4")
                {
                    comboBox2.SelectedIndex = 2;
                }
                else if (value == "8")
                {
                    comboBox2.SelectedIndex = 3;
                }
                else if (value == "16")
                {
                    comboBox2.SelectedIndex = 4;
                }
            }
            else
            {
                comboBox2.Enabled = false;
                comboBox2.SelectedIndex = -1;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                FuncParser.iniWrite(enbLocal, "ENGINE", "MaxAnisotropy", "0");
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                FuncParser.iniWrite(enbLocal, "ENGINE", "MaxAnisotropy", "2");
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                FuncParser.iniWrite(enbLocal, "ENGINE", "MaxAnisotropy", "4");
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                FuncParser.iniWrite(enbLocal, "ENGINE", "MaxAnisotropy", "8");
            }
            else if (comboBox2.SelectedIndex == 4)
            {
                FuncParser.iniWrite(enbLocal, "ENGINE", "MaxAnisotropy", "16");
            }
            refrashAF();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}