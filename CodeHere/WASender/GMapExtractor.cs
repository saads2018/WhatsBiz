using MaterialSkin.Controls;
using Newtonsoft.Json;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class GMapExtractor : MaterialForm
    {
        InitStatusEnum initStatusEnum;
        System.Windows.Forms.Timer timerInitChecker;
        IWebDriver driver;
        BackgroundWorker worker;
        CampaignStatusEnum campaignStatusEnum;
        WaSenderForm waSenderForm;
        Logger logger;
        List<GMapModel> gMapModelList;
        MainNavPage mainNavPage;
        IndividualContacts importContacts;

        public GMapExtractor(WaSenderForm _WASender,MainNavPage mainNavPage)
        {
            this.waSenderForm = _WASender;
            this.mainNavPage = mainNavPage;
            InitializeComponent();

            initializeResolution();
        }

        private void initializeResolution()
        {
            if ( (Program.resWidth == 1280 && Program.resHeight == 1024))
            {
                this.Size = new Size(this.Width-100, this.Height);
                this.panel2.Width -= 100;
                this.dataGridView1.Width -= 100;
            }
            else if (Program.resWidth == 1152 && Program.resHeight == 864)
            {
                this.panel2.Width -= 100;
                this.dataGridView1.Width -= 100;
            }
            else if (Program.resWidth == 1024 && Program.resHeight == 768)
            {
                this.Size = new Size(this.Width + 100, this.Height);
                this.panel2.Width -= 110;
                this.dataGridView1.Width -= 110;
            }
            else if (Program.resWidth == 800)
            {
                this.Size = new Size(this.Width + 100, this.Height);
                this.panel2.Width = 350;
                this.dataGridView1.Width = 350;
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
        private void GMapExtractor_Load(object sender, EventArgs e)
        {
            initLanguage();
            logger = new Logger("ContactGrabber");
            init();
            gMapModelList = new List<GMapModel>();
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


        private void initLanguage()
        {
            this.Text = Strings.GoogleMapDataEExtractor;
            this.materialLabel2.Text = Strings.Clickbellowbuttontoopenbrowser;
            this.label5.Text = Strings.Status;
/*            this.materialLabel1.Text = Strings.Usethatwindowtosearchforbusinessesandwhensearchresultsareshown;
*//*            this.materialButton6.Text = Strings.StartGrabbing;
*//*            this.btnInitWA.Text = Strings.Start;
*/            this.materialButton2.Text = Strings.Stop;
/*            materialButton5.Text = Strings.Export;
*//*            materialButton4.Text = Strings.ImportInWaSender;
*//*            label2.Text = Strings.Count;
*/            dataGridView1.Columns[0].HeaderText = Strings.Name;
            dataGridView1.Columns[1].HeaderText = Strings.MobileNumber;
            dataGridView1.Columns[2].HeaderText = Strings.ReviewCount;
            dataGridView1.Columns[3].HeaderText = Strings.RatingCount;
            dataGridView1.Columns[4].HeaderText = Strings.Catagory;
            dataGridView1.Columns[5].HeaderText = Strings.Address;
            dataGridView1.Columns[6].HeaderText = Strings.Website;
            dataGridView1.Columns[7].HeaderText = Strings.PlusCode;
        }


        public void InputReturn(string searchTurm)
        {
            logger.WriteLog("btnInitWA_Click");
            ChangeInitStatus(InitStatusEnum.Initialising);
            try
            {
                // Config.KillChromeDriverProcess();
                var chromeDriverService = ChromeDriverService.CreateDefaultService(Config.GetChromeDriverFolder());
                chromeDriverService.HideCommandPromptWindow = true;


                driver = new ChromeDriver(chromeDriverService, Config.GetChromeOptionsGMAP());
                try
                {
                    driver.Url = "https://www.google.com/search?q=" + searchTurm + "&biw=1418&bih=679&tbm=lcl";
                }
                catch (Exception ex)
                {

                }
                ChangeInitStatus(InitStatusEnum.Initialised);

            }
            catch (Exception ex)
            {
                ChangeInitStatus(InitStatusEnum.Unable);
                logger.WriteLog(ex.Message);
                logger.WriteLog(ex.StackTrace);
                string ss = "";
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

        private void btnInitWA_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                InputDialog id = new InputDialog(this);
                id.ShowDialog();
            }       
        }

        private bool IsResultShown()
        {

            try
            {
                By ResultsBy = By.XPath(XPathStore.GMap_Result);
                if (AutomationCommon.IsElementPresent(ResultsBy, driver))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private void initBackgroundWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            initTimer();
        }

        private string GetAttributeMulti(By by, string attr)
        {
            if (AutomationCommon.IsElementPresent(by, driver))
            {
                var els = driver.FindElements(by);
                string value = "";
                foreach (var el in els)
                {
                    String val= el.GetAttribute(attr);
                    if (val != null && val != null && (!val.Contains("google")))
                    {
                        value = val;
                    }

                }
                return value;
            }
            return "";
        }
        private string GetAttribute(By by,string attr)
        {
            if (AutomationCommon.IsElementPresent(by, driver))
            {
                IWebElement el = driver.FindElement(by);
                return el.GetAttribute(attr);
            }
            return "";
        }
        private string GetString(By by)
        {
            if (AutomationCommon.IsElementPresent(by, driver))
            {
                IWebElement el = driver.FindElement(by);
                return el.Text;
            }
            return "";
        }

        bool isStop = false;



        public bool elementHasClass(IWebElement element, string active)
        {
            return element.GetAttribute("class").Contains(active);
        }


        private void SvrollDown(IWebDriver driver)
        {
            IWebElement mainDiv = driver.FindElement(By.XPath("//*[@id=\"QA0Szd\"]/div/div/div[1]/div[2]/div/div[1]/div/div/div[2]/div[1]"));
            int scrollCount = 10;
            try
            {
                for (int i = 0; i < scrollCount; i++)
                {
                    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                }
            }
            catch (Exception ex)
            {

            }
            mainDiv = driver.FindElement(By.XPath("//*[@id=\"QA0Szd\"]/div/div/div[1]/div[2]/div/div[1]/div/div/div[3]/div[1]"));
            try
            {
                for (int i = 0; i < scrollCount; i++)
                {
                    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            //logger.WriteLog("Started Grabbing chat list");

            IJavaScriptExecutor jsFunction = (IJavaScriptExecutor)driver;
            jsFunction.ExecuteScript("function getElementByXpath(path) { return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue; }");

            int needtoSkip = 0;
            int gloibalCounter = 0;
            while (!isStop)
            {

                try
                {

                    var results = driver.FindElements(By.XPath(XPathStore.GMap_Result));
                    GMapModel gMapModel;

                    foreach (var item in results)
                    {
             
                        if (!isStop)
                        {
                            gMapModel = new GMapModel();
                            try
                            {
                                logger.WriteLog("item Click");

                                try
                                {
                                    item.Click();
                                }
                                catch (Exception ex)
                                {
                                    SvrollDown(driver);
                                    try
                                    {
                                        item.Click();
                                    }
                                    catch (Exception exd)
                                    {

                                    }
                                }

                                Thread.Sleep(1000);
                                //String GMap_Heading = "//h2[contains(@data-attrid,'title')]";
                                //String GMap_MobileNumber = "//a[contains(@data-dtype,'d3ph')]";
                                //string GMap_WebSite = "//a[@class='CL9Uqc']";

                                AutomationCommon.WaitUntilElementVisible(driver, By.XPath(XPathStore.GMap_Heading), 10);

                                if (AutomationCommon.IsElementPresent(By.XPath(XPathStore.GMap_Heading), driver))
                                {
                                    logger.WriteLog("Heading is present");
                                }
                                else
                                {
                                    logger.WriteLog("Heading is not present");
                                }

                                By GMap_HeadingBy = By.XPath(XPathStore.GMap_Heading);
                                By GMap_MobileNumberBy = By.XPath(XPathStore.GMap_MobileNumber);

                                By GMap_AddressBy = By.XPath(XPathStore.GMap_Address);
                                By GMap_WebSiteBy = By.XPath("//a[contains(@class,'dHS6jb')]");
                                By GMap_PlusCodeBy = By.XPath(XPathStore.GMap_PlusCode);
                                By GMap_RatingBy = By.XPath(XPathStore.GMap_Rating);

                                By GMap_ReviewCountBy = By.XPath(XPathStore.GMap_ReviewCount);
                                By GMap_CatagoryBy = By.XPath(XPathStore.GMap_Catagory);

                                AutomationCommon.WaitUntilElementVisible(driver, GMap_HeadingBy, 5);


                                gMapModel.Name = GetString(GMap_HeadingBy);

                                string MobileNumber = GetString(GMap_MobileNumberBy);
                                if (MobileNumber.StartsWith("0"))
                                {
                                    MobileNumber = MobileNumber.Substring(1);
                                }

                                MobileNumber = MobileNumber.Replace(@" ", "");
                                MobileNumber = MobileNumber.Replace(@"(", "");
                                MobileNumber = MobileNumber.Replace(@")", "");
                                MobileNumber = MobileNumber.Replace(@"+", "");
                                MobileNumber = MobileNumber.Replace(@"-", "");
                                gMapModel.mobilenumber = MobileNumber;
                                gMapModel.address = GetString(GMap_AddressBy);
                                gMapModel.website = GetAttributeMulti(GMap_WebSiteBy, "href");
                                gMapModel.PlusCode = GetString(GMap_PlusCodeBy);
                                gMapModel.rating = GetString(GMap_RatingBy);
                                gMapModel.reviewCount = GetString(GMap_ReviewCountBy);
                                gMapModel.category = GetString(GMap_CatagoryBy);

                                gMapModel.Logged = false;
                                int Existcount = gMapModelList.Where(x => x.Name == gMapModel.Name && x.mobilenumber == gMapModel.mobilenumber).Count();
                                if (Existcount == 0)
                                {
                                    gMapModelList.Add(gMapModel);
                                    //var jsExecutor = (IJavaScriptExecutor)driver;
                                    // jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", item, "IsLogged", "true");
                                }
                                else
                                {
                                    logger.WriteLog("Same Name Exist");
                                }
                            }
                            catch (Exception ex)
                            {
                                string ss = "";
                               // results = driver.FindElements(By.XPath(XPathStore.GMap_Result));
                            }

                        }
                    }

                    try
                    {
                        logger.WriteLog("checking Next button ");
                        By nextButtonBy = By.XPath(XPathStore.GMap_NextButton);
                        if (AutomationCommon.IsElementPresent(nextButtonBy, driver))
                        {
                            logger.WriteLog("Next button clicked");
                            driver.FindElement(nextButtonBy).Click();
                            Thread.Sleep(3000);
                        }
                        //AutomationCommon.WaitUntilElementDispose(driver, By.ClassName("IeJeYc"));
                        //if (!AutomationCommon.IsElementPresent(By.ClassName("IeJeYc"), driver))
                        //{
                        //    // needtoSkip = needtoSkip + 20;
                        //}
                    }
                    catch (Exception ex)
                    {
                        logger.WriteLog("ex= " + ex.Message);
                    }



                    //string scrollerJS = " function getElementByXpath(path) { return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue; }; \nvar ss=getElementByXpath('//*[@id=\"QA0Szd\"]/div/div/div[1]/div[2]/div/div[1]/div/div/div[2]/div[1]');";
                    //scrollerJS += "return ss.scrollTop = ss.scrollHeight;";
                    //Int64 divHeight = (Int64)jsFunction.ExecuteScript(scrollerJS);

                    //if (divHeight < 300)
                    //{
                    //    scrollerJS = " function getElementByXpath(path) { return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue; }; \nvar ss=getElementByXpath('//*[@id=\"QA0Szd\"]/div/div/div[1]/div[2]/div/div[1]/div/div/div[3]/div[1]');";
                    //    scrollerJS += "return ss.scrollTop = ss.scrollHeight;";
                    //    try
                    //    {
                    //        divHeight = (Int64)jsFunction.ExecuteScript(scrollerJS);
                    //    }
                    //    catch (Exception)
                    //    {

                    //    }
                    //}

                    ////logger.WriteLog("divHeight = " + divHeight);

                    ////while (results.Count() <= 19)
                    ////{
                    //try
                    //{
                    //    divHeight = (Int64)jsFunction.ExecuteScript(scrollerJS);
                    //}
                    //catch (Exception ex)
                    //{

                    //}
                    //Thread.Sleep(1000);
                    //results = driver.FindElements(By.XPath(XPathStore.GMap_Result));
                    ////}

                    //// logger.WriteLog("results = " + results.Count());

                    //try
                    //{
                    //    IWebElement mainDiv = driver.FindElement(By.XPath("//*[@id=\"QA0Szd\"]/div/div/div[1]/div[2]/div/div[1]/div/div/div[2]/div[1]"));
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Up);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Up);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Up);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);

                    //    for (int i = 0; i < 100; i++)
                    //    {
                    //        mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //    }
                    //    results = driver.FindElements(By.XPath(XPathStore.GMap_Result));
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //}
                    //catch (Exception ex)
                    //{

                    //}

                    //try
                    //{
                    //    IWebElement mainDiv = driver.FindElement(By.XPath("//*[@id=\"QA0Szd\"]/div/div/div[1]/div[2]/div/div[1]/div/div/div[3]/div[1]"));
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Up);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Up);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Up);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //    for (int i = 0; i < 100; i++)
                    //    {
                    //        mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //    }
                    //}
                    //catch (Exception ex)
                    //{

                    //}
                    //foreach (var item in results)
                    //{
                    //    string logged = item.GetAttribute("islogged");
                    //    if (logged == "true")
                    //    {
                    //        continue;
                    //    }
                    //    if (elementHasClass(item, "taggered"))
                    //    {
                    //        continue;
                    //    }
                    //    if (!isStop)
                    //    {
                    //        gMapModel = new GMapModel();
                    //        try
                    //        {
                    //            logger.WriteLog("item Click");
                    //            item.Click();
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            logger.WriteLog("ex=" + ex.Message);
                    //            //jsFunction.ExecuteScript(scrollerJS);
                    //            try
                    //            {
                    //                IWebElement mainDiv = driver.FindElement(By.XPath("//*[@id=\"QA0Szd\"]/div/div/div[1]/div[2]/div/div[1]/div/div/div[2]/div[1]"));
                    //                mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //            }
                    //            catch (Exception exffff)
                    //            {
                    //                try
                    //                {
                    //                    IWebElement mainDiv = driver.FindElement(By.XPath("//*[@id=\"QA0Szd\"]/div/div/div[1]/div[2]/div/div[1]/div/div/div[3]/div[1]"));
                    //                    mainDiv.SendKeys(OpenQA.Selenium.Keys.Down);
                    //                }
                    //                catch (Exception fff)
                    //                {

                    //                }

                    //            }
                    //            driver.Manage().Window.Maximize();
                    //            var ss = item.Location.Y;
                    //            Thread.Sleep(500);
                    //            try
                    //            {
                    //                logger.WriteLog("item Click");
                    //                item.Click();
                    //            }
                    //            catch (Exception)
                    //            {
                    //                string ssggg = "";
                    //            }
                    //        }

                    //        Thread.Sleep(1000);
                    //        logger.WriteLog("Checking for heading..");
                    //        AutomationCommon.WaitUntilElementVisible(driver, By.XPath(XPathStore.GMap_Heading), 40);

                    //        if (AutomationCommon.IsElementPresent(By.XPath(XPathStore.GMap_Heading), driver))
                    //        {
                    //            logger.WriteLog("Heading is present");
                    //        }
                    //        else
                    //        {
                    //            logger.WriteLog("Heading is not present");
                    //        }

                    //        By GMap_HeadingBy = By.XPath(XPathStore.GMap_Heading);
                    //        By GMap_MobileNumberBy = By.XPath(XPathStore.GMap_MobileNumber);

                    //        By GMap_AddressBy = By.XPath(XPathStore.GMap_Address);
                    //        By GMap_WebSiteBy = By.XPath(XPathStore.GMap_WebSite);
                    //        By GMap_PlusCodeBy = By.XPath(XPathStore.GMap_PlusCode);
                    //        By GMap_RatingBy = By.XPath(XPathStore.GMap_Rating);

                    //        By GMap_ReviewCountBy = By.XPath(XPathStore.GMap_ReviewCount);
                    //        By GMap_CatagoryBy = By.XPath(XPathStore.GMap_Catagory);


                    //        AutomationCommon.WaitUntilElementVisible(driver, GMap_HeadingBy, 5);


                    //        gMapModel.Name = GetString(GMap_HeadingBy);

                    //        string MobileNumber = GetString(GMap_MobileNumberBy);
                    //        if (MobileNumber.StartsWith("0"))
                    //        {
                    //            MobileNumber = MobileNumber.Substring(1);
                    //        }

                    //        MobileNumber = MobileNumber.Replace(@" ", "");
                    //        MobileNumber = MobileNumber.Replace(@"(", "");
                    //        MobileNumber = MobileNumber.Replace(@")", "");
                    //        MobileNumber = MobileNumber.Replace(@"+", "");
                    //        MobileNumber = MobileNumber.Replace(@"-", "");
                    //        gMapModel.mobilenumber = MobileNumber;
                    //        gMapModel.address = GetString(GMap_AddressBy);
                    //        gMapModel.website = GetString(GMap_WebSiteBy);
                    //        gMapModel.PlusCode = GetString(GMap_PlusCodeBy);
                    //        gMapModel.rating = GetString(GMap_RatingBy);
                    //        gMapModel.reviewCount = GetString(GMap_ReviewCountBy);
                    //        gMapModel.category = GetString(GMap_CatagoryBy);

                    //        gMapModel.Logged = false;
                    //        int Existcount = gMapModelList.Where(x => x.Name == gMapModel.Name && x.mobilenumber == gMapModel.mobilenumber).Count();
                    //        if (Existcount == 0)
                    //        {
                    //            gMapModelList.Add(gMapModel);

                    //            var jsExecutor = (IJavaScriptExecutor)driver;
                    //            jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", item, "IsLogged", "true");


                    //            logger.WriteLog("addedd in gMapModelList");
                    //        }
                    //    }

                    //}

                    //// for (int i = 0; i < results.Count(); i++)
                    //// {
                    //try
                    //{
                    //    // string changeValScript = "var list=document.getElementsByClassName('Nv2PK');for(var i=0;i < list.length;i++){if(!document.getElementsByClassName('Nv2PK')[i].classList.contains('taggered')){document.getElementsByClassName('Nv2PK')[i].setAttribute('class','taggered');} }";
                    //    //jsFunction.ExecuteScript(changeValScript);
                    //    gloibalCounter++;
                    //}
                    //catch (Exception ex)
                    //{

                    //}

                    //// }

                    //logger.WriteLog("Loop completed");
                    //if (!isStop)
                    //{

                    //    try
                    //    {
                    //        logger.WriteLog("checking Next button ");
                    //        By nextButtonBy = By.XPath(XPathStore.GMap_NextButton);
                    //        if (AutomationCommon.IsElementPresent(nextButtonBy, driver))
                    //        {
                    //            logger.WriteLog("Next button clicked");
                    //            driver.FindElement(nextButtonBy).Click();
                    //        }
                    //        AutomationCommon.WaitUntilElementDispose(driver, By.ClassName("IeJeYc"));
                    //        if (!AutomationCommon.IsElementPresent(By.ClassName("IeJeYc"), driver))
                    //        {
                    //            // needtoSkip = needtoSkip + 20;
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        logger.WriteLog("ex= " + ex.Message);
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    string ssss = "";
                }

            }

        }

        System.Windows.Forms.Timer timerRunner;

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
                materialButton5.Text = "Save: Members = " + gMapModelList.Count().ToString();
                button3.Text = "Export: Members = " + gMapModelList.Count().ToString();

                foreach (var item in gMapModelList)
                {
                    if (item.Logged == false)
                    {
                        var globalCounter = dataGridView1.Rows.Count - 1;
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[globalCounter].Cells[0].Value = item.Name;


                        dataGridView1.Rows[globalCounter].Cells[1].Value = item.mobilenumber;
                        dataGridView1.Rows[globalCounter].Cells[2].Value = item.reviewCount;
                        dataGridView1.Rows[globalCounter].Cells[3].Value = item.rating;
                        dataGridView1.Rows[globalCounter].Cells[4].Value = item.category;
                        dataGridView1.Rows[globalCounter].Cells[5].Value = item.address;
                        dataGridView1.Rows[globalCounter].Cells[6].Value = item.website;
                        dataGridView1.Rows[globalCounter].Cells[7].Value = item.PlusCode;
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                        item.Logged = true;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }


        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (initStatusEnum != InitStatusEnum.Initialised)
            {
                Utils.showAlert(Strings.PleasefollowStepNo1FirstInitialiseWhatsapp, Alerts.Alert.enmType.Error);
                return;
            }
            else if (!IsResultShown())
            {
                Utils.showAlert(Strings.PleaseSearchsomething, Alerts.Alert.enmType.Info);
            }
            else if (campaignStatusEnum != CampaignStatusEnum.Running)
            {
                isStop = false;
                initBackgroundWorker();
                worker.RunWorkerAsync();
                ChangeCampStatus(CampaignStatusEnum.Running);
            }
            else
            {
                Utils.showAlert(Strings.Processisalreadyrunning, Alerts.Alert.enmType.Info);
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (timerRunner != null)
            {
                timerRunner.Stop();
            }
            worker.CancelAsync();
            isStop = true;
            ChangeCampStatus(CampaignStatusEnum.Stopped);
        }

        private void GMapExtractor_FormClosing(object sender, FormClosingEventArgs e)
        {

            logger.Complete();
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
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            logger.Complete();
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {

            }
            this.Close();
            this.waSenderForm.gmapDataReturn(this.gMapModelList);
        }

        private void Initiate()
        {

            String FolderPath = Config.GetTempFolderPath();
            String file = Path.Combine(FolderPath, "GMapData" + Guid.NewGuid().ToString() + ".xlsx");
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

                ws.Cells[1, 1].Value = "Name";
                ws.Cells[1, 2].Value = "Mobile Number";
                ws.Cells[1, 3].Value = "Review Count";
                ws.Cells[1, 4].Value = "Rating";
                ws.Cells[1, 5].Value = "Category";
                ws.Cells[1, 6].Value = "Address";
                ws.Cells[1, 7].Value = "Website";
                ws.Cells[1, 8].Value = "PlusCode";


                for (int i = 0; i < gMapModelList.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = gMapModelList[i].Name;
                    ws.Cells[i + 2, 2].Value = gMapModelList[i].mobilenumber;
                    ws.Cells[i + 2, 3].Value = gMapModelList[i].reviewCount;
                    ws.Cells[i + 2, 4].Value = gMapModelList[i].rating;
                    ws.Cells[i + 2, 5].Value = gMapModelList[i].category;
                    ws.Cells[i + 2, 6].Value = gMapModelList[i].address;
                    ws.Cells[i + 2, 7].Value = gMapModelList[i].website;
                    ws.Cells[i + 2, 8].Value = gMapModelList[i].PlusCode;
                    contacts1.Numbers.Add(gMapModelList[i].mobilenumber);
                    contacts1.ContactNames.Add(gMapModelList[i].Name);
                }
                xlPackage.Save();
            }


            savesampleExceldialog.FileName = "GMapData.xlsx";

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


        bool save = false;
        private void materialButton3_Click(object sender, EventArgs e)
        {
            save = true;
            Initiate();
        }

        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");

        private void GMapExtractor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "L, Alt")
            {
                //GeneralSettings s = new GeneralSettings();
                //s.ShowDialog();
                string file= logger.CompleteWithPath();

                savesampleExceldialog.FileName = "GMapLogger.json";
                if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(file, savesampleExceldialog.FileName.EndsWith(".json") ? savesampleExceldialog.FileName : savesampleExceldialog.FileName + ".json", true);
                    Utils.showAlert(Strings.Filedownloadedsuccessfully, Alerts.Alert.enmType.Success);
                }
            }
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
