﻿using MaterialSkin.Controls;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WASender.enums;
using WASender.Models;

namespace WASender
{
    public partial class ContactGrabber : MaterialForm
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
        GroupContact importGroups;
        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");

        public ContactGrabber(WaSenderForm _waSenderForm, MainNavPage mainNavPage)
        {
            InitializeComponent();
            logger = new Logger("ContactGrabber");
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
        private void ChangeCampStatus(CampaignStatusEnum _campaignStatus)
        {
            AutomationCommon.ChangeCampStatus(_campaignStatus, lblRunStatus);
        }

        private void ContactGrabber_Load(object sender, EventArgs e)
        {
            init();
            InitLanguage();
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
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        List<string> chatNames;
        List<WAPI_ContactModel> wAPI_ContactModel;
        List<WAPI_GroupModel> wAPI_GroupModel;


        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isEnd = false;
            chatNames = new List<string>();
            logger.WriteLog("Started Grabbing chat list");
            int nonINsertedCount = 0;
            try
            {
                By newChatButonBy = By.XPath("//*[@id=\"side\"]/header/div[2]/div/span/div[2]/div/span");
                if (AutomationCommon.IsElementPresent(newChatButonBy, driver))
                {
                    driver.FindElement(newChatButonBy).Click();
                    while (isEnd == false)
                    {

                        logger.WriteLog("Not End");
                        By HolderBy = By.ClassName("KPJpj");
                        if (AutomationCommon.IsElementPresent(HolderBy, driver))
                        {
                            IWebElement Holder = driver.FindElement(HolderBy);

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
                                {
                                    try
                                    {
                                        string ss = chat.GetAttribute("innerHTML");
                                        string ChatName = chat.FindElement(By.ClassName("_3q9s6")).Text;
                                        if ((chatNames.Where(_ => _ == ChatName).Count()) == 0)
                                        {
                                            chatNames.Add(ChatName);
                                            IsInserted = true;
                                        }
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                            }
                            if (IsInserted == false)
                            {
                                nonINsertedCount++;
                            }
                            else
                            {
                                nonINsertedCount = 0;
                            }
                        }


                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                        var res = (bool)js.ExecuteScript("return document.getElementsByClassName('KPJpj')[0].offsetHeight + document.getElementsByClassName('KPJpj')[0].scrollTop >= document.getElementsByClassName('KPJpj')[0].scrollHeight");
                        Thread.Sleep(600);
                        isEnd = res;
                        if (isEnd == false && nonINsertedCount > 30)
                        {
                            isEnd = true;
                        }
                        driver.Manage().Window.Maximize();
                        js.ExecuteScript("document.getElementsByClassName('KPJpj')[0].scrollBy(0,100)");
                        logger.WriteLog("Js Executed");
                    }
                }
                else
                {
                    logger.WriteLog("New CHat Element is not Ready");
                }
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex.Message);
                logger.WriteLog(ex.StackTrace);
            }


        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            String FolderPath = Config.GetTempFolderPath();
            String file = Path.Combine(FolderPath, "ContactList_" + Guid.NewGuid().ToString() + ".xlsx");

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


            savesampleExceldialog.FileName = "ContactLIstList.xlsx";
            if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(NewFileName, savesampleExceldialog.FileName.EndsWith(".xlsx") ? savesampleExceldialog.FileName : savesampleExceldialog.FileName + ".xlsx");
                Utils.showAlert(Strings.Filedownloadedsuccessfully, Alerts.Alert.enmType.Success);
            }
            ChangeCampStatus(CampaignStatusEnum.Finish);
        }

        private void InitLanguage()
        {
            this.Text = Strings.ContactListGrabber;
/*            materialLabel2.Text = Strings.InitiateWhatsAppScaneQRCodefromyourmobile;
*/            btnInitWA.Text = Strings.ClicktoInitiate;
            label5.Text = Strings.Status;
            label7.Text = Strings.Status;
            /*materialButton4.Text = Strings.GrabAllSavedContacts;
            materialButton5.Text = Strings.GrabAllGroups;*/

        }

