using MaterialSkin;
using MaterialSkin.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WASender.enums;
using System.Threading;
using System.Diagnostics;
using System.IO;
using OfficeOpenXml;
using WASender.Models;
using Newtonsoft.Json;

namespace WASender
{


    public partial class GrabChatList : MaterialForm
    {
        InitStatusEnum initStatusEnum;
        System.Windows.Forms.Timer timerInitChecker;
        IWebDriver driver;
        BackgroundWorker worker;
        CampaignStatusEnum campaignStatusEnum;
        WaSenderForm waSenderForm;
        Logger logger;
        MainNavPage mainNavPage;
        IndividualContacts importContacts;

        public GrabChatList(WaSenderForm _waSenderForm, MainNavPage mainNavPage)
        {
            InitializeComponent();
            logger = new Logger("GrabChatList");
            waSenderForm = _waSenderForm;
            this.mainNavPage = mainNavPage;

            if (Utils.Driver != null)
            {
                Utils.SetDriver();
                driver = Utils.Driver;
                initWA();
            }
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
        private void initWA()
        {
            btnInitWA.Enabled = false;
            ChangeInitStatus(InitStatusEnum.Initialising);

            try
            {
                var s = driver.WindowHandles;
            }
            catch (Exception ex)
            {
                Utils.Driver = null;
                this.driver = Utils.Driver;
            }


            try
            {
                if (driver == null)
                {
                    Utils.SetDriver();
                    this.driver = Utils.Driver;
                }


                checkQRScanDone();
            }
            catch (Exception ex)
            {
                ChangeInitStatus(InitStatusEnum.Unable);
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

                else if (ex.Message.Contains("invalid argument: user data directory is already in use"))
                {
                    Config.KillChromeDriverProcess();
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Please Close All Previous Sessions and Browsers if open, Then try again", Strings.OK, true);
                    SnackBarMessage.Show(this);
                }
            }
        }



        private void ChangeInitStatus(InitStatusEnum _initStatus)
        {
            logger.WriteLog("ChangeInitStatus = " + _initStatus.ToString());
            this.initStatusEnum = _initStatus;
            AutomationCommon.ChangeInitStatus(_initStatus, lblInitStatus);
        }


        private void init()
        {
            ChangeInitStatus(InitStatusEnum.NotInitialised);
            ChangeCampStatus(CampaignStatusEnum.NotStarted);
        }

        private void checkQRScanDone()
        {
            logger.WriteLog("checkQRScanDone");
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
                    logger.WriteLog("_1XkO3 ElementDisplayed");
                    ChangeInitStatus(InitStatusEnum.Initialised);
                    timerInitChecker.Stop();
                    initBackgroundWorker();
                    Activate();
                }
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex.Message);
                logger.WriteLog(ex.StackTrace);
                ChangeInitStatus(InitStatusEnum.Unable);
                timerInitChecker.Stop();
            }

