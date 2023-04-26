using MaterialSkin;
using MaterialSkin.Controls;
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
using WASender.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Web;

namespace WASender
{
    public partial class RunSingle : MaterialForm
    {
        WASenderSingleTransModel wASenderSingleTransModel;
        WaSenderForm waSenderForm;
        InitStatusEnum initStatusEnum;
        CampaignStatusEnum campaignStatusEnum;
        IWebDriver driver;
        System.Windows.Forms.Timer timerInitChecker;
        System.Windows.Forms.Timer timerRunner;
        BackgroundWorker worker;
        private bool IsPaused = false;
        Logger logger;
        private bool IsStopped = true;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        public RunSingle(WASenderSingleTransModel _wASenderSingleTransModel, WaSenderForm _waSenderForm)
        {
            InitializeComponent();
            logger = new Logger("RunSingle");
            this.waSenderForm = _waSenderForm;
            this.wASenderSingleTransModel = _wASenderSingleTransModel;
            this.Text = _wASenderSingleTransModel.CampaignName;
            if (Utils.Driver != null)
            {
                Utils.SetDriver();
                driver = Utils.Driver;
                initWA();
            }
        }

        private void RunForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            waSenderForm.formReturn(true);
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

        private void initWA()
        {
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
        private void RunSingle_Load(object sender, EventArgs e)
        {
            init();

            initLanguage();
        }

        private void initLanguage()
        {
            this.Text = Strings.Run;
/*            materialLabel2.Text = Strings.InitiateWhatsAppScaneQRCodefromyourrmobile;
*/            btnInitWA.Text = Strings.ClicktoInitiate;
            label5.Text = Strings.Status;
/*            btnSTart.Text = Strings.Start;
*/            /* button3.Text = Strings.Pause;
           button2.Text = Strings.Stop;*/
            label7.Text = Strings.Status;
/*            label8.Text = Strings.Log;
*/            gridStatus.Columns[0].HeaderText = Strings.ChatName;
            gridStatus.Columns[1].HeaderText = Strings.Status;
           /* label4.Text = Strings.ImportentNotes;
            label1.Text = Strings.Keepapplicationopenwhilesendingmessagesanduntilallmessagesaresentfromyourmobile;
            label2.Text = Strings.ClearWhatsAppchathistoryafter5001000150020000messagesasperyourphoneconfiguration;
            label3.Text = Strings.WaSendertendstosubmitmessagestoyourphoneisnotresponsiblefordeliveryofthemessage;*/
        }

        private void init()
        {
/*            label4.ForeColor = Color.Red;
*/            ChangeInitStatus(InitStatusEnum.NotInitialised);
            ChangeCampStatus(CampaignStatusEnum.NotStarted);
        }

        private void ChangeCampStatus(CampaignStatusEnum _campaignStatus)
        {
            this.campaignStatusEnum = _campaignStatus;
            AutomationCommon.ChangeCampStatus(_campaignStatus, lblRunStatus);
        }

        private void ChangeInitStatus(InitStatusEnum _initStatus)
        {
            this.initStatusEnum = _initStatus;
            AutomationCommon.ChangeInitStatus(_initStatus, lblInitStatus);
        }

        private void checkQRScanDone()
        {
            timerInitChecker = new System.Windows.Forms.Timer();
            timerInitChecker.Interval = 1000;
            timerInitChecker.Tick += timerInitChecker_Tick;
            timerInitChecker.Start();
        }



        private void btnInitWA_Click(object sender, EventArgs e)
        {
            initWA();
        }

        public void timerInitChecker_Tick(object sender, EventArgs e)
        {
            //_1jJ70 
            try
            {
                bool isElementDisplayed = AutomationCommon.IsElementPresent(By.ClassName("_1XkO3"), driver);
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

        private void PlaceLink(IWebDriver _driver, string number, string className)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            try
            {
                string NavigateJS = "try{";
                NavigateJS += "document.getElementsByClassName('ownCLickable')[0].parentElement.innerHTML=\"\";";
                NavigateJS += "}catch(err){};";
                NavigateJS += "";
                NavigateJS += "";
                NavigateJS += "";
                NavigateJS += "var para = document.createElement(\"div\"); ";
                NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='http://wa.me/" + number + "'>*</a>\"; ";
                NavigateJS += "document.getElementsByClassName(\"" + className + "\")[0].appendChild(para); ";
                NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                NavigateJS += "link[0].click(); ";
                js.ExecuteScript(NavigateJS);
                CanStopWaitingForDelevetry = true;
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
            }
            Thread.Sleep(1000);
        }

        private static bool CanStopWaitingForDelevetry = false;

        [STAThread]
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = 0;
            int totalCounter = 0;
            logger.WriteLog("Starting");
            if (Config.SendingType == 0)
            {
                #region "OldLogic"
                foreach (var item in wASenderSingleTransModel.contactList)
                {
                    try
                    {
                        By hrefHolder1 = By.ClassName("_2-IT7");
                        By hrefHolder2 = By.ClassName("_1y6Yk");
                        By hrefHolder3 = By.ClassName("do8e0lj9");

                        bool IsNumberValid = false;
                        try
                        {
                            Int64 sampleNumber = Convert.ToInt64(item.number);
                            IsNumberValid = true;
                        }
                        catch (Exception ex)
                        {
                            var newNumber = item.number.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "");
                            try
                            {
                                Int64 sampleNumber = Convert.ToInt64(newNumber);
                                item.number = newNumber;
                                IsNumberValid = true;
                            }
                            catch (Exception exs)
                            {

                            }
                        }
                        if (IsNumberValid == true)
                        {
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
                                CanStopWaitingForDelevetry = true;
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
                                CanStopWaitingForDelevetry = true;
                            }
                            else if (AutomationCommon.IsElementPresent(hrefHolder3, driver))
                            {
                                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                string NavigateJS = "document.getElementsByClassName('do8e0lj9')[0].innerHTML=\"\"; ";
                                NavigateJS += "var para = document.createElement(\"div\"); ";
                                NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='http://wa.me/" + item.number + "'>*</a>\"; ";
                                NavigateJS += "document.getElementsByClassName(\"do8e0lj9\")[0].appendChild(para); ";
                                NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                                NavigateJS += "link[0].click(); ";
                                js.ExecuteScript(NavigateJS);
                                CanStopWaitingForDelevetry = true;
                            }
                            else
                            {
                                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                js.ExecuteScript("window.location.href='https://web.whatsapp.com/send?phone=" + item.number + "&text&app_absent=0'");
                                CanStopWaitingForDelevetry = false;
                            }
                        }
                        else
                        {
                            try
                            {
                                By BackButon = By.XPath("//*[@id=\"app\"]/div/div/div[2]/div[1]/span/div/span/div/header/div/div[1]/button/span");
                                if (AutomationCommon.IsElementPresent(BackButon, driver))
                                {
                                    driver.FindElement(BackButon).Click();
                                }

                                By newchatBy = By.XPath("//*[@id=\"side\"]/header/div[2]/div/span/div[2]/div/span");
                                if (AutomationCommon.IsElementPresent(newchatBy, driver))
                                {
                                    driver.FindElement(newchatBy).Click();
                                    Thread.Sleep(300);

                                    By searchChattxtBy = By.XPath("//*[@id=\"app\"]/div/div/div[2]/div[1]/span/div/span/div/div[1]/div/label/div/div[2] | //*[@id=\"app\"]/div/div/div[2]/div[1]/span/div/span/div/div[1]/div/div/div[2]/div/div[2]");


                                    if (AutomationCommon.IsElementPresent(searchChattxtBy, driver))
                                    {
                                        driver.FindElement(searchChattxtBy).SendKeys(item.number);
                                        Thread.Sleep(300);
                                        By searchResultHolderBy = By.XPath("//*[@id=\"app\"]/div/div/div[2]/div[1]/span/div/span/div/div[2]/div/div/div");
                                        if (AutomationCommon.IsElementPresent(searchResultHolderBy, driver))
                                        {
                                            IWebElement searchResultHolder = driver.FindElement(searchResultHolderBy);
                                            var ResultNames = searchResultHolder.FindElements(By.ClassName("ggj6brxn"));
                                            if (ResultNames.Count() > 0)
                                            {
                                                ResultNames[0].Click();

                                            }

                                        }
                                        else
                                        {
                                            // By BackButon = By.XPath("//*[@id=\"app\"]/div/div/div[2]/div[1]/span/div/span/div/header/div/div[1]/button/span");
                                            if (AutomationCommon.IsElementPresent(BackButon, driver))
                                            {
                                                driver.FindElement(BackButon).Click();
                                            }
                                        }

                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
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


                            if (true == true)
                            {


                                By NumberInvalidBox = By.ClassName("_2Nr6U");
                                if (AutomationCommon.IsElementPresent(NumberInvalidBox, driver))
                                {
                                    By OkButtonBy = By.ClassName("_20C5O");
                                    if (AutomationCommon.IsElementPresent(OkButtonBy, driver))
                                    {
                                        driver.FindElement(OkButtonBy).Click();


                                        item.sendStatusModel.isDone = true;
                                        item.sendStatusModel.sendStatusEnum = SendStatusEnum.ContactNotFound;
                                        counter++;
                                        totalCounter++;

                                        var _count = wASenderSingleTransModel.contactList.Count();
                                        var percentage = totalCounter * 100 / _count;
                                        worker.ReportProgress(percentage);
                                        continue;


                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        AutomationCommon.checkConnection(driver);
                        IWebElement messageTextBox = AutomationCommon.WaitUntilElementVisible(driver, By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]"), 10);


                        if (messageTextBox == null)
                        {
                            item.sendStatusModel.isDone = true;
                            item.sendStatusModel.sendStatusEnum = SendStatusEnum.ContactNotFound;
                            counter++;
                            totalCounter++;

                            var _count = wASenderSingleTransModel.contactList.Count();
                            var percentage = totalCounter * 100 / _count;
                            worker.ReportProgress(percentage);
                            continue;
                        }


                        By DisappearingmessagesBy = By.ClassName("_1N4rE");
                        if (AutomationCommon.IsElementPresent(DisappearingmessagesBy, driver))
                        {
                            By HeaderHolderBy = By.ClassName("_1FrBz");
                            IWebElement Disappearingmessages = driver.FindElement(DisappearingmessagesBy);
                            if (AutomationCommon.IsElementPresent(HeaderHolderBy, Disappearingmessages))
                            {
                                IWebElement HeaderHolder = driver.FindElement(HeaderHolderBy);

                                if (AutomationCommon.IsElementPresent(HeaderHolderBy, Disappearingmessages))
                                {
                                    IWebElement holder = Disappearingmessages.FindElement(HeaderHolderBy);
                                    try
                                    {
                                        string HeaderText = holder.FindElement(By.TagName("h1")).Text;
                                        if (HeaderText == "Disappearing messages")
                                        {
                                            By okButtonBy = By.XPath("//div[contains(@class, '_20C5O') and contains(@class, '_2Zdgs') ]");
                                            if (AutomationCommon.IsElementPresent(okButtonBy, Disappearingmessages)) ;
                                            {
                                                IWebElement okButton = Disappearingmessages.FindElement(okButtonBy);
                                                okButton.Click();
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }

                        }

                        int n = Utils.getRandom(0, wASenderSingleTransModel.messages.Where(x => x != null).Count());

                        if (wASenderSingleTransModel.messages.Where(x => x != null).ToList().Count() < n)
                        {
                            n = wASenderSingleTransModel.messages.Where(x => x != null).ToList().Count();
                        }

                        MesageModel mesageModel = wASenderSingleTransModel.messages.Where(x => x != null).ToList()[n];

                        bool AutoSend = false;
                        if (mesageModel.buttons != null && mesageModel.buttons.Count() > 0)
                        {
                            AutoSend = true;
                        }

                        int fileCntr = 0;
                        IWebElement image = null;

                        if (mesageModel.files.Count > 0)
                        {
                            driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div/span[2]/div/div[1]/div[2]/div")).Click();
                            Thread.Sleep(250);
                            image = driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div/span[2]/div/div[1]/div[2]/div/span/div[1]/div/ul/li[1]/button/input"));
                        }

                        string filesString = "";
                        foreach (var file in mesageModel.files)
                        {
                            if (filesString != "")
                            {
                                filesString += "\n" + file.filePath;
                            }
                            else
                            {
                                filesString += file.filePath;
                            }
                            fileCntr++;
                        }

                        if (filesString != "")
                        {
                            image.SendKeys(filesString);

                            Thread.Sleep(TimeSpan.FromSeconds(2));

                            By sendFIleBy = By.XPath("//*[@id='app']/div[1]/div[1]/div[2]/div[2]/span/div[1]/span/div[1]/div/div[2]/div/div[2]/div[2]/div/div");

                            if (AutomationCommon.IsElementPresent(sendFIleBy, driver))
                            {
                                driver.FindElement(sendFIleBy).Click();
                            }
                            else
                            {
                                AutomationCommon.WaitUntilElementVisible(driver, sendFIleBy);
                                driver.FindElement(sendFIleBy).Click();
                            }


                            Thread.Sleep(500);
                        }


                        string finalMessage = "";
                        if (wASenderSingleTransModel.MessageSendingType == 2)
                        {
                            var messages = mesageModel.longMessage.Split('\n');

                            foreach (var m in messages)
                            {
                                if (m != "")
                                {
                                    string MsgLine = m;

                                    // Check For KeyMarker
                                    if (m.Contains("{{ KEY :"))
                                    {
                                        string str = Utils.ExtractBetweenTwoStrings(m, "{{ KEY :", "}}", false, false);
                                        var Keysplitter = str.Split('|');
                                        string randomKey = Keysplitter[Utils.getRandom(0, Keysplitter.Length - 1)];
                                        MsgLine = m.Replace("{{ KEY :" + str + "}}", randomKey);
                                    }
                                    // Check {{ RANDOM }}
                                    if (MsgLine.Contains("{{ RANDOM }}"))
                                    {
                                        string rand = Utils.getRandom(10000, 50000).ToString();
                                        MsgLine = MsgLine.Replace("{{ RANDOM }}", rand);
                                    }

                                    if (item.parameterModelList != null)
                                    {
                                        foreach (var param in item.parameterModelList)
                                        {
                                            if (MsgLine.Contains("{{" + param.ParameterName + "}}"))
                                            {
                                                MsgLine = MsgLine.Replace("{{" + param.ParameterName + "}}", param.ParameterValue);
                                            }
                                        }
                                    }


                                    IWebElement el = driver.FindElement(By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[2]"));
                                    try
                                    {
                                        var splitter = MsgLine.Trim().Split(' ');

                                        foreach (var _char in splitter)
                                        {
                                            try
                                            {
                                                messageTextBox.SendKeys(_char.ToString() + " ");
                                            }
                                            catch (Exception ex)
                                            {
                                                if (ex.Message.Contains("element not interactable"))
                                                {
                                                    try
                                                    {
                                                        el.SendKeys(_char.ToString() + " ");
                                                    }
                                                    catch (Exception exd)
                                                    {
                                                        string new_char = _char.Replace("\r", "");
                                                        string script = "arguments[0].innerHTML += '" + new_char + "'";
                                                        ((IJavaScriptExecutor)driver).ExecuteScript(script, el);
                                                        Thread.Sleep(500);
                                                        el.SendKeys(OpenQA.Selenium.Keys.Control + OpenQA.Selenium.Keys.End);
                                                        Thread.Sleep(500);
                                                    }
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        string new_char = _char.Replace("\r", "");
                                                        string script = "arguments[0].innerHTML += '" + new_char + "'";
                                                        ((IJavaScriptExecutor)driver).ExecuteScript(script, messageTextBox);
                                                        Thread.Sleep(500);
                                                        messageTextBox.SendKeys(OpenQA.Selenium.Keys.Control + OpenQA.Selenium.Keys.End);
                                                        Thread.Sleep(500);
                                                    }
                                                    catch (Exception exx)
                                                    {

                                                    }
                                                }

                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }



                                    try
                                    {
                                        if (AutoSend == false)
                                        {
                                            messageTextBox.SendKeys(OpenQA.Selenium.Keys.Shift + '\n');
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex.Message.Contains("element not interactable"))
                                        {
                                            if (AutoSend == false)
                                            {
                                                el.SendKeys(OpenQA.Selenium.Keys.Shift + '\n');
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (wASenderSingleTransModel.MessageSendingType == 1)
                        {
                            var messages = mesageModel.longMessage.Split('\n');
                            string NewMessage = "";
                            foreach (var m in messages)
                            {
                                if (m != "")
                                {
                                    string MsgLine = m;

                                    // Check For KeyMarker
                                    if (m.Contains("{{ KEY :"))
                                    {
                                        string str = Utils.ExtractBetweenTwoStrings(m, "{{ KEY :", "}}", false, false);
                                        var Keysplitter = str.Split('|');
                                        string randomKey = Keysplitter[Utils.getRandom(0, Keysplitter.Length - 1)];
                                        MsgLine = m.Replace("{{ KEY :" + str + "}}", randomKey);
                                    }
                                    // Check {{ RANDOM }}
                                    if (MsgLine.Contains("{{ RANDOM }}"))
                                    {
                                        string rand = Utils.getRandom(10000, 50000).ToString();
                                        MsgLine = MsgLine.Replace("{{ RANDOM }}", rand);
                                    }

                                    if (item.parameterModelList != null)
                                    {
                                        foreach (var param in item.parameterModelList)
                                        {
                                            if (MsgLine.Contains("{{" + param.ParameterName + "}}"))
                                            {
                                                MsgLine = MsgLine.Replace("{{" + param.ParameterName + "}}", param.ParameterValue);
                                            }
                                        }
                                    }

                                    MsgLine = MsgLine + "\n";
                                    NewMessage = NewMessage + MsgLine;
                                }
                            }

                            finalMessage = NewMessage;
                            Invoke((Action)(() => { Clipboard.SetText(NewMessage); }));
                            try
                            {
                                if (AutoSend == false)
                                {
                                    messageTextBox.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                                }

                            }
                            catch (Exception x)
                            {
                                if (AutoSend == false)
                                {
                                    try
                                    {
                                        IWebElement el = driver.FindElement(By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]"));
                                        Invoke((Action)(() => { Clipboard.SetText(NewMessage); }));
                                        el.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                                        Thread.Sleep(500);

                                    }
                                    catch (Exception ex)
                                    {

                                    }

                                    try
                                    {
                                        IWebElement el2 = driver.FindElement(By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[2]"));
                                        Invoke((Action)(() => { Clipboard.SetText(NewMessage); }));
                                        el2.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                                        Thread.Sleep(500);
                                    }
                                    catch (Exception exdd)
                                    {

                                    }
                                }

                            }
                        }


                        AutomationCommon.checkConnection(driver);
                        if (AutoSend == false)
                        {
                            try
                            {
                                IWebElement sendButton = AutomationCommon.WaitUntilElementVisible(driver, By.ClassName("_4sWnG"), 0);
                                sendButton.Click();
                                Thread.Sleep(250);
                            }
                            catch (Exception ex)
                            {

                            }

                            By sendButton2 = By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[2]/button/span");
                            if (AutomationCommon.IsElementPresent(sendButton2, driver))
                            {
                                try
                                {
                                    driver.FindElement(sendButton2).Click();
                                    Thread.Sleep(250);
                                }
                                catch (Exception ex)
                                {

                                }
                            }

                            if (AutomationCommon.IsElementPresent(By.ClassName("_4sWnG"), driver))
                            {
                                try
                                {
                                    IJavaScriptExecutor jssend = (IJavaScriptExecutor)driver;
                                    jssend.ExecuteScript("document.getElementsByClassName('_4sWnG')[0].click()");
                                    Thread.Sleep(500);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            By buttonByCustomAttr = By.CssSelector("[data-testid='send']");
                            if (AutomationCommon.IsElementPresent(buttonByCustomAttr, driver))
                            {
                                IJavaScriptExecutor jssend = (IJavaScriptExecutor)driver;
                                jssend.ExecuteScript("document.querySelector('[data-testid=\"send\"]').click()");
                                Thread.Sleep(500);
                            }
                        }

                        if (AutoSend == true)
                        {
                            if (!WAPIHelper.IsWAPIInjected(driver))
                            {
                                ProjectCommon.injectWapi(driver);
                            }

                            bool isMessageSent = WAPIHelper.sendButtonWithMessage(driver, mesageModel, item.number, finalMessage);
                            if (isMessageSent == false)
                            {
                                item.sendStatusModel.isDone = true;
                                item.sendStatusModel.sendStatusEnum = SendStatusEnum.ContactNotFound;
                                counter++;
                                totalCounter++;

                                var _count = wASenderSingleTransModel.contactList.Count();
                                var percentage = totalCounter * 100 / _count;
                                worker.ReportProgress(percentage);
                                continue;
                            }
                        }

                        AutomationCommon.checkConnection(driver);
                        if (CanStopWaitingForDelevetry == false)
                        {
                            bool IsStillSending = AutomationCommon.IsElementPresent(By.XPath("//*[@data-testid=\"msg-time\"]"), driver);

                            if (IsStillSending == true)
                            {
                                AutomationCommon.WaitUntilElementDispose(driver, By.XPath("//*[@data-testid=\"msg-time\"]"), 100);
                            }
                        }
                        AutomationCommon.checkConnection(driver);
                        Thread.Sleep(500);
                        try
                        {
                            By menuBy = By.XPath("//*[@id='main']/header/div[3]/div/div[2]/div/div");
                            By meuBySecond = By.XPath("//*[@id='main']/header/div[3]/div/div[3]/div/div/span");

                            IWebElement menu = null;
                            if (AutomationCommon.IsElementPresent(menuBy, driver))
                            {
                                menu = driver.FindElement(menuBy);
                                menu.Click();
                            }
                            else if (AutomationCommon.IsElementPresent(meuBySecond, driver))
                            {
                                menu = driver.FindElement(meuBySecond);
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
                                lis[4].Click();
                            }
                            else if (lis.Count() == 8)
                            {
                                lis[4].Click();
                            }
                            else if (lis.Count() == 7)
                            {
                                lis[2].Click();
                            }
                            else if (lis.Count() == 10)
                            {
                                lis[5].Click();
                            }
                            else
                            {
                                //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                //js.ExecuteScript("window.location.href=''");
                            }

                            By prifileBy = By.XPath("//*[@class='_1PzAL']");
                            if (AutomationCommon.IsElementPresent(prifileBy, driver))
                            {
                                bool closed = false;

                                try
                                {
                                    List<string> clsConvs = new List<string>();
                                    clsConvs.Add("Fechar conversa");
                                    clsConvs.Add("Close chat");


                                    Thread.Sleep(500);
                                    try
                                    {
                                        menu.Click();
                                        // logger.WriteLog("Menu CLick");
                                        menuHolder = driver.FindElement(By.CssSelector("[data-testid='contact-menu-dropdown']"));
                                        var liss = menuHolder.FindElements(By.ClassName("_2qR8G"));
                                    }
                                    catch (Exception exdd)
                                    {
                                        // logger.WriteLog("Error ");
                                        driver.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.Escape);
                                        //logger.WriteLog("Escape Pressed");
                                        try
                                        {

                                            menu.Click();
                                            // logger.WriteLog("Menu Clicked");
                                            menuHolder = driver.FindElement(By.CssSelector("[data-testid='contact-menu-dropdown']"));
                                            lis = menuHolder.FindElements(By.ClassName("_2qR8G"));
                                        }
                                        catch (Exception exd)
                                        {
                                            //      logger.WriteLog("Error");
                                        }
                                    }

                                    //logger.WriteLog("Going for foreach");
                                    //logger.WriteLog("lis count=" + lis.Count());
                                    foreach (var itemd in lis)
                                    {
                                        string ss = itemd.Text;
                                        //logger.WriteLog("item=" + ss);
                                        if (clsConvs.Where(x => x.ToUpper() == ss.ToUpper()).Count() > 0)
                                        {
                                            //logger.WriteLog("Item Match");
                                            itemd.Click();
                                            //logger.WriteLog("Item Clicked");
                                            closed = true;
                                            break;
                                        }
                                    }
                                    if (closed == false)
                                    {
                                        if (lis.Count() == 9)
                                        {
                                            try
                                            {
                                                lis[4].Click();
                                                closed = true;
                                            }
                                            catch (Exception efx)
                                            {

                                            }
                                        }
                                    }
                                }
                                catch (Exception eeeex)
                                {
                                    //logger.WriteLog("eeeex error");
                                }
                                if (closed == false)
                                {
                                    //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                    //js.ExecuteScript("window.location.href=''");
                                    //logger.WriteLog("prifileBy found");
                                }

                                //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                //js.ExecuteScript("window.location.href=''");
                            }

                        }
                        catch (Exception Ex)
                        {

                        }

                        Thread.Sleep(Utils.getRandom(wASenderSingleTransModel.settings.delayAfterEveryMessageFrom * 1000, wASenderSingleTransModel.settings.delayAfterEveryMessageTo * 1000));
                        counter++;

                        if (wASenderSingleTransModel.settings.delayAfterMessages == counter)
                        {
                            counter = 0;
                            Thread.Sleep(Utils.getRandom(wASenderSingleTransModel.settings.delayAfterMessagesFrom * 1000, wASenderSingleTransModel.settings.delayAfterMessagesFrom * 1000));
                        }
                    }
                    catch (Exception exc)
                    {
                        logger.WriteLog("exc=" + exc.Message);
                        item.sendStatusModel.isDone = true;
                        item.sendStatusModel.sendStatusEnum = SendStatusEnum.Failed;
                    }
                    totalCounter++;

                    var __count = wASenderSingleTransModel.contactList.Count();
                    var _percentage = totalCounter * 100 / __count;
                    item.sendStatusModel.isDone = true;
                    item.sendStatusModel.sendStatusEnum = SendStatusEnum.Success;
                    worker.ReportProgress(_percentage);

                }
                #endregion

            }
            else if (Config.SendingType == 1)
            {

                try
                {
                    GeneralSettingsModel generalSettingsModel = Config.GetSettings();
                    logger.WriteLog("Checking IsWAPIInjected");
                    bool isFirstMessage = true;
                    try
                    {
                        if (!WAPIHelper.IsWAPIInjected(driver))
                        {
                            logger.WriteLog("!IsWAPIInjected ");
                            ProjectCommon.injectWapi(driver);
                            logger.WriteLog("injectWapi Done");
                        }
                    }
                    catch (Exception edd)
                    {
                        logger.WriteLog("injectWapi Error" + edd.Message);
                    }

                    foreach (var item in wASenderSingleTransModel.contactList)
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
                            if (!WAPIHelper.IsWAPIInjected(driver))
                            {
                                ProjectCommon.injectWapi(driver);
                            }
                        }
                        catch (Exception ex)
                        {
                            logger.WriteLog("in Each-" + ex.Message);
                        }
                        bool isNumberValid = false;

                        try
                        {
                            item.number = item.number.Replace("+", "");
                            item.number = item.number.Replace(" ", "");
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {

                            try
                            {
                                if (item.number.StartsWith("55"))
                                {
                                    item.number = WAPIHelper.queryExists(driver, item.number);
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            /*if (generalSettingsModel != null && generalSettingsModel.manuallyOpenChat == true)
                            {
                                string className1 = "_2-IT7";
                                string className2 = "_1y6Yk";
                                string className3 = "do8e0lj9";
                                string className4 = generalSettingsModel.UniqueClassName == null ? "" : generalSettingsModel.UniqueClassName;
                                string className5 = "YtmXM";

                                By hrefHolder1 = By.ClassName(className1);
                                By hrefHolder2 = By.ClassName(className2);
                                By hrefHolder3 = By.ClassName(className3);
                                By hrefHolder4 = By.ClassName(className4);
                                By hrefHolder5 = By.ClassName(className5);


                                if (AutomationCommon.IsElementPresent(hrefHolder1, driver))
                                {
                                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                    string NavigateJS = "document.getElementsByClassName('" + className1 + "')[0].innerHTML=\"\"; ";
                                    NavigateJS += "var para = document.createElement(\"div\"); ";
                                    NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='http://wa.me/" + item.number + "'>*</a>\"; ";
                                    NavigateJS += "document.getElementsByClassName(\"" + className1 + "\")[0].appendChild(para); ";
                                    NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                                    NavigateJS += "link[0].click(); ";
                                    js.ExecuteScript(NavigateJS);
                                    CanStopWaitingForDelevetry = true;
                                }
                                else if (AutomationCommon.IsElementPresent(hrefHolder2, driver))
                                {
                                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                    string NavigateJS = "document.getElementsByClassName('" + className2 + "')[0].innerHTML=\"\"; ";
                                    NavigateJS += "var para = document.createElement(\"div\"); ";
                                    NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='http://wa.me/" + item.number + "'>*</a>\"; ";
                                    NavigateJS += "document.getElementsByClassName(\"" + className2 + "\")[0].appendChild(para); ";
                                    NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                                    NavigateJS += "link[0].click(); ";
                                    js.ExecuteScript(NavigateJS);
                                    CanStopWaitingForDelevetry = true;
                                }
                                else if (AutomationCommon.IsElementPresent(hrefHolder3, driver))
                                {
                                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                    string NavigateJS = "document.getElementsByClassName('" + className3 + "')[0].innerHTML=\"\"; ";
                                    NavigateJS += "var para = document.createElement(\"div\"); ";
                                    NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='http://wa.me/" + item.number + "'>*</a>\"; ";
                                    NavigateJS += "document.getElementsByClassName(\"" + className3 + "\")[0].appendChild(para); ";
                                    NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                                    NavigateJS += "link[0].click(); ";
                                    js.ExecuteScript(NavigateJS);
                                    CanStopWaitingForDelevetry = true;
                                }
                                else if (AutomationCommon.IsElementPresent(hrefHolder5, driver))
                                {
                                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                    string NavigateJS = "document.getElementsByClassName('" + className5 + "')[0].innerHTML=\"\"; ";
                                    NavigateJS += "var para = document.createElement(\"div\"); ";
                                    NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='http://wa.me/" + item.number + "'>*</a>\"; ";
                                    NavigateJS += "document.getElementsByClassName(\"" + className5 + "\")[0].appendChild(para); ";
                                    NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                                    NavigateJS += "link[0].click(); ";
                                    js.ExecuteScript(NavigateJS);
                                    CanStopWaitingForDelevetry = true;
                                }
                                else if (className4 != null && className4 != "")
                                {
                                    if (AutomationCommon.IsElementPresent(hrefHolder4, driver))
                                    {
                                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                        string NavigateJS = "document.getElementsByClassName('" + className4 + "')[0].innerHTML=\"\"; ";
                                        NavigateJS += "var para = document.createElement(\"div\"); ";
                                        NavigateJS += "para.innerHTML = \"<a class='ownCLickable' href='http://wa.me/" + item.number + "'>*</a>\"; ";
                                        NavigateJS += "document.getElementsByClassName(\"" + className4 + "\")[0].appendChild(para); ";
                                        NavigateJS += "var link = document.getElementsByClassName('ownCLickable'); ";
                                        NavigateJS += "link[0].click(); ";
                                        js.ExecuteScript(NavigateJS);
                                        CanStopWaitingForDelevetry = true;
                                    }
                                }
                                else
                                {
                                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                    js.ExecuteScript("window.location.href='https://web.whatsapp.com/send?phone=" + item.number + "&text&app_absent=0'");
                                    CanStopWaitingForDelevetry = false;
                                }
                                Thread.Sleep(2000);
                                By NumberHeadersBy = By.XPath("//*[@data-testid='conversation-info-header-chat-title']");

                                By ButtonsBy = By.XPath("//*[@class='_2Nr6U']");

                                if (AutomationCommon.IsElementPresent(NumberHeadersBy, driver) && (!AutomationCommon.IsElementPresent(ButtonsBy, driver)))
                                {
                                    IWebElement numberheader = driver.FindElement(NumberHeadersBy);
                                    string number = numberheader.Text;
                                    string tempNumber = number.Replace("+", "").Replace(" ", "").Replace("-", "").Replace(" ", "").Replace(" ", "").Replace(" ", "").Replace(" ", "");
                                    try
                                    {
                                        Int64 bgint = Convert.ToInt64(tempNumber);
                                        number = tempNumber;
                                    }
                                    catch (Exception ex)
                                    {
                                        try
                                        {
                                            string id = WAPIHelper.getIDByName(driver, number);
                                            if (id != null)
                                            {
                                                number = id.Replace("@c.us", "");
                                            }
                                        }
                                        catch (Exception exs)
                                        {

                                        }
                                    }


                                    By NumberInvalidBox = By.ClassName("_2Nr6U");
                                    if (AutomationCommon.IsElementPresent(NumberInvalidBox, driver))
                                    {
                                        By OkButtonBy = By.ClassName("_20C5O");
                                        if (AutomationCommon.IsElementPresent(OkButtonBy, driver))
                                        {
                                            driver.FindElement(OkButtonBy).Click();
                                        }
                                    }
                                    else
                                    {
                                        item.number = number;
                                    }
                                }
                            }*/

                            //isNumberValid = WAPIHelper.validateNumber(driver, item.number);

                        }
                        catch (Exception ex)
                        {
                            logger.WriteLog("Is Number Valid-" + ex.Message);
                        }

                        try
                        {
                            isNumberValid = WAPIHelper.validateNumber(driver, item.number);
                            // isNumberValid = true;
                        }
                        catch (Exception ex)
                        {
                            logger.WriteLog("Is Number Valid-" + ex.Message);
                        }

                        if (!isNumberValid)
                        {
                            item.sendStatusModel.isDone = true;
                            item.sendStatusModel.sendStatusEnum = SendStatusEnum.ContactNotFound;
                            counter++;
                            totalCounter++;

                            var _count = wASenderSingleTransModel.contactList.Count();
                            var percentage = totalCounter * 100 / _count;
                            worker.ReportProgress(percentage);
                        }
                        else
                        {
                            foreach (MesageModel mesageModel in wASenderSingleTransModel.messages.Where(x => x != null).ToList())
                            {

                                try
                                {
                                    bool AutoSend = false;
                                    bool isAlreadySent = false;
                                    if (mesageModel.buttons != null && mesageModel.buttons.Count() > 0)
                                    {
                                        AutoSend = true;
                                    }

                                    isFirstMessage = false;
                                    Thread.Sleep(500);
                                    //var messages = mesageModel.longMessage.Split('\n');
                                    string NewMessage = ProjectCommon.ReplaceKeyMarker(mesageModel.longMessage, item.parameterModelList);



                                    foreach (var file in mesageModel.files)
                                    {
                                        Byte[] bytes = File.ReadAllBytes(file.filePath);
                                        String filebase64 = Convert.ToBase64String(bytes);

                                        string ext = Path.GetExtension(file.filePath);

                                        string contentType = MimeMapping.GetMimeMapping(file.filePath);
                                        if (ext == ".mp4")
                                        {
                                            contentType = "video/mp4";
                                        }
                                        string fullBase64 = "data:" + contentType + ";base64," + filebase64;
                                        string FileName = file.filePath.Split('\\')[file.filePath.Split('\\').Length - 1];

                                        if (ext == ".mp4")
                                        {
                                            try
                                            {
                                                if (file.Caption != null)
                                                {
                                                    file.Caption = ProjectCommon.ReplaceKeyMarker(file.Caption, item.parameterModelList);
                                                }

                                                WAPIHelper.OpenChatopenChatBottom(driver, item.number);
                                                Thread.Sleep(500);
                                                var rand = Utils.getRandom(500, 1000);
                                                WAPIHelper.markIsComposing(driver, item.number + "@c.us", rand);


                                                if (file.attachWithMainMessage == true)
                                                {
                                                    WAPIHelper.SendVideo(driver, item.number, fullBase64, mesageModel.longMessage, mesageModel.buttons);
                                                    AutoSend = false;
                                                }
                                                else
                                                {
                                                    WAPIHelper.SendVideo(driver, item.number, fullBase64, file.Caption);
                                                }


                                            }
                                            catch (Exception eeex)
                                            {
                                                logger.WriteLog("Is Number Valid-" + eeex.Message);
                                            }

                                        }
                                        else if (ext == ".ogg")
                                        {
                                            try
                                            {
                                                if (file.Caption != null)
                                                {
                                                    file.Caption = ProjectCommon.ReplaceKeyMarker(file.Caption, item.parameterModelList);
                                                }

                                                WAPIHelper.OpenChatopenChatBottom(driver, item.number);
                                                Thread.Sleep(500);
                                                var rand = Utils.getRandom(500, 1000);
                                                WAPIHelper.markIsComposing(driver, item.number + "@c.us", rand);

                                                fullBase64 = fullBase64.Replace("data:application/octet-stream;", "data:audio/mp3;");

                                                if (file.attachWithMainMessage == true)
                                                {
                                                    WAPIHelper.SendVideo(driver, item.number, fullBase64, mesageModel.longMessage, mesageModel.buttons);
                                                    AutoSend = false;
                                                }
                                                else
                                                {
                                                    WAPIHelper.SendVideo(driver, item.number, fullBase64, file.Caption);
                                                }


                                            }
                                            catch (Exception eeex)
                                            {
                                                logger.WriteLog("Is Number Valid-" + eeex.Message);
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if (file.Caption != null)
                                                {
                                                    file.Caption = ProjectCommon.ReplaceKeyMarker(file.Caption, item.parameterModelList);
                                                }
                                                WAPIHelper.OpenChatopenChatBottom(driver, item.number);
                                                Thread.Sleep(500);
                                                var rand = Utils.getRandom(500, 1000);
                                                WAPIHelper.markIsComposing(driver, item.number + "@c.us", rand);
                                                if (file.attachWithMainMessage == true)
                                                {
                                                    WAPIHelper.SendVideo(driver, item.number, fullBase64, mesageModel.longMessage, mesageModel.buttons);
                                                    AutoSend = false;
                                                    isAlreadySent = true;
                                                }
                                                else
                                                {
                                                    WAPIHelper.SendAttachment(driver, item.number, fullBase64, FileName, file.Caption);
                                                }

                                            }
                                            catch (Exception eex)
                                            {
                                                logger.WriteLog("Is Number Valid-" + eex.Message);
                                            }
                                        }

                                        if (isFirstMessage == true)
                                        {
                                            Thread.Sleep(2000);
                                        }
                                        Thread.Sleep(Utils.getRandom(wASenderSingleTransModel.settings.delayAfterEveryMessageFrom * 1000, wASenderSingleTransModel.settings.delayAfterEveryMessageTo * 1000));
                                    }


                                    if (AutoSend == false)
                                    {

                                        try
                                        {
                                            //throw new Exception("dfs");
                                            if (isAlreadySent == false)
                                            {
                                                if (NewMessage.Contains("http://") || NewMessage.Contains("https://"))
                                                {
                                                    WAPIHelper.OpenChatopenChatBottom(driver, item.number);
                                                    Thread.Sleep(500);
                                                    var rand = Utils.getRandom(500, 1000);
                                                    WAPIHelper.markIsComposing(driver, item.number + "@c.us", rand);
                                                    WAPIHelper.sendTextMessageWithPreview(driver, item.number, NewMessage);
                                                }
                                                else
                                                {
                                                    //WAPIHelper.OpenChatopenChatBottom(driver, item.number);
                                                    //Thread.Sleep(500);
                                                    var rand = Utils.getRandom(500, 1000);
                                                    WAPIHelper.markIsComposing(driver, item.number + "@c.us", rand);
                                                    WAPIHelper.SendMessage(driver, item.number, NewMessage);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            logger.WriteLog("Is Number Valid-" + ex.Message);

                                            string class1 = "do8e0lj9", class2 = "YtmXM", class3 = "_1y6Yk", class4 = "YtmXM";

                                            By hrefHolder1 = By.ClassName(class1);
                                            By hrefHolder2 = By.ClassName(class2);
                                            By hrefHolder3 = By.ClassName(class3);
                                            By hrefHolder4 = By.ClassName(class4);
                                            bool IsFound = false;
                                            if (AutomationCommon.IsElementPresent(hrefHolder1, driver))
                                            {
                                                PlaceLink(driver, item.number, class1);
                                                IsFound = true;
                                            }
                                            else if (AutomationCommon.IsElementPresent(hrefHolder2, driver))
                                            {
                                                PlaceLink(driver, item.number, class2);
                                                IsFound = true;
                                            }
                                            else if (AutomationCommon.IsElementPresent(hrefHolder3, driver))
                                            {
                                                PlaceLink(driver, item.number, class3);
                                                IsFound = true;
                                            }
                                            else if (AutomationCommon.IsElementPresent(hrefHolder4, driver))
                                            {
                                                PlaceLink(driver, item.number, class4);
                                                IsFound = true;
                                            }
                                            if (IsFound == true)
                                            {
                                                try
                                                {
                                                    var rand = Utils.getRandom(500, 1000);
                                                    WAPIHelper.markIsComposing(driver, item.number + "@c.us", rand);
                                                    WAPIHelper.SendDirectMessage(driver, item.number, NewMessage);
                                                }
                                                catch (Exception exd)
                                                {
                                                    logger.WriteLog("Send Direct Failed-" + ex.Message);
                                                }
                                            }

                                        }

                                    }
                                    else
                                    {
                                        try
                                        {
                                            if (isAlreadySent == false)
                                            {
                                                var rand = Utils.getRandom(500, 1000);
                                                WAPIHelper.markIsComposing(driver, item.number + "@c.us", rand);
                                                WAPIHelper.sendButtonWithMessage(driver, mesageModel, item.number, NewMessage);
                                            }

                                        }
                                        catch (Exception ex)
                                        {

                                            logger.WriteLog("Is Number Valid-" + ex.Message);
                                        }
                                    }



                                    Thread.Sleep(Utils.getRandom(wASenderSingleTransModel.settings.delayAfterEveryMessageFrom * 1000, wASenderSingleTransModel.settings.delayAfterEveryMessageTo * 1000));

                                }
                                catch (Exception ex)
                                {
                                    logger.WriteLog("1309=" + ex.Message);
                                }
                            }
                            try
                            {
                                counter++;

                                if (wASenderSingleTransModel.settings.delayAfterMessages == counter)
                                {
                                    counter = 0;
                                    Thread.Sleep(Utils.getRandom(wASenderSingleTransModel.settings.delayAfterMessagesFrom * 1000, wASenderSingleTransModel.settings.delayAfterMessagesFrom * 1000));
                                }
                            }
                            catch (Exception ex)
                            {
                                logger.WriteLog("1324=" + ex.Message);
                            }
                            totalCounter++;

                            var __count = wASenderSingleTransModel.contactList.Count();
                            var _percentage = totalCounter * 100 / __count;
                            item.sendStatusModel.isDone = true;
                            item.sendStatusModel.sendStatusEnum = SendStatusEnum.Success;
                            worker.ReportProgress(_percentage);

                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.WriteLog("1339=" + ex.Message);
                }


            }



        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ChangeCampStatus(CampaignStatusEnum.Finish);
            stopProgressbar();
            string report = AutomationCommon.GenerateReport(this.wASenderSingleTransModel);

            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string NavigateJS = "var win = window.open(\"\", \"Title\");";


                //NavigateJS += "win.document.body.innerHTML = `" + report + "`;";
                NavigateJS += "win.document.write('<html><head></head><body>');";
                NavigateJS += "win.document.write(`" + report + "`);";
                NavigateJS += "win.document.write('</body></html>');";
                js.ExecuteScript(NavigateJS);
            }
            catch (Exception ex)
            {
                string ss = "";
            }
            if (e.Error != null)
            {
                logger.WriteLog(e.Error.Message);
            }

        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblPersentage.Text = e.ProgressPercentage + "% " + Strings.Completed;
        }

        private void btnSTart_Click(object sender, EventArgs e)
        {
            logger.WriteLog("CLicked");
            if (initStatusEnum != InitStatusEnum.Initialised)
            {
                Utils.showAlert(Strings.PleasefollowStepNo1FirstInitialiseWhatsapp, Alerts.Alert.enmType.Error);
                return;
            }
            if (campaignStatusEnum == CampaignStatusEnum.Finish)
            {
                gridStatus.Rows.Clear();
            }
            if (campaignStatusEnum != CampaignStatusEnum.Running && campaignStatusEnum != CampaignStatusEnum.Paused)
            {
                try
                {
                    IsStopped = false;
                    logger.WriteLog("worker.RunWorkerAsync");
                    worker.RunWorkerAsync();
                    ChangeCampStatus(CampaignStatusEnum.Running);
                    startProgressBar();
                    initTimer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (campaignStatusEnum == CampaignStatusEnum.Paused)
            {
                IsPaused = false;
                ChangeCampStatus(CampaignStatusEnum.Running);
                startProgressBar();
            }
            else
            {
                Utils.showAlert(Strings.Processisalreadyrunning, Alerts.Alert.enmType.Info);
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
                foreach (var item in wASenderSingleTransModel.contactList)
                {
                    if (item.sendStatusModel.isDone == true && item.logged == false)
                    {


                        var globalCounter = gridStatus.Rows.Count - 1;
                        gridStatus.Rows.Add();
                        gridStatus.Rows[globalCounter].Cells[0].Value = item.number;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialCard2_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
