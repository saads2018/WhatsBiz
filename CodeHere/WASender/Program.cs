using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WASender
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            createSaveFiles();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /// Application.Run(new GMapExtractor());
            /// Application.Run(new GeneralSettings());
            Application.Run(new MainNavPage());
            //Application.Run(new GroupFinder());
        }

        private static void createSaveFiles()
        {

            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            String fileSaves = Path.Combine(FolderPath, "fileSaves");

            if (!Directory.Exists(fileSaves))
            {
                Directory.CreateDirectory(fileSaves);
            }

            File.AppendAllText(fileSaves + "\\" + "Groups.json", "");
            File.AppendAllText(fileSaves + "\\" + "GroupSender.json", "");
            File.AppendAllText(fileSaves + "\\" + "IndividualContacts.json", "");
            File.AppendAllText(fileSaves + "\\" + "SingleSender.json", "");
            File.AppendAllText(fileSaves + "\\" + "GroupLinks.json", "");
            File.AppendAllText(fileSaves + "\\" + "AutoResponderLogs.json", "");
            File.AppendAllText(FolderPath + "\\" + "RulePause.json", "");
        }

    }
}
