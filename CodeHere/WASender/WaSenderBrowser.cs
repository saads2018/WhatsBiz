using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WASender.Models;

namespace WASender
{
    public partial class WaSenderBrowser : Form
    {
        public bool isMultiMode { get; set; }
        public string sessionId { get; set; }


        public List<ConnectedAccountModel> selectedAccounts;
        public WaSenderBrowser(List<ConnectedAccountModel> _selectedAccounts)
        {
            InitializeComponent();
            isMultiMode = true;
            this.sessionId = "";
            this.selectedAccounts = _selectedAccounts;
        }
        public WaSenderBrowser()
        {
            InitializeComponent();
            isMultiMode = false;
            this.sessionId = "";
        }
        public WaSenderBrowser(bool _isMultiMode = false)
        {
            InitializeComponent();
            isMultiMode = _isMultiMode;
        }

        public WaSenderBrowser(string _sessionId = "")
        {
            InitializeComponent();
            isMultiMode = false;
            sessionId = _sessionId;
        }

        private void WaSenderBrowser_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            label1.Text = "Loading";
            CheckForSessions();
        }

        private void CheckForSessions()
        {
            DataTable Data = new SqLiteBaseRepository().ReadData();
            if (Data.Rows.Count == 0)
            {
                new SqLiteBaseRepository().AddSession("Profile1");
            }
            if (isMultiMode == false && (sessionId == null || sessionId == ""))
            {
                Data = new SqLiteBaseRepository().ReadData(true);
            }
            else
            {
                if (sessionId != null && sessionId != "")
                {
                    Data = new SqLiteBaseRepository().getBySessionId(sessionId);
                }
                else
                {
                    Data = new SqLiteBaseRepository().ReadData();
                    //foreach (DataRow item in Data.Rows)
                    //{
                    //    string ss = item["isDefault"].ToString();
                    //    if (ss == "1")
                    //    {
                    //        item["sessionName"] = item["sessionName"].ToString() + "(" + Strings.Primary + ")";
                    //    }
                    //}

                    if (selectedAccounts != null && selectedAccounts.Count() > 0)
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Id");
                        dt.Columns.Add("sessionName");
                        dt.Columns.Add("sesionId");
                        dt.Columns.Add("isDefault");
                        foreach (DataRow item in Data.Rows)
                        {
                            int count = selectedAccounts.Where(x => x.ID == item["ID"].ToString()).Count();
                            if (count > 0)
                            {
                                DataRow _ravi = dt.NewRow();
                                _ravi["ID"] = item["ID"];
                                _ravi["sessionName"] = item["sessionName"];
                                _ravi["sesionId"] = item["sesionId"];
                                _ravi["isDefault"] = item["isDefault"];
                                dt.Rows.Add(_ravi);
                            }
                        }
                        Data = dt;
                    }
                }

            }

            if (Data.Rows.Count > 0)
            {
                tabControl1.Show();
            }
            else
            {
                tabControl1.Hide();
                label1.Text = Strings.YouhaventaddedanyaccountyetToaddnewaccountpleaseuseACCOUNTSbutton;
            }



            try
            {
                Data.DefaultView.Sort = "isDefault desc";
                Data = Data.DefaultView.ToTable();
            }
            catch (Exception ex)
            {

            }


            foreach (DataRow item in Data.Rows)
            {
                bool isAlreadyExist = false;
                List<string> currentList = new List<string>();
                foreach (TabPage tabpage in tabControl1.TabPages)
                {
                    currentList.Add(tabpage.Text);
                }

                int existCount = currentList.Where(_ => _ == item["sessionName"].ToString()).ToList().Count();
                if (existCount > 0)
                {
                    isAlreadyExist = true;
                }

                if (!isAlreadyExist)
                {
                    var page = new TabPage(item["sessionName"].ToString());

                    MainUC uc = new MainUC(item["sesionID"].ToString());
                    uc.Dock = DockStyle.Fill;
                    page.Dock = DockStyle.Fill;
                    page.Controls.Add(uc);
                    page.Tag = item;
                    tabControl1.TabPages.Add(page);

                    tabControl1.Visible = true;
                    label1.Visible = false;

                }

            }
        }

        private void WaSenderBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.waSenderBrowser = null;
            // Utils.waSenderBrowserValueChange()
            TestClass _textClass = Utils.testClass;
            _textClass.UpdateStatus("");
        }
    }
}
