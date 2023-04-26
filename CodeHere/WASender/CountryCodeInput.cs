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
    public partial class CountryCodeInput : MyMaterialPopOp
    {
        WaSenderForm waSenderForm;
        //MaterialSkin.MaterialSkinManager materialSkinManager;
        public CountryCodeInput(WaSenderForm _WaSenderForm)
        {
            waSenderForm = _WaSenderForm;
            InitializeComponent();
           // Utils.SetColorScheme(materialSkinManager, this);
            init();
        }

        private void init()
        {
            this.Text = Strings.EnterCountryCode;
            materialButton1.Text = Strings.OK;
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
        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int cc = Convert.ToInt32(materialMaskedTextBox1.Text);
                waSenderForm.CountryCOdeAdded(materialMaskedTextBox1.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
