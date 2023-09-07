using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WASender
{
    static class Program
    {
        public static int resWidth = Screen.PrimaryScreen.Bounds.Width;
        public static int resHeight = Screen.PrimaryScreen.Bounds.Height;
        public static int resScale = (int) (100 * resWidth / SystemParameters.PrimaryScreenWidth);  

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            createSaveFiles();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms. Application.SetCompatibleTextRenderingDefault(false);
            /// Application.Run(new GMapExtractor());
            /// Application.Run(new GeneralSettings());
            /// //Application.Run(new GroupGenerator());
            // Application.Run(new gpttest());r
            System.Windows.Forms.Application.Run(new MainNavPage());
            //Application.Run(new GroupFinder());
        }

        private static void createSaveFiles()
        {
            int x = resScale;
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
