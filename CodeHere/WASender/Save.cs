using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WASender.Models;

namespace WASender
{
    public partial class Save : Form
    {
        WASenderSingleTransModel wASenderSingleTransModel;
        WASenderGroupTransModel wASenderGroupTransModel;
        bool single;
        public Save(WASenderSingleTransModel wASenderSingleTransModel,WASenderGroupTransModel wASenderGroupTransModel,bool single)
        {    
            InitializeComponent();

            this.wASenderSingleTransModel = wASenderSingleTransModel;
            this.wASenderGroupTransModel = wASenderGroupTransModel;
            this.single = single;
            init();
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
        private void init()
        {
            String tmpFolderPath = Config.GetTempFolderPath();
            string Json = "";
            string filedata = File.ReadAllText(fileSaves + "\\" + "SingleSender.json");
            string filedata1 = File.ReadAllText(fileSaves + "\\" + "GroupSender.json");
            List<WASenderSingleTransModel> wASenders = JsonConvert.DeserializeObject<List<WASenderSingleTransModel>>(filedata);
            List<WASenderGroupTransModel> wASenders1 = JsonConvert.DeserializeObject<List<WASenderGroupTransModel>>(filedata1);

           
            if (single)
            {
                if (wASenders == null)
                {
                    wASenders = new List<WASenderSingleTransModel>();
                }

                wASenderSingleTransModel.Id = wASenders.Count;
                wASenders.Add(wASenderSingleTransModel);
                Json = JsonConvert.SerializeObject(wASenders, Formatting.Indented);
                File.WriteAllText(fileSaves + "\\" + "SingleSender.json", Json);
            }
            else
            {
                if (wASenders1 == null)
                {
                    wASenders1 = new List<WASenderGroupTransModel>();
                }
                wASenderGroupTransModel.Id = wASenders1.Count;
                wASenders1.Add(wASenderGroupTransModel);
                Json = JsonConvert.SerializeObject(wASenders1, Formatting.Indented);
                File.WriteAllText(fileSaves + "\\" + "GroupSender.json", Json);
            }
        }

        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
