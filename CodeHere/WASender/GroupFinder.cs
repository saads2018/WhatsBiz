using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaAutoReplyBot;
using WASender.Models;
using WASender.Validators;
using FluentValidation.Results;
using MaterialSkin.Controls;
using System.Threading;
using RestSharp;
using OfficeOpenXml;
using System.IO;
using Newtonsoft.Json;

namespace WASender
{
    public partial class GroupFinder : MaterialForm
    {
        WaSenderForm waSenderForm;
        private static int group_no = 0;
        int count = 0;
        private static int cntr = 0;
        private static bool IsRunning = false;
        private string Searchturm = "";
        MainNavPage mainNavPage;
        GroupContact importGroups;

        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        public GroupFinder(WaSenderForm _waSenderForm, MainNavPage mainNavPage)
        {
            InitializeComponent();
            this.waSenderForm = _waSenderForm;
            this.mainNavPage = mainNavPage;
            group_no = 0;
            cntr = 0;
            IsRunning = false;
            Searchturm = "";

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

        private void GroupFinder_Load(object sender, EventArgs e)
        {
            initLanguages();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        }

        private void initLanguages()
        {
            this.Text = Strings.GroupFinder;
            materialTextBox21.Hint = Strings.GroupSubject;
            materialTextBox21.HelperText = Strings.GroupSubject;
            materialButton1.Text = Strings.Start;
            materialButton2.Text = Strings.Stop;
/*            materialButton3.Text = Strings.ImportInGroupJoiner;
*/            dataGridView1.Columns[0].HeaderText = Strings.GroupName;
            dataGridView1.Columns[1].HeaderText = Strings.GroupLink;
/*            materialButton5.Text = Strings.Export;
*/
        }

        string entry = "";
        private void materialButton1_Click(object sender, EventArgs e)
        {

            if (materialTextBox21.Text != entry)
            {
                dataGridView1.Rows.Clear();
                materialButton5.Text = "Save: Members = 0";
                button3.Text = "Export: Members = 0";
                cntr = 0;
                count = 0;
            }


            entry = materialTextBox21.Text;
            startProgressBar();
            IsRunning = true;
            Searchturm = materialTextBox21.Text;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            try
            {
                backgroundWorker1.RunWorkerAsync();
                timer1.Interval = 1000;
                timer1.Start();
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;
            e.Result = BackgroundProcessLogicMethod(helperBW);
            if (helperBW.CancellationPending)
            {
                e.Cancel = true;
            }
        }



        private int BackgroundProcessLogicMethod(BackgroundWorker bw)
        {
            //int result = 0;
            //Thread.Sleep(20000);
            //MessageBox.Show("I was doing some work in the background.");
            while (IsRunning)
            {
                var client = new RestClient("https://groupsor.link/group/searchmore/" + Searchturm);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Cookie", "ci_session=a%3A5%3A%7Bs%3A10%3A%22session_id%22%3Bs%3A32%3A%22f4acd9ae0adfb8dad9c3ff1164996c83%22%3Bs%3A10%3A%22ip_address%22%3Bs%3A13%3A%22172.71.198.72%22%3Bs%3A10%3A%22user_agent%22%3Bs%3A21%3A%22PostmanRuntime%2F7.29.2%22%3Bs%3A13%3A%22last_activity%22%3Bi%3A1665303876%3Bs%3A9%3A%22user_data%22%3Bs%3A0%3A%22%22%3B%7D93dfaa97a1fb55b8be313aea7aaf932b2625cf90");
                request.AlwaysMultipartFormData = true;
                request.AddParameter("group_no", group_no);
                IRestResponse response = client.Execute(request);
                string res = response.Content;
                //Console.WriteLine(response.Content);

                //HtmlDocument doc = new HtmlDocument(;
                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(res);

                var ss = htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, 'joinbtn')]");

                if (ss != null)
                {
                    foreach (var item in ss.ToList())
                    {
                        try
                        {
                            string ttl = item.Attributes["title"].Value;
                            ttl = ttl.Replace("Click here to join ", "").Replace(" Whatsapp group", "");
                            var link = item.Attributes["href"].Value;
                            var waLink = link.Split('/')[link.Split('/').Length - 1];
                            string fullLink = "https://chat.whatsapp.com/invite/" + waLink;

                            dataGridView1.Invoke(new Action(() =>
                            {
                                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                                row.Cells[0].Value = ttl;
                                row.Cells[1].Value = fullLink;
                                dataGridView1.Rows.Add(row);
                            }));

                            cntr = cntr + 1;
                            materialButton5.Text = "Save: Members = " + cntr.ToString(); ;
                            button3.Text = "Export: Members = " + cntr.ToString();
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    group_no = group_no + 1;
                }
                else
                {
                    IsRunning = false;
                }


            }

            //{
            //    var title = item.SelectSingleNode("//span[contains(@style,'gtitle')]").ChildNodes[0].Attributes["alt"].Value;
            //    var link = item.SelectSingleNode("//a[contains(@class,'joinbtn')]").Attributes["href"].Value;
            //    var waLink = link.Split('/')[link.Split('/').Length-1];

            //    var ddd = item.SelectNodes("//span[contains(@style,'gtitle')]");

            //    string fullLink = "https://chat.whatsapp.com/invite/" + link;
            //}



            return 1;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) MessageBox.Show("Operation was canceled");
            else if (e.Error != null) MessageBox.Show(e.Error.Message);
            else MessageBox.Show(e.Result.ToString());
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            IsRunning = false;
            count = 0;
            stopProgressbar();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            List<string> links = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    links.Add(row.Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
            }

            GroupsJoiner groupsJoiner = new GroupsJoiner(this.waSenderForm,this.mainNavPage,links);
            this.Hide();
            groupsJoiner.ShowDialog();
            this.Refresh();
            //groupsJoiner.ImportLinks(links);


        }

        private void GroupFinder_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Inititate()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.Cells[1, 1].Value = Strings.GroupName;
            workSheet.Cells[1, 2].Value = Strings.Link;
            int recordIndex = 2;

            string fileData = File.ReadAllText(fileSaves + "\\" + "GroupLinks.json");

            List<GroupContact> contacts = new List<GroupContact>();

            if (!String.IsNullOrWhiteSpace(fileData))
                contacts = JsonConvert.DeserializeObject<List<GroupContact>>(fileData);

            GroupContact contacts1 = new GroupContact();
            contacts1.ContactNames = new List<string>();
            contacts1.GroupID = new List<string>();

            List<NVModel> links = new List<NVModel>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    links.Add(new NVModel
                    {
                        Name = row.Cells[0].Value.ToString(),
                        Value = row.Cells[1].Value.ToString()
                    });
                }
                catch (Exception ex)
                {

                }
            }

