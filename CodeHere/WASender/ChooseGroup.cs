using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WaAutoReplyBot;
using WASender.Models;
using SelectionMode = System.Windows.Forms.SelectionMode;

namespace WASender
{
    public partial class ChooseGroup : MyMaterialPopOp
    {
        GetGroupMember getGroupMember;
        GroupMemberAdder groupMemberAdder;
        List<WAPI_GroupModel> wAPI_GroupModel;
        NumberFilter numberFilter;
        List<WASenderSingleTransModel> wASenderSingleList;
        List<WASenderGroupTransModel> wASenderGroupList;
        WaSenderForm senderForm;
        List<GroupContact> groupContacts;
        GroupsJoiner joiner;
        string cond;
        List<IndividualContacts> individualContacts;
        private static string fileSaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "fileSaves");


        public ChooseGroup(GroupMemberAdder _groupMemberAdder, List<WAPI_GroupModel> _wAPI_GroupModel)
        {
            InitializeComponent();
            groupMemberAdder = _groupMemberAdder;
            init(_wAPI_GroupModel);
        }

        public ChooseGroup(WaSenderForm _waSenderForm, List<GroupContact> _groupContacts)
        {
            InitializeComponent();
            senderForm = _waSenderForm;
            init(_groupContacts);
        }

        public ChooseGroup(GroupMemberAdder groupMemberAdder,string cond)
        {
            InitializeComponent();
            this.cond = cond;
            this.groupMemberAdder = groupMemberAdder;
            init(cond);
        }

        public ChooseGroup(NumberFilter numberFilter, string cond)
        {
            InitializeComponent();
            this.cond = cond;
            this.numberFilter = numberFilter;
            init(cond);
        }

