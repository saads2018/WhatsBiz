using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaAutoReplyBot.enums;
using WaAutoReplyBot.Models;
using WaAutoReplyBot.Validators;
using FluentValidation.Results;
using WASender;
using WASender.Models;
using System.IO;
using Newtonsoft.Json;
using WASender.Model;

namespace WaAutoReplyBot
{
    public partial class AddRule : MyMaterialPopOp
    {
        RuleTransactionModel ruleTransactionModel;
        WaAutoReplyForm waAutoReplyForm;
        int index;
        public AddRule(RuleTransactionModel _ruleTransactionModel, WaAutoReplyForm _waAutoReplyForm, int index = -1)
        {
            InitializeComponent();
            initializeResolution();
            this.index = index;
            ruleTransactionModel = _ruleTransactionModel;
            waAutoReplyForm = _waAutoReplyForm;
            if (ruleTransactionModel.messages == null)
                ruleTransactionModel.messages = new List<MessageModel>();
        }

       
        private void initializeResolution()
        {
            if(Program.resHeight<=600)
            {
                this.lstMessages.Height -= 50;
                this.materialButton1.Top -= 60;
                this.materialButton3.Top -= 60;
                this.btnDelete.Top -= 60;
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
        private void materialButton1_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                AddMessage addMessage = new AddMessage(new MessageModel(), this);
                addMessage.ShowDialog();
                this.Refresh();
            }

        }

        public void AddNewMesage(MessageModel _messageModel)
        {
            if (_messageModel.IsEditMode != true)
            {
                ListViewItem item = new ListViewItem(new[] { _messageModel.LongMessage, _messageModel.Files.Count().ToString() });
                lstMessages.Items.Add(item);
                ruleTransactionModel.messages.Add(_messageModel);
            }
            else
            {
                var ss = lstMessages.SelectedItems[0].Index;
                ListViewItem item = new ListViewItem(new[] { _messageModel.LongMessage, _messageModel.Files.Count().ToString() });
                lstMessages.Items[ss] = item;
            }
        }

        List<string> removableMessages=new List<string>();
        private RuleTransactionModel ruleTransactionModel1;