            foreach (var item in links)
            {
                workSheet.Cells[recordIndex, 1].Value = item.Name;
                workSheet.Cells[recordIndex, 2].Value = item.Value;
                contacts1.ContactNames.Add(item.Name);
                contacts1.GroupID.Add(item.Value);
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();

            String FolderPath = Config.GetTempFolderPath();
            String file = Path.Combine(FolderPath, materialTextBox21.Text + "_Group_Links" + Guid.NewGuid().ToString() + ".xlsx");
            string NewFileName = file.ToString();

            FileStream objFileStrm = File.Create(NewFileName);
            objFileStrm.Close();

            // Write content to excel file 
            File.WriteAllBytes(NewFileName, excel.GetAsByteArray());
            //Close Excel package
            excel.Dispose();
            // File.Copy(materialTextBox21.Text + "_Group_Links" +""+ ".xlsx", NewFileName);
            savesampleExceldialog.FileName = materialTextBox21.Text + "_Group_Links" + "" + ".xlsx";

            contacts1.Name = Path.GetFileNameWithoutExtension(savesampleExceldialog.FileName).Replace(".xlsx", "");
            contacts.Add(contacts1);
            importGroups = contacts1;
            string Json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            if(save)
                File.WriteAllText(fileSaves + "\\" + "GroupLinks.json", Json);

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
        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");

        private void materialButton4_Click(object sender, EventArgs e)
        {
            save = true;
            Inititate();
        }

        private void startProgressBar()
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;

        }
        private void stopProgressbar()
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.MarqueeAnimationSpeed = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBox21_Click(object sender, EventArgs e)
        {

        }

        private void materialCard2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            count += 1;
            int x = dataGridView1.Rows.Count;

            if (count > 10 && x==1)
            {
                count = 0;
                stopProgressbar();
                MessageBox.Show("No Results Were Found, Try Searching For Something Else!","Alert",MessageBoxButtons.OK,MessageBoxIcon.Information);
                timer1.Stop();
            }

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
            if (importGroups != null)
            {
                var count = ProjectCommon.getGroupLinks().Count - 1;
                mainNavPage.automaticMessagingNav1.init();
                mainNavPage.automaticMessagingNav1.mainNavPage = mainNavPage;
                mainNavPage.label8.ForeColor = Color.White;
                mainNavPage.panel4.SendToBack();
                mainNavPage.automaticMessagingNav1.Refresh();
                mainNavPage.automaticMessagingNav1.openGroups();
                mainNavPage.automaticMessagingNav1.chooseGroupContacts1.switchToLinks(false);
                mainNavPage.automaticMessagingNav1.chooseGroupContacts1.View(3, count.ToString(), false);
                mainNavPage.automaticMessagingNav1.chooseGroupContacts1.checkBox1.Checked = true;
                mainNavPage.automaticMessagingNav1.Visible = true;
                this.Close();
            }

        }
      /*  public void loadingScreen(bool appear)
        {
            if(appear)
            {
                this.Hide();
                mainNavPage.loading1.Visible = true;
                mainNavPage.loading1.BringToFront();
            }
            else
            {
                mainNavPage.loading1.Visible = false;
                mainNavPage.loading1.SendToBack();
            }
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            save = false;
            Inititate();
        }
    }


    class NVModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
