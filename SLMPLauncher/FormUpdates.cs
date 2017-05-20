using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormUpdates : Form
    {
        string updateFolder = FormMain.launcherFolder + @"Updates\";
        string nameUpdateInfo = "UpdateInfo.ini";
        string nameControlPanel = "SLMPLauncher.exe";
        string nameHostName = "http://www.slmp.ru";
        string nameDLFolderHost = "/_SLMP-GR/";
        string downloadFileType = null;
        string downloadFileName = null;
        bool updatesFound = false;
        bool stopDownload = false;
        bool updatesCPFound = false;
        bool updateInstall = false;
        int numberSelectFile = -1;
        WebClient client = new WebClient();

        public FormUpdates()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(FormMain.launcherFolder);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            if (FormMain.numberStyle > 1)
            {
                imageBackgroundImage();
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.LabelsTextColor(this, System.Drawing.SystemColors.ControlLight, System.Drawing.Color.FromArgb(30, 30, 30));
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonCheckU_Click(object sender, EventArgs e)
        {
            if (stopDownload)
            {
                client.CancelAsync();
                stopDownload = false;
                EnableDisableButtons();
            }
            else
            {
                stopDownload = true;
                EnableDisableButtons();
                if (updatesFound)
                {
                    string line = FuncParser.stringRead(updateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_warning");
                    if (line != null)
                    {
                        MessageBox.Show(line);
                        line = null;
                    }
                    FuncFiles.Delete(updateFolder + "file" + numberSelectFile + ".rar");
                    downloadFileName = "file" + numberSelectFile + ".rar";
                    downloadFileType = "UpdateG";
                    client_DownloadProgressStart();
                }
                else
                {
                    FuncFiles.Delete(updateFolder + nameUpdateInfo);
                    downloadFileName = nameUpdateInfo;
                    downloadFileType = "CheckU";
                    client_DownloadProgressStart();
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void aboutU_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FuncParser.stringRead(updateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_discription"));
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonUpdateCP_Click(object sender, EventArgs e)
        {
            stopDownload = true;
            EnableDisableButtons();
            FuncFiles.Delete(updateFolder + nameControlPanel);
            downloadFileName = nameControlPanel;
            downloadFileType = "UpdateCP";
            client_DownloadProgressStart();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void EnableDisableButtons()
        {
            if (updatesFound)
            {
                if (stopDownload)
                {
                    comboBox1.Enabled = false;
                    buttonAboutU.Enabled = false;
                    buttonCvsU.Text = "Стоп";
                }
                else
                {
                    comboBox1.Enabled = true;
                    buttonAboutU.Enabled = true;
                    label5.Text = "Размер: " + FuncParser.convertFileSize(FuncParser.intRead(updateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_filesize"));
                    if (updateInstall)
                    {
                        buttonCvsU.Enabled = false;
                        buttonCvsU.Text = "Установлено";
                    }
                    else
                    {
                        buttonCvsU.Enabled = true;
                        buttonCvsU.Text = "Обновить";
                    }
                }
            }
            else
            {
                comboBox1.Enabled = false;
                buttonAboutU.Enabled = false;
                label5.Text = "";
                if (stopDownload)
                {
                    buttonCvsU.Text = "Стоп";
                }
                else
                {
                    buttonCvsU.Text = "Проверить";
                }
            }
            if (updatesCPFound)
            {
                if (stopDownload)
                {
                    buttonUpdateCP.Enabled = false;
                    buttonUpdateCP.Text = "В процессе...";
                }
                else
                {
                    buttonUpdateCP.Enabled = true;
                    buttonUpdateCP.Text = "Обновить";
                }
            }
            else
            {
                buttonUpdateCP.Enabled = false;
                buttonUpdateCP.Text = "Нет обновления";
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void client_DownloadProgressStart()
        {
            if (FuncMisc.Ping(nameHostName + nameDLFolderHost + downloadFileName))
            {
                FuncFiles.CreatDirectory(updateFolder);
                client.DownloadFileAsync(new Uri(nameHostName + nameDLFolderHost + downloadFileName), updateFolder + downloadFileName);
            }
            else
            {
                stopDownload = false;
                EnableDisableButtons();
                MessageBox.Show("Нет доступа к: " + nameHostName + nameDLFolderHost + downloadFileName);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (stopDownload)
            {
                if (File.Exists(updateFolder + nameUpdateInfo))
                {
                    if (downloadFileType == "CheckU")
                    {
                        int CountComboBox = FuncParser.intRead(updateFolder + nameUpdateInfo, "General", "numbers_files_update");
                        if (CountComboBox > 0)
                        {
                            for (int i = 0; i < CountComboBox; i++)
                            {
                                comboBox1.Items.Add("");
                                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                            }
                            comboBox1.SelectedIndex = 0;
                            updatesFound = true;
                            label4.Text = CountComboBox.ToString();
                        }
                        else
                        {
                            updatesFound = false;
                            label4.Text = "Нет обновлений";
                        }
                        string line = FuncParser.stringRead(updateFolder + nameUpdateInfo, "General", "version_control_panel");
                        if (line != null)
                        {
                            var result = new Version(FileVersionInfo.GetVersionInfo(Process.GetCurrentProcess().MainModule.FileName).ProductVersion).CompareTo(new Version(line));
                            if (result < 0)
                            {
                                updatesCPFound = true;
                            }
                            else
                            {
                                updatesCPFound = false;
                            }
                        }
                    }
                    if (downloadFileType == "UpdateG")
                    {
                        if (File.Exists(updateFolder + "file" + numberSelectFile + ".rar") && File.Exists(updateFolder + nameUpdateInfo) && File.Exists(FormMain.launcherFolder + "UnRAR.exe"))
                        {
                            if (new FileInfo(updateFolder + "file" + numberSelectFile + ".rar").Length == FuncParser.intRead(updateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_filesize"))
                            {
                                FuncMisc.UnPackRAR(updateFolder + "file" + numberSelectFile + ".rar");
                                if (File.Exists(updateFolder + "Update_" + numberSelectFile + ".bat"))
                                {
                                    Process.Start(updateFolder + "Update_" + numberSelectFile + ".bat");
                                }
                                FuncParser.iniWrite(FormMain.iniLauncher, "Updates", "Update_" + numberSelectFile + "_Version", FuncParser.stringRead(updateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_version"));
                                comboBox1_SelectedIndexChanged(this, new EventArgs());
                            }
                            else
                            {
                                MessageBox.Show("Скачанный файл не соответствует UpdateInfo. Повторите попытку.");
                                FuncFiles.Delete(updateFolder + "file" + numberSelectFile + ".rar");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Нет компонентов для установки обновления (файла обновления, UnRAR или UpdateInfo).");
                        }
                    }
                    if (downloadFileType == "UpdateCP")
                    {
                        string version1 = FileVersionInfo.GetVersionInfo(updateFolder + nameControlPanel).ProductVersion;
                        if (version1 == FuncParser.stringRead(updateFolder + nameUpdateInfo, "General", "version_control_panel"))
                        {
                            StreamWriter writer = new StreamWriter(FormMain.launcherFolder + "Update.bat");
                            writer.WriteLine("@Echo off");
                            writer.WriteLine("mode con:cols=50 lines=10");
                            writer.WriteLine("color 0E");
                            writer.WriteLine("cd %~dp0 >nul 2>nul");
                            writer.WriteLine("SET CP_S=" + FormMain.launcherFolder + nameControlPanel);
                            writer.WriteLine("SET CP_U=" + updateFolder + nameControlPanel);
                            writer.WriteLine("Echo Please Wait 5 second before start update.");
                            writer.WriteLine("TIMEOUT /T 2 /NOBREAK > nul");
                            writer.WriteLine("IF EXIST \"%CP_U%\" (");
                            writer.WriteLine("Echo -Update file found.");
                            writer.WriteLine("TIMEOUT /T 1 /NOBREAK > nul");
                            writer.WriteLine("Echo -Deleted old file control panel.");
                            writer.WriteLine("del \"%CP_S%\" /Q >nul 2>nul");
                            writer.WriteLine("TIMEOUT /T 1 /NOBREAK > nul");
                            writer.WriteLine("Echo -Trying move new file control panel.");
                            writer.WriteLine("move /Y \"%CP_U%\" \"%CP_S%\" >nul 2>nul");
                            writer.WriteLine("TIMEOUT /T 1 /NOBREAK > nul");
                            writer.WriteLine("Echo -Expectation launching new control panel.");
                            writer.WriteLine("start \"Run new file\" \"%CP_S%\" >nul 2>nul");
                            writer.WriteLine(") else (");
                            writer.WriteLine("Echo -Update file not found...");
                            writer.WriteLine("TIMEOUT /T 5 /NOBREAK > nul");
                            writer.WriteLine(")");
                            writer.WriteLine("Echo -Ready. Closing.");
                            writer.WriteLine("TIMEOUT /T 2 /NOBREAK > nul");
                            writer.WriteLine("del \"" + FormMain.launcherFolder + "Update.bat\" /Q >nul 2>nul");
                            writer.Close();
                            Process.Start(FormMain.launcherFolder + "Update.bat");
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show("Версия скачанного файла не совпадает с UpdateInfo.");
                            FuncFiles.Delete(updateFolder + nameControlPanel);
                        }
                    }
                }
                else
                {
                    updatesFound = false;
                    updatesCPFound = false;
                }
            }
            stopDownload = false;
            progressBar1.Value = 0;
            EnableDisableButtons();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numberSelectFile = comboBox1.SelectedIndex + 1;
            double UpdateVersion1 = FuncParser.doubleRead(updateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_version");
            if (UpdateVersion1 != -1)
            {
                double UpdateVersion2 = FuncParser.doubleRead(FormMain.iniLauncher, "Updates", "Update_" + numberSelectFile + "_Version");
                if (UpdateVersion1 != -1)
                {
                    if (UpdateVersion1 <= UpdateVersion2)
                    {
                        updateInstall = true;
                        SetComboBoxItem("Установлено / ");
                    }
                    else
                    {
                        updateInstall = false;
                        SetComboBoxItem("Обновление / ");
                    }
                }
                else
                {
                    updateInstall = false;
                    SetComboBoxItem("Обновление / ");
                }
            }
            else
            {
                updateInstall = true;
                SetComboBoxItem("Ошибка / ");
            }
            EnableDisableButtons();
        }
        private void SetComboBoxItem(string installed)
        {
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            comboBox1.Items[comboBox1.SelectedIndex] = installed + FuncParser.stringRead(updateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file");
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonClose_Click(object sender, EventArgs e)
        {
            client.DownloadProgressChanged -= new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted -= new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.CancelAsync();
            FuncFiles.Delete(updateFolder + nameControlPanel);
            FuncFiles.Delete(updateFolder + nameUpdateInfo);
            Dispose();
        }
    }
}