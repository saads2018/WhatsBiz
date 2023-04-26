using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WASender
{
    public partial class AddGroup : WaAutoReplyBot.MyMaterialPopOp
    {
        ChooseGroupContacts chooseGroupContacts;
        bool edit;
        public AddGroup(ChooseGroupContacts chooseGroupContacts)
        {
            InitializeComponent();
            edit= false;
            this.chooseGroupContacts = chooseGroupContacts;
            if (chooseGroupContacts.globalCond > 1)
            {
                label2.Text = "Group Link";
                materialTextBox22.Hint = "Enter Link";
                label22.Text = "Add Link";
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void EditGroup(string name, string desc)
        {
            label22.Text = chooseGroupContacts.globalCond>1? "Edit Link":"Edit Group";
            materialTextBox21.Text = name;
            materialTextBox22.Text = desc;
            edit = true;
            button2.Visible = true;
            btnActivate.Size = new Size(260, btnActivate.Height);
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                this.chooseGroupContacts.EditGroup(materialTextBox21.Text, materialTextBox22.Text);
            }
            else
                this.chooseGroupContacts.saveContactDetails(materialTextBox21.Text, materialTextBox22.Text);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chooseGroupContacts.Delete();
            this.Close();
        }
    }
}
