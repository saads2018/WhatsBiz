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

namespace WASender
{
    public partial class InputDialog : MyMaterialPopOp
    {
        GMapExtractor gMapExtractor;
        LinkedInDataExtractor linkedInDataExtractor;


        public InputDialog(GMapExtractor _gMapExtractor)
        {
            gMapExtractor = _gMapExtractor;
            InitializeComponent();
        }

        public InputDialog(LinkedInDataExtractor _linkedInDataExtractor)
        {
            linkedInDataExtractor = _linkedInDataExtractor;
            InitializeComponent();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            initLang();
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
        private void initLang()
        {
            this.Text = Strings.YourSearchterm;
            //materialMaskedTextBox1.Text = Strings.Softwarecompaniesintexas;   
        }

        private void searchInput()
        {
            if (materialMaskedTextBox1.Text != "")
            {
                try
                {
                    if (gMapExtractor != null)
                        gMapExtractor.InputReturn(materialMaskedTextBox1.Text);
                    else if (linkedInDataExtractor != null)
                        linkedInDataExtractor.InputReturn(materialMaskedTextBox1.Text);

                    this.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            searchInput();
        }


        private void materialMaskedTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialMaskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchInput();
        }
    }
}
