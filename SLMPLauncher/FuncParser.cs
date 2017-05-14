using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public class FuncParser
    {
        static List<string> cacheFile = new List<string>();
        static int startIndex = -1;
        static int enbIndex = -1;
        static int lineIndex = -1;
        static bool blockClearEK = false;
        static bool blockClearSR = false;
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private static bool sectionRange(string path, string section)
        {
            startIndex = -1;
            enbIndex = -1;
            if (File.Exists(path))
            {
                bool find = false;
                cacheFile = new List<string>(File.ReadAllLines(path).ToList());
                for (int i = 0; i < cacheFile.Count; i++)
                {
                    if (find && enbIndex == -1)
                    {
                        if (cacheFile[i].StartsWith("["))
                        {
                            if (cacheFile[i].Contains("]"))
                            {
                                for (int y = i - 1; y >= startIndex; y--)
                                {
                                    if (cacheFile[y].Length > 0)
                                    {
                                        enbIndex = y;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    if (!find)
                    {
                        if (cacheFile[i].StartsWith("["))
                        {
                            if (cacheFile[i] == "[" + section + "]")
                            {
                                find = true;
                                startIndex = i;
                            }
                        }
                    }
                }
                if (find && enbIndex == -1)
                {
                    for (int i = cacheFile.Count - 1; i >= 0; i--)
                    {
                        if (cacheFile[i].Length > 0)
                        {
                            enbIndex = i;
                            break;
                        }
                    }
                }
                if (find)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static bool keyExists(string path, string section, string key)
        {
            lineIndex = -1;
            bool find = false;
            if (sectionRange(path, section) && startIndex != -1 && enbIndex != -1 && cacheFile.Count > enbIndex && startIndex != enbIndex)
            {
                List<string> linesRange = new List<string>(cacheFile.Skip(startIndex + 1).Take((enbIndex - startIndex)).ToList());
                for (int i = 0; i < linesRange.Count; i++)
                {
                    if (linesRange[i].StartsWith(key + "="))
                    {
                        find = true;
                        lineIndex = startIndex + 1 + i;
                        break;
                    }
                }
                linesRange.Clear();
            }
            if (!blockClearEK)
            {
                cacheFile.Clear();
            }
            if (find)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static string stringRead(string path, string section, string key)
        {
            string outString = null;
            blockClearEK = true;
            if (keyExists(path, section, key))
            {
                outString = cacheFile[lineIndex].Remove(0, cacheFile[lineIndex].IndexOf('=') + 1);
                if (outString.Length == 0)
                {
                    outString = null;
                }
            }
            blockClearEK = false;
            if (!blockClearSR)
            {
                cacheFile.Clear();
            }
            return outString;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private static void writeToFile(string path)
        {
            try
            {
                File.WriteAllLines(path, cacheFile);
            }
            catch
            {
                MessageBox.Show("Не удалось записать файл: " + path);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void iniWrite(string path, string section, string key, string value)
        {
            bool readyToWrite = false;
            blockClearSR = true;
            string line = stringRead(path, section, key);
            blockClearSR = false;
            if (line != null)
            {
                if (line != value)
                {
                    cacheFile[lineIndex] = key + "=" + value;
                    readyToWrite = true;
                }
            }
            else
            {
                if (startIndex != -1 && enbIndex != -1)
                {
                    cacheFile[enbIndex] = cacheFile[enbIndex] + Environment.NewLine + key + "=" + value;
                    readyToWrite = true;
                }
                else
                {
                    if (File.Exists(path) && cacheFile.Count != 0)
                    {
                        for (int i = cacheFile.Count - 1; i >= 0; i--)
                        {
                            if (cacheFile[i].Length > 0)
                            {
                                cacheFile[i] = cacheFile[i] + Environment.NewLine + Environment.NewLine + "[" + section + "]" + Environment.NewLine + key + "=" + value;
                                readyToWrite = true;
                                break;
                            }
                            else if (i != 0)
                            {
                                cacheFile.RemoveAt(i);
                            }
                            if (i == 0)
                            {
                                cacheFile[i] = "[" + section + "]" + Environment.NewLine + key + "=" + value;
                                readyToWrite = true;
                            }
                        }
                    }
                    else
                    {
                        File.AppendAllText(path, "[" + section + "]" + Environment.NewLine + key + "=" + value + Environment.NewLine);
                    }
                }
            }
            if (readyToWrite)
            {
                writeToFile(path);
            }
            cacheFile.Clear();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void iniDeleteKey(string path, string section, string key)
        {
            blockClearEK = true;
            if (keyExists(path, section, key))
            {
                cacheFile.RemoveAt(lineIndex);
                writeToFile(path);
            }
            blockClearEK = false;
            cacheFile.Clear();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void iniDeleteSection(string path, string section)
        {
            if (sectionRange(path, section))
            {
                cacheFile.RemoveRange(startIndex, enbIndex - startIndex + 1);
                writeToFile(path);
            }
            cacheFile.Clear();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static int intRead(string path, string section, string key)
        {
            int value = -1;
            string line = stringRead(path, section, key);
            if (line != null)
            {
                if (line.Contains("."))
                {
                    string EqualString = line.Remove(line.IndexOf('.'));
                    Int32.TryParse(EqualString, out value);
                }
                else
                {
                    Int32.TryParse(line, out value);
                }
            }
            return value;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static double doubleRead(string path, string section, string key)
        {
            double value = -1;
            string line = stringRead(path, section, key);
            if (line != null)
            {
                Double.TryParse(line, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
            }
            return value;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static int stringToInt(string input)
        {
            int value = -1;
            if (input.Contains("."))
            {
                string EqualString = input.Remove(input.IndexOf('.'));
                Int32.TryParse(EqualString, out value);
            }
            else
            {
                Int32.TryParse(input, out value);
            }
            return value;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static double stringToDouble(string input)
        {
            double value = -1;
            Double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
            return value;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static string convertFileSize(int input)
        {
            if (input > 1073741824)
            {
                return (input / 1024 / 1024 / 1024).ToString() + " GB";
            }
            else if (input > 1048576 && input < 1073741824)
            {
                return (input / 1024 / 1024).ToString() + " MB";
            }
            else if (input > 1024 && input < 1048576)
            {
                return (input / 1024).ToString() + " KB";
            }
            else if (input >= 0)
            {
                return input.ToString() + " B";
            }
            else
            {
                return "Ошибка";
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static bool listsCompare(List<string> list1, List<string> list2)
        {
            if (list1.Count() == list2.Count())
            {
                for (int i = 0; i < list1.Count() - 1; i++)
                {
                    if (list1[i] != list2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static List<string> parserESPESM(string file)
        {
            List<string> outString = new List<string>();
            if (File.Exists(file))
            {
                char[] charsSymbol = { ' ', '!', '\'', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?', '@', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '[', '\\', ']', '^', '_', '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '|', '}', '~' };
                byte[] bytesFile = new byte[5000];
                FileStream fs = File.OpenRead(file);
                fs.Read(bytesFile, 0, 5000);
                fs.Close();
                List<string> processing = new List<string>();
                processing.Add("");
                bool wordStart = false;
                for (int i = 0; i < bytesFile.Count(); i++)
                {
                    if (processing[processing.Count - 1] == "GRUP" || processing[processing.Count - 1] == "ONAM")
                    {
                        break;
                    }
                    if (bytesFile[i] >= 32 && bytesFile[i] <= 126)
                    {
                        if (!wordStart)
                        {
                            processing.Add(charsSymbol[bytesFile[i] - 32].ToString());
                            wordStart = true;
                        }
                        else
                        {
                            processing[processing.Count - 1] = processing[processing.Count - 1] + charsSymbol[bytesFile[i] - 32].ToString();
                        }
                    }
                    else
                    {
                        wordStart = false;
                    }
                }
                if (processing[1].Contains("TES4") && (processing[processing.Count - 1] == "GRUP" || processing[processing.Count - 1] == "ONAM"))
                {
                    for (int i = 0; i < processing.Count(); i++)
                    {
                        if (processing[i].Contains("MAST"))
                        {
                            if ((i + 1) < processing.Count())
                            {
                                if (processing[i + 1].Contains(".esp") || processing[i + 1].Contains(".esm"))
                                {
                                    outString.Add(processing[i + 1]);
                                }
                            }
                        }
                    }
                }
                processing.Clear();
            }
            return outString;
        }
        public static bool checkESM(string file)
        {
            if (File.Exists(file))
            {
                byte[] bytesFile = new byte[9];
                FileStream fs = File.OpenRead(file);
                fs.Read(bytesFile, 0, 9);
                fs.Close();
                if (bytesFile[8] == 1 || bytesFile[8] == 129)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}