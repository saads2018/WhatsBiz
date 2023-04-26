using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WASender
{
    public partial class About : WaAutoReplyBot.MyMaterialPopOp
    {
        public About()
        {
            InitializeComponent();

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            label1.Text += version;
            DateTime? _date = Config.getEndDate();
            if (_date == null)
            {
                label3.Text = "Never";
            }
            else
            {
                label3.Text = _date.Value.Day.ToString() + "-" + _date.Value.ToString("MMM") + "-" + _date.Value.Year + " " + _date.Value.Hour + ":" + _date.Value.Minute;
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

        private void materialCard4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
