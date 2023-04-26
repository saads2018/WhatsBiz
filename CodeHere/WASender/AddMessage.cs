using FluentValidation.Results;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaAutoReplyBot.Models;
using WaAutoReplyBot.Validators;
using WASender;
using WASender.Models;

namespace WaAutoReplyBot
{
    public partial class AddMessage : MyMaterialPopOp
    {
        MessageModel messageModel;
        AddRule addRule;
        List<ButtonsModel> buttonsModelList1;
        public AddMessage(MessageModel _messageModel, AddRule _addRule)
        {
            messageModel = _messageModel;
            addRule = _addRule;
            InitializeComponent();
            if (_messageModel.buttons == null)
            {
                buttonsModelList1 = new List<ButtonsModel>();
            }
            else
            {
                buttonsModelList1 = _messageModel.buttons;
            }

            if(!String.IsNullOrWhiteSpace(_messageModel.LongMessage))
            {
                button2.Visible = true;
                materialButton2.Size=new Size(txtLongMessage.Width, this.materialButton2.Height);
            }

            webBrowser1.DocumentText = Storage.DocumentHtmlString;
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser1_DocumentCompleted);
            if (_messageModel.buttons !=null && _messageModel.buttons.Count() > 0)
            {
                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(500);
                    this.Invoke(new Action(() =>
                        geterateButtons()));
                });
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
        private void browser1_DocumentCompleted(Object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.webBrowser1.Document.Body.MouseDown += new HtmlElementEventHandler(Body_MouseDown1);
        }

        private void Body_MouseDown1(Object sender, HtmlElementEventArgs e)
        {
            switch (e.MouseButtonsPressed)
            {
                case MouseButtons.Left:
                    HtmlElement element = this.webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
                    var btnId = element.GetAttribute("id");
                    if (btnId != "")
                    {
                        try
                        {
                            ButtonsModel b = buttonsModelList1.Where(x => x.id == btnId).FirstOrDefault();
                            b.editMode = true;
                            AddButton addButton = new AddButton(this, b);
                            addButton.ShowDialog();
                            this.Refresh();
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    break;
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Utils.selectFileForMessage(lstViewFiles);
        }

        private void lstViewFiles_KeyDown(object sender, KeyEventArgs e)
        {
            Utils.removeListViewItem(e, lstViewFiles);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.messageModel.LongMessage = txtLongMessage.Text;
            this.messageModel.Files = new List<string>();


            foreach (ListViewItem item in lstViewFiles.Items)
            {
                this.messageModel.Files.Add(item.Text);
            }
            this.messageModel.buttons = buttonsModelList1;

            List<ValidationFailure> errors = new MessageModelValidator().Validate(this.messageModel).Errors.ToList();
            if (errors.Count() > 0)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar(errors[0].ErrorMessage, Strings.OK, true);
                SnackBarMessage.Show(this);
            }
            else
            {
                this.addRule.AddNewMesage(this.messageModel);
                this.Close();
            }

        }

        private void AddMessage_Load(object sender, EventArgs e)
        {
            init();
            initLanguage();
        }

        private void initLanguage()
        {
            this.Text = Strings.ReplyMessage;
            txtLongMessage.Hint = Strings.TypeYourMessagehere;
            materialButton1.Text = Strings.Addfile;
/*            materialButton3.Text = Strings.Cancel;
*/            materialButton2.Text = Strings.Add;
            lstViewFiles.Columns[0].Text = Strings.Files;
        }

        private void init()
        {
            this.txtLongMessage.Text = this.messageModel.LongMessage;
            if (this.messageModel.Files == null)
                this.messageModel.Files = new List<string>();

            foreach (var item in this.messageModel.Files)
            {
                lstViewFiles.Items.Add(item);
            }
        }

        private void AddMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void materialButton19_Click(object sender, EventArgs e)
        {
            ShowAddButtonDialog();
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

        private void ShowAddButtonDialog()
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                ButtonsModel buttonsModel = new ButtonsModel();
                buttonsModel.buttonTypeEnum = WASender.enums.ButtonTypeEnum.NONE;
                AddButton keyMarker = new AddButton(this, buttonsModel);
                keyMarker.ShowDialog();
                this.Refresh();
            }


        }

        public void RecievButton(ButtonsModel _buttonsModel)
        {
            if (_buttonsModel.editMode == true)
            {
                int index = buttonsModelList1.FindIndex(x => x.id == _buttonsModel.id);
                _buttonsModel.editMode = false;
                buttonsModelList1[index] = _buttonsModel;
            }
            else
            {
                buttonsModelList1.Add(_buttonsModel);
            }

            geterateButtons();
        }

        private void geterateButtons()
        {
            string buttontext = Storage.DocumentHtmlString;
            string cssStyle = Storage.DocumentButtonStypeStrig;

            foreach (var item in buttonsModelList1)
            {
                string txt = "";

                if (item.buttonTypeEnum == WASender.enums.ButtonTypeEnum.PHONE_NUMBER)
                {
                    txt = "📞" + item.text;
                }
                else if (item.buttonTypeEnum == WASender.enums.ButtonTypeEnum.URL)
                {
                    txt = "🔗 " + item.text;
                }
                else
                {
                    txt = item.text;
                }
                buttontext += "<button style='margin:5px;" + cssStyle + "' type='button' id='" + item.id + "' >" + txt + "</button>";
            }
            webBrowser1.DocumentText = buttontext + "</body></html>";
        }
        public void RemoveButton(ButtonsModel buttonsModel)
        {
            int index = buttonsModelList1.FindIndex(x => x.id == buttonsModel.id);
            buttonsModelList1.Remove(buttonsModelList1[index]);
            geterateButtons();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.addRule.DeleteMessage();
            this.Close();
        }
    }
}
