using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WASender
{
    public partial class AddContact : WaAutoReplyBot.MyMaterialPopOp
    {
        ChooseContact chooseContact;
        bool edit;
        public AddContact(ChooseContact chooseContact)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void EditContact(string name,string number)
        {
            label2.Text = "Edit Contact";
            materialTextBox21.Text = name;
            materialTextBox22.Text=number;
            button2.Visible = true;
            btnActivate.Size = new Size(253, btnActivate.Height);
            edit= true;
        }
        private void btnActivate_Click(object sender, EventArgs e)
        {
            if(edit)
            {
                this.chooseContact.EditContact(materialTextBox21.Text, materialTextBox22.Text);
            }
            else
                this.chooseContact.saveContactDetails(materialTextBox21.Text, materialTextBox22.Text);
                
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chooseContact.Delete();
            this.Close();
        }
    }
}
