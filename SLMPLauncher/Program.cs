using System;
using System.IO;
using System.Windows.Forms;

namespace SLMPLauncher
{
    internal sealed class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(FormMain.launcherFolder);
            if (!File.Exists(FormMain.gameFolder + "TESV.exe") || !File.Exists(FormMain.gameFolder + "SKYRIM.exe") || !File.Exists(FormMain.gameFolder + @"Data\GameComm.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameMesh1.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameMesh2.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameMesh3.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameText1.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameText2.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameText3.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameText4.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameText5.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameText6.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameText7.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameText8.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameVoice1.bsa") || !File.Exists(FormMain.gameFolder + @"Data\GameVoice2.bsa") || !File.Exists(FormMain.gameFolder + @"Data\Dawnguard.esm") || !File.Exists(FormMain.gameFolder + @"Data\Dragonborn.esm") || !File.Exists(FormMain.gameFolder + @"Data\HearthFires.esm") || !File.Exists(FormMain.gameFolder + @"Data\Skyrim.esm") || !File.Exists(FormMain.gameFolder + @"Data\Update.esm") || !File.Exists(FormMain.gameFolder + @"Data\Unofficial Skyrim Legendary Edition Patch.bsa") || !File.Exists(FormMain.gameFolder + @"Data\Unofficial Skyrim Legendary Edition Patch.esp"))
            {
                MessageBox.Show("Не найдены ресурсы игры. Панель управления должна находиться по адресу:" + Environment.NewLine + @"Директория Игры\Skyrim\");
                return;
            }
            if (args != null)
            {
                foreach (string line in args)
                {
                    if (line.StartsWith("-s="))
                    {
                        FormMain.startWithGame = line.Remove(0, 3);
                    }
                    else if (line.StartsWith("-w="))
                    {
                        FormMain.waitBeforeStart = line.Remove(0, 3);
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}