using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormMain : Form
    {
        public static string launcherFolder = FuncFiles.PathAddSlash(AppDomain.CurrentDomain.BaseDirectory);
        public static string gameFolder = FuncFiles.PathAddSlash(Path.GetDirectoryName(Path.GetDirectoryName(launcherFolder)));
        public static string myDocPath = FuncFiles.PathAddSlash(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + @"My Games\Skyrim\";
        public static string iniSkyrim = myDocPath + @"Skyrim.ini";
        public static string iniSkyrimPrefs = myDocPath + @"SkyrimPrefs.ini";
        public static string appDataPath = FuncFiles.PathAddSlash(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) + @"Skyrim\";
        public static string iniLauncher = launcherFolder + "SLMPLauncher.ini";
        public static string iniIgnoreFiles = launcherFolder + "SLMPIgnoreFiles.ini";
        public static string startWithGame = null;
        public static string waitBeforeStart = null;
        public static int numberStyle = 0;
        string helpPath = gameFolder + @"_Programs\ProgramFiles\SLMP-GR Help.chm";
        string wryeBash = gameFolder + @"_Programs\ProgramFiles\Mopy\Wrye Bash.exe";
        string dsr = gameFolder + @"Data\SkyProc Patchers\Dual Sheath Redux Patch\Dual Sheath Redux Patch.jar";
        string fnis = gameFolder + @"Data\Tools\GenerateFNIS_for_Users\GenerateFNISforUsers.exe";
        bool moveWindow = false;
        bool windgetOpen = false;
        int mouseWindowX = 0;
        int mouseWindowY = 0;
        public static Bitmap BMbuttonlogoGlow;
        public static Bitmap BMbuttonlogo;
        public static Bitmap BMbuttonlogoPressed;
        public static Bitmap BMbuttonWryeBashGlow;
        public static Bitmap BMbuttonWryeBash;
        public static Bitmap BMbuttonWryeBashPressed;
        public static Bitmap BMbuttonDSRGlow;
        public static Bitmap BMbuttonDSR;
        public static Bitmap BMbuttonDSRPressed;
        public static Bitmap BMbuttonFNISGlow;
        public static Bitmap BMbuttonFNIS;
        public static Bitmap BMbuttonFNISPressed;
        public static Bitmap BMbuttonProgramsDirGlow;
        public static Bitmap BMbuttonProgramsDir;
        public static Bitmap BMbuttonGameDirGlow;
        public static Bitmap BMbuttonGameDir;
        public static Bitmap BMbuttonResetGlow;
        public static Bitmap BMbuttonReset;
        public static Bitmap BMbuttonClearGlow;
        public static Bitmap BMbuttonClear;
        public static Bitmap BMbuttonAddDirGlow;
        public static Bitmap BMbuttonAddDir;
        public static Bitmap BMbuttonAddFileGlow;
        public static Bitmap BMbuttonAddFile;
        public static Bitmap BMbuttonModsGlow;
        public static Bitmap BMbuttonMods;
        public static Bitmap BMbuttonProgramsGlow;
        public static Bitmap BMbuttonPrograms;
        public static Bitmap BMbuttonENBGlow;
        public static Bitmap BMbuttonENB;
        public static Bitmap BMbuttonOptionsGlow;
        public static Bitmap BMbuttonOptions;
        public static Bitmap BMBackgroundImage;
        FormWidget settingsWidget = null;

        public FormMain()
        {
            InitializeComponent();
            if (File.Exists(iniLauncher))
            {
                if (FuncParser.keyExists(iniLauncher, "Position", "POS_WindowTop") && FuncParser.keyExists(iniLauncher, "Position", "POS_WindowLeft"))
                {
                    int Wleft = -1;
                    int Wtop = -1;
                    Wleft = FuncParser.intRead(iniLauncher, "Position", "POS_WindowLeft");
                    Wtop = FuncParser.intRead(iniLauncher, "Position", "POS_WindowTop");
                    if (Wleft > (Screen.PrimaryScreen.Bounds.Width - Size.Width))
                    {
                        Wleft = Screen.PrimaryScreen.Bounds.Width - Size.Width;
                    }
                    else if (Wleft < 0)
                    {
                        Wleft = 0;
                    }
                    if (Wtop > (Screen.PrimaryScreen.Bounds.Height - Size.Height))
                    {
                        Wtop = Screen.PrimaryScreen.Bounds.Height - Size.Height;
                    }
                    else if (Wtop < 0)
                    {
                        Wtop = 0;
                    }
                    StartPosition = FormStartPosition.Manual;
                    Location = new Point(Wleft, Wtop);
                }
                else
                {
                    StartPosition = FormStartPosition.CenterScreen;
                }
                if (FuncParser.keyExists(iniLauncher, "General", "Version_CP"))
                {
                    var version1 = new Version(FileVersionInfo.GetVersionInfo(Process.GetCurrentProcess().MainModule.FileName).ProductVersion);
                    var version2 = new Version(FuncParser.stringRead(iniLauncher, "General", "Version_CP"));
                    var result = version1.CompareTo(version2);
                    if (result != 0)
                    {
                        FuncParser.iniWrite(iniLauncher, "General", "Version_CP", version1.ToString());
                    }
                }
                else
                {
                    FuncParser.iniWrite(iniLauncher, "General", "Version_CP", FileVersionInfo.GetVersionInfo(launcherFolder + "SLMPLauncher.exe").ProductVersion);
                }
                if (FuncParser.keyExists(iniLauncher, "General", "NumberStyle"))
                {
                    numberStyle = FuncParser.intRead(iniLauncher, "General", "NumberStyle");
                    if (numberStyle >= 1 && numberStyle <= 3)
                    {
                        if (numberStyle == 1)
                        {
                            FuncStyle_1.style_1();
                        }
                        else if (numberStyle == 2)
                        {
                            FuncStyle_2.style_2();
                        }
                    }
                    else
                    {
                        numberStyle = 1;
                        FuncStyle_1.style_1();
                    }
                }
                else
                {
                    numberStyle = 1;
                    FuncStyle_1.style_1();
                }
            }
            else
            {
                numberStyle = 1;
                FuncStyle_1.style_1();
                StartPosition = FormStartPosition.CenterScreen;
                OnProcessExit(this, new EventArgs());
            }
            if (!File.Exists(iniSkyrimPrefs) || !File.Exists(iniSkyrim))
            {
                resetSettings();
            }
            toolTip1.SetToolTip(buttonMods, "Установка опциональных модов.");
            toolTip1.SetToolTip(buttonWryeBash, "Сортировщик модов. Моды имеющие конфликты будут красными.");
            toolTip1.SetToolTip(buttonDSRStart, "Патчер Dual Sheath Redux. Применять после изменения в модах.");
            toolTip1.SetToolTip(buttonFNISStart, "Патчер FNIS. Применять после изменения модов содержащих анимации.");
            toolTip1.SetToolTip(buttonGameDirectory, "Открывает папку-директорию игры.");
            toolTip1.SetToolTip(buttonResetSettings, "Полный сброс настроек игры и восстановление последовательности модов.");
            toolTip1.SetToolTip(buttonClearDirectory, "Удаляет \"чужие\" файлы. В т.ч. распакованные программы.");
            toolTip1.SetToolTip(buttonInstRemPrograms, "Распаковка различных программ для редактирования игры.");
            toolTip1.SetToolTip(buttonENBmenu, "Меню управления ENB с выбором различных пресетов.");
            toolTip1.SetToolTip(buttonProgrammsFolder, "Открывает папку с ярлыками программ для редактирования игры.");
            toolTip1.SetToolTip(buttonSkyrim, "Запустить игру.");
            toolTip1.SetToolTip(buttonAddFolderToIgnore, "Добавление папки в шаблон игнор-листа.");
            toolTip1.SetToolTip(buttonAddFileToIgnore, "Добавление файла(ов) в шаблон игнор-листа.");
            toolTip1.SetToolTip(buttonOptions, "Настройка конфигурации, параметров игры, управление подключаемыми файлами.");
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            RefreshStyle();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void OnProcessExit(object sender, EventArgs e)
        {
            if (!File.Exists(iniLauncher))
            {
                StreamWriter sw = new StreamWriter(iniLauncher);
                sw.WriteLine("[General]");
                sw.WriteLine("Version_CP=" + FileVersionInfo.GetVersionInfo(Process.GetCurrentProcess().MainModule.FileName).ProductVersion);
                sw.WriteLine("HideWebButtons=false");
                sw.WriteLine("NumberStyle=" + numberStyle);
                sw.WriteLine("");
                sw.WriteLine("[Position]");
                sw.WriteLine("POS_WindowTop=" + Top);
                sw.WriteLine("POS_WindowLeft=" + Left);
                sw.WriteLine("");
                sw.WriteLine("[Updates]");
                sw.Close();
            }
            else
            {
                FuncParser.iniWrite(iniLauncher, "General", "NumberStyle", numberStyle.ToString());
                FuncParser.iniWrite(iniLauncher, "Position", "POS_WindowTop", Top.ToString());
                FuncParser.iniWrite(iniLauncher, "Position", "POS_WindowLeft", Left.ToString());
            }
            AppDomain.CurrentDomain.ProcessExit -= new EventHandler(OnProcessExit);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonWryeBash_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(wryeBash))
            {
                buttonWryeBash.Enabled = false;
                buttonWryeBash.MouseEnter -= new EventHandler(buttonWryeBash_MouseEnter);
                buttonWryeBash.MouseLeave -= new EventHandler(buttonWryeBash_MouseLeave);
                buttonWryeBash.BackgroundImage = BMbuttonWryeBashPressed;
                FuncMisc.RunProcess(wryeBash, null, WryeBashExited, this);
            }
            else
            {
                MessageBox.Show("Wrye Bash не найден.");
            }
        }
        private void WryeBashExited(object sender, EventArgs e)
        {
            buttonWryeBash.Enabled = true;
            buttonWryeBash.MouseEnter += new EventHandler(buttonWryeBash_MouseEnter);
            buttonWryeBash.MouseLeave += new EventHandler(buttonWryeBash_MouseLeave);
            buttonWryeBash.BackgroundImage = BMbuttonWryeBash;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonDSRStart_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(dsr))
            {
                buttonDSRStart.Enabled = false;
                buttonDSRStart.MouseEnter -= new EventHandler(buttonDSRStart_MouseEnter);
                buttonDSRStart.MouseLeave -= new EventHandler(buttonDSRStart_MouseLeave);
                buttonDSRStart.BackgroundImage = BMbuttonDSRPressed;
                FuncMisc.RunProcess(dsr, null, DSRExited, this);
            }
            else
            {
                MessageBox.Show("Dual Sheath Redux патчер не найден.");
            }
        }
        private void DSRExited(object sender, EventArgs e)
        {
            buttonDSRStart.Enabled = true;
            buttonDSRStart.MouseEnter += new EventHandler(buttonDSRStart_MouseEnter);
            buttonDSRStart.MouseLeave += new EventHandler(buttonDSRStart_MouseLeave);
            buttonDSRStart.BackgroundImage = BMbuttonDSR;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonFNIS_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(fnis))
            {
                FuncMisc.ToggleButtons(this, false);
                FuncMisc.UnPackRAR(launcherFolder + @"CPFiles\BackUp\FNIS.rar");
                FuncMisc.ToggleButtons(this, true);
                buttonFNISStart.Enabled = false;
                buttonFNISStart.MouseEnter -= new EventHandler(buttonFNISStart_MouseEnter);
                buttonFNISStart.MouseLeave -= new EventHandler(buttonFNISStart_MouseLeave);
                buttonFNISStart.BackgroundImage = BMbuttonFNISPressed;
                FuncMisc.RunProcess(fnis, null, FNISExited, this);
            }
            else
            {
                MessageBox.Show("FNIS патчер не найден.");
            }
        }
        private void FNISExited(object sender, EventArgs e)
        {
            buttonFNISStart.Enabled = true;
            buttonFNISStart.MouseEnter += new EventHandler(buttonFNISStart_MouseEnter);
            buttonFNISStart.MouseLeave += new EventHandler(buttonFNISStart_MouseLeave);
            buttonFNISStart.BackgroundImage = BMbuttonFNIS;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonGameDirectory_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (Directory.Exists(gameFolder))
            {
                Process.Start(gameFolder);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonProgrammsFolder_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (Directory.Exists(gameFolder + "_Programs"))
            {
                Process.Start(gameFolder + "_Programs");
            }
            else
            {
                MessageBox.Show("Не найдена папка программ для редактирования.");
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonResetSettings_Click(object sender, EventArgs e)
        {
            label1.Focus();
            DialogResult dialogResult = MessageBox.Show("Сбросить настройки?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                resetSettings();
            }
        }
        public void resetSettings()
        {
            if (File.Exists(launcherFolder + "Skyrim.ini") && File.Exists(launcherFolder + "SkyrimPrefs.ini") && File.Exists(launcherFolder + @"MasterList\DLCList.txt") && File.Exists(launcherFolder + @"MasterList\plugins.txt"))
            {
                try
                {
                    RegistryKey key;
                    key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Bethesda Softworks\Skyrim");
                    key.SetValue("Installed Path", gameFolder);
                    key.Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось записать путь в реест.");
                }
                FuncFiles.Delete(myDocPath + "Skyrim.ini");
                FuncFiles.Delete(myDocPath + "SkyrimPrefs.ini");
                FuncFiles.Delete(myDocPath + "Logs");
                FuncFiles.Delete(myDocPath + "SKSE");
                FuncFiles.Delete(myDocPath + "SkyProc");
                FuncFiles.Delete(myDocPath + "BashSettings.dat");
                FuncFiles.Delete(myDocPath + "BashSettings.dat.bak");
                FuncFiles.Delete(myDocPath + "RendererInfo.txt");
                FuncFiles.Delete(myDocPath + @"Saves\Bash");
                FuncFiles.CreatDirectory(myDocPath);
                FuncFiles.CopyAnyFiles(launcherFolder + "Skyrim.ini", myDocPath + "Skyrim.ini");
                FuncFiles.CopyAnyFiles(launcherFolder + "SkyrimPrefs.ini", myDocPath + "SkyrimPrefs.ini");
                FuncFiles.CopyAnyFiles(launcherFolder + @"MasterList\BashSettings.dat", myDocPath + "BashSettings.dat");
                FuncFiles.Delete(appDataPath + @"DLCList.txt");
                FuncFiles.Delete(appDataPath + @"plugins.txt");
                FuncFiles.Delete(appDataPath + @"loadorder.txt");
                FuncFiles.CreatDirectory(appDataPath);
                FuncFiles.CopyAnyFiles(launcherFolder + @"MasterList\DLCList.txt", appDataPath + @"DLCList.txt");
                FuncFiles.CopyAnyFiles(launcherFolder + @"MasterList\plugins.txt", appDataPath + @"plugins.txt");
                FuncFiles.CopyAnyFiles(launcherFolder + @"MasterList\Plugins.tes5viewsettings", appDataPath + @"Plugins.tes5viewsettings");
                FormOptions opt = new FormOptions();
                opt.resetSettings();
                opt.Close();
            }
            else
            {
                MessageBox.Show("Нет шаблонов конфигурационных файлов для сброса настроек.");
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonClearDirectory_Click(object sender, EventArgs e)
        {
            label1.Focus();
            DialogResult dialogResult = MessageBox.Show("Очистить директорию?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncFiles.Delete(gameFolder + @"..\Skyrim Mods");
                FuncClear.Clear();
                FuncClear.EmptyFolder(gameFolder);
            }
        }
        private void buttonAddFileToIgnore_Click(object sender, EventArgs e)
        {
            label1.Focus();
            openFileDialog1.InitialDirectory = gameFolder;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (openFileDialog1.FileName.Contains(gameFolder))
                {
                    foreach (string line in openFileDialog1.FileNames)
                    {
                        string FileName = line.Remove(0, gameFolder.Length);
                        File.AppendAllText(iniIgnoreFiles, FileName + Environment.NewLine);
                    }
                }
                else
                {
                    MessageBox.Show("Выбран(ы) файл(ы) вне директории игры.");
                }
            }
        }
        private void buttonAddFolderToIgnore_Click(object sender, EventArgs e)
        {
            label1.Focus();
            folderBrowserDialog1.SelectedPath = gameFolder;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath.Contains(gameFolder))
                {
                    string DirName = folderBrowserDialog1.SelectedPath.Remove(0, gameFolder.Length);
                    File.AppendAllText(iniIgnoreFiles, DirName + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("Выбрана папка вне директории игры.");
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonInstRemPrograms_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (Directory.Exists(gameFolder + "_Programs"))
            {
                var dialog = new FormPrograms();
                dialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Не найдена папка программ для редактирования.");
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonENBmenu_Click(object sender, EventArgs e)
        {
            label1.Focus();
            var dialog = new FormENBMenu();
            dialog.ShowDialog();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonSkyrim_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(gameFolder + "TESV.exe"))
            {
                buttonSkyrim.Enabled = false;
                buttonSkyrim.MouseEnter -= new EventHandler(buttonSkyrim_MouseEnter);
                buttonSkyrim.MouseLeave -= new EventHandler(buttonSkyrim_MouseLeave);
                buttonSkyrim.BackgroundImage = BMbuttonlogoPressed;
                if (startWithGame != null)
                {
                    if (File.Exists(startWithGame))
                    {
                        Process.Start(startWithGame);
                    }
                }
                if (waitBeforeStart != null)
                {
                    int WaitTime = FuncParser.stringToInt(waitBeforeStart);
                    if (WaitTime > 0)
                    {
                        FuncMisc.ToggleButtons(this, false);
                        Thread.Sleep(WaitTime * 1000);
                        FuncMisc.ToggleButtons(this, true);
                        buttonSkyrim.Enabled = false;
                    }
                }
                FuncMisc.RunProcess(gameFolder + "TESV.exe", "-forcesteamloader", SKSEExited, this);
            }
            else
            {
                MessageBox.Show("Не найден TESV.exe.");
            }
        }
        private void SKSEExited(object sender, EventArgs e)
        {
            bool find = false;
            foreach (Process line in Process.GetProcessesByName("SKYRIM"))
            {
                line.EnableRaisingEvents = true;
                line.Exited += processGAMEExited;
                find = true;
            }
            if (!find)
            {
                processGAMEExited(this, new EventArgs());
            }
        }
        private void processGAMEExited(object sender, EventArgs e)
        {
            buttonSkyrim.Enabled = true;
            buttonSkyrim.MouseEnter += new EventHandler(buttonSkyrim_MouseEnter);
            buttonSkyrim.MouseLeave += new EventHandler(buttonSkyrim_MouseLeave);
            buttonSkyrim.BackgroundImage = BMbuttonlogo;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonMods_Click(object sender, EventArgs e)
        {
            label1.Focus();
            var dialog = new FormMods();
            dialog.ShowDialog();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonOptions_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(iniSkyrim) && File.Exists(iniSkyrimPrefs) && File.Exists(appDataPath + @"plugins.txt"))
            {
                var dialog = new FormOptions();
                dialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Файлы настроек Skyrim не сформированы. Сделайте сброс настроек.");
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(helpPath))
            {
                Process.Start(helpPath);
            }
            else
            {
                MessageBox.Show("Нет файла справки.");
            }
        }
        private void buttonWidget_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (!windgetOpen)
            {
                windgetOpen = true;
                settingsWidget = new FormWidget();
                settingsWidget.Show(this);
                settingsWidget.DesktopLocation = new Point(Left, Top - settingsWidget.Size.Height);
                buttonWidget.BackgroundImage = Properties.Resources.buttonWidgetPressed;
            }
            else
            {
                windgetOpen = false;
                settingsWidget.Close();
                buttonWidget.BackgroundImage = Properties.Resources.buttonWidget;
            }
        }
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            label1.Focus();
            WindowState = FormWindowState.Minimized;
            if (windgetOpen)
            {
                windgetOpen = false;
                settingsWidget.Close();
                buttonWidget.BackgroundImage = Properties.Resources.buttonWidget;
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            label1.Focus();
            Application.Exit();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            moveWindow = true;
            mouseWindowX = e.X;
            mouseWindowY = e.Y;
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (moveWindow)
            {
                moveWindow = false;
            }
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveWindow)
            {
                Location = new Point(Cursor.Position.X - mouseWindowX, Cursor.Position.Y - mouseWindowY);
                if (windgetOpen)
                {
                    settingsWidget.Location = new Point(Left, Top - settingsWidget.Size.Height);
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public void RefreshStyle()
        {
            if (buttonSkyrim.Enabled == true)
            {
                buttonSkyrim.BackgroundImage = BMbuttonlogo;
            }
            else
            {
                buttonSkyrim.BackgroundImage = BMbuttonlogoPressed;
            }
            if (buttonWryeBash.Enabled == true)
            {
                buttonWryeBash.BackgroundImage = BMbuttonWryeBash;
            }
            else
            {
                buttonWryeBash.BackgroundImage = BMbuttonWryeBashPressed;
            }
            if (buttonDSRStart.Enabled == true)
            {
                buttonDSRStart.BackgroundImage = BMbuttonDSR;
            }
            else
            {
                buttonDSRStart.BackgroundImage = BMbuttonDSRPressed;
            }
            if (buttonFNISStart.Enabled == true)
            {
                buttonFNISStart.BackgroundImage = BMbuttonFNIS;
            }
            else
            {
                buttonFNISStart.BackgroundImage = BMbuttonFNISPressed;
            }
            buttonProgrammsFolder.BackgroundImage = BMbuttonProgramsDir;
            buttonGameDirectory.BackgroundImage = BMbuttonGameDir;
            buttonResetSettings.BackgroundImage = BMbuttonReset;
            buttonClearDirectory.BackgroundImage = BMbuttonClear;
            buttonAddFolderToIgnore.BackgroundImage = BMbuttonAddDir;
            buttonAddFileToIgnore.BackgroundImage = BMbuttonAddFile;
            buttonMods.BackgroundImage = BMbuttonMods;
            buttonInstRemPrograms.BackgroundImage = BMbuttonPrograms;
            buttonENBmenu.BackgroundImage = BMbuttonENB;
            buttonOptions.BackgroundImage = BMbuttonOptions;
            BackgroundImage = BMBackgroundImage;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonSkyrim_MouseEnter(object sender, EventArgs e)
        {
            buttonSkyrim.BackgroundImage = BMbuttonlogoGlow;
        }
        private void buttonSkyrim_MouseLeave(object sender, EventArgs e)
        {
            buttonSkyrim.BackgroundImage = BMbuttonlogo;
        }

        private void buttonWryeBash_MouseEnter(object sender, EventArgs e)
        {
            buttonWryeBash.BackgroundImage = BMbuttonWryeBashGlow;
        }
        private void buttonWryeBash_MouseLeave(object sender, EventArgs e)
        {
            buttonWryeBash.BackgroundImage = BMbuttonWryeBash;
        }

        private void buttonDSRStart_MouseEnter(object sender, EventArgs e)
        {
            buttonDSRStart.BackgroundImage = BMbuttonDSRGlow;
        }
        private void buttonDSRStart_MouseLeave(object sender, EventArgs e)
        {
            buttonDSRStart.BackgroundImage = BMbuttonDSR;
        }

        private void buttonFNISStart_MouseEnter(object sender, EventArgs e)
        {
            buttonFNISStart.BackgroundImage = BMbuttonFNISGlow;
        }
        private void buttonFNISStart_MouseLeave(object sender, EventArgs e)
        {
            buttonFNISStart.BackgroundImage = BMbuttonFNIS;
        }

        private void buttonProgrammsFolder_MouseEnter(object sender, EventArgs e)
        {
            buttonProgrammsFolder.BackgroundImage = BMbuttonProgramsDirGlow;
        }
        private void buttonProgrammsFolder_MouseLeave(object sender, EventArgs e)
        {
            buttonProgrammsFolder.BackgroundImage = BMbuttonProgramsDir;
        }

        private void buttonGameDirectory_MouseEnter(object sender, EventArgs e)
        {
            buttonGameDirectory.BackgroundImage = BMbuttonGameDirGlow;
        }
        private void buttonGameDirectory_MouseLeave(object sender, EventArgs e)
        {
            buttonGameDirectory.BackgroundImage = BMbuttonGameDir;
        }

        private void buttonResetSettings_MouseEnter(object sender, EventArgs e)
        {
            buttonResetSettings.BackgroundImage = BMbuttonResetGlow;
        }
        private void buttonResetSettings_MouseLeave(object sender, EventArgs e)
        {
            buttonResetSettings.BackgroundImage = BMbuttonReset;
        }

        private void buttonClearDirectory_MouseEnter(object sender, EventArgs e)
        {
            buttonClearDirectory.BackgroundImage = BMbuttonClearGlow;
        }
        private void buttonClearDirectory_MouseLeave(object sender, EventArgs e)
        {
            buttonClearDirectory.BackgroundImage = BMbuttonClear;
        }

        private void buttonAddFolderToIgnore_MouseEnter(object sender, EventArgs e)
        {
            buttonAddFolderToIgnore.BackgroundImage = BMbuttonAddDirGlow;
        }
        private void buttonAddFolderToIgnore_MouseLeave(object sender, EventArgs e)
        {
            buttonAddFolderToIgnore.BackgroundImage = BMbuttonAddDir;
        }

        private void buttonAddFileToIgnore_MouseEnter(object sender, EventArgs e)
        {
            buttonAddFileToIgnore.BackgroundImage = BMbuttonAddFileGlow;
        }
        private void buttonAddFileToIgnore_MouseLeave(object sender, EventArgs e)
        {
            buttonAddFileToIgnore.BackgroundImage = BMbuttonAddFile;
        }

        private void buttonMods_MouseEnter(object sender, EventArgs e)
        {
            buttonMods.BackgroundImage = BMbuttonModsGlow;
        }
        private void buttonMods_MouseLeave(object sender, EventArgs e)
        {
            buttonMods.BackgroundImage = BMbuttonMods;
        }

        private void buttonInstRemPrograms_MouseEnter(object sender, EventArgs e)
        {
            buttonInstRemPrograms.BackgroundImage = BMbuttonProgramsGlow;
        }
        private void buttonInstRemPrograms_MouseLeave(object sender, EventArgs e)
        {
            buttonInstRemPrograms.BackgroundImage = BMbuttonPrograms;
        }

        private void buttonENBmenu_MouseEnter(object sender, EventArgs e)
        {
            buttonENBmenu.BackgroundImage = BMbuttonENBGlow;
        }
        private void buttonENBmenu_MouseLeave(object sender, EventArgs e)
        {
            buttonENBmenu.BackgroundImage = BMbuttonENB;
        }

        private void buttonOptions_MouseEnter(object sender, EventArgs e)
        {
            buttonOptions.BackgroundImage = BMbuttonOptionsGlow;
        }
        private void buttonOptions_MouseLeave(object sender, EventArgs e)
        {
            buttonOptions.BackgroundImage = BMbuttonOptions;
        }

        private void buttonHelp_MouseEnter(object sender, EventArgs e)
        {
            buttonHelp.BackgroundImage = Properties.Resources.buttonHelpGlow;
        }
        private void buttonHelp_MouseLeave(object sender, EventArgs e)
        {
            buttonHelp.BackgroundImage = Properties.Resources.buttonHelp;
        }

        private void buttonWidget_MouseEnter(object sender, EventArgs e)
        {
            if (windgetOpen)
            {
                buttonWidget.BackgroundImage = Properties.Resources.buttonWidgetPressed;
            }
            else
            {
                buttonWidget.BackgroundImage = Properties.Resources.buttonWidgetGlow;
            }
        }
        private void buttonWidget_MouseLeave(object sender, EventArgs e)
        {
            if (windgetOpen)
            {
                buttonWidget.BackgroundImage = Properties.Resources.buttonWidgetPressed;
            }
            else
            {
                buttonWidget.BackgroundImage = Properties.Resources.buttonWidget;
            }
        }

        private void buttonMinimize_MouseEnter(object sender, EventArgs e)
        {
            buttonMinimize.BackgroundImage = Properties.Resources.buttonMinimizeGlow;
        }
        private void buttonMinimize_MouseLeave(object sender, EventArgs e)
        {
            buttonMinimize.BackgroundImage = Properties.Resources.buttonMinimize;
        }

        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.buttonCloseGlow;
        }
        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.buttonClose;
        }
    }
}