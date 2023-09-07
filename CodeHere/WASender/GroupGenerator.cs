using MaterialSkin.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WASender.enums;
using WASender.Models;

namespace WASender
{
    public partial class BulkGroupGenerator : Form
    {
        InitStatusEnum initStatusEnum;
        System.Windows.Forms.Timer timerInitChecker;
        IWebDriver driver;
        BackgroundWorker worker;
        CampaignStatusEnum campaignStatusEnum;
        System.Windows.Forms.Timer timerRunner;
        Logger logger;
        MainNavPage main;

        public BulkGroupGenerator(MainNavPage _main)
        {
            InitializeComponent();
            logger = new Logger("Group Generator");
            main= _main;
            //waSenderForm = _waSenderForm;
            if (Utils.Driver != null)
            {
                Utils.SetDriver();
                driver = Utils.Driver;
                initWA();
            }
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

                }


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
                        GeneralSettings generalSettings = new GeneralSettings(this.main);
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

        private async void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Main Job

            int counter = 0;
            int totalCounter = 0;

            try
            {
                logger.WriteLog("initing WAPI");
                WAPIHelper.IsWAPIInjected(driver);
            }
            catch (Exception ex)
            {
                string ss = "";
                logger.WriteLog(ex.Message);
                //msg = ex.Message;
                //MessageBox.Show(ex.Message);
            }

            if (!WAPIHelper.IsWAPIInjected(driver))
            {
                ProjectCommon.injectWapi(driver);
            }



            Thread.Sleep(1000);

            int chunkSeperator = Convert.ToInt32(txtdelayAfterMessages.Text);
            if (chunkSeperator >= groupGeneratorModel.contactList.Count())
            {
                chunkSeperator = groupGeneratorModel.contactList.Count();
            }

            var ss_ = LinqHelpers.Chunk(groupGeneratorModel.contactList, chunkSeperator).ToList();

            //int GapBetweenGroups = Convert.ToInt32(txtdelayAfterMessages.Text);
            //int i = 0;

