using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WASender.Models;

namespace WASender
{
    public class Config
    {
        public static bool IsDemoMode = false;

        public static readonly string WaSenderFolderName = "WaSender";
        public static readonly string KeyMarkersFile = "KeyMarkers.txt";
        public static readonly string GeneralSettingsFile = "GeneralSettings.txt";
        public static readonly string ChromeProfileFolder = "ChromeProfile";
        public static readonly string ChromeProfileBotFolder = "ChromeProfileBot";
        public static readonly string ChromeProfileGMAPFolder = "ChromeProfileGMAP";
        public static readonly string ActivationFile = "Activation.txt";
        public static readonly string ProcessLoggerFolderName = "ProcessLogger";
        public static readonly string ErrorLoggerFolderName = "ErrorLogger";
        public static readonly string TempFolderName = "temp";
        public static readonly string MasterKeyName = "masterkey";
        public static readonly string MasterKeyValue = "eyJBY3RpdmF0aW9uQ29kZSI6ImJXRnpkR1Z5YTJWNSIsInZhbGlkRGF5cyI6MzY1LCJTdGFydERhdGUiOiIyMDIyLTA2LTIwVDIwOjM3OjMxLjQ1Mjk4MjgrMDU6MzAiLCJFbmREYXRlIjoiMjAyMy0wNi0yMFQyMDozNzozMS40NTI5ODI4KzA1OjMwIn0=";
        public static readonly string SysFilesFolder = "SysFiles";
        public static readonly string ChromeDriverFolder = SysFilesFolder;
        public static readonly string WAPIFolder = SysFilesFolder;

        public static readonly int SendingType = 1;
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static GeneralSettingsModel GetSettings()
        {
            String GetGeneralSettingsFilePath = Config.GetGeneralSettingsFilePath();
            GeneralSettingsModel generalSettingsModel;
            try
            {

                if (File.Exists(GetGeneralSettingsFilePath))
                {
                    string json = File.ReadAllText(GetGeneralSettingsFilePath);
                    generalSettingsModel = JsonConvert.DeserializeObject<GeneralSettingsModel>(json);
                    if (generalSettingsModel == null)
                    {
                        generalSettingsModel = new GeneralSettingsModel();
                    }
                    return generalSettingsModel;
                }
                else
                {
                    return new GeneralSettingsModel();
                }
            }
            catch (Exception ex)
            {
                return new GeneralSettingsModel();
            }
        }


        public static DateTime? getEndDate()
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String keyMarkersTxtFilepath = Path.Combine(WaSenderFolderpath, Config.ActivationFile);
            if (File.Exists(keyMarkersTxtFilepath))
            {
                string DecodedText = File.ReadAllText(keyMarkersTxtFilepath);
                string encodedJson = Config.Base64Decode(DecodedText);

                try
                {
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<WASender.Models.ActivationModel>(encodedJson);

                    string keyCode = Base64Decode(obj.ActivationCode);
                    return obj.EndDate;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }

        public static bool IsProductActive()
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String keyMarkersTxtFilepath = Path.Combine(WaSenderFolderpath, Config.ActivationFile);
            if (File.Exists(keyMarkersTxtFilepath))
            {
                string DecodedText = File.ReadAllText(keyMarkersTxtFilepath);
                string encodedJson = Config.Base64Decode(DecodedText);

                try
                {
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<WASender.Models.ActivationModel>(encodedJson);

                    string keyCode = Base64Decode(obj.ActivationCode);

                    // if (Security.FingerPrint.Value() == keyCode || keyCode == "masterkey")
                    {

                        if (obj.EndDate <= DateTime.Now)
                        {
                            return false;
                        }
                        return true;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return false;
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }


        public static string GetTempFolderPath()
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String returnableFolder = Path.Combine(WaSenderFolderpath, Config.TempFolderName);

            if (!Directory.Exists(returnableFolder))
            {
                Directory.CreateDirectory(returnableFolder);
            }

            return returnableFolder;
        }

        public static void KillChromeDriverProcess()
        {
            if (Utils.Driver != null)
            {
                try
                {
                    Utils.Driver.Close();
                    Utils.Driver.Dispose();
                    Utils.Driver.Quit();
                    Utils.Driver = null;
                }
                catch (Exception ex)
                {
                }
            }
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                try
                {
                    process.Kill();
                }
                catch (Exception ex)
                {

                }
            }


        }

        public static string GetProcessLoggerFolderPath()
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String returnableFolder = Path.Combine(WaSenderFolderpath, Config.ProcessLoggerFolderName);

            if (!Directory.Exists(returnableFolder))
            {
                Directory.CreateDirectory(returnableFolder);
            }

            return returnableFolder;
        }


