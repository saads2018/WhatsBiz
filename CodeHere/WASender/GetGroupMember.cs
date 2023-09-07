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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WASender.enums;
using WASender.Models;

namespace WASender
{
    public partial class GetGroupMember : MaterialForm
    {
        InitStatusEnum initStatusEnum;
        System.Windows.Forms.Timer timerInitChecker;
        IWebDriver driver;
        BackgroundWorker worker;
        CampaignStatusEnum campaignStatusEnum;
        WaSenderForm waSenderForm;
        Logger logger;
        List<WAPI_GroupModel> wAPI_GroupModel;
        IndividualContacts importContacts;
        MainNavPage mainNavPage;

        public GetGroupMember(WaSenderForm _waSenderForm,MainNavPage mainNavPage)
        {
            InitializeComponent();

            waSenderForm = _waSenderForm;
            this.mainNavPage = mainNavPage;

            logger = new Logger("GteGroupMembers");

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
                    logger.WriteLog("_1XkO3 ElementDisplayed");
                    ChangeInitStatus(InitStatusEnum.Initialised);
                    timerInitChecker.Stop();
                    Activate();
                }
            }
            catch (Exception ex)
            {
                ChangeInitStatus(InitStatusEnum.Unable);
                logger.WriteLog(ex.Message);
                logger.WriteLog(ex.StackTrace);
                timerInitChecker.Stop();
            }
            try
            {
                bool isElementDisplayed = AutomationCommon.IsElementPresent(By.ClassName("_1jJ70"), driver);
                if (isElementDisplayed == true)
                {
                    ChangeInitStatus(InitStatusEnum.Initialised);
                    timerInitChecker.Stop();
                    //initBackgroundWorker();
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
            initWA();
        }

        private void GetGroupMember_Load(object sender, EventArgs e)
        {
            init();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.Text = Strings.GetGroupMember;
            materialLabel2.Text = Strings.InitiateWhatsAppScaneQRCodefromyourmobile;
            materialLabel1.Text = Strings.OpenanyGroupchatClickbuttonbellow;
            btnInitWA.Text = Strings.ClicktoInitiate;
/*            materialButton1.Text = Strings.StartGrabbing;
*/            label5.Text = Strings.Status;
        }

        private List<string> TryThirdMethod()
        {
            logger.WriteLog("Third Attempt Started ");
            List<string> _chatNames = new List<string>();

            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string text = (string)js.ExecuteScript("return document.getElementsByClassName('_2YPr_')[0].getAttribute('title')");
                _chatNames = AutomationCommon.GetNumbers(text);
                logger.WriteLog("Got Text=" + text);
            }
            catch (Exception ex)
            {
                logger.WriteLog("Third Attempt Error-");
                logger.WriteLog(ex.Message);
                logger.WriteLog(ex.StackTrace);
            }
            logger.WriteLog("Third Attempt End ");
            return _chatNames;
        }

