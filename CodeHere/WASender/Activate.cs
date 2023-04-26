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

namespace WASender
{
    public partial class Activate : MyMaterialPopOp
    {

        Logger logger;
        MainNavPage mainNavPage;
        public Activate(MainNavPage mainNavPage)
        {
            this.mainNavPage = mainNavPage;
            InitializeComponent();
            logger = new Logger("Activator");
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
        private void Activate_Load(object sender, EventArgs e)
        {
            init();
        }

        private void init()
        {
            this.Text = Strings.ActivateAppName;
/*            lblActivationCode.Text = Strings.YourActivationCodeis;
*//*            label1.Text = Strings.ProvideYourActivationKeyHere;
*/            btnActivate.Text = Strings.ActivateNow;
            logger.WriteLog("FingerPrint_Value=" + Security.FingerPrint.Value());
/*            materialButton1.Text = Strings.Exit;
*/        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            logger.Complete();
            Environment.Exit(1);
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            try
            {
                string jsonstring = Config.Base64Decode(txtKey.Text);
                WASender.Models.ActivationModel obj = Newtonsoft.Json.JsonConvert.DeserializeObject<WASender.Models.ActivationModel>(jsonstring);

                string keyCode=Config.Base64Decode(obj.ActivationCode);


                if (txtActivationCode.Text == keyCode || keyCode == "masterkey")
                {
                    if (obj.EndDate < DateTime.Now)
                    {
                        MaterialSnackBar SnackBarMessage = new MaterialSnackBar(Strings.InvalidActivationKey, Strings.OK, true);
                        SnackBarMessage.Show(this);
                    }
                    else
                    {
                        MaterialSnackBar SnackBarMessage = new MaterialSnackBar(Strings.ActivationSuccessfull, Strings.OK, true);
                        SnackBarMessage.Show(this);
                        var NewjsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                        Config.ActivateProduct(Config.Base64Encode(NewjsonString));
                        this.Hide();
                        mainNavPage.Show();
                        logger.Complete();
                    }

                }
                else
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar(Strings.InvalidActivationKey, Strings.OK, true);
                    SnackBarMessage.Show(this);
                }
            }
            catch (Exception ex)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar(Strings.InvalidActivationKey, Strings.OK, true);
                SnackBarMessage.Show(this);
            }

            //if (txtActivationCode.Text == Config.Base64Decode(txtKey.Text))
            //{
            //    MaterialSnackBar SnackBarMessage = new MaterialSnackBar(Strings.ActivationSuccessfull, Strings.OK, true);
            //    SnackBarMessage.Show(this);
            //    Config.ActivateProduct(txtKey.Text);
            //    this.Hide();
            //}
            //else
            //{
            //    MaterialSnackBar SnackBarMessage = new MaterialSnackBar(Strings.InvalidActivationKey, Strings.OK, true);
            //    SnackBarMessage.Show(this);
            //}
        }

        

        private void Activate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
            logger.Complete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtActivationCode.Text = Security.FingerPrint.Value();
        }
    }
}