            try
            {
                bool isElementDisplayed = AutomationCommon.IsElementPresent(By.ClassName("_1jJ70"), driver);
                if (isElementDisplayed == true)
                {
                    ChangeInitStatus(InitStatusEnum.Initialised);
                    timerInitChecker.Stop();
                    initBackgroundWorker();
                    Activate();
                }
            }
            catch (Exception ex)
            {
                ChangeInitStatus(InitStatusEnum.Unable);
                timerInitChecker.Stop();
            }
        }


        private void initBackgroundWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            //worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        List<string> chatNames;

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isEnd = false;
            chatNames = new List<string>();
            logger.WriteLog("Started Grabbing chat list");
            int nonINsertedCount = 0;
            while (isEnd == false)
            {
                logger.WriteLog("Not End");
                var list = driver.FindElements(By.XPath("//span[contains(@class,'_3m_Xw')] | //span[contains(@class,'_3q9s6')] | //div[contains(@class,'zoWT4')] "));
                logger.WriteLog("list count = " + list.Count());
                bool IsInserted = false;
                foreach (var chat in list)
                {
                    try
                    {
                        string ChatName = chat.FindElement(By.ClassName("ggj6brxn")).Text;
                        if ((chatNames.Where(_ => _ == ChatName).Count()) == 0)
                        {
                            chatNames.Add(ChatName);
                            IsInserted = true;
                        }
                    }
                    catch (Exception ex)
                    { }
                }
                if (IsInserted == false)
                {
                    nonINsertedCount++;
                }
                else
                {
                    nonINsertedCount = 0;
                }
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                driver.Manage().Window.Maximize();
                var res = (bool)js.ExecuteScript("return document.getElementById('pane-side').offsetHeight + document.getElementById('pane-side').scrollTop >= document.getElementById('pane-side').scrollHeight");
                Thread.Sleep(600);
                isEnd = res;
                if (isEnd == false && nonINsertedCount > 30)
                {
                    isEnd = true;
                }

                js.ExecuteScript("document.getElementById('pane-side').scrollBy(0,100)");
                logger.WriteLog("Js Executed");
            }



        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            String file = Path.Combine(FolderPath, "ChatList_" + Guid.NewGuid().ToString() + ".xlsx");

            string NewFileName = file.ToString();

            File.Copy("ChatListTemplate.xlsx", NewFileName, true);

            var newFile = new FileInfo(NewFileName);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                var ws = xlPackage.Workbook.Worksheets[0];

                for (int i = 0; i < chatNames.Count(); i++)
                {
                    ws.Cells[i + 1, 1].Value = chatNames[i];
                }
                xlPackage.Save();
            }


            savesampleExceldialog.FileName = "ChatList.xlsx";
            if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(NewFileName, savesampleExceldialog.FileName.EndsWith(".xlsx") ? savesampleExceldialog.FileName : savesampleExceldialog.FileName + ".xlsx", true);
                Utils.showAlert(Strings.Filedownloadedsuccessfully, Alerts.Alert.enmType.Success);
            }
            ChangeCampStatus(CampaignStatusEnum.Finish);
        }

        private void ChangeCampStatus(CampaignStatusEnum _campaignStatus)
        {
            AutomationCommon.ChangeCampStatus(_campaignStatus, lblRunStatus);
        }
        List<WAPI_ContactModel> wAPI_ContactModel;

        private void Initiate()
        {
            if (initStatusEnum != InitStatusEnum.Initialised)
            {
                Utils.showAlert(Strings.PleasefollowStepNo1FirstInitialiseWhatsapp, Alerts.Alert.enmType.Error);
                return;
            }
            if (campaignStatusEnum != CampaignStatusEnum.Running)
            {
                ChangeCampStatus(CampaignStatusEnum.Running);

                if (!WAPIHelper.IsWAPIInjected(driver))
                {
                    ProjectCommon.injectWapi(driver);
                }
                wAPI_ContactModel = WAPIHelper.getAlChats(driver);

                String FolderPath = Config.GetTempFolderPath();
                String file = Path.Combine(FolderPath, "ChatList_" + Guid.NewGuid().ToString() + ".xlsx");

                string NewFileName = file.ToString();

                File.Copy("ChatListTemplate.xlsx", NewFileName, true);

                var newFile = new FileInfo(NewFileName);
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                string fileData = File.ReadAllText(fileSaves + "\\" + "IndividualContacts.json");

                List<IndividualContacts> contacts = new List<IndividualContacts>();

                if (!String.IsNullOrWhiteSpace(fileData))
                    contacts = JsonConvert.DeserializeObject<List<IndividualContacts>>(fileData);


                IndividualContacts contacts1 = new IndividualContacts();
                contacts1.ContactNames = new List<string>();
                contacts1.Numbers = new List<string>();

                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    var ws = xlPackage.Workbook.Worksheets[0];

                    ws.Cells[1, 1].Value = "Number";
                    ws.Cells[1, 2].Value = "Name";
                    ws.Cells[1, 3].Value = "Labels";

                    for (int i = 0; i < wAPI_ContactModel.Count(); i++)
                    {
                        ws.Cells[i + 2, 1].Value = wAPI_ContactModel[i].number;
                        ws.Cells[i + 2, 2].Value = String.IsNullOrWhiteSpace(wAPI_ContactModel[i].Name) ? "Unknown" : wAPI_ContactModel[i].Name;
                        ws.Cells[i + 2, 3].Value = wAPI_ContactModel[i].Labels;

                        contacts1.ContactNames.Add(ws.Cells[i + 2, 2].Value.ToString());
                        contacts1.Numbers.Add(wAPI_ContactModel[i].number);
                    }
                    xlPackage.Save();
                }


                savesampleExceldialog.FileName = "ChatstList.xlsx";
                contacts1.Name = Path.GetFileNameWithoutExtension(savesampleExceldialog.FileName).Replace(".xlsx", "");
                contacts.Add(contacts1);
                importContacts = contacts1;
                string Json = JsonConvert.SerializeObject(contacts, Formatting.Indented);

                if(save)
                    File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);
                if(!save)
                {
                    if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(NewFileName, savesampleExceldialog.FileName.EndsWith(".xlsx") ? savesampleExceldialog.FileName : savesampleExceldialog.FileName + ".xlsx", true);
                    }
                }
                successTimer.Start();

                ChangeCampStatus(CampaignStatusEnum.Finish);

            }
            else
            {
                Utils.showAlert(Strings.Processisalreadyrunning, Alerts.Alert.enmType.Info);
            }
        }

        bool save = false;
        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");

        private void materialButton1_Click(object sender, EventArgs e)
        {
            save = true;
            Initiate();   
        }

        private void btnInitWA_Click(object sender, EventArgs e)
        {
            initWA();
        }

        private void GrabGroups_Load(object sender, EventArgs e)
        {
            init();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.Text = Strings.GrabChatList;
            materialLabel2.Text = Strings.InitiateWhatsAppScaneQRCodefromyourmobile;
            btnInitWA.Text = Strings.ClicktoInitiate;
            label5.Text = Strings.Status;
            label7.Text = Strings.Status;
/*            materialButton1.Text = Strings.StartGrabbing;
*/
        }

        private void GrabGroups_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.Complete();

           /* try
            {
                if(driver!=null)
                {
                    driver.Quit();
                }
            }
            catch (Exception ex)
            {

            }
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }*/
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (importContacts != null)
            {
                var count = ProjectCommon.getContactLists().Count - 1;
                mainNavPage.automaticMessagingNav1.init();
                mainNavPage.automaticMessagingNav1.mainNavPage = mainNavPage;
                mainNavPage.label8.ForeColor = Color.White;
                mainNavPage.panel4.SendToBack();
                mainNavPage.automaticMessagingNav1.Refresh();
                mainNavPage.automaticMessagingNav1.openContacts();
                mainNavPage.automaticMessagingNav1.chooseContact1.View(1, count.ToString(), false);
                mainNavPage.automaticMessagingNav1.chooseContact1.checkBox1.Checked = true;
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
