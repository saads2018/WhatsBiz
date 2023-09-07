using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WASender
{
    public partial class MainUC : UserControl
    {
        string profileName;
        string ProfileId;
        public MainUC(string _ProfileId)
        {
            ProfileId = _ProfileId;
            InitializeComponent();
        }

        private void MainUC_Load(object sender, EventArgs e)
        {
            try
            {
                string ProfilesFolderPath = Config.GetProfilesFolderPath();
                profileName = ProfilesFolderPath + "\\" + ProfileId;
                if (!Directory.Exists(profileName))
                {
                    Directory.CreateDirectory(profileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            InitBrowser();
        }

        public async void InitBrowser()
        {
            await initizated();
            webView21.CoreWebView2.Navigate("https://web.whatsapp.com/");
        }

        private async Task initizated()
        {
            try
            {
                webView21.CreationProperties = new Microsoft.Web.WebView2.WinForms.CoreWebView2CreationProperties();
                webView21.CreationProperties.UserDataFolder = profileName;
                await webView21.EnsureCoreWebView2Async(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
