using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WASender.Models;

namespace WASender
{
    public static class ProjectCommon
    {
        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");
        public static void injectWapi(IWebDriver driver)
        {
            WAPIHelper.injectWapi(driver, Config.WAPIFolderFolder());
        }

        public static List<IndividualContacts> getContactLists()
        {
            List<IndividualContacts> contacts = new List<IndividualContacts>();
            string fileData = File.ReadAllText(fileSaves + "\\" + "IndividualContacts.json");
            contacts = JsonConvert.DeserializeObject<List<IndividualContacts>>(fileData);
            return contacts;
        }

        public static List<GroupContact> getGroupLists()
        {
            List<GroupContact> contacts = new List<GroupContact>();
            string fileData = File.ReadAllText(fileSaves + "\\" + "Groups.json");
            contacts = JsonConvert.DeserializeObject<List<GroupContact>>(fileData);
            return contacts;
        }

        public static List<GroupContact> getGroupLinks()
        {
            List<GroupContact> contacts = new List<GroupContact>();
            string fileData = File.ReadAllText(fileSaves + "\\" + "GroupLinks.json");
            contacts = JsonConvert.DeserializeObject<List<GroupContact>>(fileData);
            return contacts;
        }

        public static string ReplaceKeyMarker(string text, List<ParameterModel> parameterModelList = null)
        {
            var messages = text.Split('\n');
            string NewMessage = "";

            foreach (var m in messages)
            {
                if (m != "")
                {
                    string MsgLine = m;

                    // Check For KeyMarker
                    if (m.Contains("{{ KEY :"))
                    {
                        string str = Utils.ExtractBetweenTwoStrings(m, "{{ KEY :", "}}", false, false);
                        var Keysplitter = str.Split('|');
                        string randomKey = Keysplitter[Utils.getRandom(0, Keysplitter.Length - 1)];
                        MsgLine = m.Replace("{{ KEY :" + str + "}}", randomKey);
                    }
                    // Check {{ RANDOM }}
                    if (MsgLine.Contains("{{ RANDOM }}"))
                    {
                        string rand = Utils.getRandom(10000, 50000).ToString();
                        MsgLine = MsgLine.Replace("{{ RANDOM }}", rand);
                    }
                    if (MsgLine.Contains("{{sys.date}}"))
                    {
                        string rand = Utils.getRandom(10000, 50000).ToString();
                        MsgLine = MsgLine.Replace("{{sys.date}}", Utils.exactDatetime());
                    }

                    if (parameterModelList != null)
                    {
                        foreach (var param in parameterModelList)
                        {
                            if (MsgLine.ToLower().Contains("{{" + param.ParameterName.ToLower() + "}}"))
                            {
                                MsgLine = MsgLine.Replace("{{" + param.ParameterName + "}}", param.ParameterValue);
                            }
                        }
                    }

                    MsgLine = MsgLine + "\n";
                    NewMessage = NewMessage + MsgLine;
                }
            }
            return NewMessage;
        }
    }
}
