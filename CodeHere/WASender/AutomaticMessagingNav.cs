using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WASender
{
    public partial class AutomaticMessagingNav : UserControl
    {
        MainNavPage navPage;
        public AutomaticMessagingNav()
        {
            InitializeComponent();
            init();
        }

        public MainNavPage mainNavPage { get; set; }

        public void init()
        {
            chooseContact1.Visible = false;
            chooseGroupContacts1.Visible = false;
            this.panel4.AutoScroll = true;
        }

        public void openContacts()
        {
            chooseContact1.goToLists();
            chooseContact1.Visible = true;
            chooseContact1.BringToFront();
            chooseContact1.Refresh();
            chooseGroupContacts1.Visible = false;
            panel4.SendToBack();
            chooseContact1.label2.Location = new Point(chooseContact1.label1.Location.X + 30, chooseContact1.borderPanel5.Location.Y + 200);

        }

        public void openGroups(bool view=true)
        {
            chooseGroupContacts1.View(0, "0",view);
            chooseGroupContacts1.Visible = true;
            chooseGroupContacts1.BringToFront();
            chooseContact1.Visible = false;
            chooseGroupContacts1.switchToLinks(view);
            chooseGroupContacts1.switchToGroups(view);
            panel4.SendToBack();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openContacts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainNavPage.backToHomeScreen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WaSenderForm senderForm1 = new WaSenderForm();
            senderForm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openGroups();
        }
    }
}
