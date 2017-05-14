using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormOptions : Form
    {
        string pathToPlugins = FormMain.appDataPath + @"plugins.txt";
        string dataFolder = FormMain.gameFolder + @"Data\";
        string ruLocation = FormMain.launcherFolder + @"LangVoice\RU\";
        string enLocation = FormMain.launcherFolder + @"LangVoice\EN\";
        string filesType = @"*.bsa";
        string currentSelectName = null;
        string indexAdapter = "Изменение индекса видеоадаптера, если нужно запустить на другой видеокарте.";
        string shadowResolution = "Изменение самого \"тяжелого\" параметра теней.";
        string grassDensity = "Расстояние между кустами травы, чем оно меньше, тем плотнее трава.";
        string weaponFavorite = "Отображение на персонаже оружия находящегося в категории избранного.";
        List<int> screenListW = new List<int>();
        List<int> screenListH = new List<int>();
        List<string> filesDataES = new List<string>();
        List<string> pluginsList = new List<string>();
        List<string> currentFileList = new List<string>();
        List<string> newFileList = new List<string>();
        int currentSelectIndex = -1;
        int lastESMIndex = 0;
        bool fail = false;
        bool blockCheck = false;
        bool startMoveItem = false;
        bool moveChecked = false;
        bool hideobjects = false;
        bool fxaa = false;
        bool vsync = false;
        bool window = false;
        bool weapons = false;
        bool papyrus = false;

        public FormOptions()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(FormMain.launcherFolder);
            if (FormMain.numberStyle > 1)
            {
                imageBackgroundImage();
            }
            toolTip1.SetToolTip(label14, indexAdapter);
            toolTip1.SetToolTip(comboBoxAdapterIndex, indexAdapter);
            toolTip1.SetToolTip(label20, shadowResolution);
            toolTip1.SetToolTip(comboBoxShadowMap, shadowResolution);
            toolTip1.SetToolTip(label21, grassDensity);
            toolTip1.SetToolTip(label22, grassDensity);
            toolTip1.SetToolTip(trackBarGrass, grassDensity);
            toolTip1.SetToolTip(label2, weaponFavorite);
            toolTip1.SetToolTip(buttonToggleWeapons, weaponFavorite);
            toolTip1.SetToolTip(buttonRedateMods, "Массовое изменение даты изменения файлов по возрастанию.");
            refrashSettings();
            refreshModsList();
            currentFileList.AddRange(Directory.GetFiles(dataFolder).Select(f => f.Substring((dataFolder).Length)));
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.LabelsTextColor(this, System.Drawing.SystemColors.ControlLight, System.Drawing.Color.FromArgb(30, 30, 30));
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void refrashSettings()
        {
            refreshbuttonToggleWeapons();
            refreshValueLabelPapyrus();
            refreshWindow();
            refreshAfapterIndex();
            refrashVsync();
            refrashAA();
            refrashAF();
            refrashFXAA();
            refrashGrass();
            refrashShadow();
            refrashWater();
            refrashDecals();
            refrashLights();
            refrashActors();
            refrashItems();
            refrashObjects();
            refrashTextures();
            refreshLangButton();
            refrashLODObjects();
            refreshHideObjects();
            refrashShadowRange();
            refrashGrassDistance();
            refreshScreenResolution(FuncParser.intRead(FormMain.iniSkyrimPrefs, "Display", "iSize W"), FuncParser.intRead(FormMain.iniSkyrimPrefs, "Display", "iSize H"), false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonToggleWeapons_Click(object sender, EventArgs e)
        {
            if (weapons)
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "General", "bDisableGearedUp", "1");
                refreshbuttonToggleWeapons();
            }
            else
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "General", "bDisableGearedUp", "0");
                refreshbuttonToggleWeapons();
            }
        }
        private void refreshbuttonToggleWeapons()
        {
            weapons = FuncMisc.RefreshButton(buttonToggleWeapons, FormMain.iniSkyrim, "General", "bDisableGearedUp", null, true);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonPapyrus_Click(object sender, EventArgs e)
        {
            if (papyrus)
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "Papyrus", "bEnableLogging", "0");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Papyrus", "bEnableTrace", "0");
                refreshValueLabelPapyrus();
            }
            else
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "Papyrus", "bEnableLogging", "1");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Papyrus", "bEnableTrace", "1");
                refreshValueLabelPapyrus();
            }
        }
        private void refreshValueLabelPapyrus()
        {
            papyrus = FuncMisc.RefreshButton(buttonPapyrus, FormMain.iniSkyrim, "Papyrus", "bEnableLogging", null, false);
            if (papyrus)
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "Papyrus", "bEnableTrace", "1");
            }
            else
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "Papyrus", "bEnableTrace", "0");
            }
        }
        private void buttonLogsFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(FormMain.myDocPath + @"Logs\"))
            {
                Process.Start(FormMain.myDocPath + @"Logs\");
            }
            else if (Directory.Exists(FormMain.myDocPath))
            {
                Process.Start(FormMain.myDocPath);
            }
            else if (Directory.Exists(FormMain.myDocPath + @"..\"))
            {
                Process.Start(FormMain.myDocPath + @"..\");
            }
            else if (Directory.Exists(FormMain.myDocPath + @"..\..\"))
            {
                Process.Start(FormMain.myDocPath + @"..\..\");
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!blockCheck)
            {
                e.NewValue = e.CurrentValue;
            }
        }
        //////////////////////////////////////////////////////
        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex != -1)
            {
                listBox1.DataSource = FuncParser.parserESPESM(dataFolder + checkedListBox1.SelectedItem.ToString());
            }
        }
        private void checkedListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkedListBox1.SelectedIndex != -1)
            {
                startMoveItem = true;
                moveChecked = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                currentSelectIndex = checkedListBox1.SelectedIndex;
                currentSelectName = checkedListBox1.SelectedItem.ToString();
            }
        }
        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            startMoveItem = false;
            moveChecked = false;
            currentSelectIndex = -1;
            currentSelectName = null;
            writeMasterFile();
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!blockCheck && startMoveItem)
            {
                if (currentSelectIndex != checkedListBox1.SelectedIndex && checkedListBox1.SelectedIndex != -1 && currentSelectIndex != -1)
                {
                    blockCheck = true;
                    checkedListBox1.Items.RemoveAt(currentSelectIndex);
                    if (checkedListBox1.SelectedIndex < currentSelectIndex)
                    {
                        inserItem(-1, 0);
                    }
                    else
                    {
                        inserItem(1, 1);
                    }
                    blockCheck = false;
                }
            }
            listBox1.DataSource = FuncParser.parserESPESM(dataFolder + checkedListBox1.SelectedItem.ToString());
        }
        private void inserItem(int index1, int index2)
        {
            checkedListBox1.Items.Insert(checkedListBox1.SelectedIndex + index2, currentSelectName);
            if (moveChecked)
            {
                checkedListBox1.SetItemCheckState(checkedListBox1.SelectedIndex + index1, CheckState.Checked);
            }
            else
            {
                checkedListBox1.SetItemCheckState(checkedListBox1.SelectedIndex + index1, CheckState.Unchecked);
            }
            checkedListBox1.SelectedIndex = checkedListBox1.SelectedIndex + index1;
        }
        //////////////////////////////////////////////////////
        private void checkedListBox1_DoubleClick(object sender, EventArgs e)
        {
            blockCheck = true;
            if (checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex))
            {
                checkedListBox1.SetItemCheckState(checkedListBox1.SelectedIndex, CheckState.Unchecked);
                uncheckItem(checkedListBox1.SelectedIndex);
                writeMasterFile();
            }
            else
            {
                checkItem(checkedListBox1.SelectedIndex, true);
                writeMasterFile();
            }
            labelsRefresh();
            blockCheck = false;
        }
        private void checkItem(int index, bool check)
        {
            foreach (string line in FuncParser.parserESPESM(dataFolder + checkedListBox1.Items[index].ToString()))
            {
                if (line != "Skyrim.esm")
                {
                    if (checkedListBox1.Items.OfType<String>().ToList().Contains(line))
                    {
                        checkItem(checkedListBox1.Items.IndexOf(line), check);
                        if (!fail)
                        {
                            if (check)
                            {
                                checkedListBox1.SetItemCheckState(checkedListBox1.Items.IndexOf(line), CheckState.Checked);
                            }
                        }
                        else
                        {
                            checkedListBox1.SetItemCheckState(checkedListBox1.Items.IndexOf(line), CheckState.Unchecked);
                        }
                    }
                    else
                    {
                        fail = true;
                        break;
                    }
                }
            }
            if (!fail)
            {
                if (check)
                {
                    checkedListBox1.SetItemCheckState(index, CheckState.Checked);
                }
            }
            else
            {
                checkedListBox1.SetItemCheckState(index, CheckState.Unchecked);
            }
            fail = false;
        }
        private void uncheckItem(int index)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                foreach (string line in FuncParser.parserESPESM(dataFolder + checkedListBox1.Items[i].ToString()))
                {
                    if (line == checkedListBox1.Items[index].ToString())
                    {
                        checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                        uncheckItem(i);
                    }
                }
            }
        }
        //////////////////////////////////////////////////////
        private void refreshModsList()
        {
            blockCheck = true;
            checkedListBox1.Enabled = false;
            checkedListBox1.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(checkedListBox1_ItemCheck);
            checkedListBox1.Click -= new System.EventHandler(checkedListBox1_Click);
            checkedListBox1.SelectedIndexChanged -= new System.EventHandler(checkedListBox1_SelectedIndexChanged);
            checkedListBox1.DoubleClick -= new System.EventHandler(this.checkedListBox1_DoubleClick);
            checkedListBox1.MouseDown -= new System.Windows.Forms.MouseEventHandler(checkedListBox1_MouseDown);
            checkedListBox1.MouseUp -= new System.Windows.Forms.MouseEventHandler(checkedListBox1_MouseUp);
            checkedListBox1.Items.Clear();
            filesDataES.Clear();
            pluginsList.Clear();
            filesDataES.AddRange(Directory.GetFiles(dataFolder, "*.esm").Select(f => f.Substring((dataFolder).Length)));
            filesDataES.Remove("Skyrim.esm");
            filesDataES.AddRange(Directory.GetFiles(dataFolder, "*.esp").Select(f => f.Substring((dataFolder).Length)));
            pluginsList = File.ReadAllLines(pathToPlugins).ToList();
            lastESMIndex = 0;
            foreach (string line in pluginsList)
            {
                if (filesDataES.Contains(line) && !checkedListBox1.Items.OfType<String>().ToList().Contains(line))
                {
                    addItem(true, line);
                }
            }
            foreach (string line in filesDataES)
            {
                if (!pluginsList.Contains(line))
                {
                    addItem(false, line);
                }
            }
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkItem(i, false);
            }
            writeMasterFile();
            labelsRefresh();
            checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(checkedListBox1_ItemCheck);
            checkedListBox1.Click += new System.EventHandler(checkedListBox1_Click);
            checkedListBox1.SelectedIndexChanged += new System.EventHandler(checkedListBox1_SelectedIndexChanged);
            checkedListBox1.DoubleClick += new System.EventHandler(this.checkedListBox1_DoubleClick);
            checkedListBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(checkedListBox1_MouseDown);
            checkedListBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(checkedListBox1_MouseUp);
            checkedListBox1.Enabled = true;
            blockCheck = false;
        }
        private void addItem(bool check, string name)
        {
            if (name.Contains(".esm") || FuncParser.checkESM(dataFolder + name))
            {
                checkedListBox1.Items.Insert(lastESMIndex, name);
                if (check)
                {
                    checkedListBox1.SetItemCheckState(lastESMIndex, CheckState.Checked);
                }
                else
                {
                    checkedListBox1.SetItemCheckState(lastESMIndex, CheckState.Unchecked);
                }
                lastESMIndex = lastESMIndex + 1;
            }
            else if (check)
            {
                checkedListBox1.Items.Add(name, CheckState.Checked);
            }
            else
            {
                checkedListBox1.Items.Add(name, CheckState.Unchecked);
            }
        }
        //////////////////////////////////////////////////////
        private void buttonActivatedAll_Click(object sender, EventArgs e)
        {
            blockCheck = true;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkItem(i, true);
            }
            blockCheck = false;
            writeMasterFile();
            labelsRefresh();
        }
        private void buttonRestore_Click(object sender, EventArgs e)
        {
            FuncFiles.Delete(FormMain.appDataPath + @"DLCList.txt");
            FuncFiles.Delete(FormMain.appDataPath + @"plugins.txt");
            FuncFiles.CopyAnyFiles(FormMain.launcherFolder + @"MasterList\DLCList.txt", FormMain.appDataPath + @"DLCList.txt");
            FuncFiles.CopyAnyFiles(FormMain.launcherFolder + @"MasterList\plugins.txt", FormMain.appDataPath + @"plugins.txt");
            refreshModsList();
        }
        //////////////////////////////////////////////////////
        private void writeMasterFile()
        {
            try
            {
                FuncFiles.Delete(FormMain.appDataPath + @"loadorder.txt");
                File.WriteAllLines(pathToPlugins, checkedListBox1.CheckedItems.OfType<String>().ToList());
            }
            catch
            {
                MessageBox.Show("Не удалось записать файл: " + pathToPlugins);
            }
        }
        private void labelsRefresh()
        {
            label9.Text = checkedListBox1.CheckedItems.Count.ToString();
            label11.Text = checkedListBox1.Items.Count.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            newFileList.Clear();
            newFileList.AddRange(Directory.GetFiles(dataFolder).Select(f => f.Substring((dataFolder).Length)));
            if (!FuncParser.listsCompare(newFileList, currentFileList))
            {
                refreshModsList();
                currentFileList.Clear();
                currentFileList.AddRange(newFileList);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonRedateMods_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count > 0)
            {
                string nameStartFile = null;
                DateTime dt = new DateTime(2017, 1, 12, 12, 0, 0, DateTimeKind.Local);
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    nameStartFile = checkedListBox1.Items[i].ToString();
                    if (nameStartFile != "Update.esm" && nameStartFile != "Dawnguard.esm" && nameStartFile != "HearthFires.esm" && nameStartFile != "Dragonborn.esm")
                    {
                        try
                        {
                            File.SetLastWriteTime(dataFolder + checkedListBox1.Items[i].ToString(), dt);
                        }
                        catch
                        {
                            MessageBox.Show("не удалось изменить дату изменения файла: " + dataFolder + checkedListBox1.Items[i].ToString());
                        }
                        dt = dt.AddMinutes(1);
                    }
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public void resetSettings()
        {
            double rambyte = 0;
            try
            {
                rambyte = (new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory) / 1024 / 1024;
            }
            catch
            {
                MessageBox.Show("Программе не удалось получить сведения о системе.");
            }
            if (rambyte > 8000)
            {
                FuncSettings.HightPreset();
                MessageBox.Show("Установлены Высокие настройки.");
            }
            else if (rambyte > 4000)
            {
                FuncSettings.MediumPreset();
                MessageBox.Show("Установлены Средние настройки.");
            }
            else
            {
                FuncSettings.LowPreset();
                MessageBox.Show("Установлены Низкие настройки.");
            }
            refreshScreenResolution(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, true);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxAspect_SelectedIndexChanged(object sender, EventArgs e)
        {
            screenListW.Clear();
            screenListH.Clear();
            comboBoxResolution.Items.Clear();
            if (comboBoxAspect.SelectedIndex == 0)
            {
                comboBoxResolution.Items.AddRange(new string[] { "2560 × 1080", "3440 × 1440", "5120 × 2160" });
                screenListW.AddRange(new int[] { 2560, 3440, 5120 });
                screenListH.AddRange(new int[] { 1080, 1440, 2160 });
            }
            else if (comboBoxAspect.SelectedIndex == 1)
            {
                comboBoxResolution.Items.AddRange(new string[] { "1280 × 800", "1440 × 900", "1680 × 1050", "1920 × 1200", "2560 × 1600 UltraHD", "3840 × 2400 UltraHD", });
                screenListW.AddRange(new int[] { 1280, 1440, 1680, 1920, 2560, 3840, });
                screenListH.AddRange(new int[] { 800, 900, 1050, 1200, 1600, 2400, });
            }
            else if (comboBoxAspect.SelectedIndex == 2)
            {
                comboBoxResolution.Items.AddRange(new string[] { "1280 × 720", "1366 × 768", "1600 × 900", "1920 × 1080", "2048 × 1152 UltraHD", "2560 × 1440 UltraHD", "3200 × 1800 UltraHD", "3840 × 2160 UltraHD", "4096 × 2304 UltraHD", "5120 × 2880 UltraHD", "7680 × 4320 UltraHD", });
                screenListW.AddRange(new int[] { 1280, 1366, 1600, 1920, 2048, 2560, 3200, 3840, 4096, 5120, 7680, });
                screenListH.AddRange(new int[] { 720, 768, 900, 1080, 1152, 1440, 1800, 2160, 2304, 2880, 4320, });
            }
            else if (comboBoxAspect.SelectedIndex == 3)
            {
                comboBoxResolution.Items.AddRange(new string[] { "600 × 480", "1280 × 1024", "1600 × 1280" });
                screenListW.AddRange(new int[] { 600, 1280, 1600 });
                screenListH.AddRange(new int[] { 480, 1024, 1280 });
            }
            else if (comboBoxAspect.SelectedIndex == 4)
            {
                comboBoxResolution.Items.AddRange(new string[] { "800 × 600", "1024 × 768", "1280 × 960", "1440 × 1080" });
                screenListW.AddRange(new int[] { 800, 1024, 1280, 1440 });
                screenListH.AddRange(new int[] { 600, 768, 960, 1080 });
            }
        }
        private void refreshScreenResolution(float x, float y, bool set)
        {
            float aspectRatio = x / y;
            if (aspectRatio < 2.4 && aspectRatio > 2.3)
            {
                comboBoxAspect.SelectedIndex = 0;
            }
            else if (aspectRatio < 1.8 && aspectRatio > 1.7)
            {
                comboBoxAspect.SelectedIndex = 2;
            }
            else if (aspectRatio == 1.6)
            {
                comboBoxAspect.SelectedIndex = 1;
            }
            else if (aspectRatio == 1.25)
            {
                comboBoxAspect.SelectedIndex = 3;
            }
            else if (aspectRatio < 1.4 && aspectRatio > 1.3)
            {
                comboBoxAspect.SelectedIndex = 4;
            }
            for (int i = 0; i < screenListW.Count; i++)
            {
                if (screenListW[i] == x && screenListH[i] == y)
                {
                    comboBoxResolution.SelectedIndex = i;
                }
            }
        }
        private void comboBoxResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iSize W", screenListW[comboBoxResolution.SelectedIndex].ToString());
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iSize H", screenListH[comboBoxResolution.SelectedIndex].ToString());
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxAdapterIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Изменить индекс видеоадаптера? Игра не запуститься если его там не окажется.", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "Display", "iAdapter", comboBoxAdapterIndex.SelectedIndex.ToString());
                FuncParser.iniWrite(FormENBMenu.enbLocal, "MULTIHEAD", "VideoAdapterIndex", comboBoxAdapterIndex.SelectedIndex.ToString());
                if (comboBoxAdapterIndex.SelectedIndex >= 1 && comboBoxAdapterIndex.SelectedIndex <= 5)
                {
                    FuncParser.iniWrite(FormENBMenu.enbLocal, "MULTIHEAD", "ForceVideoAdapterIndex", "true");
                }
                else
                {
                    FuncParser.iniWrite(FormENBMenu.enbLocal, "MULTIHEAD", "ForceVideoAdapterIndex", "false");
                }
            }
            else
            {
                refreshAfapterIndex();
            }
        }
        private void refreshAfapterIndex()
        {
            comboBoxAdapterIndex.SelectedIndexChanged -= comboBoxAdapterIndex_SelectedIndexChanged;
            int value = FuncParser.intRead(FormMain.iniSkyrim, "Display", "iAdapter");
            if (value >= 0 && value <= 5)
            {
                comboBoxAdapterIndex.SelectedIndex = value;
                if (value >= 1 && value <= 5)
                {
                    FuncParser.iniWrite(FormENBMenu.enbLocal, "MULTIHEAD", "ForceVideoAdapterIndex", "true");
                }
                else
                {
                    FuncParser.iniWrite(FormENBMenu.enbLocal, "MULTIHEAD", "ForceVideoAdapterIndex", "false");
                }
            }
            else
            {
                comboBoxAdapterIndex.SelectedIndex = 0;
                FuncParser.iniWrite(FormMain.iniSkyrim, "Display", "iAdapter", "0");
                FuncParser.iniWrite(FormENBMenu.enbLocal, "MULTIHEAD", "VideoAdapterIndex", "0");
                FuncParser.iniWrite(FormENBMenu.enbLocal, "MULTIHEAD", "ForceVideoAdapterIndex", "false");
            }
            comboBoxAdapterIndex.SelectedIndexChanged += comboBoxAdapterIndex_SelectedIndexChanged;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonLow_Click(object sender, EventArgs e)
        {
            FuncSettings.LowPreset();
            refrashSettings();
        }
        private void buttonMedium_Click(object sender, EventArgs e)
        {
            FuncSettings.MediumPreset();
            refrashSettings();
        }
        private void buttonHight_Click(object sender, EventArgs e)
        {
            FuncSettings.HightPreset();
            refrashSettings();
        }
        private void buttonUltra_Click(object sender, EventArgs e)
        {
            FuncSettings.UltraPreset();
            refrashSettings();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonWindow_Click(object sender, EventArgs e)
        {
            if (window)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFull Screen", "1");
                refreshWindow();
            }
            else
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFull Screen", "0");
                refreshWindow();
            }
        }
        private void refreshWindow()
        {
            window = FuncMisc.RefreshButton(buttonWindow, FormMain.iniSkyrimPrefs, "Display", "bFull Screen", null, true);
            if (window)
            {
                FuncParser.iniWrite(FormENBMenu.enbLocal, "WINDOW", "ForceBorderless", "true");
            }
            else
            {
                FuncParser.iniWrite(FormENBMenu.enbLocal, "WINDOW", "ForceBorderless", "false");
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonVsync_Click(object sender, EventArgs e)
        {
            if (vsync)
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "Display", "iPresentInterval", "0");
                refrashVsync();
            }
            else
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "Display", "iPresentInterval", "1");
                refrashVsync();
            }
        }
        private void refrashVsync()
        {
            vsync = FuncMisc.RefreshButton(buttonVsync, FormMain.iniSkyrim, "Display", "iPresentInterval", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonAdvancedSettings_Click(object sender, EventArgs e)
        {
            buttonDistance.Enabled = true;
            buttonAdvancedSettings.Enabled = false;
            label17.Visible = true;
            comboBoxAA.Visible = true;
            label18.Visible = true;
            comboBoxAF.Visible = true;
            label19.Visible = true;
            buttonFXAA.Visible = true;
            label15.Visible = true;
            buttonWindow.Visible = true;
            label16.Visible = true;
            buttonVsync.Visible = true;
            label20.Visible = true;
            comboBoxShadowMap.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
            trackBarGrass.Visible = true;
            label23.Visible = true;
            comboBoxWaterReflect.Visible = true;
            label6.Visible = true;
            comboBoxAspect.Visible = true;
            comboBoxResolution.Visible = true;
            label14.Visible = true;
            label24.Visible = true;
            comboBoxTextures.Visible = true;
            label25.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
            trackBarGrass.Visible = true;
            label26.Visible = true;
            comboBoxDecals.Visible = true;
            comboBoxShadowRange.Visible = true;
            comboBoxAdapterIndex.Visible = true;
            label3.Visible = false;
            label1.Visible = false;
            trackBarGrassDistance.Visible = false;
            label4.Visible = false;
            label27.Visible = false;
            trackBarObjects.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            trackBarItems.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            trackBarActors.Visible = false;
            label32.Visible = false;
            label33.Visible = false;
            trackBarLights.Visible = false;
            label34.Visible = false;
            comboBoxLODObjects.Visible = false;
            label35.Visible = false;
            buttonHideObjects.Visible = false;
        }
        private void buttonDistance_Click(object sender, EventArgs e)
        {
            buttonDistance.Enabled = false;
            buttonAdvancedSettings.Enabled = true;
            label17.Visible = false;
            comboBoxAA.Visible = false;
            label18.Visible = false;
            comboBoxAF.Visible = false;
            label19.Visible = false;
            buttonFXAA.Visible = false;
            label15.Visible = false;
            buttonWindow.Visible = false;
            label16.Visible = false;
            buttonVsync.Visible = false;
            label20.Visible = false;
            comboBoxShadowMap.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            trackBarGrass.Visible = false;
            label23.Visible = false;
            comboBoxWaterReflect.Visible = false;
            label6.Visible = false;
            comboBoxAspect.Visible = false;
            comboBoxResolution.Visible = false;
            label14.Visible = false;
            label24.Visible = false;
            comboBoxTextures.Visible = false;
            label25.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            trackBarGrass.Visible = false;
            label26.Visible = false;
            comboBoxDecals.Visible = false;
            comboBoxShadowRange.Visible = false;
            comboBoxAdapterIndex.Visible = false;
            label3.Visible = true;
            label1.Visible = true;
            trackBarGrassDistance.Visible = true;
            label4.Visible = true;
            label27.Visible = true;
            trackBarObjects.Visible = true;
            label28.Visible = true;
            label29.Visible = true;
            trackBarItems.Visible = true;
            label30.Visible = true;
            label31.Visible = true;
            trackBarActors.Visible = true;
            label32.Visible = true;
            label33.Visible = true;
            trackBarLights.Visible = true;
            label34.Visible = true;
            comboBoxLODObjects.Visible = true;
            label35.Visible = true;
            buttonHideObjects.Visible = true;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxAA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAA.SelectedIndex == 0)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMultiSample", "1");
            }
            else if (comboBoxAA.SelectedIndex == 1)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMultiSample", "2");
            }
            else if (comboBoxAA.SelectedIndex == 2)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMultiSample", "4");
            }
            else if (comboBoxAA.SelectedIndex == 3)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMultiSample", "8");
            }
            refrashAA();
        }
        private void refrashAA()
        {
            FuncSettings.ENBCheck(false);
            int aa = FuncParser.intRead(FormMain.iniSkyrimPrefs, "Display", "iMultiSample");
            if (aa <= 1)
            {
                comboBoxAA.SelectedIndex = 0;
            }
            else if (aa <= 2)
            {
                comboBoxAA.SelectedIndex = 1;
            }
            else if (aa <= 4 && aa < 8)
            {
                comboBoxAA.SelectedIndex = 2;
            }
            else if (aa >= 8)
            {
                comboBoxAA.SelectedIndex = 3;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxAF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAF.SelectedIndex == 0)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy", "1");
            }
            else if (comboBoxAF.SelectedIndex == 1)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy", "2");
            }
            else if (comboBoxAF.SelectedIndex == 2)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy", "4");
            }
            else if (comboBoxAF.SelectedIndex == 3)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy", "8");
            }
            else if (comboBoxAF.SelectedIndex == 4)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy", "16");
            }
            refrashAF();
        }
        private void refrashAF()
        {
            FuncSettings.ENBCheck(false);
            int af = FuncParser.intRead(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy");
            if (af <= 1)
            {
                comboBoxAF.SelectedIndex = 0;
            }
            else if (af <= 2)
            {
                comboBoxAF.SelectedIndex = 1;
            }
            else if (af <= 4)
            {
                comboBoxAF.SelectedIndex = 2;
            }
            else if (af <= 8 && af < 16)
            {
                comboBoxAF.SelectedIndex = 3;
            }
            else if (af >= 16)
            {
                comboBoxAF.SelectedIndex = 4;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonFXAA_Click(object sender, EventArgs e)
        {
            if (fxaa)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFXAAEnabled", "0");
                refrashFXAA();
            }
            else
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFXAAEnabled", "1");
                refrashFXAA();
            }
        }
        private void refrashFXAA()
        {
            FuncSettings.ENBCheck(false);
            fxaa = FuncMisc.RefreshButton(buttonFXAA, FormMain.iniSkyrimPrefs, "Display", "bFXAAEnabled", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarGrass_Scroll(object sender, EventArgs e)
        {

            FuncParser.iniWrite(FormMain.iniSkyrim, "Grass", "iMinGrassSize", (trackBarGrass.Value * 5).ToString());
            refrashGrass();
        }
        private void refrashGrass()
        {
            FuncMisc.RefreshTrackBar(trackBarGrass, FormMain.iniSkyrim, "Grass", "iMinGrassSize", 5, label22);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxShadowMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxShadowMap.SelectedIndex == 0)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iShadowMapResolution", "512");
            }
            else if (comboBoxShadowMap.SelectedIndex == 1)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iShadowMapResolution", "1024");
            }
            else if (comboBoxShadowMap.SelectedIndex == 2)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iShadowMapResolution", "2048");
            }
            else if (comboBoxShadowMap.SelectedIndex == 3)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iShadowMapResolution", "4096");
            }
            else if (comboBoxShadowMap.SelectedIndex == 4)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iShadowMapResolution", "8192");
            }
            refrashShadow();
        }
        private void refrashShadow()
        {
            int shadow = FuncParser.intRead(FormMain.iniSkyrimPrefs, "Display", "iShadowMapResolution");
            if (shadow <= 512)
            {
                comboBoxShadowMap.SelectedIndex = 0;
            }
            else if (shadow <= 1024)
            {
                comboBoxShadowMap.SelectedIndex = 1;
            }
            else if (shadow <= 2048)
            {
                comboBoxShadowMap.SelectedIndex = 2;
            }
            else if (shadow <= 4096 && shadow < 8192)
            {
                comboBoxShadowMap.SelectedIndex = 3;
            }
            else if (shadow >= 8192)
            {
                comboBoxShadowMap.SelectedIndex = 4;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxWaterReflect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxWaterReflect.SelectedIndex == 0)
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODObjects", "0");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODLand", "0");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectSky", "0");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODTrees", "0");
            }
            else if (comboBoxWaterReflect.SelectedIndex == 1)
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODObjects", "0");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODLand", "0");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectSky", "1");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODTrees", "0");
            }
            else if (comboBoxWaterReflect.SelectedIndex == 2)
            {
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODObjects", "0");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODLand", "1");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectSky", "1");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODTrees", "0");
            }
            else if (comboBoxWaterReflect.SelectedIndex == 3)
            {

                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODObjects", "1");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODLand", "1");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectSky", "1");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODTrees", "0");
            }
            else if (comboBoxWaterReflect.SelectedIndex == 4)
            {

                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODObjects", "1");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODLand", "1");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectSky", "1");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODTrees", "1");
            }
            refrashWater();
        }
        private void refrashWater()
        {
            if (FuncParser.stringRead(FormMain.iniSkyrim, "Water", "bReflectLODTrees") == "1")
            {
                comboBoxWaterReflect.SelectedIndex = 4;
            }
            else if (FuncParser.stringRead(FormMain.iniSkyrim, "Water", "bReflectLODObjects") == "1")
            {
                comboBoxWaterReflect.SelectedIndex = 3;
            }
            else if (FuncParser.stringRead(FormMain.iniSkyrim, "Water", "bReflectLODLand") == "1")
            {
                comboBoxWaterReflect.SelectedIndex = 2;
            }
            else if (FuncParser.stringRead(FormMain.iniSkyrim, "Water", "bReflectSky") == "1")
            {
                comboBoxWaterReflect.SelectedIndex = 1;
            }
            else
            {
                comboBoxWaterReflect.SelectedIndex = 0;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxTextures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTextures.SelectedIndex == 0)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iTexMipMapSkip", "2");
            }
            else if (comboBoxTextures.SelectedIndex == 1)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iTexMipMapSkip", "1");
            }
            else if (comboBoxTextures.SelectedIndex == 2)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iTexMipMapSkip", "0");
            }
            refrashTextures();
        }
        private void refrashTextures()
        {
            int text = FuncParser.intRead(FormMain.iniSkyrimPrefs, "Display", "iTexMipMapSkip");
            if (text <= 0)
            {
                comboBoxTextures.SelectedIndex = 2;
            }
            else if (text == 1)
            {
                comboBoxTextures.SelectedIndex = 1;
            }
            else if (text >= 2)
            {
                comboBoxTextures.SelectedIndex = 0;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxShadowRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxShadowRange.SelectedIndex == 0)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iBlurDeferredShadowMask", "0");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowDistance", "2000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fTreesMidLODSwitchDist", "3500.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowBiasScale", "0.5000");
            }
            else if (comboBoxShadowRange.SelectedIndex == 1)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iBlurDeferredShadowMask", "2");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowDistance", "3500.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fTreesMidLODSwitchDist", "5000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowBiasScale", "0.3000");
            }
            else if (comboBoxShadowRange.SelectedIndex == 2)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iBlurDeferredShadowMask", "3");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowDistance", "5000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fTreesMidLODSwitchDist", "10000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowBiasScale", "0.2500");
            }
            else if (comboBoxShadowRange.SelectedIndex == 3)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iBlurDeferredShadowMask", "3");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowDistance", "8000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fTreesMidLODSwitchDist", "10000000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowBiasScale", "0.1500");
            }
            refrashShadowRange();
            refrashShadow();
        }
        private void refrashShadowRange()
        {
            int dist = FuncParser.intRead(FormMain.iniSkyrimPrefs, "Display", "fShadowDistance");
            if (dist <= 2000)
            {
                comboBoxShadowRange.SelectedIndex = 0;
            }
            else if (dist <= 3500)
            {
                comboBoxShadowRange.SelectedIndex = 1;
            }
            else if (dist <= 5000 && dist < 8000)
            {
                comboBoxShadowRange.SelectedIndex = 2;
            }
            else if (dist >= 8000)
            {
                comboBoxShadowRange.SelectedIndex = 3;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxDecals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDecals.SelectedIndex == 0)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxSkinDecalsPerFrame", "0");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxDecalsPerFrame", "0");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecals", "0");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecalsPerActor", "0");
            }
            else if (comboBoxDecals.SelectedIndex == 1)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxSkinDecalsPerFrame", "3");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxDecalsPerFrame", "10");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecals", "35");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecalsPerActor", "20");
            }
            else if (comboBoxDecals.SelectedIndex == 2)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxSkinDecalsPerFrame", "10");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxDecalsPerFrame", "30");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecals", "50");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecalsPerActor", "40");
            }
            else if (comboBoxDecals.SelectedIndex == 3)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxSkinDecalsPerFrame", "25");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxDecalsPerFrame", "100");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecals", "100");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecalsPerActor", "60");
            }
            refrashDecals();
        }
        private void refrashDecals()
        {
            int decal = FuncParser.intRead(FormMain.iniSkyrimPrefs, "Display", "iMaxDecalsPerFrame");
            if (decal <= 0)
            {
                comboBoxDecals.SelectedIndex = 0;
            }
            else if (decal <= 10)
            {
                comboBoxDecals.SelectedIndex = 1;
            }
            else if (decal <= 30 && decal < 100)
            {
                comboBoxDecals.SelectedIndex = 2;
            }
            else if (decal >= 100)
            {
                comboBoxDecals.SelectedIndex = 3;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            QuestionResul("Установить Русскую озвучку?", ruLocation, enLocation);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            QuestionResul("Установить Английскую озвучку?", enLocation, ruLocation);
        }
        private void QuestionResul(string question, string path1, string path2)
        {
            DialogResult dialogResult = MessageBox.Show(question, "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MoveVoicesFiles(path1, path2);
            }
        }
        private void MoveVoicesFiles(string path1, string path2)
        {
            List<string> path2Files = Directory.GetFiles(path2, filesType).Select(f => f.Substring((path2).Length)).ToList();
            foreach (string line in Directory.GetFiles(path1, filesType).Select(f => f.Substring((path1).Length)).ToList())
            {
                if (path2Files.Contains(line))
                {
                    FuncFiles.Delete(FormMain.gameFolder + @"Data\" + line);
                    FuncFiles.MoveAnyFiles(path1 + line, FormMain.gameFolder + @"Data\" + line);
                }
                else
                {
                    FuncFiles.MoveAnyFiles(FormMain.gameFolder + @"Data\" + line, path2 + line);
                    FuncFiles.MoveAnyFiles(path1 + line, FormMain.gameFolder + @"Data\" + line);
                }
            }
            refreshLangButton();
        }
        private void refreshLangButton()
        {
            if (Directory.Exists(ruLocation))
            {
                if (Directory.GetFiles(ruLocation, filesType).ToList().Count > 0)
                {
                    pictureBox1.Enabled = true;
                    pictureBox1.BackgroundImage = Properties.Resources.RU;
                }
                else
                {
                    pictureBox1.Enabled = false;
                    pictureBox1.BackgroundImage = Properties.Resources.RUoff;
                }
            }
            if (Directory.Exists(enLocation))
            {
                if (Directory.GetFiles(enLocation, filesType).ToList().Count > 0)
                {
                    pictureBox2.Enabled = true;
                    pictureBox2.BackgroundImage = Properties.Resources.EN;
                }
                else
                {
                    pictureBox2.Enabled = false;
                    pictureBox2.BackgroundImage = Properties.Resources.ENoff;
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarGrassDistance_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Grass", "fGrassStartFadeDistance", (trackBarGrassDistance.Value * 1000).ToString());
            refrashGrassDistance();
        }
        private void refrashGrassDistance()
        {
            FuncMisc.RefreshTrackBar(trackBarGrassDistance, FormMain.iniSkyrimPrefs, "Grass", "fGrassStartFadeDistance", 1000, label3);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarObjects_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultObjects", (trackBarObjects.Value).ToString());
            refrashObjects();
        }
        private void refrashObjects()
        {
            FuncMisc.RefreshTrackBar(trackBarObjects, FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultObjects", -1, label27);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarItems_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultItems", (trackBarItems.Value).ToString());
            refrashItems();
        }
        private void refrashItems()
        {
            FuncMisc.RefreshTrackBar(trackBarItems, FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultItems", -1, label29);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarActors_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultActors", (trackBarActors.Value).ToString());
            refrashActors();
        }
        private void refrashActors()
        {
            FuncMisc.RefreshTrackBar(trackBarActors, FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultActors", -1, label31);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarLights_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fLightLODStartFade", (trackBarLights.Value * 100).ToString());
            refrashLights();
        }
        private void refrashLights()
        {
            FuncMisc.RefreshTrackBar(trackBarLights, FormMain.iniSkyrimPrefs, "Display", "fLightLODStartFade", 100, label33);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxLODObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLODObjects.SelectedIndex == 0)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fTreeLoadDistance", "12500.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockMaximumDistance", "75000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel1Distance", "25000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel0Distance", "15000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fSplitDistanceMult", "0.4000");
            }
            else if (comboBoxLODObjects.SelectedIndex == 1)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fTreeLoadDistance", "25000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockMaximumDistance", "100000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel1Distance", "32768.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel0Distance", "20480.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fSplitDistanceMult", "0.7500");
            }
            else if (comboBoxLODObjects.SelectedIndex == 2)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fTreeLoadDistance", "40000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockMaximumDistance", "150000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel1Distance", "40000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel0Distance", "25000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fSplitDistanceMult", "1.1000");
            }
            else if (comboBoxLODObjects.SelectedIndex == 3)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fTreeLoadDistance", "75000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockMaximumDistance", "250000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel1Distance", "70000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel0Distance", "35000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fSplitDistanceMult", "1.5000");
            }
            refrashLODObjects();
        }
        private void refrashLODObjects()
        {
            int objects = FuncParser.intRead(FormMain.iniSkyrimPrefs, "TerrainManager", "fTreeLoadDistance");
            if (objects <= 12500)
            {
                comboBoxLODObjects.SelectedIndex = 0;
            }
            else if (objects <= 25000)
            {
                comboBoxLODObjects.SelectedIndex = 1;
            }
            else if (objects <= 40000 && objects < 75000)
            {
                comboBoxLODObjects.SelectedIndex = 2;
            }
            else if (objects >= 75000)
            {
                comboBoxLODObjects.SelectedIndex = 3;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonHideObjects_Click(object sender, EventArgs e)
        {
            if (hideobjects)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel2FadeDist", "10000000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel1FadeDist", "10000000.0000");
            }
            else
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel2FadeDist", "5000.0000");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel1FadeDist", "5000.0000");
            }
            refreshHideObjects();
        }
        private void refreshHideObjects()
        {
            int objects = FuncParser.intRead(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel1FadeDist");
            if (objects == 10000000)
            {
                buttonHideObjects.BackgroundImage = Properties.Resources.buttonToggleOff;
                hideobjects = false;
            }
            else
            {
                buttonHideObjects.BackgroundImage = Properties.Resources.buttonToggleOn;
                hideobjects = true;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonClose_Click(object sender, EventArgs e)
        {
            BackgroundImage = null;
            DoubleBuffered = false;
            Dispose();
        }
    }
}