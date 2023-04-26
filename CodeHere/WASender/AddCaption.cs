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
using WaAutoReplyBot;
using WASender.Model;

namespace WASender
{
    public partial class AddCaption : MyMaterialPopOp
    {

        WaSenderForm waSenderForm;
        CaptionModel captionModel;
        public AddCaption(WaSenderForm _waSenderForm, CaptionModel _captionModel)
        {
            InitializeComponent();
            this.waSenderForm = _waSenderForm;
            this.captionModel = _captionModel;

            checkBox1.Hide();
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
        private void AddCaption_Load(object sender, EventArgs e)
        {
            initLanguages();
            if (captionModel.IsAttachwithMainMessage == true)
            {
                checkBox1.Checked = true;
                txtLongMessage.Text = "";
            }
            txtLongMessage.Text = captionModel.Caption;
        }

        private void initLanguages()
        {
            this.Text = Strings.AddCaption;
            txtLongMessage.Hint = Strings.TypeYourMessagehere;
/*            materialButton2.Text = Strings.Save;
*/        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (txtLongMessage.Text != "")
            {
                if (checkBox1.Checked)
                    txtLongMessage.Text = "";

                this.waSenderForm.AddCaptionFReturn(txtLongMessage.Text, checkBox1.Checked);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
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
        public void AddKeyMarker(string KeyMarker)
        {
            txtLongMessage.Text += KeyMarker;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ClientRectangle.Size;
                p.BackgroundImage = FormFade();
                this.Controls.Add(p);
                p.BringToFront();

                KeyMarker keyMarker = new KeyMarker(this);
                keyMarker.ShowDialog();
                this.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtLongMessage.Text += "{{ RANDOM }}";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtLongMessage.Enabled = false;
                button2.Enabled = false;
                button16.Enabled = false;
            }
            else
            {
                txtLongMessage.Enabled = true;
                button2.Enabled = true;
                button16.Enabled = true;
            }
        }
    }
}
