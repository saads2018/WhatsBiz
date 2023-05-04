﻿using FluentValidation.Results;
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
using WASender.Validators;

namespace WASender
{
    public partial class GroupsJoiner : MaterialForm
    {

        InitStatusEnum initStatusEnum;
        System.Windows.Forms.Timer timerInitChecker;
        IWebDriver driver;
        BackgroundWorker worker;
        WaSenderForm waSenderForm;
        CampaignStatusEnum campaignStatusEnum;
        private bool IsPaused = false;
        System.Windows.Forms.Timer timerRunner;
        Logger logger;
        private bool IsStopped = true;


       
        public GroupsJoiner(WaSenderForm _waSenderForm, List<string> links = null)
        {
            InitializeComponent();
            initializeResolution();
            logger = new Logger("GroupJoiner");
            selectedIndex = -1;
            waSenderForm = _waSenderForm;
            if (links != null)
            {
                ImportLinks(links);
            }
            if (Utils.Driver != null)
            {
                Utils.SetDriver();
                driver = Utils.Driver;
                initWA();
            }

        }

        private void initializeResolution()
        {
            /*if (Program.resScale <= 100)
            {
                this.pictureBox1.Width = 57;
                this.pictureBox2.Width = 42;
                this.label3.Left = 293;
                this.materialLabel13.Left = 313;
            }*/
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

        public void LoadFile(GroupContact contact)
        {
                gridTargetsGroup.Rows.Clear();

                var globalCounter = gridTargetsGroup.Rows.Count - 1;

                for (int i = 0; i < contact.ContactNames.Count; i++)
                {
                    try
                    {
                        gridTargetsGroup.Rows.Add();
                        gridTargetsGroup.Rows[globalCounter].Cells[0].Value = contact.GroupID[i];
                        globalCounter++;
                    }
                    catch
                    {

                    }

                }
                button4.Text = "File Loaded";
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

        private void GroupsJoiner_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*logger.Complete();
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
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }*/
        }

        public void ImportLinks(List<string> links)
        {
            foreach (var item in links)
            {
                DataGridViewRow row = (DataGridViewRow)gridTargetsGroup.Rows[0].Clone();
                row.Cells[0].Value = item;
                gridTargetsGroup.Rows.Add(row);
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = Strings.SelectExcel;
            openFileDialog.DefaultExt = "xlsx";
            openFileDialog.Filter = "Excel Files|*.xlsx;";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                FileInfo fi = new FileInfo(file);
                if (fi.Extension != ".xlsx")
                {
                    Utils.showAlert(Strings.PleaseselectExcelfilesformatonly, Alerts.Alert.enmType.Error);
                    return;
                }
                materialButton1.Text = "✔";
                Utils.showAlert("File Uploaded Successfully", Alerts.Alert.enmType.Success);
                button4.Text = "Load From Save";
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(fi))
                {
                    try
                    {
                        gridTargetsGroup.Rows.Clear();
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                        var globalCounter = gridTargetsGroup.Rows.Count - 1;
                        for (int i = 1; i < worksheet.Dimension.Rows; i++)
                        {
                            if (Config.IsDemoMode == true && globalCounter > 5)
                            {
                                Utils.showAlert("You can import only 5 Groups in trial Version", Alerts.Alert.enmType.Error);
                                return;
                            }

                            gridTargetsGroup.Rows.Add();
                            gridTargetsGroup.Rows[globalCounter].Cells[0].Value = worksheet.Cells[i + 1, 2].Value.ToString();
                            globalCounter++;

                        }
                    }
                    catch (Exception ex)
                    {
                        logger.WriteLog(ex.Message);
                        logger.WriteLog(ex.StackTrace);
                        Utils.showAlert(ex.Message, Alerts.Alert.enmType.Error);
                    }
                }
            }
        }


        private void ChangeInitStatus(InitStatusEnum _initStatus)
        {
            this.initStatusEnum = _initStatus;
            logger.WriteLog(_initStatus.ToString());
            AutomationCommon.ChangeInitStatus(_initStatus, lblInitStatus);
        }
        private void ChangeCampStatus(CampaignStatusEnum _campaignStatus)
        {
            logger.WriteLog(_campaignStatus.ToString());
            this.campaignStatusEnum = _campaignStatus;
            AutomationCommon.ChangeCampStatus(_campaignStatus, lblRunStatus);
        }

