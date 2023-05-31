using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using AutoUpdaterDotNET;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaAutoReplyBot;
using Keys = OpenQA.Selenium.Keys;
using System.IO;
using System.Web.UI.WebControls;
using Panel = System.Windows.Forms.Panel;

namespace WASender
{
    public partial class MainNavPage : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private Size sizeNormal;

        WaSenderForm senderForm;


        public MainNavPage()
        {
            InitializeComponent();
            NativeWinAPI.appear(this);
            senderForm = new WaSenderForm(this);

            this.sizeNormal = this.flowLayoutPanel1.Size;
            this.StartPosition = FormStartPosition.CenterScreen;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            this.Text = "WhatsBiz " + version;
            versionLabel.Text = "Version : " + version;

            if (!Config.IsProductActive())
            {
                Activate activate = new Activate(this);
                this.Hide();
                activate.ShowDialog();
                this.Refresh();
            }

            automaticMessaging();
            this.automaticMessagingNav1.openContacts();
            backToHomeScreen();

            automaticMessaging();
            this.automaticMessagingNav1.openGroups();
            backToHomeScreen();

            automaticMessaging();
            this.automaticMessagingNav1.openGroups();
            this.automaticMessagingNav1.chooseGroupContacts1.switchToLinks();
            backToHomeScreen();

            goToManageGroups();
            goToManageContacts();
            this.automaticMessagingNav1.chooseContact1.Directly = false;
            this.automaticMessagingNav1.chooseGroupContacts1.Directly = false;
            backToHomeScreen();
            initializeResolution();
        }

       
        private void initializeResolution()
        {
            if (Program.resWidth== 1280 || Program.resWidth == 1600)
            {
                foreach (Control control in this.flowLayoutPanel1.Controls)
                    control.Margin = new Padding(control.Margin.Left, control.Margin.Top, 15, control.Margin.Bottom);
            }
            else if (Program.resWidth == 1680 && Program.resHeight == 1050)
            {
                this.flowLayoutPanel1.Width+= 200;

                foreach (Control control in this.flowLayoutPanel1.Controls)
                    control.Margin = new Padding(control.Margin.Left, control.Margin.Top, 15, control.Margin.Bottom);
            }
            else if (Program.resWidth == 800)
            {
                foreach (Control control in this.panel1.Controls)
                {
                    control.Font = new Font(control.Font.FontFamily, 7, control.Font.Style);
                    if (control.Name == "pictureBox12" || control.Name == "label8" || control.Name == "label14" || control.Name == "versionLabel")
                        control.Left -= 10;
                }

                this.panel1.Controls[1].Left += 12;
                this.panel1.Controls[2].Left += 15;
                this.panel1.Controls[3].Left += 40;
                this.panel1.Controls[4].Left += 50;
                this.panel1.Controls[5].Left += 68;
                this.panel1.Controls[6].Left += 70;
                this.panel1.Controls[7].Left += 85;
                this.panel1.Controls[8].Left += 90;

            }
        }

        int originalExStyle = -1;
        bool enableFormLevelDoubleBuffering = true;

      /*  protected override CreateParams CreateParams
        {
            get
            {
                if (originalExStyle == -1)
                    originalExStyle = base.CreateParams.ExStyle;

                CreateParams cp = base.CreateParams;
                if (enableFormLevelDoubleBuffering)
                    cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                else
                    cp.ExStyle = originalExStyle;

                return cp;
            }
        }

        private void TurnOffFormLevelDoubleBuffering()
        {
            enableFormLevelDoubleBuffering = false;
            this.MaximizeBox = true;
        }
*/

        public void frmChild()
        {
            ResizeRedraw = true;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        }


        private void goToManageContacts()
        {
            automaticMessaging(false);
            this.automaticMessagingNav1.chooseContact1.Directly = true;
            this.automaticMessagingNav1.chooseContact1.main = this;
            this.automaticMessagingNav1.openContacts();
            this.automaticMessagingNav1.Visible = true;
        }

        private void goToManageGroups()
        {
            automaticMessaging(false);
            this.automaticMessagingNav1.chooseGroupContacts1.Directly = true;
            this.automaticMessagingNav1.chooseGroupContacts1.main = this;
            this.automaticMessagingNav1.openGroups();
            this.automaticMessagingNav1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int style = base.CreateParams.ExStyle;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);

