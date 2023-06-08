using MaterialSkin.Controls;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WASender.enums;
using WASender.Model;
using WASender.Models;

namespace WASender
{
    public partial class LinkedInDataExtractor : Form
    {
        InitStatusEnum initStatusEnum;
        IWebDriver driver;
        BackgroundWorker worker;
        List<IWebElement> elements;
        IWebElement element;
        CampaignStatusEnum campaignStatusEnum;
        WaSenderForm waSenderForm;
        List<GMapModel> gMapModelList;
        MainNavPage mainNavPage;
        IndividualContacts importContacts;
        List<IWebElement> pages;
        LinkedInDivs divs;
        bool isStopped = true;
        string searchOption;
        int pagesToSkip=0;
        object prevItem;

        public LinkedInDataExtractor(WaSenderForm _WASender, MainNavPage mainNavPage)
        {
            InitializeComponent();
            this.waSenderForm = _WASender;
            elements = new List<IWebElement>();
            pages = new List<IWebElement>();
            element = null;
            this.mainNavPage = mainNavPage;
            divs = new LinkedInDivs();
            searchOption = "people";
            InitializeComponent();

            initializeResolution();
        }

        public void setTableHeaders()
        {
            string value = materialComboBox1.Items[materialComboBox1.SelectedIndex].ToString().ToLower();
            searchOption = value;
            prevItem = materialComboBox1.SelectedItem;

            for(int i=0;i<this.dataGridView1.Columns.Count;i++)
            {
                try
                {
                    this.dataGridView1.Columns[i].Visible = true;
                    this.dataGridView1.Columns[i].HeaderText = divs.searchTypes[value].headerTexts[i];
                }
                catch
                {
                    this.dataGridView1.Columns[i].Visible = false;
                }
            }
        }
        private void initializeResolution()
        {
            if ((Program.resWidth == 1280 && Program.resHeight == 1024))
            {
                this.Size = new Size(this.Width - 100, this.Height);
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

        private void initBackgroundWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }
      

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (searchOption == "jobs")
                extractJobs();
            else
                extractInformation();
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
        private void ChangeInitStatus(InitStatusEnum _initStatus)
        {
            this.initStatusEnum = _initStatus;
            AutomationCommon.ChangeInitStatus(_initStatus, lblInitStatus);
        }

        public void InputReturn(string searchTurm)
        {
            //ChangeInitStatus(InitStatusEnum.Initialising);        
            try
            {
                // Config.KillChromeDriverProcess();
                var chromeDriverService = ChromeDriverService.CreateDefaultService(Config.GetChromeDriverFolder());
                chromeDriverService.HideCommandPromptWindow = true;

                if (driver != null)
                    driver.Quit();

                    driver = new ChromeDriver(chromeDriverService, Config.GetChromeOptionsGMAP());
                try
                {
                    var link = "";

                    if (searchOption == "courses")
                        link = "https://www.linkedin.com/search/results/learning/?keywords="+searchTurm;
                    else if (searchOption == "jobs")
                        link = "https://www.linkedin.com/jobs/search/?keywords=" + searchTurm;
                    else
                        link = "https://www.linkedin.com/search/results/"+ searchOption + "/?keywords=" + searchTurm;

                    driver.Url = link;

                    Activate();

                }
                catch (Exception ex)
                {

                }
                //ChangeInitStatus(InitStatusEnum.Initialised);

            }
            catch (Exception ex)
            {
                //ChangeInitStatus(InitStatusEnum.Unable);
             
                string ss = "";
                if (ex.Message.Contains("session not created"))
                {
                    DialogResult dr = MessageBox.Show("Your Chrome Driver and Google Chrome Version Is not same, Click 'Yes botton' to Update it from Settings", "Error ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void extractInformation()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");


            AutomationCommon.WaitUntilElementVisible(driver, By.ClassName("artdeco-pagination__indicator"));

            bool justOne = true;
            var limit = 1;
            List<IWebElement> pages = driver.FindElements(By.ClassName("artdeco-pagination__indicator")).ToList();
            if(pages.Count > 0)
            {
                limit = Int32.Parse(pages.LastOrDefault().Text);
                justOne = false;
            }


            for (int i = 1+pagesToSkip; i <= limit; i++)
            {
                if (isStopped)
                    break;

                List<IWebElement> elements = driver.FindElements(By.ClassName("entity-result__content")).ToList();

                if (elements.Count > 0)
                {
                    foreach (var element in elements.Skip(needToSkip))
                    {
                        var globalCounter = dataGridView1.Rows.Count - 1;

                        dataGridView1.Invoke((MethodInvoker)delegate
                        {
                            dataGridView1.Rows.Add();
                        });

                        for (int j = 0; j < divs.searchTypes[searchOption].divLocations.Count; j++)
                        {
                            validate(globalCounter, element, divs.searchTypes[searchOption].divLocations[j], j);
                        }

                        if (searchOption == "services")
                        {
                            var services = element.FindElement(By.ClassName("reusable-search-labels-insight__container"));

                            if (services != null)
                            {
                                var servicesList = services.FindElements(By.TagName("span")).ToList();
                                servicesList.Remove(servicesList.Where(x => x.Text.Contains("+")).FirstOrDefault());
                                string serviceCollection = "";

                                foreach (var service in servicesList)
                                    serviceCollection += service == servicesList.LastOrDefault() ? service.GetAttribute("textContent") : service.GetAttribute("textContent") + ", ";

                                this.dataGridView1.Rows[globalCounter].Cells[divs.searchTypes[searchOption].divLocations.Count].Value = serviceCollection;
                            }
                        }

                        if (searchOption == "people")
                        {
                            var link = element.FindElement(By.XPath("div/div[1]/div/span[1]/span/a"));
                            this.dataGridView1.Rows[globalCounter].Cells[divs.searchTypes[searchOption].divLocations.Count].Value = link.GetAttribute("href").Trim();
                        }

                        dataGridView1.Invoke((MethodInvoker)delegate
                        {
                            this.dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;

                        });
                        isClear = false;
                        needToSkip += 1;
                    }
                }
                else
                    break;


                if (i == limit)
                    break;
                else
                {
                    pages[pages.IndexOf(pages.Where(x => x.Text.Trim().Contains((i).ToString())).FirstOrDefault())+1].Click();
                    Thread.Sleep(1500);
                    AutomationCommon.WaitUntilElementVisible(driver, By.ClassName("entity-result__content"));
                    IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)driver;
                    jsExecutor1.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                    AutomationCommon.WaitUntilElementVisible(driver, By.ClassName("artdeco-pagination__indicator"));
                    pages = driver.FindElements(By.ClassName("artdeco-pagination__indicator")).ToList();
                    pagesToSkip = i;
                    needToSkip = 0;
                }

            }

        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            isStopped = false;
            initBackgroundWorker();
            worker.RunWorkerAsync();
        }

        int needToSkip = 0;
        private void extractJobs()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("document.getElementsByClassName('jobs-search-results-list')[0].scrollTop = document.getElementsByClassName('jobs-search-results-list')[0].scrollHeight;");
            jsExecutor.ExecuteScript("document.getElementsByClassName('jobs-search-results-list')[0].scrollTop = document.getElementsByClassName('jobs-search-results-list')[0].scrollHeight;");
            jsExecutor.ExecuteScript("document.getElementsByClassName('jobs-search-results-list')[0].scrollTop = document.getElementsByClassName('jobs-search-results-list')[0].scrollHeight;");

            AutomationCommon.WaitUntilElementVisible(driver, By.ClassName("artdeco-pagination__indicator"));

            bool justOne = true;
            var limit = 1;
            List<IWebElement> pages = driver.FindElements(By.ClassName("artdeco-pagination__indicator")).ToList();
            if(pages.Count>0)
            {
                limit = Int32.Parse(pages.LastOrDefault().Text);
                justOne = false;
            }

            for (int i = 1+ pagesToSkip; i <= limit; i++)
            {

                List<IWebElement> elements = driver.FindElements(By.ClassName("job-card-container")).ToList();
                
                if (elements.Count > 0)
                {
                    IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)driver;
                    jsExecutor1.ExecuteScript("document.getElementsByClassName('jobs-search-results-list')[0].scrollTop = 0;\r\n\r\nfor (let i = 0; i < "+needToSkip+";i++) {\r\n  document.getElementsByClassName('jobs-search-results-list')[0].scrollTop += document.getElementsByClassName('job-card-container')[i].clientHeight\r\n}");

                    elements = driver.FindElements(By.ClassName("job-card-container")).ToList();

                    if (element == null)
                        element = elements.First();
                    else
                    {
                        try
                        {
                            element = elements[elements.IndexOf(element) + 1];
                        }
                        catch
                        {
                            if (!justOne && !pages.LastOrDefault().Text.Trim().Contains(i.ToString()))
                            {
                                AutomationCommon.WaitUntilElementVisible(driver, By.ClassName("artdeco-pagination__indicator"));
                                pages = driver.FindElements(By.ClassName("artdeco-pagination__indicator")).ToList();
                                pages[pages.IndexOf(pages.Where(x => x.Text.Trim().Contains((i).ToString())).FirstOrDefault()) + 1].Click();
                                AutomationCommon.WaitUntilElementVisible(driver, By.ClassName("job-card-container"));
                                elements = driver.FindElements(By.ClassName("job-card-container")).ToList();
                                element = elements.First();
                                pagesToSkip = i;
                                needToSkip = 0;
                            }
                            else
                                break;
                        }
                    }

                    int counter = 0;
                    do
                    {
                        element.Click();
                        AutomationCommon.WaitUntilElementVisible(driver, By.ClassName("jobs-unified-top-card__job-title"));
                        var globalCounter = dataGridView1.Rows.Count - 1;

                        dataGridView1.Invoke((MethodInvoker)delegate
                        {
                            dataGridView1.Rows.Add();
                        });

                        AutomationCommon.WaitUntilElementVisible(driver, By.XPath("/html/body/div[5]/div[3]/div[4]/div/div/main/div/div[2]/div/div[2]/div[1]/div/div[1]/div/div[1]/div[1]/div[2]/span[1]/span[1]/a"));
                        validateJobInfo(globalCounter, driver.FindElement(By.ClassName("jobs-unified-top-card__job-title")), 0);
                        validateJobInfo(globalCounter, driver.FindElements(By.ClassName("ember-view")).Where(x => x.GetAttribute("class") == "ember-view t-black t-normal").FirstOrDefault(), 1);
                        validateJobInfo(globalCounter, driver.FindElements(By.ClassName("jobs-unified-top-card__bullet")).Where(x => !x.Text.ToLower().Contains("applicant")).FirstOrDefault(), 2);
                        validateJobInfo(globalCounter, driver.FindElements(By.ClassName("jobs-unified-top-card__workplace-type")).FirstOrDefault(), 3);
                        validateJobInfo(globalCounter, driver.FindElement(By.ClassName("jobs-unified-top-card__posted-date")), 4);
                        validateJobInfo(globalCounter, driver.FindElements(By.ClassName("jobs-unified-top-card__bullet")).Where(x => x.Text.ToLower().Contains("applicant")).FirstOrDefault(), 5);

                        validateJobInfo(globalCounter, driver.FindElements(By.ClassName("jobs-unified-top-card__job-insight")).Where(x => x.FindElement(By.TagName("li-icon")).GetAttribute("type") == "job").FirstOrDefault(), 6);
                        validateJobInfo(globalCounter, driver.FindElements(By.ClassName("jobs-unified-top-card__job-insight")).Where(x => x.FindElement(By.TagName("li-icon")).GetAttribute("type") == "company").FirstOrDefault(), 7);

                        try
                        {
                            var checkList = driver.FindElement(By.ClassName("jobs-unified-top-card__job-insight-text-button"));
                            if (checkList != null)
                            {
                                checkList.Click();
                                AutomationCommon.WaitUntilElementVisible(driver, By.ClassName("job-details-skill-match-status-list"));

                                var skillList = driver.FindElement(By.ClassName("job-details-skill-match-status-list"));
                                var skills = skillList.FindElements(By.TagName("li"));

                                var skillsRecord = "";
                                foreach (var skill in skills)
                                    skillsRecord += skill == skills.LastOrDefault() ? skill.Text.Replace("Add", "") : skill.Text.Replace("Add", "") + ", ";

                                this.dataGridView1.Rows[globalCounter].Cells[8].Value = skillsRecord;
                                driver.FindElement(By.XPath("/html/body/div[3]/div/div/button")).Click();
                            }
                        }
                        catch
                        {
                            
                        }

                        dataGridView1.Invoke((MethodInvoker)delegate
                        {
                            this.dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;

                        });
                        isClear = false;
                        needToSkip += 1;

                        if (isStopped)
                            break;

                        IJavaScriptExecutor jsExecutor2 = (IJavaScriptExecutor)driver;
                        jsExecutor2.ExecuteScript("document.getElementsByClassName('jobs-search-results-list')[0].scrollTop += document.getElementsByClassName('job-card-container')["+counter+"].clientHeight");

                        elements = driver.FindElements(By.ClassName("job-card-container")).ToList();

                        try
                        {
                            element = elements[elements.IndexOf(element) + 1];
                            counter++;
                        }
                        catch
                        {
                            element = null;
                        }

                    } while (element != null);
                }
                else
                    break;

                if (isStopped)
                    break;

                if (i == limit)
                    break;
                else
                {
                    pages[pages.IndexOf(pages.Where(x => x.Text.Trim().Contains((i).ToString())).FirstOrDefault()) + 1].Click();
                    Thread.Sleep(1500);
                    AutomationCommon.WaitUntilElementVisible(driver, By.ClassName("jobs-search-results-list"));
                    IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)driver;
                    jsExecutor1.ExecuteScript("document.getElementsByClassName('jobs-search-results-list')[0].scrollTop = document.getElementsByClassName('jobs-search-results-list')[0].scrollHeight;");
                    jsExecutor1.ExecuteScript("document.getElementsByClassName('jobs-search-results-list')[0].scrollTop = document.getElementsByClassName('jobs-search-results-list')[0].scrollHeight;");
                    jsExecutor1.ExecuteScript("document.getElementsByClassName('jobs-search-results-list')[0].scrollTop = document.getElementsByClassName('jobs-search-results-list')[0].scrollHeight;");
                    AutomationCommon.WaitUntilElementVisible(driver, By.ClassName("artdeco-pagination__indicator"));
                    pages = driver.FindElements(By.ClassName("artdeco-pagination__indicator")).ToList();
                    pagesToSkip = i;
                    needToSkip = 0;
                }

            }

        }