            foreach (var chunk in ss_)
            {
                List<ContactModel> lisr = chunk.ToList();

                foreach (var item in lisr)
                {

                    try
                    {
                        WAPIHelper.CreateGroup(driver, item.name, groupGeneratorModel.DefaultNumberAdd);
                        item.sendStatusModel.sendStatusEnum = SendStatusEnum.Success;
                        item.sendStatusModel.isDone = true;
                    }
                    catch (Exception ex)
                    {
                        item.sendStatusModel.sendStatusEnum = SendStatusEnum.Failed;
                        item.sendStatusModel.isDone = true;
                    }

                    try
                    {
                        int _rand = Utils.getRandom(Convert.ToInt32(txtdelayAfterEveryMessageFrom.Text), Convert.ToInt32(txtdelayAfterEveryMessageTo.Text));
                        Thread.Sleep(TimeSpan.FromSeconds(_rand));
                    }
                    catch (Exception ex)
                    {

                    }
                }

                try
                {
                    int _rand = Utils.getRandom(Convert.ToInt32(txtdelayAfterMessagesFrom.Text), Convert.ToInt32(txtdelayAfterMessagesTo.Text));
                    Thread.Sleep(TimeSpan.FromSeconds(_rand));
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblPersentage.Text = e.ProgressPercentage + "% " + Strings.Completed;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ChangeCampStatus(CampaignStatusEnum.Finish);
            stopProgressbar();
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

        private bool ValidateControl(bool show = false)
        {

            string Message = "";
            bool returnValue = true;
            if (materialTextBox21.Text == "")
            {
                Message = Strings.GroupNamePrefix + " " + Strings.ShouldNotbeempty;
                returnValue = false;
            }
            if (materialTextBox22.Text == "")
            {
                Message = Strings.Increment + " " + Strings.ShouldNotbeempty;
                returnValue = false;
            }

            try
            {
                Convert.ToInt32(materialTextBox22.Text);
            }
            catch (Exception ex)
            {
                Message = Strings.Increment + " " + Strings.IsNotValid;
                returnValue = false;
            }

            if (materialTextBox24.Text == "")
            {
                Message = Strings.DefaultNumberAdd + " " + Strings.ShouldNotbeempty;
                returnValue = false;
            }

            if (materialTextBox25.Text == "")
            {
                Message = Strings.GenerateTotalGroups + " " + Strings.ShouldNotbeempty;
                returnValue = false;
            }

            try
            {
                Convert.ToInt32(materialTextBox25.Text);
            }
            catch (Exception ex)
            {
                Message = Strings.GenerateTotalGroups + " " + Strings.IsNotValid;
                returnValue = false;
            }
            if (Message != "")
            {
                MessageBox.Show(Message, Strings.Errors, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(returnValue && show)
            {
                MessageBox.Show("All Input Values Are Valid!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            returnValue = SetFocusIfEmpty(txtdelayAfterMessagesFrom);
            returnValue = SetFocusIfEmpty(txtdelayAfterMessagesTo);
            returnValue = SetFocusIfEmpty(txtdelayAfterMessages);
            returnValue = SetFocusIfEmpty(txtdelayAfterEveryMessageFrom);
            returnValue = SetFocusIfEmpty(txtdelayAfterEveryMessageTo);

            return returnValue;
        }

        private bool SetFocusIfEmpty(TextBox txt)
        {
            bool returnValue = true;
            if (txt.Text == "")
            {
                txt.Focus();
                returnValue = false;
            }
            try
            {
                Convert.ToInt32(txt.Text);
            }
            catch (Exception ex)
            {
                txt.Focus();
                returnValue = false;
            }
            return returnValue;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ValidateControl(true);
        }

        private void BulkGroupGenerator_Load(object sender, EventArgs e)
        {
            init();
        }

        public void init()
        {
            logger.WriteLog("init");
            ChangeInitStatus(InitStatusEnum.NotInitialised);
            ChangeCampStatus(CampaignStatusEnum.NotStarted);
            materialCheckbox1.Checked = true;
            materialCheckbox2.Checked = true;
        }

        private void btnInitWA_Click(object sender, EventArgs e)
        {
            if (ValidateControl() == true)
            {
                initWA();
            }

        }

        private void btnSTart_Click(object sender, EventArgs e)
        {
            if(ValidateControl() == true)
            {
                if (campaignStatusEnum == CampaignStatusEnum.Finish)
                {
                    gridStatus.Rows.Clear();
                }

                if (campaignStatusEnum == CampaignStatusEnum.Paused)
                {

                    ChangeCampStatus(CampaignStatusEnum.Running);
                    startProgressBar();
                }
                else
                {
                    ValidateControlsGroup();
                }
            }
        }

        private void ValidateControlsGroup()
        {
            groupGeneratorModel = new GroupGeneratorModel();
            groupGeneratorModel.contactList = new List<ContactModel>();

            ContactModel contact;
            if (initStatusEnum != InitStatusEnum.Initialised)
            {
                Utils.showAlert(Strings.PleaseFollowStepnoThree, Alerts.Alert.enmType.Error);
                return;
            }

            int totalGrouptoCreate = Convert.ToInt32(materialTextBox25.Text);

            int currentIncrement = Convert.ToInt32(materialTextBox22.Text);

            groupGeneratorModel.contactList = new List<ContactModel>();
            for (int i = 0; i < totalGrouptoCreate; i++)
            {
                contact = new ContactModel();
                contact.name = materialTextBox21.Text + currentIncrement.ToString() + materialTextBox23.Text;
                contact.sendStatusModel = new SendStatusModel { isDone = false };
                groupGeneratorModel.contactList.Add(contact);
                currentIncrement = currentIncrement + Convert.ToInt32(materialTextBox22.Text);
            }
            groupGeneratorModel.DefaultNumberAdd = materialTextBox24.Text;
            groupGeneratorModel.singleSettingModel = new SingleSettingModel();
            groupGeneratorModel.singleSettingModel.delayAfterMessages = Convert.ToInt32(txtdelayAfterMessages.Text);
            groupGeneratorModel.singleSettingModel.delayAfterMessagesFrom = Convert.ToInt32(txtdelayAfterMessagesFrom.Text);
            groupGeneratorModel.singleSettingModel.delayAfterMessagesTo = Convert.ToInt32(txtdelayAfterMessagesTo.Text);
            groupGeneratorModel.singleSettingModel.delayAfterEveryMessageFrom = Convert.ToInt32(txtdelayAfterEveryMessageFrom.Text);
            groupGeneratorModel.singleSettingModel.delayAfterEveryMessageTo = Convert.ToInt32(txtdelayAfterEveryMessageTo.Text);
            if (campaignStatusEnum != CampaignStatusEnum.Running)
            {
                worker.RunWorkerAsync();
                ChangeCampStatus(CampaignStatusEnum.Running);
                startProgressBar();
                initTimer();
            }
        }

        private void initTimer()
        {
            timerRunner = new System.Windows.Forms.Timer();
            timerRunner.Interval = 1000;
            timerRunner.Tick += timerRunnerChecker_Tick;
            timerRunner.Start();
        }
        GroupGeneratorModel groupGeneratorModel;

        public void timerRunnerChecker_Tick(object sender, EventArgs e)
        {
            int i = 1;
            foreach (var item in groupGeneratorModel.contactList)
            {
                if (item.sendStatusModel.isDone == true && item.logged == false)
                {
                    var globalCounter = gridStatus.Rows.Count - 1;
                    gridStatus.Rows.Add();
                    gridStatus.Rows[globalCounter].Cells[0].Value = globalCounter+1;
                    gridStatus.Rows[globalCounter].Cells[1].Value = item.name;
                    gridStatus.Rows[globalCounter].Cells[2].Value = item.sendStatusModel.sendStatusEnum;
                    gridStatus.FirstDisplayedScrollingRowIndex = gridStatus.RowCount - 1;
                    item.logged = true;
                    i = i + 1;
                }
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

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