        private List<string> TrySecondMetod()
        {
            List<string> _chatNames = new List<string>();
            logger.WriteLog("Second Attempt Started ");
            try
            {
                By span = By.XPath("//*[@id='main']/header/div[2]/div[2]/span");
                if (AutomationCommon.IsElementPresent(span, driver))
                {
                    logger.WriteLog("span found");
                    string text = driver.FindElement(span).Text;
                    logger.WriteLog("Got Text=" + text);
                    _chatNames = AutomationCommon.GetNumbers(text);
                }
                else
                {
                    logger.WriteLog("span not found");
                }
            }
            catch (Exception ex)
            {
                logger.WriteLog("Second Attempt Error-");
                logger.WriteLog(ex.Message);
                logger.WriteLog(ex.StackTrace);
            }
            logger.WriteLog("Second Attempt End");
            return _chatNames;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            save = true;
            Initiate();
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
                    DialogResult dr = MessageBox.Show("Your Chrome Driver and Google Chrome Version Is not same, Click 'Yes botton' to Update it from Settings", "Error ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                    if (dr == DialogResult.Yes)
                    {
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
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");

        public void ReturnBack(int index)
        {
            if (wAPI_GroupModel != null && wAPI_GroupModel.Count() > 0)
            {
                if (!WAPIHelper.IsWAPIInjected(driver))
                {
                    ProjectCommon.injectWapi(driver);
                }


                WAPI_GroupModel group = wAPI_GroupModel[index];
                List<string> members = WAPIHelper.GetGroupMembers(group, driver);

                String FolderPath = Config.GetTempFolderPath();
                String file = Path.Combine(FolderPath, "" + Config.RemoveSpecialCharacters( group.GroupName )+ "_Members_" + Guid.NewGuid().ToString() + ".xlsx");
                string NewFileName = file.ToString();

                File.Copy("MemberListTemplate.xlsx", NewFileName, true);

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
                    contacts1.Name = group.GroupName + "_Members";

                    var ws = xlPackage.Workbook.Worksheets[0];

                    for (int i = 0; i < members.Count(); i++)
                    {
                        ws.Cells[i + 1, 1].Value = members[i];
                        contacts1.ContactNames.Add("Group Member" + (i + 1).ToString());
                        contacts1.Numbers.Add(members[i]);
                    }
                    xlPackage.Save();
                }

                contacts.Add(contacts1);
                importContacts = contacts1;
                string Json = JsonConvert.SerializeObject(contacts, Formatting.Indented);

                if(save)
                    File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json",Json);
                savesampleExceldialog.FileName = Config.RemoveSpecialCharacters(group.GroupName) + "_Members.xlsx";

                if(!save)
                {
                    if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(NewFileName, savesampleExceldialog.FileName.EndsWith(".xlsx") ? savesampleExceldialog.FileName : savesampleExceldialog.FileName + ".xlsx", true);
                    }
                }

                successTimer.Start();
            }
        }
        private void GetGroupMember_FormClosed(object sender, FormClosedEventArgs e)
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

        internal void ReturnBack(List<WAPI_GroupModel> p)
        {
            if (!WAPIHelper.IsWAPIInjected(driver))
            {
                ProjectCommon.injectWapi(driver);
            }

            List<string> members = new List<string>();
            foreach (var group in p)
            {
                members.AddRange(WAPIHelper.GetGroupMembers(group, driver));
            }

            String FolderPath = Config.GetTempFolderPath();
            String file = Path.Combine(FolderPath, "Multiple_Group_Members" + Guid.NewGuid().ToString() + ".xlsx");
            string NewFileName = file.ToString();

            File.Copy("MemberListTemplate.xlsx", NewFileName, true);


            var newFile = new FileInfo(NewFileName);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            string fileData = File.ReadAllText(fileSaves + "\\" + "IndividualContacts.json");

            List<IndividualContacts> contacts = new List<IndividualContacts>();
            int x = 1;

            if (!String.IsNullOrWhiteSpace(fileData))
            {
                contacts = JsonConvert.DeserializeObject<List<IndividualContacts>>(fileData);
                x = contacts.Where(y => y.Name.StartsWith("Group_Members")).ToList().Count+1;
            }

            IndividualContacts contacts1 = new IndividualContacts();
            contacts1.ContactNames = new List<string>();
            contacts1.Numbers = new List<string>();

            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {

                contacts1.Name = "Group_Members_"+x;
                var ws = xlPackage.Workbook.Worksheets[0];

                for (int i = 0; i < members.Count(); i++)
                {
                    ws.Cells[i + 1, 1].Value = members[i];
                    contacts1.ContactNames.Add("Empty");
                    contacts1.Numbers.Add(members[i]);
                }
                xlPackage.Save();
            }

            contacts.Add(contacts1);
            importContacts = contacts1;
            string Json = JsonConvert.SerializeObject(contacts, Formatting.Indented);

            if (save)
                File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);

            savesampleExceldialog.FileName = "Multiple_Group_Members.xlsx";

            if (!save)
            {
                if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(NewFileName, savesampleExceldialog.FileName.EndsWith(".xlsx") ? savesampleExceldialog.FileName : savesampleExceldialog.FileName + ".xlsx", true);
                    Utils.showAlert(Strings.Filedownloadedsuccessfully, Alerts.Alert.enmType.Success);
                }
            }
            successTimer.Start();
        }

        private void materialCard2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialCard2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void materialCard3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void savesampleExceldialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void lblInitStatus_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<IndividualContacts> getContactLists()
        {
            List<IndividualContacts> contacts = new List<IndividualContacts>();
            string fileData = File.ReadAllText(fileSaves + "\\" + "IndividualContacts.json");
            contacts=JsonConvert.DeserializeObject<List<IndividualContacts>>(fileData);
            return contacts;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(importContacts!=null)
            {
                var count = getContactLists().Count - 1;
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
        }
        int successCount = 0;
        private void successTimer_Tick(object sender, EventArgs e)
        {
            if(successCount<5)
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

        bool save = false;

        public void Initiate()
        {
            if (initStatusEnum != InitStatusEnum.Initialised)
            {
                logger.WriteLog("!InitStatusEnum.Initialised");
                Utils.showAlert(Strings.PleasefollowStepNo1FirstInitialiseWhatsapp, Alerts.Alert.enmType.Error);
                return;
            }
            if (campaignStatusEnum != CampaignStatusEnum.Running)
            {

                if (Config.SendingType == 1)
                {
                    if (!WAPIHelper.IsWAPIInjected(driver))
                    {
                        ProjectCommon.injectWapi(driver);
                    }

                    wAPI_GroupModel = WAPIHelper.getMyGroups(driver);
                    ChooseGroup ghooseGroup = new ChooseGroup(this, wAPI_GroupModel,true);
                    ghooseGroup.ShowDialog();
                    this.Refresh();
                }
                else if (Config.SendingType == 2)
                {
                    #region
                    By numbersBy = By.ClassName("_2YPr_");

                    chatNames = new List<string>();

                    if (AutomationCommon.IsElementPresent(numbersBy, driver))
                    {
                        logger.WriteLog("_2YPr_ is present");
                        IWebElement numbersDiv = driver.FindElement(numbersBy);
                        string list = numbersDiv.GetAttribute("title");

                        var splitter = list.Split(',');
                        logger.WriteLog("splitter.Count = " + splitter.Count());
                        if (splitter.Count() == 1)
                        {
                            logger.WriteLog("splitter.Count = 1");
                            Thread.Sleep(2000);
                            list = numbersDiv.GetAttribute("title");
                            splitter = list.Split(',');
                            logger.WriteLog("splitter.Count = " + splitter.Count());
                            if (splitter.Count() == 1)
                            {
                                Thread.Sleep(2000);
                                list = numbersDiv.GetAttribute("title");
                                splitter = list.Split(',');
                            }
                        }



                        int globalCounter = 0;
                        foreach (var item in splitter)
                        {
                            string newItem = item.Replace("+", "").Replace(" ", "");

                            try
                            {
                                if (Config.IsDemoMode == true)
                                {
                                    if (globalCounter > 5)
                                    {
                                        Utils.showAlert("You can Extract only 5 Group Members in trial version", Alerts.Alert.enmType.Error);
                                        break;
                                    }
                                }
                                Int64 number = Convert.ToInt64(newItem);
                                chatNames.Add(newItem);
                                globalCounter++;
                            }
                            catch (Exception ex)
                            {

                            }

                        }


                        if (chatNames.Count() == 0)
                        {
                            logger.WriteLog("First Attempt - chatNames.Count = 0");
                            try
                            {
                                chatNames = TrySecondMetod();
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        if (chatNames.Count() == 0)
                        {
                            logger.WriteLog("Second Attempt - chatNames.Count = 0");
                            chatNames = TryThirdMethod();
                        }
                        if (chatNames.Count() == 0)
                        {
                            logger.WriteLog("Third Attempt - chatNames.Count = 0");
                        }

                        string GroupName = "Group_";

                        By GroupNameBy = By.XPath("/html/body/div[1]/div[1]/div[1]/div[4]/div[1]/header/div[2]/div[1]/div/span");


                       
                        if (AutomationCommon.IsElementPresent(GroupNameBy, driver))
                        {
                            GroupName = AutomationCommon.RemoveSpecialCharacters(driver.FindElement(GroupNameBy).Text);
                        }

                        String FolderPath = Config.GetTempFolderPath();
                        String file = Path.Combine(FolderPath, "" + GroupName + "_Members_" + Guid.NewGuid().ToString() + ".xlsx");
                        string NewFileName = file.ToString();

                        File.Copy("MemberListTemplate.xlsx", NewFileName, true);

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


                        savesampleExceldialog.FileName = GroupName + "_Members.xlsx";
                        if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
                        {
                            File.Copy(NewFileName, savesampleExceldialog.FileName.EndsWith(".xlsx") ? savesampleExceldialog.FileName : savesampleExceldialog.FileName + ".xlsx", true);
                            Utils.showAlert(Strings.Filedownloadedsuccessfully, Alerts.Alert.enmType.Success);
                        }
                    }
                    else
                    {
                        Utils.showAlert(Strings.PleaseGotoanygroupchat, Alerts.Alert.enmType.Warning);
                    }

                    #endregion
                }

            }
            else
            {
                Utils.showAlert(Strings.Processisalreadyrunning, Alerts.Alert.enmType.Info);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            save = false;
            Initiate();
        }
    }
}