        public void DeleteMessage()
        {
            foreach (ListViewItem item in lstMessages.SelectedItems)
            {
                removableMessages.Add(item.Text);
            }
            var ss = lstMessages.SelectedItems[0].Index;
            lstMessages.Items.RemoveAt(ss);
        }

        
        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstMessages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteMessage();
            }
        }

        private void AddRule_Load(object sender, EventArgs e)
        {
            init();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.Text = Strings.AddRule;
         /*   this.materialLabel2.Text = Strings.If;
            this.materialCheckbox1.Text = Strings.Usefallback;*/
            this.txtUserInput.Hint = Strings.UserSend;
/*            this.materialLabel1.Text= Strings.Which;
*/            this.cboCondition.Hint= Strings.Condition;
/*            materialLabel3.Text = Strings.ThenReplywith;
*/            materialButton1.Text = Strings.AddMessage;

            lstMessages.Columns[0].Text = Strings.Message;
            lstMessages.Columns[1].Text = Strings.Attachments;


/*            materialButton2.Text = Strings.Cancel;
*/            btnDelete.Text = Strings.Delete;
            materialButton3.Text = Strings.Save;
        }

        private void init()
        {
            var pauses = WaAutoReplyForm.getPause();
            if(index!=-1)
            {
                if(pauses.Where(x=>x.RuleID==index).FirstOrDefault()!=null)
                {
                    if (pauses.Where(x => x.RuleID == index).FirstOrDefault().DaysCount > 0)
                        checkBox1.Checked = true;
                    else
                        checkBox1.Checked = false;

                    textBox1.Text = pauses.Where(x => x.RuleID == index).FirstOrDefault().DaysCount.ToString();
                }
                else
                {
                    pauses.Add(new RulePause(index, 0));
                    WaAutoReplyForm.savePause(pauses);
                }
            }

            cboCondition.DataSource = Enum.GetValues(typeof(enums.OperatorsEnum));
            if (!ruleTransactionModel.IsFallBack)
            {
                txtUserInput.Text = ruleTransactionModel.userInput;
            }
            materialCheckbox1.Checked = ruleTransactionModel.IsFallBack;

            foreach (var _messageModel in ruleTransactionModel.messages)
            {
                ListViewItem Listitem = new ListViewItem(new[] { _messageModel.LongMessage, _messageModel.Files.Count().ToString() });
                lstMessages.Items.Add(Listitem);
            }
            if (ruleTransactionModel.IsEditMode)
            {
                btnDelete.Visible = true;
            }
            cboCondition.SelectedIndex = cboCondition.FindStringExact(ruleTransactionModel.operatorsEnum.ToString());
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            ruleTransactionModel.userInput = txtUserInput.Text;
            ruleTransactionModel.operatorsEnum = (OperatorsEnum)Enum.Parse(typeof(OperatorsEnum), cboCondition.Text);
            ruleTransactionModel.IsSaved = true;
            ruleTransactionModel.IsFallBack = materialCheckbox1.Checked;
            if (ruleTransactionModel.IsFallBack == true)
            {
                ruleTransactionModel.userInput = "(" + Strings.fallback + ")";
            }
            List<ValidationFailure> errors = new RuleTransactionModelValidator().Validate(this.ruleTransactionModel).Errors.ToList();

            if (errors.Count() > 0)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar(errors[0].ErrorMessage, Strings.OK, true);
                SnackBarMessage.Show(this);
            }
            else if(lstMessages.Items.Count==0)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Please Add At Least One Message!", Strings.OK, true);
                SnackBarMessage.Show(this);
            }
            else if(checkBox1.Checked && String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Please Enter The Number Of Days!", Strings.OK, true);
                SnackBarMessage.Show(this);
            }
            else if (!int.TryParse(textBox1.Text, out int value))
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Please Make Sure The Count of Days Is An Integer Value!", Strings.OK, true);
                SnackBarMessage.Show(this);
            }
            else if (checkBox1.Checked && Int32.Parse(textBox1.Text)<=0)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Please Enter A Count of Days Greater Than Zero!", Strings.OK, true);
                SnackBarMessage.Show(this);
            }
            else
            {
                foreach (var item in removableMessages)
                {
                    var itemToRemove = ruleTransactionModel.messages.Single(r => r.LongMessage == item);
                    ruleTransactionModel.messages.Remove(itemToRemove);
                }

                    waAutoReplyForm.AddRuleTRansaction(ruleTransactionModel, checkBox1.Checked?textBox1.Text:"0", checkBox1.Checked);

                this.Close();
            }
        }

        private void lstMessages_DoubleClick(object sender, EventArgs e)
        {
            var ss = lstMessages.SelectedItems[0].Index;
            this.ruleTransactionModel.messages[ss].IsEditMode = true;

            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                AddMessage addMessage = new AddMessage(this.ruleTransactionModel.messages[ss], this);
                addMessage.ShowDialog();
                this.Refresh();
            }

        }

        private void AddRule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void AddRule_FormClosing(object sender, FormClosingEventArgs e)
        {
            waAutoReplyForm.HandleChieldEditMode();
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            MaterialDialog materialDialog = new MaterialDialog(this, Strings.Confirm, Strings.AreyousuretodeletethisRule, Strings.OK, true, Strings.Cancel);
            DialogResult result = materialDialog.ShowDialog(this);
            if (result.ToString() == "OK")
            {
                waAutoReplyForm.RemoveItem();
                this.Close();
            }
        }

        private void materialCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckbox1.Checked)
            {
                cboCondition.Enabled = false;
                txtUserInput.Enabled = false;
            }
            else
            {
                cboCondition.Enabled = true;
                txtUserInput.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
