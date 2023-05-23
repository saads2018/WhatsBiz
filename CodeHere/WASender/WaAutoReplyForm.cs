using MaterialSkin.Controls;
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
using WhatsappBusiness.CloudApi;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaAutoReplyBot.enums;
using WASender;
using WASender.enums;
using WASender;
using OpenQA.Selenium.Interactions;
using WASender.Models;
using System.Web;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using WASender.Model;
using WaAutoReplyBot.Models;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using WASender.Alerts;
using OfficeOpenXml;

namespace WaAutoReplyBot
{
    public partial class WaAutoReplyForm : MyMaterialForm
    {
        List<RuleTransactionModel> ruleTransactionModelList;
        DataTable dtEmp;
        InitStatusEnum initStatusEnum;
        IWebDriver driver;
        System.Windows.Forms.Timer timerInitChecker;
        BackgroundWorker worker;
        private static bool IsRunning = false;
        private static string strLog = "";
        System.Windows.Forms.Timer timerRunner;
        WaSenderForm WaSenderForm;
        List<UnReadMessagesModel> sendMessagesList = new List<UnReadMessagesModel>();
        Logger logger;
        bool _AutoOpen = false;

        string welcome = "Hey how are you doing?";

       /* protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }*/
        public WaAutoReplyForm(WaSenderForm _WaSenderForm, bool isAutoOpen = false)
        {

            logger = new Logger("AutoReplyBot");
            WaSenderForm = _WaSenderForm;
           // _AutoOpen = isAutoOpen;
            InitializeComponent();
            contextMenuStrip1.Visible = false;
            //WaitForReopen();
        }

        private async void WaitForReopen()
        {
            await Task.Delay(TimeSpan.FromHours(3));

            ReOpen();
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
            txtLog.Text = strLog;
        }

        public static void WriteLogg(string msg)
        {
            strLog = msg + Environment.NewLine + strLog;
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
        private void materialButton2_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                AddRule addRule = new AddRule(new RuleTransactionModel(), this);
                addRule.ShowDialog();
                this.Refresh();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
            initLanguage();
            if (this._AutoOpen)
            {
                RunNow();
            }
        }

        private void initLanguage()
        {
            this.Text = Strings.WhatsAppBot;
/*            materialLabel1.Text = Strings.Rules;
*/            materialButton2.Text = Strings.AddRule;
            label7.Text = Strings.Status;
/*            materialLabel2.Text = Strings.Log;
*/            materialButton1.Text = Strings.Start;
            materialButton4.Text = Strings.Stop;
        }

        private void init()
        {
            ruleTransactionModelList = new List<RuleTransactionModel>();
            dtEmp = new DataTable();
            dtEmp.Columns.Add("IsActive", typeof(bool));
            dtEmp.Columns.Add("User Input", typeof(string));
            dtEmp.Columns.Add("Type", typeof(string));
            dtEmp.Columns.Add("Messages", typeof(string));
            gridRulesets.DataSource = dtEmp;
            gridRulesets.Columns[0].Width = 60;
            gridRulesets.Columns[0].ReadOnly = false;
            gridRulesets.Columns[1].ReadOnly = true;
            gridRulesets.Columns[2].ReadOnly = true;
            gridRulesets.Columns[3].ReadOnly = true;

            string ObjData = Newtonsoft.Json.JsonConvert.SerializeObject(this.ruleTransactionModelList);
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            String path = Path.Combine(FolderPath, "WaAutoreplyRules.json");
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                var tempruleTransactionModelList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RuleTransactionModel>>(text);

                foreach (RuleTransactionModel ruleTransactionModel in tempruleTransactionModelList.ToList())
                {
                    initiate = true;
                    AddRuleTRansaction(ruleTransactionModel);
                    initiate = false;
                }
            }
        }

        public void RemoveItem()
        {
            var ss = gridRulesets.CurrentCell.RowIndex;
            this.ruleTransactionModelList.RemoveAt(ss);
            var logs = getAutoResponderLogs();

            var pauses = getPause();
            pauses.Remove(pauses.Where(x=>x.RuleID==ss).FirstOrDefault());
            logs.RemoveAll(x => x.RuleID == ss);

            int counter = 0;
            foreach(var pause in pauses)
            {
                foreach(var log in logs)
                {
                    if(log.RuleID==pause.RuleID)
                        log.RuleID=counter;
                }
                pause.RuleID = counter;
                counter += 1;
            }
            savePause(pauses);
            File.WriteAllText(fileSaves + "\\" + "AutoResponderLogs.json", JsonConvert.SerializeObject(logs, Formatting.Indented));

            dtEmp.Rows.RemoveAt(ss);
        }

        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");

        public void HandleChieldEditMode()
        {
            try
            {
                var ss = gridRulesets.CurrentCell.RowIndex;
                this.ruleTransactionModelList[ss].IsEditMode = false;
            }
            catch (Exception ex)
            {

            }
        }

        public static List<RulePause> getPause()
        {
            List<RulePause> rulePauses = new List<RulePause>();
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            String path = Path.Combine(FolderPath, "RulePause.json");

            string json = File.ReadAllText(path);
            if(!String.IsNullOrWhiteSpace(json))
            {
                rulePauses = JsonConvert.DeserializeObject<List<RulePause>>(json);
            }
            return rulePauses;
        }

        public static void savePause(List<RulePause> rulePauses)
        {
            String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            String path = Path.Combine(FolderPath, "RulePause.json");
            File.WriteAllText(path,JsonConvert.SerializeObject(rulePauses,Formatting.Indented));
        }