        public static void ActivateProduct(string ActivationKey)
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String keyMarkersTxtFilepath = Path.Combine(WaSenderFolderpath, Config.ActivationFile);
            if (!File.Exists(keyMarkersTxtFilepath))
            {
                File.WriteAllText(keyMarkersTxtFilepath, ActivationKey);
            }
            else
            {
                File.Delete(keyMarkersTxtFilepath);
                File.WriteAllText(keyMarkersTxtFilepath, ActivationKey);
            }
        }

        public static string GetKeyMarkersFilePath()
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String keyMarkersTxtFilepath = Path.Combine(WaSenderFolderpath, Config.KeyMarkersFile);
            return keyMarkersTxtFilepath;
        }

        public static string GetGeneralSettingsFilePath()
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String keyMarkersTxtFilepath = Path.Combine(WaSenderFolderpath, Config.GeneralSettingsFile);
            return keyMarkersTxtFilepath;
        }

        public static string GetChromeProfileFolder()
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String keyMarkersTxtFilepath = Path.Combine(WaSenderFolderpath, Config.ChromeProfileFolder);
            if (!Directory.Exists(keyMarkersTxtFilepath))
            {
                Directory.CreateDirectory(keyMarkersTxtFilepath);
            }
            return keyMarkersTxtFilepath;
        }
        //ChromeDriverFolder
        public static string GetChromeDriverFolder()
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String keyMarkersTxtFilepath = Path.Combine(WaSenderFolderpath, Config.ChromeDriverFolder);
            if (!Directory.Exists(keyMarkersTxtFilepath))
            {
                Directory.CreateDirectory(keyMarkersTxtFilepath);
            }
            if (!File.Exists(keyMarkersTxtFilepath + "\\chromedriver.exe"))
            {
                File.Copy("chromedriver.exe", keyMarkersTxtFilepath + "\\chromedriver.exe");
            }
            else
            {
                DateTime ftime = File.GetLastWriteTime(keyMarkersTxtFilepath + "\\chromedriver.exe");
                DateTime ftime2 = File.GetLastWriteTime("chromedriver.exe");
                if (ftime < ftime2)
                {
                    File.Copy("chromedriver.exe", keyMarkersTxtFilepath + "\\chromedriver.exe", true);
                }
            }
            return keyMarkersTxtFilepath;
        }

        //WAPIFolder

        public static string WAPIFolderFolder()
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String keyMarkersTxtFilepath = Path.Combine(WaSenderFolderpath, Config.ChromeDriverFolder);
            if (!Directory.Exists(keyMarkersTxtFilepath))
            {
                Directory.CreateDirectory(keyMarkersTxtFilepath);
            }
            if (!File.Exists(keyMarkersTxtFilepath + "\\chatTemplate.csv"))
            {
                File.Copy("chatTemplate.csv", keyMarkersTxtFilepath + "\\chatTemplate.csv", true);
            }
            else
            {
                DateTime ftime = File.GetLastWriteTime(keyMarkersTxtFilepath + "\\chatTemplate.csv");
                DateTime ftime2 = File.GetLastWriteTime("chatTemplate.csv");
                if (ftime < ftime2)
                {
                    File.Copy("chatTemplate.csv", keyMarkersTxtFilepath + "\\chatTemplate.csv", true);
                }
            }


            if (!File.Exists(keyMarkersTxtFilepath + "\\wapi.js"))
            {
                File.Copy("wapi.js", keyMarkersTxtFilepath + "\\wapi.js", true);
            }
            return keyMarkersTxtFilepath;
        }

        public static string GetChromeProfileFolderBot()
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String keyMarkersTxtFilepath = Path.Combine(WaSenderFolderpath, Config.ChromeProfileBotFolder);
            if (!Directory.Exists(keyMarkersTxtFilepath))
            {
                Directory.CreateDirectory(keyMarkersTxtFilepath);
            }
            return keyMarkersTxtFilepath;
        }

        public static string GetChromeProfileFolderGMAP()
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            String WaSenderFolderpath = Path.Combine(FolderPath, Config.WaSenderFolderName);
            if (!Directory.Exists(WaSenderFolderpath))
            {
                Directory.CreateDirectory(WaSenderFolderpath);
            }
            String keyMarkersTxtFilepath = Path.Combine(WaSenderFolderpath, Config.ChromeProfileGMAPFolder);
            if (!Directory.Exists(keyMarkersTxtFilepath))
            {
                Directory.CreateDirectory(keyMarkersTxtFilepath);
            }
            return keyMarkersTxtFilepath;
        }

        public static ChromeOptions GetChromeOptionsGMAP()
        {
            ChromeOptions options = new ChromeOptions();


            String GetGeneralSettingsFilePath = Config.GetGeneralSettingsFilePath();

            if (File.Exists(GetGeneralSettingsFilePath))
            {
                string json = File.ReadAllText(GetGeneralSettingsFilePath);
                GeneralSettingsModel generalSettingsModel = JsonConvert.DeserializeObject<GeneralSettingsModel>(json);
                try
                {
                    if (generalSettingsModel.ChromeProfilePath != null && generalSettingsModel.ChromeProfilePath != "")
                    {
                        options.BinaryLocation = generalSettingsModel.ChromeProfilePath + "\\chrome.exe";
                    }
                }
                catch (Exception ex)
                {

                }
            }

            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddArgument("user-data-dir=" + Config.GetChromeProfileFolderGMAP());
            return options;
        }
        public static ChromeOptions GetChromeOptionsBot()
        {
            ChromeOptions options = new ChromeOptions();


            String GetGeneralSettingsFilePath = Config.GetGeneralSettingsFilePath();

            if (File.Exists(GetGeneralSettingsFilePath))
            {
                string json = File.ReadAllText(GetGeneralSettingsFilePath);
                GeneralSettingsModel generalSettingsModel = JsonConvert.DeserializeObject<GeneralSettingsModel>(json);
                try
                {
                    if (generalSettingsModel.ChromeProfilePath != null && generalSettingsModel.ChromeProfilePath != "")
                    {
                        options.BinaryLocation = generalSettingsModel.ChromeProfilePath + "\\chrome.exe";
                    }
                }
                catch (Exception ex)
                {

                }
            }

            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddArgument("user-data-dir=" + Config.GetChromeProfileFolderBot());
            return options;
        }



        public static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();


            String GetGeneralSettingsFilePath = Config.GetGeneralSettingsFilePath();

            if (File.Exists(GetGeneralSettingsFilePath))
            {
                string json = File.ReadAllText(GetGeneralSettingsFilePath);
                GeneralSettingsModel generalSettingsModel = JsonConvert.DeserializeObject<GeneralSettingsModel>(json);
                try
                {
                    
                    if (generalSettingsModel.ChromeProfilePath != null && generalSettingsModel.ChromeProfilePath != "")
                    {
                        options.BinaryLocation = generalSettingsModel.ChromeProfilePath + "\\chrome.exe";
                    }
                }
                catch (Exception ex)
                {

                }
            }

            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddArgument("user-data-dir=" + Config.GetChromeProfileFolder());
            return options;
        }

        public static ChromeOptions GetChromeOptionsMin()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);
            return options;
        }

    }
}
