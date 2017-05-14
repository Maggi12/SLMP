using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public class FuncMisc
    {
        public static bool RefreshButton(Button button, string file, string section, string parameter, string value, bool invert)
        {
            if (File.Exists(file))
            {
                string readString = FuncParser.stringRead(file, section, parameter);
                button.Enabled = true;
                if (value != null)
                {
                    if (readString == value)
                    {
                        button.BackgroundImage = Properties.Resources.buttonToggleOn;
                        return true;
                    }
                    else
                    {
                        button.BackgroundImage = Properties.Resources.buttonToggleOff;
                        return false;
                    }
                }
                if (readString == "1" || readString == "true")
                {
                    if (invert)
                    {
                        button.BackgroundImage = Properties.Resources.buttonToggleOff;
                        return false;
                    }
                    else
                    {
                        button.BackgroundImage = Properties.Resources.buttonToggleOn;
                        return true;
                    }
                }
                else if (readString == "0" || readString == "false")
                {
                    if (invert)
                    {
                        button.BackgroundImage = Properties.Resources.buttonToggleOn;
                        return true;
                    }
                    else
                    {
                        button.BackgroundImage = Properties.Resources.buttonToggleOff;
                        return false;
                    }
                }
                else
                {
                    button.BackgroundImage = Properties.Resources.buttonToggleOff;
                    return false;
                }
            }
            else
            {
                button.BackgroundImage = Properties.Resources.buttonToggleDisable;
                button.Enabled = false;
                return false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void RefreshTrackBar(TrackBar trackbar, string file, string section, string parameter, int division, Label label)
        {
            if (File.Exists(file))
            {
                trackbar.Enabled = true;
                int Max = trackbar.Maximum;
                int Min = trackbar.Minimum;
                int readINT = FuncParser.intRead(file, section, parameter);
                if (division != -1)
                {
                    readINT = readINT / division;
                }
                if (readINT >= Min && readINT <= Max)
                {
                    if (division != -1)
                    {
                        label.Text = (readINT * division).ToString();
                    }
                    else
                    {
                        label.Text = readINT.ToString();
                    }
                    trackbar.Value = readINT;
                }
                else
                {
                    label.Text = "N/A";
                }
            }
            else
            {
                label.Text = "N/A";
                trackbar.Enabled = false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void ToggleButtons(Form form, bool action)
        {
            foreach (Control line in form.Controls)
            {
                Button buttons = line as Button;
                if (buttons != null)
                {
                    buttons.Enabled = action;
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void LabelsTextColor(Form form, Color color, Color trackbar)
        {
            foreach (Control line in form.Controls)
            {
                if (line is Label)
                {
                    line.ForeColor = color;
                }
                if (line is TrackBar)
                {
                    line.BackColor = trackbar;
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void UnPackRAR(string path)
        {
            Directory.SetCurrentDirectory(FormMain.launcherFolder);
            if (File.Exists(path) && File.Exists(FormMain.launcherFolder + "UnRAR.exe"))
            {
                Process UnPack = new Process();
                UnPack.StartInfo.FileName = FormMain.launcherFolder + "UnRAR.exe";
                UnPack.StartInfo.Arguments = " x -y \"" + path + "\"" + " " + "\"" + FormMain.gameFolder + "\"";
                try
                {
                    UnPack.Start();
                }
                catch
                {
                    MessageBox.Show("Не удалось запустить файл: " + UnPack.StartInfo.FileName);
                }
                UnPack.WaitForExit(30000);
            }
            else
            {
                MessageBox.Show("Не удалось распаковать: " + path);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void RunProcess(string path, string arg, EventHandler onexit, Form form)
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(path));
            Process Run = new Process();
            Run.StartInfo.FileName = path;
            Run.StartInfo.Arguments = arg;
            if (onexit != null)
            {
                Run.EnableRaisingEvents = true;
                Run.Exited += onexit;
            }
            try
            {
                Run.Start();
            }
            catch
            {
                MessageBox.Show("Не удалось запустить файл: " + Run.StartInfo.FileName);
                if (onexit != null)
                {
                    onexit(form, new EventArgs());
                }
            }
            Directory.SetCurrentDirectory(FormMain.launcherFolder);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static bool Ping(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                request.Timeout = 5000;
                request.AllowAutoRedirect = false;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }
    }
}