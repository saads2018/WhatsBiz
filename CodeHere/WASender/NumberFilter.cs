using FluentValidation.Results;
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
    public partial class NumberFilter : MaterialForm
    {

        InitStatusEnum initStatusEnum;
        System.Windows.Forms.Timer timerInitChecker;
        IWebDriver driver;
        BackgroundWorker worker;
        WaSenderForm waSenderForm;
        CampaignStatusEnum campaignStatusEnum;
        System.Windows.Forms.Timer timerRunner;
        Logger logger;
        private bool IsStopped = true;
        private bool IsPaused = false;
        MainNavPage mainNavPage;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        public NumberFilter(WaSenderForm _waSenderForm, MainNavPage mainNavPage)
        {
            InitializeComponent();
            initializeResolution();
            logger = new Logger("NumberFilter");
            waSenderForm = _waSenderForm;
            selectedIndex = -1;
            if (Utils.Driver != null)
            {
                Utils.SetDriver();
                driver = Utils.Driver;
                initWA();
            }

            this.mainNavPage = mainNavPage;
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

        public void init()
        {
            logger.WriteLog("init");
            ChangeInitStatus(InitStatusEnum.NotInitialised);
            ChangeCampStatus(CampaignStatusEnum.NotStarted);
            materialCheckbox1.Checked = true;
            materialCheckbox2.Checked = true;
        }

        private void InitLanguage()
        {
            this.Text = Strings.WhatsAppNumberFilter;
/*            materialButton1.Text = Strings.UploadSampleExcel;
*/        /*    De.Text = Strings.DelaySettings;
            materialLabel3.Text = Strings.Wait;
            materialLabel9.Text = Strings.Wait;
            materialLabel4.Text = Strings.to;
            materialLabel8.Text = Strings.to;
            materialLabel5.Text = Strings.secondsafterevery;
            materialLabel6.Text = Strings.NumberCheck;
            materialLabel7.Text = Strings.secondsbeforeeveryNumberCheck;
            materialLabel2.Text = Strings.InitiateWhatsAppScaneQRCodefromyourrmobile;*/
            label5.Text = Strings.Status;
            label7.Text = Strings.Status;
            btnInitWA.Text = Strings.ClicktoInitiate;
/*            btnSTart.Text = Strings.StartChecking;
*/            /*button3.Text = Strings.Pause;
            button2.Text = Strings.Stop;*/

            gridTargetsGroup.Columns[0].HeaderText = Strings.Number;
            gridStatus.Columns[1].HeaderText = Strings.Number;
            gridStatus.Columns[2].HeaderText = Strings.Status;
        }

        private void NumberFilter_FormClosing(object sender, FormClosingEventArgs e)
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
            /*foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }*/
        }

        private void NumberFilter_Load(object sender, EventArgs e)
        {
            init();
            InitLanguage();
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
                            gridTargetsGroup.Rows[globalCounter].Cells[0].Value = worksheet.Cells[i + 1, 1].Value.ToString();
                            gridTargetsGroup.Rows[globalCounter].Cells[1].Value = worksheet.Cells[i + 1, 2].Value.ToString();
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

        static string msg = "";
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = 0;
            int totalCounter = 0;

            logger.WriteLog("Started Checking");


            //else if (Config.SendingType == 1)
            //        {

            //            if (!WAPIHelper.IsWAPIInjected(driver))
            //            {
            //                WAPIHelper.injectWapi(driver);
            //            }

            //        }

            if (Config.SendingType == 0)
            {
                #region "OldLOgic"
                foreach (var item in wASenderGroupTransModel.contactList)
                {
                    try
                    {
                        By hrefHolder1 = By.ClassName("_2-IT7");
                        By hrefHolder2 = By.ClassName("_1y6Yk");
                        if (AutomationCommon.IsElementPresent(hrefHolder1, driver))
                        {
                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                            string NavigateJS = "document.getElementsByClassName('_2-IT7')[0].innerHTML=\"\"; ";
                            NavigateJS += "var para = document.createElement(\"div\"); ";
                            NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='http://wa.me/" + item.number + "'>*</a>\"; ";
                            NavigateJS += "document.getElementsByClassName(\"_2-IT7\")[0].appendChild(para); ";
                            NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                            NavigateJS += "link[0].click(); ";
                            js.ExecuteScript(NavigateJS);
                        }
                        else if (AutomationCommon.IsElementPresent(hrefHolder2, driver))
                        {
                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                            string NavigateJS = "document.getElementsByClassName('_1y6Yk')[0].innerHTML=\"\"; ";
                            NavigateJS += "var para = document.createElement(\"div\"); ";
                            NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='http://wa.me/" + item.number + "'>*</a>\"; ";
                            NavigateJS += "document.getElementsByClassName(\"_1y6Yk\")[0].appendChild(para); ";
                            NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                            NavigateJS += "link[0].click(); ";
                            js.ExecuteScript(NavigateJS);
                        }
                        else
                        {
                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                            js.ExecuteScript("window.location.href='https://web.whatsapp.com/send?phone=" + item.number + "&text&app_absent=0'");
                        }

                        Thread.Sleep(1000);

                        try
                        {
                            By loadingBy = By.XPath("//div[contains(@class, '_1INL_') and contains(@class, '_1iyey') and contains(@class, '_2FX6G') and contains(@class, '_1UG2S') ]");

                            bool IsLoading = AutomationCommon.IsElementPresent(loadingBy, driver);
                            if (IsLoading == true)
                            {
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
                            bool IsSearching = AutomationCommon.IsElementPresent(By.ClassName("_3_EXz"), driver);

                            if (IsSearching == true)
                            {
                                AutomationCommon.WaitUntilElementDispose(driver, By.ClassName("_3_EXz"), 500);
                            }
                            AutomationCommon.checkConnection(driver);

                            if (true == true)
                            {
                                // AutomationCommon.WaitUntilElementDispose(driver, By.ClassName("_3_EXz"), 500);

                                By NumberInvalidBox = By.ClassName("_2Nr6U");
                                if (AutomationCommon.IsElementPresent(NumberInvalidBox, driver))
                                {
                                    By OkButtonBy = By.ClassName("_20C5O");
                                    if (AutomationCommon.IsElementPresent(OkButtonBy, driver))
                                    {
                                        driver.FindElement(OkButtonBy).Click();

                                        item.sendStatusModel.isDone = true;
                                        item.sendStatusModel.sendStatusEnum = SendStatusEnum.NotAvailable;
                                        counter++;
                                        totalCounter++;

                                        var _count = wASenderGroupTransModel.contactList.Count();
                                        var percentage = totalCounter * 100 / _count;
                                        worker.ReportProgress(percentage);
                                        // continue;
                                    }
                                }
                                else
                                {
                                    AutomationCommon.checkConnection(driver);
                                    By messageTextBoxBy = By.XPath("//*[@id='main']/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[2]");
                                    IWebElement messageTextBox = driver.FindElement(messageTextBoxBy);
                                    if (!AutomationCommon.IsElementPresent(messageTextBoxBy, driver))
                                    {
                                        item.sendStatusModel.isDone = true;
                                        item.sendStatusModel.sendStatusEnum = SendStatusEnum.NotAvailable;
                                        counter++;
                                        totalCounter++;

                                        var _count = wASenderGroupTransModel.contactList.Count();
                                        var percentage = totalCounter * 100 / _count;
                                        worker.ReportProgress(percentage);

                                    }
                                    else
                                    {
                                        item.sendStatusModel.isDone = true;
                                        item.sendStatusModel.sendStatusEnum = SendStatusEnum.Available;
                                        counter++;
                                        totalCounter++;

                                        var _count = wASenderGroupTransModel.contactList.Count();
                                        var percentage = totalCounter * 100 / _count;
                                        worker.ReportProgress(percentage);

                                        try
                                        {
                                            By menuBy = By.XPath("//*[@id='main']/header/div[3]/div/div[2]/div/div");
                                            By meuBySecond = By.XPath("//*[@id='main']/header/div[3]/div/div[3]/div/div/span");


                                            if (AutomationCommon.IsElementPresent(menuBy, driver))
                                            {
                                                IWebElement menu = driver.FindElement(menuBy);
                                                menu.Click();
                                            }
                                            else if (AutomationCommon.IsElementPresent(meuBySecond, driver))
                                            {
                                                IWebElement menu = driver.FindElement(meuBySecond);
                                                menu.Click();
                                            }

                                            Thread.Sleep(500);

                                            IWebElement menuHolder = driver.FindElement(By.CssSelector("[data-testid='contact-menu-dropdown']"));

                                            var lis = menuHolder.FindElements(By.ClassName("_2qR8G"));
                                            if (lis.Count() == 6)
                                            {
                                                lis[2].Click();
                                            }
                                            else if (lis.Count() == 9)
                                            {
                                                lis[5].Click();
                                            }
                                            else if (lis.Count() == 8)
                                            {
                                                lis[4].Click();
                                            }
                                            else if (lis.Count() == 7)
                                            {
                                                lis[2].Click();
                                            }
                                            else
                                            {
                                                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                                js.ExecuteScript("window.location.href=''");
                                            }

                                            By prifileBy = By.XPath("//*[@class='_1PzAL']");
                                            if (AutomationCommon.IsElementPresent(prifileBy, driver))
                                            {
                                                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                                js.ExecuteScript("window.location.href=''");
                                            }

                                        }
                                        catch (Exception Ex)
                                        {
                                            string ss = "";
                                        }

                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        Thread.Sleep(Utils.getRandom(wASenderGroupTransModel.settings.delayAfterEveryMessageFrom * 1000, wASenderGroupTransModel.settings.delayAfterEveryMessageTo * 1000));
                        counter++;

                        if (wASenderGroupTransModel.settings.delayAfterMessages == counter)
                        {
                            counter = 0;
                            Thread.Sleep(Utils.getRandom(wASenderGroupTransModel.settings.delayAfterMessagesFrom * 1000, wASenderGroupTransModel.settings.delayAfterMessagesFrom * 1000));
                        }


                    }
                    catch (Exception ex2)
                    {
                        item.sendStatusModel.isDone = true;
                        item.sendStatusModel.sendStatusEnum = SendStatusEnum.NotAvailable;
                        counter++;
                        totalCounter++;

                        var _count = wASenderGroupTransModel.contactList.Count();
                        var percentage = totalCounter * 100 / _count;
                        worker.ReportProgress(percentage);
                    }
                }
                #endregion
            }
            else if (Config.SendingType == 1)
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
                    msg = ex.Message;
                    //MessageBox.Show(ex.Message);
                }

                if (!WAPIHelper.IsWAPIInjected(driver))
                {
                    ProjectCommon.injectWapi(driver);
                }

                foreach (var item in wASenderGroupTransModel.contactList)
                {
                    if (IsPaused)
                    {
                        while (IsPaused) ;
                    }
                    if (IsStopped)
                    {
                        return;
                    }

                    item.number = item.number.Replace("+", "");
                    item.number = item.number.Replace(" ", "");

                    if (WAPIHelper.validateNumber(driver, item.number) == true)
                    {
                        item.sendStatusModel.isDone = true;
                        item.sendStatusModel.sendStatusEnum = SendStatusEnum.Available;
                    }
                    else
                    {
                        item.sendStatusModel.isDone = true;
                        item.sendStatusModel.sendStatusEnum = SendStatusEnum.NotAvailable;
                    }
                    counter++;
                    totalCounter++;

                    var _count = wASenderGroupTransModel.contactList.Count();
                    var percentage = totalCounter * 100 / _count;
                    worker.ReportProgress(percentage);


                    Thread.Sleep(Utils.getRandom(wASenderGroupTransModel.settings.delayAfterEveryMessageFrom * 1000, wASenderGroupTransModel.settings.delayAfterEveryMessageTo * 1000));
                    counter++;

                    if (wASenderGroupTransModel.settings.delayAfterMessages == counter)
                    {
                        counter = 0;
                        Thread.Sleep(Utils.getRandom(wASenderGroupTransModel.settings.delayAfterMessagesFrom * 1000, wASenderGroupTransModel.settings.delayAfterMessagesFrom * 1000));
                    }
                }

            }




        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
/*            lblPersentage.Text = e.ProgressPercentage + "% " + Strings.Completed;
*/        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ChangeCampStatus(CampaignStatusEnum.Finish);
            stopProgressbar();
            //if (msg != "")
            //{l
            //    MessageBox.Show(msg);
            //}
            // AutomationCommon.GenerateReport(this.wASenderGroupTransModel);

            String FolderPath = Config.GetTempFolderPath();
            String file = Path.Combine(FolderPath, "Number_Filter_" + Guid.NewGuid().ToString() + ".xlsx");
            string NewFileName = file.ToString();
            File.Copy("MemberListTemplate.xlsx", NewFileName, true);
            var newFile = new FileInfo(NewFileName);

            string fileData = File.ReadAllText(fileSaves + "\\" + "IndividualContacts.json");

            List<IndividualContacts> contacts = new List<IndividualContacts>();

            if (!String.IsNullOrWhiteSpace(fileData))
                contacts = JsonConvert.DeserializeObject<List<IndividualContacts>>(fileData);

            IndividualContacts contacts1 = new IndividualContacts();
            contacts1.ContactNames = new List<string>();
            contacts1.Numbers = new List<string>();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                contacts1.Name = materialButton1.Text.Replace(".xlsx", "")+"_Filtered";

                var ws = xlPackage.Workbook.Worksheets[0];

                for (int i = 0; i < wASenderGroupTransModel.contactList.Count(); i++)
                {
                    ws.Cells[i + 1, 1].Value = wASenderGroupTransModel.contactList[i].number;
                    ws.Cells[i + 1, 2].Value = wASenderGroupTransModel.contactList[i].sendStatusModel.sendStatusEnum;
                    contacts1.ContactNames.Add(wASenderGroupTransModel.contactList[i].name);
                    contacts1.Numbers.Add(wASenderGroupTransModel.contactList[i].number);
                }
                xlPackage.Save();
            }

            contacts.Add(contacts1);
            string Json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);
            Utils.showAlert("File Saved Successfully", Alerts.Alert.enmType.Success);


            savesampleExceldialog.FileName = "NumberFilter.xlsx";
            if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(NewFileName, savesampleExceldialog.FileName.EndsWith(".xlsx") ? savesampleExceldialog.FileName : savesampleExceldialog.FileName + ".xlsx", true);
                Utils.showAlert(Strings.Filedownloadedsuccessfully, Alerts.Alert.enmType.Success);
            }
        }

        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");

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


        WASenderSingleTransModel wASenderGroupTransModel;

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


        private bool showValidationErrorIfAnyGroup()
        {
            bool validationFail = true;
            if (CheckValidationMessage(wASenderGroupTransModel.validationFailures))
            {
                if (CheckValidationMessage(wASenderGroupTransModel.settings.validationFailures))
                {
                    for (int i = 0; i < wASenderGroupTransModel.contactList.Count(); i++)
                    {
                        if (CheckValidationMessage(wASenderGroupTransModel.contactList[i].validationFailures, Strings.RowNo + "- " + Convert.ToString(i + 1)))
                        {
                            string ss = "";
                        }
                        else
                        {
                            i = wASenderGroupTransModel.contactList.Count;
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

        private void ValidateControlsGroup()
        {
            wASenderGroupTransModel = new WASenderSingleTransModel();
            wASenderGroupTransModel.contactList = new List<ContactModel>();
            ContactModel contact;
            if (initStatusEnum != InitStatusEnum.Initialised)
            {
                Utils.showAlert(Strings.PleaseFollowStepnoThree, Alerts.Alert.enmType.Error);
                return;
            }

            for (int i = 0; i < gridTargetsGroup.Rows.Count; i++)
            {
                if (!(gridTargetsGroup.Rows[i].Cells[0].Value == null))
                {
                    contact = new ContactModel
                    {
                        number = gridTargetsGroup.Rows[i].Cells[0].Value == null ? "" : gridTargetsGroup.Rows[i].Cells[0].Value.ToString(),
                        name = gridTargetsGroup.Rows[i].Cells[1].Value == null ? "" : gridTargetsGroup.Rows[i].Cells[1].Value.ToString(),
                        sendStatusModel = new SendStatusModel { isDone = false }
                    };

                    contact.validationFailures = new ContactModelValidator().Validate(contact).Errors;
                    wASenderGroupTransModel.contactList.Add(contact);
                }
            }

            wASenderGroupTransModel.messages = new List<MesageModel>();
            wASenderGroupTransModel.messages.Add(new MesageModel
            {
                longMessage = "dfg"
            });
            wASenderGroupTransModel.validationFailures = new WASenderSingleTransModelValidator().Validate(wASenderGroupTransModel).Errors;

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
                foreach (var item in wASenderGroupTransModel.contactList)
                {
                    if (item.sendStatusModel.isDone == true && item.logged == false)
                    {
                        var globalCounter = gridStatus.Rows.Count - 1;
                        gridStatus.Rows.Add();
                        gridStatus.Rows[globalCounter].Cells[0].Value = gridStatus.Rows.Count.ToString();
                        gridStatus.Rows[globalCounter].Cells[1].Value = item.number;
                        gridStatus.Rows[globalCounter].Cells[2].Value = item.sendStatusModel.sendStatusEnum;

                        gridStatus.FirstDisplayedScrollingRowIndex = gridStatus.RowCount - 1;
                        item.logged = true;
                        i = i + 1;
                    }
                }

            }
            catch (Exception ex)
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
        private void materialButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(WAPIHelper.GetName());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            LoadContacts();
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

        private void LoadContacts()
        {
            string fileData = File.ReadAllText(fileSaves + "\\" + "IndividualContacts.json");

            List<IndividualContacts> contacts = new List<IndividualContacts>();

            if (!String.IsNullOrWhiteSpace(fileData))
                contacts = JsonConvert.DeserializeObject<List<IndividualContacts>>(fileData);

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

                    ChooseGroup chooseGroup = new ChooseGroup(this, "single");
                    chooseGroup.ShowDialog();
                    this.Refresh();
                }


                if (selectedIndex != -1)
                {
                    gridTargetsGroup.Rows.Clear();
                    IndividualContacts contact = contacts[selectedIndex];
                    var globalCounter = gridTargetsGroup.Rows.Count - 1;

                    for (int i = 0; i < contact.ContactNames.Count; i++)
                    {
                        try
                        {
                            gridTargetsGroup.Rows.Add();
                            gridTargetsGroup.Rows[globalCounter].Cells[0].Value = contact.Numbers[i];
                            gridTargetsGroup.Rows[globalCounter].Cells[1].Value = contact.ContactNames[i];
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
