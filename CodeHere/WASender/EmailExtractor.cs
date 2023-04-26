using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace WASender
{
    public class EmailExtractor
    {
        private static string FindCorrectEmail(List<string[]> Items)
        {
            foreach (string[] current in Items)
            {
                if (current[0].IndexOf("@mail.com", StringComparison.InvariantCultureIgnoreCase) != -1 || current[0].IndexOf("@email.com", StringComparison.InvariantCultureIgnoreCase) != -1 || current[0].IndexOf("example", StringComparison.InvariantCultureIgnoreCase) != -1 || current[0].IndexOf(".jpg", StringComparison.InvariantCultureIgnoreCase) != -1 || current[0].IndexOf(".gif", StringComparison.InvariantCultureIgnoreCase) != -1 || current[0].IndexOf("esempio", StringComparison.InvariantCultureIgnoreCase) != -1 || current[0].IndexOf("javascript", StringComparison.InvariantCultureIgnoreCase) != -1 || current[0].IndexOf(".png", StringComparison.InvariantCultureIgnoreCase) != -1 || current[0].IndexOf(".io", StringComparison.InvariantCultureIgnoreCase) != -1 || current[0].IndexOf(".tri", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    continue;
                }
                return current[0].Replace("mailto:", "");
            }
            return "";
        }

        public static string GetEmail(string Url, string[] ContactPageUrls)
        {
            string str = "";
            int num = 5000;
            bool flag = false;
            Timer timer = new Timer
            {
                Interval = num
            };
            timer.Elapsed += delegate
            {
                flag = true;
            };
            timer.Start();
            if (Url == null || Url == "")
            {
                return str;
            }
            Url = Url.Replace("https:", "http:");
            string str2 = HTTPScraper.ClearString(HTTPScraper.GetPage(Url));
            List<string[]> strArrays = HTTPScraper.ParseHTML(str2, "((?<withsubject>(?<=mailto\\:)([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(?=\\?))|(?<withoutsubject>(?<=mailto\\:)([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(?=\")))");
            if (strArrays.Count <= 0)
            {
                string str3 = "";
                strArrays = HTTPScraper.ParseHTML(str2, "href=(\"|'|)(.*?)(\"|'|)[>|\\s]");
                foreach (string[] strArrays2 in strArrays)
                {
                    foreach (string str4 in ContactPageUrls)
                    {
                        if (strArrays2[2].IndexOf(str4, StringComparison.InvariantCultureIgnoreCase) < 0)
                        {
                            continue;
                        }
                        str3 = strArrays2[2];
                        if (str3.IndexOf("http") != -1)
                        {
                            string str5 = Url.Replace("http://", "").Replace("https://", "").Replace("www.", "");
                            if (str3.IndexOf(str5.Split('/')[0]) == -1)
                            {
                                str3 = "";
                            }
                        }
                        else
                        {
                            str3 = ((str3[0] != '/') ? ("http://" + Url.TrimEnd('/').Replace("http://", "") + "/" + str3) : ("http://" + Url.TrimEnd('/') + str3));
                        }
                        if (str3 != "")
                        {
                            str2 = HTTPScraper.ClearString(HTTPScraper.GetPage(str3));
                            strArrays = HTTPScraper.ParseHTML(str2, "(mailto\\:|)([\\w\\.\\-]+)@((([\\-\\w]+\\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\\.){3}[0-9]{1,3}))");
                            if (strArrays.Count > 0)
                            {
                                str = FindCorrectEmail(strArrays).Replace("mailto:", "");
                                goto end_IL_0259;
                            }
                        }
                    }
                    continue;
                end_IL_0259:
                    break;
                }
            }
            else
            {
                str = FindCorrectEmail(strArrays).Replace("mailto:", "");
            }
            return str;
        }


    }
}
