using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WASender
{
    public partial class ChooseGroupContacts : UserControl
    {
        int selectedIndex = -1;
        public int globalCond = 0;  
        private FileInfo fiGroup;
        public ChooseGroupContacts()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            fiGroup = null;
            View(0, "0");
        }

        private int totalContacts(List<GroupContact> contacts)
        {
            int count = 0;

            foreach (GroupContact contact in contacts)
            {
                foreach (string number in contact.ContactNames)
                {
                    count++;
                }
            }
            return count;
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

        public bool Directly { get; set; } = false;

        public MainNavPage main { get; set; }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Directly)
            {
                main.automaticMessagingNav1.Hide();
                main.backToHomeScreen();
                Directly = false;
            }

        }

        private bool checkIfEmpty(string fileData)
        {
            bool state = false;
            if (String.IsNullOrWhiteSpace(fileData))
            {
                label2.Visible = true;
                label2.Location = new Point(this.label1.Location.X, this.borderPanel5.Location.Y + 200);
                label2.BringToFront();
                state = true;
            }
            else
            {
                label2.Visible = false;
            }

            return state;
        }

        private List<GroupContact> getContactLists()
        {
            List<GroupContact> contacts = new List<GroupContact>();
            string fileData = File.ReadAllText(fileSaves + "\\" + "Groups.json");
            label2.Text = "No Lists Added Yet !";
            if(!checkIfEmpty(fileData))
                contacts = JsonConvert.DeserializeObject<List<GroupContact>>(fileData);

            return contacts;
        }

        private List<GroupContact> getContactLinks()
        {
            List<GroupContact> contacts = new List<GroupContact>();
            string fileData = File.ReadAllText(fileSaves + "\\" + "GroupLinks.json");
            label2.Text = "No Links Added Yet !";
            if (!checkIfEmpty(fileData))
                contacts = JsonConvert.DeserializeObject<List<GroupContact>>(fileData);

            return contacts;
        }


        public void saveContactDetails(string name, string id)
        {
            List<GroupContact> groupContacts;
            string listName;
            string save;
           
            if (globalCond>1)
            {
                groupContacts = getContactLinks();
                save = fileSaves + "\\" + "GroupLinks.json";
            }
            else
            {
                groupContacts = getContactLists();
                save = fileSaves + "\\" + "Groups.json";
            }

            listName = name;

            if (globalCond==0 || globalCond==2)
            {
                GroupContact contacts = new GroupContact();
                contacts.Name = listName;
                contacts.ContactNames = new List<string>();
                contacts.GroupID = new List<string>();

                if (groupContacts == null)
                {
                    groupContacts = new List<GroupContact>();
                }

                groupContacts.Insert(0,contacts);
                string Json = JsonConvert.SerializeObject(groupContacts, Formatting.Indented);
                File.WriteAllText(save, Json);
                View(globalCond, "0",false);

            }
            else
            {
                groupContacts.Where(x => x.Name == groupContacts[selectedIndex].Name).FirstOrDefault().ContactNames.Insert(0, name);
                groupContacts.Where(x => x.Name == groupContacts[selectedIndex].Name).FirstOrDefault().GroupID.Insert(0, id);
                string Json = JsonConvert.SerializeObject(groupContacts, Formatting.Indented);
                File.WriteAllText(save, Json);
                View(globalCond, selectedIndex.ToString(), false);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                if (globalCond == 0 || globalCond == 2)
                {
                    AddList s = new AddList(this);
                    s.ShowDialog();
                }
                else
                {
                    AddGroup s = new AddGroup(this);
                    s.ShowDialog();
                }
                this.Refresh();
            }
        }

        private void viewCustomProgressBar(string entry)
        {
            panel4.Visible = false;
            customProgressBar1.Visible = true;
            Label label = new Label();
            customProgressBar1.Location = new Point(this.button2.Location.X + this.button2.Width, this.panel2.Location.Y);
            customProgressBar1.Size=new Size(this.button3.Location.X-(this.button2.Location.X+this.button2.Width), this.customProgressBar1.Height);
            customProgressBar1.BackColor = Color.White;
            customProgressBar1.Controls.Add(label);
            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.White;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            label.Location = new System.Drawing.Point(0, 0);
            label.Name = "label2";
            label.Size = new System.Drawing.Size(409, 32);
            label.TabIndex = 2;
            label.Text = entry;
        }

        private void windowReAppear()
        {
            customProgressBar1.Visible = false;
            customProgressBar1.Value = 0;
            customProgressBar1.Controls.Clear();
            customProgressBar1.Location = new Point(400, 800);
            panel1.Visible = false;
            panel4.Refresh();
            panel4.Visible = true;
            panel1.Visible = true;
        }

        private Label trimLabel(Label label,int length)
        {
            if(label.Text.Length>length)
            {
                label.Text=label.Text.Substring(0, length) + "...";
            }
            return label;
        }
        private void createItem(int location, GroupContact contact, int count, string entry1, string entry2, int cond)
        {
            CheckBox checkBox0 = new CheckBox();
            Button button0 = new Button();
            Button button1 = new Button();
            Label label0 = new Label();
            Label label01 = new Label();
            Label label02 = new Label();

            BorderPanel borderPanel = new BorderPanel();
            this.panel2.Controls.Add(borderPanel);
            borderPanel.BackColor = System.Drawing.Color.White;
            borderPanel.BorderColor = System.Drawing.Color.WhiteSmoke;

            string checkboxNo = "";
            var con = cond <= 1 ? getContactLists() : getContactLinks();
            var conSingle = con.Where(x => x.Name == contact.Name).FirstOrDefault();

            if (cond == 0 || cond==2)
            {
                label9.Visible = false;
                checkBox1.Visible = false;
                button1.Visible = false;
                borderPanel.Controls.Add(button1);
                button1.Visible = true;
                borderPanel.Controls.Add(button0);
                checkboxNo = con.IndexOf(con.Where(x => x.Name == contact.Name).FirstOrDefault()).ToString();
            }
            else
            {
                borderPanel.Controls.Add(checkBox0);
                label9.Visible = true;
                borderPanel.Controls.Add(button1);
                button1.Visible = true;
                checkBox1.Visible = true;
                checkboxNo = con[selectedIndex].GroupID.IndexOf(contact.GroupID.Where(x => x == entry1).FirstOrDefault()).ToString();
            }

            borderPanel.Controls.Add(label0);
            borderPanel.Controls.Add(label01);
            borderPanel.Controls.Add(label02);
            borderPanel.Location = new System.Drawing.Point(55, location);
            borderPanel.Size = new System.Drawing.Size(1260, 97);

            checkBox0.AutoSize = true;
            checkBox0.Location = new System.Drawing.Point(913, 41);
            checkBox0.Name = "checkBox2";
            checkBox0.Size = new System.Drawing.Size(18, 17);
            checkBox0.TabIndex = 50;
            checkBox0.UseVisualStyleBackColor = true;
            checkBox0.Name = checkboxNo;
            checkBox0.CheckedChanged += CheckBox0_CheckedChanged; ;
            

            button0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button0.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button0.ForeColor = System.Drawing.Color.White;
            button0.Location = new System.Drawing.Point(1143, 30);
            

            button0.Name = cond == 1 || cond==3 ? (count - 1).ToString() : con.IndexOf(conSingle).ToString();
            button0.Size = new System.Drawing.Size(65, 47);
            button0.TabIndex = 73;
            button0.Click += Button0_Click;
            button0.Text = " ►";
            button0.UseVisualStyleBackColor = false;

            label0.AutoSize = true;
            label0.BackColor = System.Drawing.Color.Transparent;
            label0.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label0.ForeColor = System.Drawing.Color.Gray;
            label0.Location = new System.Drawing.Point(cond == 1 ? 533 : 587, 31);
            label0.Name = "label11";
            label0.Size = new System.Drawing.Size(196, 28);
            label0.TabIndex = 45;
            label0.Text = String.IsNullOrWhiteSpace(entry1) ? "Empty" : entry1;
            label0=trimLabel(label0,23);

            label01.AutoSize = true;
            label01.BackColor = System.Drawing.Color.Transparent;
            label01.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label01.ForeColor = System.Drawing.Color.Gray;
            label01.Location = new System.Drawing.Point(232, 31);
            label01.Name = "label10";
            label01.Size = new System.Drawing.Size(95, 28);
            label01.TabIndex = 44;
            label01.Text = String.IsNullOrWhiteSpace(entry2) ? "Empty" : entry2;
            label01 = trimLabel(label01,17);

            label02.AutoSize = true;
            label02.BackColor = System.Drawing.Color.Transparent;
            label02.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label02.ForeColor = System.Drawing.Color.Gray;
            label02.Location = new System.Drawing.Point(45, 31);
            label02.Name = "label26";
            label02.Size = new System.Drawing.Size(35, 28);
            label02.TabIndex = 10;
            label02.Text = "#" + (count).ToString();

            button1.BackColor = System.Drawing.Color.White;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(146)))), ((int)(((byte)(122)))));
            button1.Location = new System.Drawing.Point(cond == 1 || cond == 3 ? 1095 : 900, cond == 1 || cond == 3 ? 31 : 36);
            button1.Name = checkBox0.Name;
            button1.Size = new System.Drawing.Size(124, 36);
            button1.TabIndex = 69;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click; ;

        }

        int groupIndex = -1;
        int listIndex = -1;

        private void Button1_Click(object sender, EventArgs e)
        {
            var contacts = globalCond > 1 ? getContactLinks() : getContactLists();
            var btn = (Button)sender;
            int index = Int32.Parse(btn.Name);
            groupIndex = index;
            listIndex = index;

            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();


                AddGroup addGroup = new AddGroup(this);
                AddList addList = new AddList(this);

                if (globalCond == 1 || globalCond == 3)
                {
                    addGroup.EditGroup(contacts[selectedIndex].ContactNames[index], contacts[selectedIndex].GroupID[index]);
                    addGroup.ShowDialog();
                }
                else
                {
                    addList.EditList(contacts[index].Name);
                    addList.ShowDialog();
                }
                this.Refresh();
            }


        }


        public void EditGroup(string name, string desc)
        {
            List<GroupContact> contactsList = globalCond<=1? getContactLists():getContactLinks();
            string save = globalCond <= 1 ? fileSaves + "\\" + "Groups.json" : fileSaves + "\\" + "GroupLinks.json";
            contactsList[selectedIndex].ContactNames[groupIndex] = name;
            contactsList[selectedIndex].GroupID[groupIndex] = desc;

            string Json = JsonConvert.SerializeObject(contactsList, Formatting.Indented);
            File.WriteAllText(save, Json);
            View(globalCond, selectedIndex.ToString(), false);
        }

        public void EditList(string name)
        {
            List<GroupContact> contactsList = globalCond <= 1 ? getContactLists() : getContactLinks();
            contactsList[listIndex].Name = name;

            string save = globalCond <= 1 ? fileSaves + "\\" + "Groups.json" : fileSaves + "\\" + "GroupLinks.json";
            string Json = JsonConvert.SerializeObject(contactsList, Formatting.Indented);
            File.WriteAllText(save, Json);
            View(globalCond, "0",false);
        }

        private void CheckBox0_CheckedChanged(object sender, EventArgs e)
        {
            int checkedCount = 0;

            foreach (Control c in this.panel2.Controls)
            {
                foreach (Control b in c.Controls)
                {
                    if (b.GetType().Equals(typeof(CheckBox)))
                    {
                        CheckBox cb = b as CheckBox;
                        if (cb.Checked)
                            checkedCount += 1;
                    }
                }
            }

            if (checkedCount > 0)
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            var s = (Button)sender;
            checkBox1.Checked = false;
            if (globalCond > 1)
                View(3, s.Name);
            else
                View(1, s.Name);
        }

        public void switchToGroups(bool viewProgressBar = true)
        {
            panel2.Controls.Clear();
            button2.Text = "View All Links";
            label8.Text = "No. of Groups";
            View(0, "0",viewProgressBar);
            button4.Text = "Start Campaign";
            textBox1.Text = "Search group list";
            label1.Text = "Group List";
        }

        public void switchToLinks(bool viewProgressBar=true)
        {
            panel2.Controls.Clear();
            button2.Text = "View All Lists";
            View(2, "0", viewProgressBar);
            button4.Text = "Join Groups";
            label8.Text = "No. of Links";
            textBox1.Text = "Search group links";
            label1.Text = "Group Links";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "View All Lists")
            {
                switchToGroups();
            }
            else
            {
                switchToLinks();
            }

            panel4.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = Strings.SelectExcel;
            openFileDialog.DefaultExt = "xlsx";
            openFileDialog.Filter = "Excel Files|*.xlsx;";
            openFileDialog.Multiselect = false;

            GroupContact groupContacts = new GroupContact();
            groupContacts.ContactNames = new List<string>();
            groupContacts.GroupID = new List<string>();

            if (globalCond == 1)
            {
                groupContacts = getContactLists()[selectedIndex];
            }
            else if(globalCond == 3)
            {
                groupContacts = getContactLinks()[selectedIndex];
            }

            customProgressBar1.SymbolAfter = "  Groups";

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.SafeFileName != null)
            {
                string file = openFileDialog.FileName;
                fiGroup = new FileInfo(file);
                if ((fiGroup.Extension != ".xlsx"))
                {
                    Utils.showAlert(Strings.PleaseselectExcelfilesformatonly, Alerts.Alert.enmType.Error);
                    return;
                }

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                viewCustomProgressBar("Saving Groups");

                using (var package = new ExcelPackage(fiGroup))
                {
                    try
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                        customProgressBar1.Maximum = worksheet.Dimension.Rows - 1;

                        for (int i = 1; i < worksheet.Dimension.Rows; i++)
                        {
                            groupContacts.ContactNames.Add(worksheet.Cells[i + 1, 1].Value.ToString());
                            groupContacts.GroupID.Add(worksheet.Cells[i + 1, 2].Value.ToString());
                            customProgressBar1.Value += 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        Utils.showAlert(ex.Message, Alerts.Alert.enmType.Error);
                    }
                }

                windowReAppear();

                string filedata = File.ReadAllText(fileSaves + "\\" + "Groups.json");

                if(globalCond>1)
                    filedata = File.ReadAllText(fileSaves + "\\" + "GroupLinks.json");

                List<GroupContact> contacts = new List<GroupContact>();

                if (!String.IsNullOrWhiteSpace(filedata))
                    contacts = JsonConvert.DeserializeObject<List<GroupContact>>(filedata);

                string Json;
                groupContacts.Name = openFileDialog.SafeFileName;

                if (contacts == null)
                {
                    contacts = new List<GroupContact>();
                }

                if (groupContacts.Name != "")
                {
                    if (globalCond == 1 || globalCond == 3)
                    {
                        groupContacts.Name = contacts[selectedIndex].Name;
                        contacts[selectedIndex] = groupContacts;
                    }
                    else
                        contacts.Add(groupContacts);

                    Json = JsonConvert.SerializeObject(contacts, Formatting.Indented);

                    if (globalCond > 1)
                        File.WriteAllText(fileSaves + "\\" + "GroupLinks.json", Json);
                    else
                        File.WriteAllText(fileSaves + "\\" + "Groups.json", Json);
                }

                if (globalCond == 1 || globalCond == 3)
                {
                    View(globalCond, selectedIndex.ToString());
                }
                else
                    View(globalCond, "0");
            }
        }

        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in this.panel2.Controls)
            {
                foreach (Control b in c.Controls)
                {
                    if (b.GetType().Equals(typeof(CheckBox)))
                    {
                        CheckBox cb = b as CheckBox;
                        if (checkBox1.Checked)
                            cb.Checked = true;
                        else
                            cb.Checked = false;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Search group list" || textBox1.Text == "Search group" || textBox1.Text == "Search group links" || textBox1.Text == "Search link")
                textBox1.Text = "";
        }

        List<GroupContact> searchContacts;


        public void View(int cond, string index,bool viewProgressBar=true)
        {
            panel4.Refresh();
            panel2.Controls.Clear();
            globalCond = cond;
            checkBox1.Checked = false;
            button4.Enabled = false;

            List<GroupContact> groupContacts;

            if (cond > 1)
                groupContacts = getContactLinks();

            else
                groupContacts = getContactLists();

            if (cond == 0)
                button3.Text = "Add Group List";
            else if(cond== 1)
                button3.Text = "Add Group";
            else if (cond == 2)
                button3.Text = "Add Links List";
            else if (cond == 3)
                button3.Text = "Add Group Link";

            try
            {

                if (groupContacts.Count != 0)
                {
                    this.panel2.Controls.Clear();

                    if(viewProgressBar==true)
                        viewCustomProgressBar(cond == 1 ? "Loading Saved Groups" : cond==0? "Loading Saved Lists": cond==2? "Loading Saved Group Links": "Loading Saved Links");

                    int count = 0;
                    int location = 3;
                    panel2.Controls.Clear();

                    List<GroupContact> contacts;

                    if (cond <= 1)
                    {
                        panel2.Controls.Clear();
                        button4.Text = "Start Campaign";
                        if (cond == 1)
                        {
                            button2.Text = "View All Lists";
                            if (index == "-1")
                            {
                                contacts = searchContacts;
                                index = "0";
                            }
                            else
                            {
                                contacts = getContactLists();
                                textBox1.Text = "Search group";
                                selectedIndex = Int32.Parse(index);
                                label1.Text = contacts[selectedIndex].Name.Replace(".xlsx", "");
                                label1 = trimLabel(label1, 60);
                                int x = (gradientPanel1.Size.Width - label1.Size.Width) / 2;
                                label1.Location = new Point(x, label1.Location.Y);
                            }

                            customProgressBar1.Maximum = totalContacts(contacts);
                            customProgressBar1.SymbolAfter = "  Groups";
                            GroupContact contact = contacts[Int32.Parse(index)];
                            for (int i = 0; i < contact.GroupID.Count; i++)
                            {

                                count += 1;
                                label8.Text = "Group ID";
                                createItem(location, contact, count, contact.GroupID[i], contact.ContactNames[i], cond);
                                customProgressBar1.Value += 1;
                                location += 128;
                            }
                        }
                        else
                        {
                            button2.Text = "View All Links";
                            selectedIndex = -1;
                            label1.Text = "Group List";
                            int x = (gradientPanel1.Size.Width - label1.Size.Width) / 2;
                            label1.Location = new Point(x, label1.Location.Y);

                            if (index == "-1")
                                contacts = searchContacts;
                            else
                            {
                                contacts = getContactLists();
                                textBox1.Text = "Search group list";
                            }

                            foreach (GroupContact contact in contacts)
                            {
                                customProgressBar1.SymbolAfter = "  Lists";
                                label8.Text = "No. of Groups";
                                customProgressBar1.Maximum = contacts.Count;
                                count += 1;
                                createItem(location, contact, count, contact.GroupID.Count.ToString(), contact.Name.Replace(".xlsx", ""), cond);
                                customProgressBar1.Value += 1;
                                location += 128;
                            }
                        }
                    }
                    else
                    {                    
                        if (cond == 2)
                        {
                            selectedIndex = -1;
                            label1.Text = "Group Links";
                            int x = (gradientPanel1.Size.Width - label1.Size.Width) / 2;
                            label1.Location = new Point(x, label1.Location.Y);

                            if (index == "-1")
                                contacts = searchContacts;
                            else
                            {
                                contacts = getContactLinks();
                                textBox1.Text = "Search group links";
                            }

                            foreach (GroupContact contact in contacts)
                            {
                                customProgressBar1.SymbolAfter = "  Links";
                                label8.Text = "No. of Links";
                                customProgressBar1.Maximum = contacts.Count;
                                count += 1;
                                createItem(location, contact, count, contact.GroupID.Count.ToString(), contact.Name.Replace(".xlsx", ""), cond);
                                customProgressBar1.Value += 1;
                                location += 128;
                            }
                        }
                        else
                        {
                            button2.Text = "View All Links";
                            if (index == "-1")
                            {
                                contacts = searchContacts;
                                index = "0";
                            }
                            else
                            {
                                contacts = getContactLinks();
                                textBox1.Text = "Search link";
                                selectedIndex = Int32.Parse(index);
                                label1.Text = contacts[selectedIndex].Name.Replace(".xlsx", "");
                                label1 = trimLabel(label1, 60);
                                int x = (gradientPanel1.Size.Width - label1.Size.Width) / 2;
                                label1.Location = new Point(x, label1.Location.Y);
                            }

                            customProgressBar1.Maximum = contacts[Int32.Parse(index)].ContactNames.Count;
                            customProgressBar1.SymbolAfter = "  Links";
                            GroupContact contact = contacts[Int32.Parse(index)];
                            for (int i = 0; i < contact.GroupID.Count; i++)
                            {
                                count += 1;
                                label8.Text = "Group Links";
                                createItem(location, contact, count, contact.GroupID[i], contact.ContactNames[i], cond);
                                customProgressBar1.Value += 1;
                                location += 128;
                            }
                        }
                    }
                    windowReAppear();
                }
            }
            catch
            {

            }

        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            List<GroupContact> groupContacts;
          

            if (globalCond > 1)
                groupContacts = getContactLinks();    
   
            else
                groupContacts = getContactLists();               


            if (e.KeyCode == Keys.Enter)
            {
                button4.Enabled = false;
                checkBox1.Checked = false;
                if (selectedIndex == -1)
                {
                    if (textBox1.Text != "")
                    {
                        searchContacts = groupContacts.Where(x => x.Name.Replace(".xlsx", "").ToLower().StartsWith(textBox1.Text.ToLower())).ToList();
                        View(globalCond, "-1");
                    }
                    else
                    {
                        View(globalCond, "0");
                    }
                }
                else if (selectedIndex >= 0)
                {
                    if (textBox1.Text != "")
                    {
                        GroupContact contact = new GroupContact();
                        contact.ContactNames = new List<string>();
                        contact.GroupID = new List<string>();

                        for (int i = 0; i < groupContacts[selectedIndex].ContactNames.Count; i++)
                        {
                            if (groupContacts[selectedIndex].ContactNames[i].ToLower().StartsWith(textBox1.Text.ToLower()))
                            {
                                contact.Name = "Searhed";
                                contact.ContactNames.Add(groupContacts[selectedIndex].ContactNames[i]);
                                contact.GroupID.Add(groupContacts[selectedIndex].GroupID[i]);
                            }
                        }

                        searchContacts = null;
                        searchContacts = new List<GroupContact>();
                        searchContacts.Add(contact);
                        View(globalCond, "-1");
                    }
                    else
                    {
                        View(globalCond, selectedIndex.ToString());
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GroupContact newContact = new GroupContact();

            var contacts = button4.Text=="Start Campaign"? getContactLists():getContactLinks();
            newContact.ContactNames = new List<string>();
            newContact.GroupID = new List<string>();

            foreach (Control c in this.panel2.Controls)
            {
                foreach (Control b in c.Controls)
                {
                    if (b.GetType().Equals(typeof(CheckBox)))
                    {
                        CheckBox cb = b as CheckBox;
                        if (cb.Checked)
                        {
                            newContact.ContactNames.Add(contacts[selectedIndex].ContactNames[Int32.Parse(cb.Name)]);
                            newContact.GroupID.Add(contacts[selectedIndex].GroupID[Int32.Parse(cb.Name)]);
                        }
                    }
                }
            }

            if(button4.Text== "Start Campaign")
            {
                WaSenderForm wASenderForm = new WaSenderForm();
                wASenderForm.startCampaign(newContact);
                wASenderForm.Show();
            }
            else
            {
                using (Panel p = new Panel())
                {
                    p.Location = new Point(0, 0);
                    p.Size = this.ClientRectangle.Size;
                    p.BackgroundImage = FormFade();
                    this.Controls.Add(p);
                    p.BringToFront();

                    WaSenderForm senderForm = new WaSenderForm();
                    GroupsJoiner groupsJoiner = new GroupsJoiner(senderForm);
                    groupsJoiner.LoadFile(newContact);
                    groupsJoiner.ShowDialog();
                    this.Refresh();
                }
            }
          
            
        }

        public void Delete()
        {
            List<GroupContact> contactsList = globalCond <= 1 ? getContactLists() : getContactLinks();
            string save = globalCond <= 1 ? fileSaves + "\\" + "Groups.json" : fileSaves + "\\" + "GroupLinks.json";
            contactsList[selectedIndex].ContactNames.RemoveAt(groupIndex);
            contactsList[selectedIndex].GroupID.RemoveAt(groupIndex);

            string Json = JsonConvert.SerializeObject(contactsList, Formatting.Indented);
            File.WriteAllText(save, Json);
            View(globalCond, selectedIndex.ToString(), false);
        }

        public void deleteList()
        {
            List<GroupContact> contactsList = globalCond <= 1 ? getContactLists() : getContactLinks();
            string save = globalCond <= 1 ? fileSaves + "\\" + "Groups.json" : fileSaves + "\\" + "GroupLinks.json";
            contactsList.RemoveAt(listIndex);

            string Json = JsonConvert.SerializeObject(contactsList, Formatting.Indented);
            File.WriteAllText(save, Json);
            View(globalCond, "0", false);
        }
    }
}