            this.WindowState = FormWindowState.Minimized;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }*/
        }


      

        private void label8_Click(object sender, EventArgs e)
        {

            label16.ForeColor = Color.White;
            panel4.VerticalScroll.Value = 0;
            label17.ForeColor = Color.White;
            label8.ForeColor = Color.FromArgb(37, 171, 134);

            panel4.AutoScroll = true;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            label8.ForeColor = Color.White;
            label17.ForeColor = Color.White;
            panel4.VerticalScroll.Value = 0;
            label16.ForeColor = Color.FromArgb(37, 171, 134);

            panel4.AutoScroll = true;


        }


        private void label17_Click(object sender, EventArgs e)
        {
            label16.ForeColor = Color.White;
            panel4.VerticalScroll.Value = 0;
            label17.ForeColor = Color.FromArgb(37, 171, 134); ;
            label8.ForeColor = Color.White;

            panel4.AutoScroll = true;
        }

 
        private void button3_Click_1(object sender, EventArgs e)
        {
            label16.ForeColor = Color.White;
            label17.ForeColor = Color.White;
            label8.ForeColor = Color.White;

            panel4.VerticalScroll.Value = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label16.ForeColor = Color.White;
            label17.ForeColor = Color.White;
            label8.ForeColor = Color.White;

            panel4.VerticalScroll.Value = 0;
        }

 

       
       

        private Form createFormBackground()
        {
            Form formBackground = new Form();
            formBackground.StartPosition = FormStartPosition.Manual;
            formBackground.FormBorderStyle = FormBorderStyle.None;
            formBackground.Opacity = .50d;
            formBackground.BackColor = Color.Black;
            formBackground.TopMost = true;
            formBackground.Location = this.Location;
            formBackground.Width = this.Width;
            formBackground.Height = this.Height;
            formBackground.ShowInTaskbar = false;
            formBackground.Show();
            return formBackground;
        }
        
 
        private void button15_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

       
       
        private void button18_Click(object sender, EventArgs e)
        {
            
        }

        private void MainNavPage_Load(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://dkdkfdjldjklgdjfldjs.000webhostapp.com/updateApp.xml");
            /*            AutoUpdater.Start("https://buqayvia.com/updateProgram/updateProgram.xml");
            */

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Width, this.borderPanel18.Location.Y + this.borderPanel18.Height + 30);
        }

        private void label54_Click(object sender, EventArgs e)
        {
            label54.ForeColor = Color.FromArgb(37, 171, 134);

            IWebDriver driver;
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;


            driver = new ChromeDriver(chromeDriverService, Config.GetChromeOptionsMin());
            //driver = new ChromeDriver();
            try
            {
                driver.Url = "https://www.youtube.com/";
            }
            catch (Exception ex)
            {

            }
            label54.ForeColor = Color.White;

        }

        private void label28_Click(object sender, EventArgs e)
        {
            label28.ForeColor = Color.FromArgb(37, 171, 134);

            IWebDriver driver;
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            driver = new ChromeDriver(chromeDriverService, Config.GetChromeOptionsMin());

            //driver = new ChromeDriver();
            try
            {
                driver.Url = "https://api.whatsapp.com/send?phone=9720544630291&text=Hi%20I%20need%20help%20with%20WhatsBiz";
            }
            catch (Exception ex)
            {

            }
            label28.ForeColor = Color.White;
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
        private void label21_Click(object sender, EventArgs e)
        {
            label21.ForeColor = Color.FromArgb(37, 171, 134);
          
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                GeneralSettings s = new GeneralSettings(this);
                s.ShowDialog();
                this.Refresh();
            }

            label21.ForeColor = Color.White;
        }

       
        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
           /* if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }*/
        }
        private void button3_Click_2(object sender, EventArgs e)
        {
            if(this.WindowState== FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
                this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Width, this.borderPanel7.Location.Y+this.borderPanel7.Height+30);
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.flowLayoutPanel1.Size = this.sizeNormal;
            }
            panel4.Refresh();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            backToHomeScreen();
        }

        public void backToHomeScreen()
        {
            panel4.Visible = true;
            panel4.BringToFront();
            label8.ForeColor = Color.FromArgb(37, 171, 134);
        }

        private void MainNavPage_SizeChanged(object sender, EventArgs e)
        {
            this.panel4.Refresh();
        }


        private void automaticMessaging(bool view=true)
        {
            this.automaticMessagingNav1.Visible = view;
            this.automaticMessagingNav1.init();
            this.automaticMessagingNav1.mainNavPage = this;
            label8.ForeColor = Color.White;
            panel4.SendToBack();
        }
        private void button11_Click_1(object sender, EventArgs e)
        {
            goToManageGroups();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WaAutoReplyForm bot = new WaAutoReplyForm(senderForm,false,this);
            bot.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                GetGroupMember getGroupMember = new GetGroupMember(senderForm,this);
                getGroupMember.ShowDialog();
                this.Refresh();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                GroupMemberAdder memberAdder = new GroupMemberAdder(senderForm, this);
                memberAdder.ShowDialog();
                this.Refresh();
            }

        }

        private void button23_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                GroupFinder groupMemberAdder = new GroupFinder(senderForm,this);
                groupMemberAdder.ShowDialog();
                this.Refresh();
            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                GroupsJoiner joiner = new GroupsJoiner(senderForm,this);
                joiner.ShowDialog();
                this.Refresh();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                NumberFilter number = new NumberFilter(senderForm,this);
                number.ShowDialog();
                this.Refresh();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                ContactGrabber contactGrabber = new ContactGrabber(senderForm,this);
                contactGrabber.ShowDialog();
                this.Refresh();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                GrabGroupLinks grabGroupLinks = new GrabGroupLinks(senderForm,this,p);
                grabGroupLinks.ShowDialog();
                this.Refresh();
            }

        }

        private void button24_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                GrabGroupActiveMembers grabGroupActiveMembers = new GrabGroupActiveMembers(senderForm,this);
                grabGroupActiveMembers.ShowDialog();
                this.Refresh();
            }

        }

        private void button25_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                GMapExtractor gMapExtractor = new GMapExtractor(senderForm,this);
                gMapExtractor.ShowDialog();
                this.Refresh();
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                GrabChatList grabGroups = new GrabChatList(senderForm,this);
                grabGroups.ShowDialog();
                this.Refresh();
            }
        }

        private void automaticMessagingNav1_Load(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
           goToManageContacts();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            automaticMessaging();
        }

        private void label65_Click(object sender, EventArgs e)
        {
            label65.ForeColor = Color.FromArgb(37, 171, 134);

            IWebDriver driver;
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;


            driver = new ChromeDriver(chromeDriverService, Config.GetChromeOptionsMin());
            //driver = new ChromeDriver();
            try
            {
                driver.Url = "https://trello.com/b/QfctdFpC/whatsbiz";
            }
            catch (Exception ex)
            {

            }
            label65.ForeColor = Color.White;
        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