        private void ContactGrabber_FormClosed(object sender, FormClosedEventArgs e)
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
                Utils.SetDriver();
                this.driver = Utils.Driver;
            }


            try
            {
                if (driver == null)
                {
                    Utils.SetDriver();
                    this.driver = Utils.Driver;
                }
                //if (driver == null)
                //{
                //    var chromeDriverService = ChromeDriverService.CreateDefaultService();
                //    chromeDriverService.HideCommandPromptWindow = true;


                //    driver = new ChromeDriver(chromeDriverService, Config.GetChromeOptions());
                //    try
                //    {
                //        driver.Url = "https://web.whatsapp.com";
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}


                checkQRScanDone();
            }
            catch (Exception ex)
            {
                ChangeInitStatus(InitStatusEnum.Unable);
                if (ex.Message.Contains("session not created"))
                {
                    DialogResult dr = MessageBox.Show("Your Chrome Driver and Google Chrome Version Is not same, Click 'Yes botton' to view detail info ", "Error ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                    if (dr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://medium.com/fusionqa/selenium-webdriver-error-sessionnotcreatederror-session-not-created-this-version-of-7b3a8acd7072");
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
            private void btnInitWA_Click(object sender, EventArgs e)
            
            {
                initWA();
            }

        public void InitiateContacts()
        {
            if (initStatusEnum != InitStatusEnum.Initialised)
            {
                Utils.showAlert(Strings.PleasefollowStepNo1FirstInitialiseWhatsapp, Alerts.Alert.enmType.Error);
                return;
            }

            if (!WAPIHelper.IsWAPIInjected(driver))
            {
                ProjectCommon.injectWapi(driver);
            }

            wAPI_ContactModel = WAPIHelper.getMyContacts(driver);


            String FolderPath = Config.GetTempFolderPath();
            String file = Path.Combine(FolderPath, "ContactList_" + Guid.NewGuid().ToString() + ".xlsx");

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
                    ws.Cells[i + 2, 2].Value = wAPI_ContactModel[i].Name;
                    ws.Cells[i + 2, 3].Value = wAPI_ContactModel[i].Labels;

                    contacts1.Numbers.Add(wAPI_ContactModel[i].number);
                    contacts1.ContactNames.Add(wAPI_ContactModel[i].Name);
                }
                xlPackage.Save();
            }


            savesampleExceldialog.FileName = "ContactLIstList.xlsx";

            contacts1.Name = Path.GetFileNameWithoutExtension(savesampleExceldialog.FileName).Replace(".xlsx", "");
            contacts.Add(contacts1);
            importContacts = contacts1;
            importGroups = null;
            button2.Text = "Import Contacts";

            string Json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            if (save)
                File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);

            if(!save)
            {
                if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(NewFileName, savesampleExceldialog.FileName.EndsWith(".xlsx") ? savesampleExceldialog.FileName : savesampleExceldialog.FileName + ".xlsx",true);
                }
            }
           
            successTimer.Start();
            ChangeCampStatus(CampaignStatusEnum.Finish);
        }

        bool save = false;
        private void materialButton1_Click(object sender, EventArgs e)
        {
            save = true;
            InitiateContacts();
        }

        private  void InitiateGroups()
        {
            if (initStatusEnum != InitStatusEnum.Initialised)
            {
                Utils.showAlert(Strings.PleasefollowStepNo1FirstInitialiseWhatsapp, Alerts.Alert.enmType.Error);
                return;
            }

            if (!WAPIHelper.IsWAPIInjected(driver))
            {
                ProjectCommon.injectWapi(driver);
            }

            wAPI_GroupModel = WAPIHelper.getMyGroups(driver);


            String FolderPath = Config.GetTempFolderPath();
            String file = Path.Combine(FolderPath, "GroupList_" + Guid.NewGuid().ToString() + ".xlsx");

            string NewFileName = file.ToString();

            File.Copy("ChatListTemplate.xlsx", NewFileName, true);


            var newFile = new FileInfo(NewFileName);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            string fileData = File.ReadAllText(fileSaves + "\\" + "Groups.json");

            List<GroupContact> contacts = new List<GroupContact>();

            if (!String.IsNullOrWhiteSpace(fileData))
                contacts = JsonConvert.DeserializeObject<List<GroupContact>>(fileData);


            GroupContact contacts1 = new GroupContact();
            contacts1.ContactNames = new List<string>();
            contacts1.GroupID = new List<string>();

            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                var ws = xlPackage.Workbook.Worksheets[0];

                ws.Cells[1, 1].Value = "GroupName";
                ws.Cells[1, 2].Value = "GroupId";
                ws.Cells[1, 3].Value = "GroupLInk";


                for (int i = 0; i < wAPI_GroupModel.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = wAPI_GroupModel[i].GroupName;
                    ws.Cells[i + 2, 2].Value = wAPI_GroupModel[i].GroupId;
                    ws.Cells[i + 2, 3].Value = wAPI_GroupModel[i].GroupLink;

                    contacts1.GroupID.Add(wAPI_GroupModel[i].GroupId);
                    contacts1.ContactNames.Add(wAPI_GroupModel[i].GroupName);
                }
                xlPackage.Save();
            }


            savesampleExceldialog.FileName = "GroupList.xlsx";

            contacts1.Name = Path.GetFileNameWithoutExtension(savesampleExceldialog.FileName).Replace(".xlsx", "");
            contacts.Add(contacts1);
            importGroups = contacts1;
            importContacts = null;
            button2.Text = "Import Groups";
            string Json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            
            if(save)
                File.WriteAllText(fileSaves + "\\" + "Groups.json", Json);

            if(!save)
            {
                if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(NewFileName, savesampleExceldialog.FileName.EndsWith(".xlsx") ? savesampleExceldialog.FileName : savesampleExceldialog.FileName + ".xlsx");
                }
            }

            successTimer.Start();
            ChangeCampStatus(CampaignStatusEnum.Finish);
        }
        private void materialButton2_Click(object sender, EventArgs e)
        {
            save = true;
            InitiateGroups();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialCard2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if(importContacts!=null)
            {
                var count = ProjectCommon.getContactLists().Count - 1;
                mainNavPage.automaticMessagingNav1.init();
                mainNavPage.automaticMessagingNav1.mainNavPage = mainNavPage;
                mainNavPage.label8.ForeColor = Color.White;
                mainNavPage.panel4.SendToBack();
                mainNavPage.automaticMessagingNav1.Refresh();
                mainNavPage.automaticMessagingNav1.openContacts();
                mainNavPage.automaticMessagingNav1.chooseContact1.View(1, count.ToString(),false);
                mainNavPage.automaticMessagingNav1.chooseContact1.checkBox1.Checked = true;
                mainNavPage.automaticMessagingNav1.Visible = true;
                this.Close();
            }
            else if (importGroups != null)
            {
                var count = ProjectCommon.getGroupLists().Count - 1;
                mainNavPage.automaticMessagingNav1.init();
                mainNavPage.automaticMessagingNav1.mainNavPage = mainNavPage;
                mainNavPage.label8.ForeColor = Color.White;
                mainNavPage.panel4.SendToBack();
                mainNavPage.automaticMessagingNav1.Refresh();
                mainNavPage.automaticMessagingNav1.openGroups();
                mainNavPage.automaticMessagingNav1.chooseGroupContacts1.View(1, count.ToString(),false);
                mainNavPage.automaticMessagingNav1.chooseGroupContacts1.checkBox1.Checked = true;
                mainNavPage.automaticMessagingNav1.Visible = true;
                this.Close();
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            save = false;
            InitiateContacts();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            save = false;
            InitiateGroups();
        }
    }
}