        public void validate(int counter,IWebElement element,string path,int index)
        {
            try
            {
                var value = element.FindElement(By.XPath(path));
                this.dataGridView1.Rows[counter].Cells[index].Value = value.Text;
            }
            catch
            {

            }


        }

        public void validateJobInfo(int counter, IWebElement element, int index)
        {
            try
            {
                this.dataGridView1.Rows[counter].Cells[index].Value = element.Text;
            }
            catch
            {

            }
        }

        int jobCounter = 0;
        int pageCounter = 0;
        bool justOne = true;
        int limit = 1;

        private void materialButton2_Click(object sender, EventArgs e)
        {
            isStopped = true;
            worker.CancelAsync();
        }
        int cond = 0;
        bool isClear = true;
        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isClear)
            {
                if (cond == 0 && MessageBox.Show("Are you sure you want to delete existing records?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning).ToString() == "OK")
                {
                    setTableHeaders();
                    isClear = true;
                    this.dataGridView1.Rows.Clear();
                }
                else if (cond == 1)
                    cond = 0;
                else
                {
                    cond = 1;
                    this.materialComboBox1.SelectedItem = prevItem;
                }
            }
            else
                setTableHeaders();
        }

        private void LinkedInDataExtractor_Load(object sender, EventArgs e)
        {
            setTableHeaders();
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
