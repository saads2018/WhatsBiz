using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WASender.enums;
using Timer = System.Windows.Forms.Timer;

namespace WASender
{
    public partial class GrabGroupLinks : MaterialForm
    {

        InitStatusEnum initStatusEnum;
        System.Windows.Forms.Timer timerInitChecker;
        System.Windows.Forms.Timer loading;
        IWebDriver driver;
        BackgroundWorker worker;
        CampaignStatusEnum campaignStatusEnum;
        WaSenderForm waSenderForm;
        MainNavPage mainNavPage;
        GroupContact importGroups;
        Panel p;

        public GrabGroupLinks(WaSenderForm _waSenderForm,MainNavPage mainNavPage,Panel p)
        {
            InitializeComponent();
            waSenderForm = _waSenderForm;
            this.mainNavPage = mainNavPage;
            this.p = p;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }
        private void ChangeInitStatus(InitStatusEnum _initStatus)
        {
            this.initStatusEnum = _initStatus;
            AutomationCommon.ChangeInitStatus(_initStatus, lblInitStatus);
        }

        private void init()
        {
            ChangeInitStatus(InitStatusEnum.NotInitialised);
        }



        private void checkQRScanDone()
        {
            timerInitChecker = new System.Windows.Forms.Timer();
            timerInitChecker.Interval = 1000;
            timerInitChecker.Tick += timerInitChecker_Tick;
            timerInitChecker.Start();
        }

        public void timerInitChecker_Tick(object sender, EventArgs e)
        {
            try
            {
                bool isElementDisplayed = AutomationCommon.IsElementPresent(By.ClassName("_1XkO3"), driver);
                if (isElementDisplayed == true)
                {
                    ChangeInitStatus(InitStatusEnum.Initialised);
                    timerInitChecker.Stop();
                    Activate();
                }
            }
            catch (Exception ex)
            {
                ChangeInitStatus(InitStatusEnum.Unable);
                timerInitChecker.Stop();
            }
        }


        List<string> chatNames;

        private void btnInitWA_Click(object sender, EventArgs e)
        {
            ChangeInitStatus(InitStatusEnum.Initialising);
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddExcludedArgument("enable-automation");
                options.AddAdditionalOption("useAutomationExtension", false);
                var chromeDriverService = ChromeDriverService.CreateDefaultService(Config.GetChromeDriverFolder());
                chromeDriverService.HideCommandPromptWindow = true;


                driver = new ChromeDriver(chromeDriverService, options);
                //driver = new ChromeDriver();
                driver.Url = "https://www.google.com/search?q=whatsapp+group+links&oq=whatsapp+group+links&aqs=chrome.0.69i59j0i433i512j0i512j0i457i512j0i402j69i60l3.2696j0j7&sourceid=chrome&ie=UTF-8";

               // checkQRScanDone();
                ChangeInitStatus(InitStatusEnum.Initialised);
            }
            catch (Exception ex)
            {
                ChangeInitStatus(InitStatusEnum.Unable);
                string ss = "";

                if (ex.Message.Contains("session not created"))
                {
                    DialogResult dr = MessageBox.Show("Your Chrome Driver and Google Chrome Version Is not same, Click 'Yes botton' to Update it from Settings ", "Error ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                    if (dr == DialogResult.Yes)
                    {
                        //System.Diagnostics.Process.Start("https://medium.com/fusionqa/selenium-webdriver-error-sessionnotcreatederror-session-not-created-this-version-of-7b3a8acd7072");
                        this.Hide();
                        GeneralSettings generalSettings = new GeneralSettings(this.mainNavPage);
                        generalSettings.ShowDialog();
                    }
                }
            }
        }

        private void GrabGroupLinks_Load(object sender, EventArgs e)
        {
            init();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.Text = Strings.GrabGroupLinks;
            this.materialLabel2.Text = Strings.Clickbellowbuttontoopenbrowser;
            this.label5.Text = Strings.Status;
/*            this.materialLabel5.Text = Strings.Navigatetoanywebsitewherelistedgrouplinkstheclickbellowbellowbuton;
*//*            this.materialButton1.Text = Strings.StartGrabbing;
*/            this.btnInitWA.Text = Strings.OpenBrowser;
        }