        bool initiate;
        public void AddRuleTRansaction(RuleTransactionModel _ruleTransactionModel, string days="0", bool pause=false, bool addtoTrans = true)
        {
            if (_ruleTransactionModel.IsEditMode != true)
            {
                if (addtoTrans == true)
                {
                    ruleTransactionModelList.Add(_ruleTransactionModel);

                    if(!initiate)
                    {
                        RulePause rulePause = new RulePause(ruleTransactionModelList.Count - 1, Int32.Parse(days));
                        var pauses = getPause();
                        pauses.Add(rulePause);
                        savePause(pauses);
                    }            
                }
                dtEmp.Rows.Add(true, _ruleTransactionModel.userInput, _ruleTransactionModel.operatorsEnum, _ruleTransactionModel.messages.Count());
            }
            else
            {
                var ss = gridRulesets.CurrentCell.RowIndex;
                this.ruleTransactionModelList[ss] = _ruleTransactionModel;
                this.ruleTransactionModelList[ss].IsEditMode = false;
                dtEmp.Rows[ss][1] = this.ruleTransactionModelList[ss].userInput;
                dtEmp.Rows[ss][2] = this.ruleTransactionModelList[ss].operatorsEnum;
                dtEmp.Rows[ss][3] = this.ruleTransactionModelList[ss].messages.Count();

                var pauses = getPause();
                if(pause)
                    pauses.Where(x=>x.RuleID==ss).FirstOrDefault().DaysCount = Int32.Parse(days);
                else
                    pauses.Where(x => x.RuleID == ss).FirstOrDefault().DaysCount = 0;

                savePause(pauses);
            }

            try
            {
                string ObjData = Newtonsoft.Json.JsonConvert.SerializeObject(this.ruleTransactionModelList);
                String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                String path = Path.Combine(FolderPath, "WaAutoreplyRules.json");
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                File.WriteAllText(path, ObjData);
            }
            catch
            {

            }
        }