        public ChooseGroup(GroupsJoiner joiner, string cond)
        {
            InitializeComponent();
            this.cond = cond;
            this.joiner = joiner;
            init(cond);
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
        private void init(List<GroupContact> _groupContacts)
        {
            groupContacts = _groupContacts;
            initLanguage();

            List<string> names = new List<string>();

            foreach (var item in groupContacts)
            {
                names.Add(item.Name.Replace(".xlsx", ""));
            }

            materialListBox1.DataSource = names;
        }
        
        private void init(string cond)
        {
            initLanguage();
            if (cond=="single")
            {
                string filedata = File.ReadAllText(fileSaves+ "\\IndividualContacts.json");

                List<IndividualContacts> contacts = new List<IndividualContacts>();

                if (!String.IsNullOrWhiteSpace(filedata))
                    contacts = JsonConvert.DeserializeObject<List<IndividualContacts>>(filedata);

                List<string> names = new List<string>();

                foreach (var item in contacts)
                {
                    names.Add(item.Name.Replace(".xlsx", ""));
                }

                materialListBox1.DataSource = names;
            }
            else
            {
                string filedata = cond=="groups"? File.ReadAllText(fileSaves+"\\Groups.json"): File.ReadAllText(fileSaves+"\\GroupLinks.json");
                List<GroupContact> contacts = new List<GroupContact>();
                
                if(!String.IsNullOrWhiteSpace(filedata))
                    contacts = JsonConvert.DeserializeObject<List<GroupContact>>(filedata);

                List<string> names = new List<string>();

                foreach (var item in contacts)
                {
                    names.Add(item.Name.Replace(".xlsx", ""));
                }

                materialListBox1.DataSource = names;
            }
            
        }

        public ChooseGroup(WaSenderForm _waSenderForm, List<IndividualContacts> _individualContacts)
        {
            InitializeComponent();
            senderForm = _waSenderForm;
            init(_individualContacts);
        }

        private void init(List<IndividualContacts> _individualContacts)
        {
            individualContacts = _individualContacts;
            initLanguage();

            List<string> names = new List<string>();

            foreach (var item in individualContacts)
            {
                names.Add(item.Name.Replace(".xlsx", ""));
            }

            materialListBox1.DataSource = names;
        }
        public ChooseGroup(GetGroupMember _getGroupMember, List<WAPI_GroupModel> _wAPI_GroupModel, bool _MultiSelect = false)
        {
            InitializeComponent();
            getGroupMember = _getGroupMember;

            if (_MultiSelect == true)
            {
                materialListBox1.SelectionMode = SelectionMode.MultiSimple;
            }

            init(_wAPI_GroupModel);
        }

        public ChooseGroup(WaSenderForm _waSenderForm, List<WASenderSingleTransModel> _wASenderSingleList)
        {
            InitializeComponent();
            senderForm = _waSenderForm;
            init(_wASenderSingleList);
        }

        public ChooseGroup(WaSenderForm _waSenderForm, List<WASenderGroupTransModel> _wASenderGroupList)
        {
            InitializeComponent();
            senderForm = _waSenderForm;
            init(_wASenderGroupList);
        }



        private void init(List<WAPI_GroupModel> _wAPI_GroupModel)
        {
            wAPI_GroupModel = _wAPI_GroupModel;
            initLanguage();


            foreach (var item in wAPI_GroupModel)
            {
                MaterialSkin.MaterialListBoxItem lbitem = new MaterialSkin.MaterialListBoxItem();
                lbitem.Text = item.GroupName;

                //ListBoxItem 

                // materialListBox1.Items.Add(item.GroupName);
            }
            materialListBox1.DataSource = wAPI_GroupModel;
            materialListBox1.ValueMember = "GroupId";
            materialListBox1.DisplayMember = "GroupName";
            //materialListBox1.MultiSelect = true;
        }

        private void init(List<WASenderSingleTransModel> _wASenderSingleList)
        {
            wASenderSingleList = _wASenderSingleList;
            initLanguage();

            foreach (var item in wASenderSingleList)
            {
                MaterialSkin.MaterialListBoxItem lbitem = new MaterialSkin.MaterialListBoxItem();
                lbitem.Text = item.CampaignName;
                materialListBox1.Items.Add(lbitem);
            }
        }

        private void init(List<WASenderGroupTransModel> _wASenderGroupList)
        {
            wASenderGroupList = _wASenderGroupList;
            initLanguage();

            foreach (var item in wASenderGroupList)
            {
                MaterialSkin.MaterialListBoxItem lbitem = new MaterialSkin.MaterialListBoxItem();
                lbitem.Text = item.CampaignName;
                materialListBox1.Items.Add(lbitem);
            }
        }

        private void initLanguage()
        {
            this.Text = Strings.ChooseGroup;
            materialButton1.Text = Strings.Select;
            //materialTextBox21.Hint = Strings.Search;

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (materialListBox1.SelectedIndex < 0)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar(Strings.PleaseSelectGroup, Strings.OK, true);
                SnackBarMessage.Show(this);
            }
            else
            {
                if (this.getGroupMember != null)
                {
                    List<WAPI_GroupModel> _WAPI_GroupModel = new List<WAPI_GroupModel>();
                    foreach (WAPI_GroupModel item in materialListBox1.SelectedItems)
                    {
                        _WAPI_GroupModel.Add(item);
                    }
                    this.getGroupMember.ReturnBack(_WAPI_GroupModel);
                }
                else if (groupMemberAdder != null && cond == null)
                {
                    var item = (WAPI_GroupModel)materialListBox1.SelectedItems[0];
                    this.groupMemberAdder.ReturnBack(item);
                }
                else if (groupMemberAdder != null)
                {
                    var item = (WAPI_GroupModel)materialListBox1.SelectedItems[0];
                    this.groupMemberAdder.ReturnBack(item);
                }
                else if (senderForm != null)
                {
                    this.senderForm.ReturnBack(materialListBox1.SelectedIndex);
                }
                else if(numberFilter != null)
                {
                    this.numberFilter.Return(materialListBox1.SelectedIndex);
                }
                else if(joiner!=null)
                {
                    this.joiner.Return(materialListBox1.SelectedIndex);
                }

                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialTextBox21_TextChanged(object sender, EventArgs e)
        {
            materialListBox1.DataSource = wAPI_GroupModel.Where(x => x.GroupName.ToUpper().Contains(materialTextBox21.Text.ToUpper())).ToList();
            materialListBox1.ValueMember = "GroupId";
            materialListBox1.DisplayMember = "GroupName";
        }
    }
}