        public void Initiate()
        {
            if (initStatusEnum != InitStatusEnum.Initialised)
            {
                Utils.showAlert(Strings.PleasefollowStepNo1FirstInitialiseWhatsapp, Alerts.Alert.enmType.Error);
                return;
            }
            if (campaignStatusEnum != CampaignStatusEnum.Running)
            {
                chatNames = new List<string>();
                var links = driver.FindElements(By.XPath("//a[contains(@href,'https://chat.whatsapp.com/')]"));
                int globalCounter = 0;
                foreach (var item in links)
                {
                    try
                    {
                        if (Config.IsDemoMode == true)
                        {
                            if (globalCounter > 5)
                            {
                                Utils.showAlert("You can Extract only 5 Links in trial version", Alerts.Alert.enmType.Error);
                                break;
                            }
                        }
                        string Link = item.GetAttribute("href").ToString();
                        chatNames.Add(Link);
                        globalCounter++;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (links.Count() == 0)
                {
                    Utils.showAlert(Strings.NoGroupLinkfoundincurrentPage, Alerts.Alert.enmType.Error);
                }
                else
                {
                    String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                    String file = Path.Combine(FolderPath, "GroupLinks__" + Guid.NewGuid().ToString() + ".xlsx");
                    string NewFileName = file.ToString();

                    File.Copy("MemberListTemplate.xlsx", NewFileName, true);

                    var newFile = new FileInfo(NewFileName);
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    string fileData = File.ReadAllText(fileSaves + "\\" + "GroupLinks.json");

                    List<GroupContact> contacts = new List<GroupContact>();

                    if (!String.IsNullOrWhiteSpace(fileData))
                        contacts = JsonConvert.DeserializeObject<List<GroupContact>>(fileData);

                    GroupContact contacts1 = new GroupContact();
                    contacts1.ContactNames = new List<string>();
                    contacts1.GroupID = new List<string>();

                    using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                    {
                        var ws = xlPackage.Workbook.Worksheets[0];
                        ws.Cells[1, 1].Value = "Group Name";
                        ws.Cells[1, 2].Value = "Link";

                        for (int i = 1; i < chatNames.Count(); i++)
                        {
                            ws.Cells[i + 1, 1].Value = "Link " + i.ToString();
                            ws.Cells[i + 1, 2].Value = chatNames[i - 1];
                            contacts1.ContactNames.Add("Link " + i.ToString());
                            contacts1.GroupID.Add(chatNames[i]);
                        }
                        xlPackage.Save();
                    }

                    savesampleExceldialog.Filter = "Excel spreadsheet (*.xlsx)|*.xlsx|Comma-separated values file (*.csv)|*.csv";
                    savesampleExceldialog.FileName = "GroupLinks.xlsx";
                    contacts1.Name = Path.GetFileNameWithoutExtension(savesampleExceldialog.FileName).Replace(".xlsx", "");
                    contacts.Add(contacts1);
                    importGroups = contacts1;
                    string Json = JsonConvert.SerializeObject(contacts, Formatting.Indented);

                    if(save)
                        File.WriteAllText(fileSaves + "\\" + "GroupLinks.json", Json);

                    if(!save)
                    {
                        if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
                        {
                            File.Copy(NewFileName, savesampleExceldialog.FileName, true);
                        }
                    }

                    successTimer.Start();

                }
            }
        }

        bool save = false;
        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");

        private void materialButton1_Click(object sender, EventArgs e)
        {
            save = true;
            Initiate();
        }

        private void GrabGroupLinks_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if(driver!=null)
                {
                    driver.Quit();
                }
            }
            catch (Exception ex)
            {

            }
           /* foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialCard2_Paint(object sender, PaintEventArgs e)
        {

        }

        int successCount = 0;
        private void successTimer_Tick(object sender, EventArgs e)
        {
            if (successCount < 5)
            {
                successCount++;
            }
            else
            {
                successTimer.Stop();
                successCount = 0;
                if(!save)
                    Utils.showAlert(Strings.Filedownloadedsuccessfully, Alerts.Alert.enmType.Success);
                else
                {
                    Utils.showAlert("File Saved Successfully", Alerts.Alert.enmType.Success);
                    button2.Enabled = true;
                }
            }
        }

      /*  public void loadingScreen(bool appear)
        {
            if (appear)
            {
                this.mainNavPage.Activate();
                this.p.Hide();
                this.Hide();
                mainNavPage.loading1.Visible = true;
                mainNavPage.loading1.BringToFront();
            }
            else
            {
                this.mainNavPage.loading1.timer1.Stop();
                mainNavPage.loading1.Visible = false;
                mainNavPage.loading1.SendToBack();
            }
        }*/

        private void Timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (importGroups != null)
            {
                var count = ProjectCommon.getGroupLinks().Count - 1;
                mainNavPage.automaticMessagingNav1.init();
                mainNavPage.automaticMessagingNav1.mainNavPage = mainNavPage;
                mainNavPage.label8.ForeColor = Color.White;
                mainNavPage.panel4.SendToBack();
                mainNavPage.automaticMessagingNav1.Refresh();
                mainNavPage.automaticMessagingNav1.openGroups(false);
                mainNavPage.automaticMessagingNav1.chooseGroupContacts1.switchToLinks(false);
                mainNavPage.automaticMessagingNav1.chooseGroupContacts1.View(3, count.ToString(), false);
                mainNavPage.automaticMessagingNav1.chooseGroupContacts1.checkBox1.Checked = true;
                mainNavPage.automaticMessagingNav1.Visible = true;
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            save = false;
            Initiate();
        }
    }
}
