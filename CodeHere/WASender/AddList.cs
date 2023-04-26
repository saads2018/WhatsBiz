using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WASender
{
    public partial class AddList : WaAutoReplyBot.MyMaterialPopOp
    {
        ChooseContact chooseContact;
        ChooseGroupContacts chooseGroupContacts;
        bool edit;
        public AddList(ChooseContact chooseContact)
        {
            InitializeComponent();
            this.chooseContact = chooseContact;
            edit = false;
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

        public AddList(ChooseGroupContacts chooseGroupContacts)
        {
            InitializeComponent();
            this.chooseGroupContacts = chooseGroupContacts;
            edit = false;
        }

        public void EditList(string name)
        {
            label22.Text = "Edit List";
            materialTextBox21.Text = name;
            button2.Visible = true;
            btnActivate.Size = new Size(253, btnActivate.Height);
            edit = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if(chooseContact != null)
            {
                if (edit)
                {
                    this.chooseContact.EditList(materialTextBox21.Text);
                }
                else
                    this.chooseContact.saveContactDetails(materialTextBox21.Text, "");
            }
            else
            {
                if (edit)
                {
                    this.chooseGroupContacts.EditList(materialTextBox21.Text);
                }
                else
                    this.chooseGroupContacts.saveContactDetails(materialTextBox21.Text, "");
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chooseContact != null)
                this.chooseContact.deleteList();
            else
                this.chooseGroupContacts.deleteList();

            this.Close();
        }
    }
}
