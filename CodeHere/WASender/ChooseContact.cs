using Microsoft.Win32;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Linq;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace WASender
{
    public partial class ChooseContact : UserControl
    {
        int selectedIndex=-1;
        int globalCond = 0;
        private FileInfo fiSingle = null;
        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),"fileSaves");
        public ChooseContact()
        {
            InitializeComponent();
            initializeResolution();

        }

        private void initializeResolution()
        {
            if(Program.resWidth==1280 && Program.resHeight == 1024)
            {
                this.panel2.Width -= 70;
            }
        }

        private int totalContacts(List<IndividualContacts> contacts)
        {
            int count = 0;

            foreach(IndividualContacts contact in contacts)
            {
                foreach (string number in contact.ContactNames)
                {
                    count++;
                }
            }
            return count;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

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

        public bool Directly { get; set; }=false;

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
      
        public void saveContactDetails(string name, string number)
        {
            if (globalCond == 0)
            {
                IndividualContacts contacts = new IndividualContacts();
                contacts.Name = name;
                contacts.ContactNames = new List<string>();
                contacts.Numbers = new List<string>();

                List<IndividualContacts> contactsList = getContactLists();
                contactsList.Insert(0,contacts);
                string Json = JsonConvert.SerializeObject(contactsList, Formatting.Indented);
                File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);
                View(0, "0",false);
            }
            else
            {
                List<IndividualContacts> contactsList = getContactLists();
                contactsList.Where(x => x.Name == contactsList[selectedIndex].Name).FirstOrDefault().ContactNames.Insert(0, name);
                contactsList.Where(x => x.Name == contactsList[selectedIndex].Name).FirstOrDefault().Numbers.Insert(0, number);
                string Json = JsonConvert.SerializeObject(contactsList, Formatting.Indented);
                File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);
                View(1, selectedIndex.ToString(),false);
            }
        }

        public void saveList(string name)
        {
            List<IndividualContacts> contactsList = getContactLists();

            IndividualContacts contacts = new IndividualContacts();
            contacts.Name = name;
            contacts.ContactNames= new List<string>();
            contacts.Numbers= new List<string>();
            contactsList.Add(contacts);

            string Json = JsonConvert.SerializeObject(contactsList, Formatting.Indented);
            File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);
            View(0, "0");
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

                if(globalCond==0)
                {
                    AddList s = new AddList(this);
                    s.ShowDialog();
                }
                else
                {
                    AddContact s = new AddContact(this);
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
            customProgressBar1.Size = new Size(this.panel2.Width / 2, this.customProgressBar1.Height);
            customProgressBar1.Location = new Point(this.panel2.Location.X+this.panel2.Width/2 - this.customProgressBar1.Width/2, this.panel2.Location.Y);
            customProgressBar1.BackColor = Color.White;
            customProgressBar1.Controls.Add(label);

            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.White;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            label.Location = new System.Drawing.Point(0, 0);
            label.Name = "labelcustom";
            label.Size = new System.Drawing.Size(409, 32);
            label.TabIndex = 2;
            label.Text = entry;
        }
            
        private List<IndividualContacts> getContactLists()
        {
            List<IndividualContacts> contacts = new List<IndividualContacts>();
            string fileData = File.ReadAllText(fileSaves + "\\" + "IndividualContacts.json");

            if (!checkIfEmpty(fileData))
                contacts = JsonConvert.DeserializeObject<List<IndividualContacts>>(fileData);

            return contacts;
        }

        private bool checkIfEmpty(string fileData)
        {
            bool state=false;
            if (String.IsNullOrWhiteSpace(fileData))
            {
                label2.Visible = true;
                label2.Location = new Point(this.label1.Location.X+30, this.borderPanel5.Location.Y+200);
                label2.BringToFront();
                state = true;
            }
            else
            {
                label2.Visible = false;
            }

            return state;
        }

        List<IndividualContacts> searchContacts;
        public void View(int cond, string index, bool viewProgressBar=true)
        {
            checkBox1.Checked = false;
            button4.Enabled = false;

            globalCond = cond;
            try
            {
                if (getContactLists().Count != 0)
                {
                    if(viewProgressBar==true)
                        viewCustomProgressBar(cond == 1 ? "Loading Saved Contacts" : "Loading Saved Lists");

                    int count = 0;
                    int location = 3;
                    panel2.Controls.Clear();

                    List<IndividualContacts> contacts;

                    if (cond == 1)
                    {
                        if (index == "-1")
                        {
                            contacts = searchContacts;
                            index= "0";
                        }
                        else
                        {
                            contacts = getContactLists();
                            textBox1.Text = "Search contact";
                            selectedIndex = Int32.Parse(index);
                            label1.Text = contacts[selectedIndex].Name.Replace(".xlsx","") ;
                            label1 = trimLabel(label1, 60);
                            int x = (gradientPanel1.Size.Width - label1.Size.Width) / 2;
                            label1.Location = new Point(x, label1.Location.Y);
                        }

                        customProgressBar1.Maximum = totalContacts(contacts);
                        customProgressBar1.SymbolAfter = "  Contacts";
                        IndividualContacts contact = contacts[Int32.Parse(index)];
                        for (int i = 0; i <contact.Numbers.Count; i++)
                        {

                            count += 1;
                            label8.Text = "Mobile Number";
                            createItem(location, contact, count, contact.Numbers[i], contact.ContactNames[i],cond);
                            customProgressBar1.Value += 1;
                            location += 128;
                        }
                    }
                    else
                    {
                        selectedIndex = -1;
                        label1.Text = "Contact List";
                        int x = (gradientPanel1.Size.Width - label1.Size.Width) / 2;
                        label1.Location = new Point(x, label1.Location.Y);

                        if (index == "-1")
                            contacts = searchContacts;
                        else
                        {
                            contacts = getContactLists();
                            textBox1.Text = "Search contact list";
                        }

                        button3.Text = "Add List";

                        foreach (IndividualContacts contact in contacts)
                        {
                            customProgressBar1.SymbolAfter = "  Lists";
                            label8.Text = "No. of Contacts";
                            customProgressBar1.Maximum = contacts.Count;
                            count += 1;
                            createItem(location, contact, count, contact.Numbers.Count.ToString(), contact.Name.Replace(".xlsx",""),cond);
                            customProgressBar1.Value += 1;
                            location += 128;
                        }
                    }
                    windowReAppear();
                }
            }
            catch
            {

            }
           
        }


        private void windowReAppear()
        {
            customProgressBar1.Value = 0;
            customProgressBar1.Visible = false;
            customProgressBar1.Controls.Clear();
            customProgressBar1.Location = new Point(400, 800);
            panel1.Visible = false;
            panel4.Refresh();
            panel4.Visible = true;
            panel1.Visible = true;

        }

        private void createItem(int location,IndividualContacts contact,int count,string entry1,string entry2,int cond)
        {
            CheckBox checkBox0 = new CheckBox();
            Button button0=new Button();
            Button button1=new Button();    
            Label label0 = new Label();
            Label label01 = new Label();
            Label label02 = new Label();

            BorderPanel borderPanel = new BorderPanel();
            this.panel2.Controls.Add(borderPanel);
            borderPanel.BackColor = System.Drawing.Color.White;
            borderPanel.BorderColor = System.Drawing.Color.WhiteSmoke;

            string checkboxNo="";
            var con = getContactLists();
            var conSingle = con.Where(x => x.Name == contact.Name).FirstOrDefault();


            if (cond==0)
            {
                label9.Visible = false;
                checkBox1.Visible = false;
                borderPanel.Controls.Add(button1);
                button1.Visible = true;
                borderPanel.Controls.Add(button0);
                checkboxNo = con.IndexOf(con.Where(x => x.Name == contact.Name).FirstOrDefault()).ToString();
            }
            else
            {
                borderPanel.Controls.Add(checkBox0);
                borderPanel.Controls.Add(button1);
                label9.Visible = true;
                checkBox1.Visible=true;
                button1.Visible = true;
                checkboxNo = con[selectedIndex].Numbers.IndexOf(contact.Numbers.Where(x => x == entry1).FirstOrDefault()).ToString();
            }

          
            borderPanel.Controls.Add(label0);
            borderPanel.Controls.Add(label01);
            borderPanel.Controls.Add(label02);
            borderPanel.Location = new System.Drawing.Point(0, location);
            borderPanel.Size = new System.Drawing.Size(panel2.Size.Width-20, 97);
            borderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

            label02.AutoSize = true;
            label02.BackColor = System.Drawing.Color.Transparent;
            label02.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label02.ForeColor = System.Drawing.Color.Gray;
            label02.Location = new System.Drawing.Point( (label4.Location.X-panel2.Location.X) + label4.Size.Width/3, 31);
            //label02.Location = new System.Drawing.Point(60, 31);
            label02.Name = "label26";
            label02.Size = new System.Drawing.Size(35, 28);
            label02.TabIndex = 10;
            label02.Text = "#" + (count).ToString();

            label01.AutoSize = true;
            label01.BackColor = System.Drawing.Color.Transparent;
            label01.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label01.ForeColor = System.Drawing.Color.Gray;
            label01.Location = new System.Drawing.Point(label02.Location.X + (label6.Location.X - label4.Location.X) - label4.Size.Width/3, 31);
            //label01.Location = new System.Drawing.Point(284, 31);
            label01.Name = "label10";
            label01.Size = new System.Drawing.Size(95, 28);
            label01.TabIndex = 44;
            label01.Text = String.IsNullOrWhiteSpace(entry2) ? "Empty" : entry2;
            label01 = trimLabel(label01, 17);

            label0.AutoSize = true;
            label0.BackColor = System.Drawing.Color.Transparent;
            label0.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label0.ForeColor = System.Drawing.Color.Gray;
            label0.Location = new System.Drawing.Point(label01.Location.X + (label8.Location.X - label6.Location.X) + (cond==0 ? label8.Size.Width/3 : 0) , 31);
            //label0.Location = new System.Drawing.Point(cond == 1 ? 585 : 639, 31);
            label0.Name = "label11";
            label0.Size = new System.Drawing.Size(196, 28);
            label0.TabIndex = 45;
            label0.Text = String.IsNullOrWhiteSpace(entry1) ? "Empty" : entry1;
            label0 = trimLabel(label0, 23);

            checkBox0.AutoSize = true;
            checkBox0.Location = new System.Drawing.Point(label0.Location.X + (label9.Location.X - label8.Location.X) + label9.Size.Width + (checkBox1.Location.X-(label9.Location.X+label9.Width)), 31);
            //checkBox0.Location = new System.Drawing.Point(988, 41);
            checkBox0.Size = new System.Drawing.Size(18, 17);
            checkBox0.TabIndex = 50;
            checkBox0.UseVisualStyleBackColor = true;
            checkBox0.Name = checkboxNo;
            checkBox0.CheckedChanged += CheckBox0_CheckedChanged;

            button1.BackColor = System.Drawing.Color.White;
            button1.Size = new System.Drawing.Size(124, 36);
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(146)))), ((int)(((byte)(122)))));
            button1.Location = new System.Drawing.Point((cond==1 ? borderPanel.Width - 40 - button1.Width : label0.Location.X) + (cond ==1 ? 0 : label3.Location.X - label8.Location.X), 31);
            //button1.Location = new System.Drawing.Point(cond==1? 1095:900, cond == 1 ? 31 : 36);
            button1.Name = checkBox0.Name;
            button1.TabIndex = 69;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;

            button0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button0.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button0.ForeColor = System.Drawing.Color.White;
            button0.Location = new System.Drawing.Point(borderPanel.Width- 20 - button0.Width, 31);
            //button0.Location = new System.Drawing.Point(1143, 30);
            button0.Name = cond == 1 ? (count - 1).ToString() : con.IndexOf(conSingle).ToString();
            button0.Size = new System.Drawing.Size(65, 47);
            button0.TabIndex = 73;
            button0.Click += Button0_Click;
            button0.Text = " ►";
            button0.UseVisualStyleBackColor = false;

        }

        int contactIndex = -1;
        int listIndex = -1;
        private void Button1_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int index = Int32.Parse(btn.Name);
            contactIndex = index;
            listIndex = index;

            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();


                AddContact addContact = new AddContact(this);
                AddList addList = new AddList(this);

                if(globalCond==1)
                {
                    addContact.EditContact(getContactLists()[selectedIndex].ContactNames[index], getContactLists()[selectedIndex].Numbers[index]);
                    addContact.ShowDialog();
                    this.Refresh();
                }
                else
                {
                    addList.EditList(getContactLists()[index].Name);
                    addList.ShowDialog();
                    this.Refresh();
                }
            }
        }


        public void EditContact(string name, string number)
        {
            List<IndividualContacts> contactsList = getContactLists();
            contactsList[selectedIndex].ContactNames[contactIndex]=name;
            contactsList[selectedIndex].Numbers[contactIndex] = number;

            string Json = JsonConvert.SerializeObject(contactsList, Formatting.Indented);
            File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);
            View(1, selectedIndex.ToString(), false);
        }

        public void EditList(string name)
        {
            List<IndividualContacts> contactsList = getContactLists();
            contactsList[listIndex].Name = name;

            string Json = JsonConvert.SerializeObject(contactsList, Formatting.Indented);
            File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);
            View(0,"0", false);
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

            if(checkedCount > 0)
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
                View(1, s.Name);
                button3.Text = "Add Contact";
            }

        public void goToLists(bool viewProgressBar=true)
        {
            panel4.Refresh();
            panel2.Controls.Clear();

            View(0, "0",viewProgressBar);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            goToLists();
        }

      /*  private void clearItems()
        {
            foreach (Control control in this.panel4.Controls)
            {
                if (control.GetType().Equals(typeof(BorderPanel))&& control.Name!="borderPanel5")
                {
                    BorderPanel borderPanel = control as BorderPanel;
                }
            }
        }*/




        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ChooseContact_Load(object sender, EventArgs e)
        {
            goToLists();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = Strings.SelectExcel;
            openFileDialog.DefaultExt = "xlsx";
            openFileDialog.Filter = "Excel Files|*.xlsx;";
            openFileDialog.Multiselect = false;

            IndividualContacts individualContacts = new IndividualContacts();
            individualContacts.Numbers = new List<string>();
            individualContacts.ContactNames = new List<string>();

            if(globalCond>0)
            {
                individualContacts = getContactLists()[selectedIndex];
            }

            customProgressBar1.SymbolAfter = "  Contacts";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                fiSingle = new FileInfo(file);
                if (fiSingle.Extension != ".xlsx")
                {
                    Utils.showAlert(Strings.PleaseselectExcelfilesformatonly, Alerts.Alert.enmType.Error);
                    return;
                }

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                viewCustomProgressBar("Saving Contacts");
                using (var package = new ExcelPackage(fiSingle))
                {
                    try
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                        var ColumnsCOunt = worksheet.Dimension.Columns;
                        if (ColumnsCOunt > 2)
                        {
                            for (int i = 3; i <= ColumnsCOunt; i++)
                            {
                                try
                                {
                                    string Header = worksheet.Cells[1, i].Value.ToString();
                                }
                                catch (Exception ex)
                                {
                                    string exs = "";
                                }
                            }
                        }

                        customProgressBar1.Maximum = worksheet.Dimension.Rows - 1;
                        for (int i = 1; i < worksheet.Dimension.Rows; i++)
                        {

                            try
                            {
                                string MobileNumber = worksheet.Cells[i + 1, 1].Value.ToString();
                                try
                                {
                                    MobileNumber = MobileNumber.Replace("+", "");
                                    MobileNumber = MobileNumber.Replace(" ", "");
                                    MobileNumber = MobileNumber.Replace(" ", "");
                                    Int64 temp = Convert.ToInt64(MobileNumber);
                                }
                                catch (Exception ex)
                                {

                                }


                                string name = "";
                                try
                                {
                                    name = worksheet.Cells[i + 1, 2].Value.ToString();
                                }
                                catch (Exception ex)
                                {

                                }


                                individualContacts.Numbers.Add(MobileNumber);
                                individualContacts.ContactNames.Add(name);
                                customProgressBar1.Value += 1;
                                try
                                {
                                    if (ColumnsCOunt > 1)
                                    {
                                        for (int j = 2; j <= ColumnsCOunt; j++)
                                        {
                                            try
                                            {
                                                string CelValue = worksheet.Cells[i + 1, j].Value.ToString();
                                            }
                                            catch (Exception ex)
                                            {

                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                string ss = "";
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Utils.showAlert(ex.Message, Alerts.Alert.enmType.Error);
                    }
                }
            }

            windowReAppear();

            List<IndividualContacts> contacts = getContactLists();
            string Json;
            individualContacts.Name = openFileDialog.SafeFileName;

            if (contacts == null)
            {
                contacts = new List<IndividualContacts>();
            }
            if (individualContacts.Name != "")
            {
                if (globalCond > 0)
                {
                    individualContacts.Name = contacts[selectedIndex].Name;
                    contacts[selectedIndex] = individualContacts;
                }
                else
                    contacts.Add(individualContacts);

                Json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
                File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);
            }

            if (globalCond > 0)
                View(globalCond, selectedIndex.ToString());
            else
                View(0, "0");
        }

        private void customProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in this.panel2.Controls)
                {
                    foreach(Control b in c.Controls)
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
            if (textBox1.Text == "Search contact list" || textBox1.Text == "Search contact")
                textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button4.Enabled = false;
                checkBox1.Checked = false;
                if (selectedIndex == -1)
                {
                    if(textBox1.Text!="")
                    {
                        searchContacts = getContactLists().Where(x => x.Name.Replace(".xlsx", "").ToLower().StartsWith(textBox1.Text.ToLower())).ToList();
                        View(0, "-1");
                    }
                    else
                    {
                        View(0, "0");
                    }
                }
                else if (selectedIndex >= 0)
                {
                    if (textBox1.Text != "")    
                    {
                        IndividualContacts contact = new IndividualContacts();
                        contact.ContactNames = new List<string>();
                        contact.Numbers = new List<string>();

                        for (int i = 0; i < getContactLists()[selectedIndex].ContactNames.Count; i++)
                        {
                            try
                            {
                                if (getContactLists()[selectedIndex].ContactNames[i].ToLower().StartsWith(textBox1.Text.ToLower()))
                                {
                                    contact.Name = "Searhed";
                                    contact.ContactNames.Add(getContactLists()[selectedIndex].ContactNames[i]);
                                    contact.Numbers.Add(getContactLists()[selectedIndex].Numbers[i]);
                                }
                            }
                            catch
                            {

                            }
                            
                        }

                        searchContacts = null;
                        searchContacts = new List<IndividualContacts>();
                        searchContacts.Add(contact);
                        View(1, "-1");
                    }
                    else
                    {
                        View(1, selectedIndex.ToString());
                    }
                }
            }
        }

        private Label trimLabel(Label label, int length)
        {
            if (label.Text.Length > length)
            {
                label.Text = label.Text.Substring(0, length) + "...";
            }
            return label;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IndividualContacts newContact = new IndividualContacts();
            var contacts = getContactLists();
            newContact.ContactNames = new List<string>();
            newContact.Numbers = new List<string>();

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
                            newContact.Numbers.Add(contacts[selectedIndex].Numbers[Int32.Parse(cb.Name)]);
                        }
                    }
                }
            }

            WaSenderForm wASenderForm = new WaSenderForm(this.main);
            wASenderForm.startCampaign(newContact);
            wASenderForm.Show();

        }

        public void Delete()
        {
            List<IndividualContacts> contactsList = getContactLists();
            contactsList[selectedIndex].ContactNames.RemoveAt(contactIndex);
            contactsList[selectedIndex].Numbers.RemoveAt(contactIndex);

            string Json = JsonConvert.SerializeObject(contactsList, Formatting.Indented);
            File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);
            View(1, selectedIndex.ToString(), false);
        }

        public void deleteList()
        {
            List<IndividualContacts> contactsList = getContactLists();
            contactsList.RemoveAt(listIndex);
            string Json = JsonConvert.SerializeObject(contactsList, Formatting.Indented);
            File.WriteAllText(fileSaves + "\\" + "IndividualContacts.json", Json);
            goToLists(false);
        }
    }
}