        private void gridRulesets_DoubleClick(object sender, EventArgs e)
        {
            var ss = gridRulesets.CurrentCell.RowIndex;
            this.ruleTransactionModelList[ss].IsEditMode = true;

            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                AddRule addRule = new AddRule(this.ruleTransactionModelList[ss], this,ss);
                addRule.ShowDialog();
                this.Refresh();
            }

        }

        private void ChangeInitStatus(InitStatusEnum _initStatus)
        {
            this.initStatusEnum = _initStatus;
            AutomationCommon.ChangeInitStatus(_initStatus, lblInitStatus);
            if (_initStatus == InitStatusEnum.Initialised || _initStatus == InitStatusEnum.Initialising || _initStatus == InitStatusEnum.Started)
            {
                materialButton2.Enabled = false;
            }
            else
            {
                materialButton2.Enabled = true;
            }
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
                    initBackgroundWorker();
                    Activate();
                    WaAutoReplyForm.IsRunning = true;
                    worker.RunWorkerAsync();
                    initTimer();
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
                    WaAutoReplyForm.IsRunning = true;
                    worker.RunWorkerAsync();
                    initTimer();
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
            ChangeInitStatus(InitStatusEnum.Started);
        }


        private List<RuleTransactionModel> ExactStartsWith(List<RuleTransactionModel> _RuleTransactionModelList, string userInput)
        {
            List<RuleTransactionModel> matchedRules = new List<RuleTransactionModel>();
            foreach (var item in _RuleTransactionModelList)
            {
                if (userInput.ToUpper().StartsWith(item.userInput.ToUpper()))
                {
                    matchedRules.Add(item);
                }
            }
            return matchedRules;
        }

        private List<RuleTransactionModel> ExactEndsWith(List<RuleTransactionModel> _RuleTransactionModelList, string userInput)
        {
            List<RuleTransactionModel> matchedRules = new List<RuleTransactionModel>();
            foreach (var item in _RuleTransactionModelList)
            {
                if (userInput.ToUpper().EndsWith(item.userInput.ToUpper()))
                {
                    matchedRules.Add(item);
                }
            }
            return matchedRules;
        }


        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<RuleTransactionModel> exactMessageList = this.ruleTransactionModelList.Where(x => x.operatorsEnum == OperatorsEnum.Exact).ToList();
            List<RuleTransactionModel> containsMessageList = this.ruleTransactionModelList.Where(x => x.operatorsEnum == OperatorsEnum.Contains).ToList();
            List<RuleTransactionModel> startFromMessageList = this.ruleTransactionModelList.Where(x => x.operatorsEnum == OperatorsEnum.StartFrom).ToList();
            List<RuleTransactionModel> endsWithFromMessageList = this.ruleTransactionModelList.Where(x => x.operatorsEnum == OperatorsEnum.EndsWith).ToList();
            List<RuleTransactionModel> fallbackMesageList = this.ruleTransactionModelList.Where(x => x.IsFallBack == true).ToList();

            //Thread.Sleep(10000);
            while (WaAutoReplyForm.IsRunning == true)
            {

                Thread.Sleep(1000);

                if (1 == 2)
                {
                    #region oldLOgic
                    bool IsGroup = false;
                    try
                    {

                        if (Config.SendingType == 0)
                        {
                            #region oldlogic
                            AutomationCommon.checkConnection(driver);
                            By unreadmessage = By.ClassName("_1pJ9J");

                            By messageby = By.ClassName("_2wUmf");

                            if (AutomationCommon.IsElementPresent(unreadmessage, driver) || AutomationCommon.IsElementPresent(messageby, driver))
                            {
                                logger.WriteLog("New UNread Found");
                                By unreadmessageHolder = By.ClassName("_1pJ9J");

                                if (AutomationCommon.IsElementPresent(unreadmessageHolder, driver) || AutomationCommon.IsElementPresent(messageby, driver))
                                {

                                    if (AutomationCommon.IsElementPresent(messageby, driver))
                                    {
                                        var lastMessage = driver.FindElements(messageby);
                                        try
                                        {
                                            var lm = lastMessage[lastMessage.Count() - 1];
                                            string sdds = lm.GetAttribute("class");
                                            if (sdds.Contains("message-in"))
                                            {
                                                try
                                                {
                                                    var SenderName = driver.FindElements(By.ClassName("a71At"));
                                                    var SenderName2 = driver.FindElements(By.ClassName("_1u3M2"));
                                                    if (SenderName.Count() == 0 && SenderName2.Count == 0)
                                                    {
                                                        IsGroup = false;
                                                    }
                                                    else
                                                    {
                                                        IsGroup = true;
                                                    }
                                                }
                                                catch (Exception ex)
                                                {

                                                }

                                            }
                                            else
                                            {
                                                IsGroup = true;
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                    if (AutomationCommon.IsElementPresent(unreadmessageHolder, driver))
                                    {
                                        IWebElement UnreadChat = driver.FindElement(unreadmessageHolder).FindElement(By.XPath("..")).FindElement(By.XPath("..")).FindElement(By.XPath("..")).FindElement(By.XPath("..")).FindElement(By.XPath(".."));

                                        string UnreadChatHtml = UnreadChat.GetAttribute("innerHTML");


                                        if (UnreadChatHtml.Contains("data-testid=\"default-group\""))
                                        {
                                            IsGroup = true;
                                            logger.WriteLog("Is Group");
                                        }

                                        if (AutomationCommon.IsElementPresent(unreadmessageHolder, driver))
                                        {


                                            UnreadChat.Click();
                                        }

                                    }

                                    logger.WriteLog("_1pJ9J Found");



                                    if (IsGroup == false)
                                    {
                                        logger.WriteLog("Not Group");
                                        var messageins = driver.FindElements(By.ClassName("message-in"));
                                        try
                                        {
                                            string lastMessageText = messageins[messageins.Count() - 1].FindElement(By.ClassName("selectable-text")).Text;
                                            logger.WriteLog("lastMessageText = " + lastMessageText);
                                            if (ExactStartsWith(startFromMessageList, lastMessageText).Count() > 0)
                                            {
                                                logger.WriteLog("Match with ExactStartsWith");
                                                RuleTransactionModel model = ExactStartsWith(startFromMessageList, lastMessageText).LastOrDefault();
                                                sendMessage(model);
                                            }
                                            else if (ExactEndsWith(endsWithFromMessageList, lastMessageText).Count() > 0)
                                            {
                                                logger.WriteLog("Match with ExactEndsWith");
                                                RuleTransactionModel model = ExactEndsWith(endsWithFromMessageList, lastMessageText).LastOrDefault();
                                                sendMessage(model);
                                            }
                                            else if (exactMessageList.Where(x => x.userInput.ToUpper() == lastMessageText.ToUpper()).Count() > 0)
                                            {
                                                logger.WriteLog("Match with exactMessage");
                                                RuleTransactionModel model = exactMessageList.Where(x => x.userInput.ToUpper() == lastMessageText.ToUpper()).LastOrDefault();
                                                sendMessage(model);
                                            }
                                            else if (containsMessageList.Where(x => x.userInput.ToUpper().Contains(lastMessageText.ToUpper())).Count() > 0)
                                            {
                                                logger.WriteLog("Match with contains");
                                                RuleTransactionModel model = containsMessageList.Where(x => x.userInput.ToUpper().Contains(lastMessageText.ToUpper())).LastOrDefault();
                                                sendMessage(model);
                                            }
                                            else
                                            {
                                                var splitter = lastMessageText.ToUpper().Split(' ');
                                                bool found = false;
                                                foreach (var item in containsMessageList)
                                                {
                                                    if (splitter.Contains(item.userInput.ToUpper()))
                                                    {
                                                        sendMessage(item);
                                                        found = true;
                                                    }
                                                }

                                                if (found == false)
                                                {
                                                    logger.WriteLog("Fallback");
                                                    RuleTransactionModel model = fallbackMesageList[Utils.getRandom(0, fallbackMesageList.Count() - 1)];
                                                    sendMessage(model);
                                                }

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            logger.WriteLog(ex.Message);
                                            if (fallbackMesageList.Count() > 0)
                                            {
                                                logger.WriteLog("Fallback Found");
                                                RuleTransactionModel model = fallbackMesageList[Utils.getRandom(0, fallbackMesageList.Count() - 1)];
                                                sendMessage(model);
                                            }
                                            else
                                            {
                                                logger.WriteLog("Fallback not found");
                                            }
                                        }


                                    }

                                    try
                                    {
                                        if (IsGroup == false)
                                        {
                                            List<string> clsConvs = new List<string>();
                                            clsConvs.Add("Fechar conversa");
                                            clsConvs.Add("Close chat");


                                            IWebElement menu = driver.FindElement(By.XPath("//*[@id='main']/header/div[3]/div/div[2]/div/div | //*[@id='main']/header/div[3]/div/div[3]/div/div/span"));
                                            menu.Click();
                                            Thread.Sleep(200);
                                            logger.WriteLog("Menu Clicked");



                                            IWebElement menuHolder = driver.FindElement(By.CssSelector("[data-testid='contact-menu-dropdown']"));

                                            var lis = menuHolder.FindElements(By.ClassName("_2qR8G"));
                                            logger.WriteLog("lis.Count()= " + lis.Count());

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
                                                //logger.WriteLog("Window Reloaded");
                                            }
                                            By prifileBy = By.XPath("//*[@class='_1PzAL']");
                                            if (AutomationCommon.IsElementPresent(prifileBy, driver))
                                            {


                                                bool closed = false;
                                                try
                                                {

                                                    // Thread.Sleep(500);
                                                    try
                                                    {
                                                        menu.Click();
                                                        logger.WriteLog("Menu CLick");
                                                        menuHolder = driver.FindElement(By.CssSelector("[data-testid='contact-menu-dropdown']"));
                                                        var liss = menuHolder.FindElements(By.ClassName("_2qR8G"));
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        logger.WriteLog("Error ");
                                                        driver.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.Escape);
                                                        logger.WriteLog("Escape Pressed");
                                                        try
                                                        {

                                                            menu.Click();
                                                            logger.WriteLog("Menu Clicked");
                                                            menuHolder = driver.FindElement(By.CssSelector("[data-testid='contact-menu-dropdown']"));
                                                            lis = menuHolder.FindElements(By.ClassName("_2qR8G"));
                                                        }
                                                        catch (Exception exd)
                                                        {
                                                            logger.WriteLog("Error");
                                                        }
                                                    }

                                                    logger.WriteLog("Going for foreach");
                                                    logger.WriteLog("lis count=" + lis.Count());
                                                    foreach (var item in lis)
                                                    {
                                                        string ss = item.Text;
                                                        logger.WriteLog("item=" + ss);
                                                        if (clsConvs.Where(x => x.ToUpper() == ss.ToUpper()).Count() > 0)
                                                        {
                                                            logger.WriteLog("Item Match");
                                                            item.Click();
                                                            logger.WriteLog("Item Clicked");
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
                                                            catch (Exception ex)
                                                            {

                                                            }
                                                        }
                                                    }

                                                }
                                                catch (Exception eeeex)
                                                {
                                                    logger.WriteLog("eeeex error");
                                                }

                                                if (closed == false)
                                                {
                                                    logger.WriteLog("closed == false");
                                                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                                    js.ExecuteScript("window.location.href=''");
                                                    logger.WriteLog("prifileBy found");
                                                }

                                            }
                                            else
                                            {
                                                logger.WriteLog("prifileBy not found");
                                            }
                                        }

                                    }
                                    catch (Exception Ex)
                                    {
                                        logger.WriteLog(Ex.Message);
                                    }

                                }

                            }
                            #endregion
                        }
                        else if (Config.SendingType == 0)
                        {
                            if (!WAPIHelper.IsWAPIInjected(driver))
                            {
                                ProjectCommon.injectWapi(driver);
                            }
                            List<string> allchats = WAPIHelper.GetAllChatIds(driver);

                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {

                            if (IsGroup == false)
                            {
                                IWebElement menu = driver.FindElement(By.XPath("//*[@id='main']/header/div[3]/div/div[2]/div/div | //*[@id='main']/header/div[3]/div/div[3]/div/div/span"));
                                menu.Click();
                                Thread.Sleep(500);
                                logger.WriteLog("Menu Clicked");

                                IWebElement menuHolder = driver.FindElement(By.CssSelector("[data-testid='contact-menu-dropdown']"));

                                var lis = menuHolder.FindElements(By.ClassName("_2qR8G"));
                                logger.WriteLog("lis.Count()= " + lis.Count());

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
                                    //logger.WriteLog("Window Reloaded");
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


                                        /// Thread.Sleep(500);
                                        try
                                        {
                                            menu.Click();
                                            logger.WriteLog("Menu CLick");
                                            menuHolder = driver.FindElement(By.CssSelector("[data-testid='contact-menu-dropdown']"));
                                            var liss = menuHolder.FindElements(By.ClassName("_2qR8G"));
                                        }
                                        catch (Exception exdd)
                                        {
                                            logger.WriteLog("Error ");
                                            driver.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.Escape);
                                            logger.WriteLog("Escape Pressed");
                                            try
                                            {

                                                menu.Click();
                                                logger.WriteLog("Menu Clicked");
                                                menuHolder = driver.FindElement(By.CssSelector("[data-testid='contact-menu-dropdown']"));
                                                lis = menuHolder.FindElements(By.ClassName("_2qR8G"));
                                            }
                                            catch (Exception exd)
                                            {
                                                logger.WriteLog("Error");
                                            }
                                        }

                                        logger.WriteLog("Going for foreach");
                                        logger.WriteLog("lis count=" + lis.Count());
                                        foreach (var item in lis)
                                        {
                                            string ss = item.Text;
                                            logger.WriteLog("item=" + ss);
                                            if (clsConvs.Where(x => x.ToUpper() == ss.ToUpper()).Count() > 0)
                                            {
                                                logger.WriteLog("Item Match");
                                                item.Click();
                                                logger.WriteLog("Item Clicked");
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
                                        logger.WriteLog("eeeex error");
                                    }

                                    if (closed == false)
                                    {
                                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                        js.ExecuteScript("window.location.href=''");
                                        logger.WriteLog("prifileBy found");
                                    }

                                }
                                else
                                {
                                    logger.WriteLog("prifileBy not found");
                                }
                            }
                        }
                        catch (Exception Ex)
                        {
                            logger.WriteLog(Ex.Message);
                        }
                    }
                    #endregion
                }
                else if (Config.SendingType == 1)
                {
                    try
                    {
                        if (!WAPIHelper.IsWAPIInjected(driver))
                        {
                            ProjectCommon.injectWapi(driver);
                            //WAPIHelper.validateNumber(driver, "918600398330");
                        }
                        List<UnReadMessagesModel> UnReadMessages = WAPIHelper.GetAllUnreadMessages2(driver);
                        UnReadMessages.AddRange(WAPIHelper._newMessagesBuffer(driver));

                        foreach (var item in UnReadMessages)
                        {
                            try
                            {
                                if (sendMessagesList.Where(x => x.id == item.id).Count() == 0)
                                {
                                    string lastMessageText = item.body;
                                    logger.WriteLog("lastMessageText = " + lastMessageText);
                                    if (ExactStartsWith(startFromMessageList, lastMessageText).Count() > 0)
                                    {
                                        logger.WriteLog("Match with ExactStartsWith");
                                        RuleTransactionModel model = ExactStartsWith(startFromMessageList, lastMessageText).LastOrDefault();
                                        sendMessage(model, item.chatId);
                                        sendMessagesList.Add(item);
                                    }
                                    else if (ExactEndsWith(endsWithFromMessageList, lastMessageText).Count() > 0)
                                    {
                                        logger.WriteLog("Match with ExactEndsWith");
                                        RuleTransactionModel model = ExactEndsWith(endsWithFromMessageList, lastMessageText).LastOrDefault();
                                        sendMessage(model, item.chatId);
                                        sendMessagesList.Add(item);
                                    }
                                    else if (exactMessageList.Where(x => x.userInput.ToUpper() == lastMessageText.ToUpper()).Count() > 0)
                                    {
                                        logger.WriteLog("Match with exactMessage");
                                        RuleTransactionModel model = exactMessageList.Where(x => x.userInput.ToUpper() == lastMessageText.ToUpper()).LastOrDefault();
                                        sendMessage(model, item.chatId);
                                        sendMessagesList.Add(item);
                                    }
                                    else if (containsMessageList.Where(x => lastMessageText.ToUpper().Contains(x.userInput.ToUpper())).Count() > 0)
                                    {
                                        logger.WriteLog("Match with contains");
                                        RuleTransactionModel model = containsMessageList.Where(x => lastMessageText.ToUpper().Contains(x.userInput.ToUpper())).LastOrDefault();
                                        sendMessage(model, item.chatId);
                                        sendMessagesList.Add(item);
                                    }
                                    else
                                    {
                                        var splitter = lastMessageText.ToUpper().Split(' ');
                                        bool found = false;
                                        foreach (var itemo in containsMessageList)
                                        {
                                            if (splitter.Contains(itemo.userInput.ToUpper()))
                                            {
                                                sendMessage(itemo, item.chatId);
                                                sendMessagesList.Add(item);
                                                found = true;
                                            }
                                        }

                                        if (found == false)
                                        {
                                            logger.WriteLog("Fallback");
                                            if (fallbackMesageList.Count > 0)
                                            {
                                                RuleTransactionModel model = fallbackMesageList[Utils.getRandom(0, fallbackMesageList.Count() - 1)];
                                                sendMessage(model, item.chatId);
                                                sendMessagesList.Add(item);
                                            }

                                        }

                                    }
                                }



                            }
                            catch (Exception ex)
                            {
                                logger.WriteLog(ex.Message);
                                if (fallbackMesageList.Count() > 0)
                                {
                                    logger.WriteLog("Fallback Found");
                                    RuleTransactionModel model = fallbackMesageList[Utils.getRandom(0, fallbackMesageList.Count() - 1)];
                                    sendMessage(model, item.chatId);
                                    sendMessagesList.Add(item);
                                }
                                else
                                {
                                    logger.WriteLog("Fallback not found");
                                }
                            }
                        }
                    }
                    catch (Exception edx)
                    {

                    }
                }


            }
        }

        private void sendMessage(RuleTransactionModel model, string number = "")
        {
            Thread.Sleep(1000);

            if (1 == 2)
            {
                #region OldLogic
                By TextBoxBy = By.XPath("//*[@id='main']/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[2]");
                IWebElement el = driver.FindElement(By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]"));
                IWebElement el2 = driver.FindElement(By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[2]"));

                IWebElement messageTextBox = driver.FindElement(TextBoxBy);

                logger.WriteLog("Sending Reply in");
                By DisappearingmessagesBy = By.ClassName("_1N4rE");
                if (AutomationCommon.IsElementPresent(DisappearingmessagesBy, driver))
                {
                    logger.WriteLog("Is Disappearingmessages");
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

                int random = Utils.getRandom(0, model.messages.Count());

                var mesageModel = model.messages[random];

                logger.WriteLog("random = " + random);


                int fileCntr = 0;
                IWebElement image = null;
                if (mesageModel.Files.Count > 0)
                {
                    driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div/span[2]/div/div[1]/div[2]/div")).Click();
                    Thread.Sleep(250);
                    image = driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div/span[2]/div/div[1]/div[2]/div/span/div[1]/div/ul/li[1]/button/input"));
                }
                string filesString = "";
                foreach (var file in mesageModel.Files)
                {
                    if (filesString != "")
                    {
                        filesString += "\n" + file;
                    }
                    else
                    {
                        filesString += file;
                    }
                    fileCntr++;
                }

                if (filesString != "")
                {
                    image.SendKeys(filesString);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    driver.FindElement(By.XPath("//*[@id='app']/div[1]/div[1]/div[2]/div[2]/span/div[1]/span/div[1]/div/div[2]/div/div[2]/div[2]/div/div")).Click();
                    Thread.Sleep(500);
                }


                var messages = mesageModel.LongMessage.Split('\n');
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

                        MsgLine = MsgLine + "\n";
                        NewMessage = NewMessage + MsgLine;
                    }
                }

                Invoke((Action)(() => { Clipboard.SetText(NewMessage); }));
                try
                {
                    messageTextBox.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                }
                catch (Exception x)
                {
                    try
                    {
                        try
                        {
                            Invoke((Action)(() => { Clipboard.SetText(NewMessage); }));
                            el.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                        }
                        catch (Exception eex)
                        {


                        }

                        try
                        {
                            Invoke((Action)(() => { Clipboard.SetText(NewMessage); }));
                            el2.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                        }
                        catch (Exception fff)
                        {

                        }

                        //el.SendKeys("dd"); 

                    }
                    catch (Exception ex)
                    {

                    }
                }



                AutomationCommon.checkConnection(driver);

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



                AutomationCommon.checkConnection(driver);

                logger.WriteLog("sendButton Click");

                By usernameBy = By.ClassName("_21nHd");
                string userName = "";
                if (AutomationCommon.IsElementPresent(usernameBy, driver))
                {
                    userName = driver.FindElement(usernameBy).Text;
                }
                if (!model.IsFallBack)
                {
                    WaAutoReplyForm.WriteLogg(userName + "\t-- " + Strings.Match + " : \t" + model.operatorsEnum + "\t-- " + Strings.ReplySend + "!");
                }
                else
                {
                    WaAutoReplyForm.WriteLogg(userName + "\t-- " + Strings.NotMatch + " :\t --" + Strings.Fallback + " \t--" + Strings.ReplySend + "!");
                }


                logger.WriteLog("Reply Sent");
                #endregion
            }
            else if (Config.SendingType == 1)
            {

                if(compareDate(number,model))
                {
                    foreach (var mesageModel in model.messages)
                    {
                        msgSupport(mesageModel, number);
                        // WAPIHelper.validateNumber(driver, number);
                        //
                        //WAPIHelper.OpenMe(driver);
                    }

                    if (!model.IsFallBack)
                    {
                        WaAutoReplyForm.WriteLogg(number + "\t-- " + Strings.Match + " : \t" + model.operatorsEnum + "\t-- " + Strings.ReplySend + "!");
                    }
                    else
                    {
                        WaAutoReplyForm.WriteLogg(number + "\t-- " + Strings.NotMatch + " :\t --" + Strings.Fallback + " \t--" + Strings.ReplySend + "!");
                    }
                }
            }

        }

        private async void msgSupport(MessageModel mesageModel,string number)
        {
            await sendFiles(mesageModel, number);
            var messages = mesageModel.LongMessage.Split('\n');
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

                    MsgLine = MsgLine + "\n";
                    NewMessage = NewMessage + MsgLine;
                }
            }

            //WAPIHelper.OpenChat(driver, number);
            //Thread.Sleep(200);
            //  WAPIHelper.validateNumber(driver,number);
            Thread.Sleep(1000);

            if (mesageModel.buttons != null && mesageModel.buttons.Count() > 0)
            {
                WAPIHelper.sendButtonWithMessage(driver, mesageModel, number, NewMessage);
            }
            else
            {
                if (NewMessage.Contains("http://") || NewMessage.Contains("https://"))
                {
                    WAPIHelper.OpenChatopenChatBottom(driver, number);
                    Thread.Sleep(500);
                    WAPIHelper.sendTextMessage(driver, number, NewMessage);
                }
                else
                {
                    WAPIHelper.SendMessage(driver, number, NewMessage);
                }
                Thread.Sleep(1000);
                WAPIHelper.sendSeen(driver, number);
            }

        }

        private async Task sendFiles(MessageModel mesageModel, string number)
        {
            foreach (var file in mesageModel.Files)
            {
                Byte[] bytes = File.ReadAllBytes(file);
                String filebase64 = Convert.ToBase64String(bytes);
                string contentType = MimeMapping.GetMimeMapping(file);

                string ext = Path.GetExtension(file);
                if (ext == ".mp4")
                {
                    contentType = "video/mp4";
                }

                string fullBase64 = "data:" + contentType + ";base64," + filebase64;
                string FileName = file.Split('\\')[file.Split('\\').Length - 1];

                if (ext == ".mp4")
                {
                    try
                    {
                        WAPIHelper.OpenChatopenChatBottom(driver, number);
                        Thread.Sleep(500);
                        WAPIHelper.SendVideo(driver, number, fullBase64, "");
                        //WhatsAppHelper whats = new WhatsAppHelper();
                        //await whats.waitVideo(driver, number, fullBase64, FileName);
                        //await WAPIHelper.SendAttachment(driver, number, fullBase64, FileName, "");
                    }
                    catch (Exception eeex)
                    {
                        logger.WriteLog("Is Number Valid-" + eeex.Message);
                    }
                }
                else
                {
                    WAPIHelper.SendAttachment(driver, number, fullBase64, FileName, "");
                    Thread.Sleep(2000);
                }



            }
        }

        private List<AutoResponderLogs> getAutoResponderLogs()
        {
            string json = File.ReadAllText(fileSaves + "\\" + "AutoResponderLogs.json");
            List<AutoResponderLogs> autoResponderLogs = new List<AutoResponderLogs>();
            if (!String.IsNullOrWhiteSpace(json))
                autoResponderLogs = JsonConvert.DeserializeObject<List<AutoResponderLogs>>(json);

            return autoResponderLogs;
        }

        private bool compareDate(string number,RuleTransactionModel transactionModel)
        {
            bool welcome = true;
            var logs = getAutoResponderLogs();
            var pauses = getPause();
            var index = ruleTransactionModelList.IndexOf(transactionModel);
            var pause=pauses.Where(x=>x.RuleID==index).FirstOrDefault();
            var log = logs.Where(x => x.Number == number && x.RuleID==pause.RuleID).FirstOrDefault();

            if (log==null)
            {
                logs.Add(new AutoResponderLogs(number,pause.RuleID,DateTime.Now.ToString()));
            }
            else if(pause!=null && pause.DaysCount > 0)
            {
                TimeSpan ts = DateTime.Now - DateTime.Parse(log.DateContacted);
                int x = (int)ts.TotalDays;
                if (x < pause.DaysCount)
                    welcome = false;

                log.DateContacted = DateTime.Now.ToString();
            }

            File.WriteAllText(fileSaves + "\\" + "AutoResponderLogs.json", JsonConvert.SerializeObject(logs, Formatting.Indented));
            return welcome;
        }

        private void RunNow()
        {
            if (!(ruleTransactionModelList.Count() > 0))
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar(Strings.PleaseaddRules, Strings.OK, true);
                SnackBarMessage.Show(this);
            }
            else if (ruleTransactionModelList.FirstOrDefault(x=>x.messages.Any(y=>y.Files.Any(z=>!File.Exists(z))))!=null)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("File(s) Location Changed!", Strings.OK, true);
                SnackBarMessage.Show(this);
            }
            else
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

                    Utils.SetDriver();
                    driver = Utils.Driver;



                    //Config.KillChromeDriverProcess();

                    //var chromeDriverService = ChromeDriverService.CreateDefaultService();
                    //chromeDriverService.HideCommandPromptWindow = true;

                    //driver = new ChromeDriver(chromeDriverService, Config.GetChromeOptionsBot());
                    //try
                    //{
                    //    driver.Url = "https://web.whatsapp.com";

                    //    //if (!WAPIHelper.IsWAPIInjected(driver))
                    //    //{
                    //    //    WAPIHelper.injectWapi(driver);
                    //    //    WAPIHelper.validateNumber(driver, "918600398330");
                    //    //}
                    //}
                    //catch (Exception ex)
                    //{

                    //}

                    checkQRScanDone();
                    materialButton1.Enabled = false;
                    materialButton4.Enabled = true;
                    gridRulesets.Enabled = false;
                    timer1.Start();
                }
                catch (Exception ex)
                {
                    logger.WriteLog("error=" + ex.Message);
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
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            RunNow();
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            materialButton1.Enabled = true;
            materialButton4.Enabled = false;
            gridRulesets.Enabled = true;
            timer1.Stop();
            if (initStatusEnum == InitStatusEnum.Initialised || initStatusEnum == InitStatusEnum.Started)
            {
                try
                {
                    WaAutoReplyForm.IsRunning = false;
                    timerRunner.Stop();
                    worker.CancelAsync();

                   /* if(driver!=null)
                    {
                        driver.Close();
                        driver.Quit();
                    }*/
                }
                catch (Exception Ex)
                {

                }
                ChangeInitStatus(InitStatusEnum.Stopped);

            }

        }

        private void WaAutoReplyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string ObjData = Newtonsoft.Json.JsonConvert.SerializeObject(this.ruleTransactionModelList);
                String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                String path = Path.Combine(FolderPath, "WaAutoreplyRules.json");
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                File.WriteAllText(path, ObjData);
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
            catch (Exception ex)
            {

            }
            logger.Complete();
        }

        private void WaAutoReplyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void ReOpen()
        {

           /* try
            {
                driver.Close();
                driver.Quit();
            }
            catch (Exception)
            {

            }*/
            this.Hide();
            this.Close();
            this.WaSenderForm.reEnableAutoReply();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialCard3_Paint(object sender, PaintEventArgs e)
        {

        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
           /* if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        int countSeconds,countHours = 0;
        int countMinutes = 0;
        string countS, countM, countH = "";

        private void gridRulesets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void gridRulesets_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void gridRulesets_MouseClick(object sender, MouseEventArgs e)
        {
           /* if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(gridRulesets, e.X, e.Y);
            }*/
        }

        private void ExportRule_Click(object sender, System.EventArgs e)
        {
            if(ruleTransactionModelList.Count==0)
            {
                MessageBox.Show("Please First Add At Least One Rule To Export!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var index = gridRulesets.CurrentCell.RowIndex;


                String FolderPath = Config.GetTempFolderPath();
                String file = Path.Combine(FolderPath, "ChatList_" + Guid.NewGuid().ToString() + ".xlsx");

                string NewFileName = file.ToString();

                File.Copy("ChatListTemplate.xlsx", NewFileName, true);

                var newFile = new FileInfo(NewFileName);
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    var ws = xlPackage.Workbook.Worksheets[0];

                    ws.Cells[1, 1].Value = "Rule #";
                    ws.Cells[1, 1].Worksheet.Column(1).Width = 7;
                    ws.Cells[1, 2].Value = "User Input";
                    ws.Cells[1, 2].Worksheet.Column(2).Width = 18;
                    ws.Cells[1, 3].Value = "Operators Enum";
                    ws.Cells[1, 3].Worksheet.Column(3).Width = 18;
                    ws.Cells[1, 4].Value = "Is Active";
                    ws.Cells[1, 4].Worksheet.Column(4).Width = 18;
                    ws.Cells[1, 5].Value = "Is Saved";
                    ws.Cells[1, 5].Worksheet.Column(5).Width = 18;
                    ws.Cells[1, 6].Value = "Is Edit Mode";
                    ws.Cells[1, 6].Worksheet.Column(6).Width = 18;
                    ws.Cells[1, 7].Value = "My Property";
                    ws.Cells[1, 7].Worksheet.Column(7).Width = 18;
                    ws.Cells[1, 8].Value = "Is Fallback";
                    ws.Cells[1, 8].Worksheet.Column(8).Width = 18;
                    ws.Cells[1, 9].Value = "Messages";
                    ws.Cells[1, 9].Worksheet.Column(9).Width = 100;
                    ws.Cells[1, 10].Value = "Pause/Delay (Days)";
                    ws.Cells[1, 10].Worksheet.Column(10).Width = 20;

                    int rowCount = 2;

                    for (int i = 0; i < ruleTransactionModelList.Count; i++)
                    {
                        RuleTransactionModel rule = ruleTransactionModelList[i];
                        int messageNo = 1;

                        ws.Cells[rowCount, 1].Value = i + 1;
                        ws.Cells[rowCount, 2].Value = rule.userInput;
                        ws.Cells[rowCount, 3].Value = rule.operatorsEnum;
                        ws.Cells[rowCount, 4].Value = rule.IsActive;
                        ws.Cells[rowCount, 5].Value = rule.IsSaved;
                        ws.Cells[rowCount, 6].Value = rule.IsEditMode;
                        ws.Cells[rowCount, 7].Value = rule.MyProperty;
                        ws.Cells[rowCount, 8].Value = rule.IsFallBack;
                        ws.Cells[rowCount, 10].Value = getPause().Where(x => x.RuleID == i).FirstOrDefault().DaysCount;


                        foreach (var message in rule.messages)
                        {
                            ws.Cells[rowCount, 9].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[rowCount, 9].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                            ws.Cells[rowCount++, 9].Value = "Message #" + messageNo++;
                            ws.Cells[rowCount, 9].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[rowCount, 9].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                            ws.Cells[rowCount++, 9].Value = "LongMessage";
                            ws.Cells[rowCount++, 9].Value = message.LongMessage;
                            ws.Cells[rowCount, 9].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[rowCount, 9].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSalmon);
                            ws.Cells[rowCount++, 9].Value = "Files";

                            if (message.Files.Count == 0)
                                ws.Cells[rowCount++, 9].Value = "NONE";
                            else
                            {
                                foreach (var x in message.Files)
                                    ws.Cells[rowCount++, 9].Value = x;
                            }

                            ws.Cells[rowCount, 9].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[rowCount, 9].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightCoral);
                            ws.Cells[rowCount++, 9].Value = "IsEditMode";
                            ws.Cells[rowCount++, 9].Value = message.IsEditMode;
                            ws.Cells[rowCount, 9].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[rowCount, 9].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                            ws.Cells[rowCount++, 9].Value = "Buttons";

                            int btnNo = 1;

                            if (message.buttons.Count == 0)
                                ws.Cells[rowCount++, 9].Value = "NONE";
                            else
                            {

                                foreach (var x in message.buttons)
                                {
                                    ws.Cells[rowCount, 9].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    ws.Cells[rowCount, 9].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightYellow);
                                    ws.Cells[rowCount++, 9].Value = "Button #" + btnNo++;
                                    ws.Cells[rowCount++, 9].Value = "id";
                                    ws.Cells[rowCount++, 9].Value = x.id;
                                    ws.Cells[rowCount++, 9].Value = "text";
                                    ws.Cells[rowCount++, 9].Value = x.text;
                                    ws.Cells[rowCount++, 9].Value = "url";
                                    ws.Cells[rowCount++, 9].Value = x.url;
                                    ws.Cells[rowCount++, 9].Value = "phoneNumber";
                                    ws.Cells[rowCount++, 9].Value = x.phoneNumber;
                                    ws.Cells[rowCount++, 9].Value = "editMode";
                                    ws.Cells[rowCount++, 9].Value = x.editMode;
                                    ws.Cells[rowCount++, 9].Value = "buttonTypeEnum";
                                    ws.Cells[rowCount++, 9].Value = x.buttonTypeEnum;
                                }
                            }

                        }
                        ws.Cells[rowCount, 9].Worksheet.Row(rowCount).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        ws.Cells[rowCount, 9].Worksheet.Row(rowCount++).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gray);
                    }

                    xlPackage.Save();
                }



                savesampleExceldialog.FileName = "rules.xlsx";

                if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(NewFileName, savesampleExceldialog.FileName, true);
                    Utils.showAlert("The Bot Rules Have Been Saved Successfully!", WASender.Alerts.Alert.enmType.Success);
                }
            }
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void button2_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void WaAutoReplyForm_VisibleChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = Strings.SelectExcel;
            openFileDialog.DefaultExt = "xlsx";
            openFileDialog.Filter = "Excel Files|*.xlsx;";
            openFileDialog.Multiselect = false;

            List<RuleTransactionModel> rules = new List<RuleTransactionModel>();

            List<string> pauses = new List<string>();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                var fiSingle = new FileInfo(file);
                if (fiSingle.Extension != ".xlsx")
                {
                    Utils.showAlert(Strings.PleaseselectExcelfilesformatonly, WASender.Alerts.Alert.enmType.Error);
                    return;
                }

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(fiSingle))
                {
                    try
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                        var ColumnsCOunt = worksheet.Dimension.Columns;

                        int largest = 0;

                        for (int i = 2; i < worksheet.Dimension.Rows; i++)
                        {
                            if (worksheet.Cells[i, 1].Value!=null && !String.IsNullOrWhiteSpace(worksheet.Cells[i,1].Value.ToString()))
                            {
                                int x = Int32.Parse(worksheet.Cells[i, 1].Value.ToString());
                                if(x>largest)
                                {
                                    largest = x;
                                }
                            }
                        }

                        int rowCount = 1;
                        for (int i = 0; i < largest; i++)
                        {

                            try
                            {
                                rowCount++;
                                RuleTransactionModel rule = new RuleTransactionModel();

                                rule.userInput = worksheet.Cells[rowCount, 2].Value.ToString();
                                rule.operatorsEnum = (OperatorsEnum) Enum.Parse(typeof(OperatorsEnum),worksheet.Cells[rowCount, 3].Value.ToString());
                                rule.IsActive = (bool)worksheet.Cells[rowCount, 4].Value;
                                rule.IsSaved = (bool)worksheet.Cells[rowCount, 5].Value;
                                rule.IsEditMode = false;
                                rule.MyProperty = Int32.Parse(worksheet.Cells[rowCount, 7].Value.ToString());
                                rule.IsFallBack = (bool)worksheet.Cells[rowCount, 8].Value;
                                pauses.Add(worksheet.Cells[rowCount, 10].Value.ToString());
                                rowCount += 2;
                                rule.messages = new List<MessageModel>();

                                bool end = false;

                                do
                                {
                                    MessageModel messageModel = new MessageModel();
                                    
                                    messageModel.LongMessage = worksheet.Cells[rowCount, 9].Value.ToString();
                                    rowCount += 2;
                                    messageModel.Files = new List<string>();

                                    if (!(worksheet.Cells[rowCount, 9].Value.ToString() == "NONE"))
                                    {
                                        while (!worksheet.Cells[rowCount, 9].Value.ToString().Contains("IsEditMode"))
                                        {
                                            messageModel.Files.Add(worksheet.Cells[rowCount++, 9].Value.ToString());
                                        }
                                        rowCount++;
                                    }
                                    else
                                        rowCount += 2;

                                    rowCount += 2;
                                    messageModel.buttons = new List<ButtonsModel>();

                                    if (!(worksheet.Cells[rowCount, 9].Value.ToString() == "NONE"))
                                    {
                                        while (worksheet.Cells[rowCount, 9].Value!=null && worksheet.Cells[rowCount, 9].Value.ToString().Contains("Button #"))
                                        {
                                            ButtonsModel buttonsModel = new ButtonsModel();
                                            rowCount += 2;
                                            buttonsModel.id = worksheet.Cells[rowCount, 9].Value.ToString();
                                            rowCount += 2;
                                            buttonsModel.text = worksheet.Cells[rowCount, 9].Value.ToString();
                                            rowCount += 2;
                                            buttonsModel.url = worksheet.Cells[rowCount, 9].Value == null ? "" : worksheet.Cells[rowCount, 9].Value.ToString();
                                            rowCount += 2;
                                            buttonsModel.phoneNumber = worksheet.Cells[rowCount, 9].Value == null ? "" : worksheet.Cells[rowCount, 9].Value.ToString();
                                            rowCount += 2;
                                            buttonsModel.editMode = (bool)worksheet.Cells[rowCount, 9].Value;
                                            rowCount += 2;
                                            buttonsModel.buttonTypeEnum = (ButtonTypeEnum)Enum.Parse(typeof(ButtonTypeEnum), worksheet.Cells[rowCount++, 9].Value.ToString());

                                            messageModel.buttons.Add(buttonsModel);
                                        }

                                    }
                                    else
                                        rowCount++;

                                    rule.messages.Add(messageModel);

                                    if (worksheet.Cells[rowCount, 9].Value==null)
                                        end = true;
                                    else
                                        rowCount += 2;

                                } while (!end);
                                rules.Add(rule);
                            }
                            catch (Exception ex)
                            {
                                string ss = "";
                            }
                        }

                        for(int j = 0;j < rules.Count;j++)
                            AddRuleTRansaction(rules[j], pauses[j]);
                    }
                    catch (Exception ex)
                    {
                        Utils.showAlert("Incorrect Format", WASender.Alerts.Alert.enmType.Error);
                    }
                }
              }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            Utils.showAlert("Please Export A Rule To View The Format Of The Excel File \n(For Importing Rules)", WASender.Alerts.Alert.enmType.Info);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                AddRule addRule;
                addRule = new AddRule(new RuleTransactionModel(), this);
                addRule.ShowDialog();
                this.Refresh();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countSeconds++;
            if(countSeconds==60)
            {
                countMinutes++;
                countSeconds = 0;
            }
            if (countMinutes == 60)
            {
                countHours++;
                countMinutes = 0;
            }

            countS = countSeconds.ToString();
            countM = countMinutes.ToString();
            countH = countHours.ToString();

            if (countSeconds<10)
                countS="0"+countS;
            if (countMinutes < 10)
                countM = "0" + countM;
            if (countHours < 10)
                countH = "0" + countH;

            materialButton1.Text = "Start - " + countH + " : " + countM + " : " + countS;
        }
    }
}