        private void init()
        {
            logger.WriteLog("init");
            ChangeInitStatus(InitStatusEnum.NotInitialised);
            ChangeCampStatus(CampaignStatusEnum.NotStarted);
            materialCheckbox1.Checked = true;
            materialCheckbox2.Checked = true;
        }


        private void initBackgroundWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            ChangeCampStatus(CampaignStatusEnum.NotStarted);
        }


        private bool isValidLink(string link)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(link, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttps;
            if (result == true)
            {
                if (link.Contains("https://chat.whatsapp.com/"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return result;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = 0;
            int totalCounter = 0;

            foreach (var item in wASenderGroupTransModel.groupList)
            {
                if (IsPaused)
                {
                    while (IsPaused) ;
                }
                if (IsStopped)
                {
                    return;
                }
                try
                {
                    Thread.Sleep(1000);

                    if (!isValidLink(item.Name))
                    {

                        item.sendStatusModel.isDone = true;
                        item.sendStatusModel.sendStatusEnum = SendStatusEnum.NotValidLink;
                        totalCounter++;
                        worker.ReportProgress(totalCounter * 100 / wASenderGroupTransModel.groupList.Count());
                        continue;
                    }

                    string Groupcode = item.Name.Replace("https://chat.whatsapp.com/", "");
                    Groupcode = Groupcode.Replace("invite/", "");

                    if (Config.SendingType == 0)
                    {

                        #region OldLogic

                        try
                        {
                            By hrefHolder1 = By.ClassName("_2-IT7");
                            By hrefHolder2 = By.ClassName("_1y6Yk");
                            By hrefHolder3 = By.ClassName("do8e0lj9");
                            //YtmXM
                            By hrefHolder4 = By.ClassName("YtmXM");
                            if (AutomationCommon.IsElementPresent(hrefHolder1, driver))
                            {
                                logger.WriteLog("hrefHolder1 Found");
                                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                string NavigateJS = "document.getElementsByClassName('_2-IT7')[0].innerHTML=\"\"; ";
                                NavigateJS += "var para = document.createElement(\"div\"); ";
                                NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='https://web.whatsapp.com/accept?code=" + Groupcode + "'>*</a>\"; ";
                                NavigateJS += "document.getElementsByClassName(\"_2-IT7\")[0].appendChild(para); ";
                                NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                                NavigateJS += "link[0].click(); ";
                                js.ExecuteScript(NavigateJS);
                            }
                            else if (AutomationCommon.IsElementPresent(hrefHolder2, driver))
                            {
                                logger.WriteLog("hrefHolder2 Found");
                                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                string NavigateJS = "document.getElementsByClassName('_1y6Yk')[0].innerHTML=\"\"; ";
                                NavigateJS += "var para = document.createElement(\"div\"); ";
                                NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='https://web.whatsapp.com/accept?code=" + Groupcode + "'>*</a>\"; ";
                                NavigateJS += "document.getElementsByClassName(\"_1y6Yk\")[0].appendChild(para); ";
                                NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                                NavigateJS += "link[0].click(); ";
                                js.ExecuteScript(NavigateJS);
                            }
                            else if (AutomationCommon.IsElementPresent(hrefHolder3, driver))
                            {
                                logger.WriteLog("hrefHolder2 Found");
                                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                string NavigateJS = "document.getElementsByClassName('do8e0lj9')[0].innerHTML=\"\"; ";
                                NavigateJS += "var para = document.createElement(\"div\"); ";
                                NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='https://web.whatsapp.com/accept?code=" + Groupcode + "'>*</a>\"; ";
                                NavigateJS += "document.getElementsByClassName(\"do8e0lj9\")[0].appendChild(para); ";
                                NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                                NavigateJS += "link[0].click(); ";
                                js.ExecuteScript(NavigateJS);
                            }
                            else if (AutomationCommon.IsElementPresent(hrefHolder4, driver))
                            {
                                logger.WriteLog("hrefHolder2 Found");
                                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                string NavigateJS = "document.getElementsByClassName('YtmXM')[0].innerHTML=\"\"; ";
                                NavigateJS += "var para = document.createElement(\"div\"); ";
                                NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='https://web.whatsapp.com/accept?code=" + Groupcode + "'>*</a>\"; ";
                                NavigateJS += "document.getElementsByClassName(\"YtmXM\")[0].appendChild(para); ";
                                NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                                NavigateJS += "link[0].click(); ";
                                js.ExecuteScript(NavigateJS);
                            }

                            else
                            {
                                logger.WriteLog("hrefHolder1 or hrefHolder2 not Found");
                                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                js.ExecuteScript("window.location.href='https://web.whatsapp.com/accept?code=" + Groupcode + "'");
                            }
                        }
                        catch (Exception ex)
                        {
                            logger.WriteLog(ex.Message);
                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                            js.ExecuteScript("window.location.href='https://web.whatsapp.com/accept?code=" + Groupcode + "'");
                        }


                        Thread.Sleep(1000);
                        try
                        {
                            By loadingBy = By.XPath("//div[contains(@class, '_1INL_') and contains(@class, '_1iyey') and contains(@class, '_2FX6G') and contains(@class, '_1UG2S') ]");

                            bool IsLoading = AutomationCommon.IsElementPresent(loadingBy, driver);
                            if (IsLoading == true)
                            {
                                logger.WriteLog("Loading Found");
                                AutomationCommon.WaitUntilElementDispose(driver, loadingBy, 500);
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                        try
                        {
                            By retryingBy = By.XPath("//div[contains(@class, 'tvf2evcx') and contains(@class, 'm0h2a7mj') and contains(@class, 'lb5m6g5c') and contains(@class, 'j7l1k36l') and contains(@class, 'ktfrpxia') and contains(@class, 'nu7pwgvd') and contains(@class, 'gjuq5ydh') ]");
                            bool IsRetrying = AutomationCommon.IsElementPresent(retryingBy, driver);

                            if (IsRetrying == true)
                            {
                                var retryEltxt = driver.FindElements(retryingBy);
                                foreach (var retryEl in retryEltxt)
                                {
                                    if (retryEl.Text == "RETRY NOW")
                                    {
                                        AutomationCommon.WaitUntilElementDispose(driver, retryingBy, 500, true, "Retry Now");
                                    }
                                }

                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            bool IsSearching = AutomationCommon.IsElementPresent(By.ClassName("_3J6wB"), driver);

                            if (IsSearching == true)
                            {
                                //  AutomationCommon.WaitUntilElementDispose(driver, By.ClassName("_3J6wB"), 500);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        AutomationCommon.checkConnection(driver);
                        AutomationCommon.isLoadingWeb(driver);

                        // f8jlpxt4 r5qsrrlp hp667wtd i0jNr
                        By CheckingLinkBy = By.XPath("//div[contains(@class, 'f8jlpxt4') and contains(@class, 'r5qsrrlp') and contains(@class, 'hp667wtd') and contains(@class, 'i0jNr') ]");
                        if (AutomationCommon.IsElementPresent(CheckingLinkBy, driver))
                        {
                            logger.WriteLog("CheckingLinkBy Found");
                            IWebElement CheckingLink = driver.FindElement(CheckingLinkBy);
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            logger.WriteLog("CheckingLinkBy Not Found");
                        }
                        Thread.Sleep(1000);
                        AutomationCommon.checkConnection(driver);
                        AutomationCommon.isLoadingWeb(driver);
                        By participantsBy = By.ClassName("_124as");



                        By participantsIsContactBy = By.ClassName("tviruh8d");
                        int Totalparticipants = 0;
                        if (AutomationCommon.IsElementPresent(participantsBy, driver))
                        {
                            logger.WriteLog("participantsBy found");
                            string participantsStr = driver.FindElement(participantsBy).Text;
                            var splitter = participantsStr.Split(new string[] { " " }, StringSplitOptions.None);
                            Totalparticipants = Convert.ToInt32(splitter[0].Trim());
                        }
                        else if (AutomationCommon.IsElementPresent(participantsIsContactBy, driver))
                        {
                            logger.WriteLog("participantsIsContactBy found");
                            string participantsStr = driver.FindElement(participantsIsContactBy).Text;
                            var splitter = participantsStr.Split(new string[] { " " }, StringSplitOptions.None);
                            Totalparticipants = Convert.ToInt32(splitter[0].Trim());
                        }

                        By participantsBySecond = By.ClassName("_3y4nr");
                        if (Totalparticipants == 0)
                        {
                            if (AutomationCommon.IsElementPresent(participantsBySecond, driver))
                            {
                                logger.WriteLog("participantsBySecond found");
                                string participantsStr = driver.FindElement(participantsBySecond).Text;
                                var splitter = participantsStr.Split(new string[] { " " }, StringSplitOptions.None);
                                Totalparticipants = Convert.ToInt32(splitter[0].Trim());
                            }
                            else if (AutomationCommon.IsElementPresent(participantsIsContactBy, driver))
                            {
                                logger.WriteLog("participantsIsContactBy found");
                                string participantsStr = driver.FindElement(participantsIsContactBy).Text;
                                var splitter = participantsStr.Split(new string[] { " " }, StringSplitOptions.None);
                                Totalparticipants = Convert.ToInt32(splitter[0].Trim());
                            }
                        }

                        logger.WriteLog("Totalparticipants = " + Totalparticipants);
                        if (Totalparticipants > 0)
                        {

                            if (Totalparticipants == 512)
                            {
                                logger.WriteLog("Totalparticipants == 512");
                                item.sendStatusModel.isDone = true;
                                item.sendStatusModel.sendStatusEnum = SendStatusEnum.GroupFull;
                                totalCounter++;
                                worker.ReportProgress(totalCounter * 100 / wASenderGroupTransModel.groupList.Count());
                                continue;
                            }
                            AutomationCommon.checkConnection(driver);
                            By JoinGroupBY = By.XPath("//*[@id=\"app\"]/div[1]/span[2]/div[1]/div/div/div/div/div/div[2]/div/div[2]/div/div");


                            if (!AutomationCommon.IsElementPresent(JoinGroupBY, driver))
                            {
                                logger.WriteLog("JoinGroupButton Is NOT Present -1 ");
                                Thread.Sleep(1000);
                                if (!AutomationCommon.IsElementPresent(JoinGroupBY, driver))
                                {
                                    logger.WriteLog("JoinGroupButton Is NOT Present -2 ");
                                    Thread.Sleep(1000);
                                    if (!AutomationCommon.IsElementPresent(JoinGroupBY, driver))
                                    {
                                        logger.WriteLog("JoinGroupButton Is NOT Present -3 ");
                                        Thread.Sleep(1000);
                                    }
                                }
                            }

                            if (AutomationCommon.IsElementPresent(JoinGroupBY, driver))
                            {

                                logger.WriteLog("JoinGroupButton Is Present");
                                Thread.Sleep(1000);

                                IWebElement JoinGroupButton = driver.FindElement(JoinGroupBY);

                                string text = JoinGroupButton.Text;
                                logger.WriteLog("JoinGroupButton Text=" + text);
                                if (text != "")
                                {
                                    JoinGroupButton.Click();
                                    logger.WriteLog("JoinGroupButton Clicked");
                                    Thread.Sleep(1000);
                                    if (AutomationCommon.IsElementPresent(JoinGroupBY, driver))
                                    {
                                        logger.WriteLog("JoinGroupButton Is Present");
                                        try
                                        {
                                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                            js.ExecuteScript("document.getElementsByClassName('_2Zdgs')[0].click()");
                                            Thread.Sleep(500);
                                            logger.WriteLog("JS Executed");
                                        }
                                        catch (Exception ex)
                                        {
                                            logger.WriteLog("JS execution error" + ex.Message);
                                        }

                                        if (AutomationCommon.IsElementPresent(JoinGroupBY, driver))
                                        {
                                            logger.WriteLog("JoinGroupButton Is Present");
                                        }
                                    }

                                    Thread.Sleep(Utils.getRandom(wASenderGroupTransModel.settings.delayAfterEveryMessageFrom * 1000, wASenderGroupTransModel.settings.delayAfterEveryMessageTo * 1000));
                                    counter++;

                                    if (wASenderGroupTransModel.settings.delayAfterMessages == counter)
                                    {
                                        counter = 0;
                                        Thread.Sleep(Utils.getRandom(wASenderGroupTransModel.settings.delayAfterMessagesFrom * 1000, wASenderGroupTransModel.settings.delayAfterMessagesFrom * 1000));
                                    }
                                }
                                else
                                {
                                    item.sendStatusModel.isDone = true;
                                    item.sendStatusModel.sendStatusEnum = SendStatusEnum.Failed;
                                    totalCounter++;
                                    worker.ReportProgress(totalCounter * 100 / wASenderGroupTransModel.groupList.Count());
                                    continue;
                                }



                            }
                            else
                            {
                                logger.WriteLog("JoinGroupButton Is NOT Present");
                            }


                        }
                        else
                        {
                            item.sendStatusModel.isDone = true;
                            item.sendStatusModel.sendStatusEnum = SendStatusEnum.Failed;
                            totalCounter++;
                            worker.ReportProgress(totalCounter * 100 / wASenderGroupTransModel.groupList.Count());
                            continue;
                        }



                        #endregion
                    }
                    else
                    {
                        try
                        {
                            logger.WriteLog("initing WAPI");
                            WAPIHelper.IsWAPIInjected(driver);
                        }
                        catch (Exception ex)
                        {
                            string ss = "";
                            logger.WriteLog(ex.Message);
                            //MessageBox.Show(ex.Message);
                        }

                        if (!WAPIHelper.IsWAPIInjected(driver))
                        {
                            ProjectCommon.injectWapi(driver);
                        }
                        try
                        {
                            bool isJoined = WAPIHelper.JoinGroup(driver, Groupcode.Trim());
                            item.sendStatusModel.isDone = true;
                            if (isJoined == true)
                            {
                                item.sendStatusModel.sendStatusEnum = SendStatusEnum.Success;
                            }
                            else
                            {
                                item.sendStatusModel.sendStatusEnum = SendStatusEnum.Failed;
                            }

                            // totalCounter++;
                            worker.ReportProgress(totalCounter * 100 / wASenderGroupTransModel.groupList.Count());

                            Thread.Sleep(Utils.getRandom(wASenderGroupTransModel.settings.delayAfterEveryMessageFrom * 1000, wASenderGroupTransModel.settings.delayAfterEveryMessageTo * 1000));
                            if (wASenderGroupTransModel.settings.delayAfterMessages == counter)
                            {
                                counter = 0;
                                Thread.Sleep(Utils.getRandom(wASenderGroupTransModel.settings.delayAfterMessagesFrom * 1000, wASenderGroupTransModel.settings.delayAfterMessagesFrom * 1000));
                            }
                        }
                        catch (Exception ex)
                        {
                            item.sendStatusModel.isDone = true;
                            item.sendStatusModel.sendStatusEnum = SendStatusEnum.Failed;
                            totalCounter++;
                            worker.ReportProgress(totalCounter * 100 / wASenderGroupTransModel.groupList.Count());
                            continue;
                        }


                    }





                }
                catch (Exception ex)
                {
                    logger.WriteLog(ex.Message);
                    item.sendStatusModel.isDone = true;
                    item.sendStatusModel.sendStatusEnum = SendStatusEnum.Failed;
                    //totalCounter++;
                    worker.ReportProgress(totalCounter * 100 / wASenderGroupTransModel.groupList.Count());
                    continue;
                }

                totalCounter++;

                var __count = wASenderGroupTransModel.groupList.Count();
                var _percentage = totalCounter * 100 / __count;
                item.sendStatusModel.isDone = true;
                item.sendStatusModel.sendStatusEnum = SendStatusEnum.Success;
                worker.ReportProgress(_percentage);
            }

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ChangeCampStatus(CampaignStatusEnum.Finish);
            AutomationCommon.GenerateReport(this.wASenderGroupTransModel);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
/*            lblPersentage.Text = e.ProgressPercentage + "% " + Strings.Completed;
*/        }


        private void btnInitWA_Click(object sender, EventArgs e)
        {
            initWA();
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
                    logger.WriteLog("isElementDisplayed = true");
                    ChangeInitStatus(InitStatusEnum.Initialised);
                    timerInitChecker.Stop();
                    initBackgroundWorker();
                    Activate();
                }
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex.Message);
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

        private void btnSTart_Click(object sender, EventArgs e)
        {
            if (campaignStatusEnum == CampaignStatusEnum.Finish)
            {
                gridStatus.Rows.Clear();
            }
            if (campaignStatusEnum == CampaignStatusEnum.Paused)
            {
                IsPaused = false;
                ChangeCampStatus(CampaignStatusEnum.Running);
                startProgressBar();
            }
            else
            {
                ValidateControlsGroup();
            }
        }
        WASenderGroupTransModel wASenderGroupTransModel;
        private void ValidateControlsGroup()
        {
            wASenderGroupTransModel = new WASenderGroupTransModel();
            wASenderGroupTransModel.groupList = new List<GroupModel>();
            GroupModel group = new GroupModel();
            if (initStatusEnum != InitStatusEnum.Initialised)
            {
                Utils.showAlert(Strings.PleaseFollowStepnoThree, Alerts.Alert.enmType.Error);
                return;
            }

            for (int i = 0; i < gridTargetsGroup.Rows.Count; i++)
            {
                if (!(gridTargetsGroup.Rows[i].Cells[0].Value == null))
                {
                    group = new GroupModel
                    {
                        Name = gridTargetsGroup.Rows[i].Cells[0].Value == null ? "" : gridTargetsGroup.Rows[i].Cells[0].Value.ToString(),
                        sendStatusModel = new SendStatusModel { isDone = false }
                    };

                    group.validationFailures = new GroupModelValidator().Validate(group).Errors;
                    wASenderGroupTransModel.groupList.Add(group);
                }
            }

            wASenderGroupTransModel.validationFailures = new WASenderGroupTransModelValidator(true).Validate(wASenderGroupTransModel).Errors;


            wASenderGroupTransModel.settings = new SingleSettingModel();
            wASenderGroupTransModel.settings.delayAfterMessages = 10;
            wASenderGroupTransModel.settings.delayAfterMessagesFrom = Convert.ToInt32(txtdelayAfterMessagesFrom.Text);
            wASenderGroupTransModel.settings.delayAfterMessagesTo = Convert.ToInt32(txtdelayAfterMessagesTo.Text);
            wASenderGroupTransModel.settings.delayAfterEveryMessageFrom = Convert.ToInt32(txtdelayAfterEveryMessageFrom.Text);
            wASenderGroupTransModel.settings.delayAfterEveryMessageTo = Convert.ToInt32(txtdelayAfterEveryMessageTo.Text);

            wASenderGroupTransModel.settings.validationFailures = new SingleSettingModelValidator().Validate(wASenderGroupTransModel.settings).Errors;

            if (showValidationErrorIfAnyGroup())
            {
                if (campaignStatusEnum != CampaignStatusEnum.Running)
                {
                    IsStopped = false;
                    worker.RunWorkerAsync();
                    ChangeCampStatus(CampaignStatusEnum.Running);
                    startProgressBar();
                    initTimer();
                }
            }
            else
            {

            }

        }

        private void startProgressBar()
        {
            progressBar1.Show();
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
        }
        private void stopProgressbar()
        {
            progressBar1.Hide();
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.MarqueeAnimationSpeed = 0;
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
            try
            {
                int i = 1;
                foreach (var item in wASenderGroupTransModel.groupList)
                {
                    if (item.sendStatusModel.isDone == true && item.logged == false)
                    {
                        var globalCounter = gridStatus.Rows.Count - 1;
                        gridStatus.Rows.Add();
                        gridStatus.Rows[globalCounter].Cells[0].Value = item.Name;
                        gridStatus.Rows[globalCounter].Cells[1].Value = item.sendStatusModel.sendStatusEnum;

                        gridStatus.FirstDisplayedScrollingRowIndex = gridStatus.RowCount - 1;
                        item.logged = true;

                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private bool showValidationErrorIfAnyGroup()
        {
            bool validationFail = true;
            if (CheckValidationMessage(wASenderGroupTransModel.validationFailures))
            {
                if (CheckValidationMessage(wASenderGroupTransModel.settings.validationFailures))
                {
                    for (int i = 0; i < wASenderGroupTransModel.groupList.Count(); i++)
                    {
                        if (CheckValidationMessage(wASenderGroupTransModel.groupList[i].validationFailures, Strings.RowNo + "- " + Convert.ToString(i + 1)))
                        {
                            string ss = "";
                        }
                        else
                        {
                            i = wASenderGroupTransModel.groupList.Count;
                            validationFail = false;
                        }
                    }
                }
                else
                {
                    validationFail = false;
                }
            }
            else
            {
                validationFail = false;
            }
            return validationFail;
        }

        private bool CheckValidationMessage(IList<ValidationFailure> validationFailures, string AdditionalMessage = "")
        {
            string Messages = "";
            if (validationFailures != null && validationFailures.Count() > 0)
            {
                foreach (var item in validationFailures)
                {
                    Messages = Messages + item.ErrorMessage + "\n\n";
                }
            }
            if (Messages == "")
            {
                return true;
            }
            else
            {
                MessageBox.Show(AdditionalMessage + " " + Messages, Strings.Errors, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void GroupsJoiner_Load(object sender, EventArgs e)
        {
            init();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.Text = Strings.GroupsJoiner;
/*            materialButton1.Text = Strings.UploadSampleExcel;
*/            /*De.Text = Strings.DelaySettings;
            materialLabel3.Text = Strings.Wait;
            materialLabel9.Text = Strings.Wait;
            materialLabel4.Text = Strings.to;
            materialLabel8.Text = Strings.to;
            materialLabel5.Text = Strings.secondsafterevery;
            materialLabel6.Text = Strings.GroupJoin;
            materialLabel7.Text = Strings.secondsbeforeeveryGroupJoin;
            materialLabel2.Text = Strings.InitiateWhatsAppScaneQRCodefromyourrmobile;*/
            label5.Text = Strings.Status;
            label7.Text = Strings.Status;
            btnInitWA.Text = Strings.ClicktoInitiate;
/*            btnSTart.Text = Strings.StartJoining;
*/           /* button3.Text = Strings.Pause;
            button2.Text = Strings.Stop;*/

            gridTargetsGroup.Columns[0].HeaderText = Strings.GroupLink;
            gridStatus.Columns[0].HeaderText = Strings.ChatName;
            gridStatus.Columns[1].HeaderText = Strings.Status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GroupsJoiner_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger.Complete();
            try
            {
                IsStopped = true;
                worker.CancelAsync();
                worker.Dispose();
            }
            catch (Exception ex)
            {

            }
            //try
            //{
            //    driver.Quit();
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IsPaused = true;
            ChangeCampStatus(CampaignStatusEnum.Paused);
            stopProgressbar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopProgressbar();
            IsStopped = true;
            IsPaused = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadLinks();
        }

        private Bitmap FormFade()
        {

            Bitmap bmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                G.CopyFromScreen(this.PointToScreen(new Point(0, 0)), new Point(0, 0), this.ClientRectangle.Size);
                double percent = 0.60;
                Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
                using (Brush brsh = new SolidBrush(darken))
                {
                    G.FillRectangle(brsh, this.ClientRectangle);
                }
            }
            return bmp;
        }
        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");

        private void LoadLinks()
        {
            string fileData = File.ReadAllText(fileSaves + "\\" + "GroupLinks.json");

            List<GroupContact> contacts = new List<GroupContact>();

            if (!String.IsNullOrWhiteSpace(fileData))
                contacts = JsonConvert.DeserializeObject<List<GroupContact>>(fileData);

            if (contacts == null)
            {
                MessageBox.Show("No Contacts Saved Yet, Please Upload An Excel File To Save A Contact List!");
            }
            else
            {
                selectedIndex = -1;
                using (Panel p = new Panel())
                {
                    p.Location = new Point(0, 0);
                    p.Size = this.ClientRectangle.Size;
                    p.BackgroundImage = FormFade();
                    this.Controls.Add(p);
                    p.BringToFront();

                    ChooseGroup chooseGroup = new ChooseGroup(this, "links");
                    chooseGroup.ShowDialog();
                    this.Refresh();
                }


                if (selectedIndex != -1)
                {
                    gridTargetsGroup.Rows.Clear();
                    GroupContact contact = contacts[selectedIndex];
                    var globalCounter = gridTargetsGroup.Rows.Count - 1;

                    for (int i = 0; i < contact.ContactNames.Count; i++)
                    {
                        try
                        {
                            gridTargetsGroup.Rows.Add();
                            gridTargetsGroup.Rows[globalCounter].Cells[0].Value = contact.GroupID[i];
                            globalCounter++;
                        }
                        catch
                        {

                        }

                    }
                    Utils.showAlert("File Loaded Successfully", Alerts.Alert.enmType.Success);
                    button4.Text = "File Loaded";
                    materialButton1.Text = "📂";
                }

            }
        }

        private int selectedIndex;
        public void Return(int index)
        {
            selectedIndex = index;
        }

    }
}
