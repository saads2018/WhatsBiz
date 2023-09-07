using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Web.WebView2.WinForms;
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
    public partial class GrabGroupActiveMembers : MaterialForm
    {
        InitStatusEnum initStatusEnum;
        System.Windows.Forms.Timer timerInitChecker;
        IWebDriver driver;
        BackgroundWorker worker;
        WAPI_GroupModel wAPI_SelectedGroup;
        CampaignStatusEnum campaignStatusEnum;
        WaSenderForm waSenderForm;
        Logger logger;
        System.Windows.Forms.Timer timerRunner;
        private static List<Models.ActiveMemberModel> activeMembersMain = new List<Models.ActiveMemberModel>();
        MainNavPage mainNavPage;
        IndividualContacts importContacts;

        GeneralSettingsModel generalSettingsModel;
        WaSenderBrowser browser;
        private TestClass _testClass;

        List<WAPI_GroupModel> wAPI_GroupModel;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        public GrabGroupActiveMembers(WaSenderForm _waSenderForm,MainNavPage mainNavPage)
        {
            InitializeComponent();
            waSenderForm = _waSenderForm;
            this.mainNavPage = mainNavPage;

            generalSettingsModel = Config.GetSettings();
            logger = new Logger("GrabAcriveMembers");
            if (Utils.Driver != null)
            {
                if (generalSettingsModel.browserType == 1)
                {
                    Utils.SetDriver();
                    driver = Utils.Driver;
                    initWA();
                }
            }
            activeMembersMain = new List<ActiveMemberModel>();
            if (Utils.waSenderBrowser != null)
            {
                browser = Utils.waSenderBrowser;
                initWABrowser();
            }
            _testClass = Utils.testClass;
            _testClass.OnUpdateStatus += _testClass_OnUpdateStatus;
        }

        private void initWABrowser()
        {
            ChangeInitStatus(InitStatusEnum.Initialising);
            retryAttempt = 0;
            if (Utils.waSenderBrowser != null)
            {
                browser = Utils.waSenderBrowser;
            }
            else
            {
                browser = new WaSenderBrowser();
                Utils.waSenderBrowser = browser;
                browser.Show();
            }
            checkQRScanDoneBrowser();
        }

        private void checkQRScanDoneBrowser()
        {
            Thread.Sleep(1000);
            logger.WriteLog("checkQRScanDone");
            timerInitChecker = new System.Windows.Forms.Timer();
            timerInitChecker.Interval = 1000;
            timerInitChecker.Tick += timerInitChecker_Tick;
            timerInitChecker.Start();
        }

        void _testClass_OnUpdateStatus(object sender, ProgressEventArgs e)
        {
            ChangeInitStatus(InitStatusEnum.Stopped);
            ChangeCampStatus(CampaignStatusEnum.Stopped);
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
                    //var chromeDriverService = ChromeDriverService.CreateDefaultService();
                    //chromeDriverService.HideCommandPromptWindow = true;


                    //driver = new ChromeDriver(chromeDriverService, Config.GetChromeOptions());
                    //try
                    //{
                    //    driver.Url = "https://web.whatsapp.com";
                    //}
                    //catch (Exception ex)
                    //{

                    //}
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

        public void ReturnBack(WAPI_GroupModel index)
        {
            wAPI_SelectedGroup = index;
            if (wAPI_SelectedGroup != null)
            {
                initBackgroundWorker();
                worker.RunWorkerAsync();
                initTimer();
                ChangeCampStatus(CampaignStatusEnum.Running);
                campaignStatusEnum = CampaignStatusEnum.Running;
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


        private void initTimer()
        {
            timerRunner = new System.Windows.Forms.Timer();
            timerRunner.Interval = 1000;
            timerRunner.Tick += timerRunnerChecker_Tick;
            timerRunner.Start();
        }

        public void timerRunnerChecker_Tick(object sender, EventArgs e)
        {
            if (isStoped == false)
            {
                materialButton5.Text="Save: Members = " + (activeMembersMain.Count() + activeMembers.Count()).ToString();
                button3.Text = "Export: Members = " + (activeMembersMain.Count() + activeMembers.Count()).ToString();
            }
        }

        private void checkQRScanDone()
        {
            timerInitChecker = new System.Windows.Forms.Timer();
            timerInitChecker.Interval = 1000;
            timerInitChecker.Tick += timerInitChecker_Tick;
            timerInitChecker.Start();
        }
        int retryAttempt = 0;
        public async void timerInitChecker_Tick(object sender, EventArgs e)
        {
            if (generalSettingsModel.browserType == 1)
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
            else if (generalSettingsModel.browserType == 2)
            {
                try
                {
                    WebView2 vw = Utils.GetActiveWebView(browser);

                    bool isInitiated = await WPPHelper.isWaInited(vw);
                    if (isInitiated)
                    {
                        ChangeInitStatus(InitStatusEnum.Initialised);
                        timerInitChecker.Stop();
                        initBackgroundWorker();
                        Activate();
                    }
                }
                catch (Exception ex)
                {
                    if (retryAttempt == 5)
                    {
                        retryAttempt = 0;
                        timerInitChecker.Stop();
                    }
                    else
                    {
                        retryAttempt++;
                        Debug.WriteLine("Retry attempt ." + retryAttempt.ToString());
                        Thread.Sleep(1000);
                    }
                }
            }

        }




        private void btnInitWA_Click(object sender, EventArgs e)
        {

            if (generalSettingsModel.browserType == 1)
            {
                ChangeInitStatus(InitStatusEnum.Initialising);
                logger.WriteLog("ChangeInitStatus");
                try
                {
                    initWA();

                    checkQRScanDone();
                }
                catch (Exception ex)
                {
                    logger.WriteLog(ex.Message);
                    logger.WriteLog(ex.StackTrace);
                    ChangeInitStatus(InitStatusEnum.Unable);
                    string ss = "";
                    if (ex.Message.Contains("session not created"))
                    {
                        DialogResult dr = MessageBox.Show("Your Chrome Driver and Google Chrome Version Is not same, Click 'Yes botton' to Update it from Settings", "Error ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                        if (dr == DialogResult.Yes)
                        {
                            this.Hide();
                            this.waSenderForm.Show();
                            GeneralSettings generalSettings = new GeneralSettings();
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
            else if (generalSettingsModel.browserType == 2)
            {
                initWABrowser();
            }


        }

        private void ChangeCampStatus(CampaignStatusEnum _campaignStatus)
        {
            AutomationCommon.ChangeCampStatus(_campaignStatus, lblRunStatus);
        }


        private async void materialButton1_Click(object sender, EventArgs e)
        {
            //activeMembers = new List<Models.ActiveMemberModel>();
            isStoped = false;
            if (initStatusEnum != InitStatusEnum.Initialised)
            {
                logger.WriteLog("!InitStatusEnum.Initialised");
                Utils.showAlert(Strings.PleasefollowStepNo1FirstInitialiseWhatsapp, Alerts.Alert.enmType.Error);
                return;
            }

            if (campaignStatusEnum != CampaignStatusEnum.Running)
            {
                if (generalSettingsModel.browserType == 1)
                {
                    By groupHeadderBy = By.XPath("//*[@id='main']/header/div[2]/div[1]/div/span");

                    if (AutomationCommon.IsElementPresent(groupHeadderBy, driver))
                    {
                        logger.WriteLog("groupHeadderBy is present");
                        initBackgroundWorker();
                        worker.RunWorkerAsync();
                        initTimer();
                        ChangeCampStatus(CampaignStatusEnum.Running);
                        campaignStatusEnum = CampaignStatusEnum.Running;
                    }
                    else
                    {
                        Utils.showAlert(Strings.PleaseGotoanygroupchat, Alerts.Alert.enmType.Warning);
                        logger.WriteLog("groupHeadderBy is not present");
                    }
                }
                else if (generalSettingsModel.browserType == 2)
                {

                    WebView2 wv = Utils.GetActiveWebView(browser);

                    if (!await WPPHelper.isWPPinjected(wv))
                    {
                        await WPPHelper.InjectWapi(wv, Config.GetSysFolderPath());
                        Thread.Sleep(1000);
                    }
                    wAPI_GroupModel = await WPPHelper.getMyGroups(wv);

                    ChooseGroup ghooseGroup = new ChooseGroup(this, wAPI_GroupModel);
                    ghooseGroup.ShowDialog();
                }

            }

        }

        private void GrabGroupActiveMembers_Load(object sender, EventArgs e)
        {
            init();
            InitLanguage();
            ChangeCampStatus(CampaignStatusEnum.NotStarted);
        }

        private void InitLanguage()
        {
            this.Text = Strings.GrabActiveGroupMembers;
            materialLabel2.Text = Strings.InitiateWhatsAppScaneQRCodefromyourmobile;
            materialLabel1.Text = Strings.OpenanyGroupchatClickbuttonbellow;
            btnInitWA.Text = Strings.ClicktoInitiate;
            materialButton1.Text = Strings.StartGrabbing;
            label5.Text = Strings.Status;
            materialButton2.Text = Strings.Stop;
/*            label1.Text = Strings.TotalFound;
*//*            materialButton5.Text = Strings.Export;
*/        }




        private void GrabGroupActiveMembers_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger.Complete();

            /*try
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

            if (campaignStatusEnum == CampaignStatusEnum.Running)
            {
                isStoped = true;
                timerRunner.Stop();
                ChangeCampStatus(CampaignStatusEnum.Stopped);
                campaignStatusEnum = CampaignStatusEnum.Stopped;
                activeMembersMain.AddRange(activeMembers);
                activeMembers = new List<Models.ActiveMemberModel>();
            }

        }

        private void initBackgroundWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (campaignStatusEnum == CampaignStatusEnum.Running)
            {
                isStoped = true;
                timerRunner.Stop();
                ChangeCampStatus(CampaignStatusEnum.Finish);
                campaignStatusEnum = CampaignStatusEnum.Finish;
                activeMembersMain.AddRange(activeMembers);
                materialButton5.Text = "Save: Members = " + (activeMembersMain.Count() + activeMembers.Count()).ToString();
                button3.Text = "Export: Members = " + (activeMembersMain.Count() + activeMembers.Count()).ToString();
                activeMembers = new List<Models.ActiveMemberModel>();
            }
        }

        private static bool isStoped = false;
        private static List<Models.ActiveMemberModel> activeMembers = new List<Models.ActiveMemberModel>();

        private async void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
            WebView2 wv = new WebView2();
            if (generalSettingsModel.browserType == 1)
            {
                while (isStoped == false)
                {
                    Thread.Sleep(1000);
                    if (isStoped == false)
                    {
                        try
                        {
                            string mainJsString = @"
                    var list=document.getElementsByClassName('WJuYU');
                    var mainList=[];
                    for ( var i=0;i < list.length;i++)
                        {
                            mainList.push( list[i].innerText );
                        }

                    var finalObj=[];
                    for(var i=0;i<mainList.length;i++)
                    {
	                    finalObj.push({
		                    number:mainList[i],
		                    count:    mainList.filter(x=> x==mainList[i]).length
	                    });

                    }

                    var dups = [];

                    var arr = finalObj.filter(function(el) {
                      // If it is not a duplicate, return true
                      if (dups.indexOf(el.number) == -1) {
                        dups.push(el.number);
                        return true;
                      }

                      return false;
  
                    });

                    return JSON.stringify(arr )
                ";

                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                            string jsonstrin = (string)js.ExecuteScript(mainJsString);

                            activeMembers = JsonConvert.DeserializeObject<List<Models.ActiveMemberModel>>(jsonstrin);
                            logger.WriteLog("found : " + activeMembers.Count());

                            IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
                            js2.ExecuteScript(" document.getElementsByClassName('_5kRIK')[0].scrollTop=5");
                        }
                        catch (Exception ex)
                        {

                            logger.WriteLog(ex.Message);
                        }
                    }
                }
            }
            else if (generalSettingsModel.browserType == 2)
            {
                browser.Invoke((MethodInvoker)delegate
                {
                    wv = Utils.GetActiveWebView(browser);
                });

                if (!await WPPHelper.isWPPinjectedAsync(wv))
                {
                    await WPPHelper.InjectWapi(wv, Config.GetSysFolderPath());
                    Thread.Sleep(1000);
                }
                //wAPI_SelectedGroup
                // List<Models.ActiveMemberModel> ActiveMembers=
                activeMembers = await WPPHelper.getChatAndCount(wv, wAPI_SelectedGroup.GroupId);

            }
        }

        private void Initiate()
        {

            if (campaignStatusEnum == CampaignStatusEnum.Stopped || campaignStatusEnum == CampaignStatusEnum.Finish)
            {
                if (activeMembersMain.Count() == 0)
                {
                    Utils.showAlert(Strings.Nothingtoexport, Alerts.Alert.enmType.Warning);
                    logger.WriteLog("Nothing to export");
                }
                else
                {
                    string GroupName = "Multiple_Group";

                    String FolderPath = Config.GetTempFolderPath();
                    String file = Path.Combine(FolderPath, "" + GroupName + "_Members_" + Guid.NewGuid().ToString() + ".xlsx");
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
                        var ws = xlPackage.Workbook.Worksheets[0];
                        ws.Cells[1, 1].Value = "Contact Name";
                        ws.Cells[1, 2].Value = "Total Messages";

                        int i = 1;

                        var nonduplicates = activeMembersMain.GroupBy(x => x.number).Select(y => y.First());
                        foreach (var item in nonduplicates.OrderByDescending(x => x.count))
                        {
                            ws.Cells[i + 1, 1].Value = AutomationCommon.GetNumbers(item.number);
                            if (generalSettingsModel.browserType == 1)
                            {
                                ws.Cells[i + 1, 2].Value = item.count;
                            }
                            else if (generalSettingsModel.browserType == 2)
                            {
                                ws.Cells[i + 1, 2].Value = activeMembersMain.Where(x => x.number == item.number).Count();
                            }
                            contacts1.Numbers.Add(AutomationCommon.GetNumbers(item.number)[0]);
                            contacts1.ContactNames.Add("Group Member " + i.ToString());
                            i++;
                        }
                        xlPackage.Save();
                    }

                    savesampleExceldialog.FileName = GroupName + "_Active_Members.xlsx";
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

                }
            }
        }

        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");


        bool save = false;
        private void materialButton3_Click(object sender, EventArgs e)
        {
            save = true;
            Initiate();
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
