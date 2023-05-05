using System.Collections.Generic;
using System.Windows.Forms;

namespace WASender
{
    partial class WaSenderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        List<Control> controlsResolution;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.controlsResolution = new List<Control>();

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaSenderForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageListMainTabs = new System.Windows.Forms.ImageList(this.components);
            this.lblSection = new System.Windows.Forms.Label();
            this.chkDarkMode = new System.Windows.Forms.CheckBox();
            this.savesampleExceldialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCaptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.label54 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.materialCard4 = new MaterialSkin.Controls.MaterialCard();
            this.panel90 = new System.Windows.Forms.Panel();
            this.materialLabel10 = new System.Windows.Forms.Label();
            this.txtdelayAfterEveryMessageToGroup = new WASender.CustomInputs.Int32TextBox();
            this.materialLabel11 = new System.Windows.Forms.Label();
            this.txtdelayAfterEveryMessageFromGroup = new WASender.CustomInputs.Int32TextBox();
            this.materialLabel12 = new System.Windows.Forms.Label();
            this.materialCheckbox3 = new System.Windows.Forms.CheckBox();
            this.panel89 = new System.Windows.Forms.Panel();
            this.materialLabel13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.materialLabel14 = new System.Windows.Forms.Label();
            this.txtdelayAfterMessagesToGroup = new WASender.CustomInputs.Int32TextBox();
            this.materialLabel15 = new System.Windows.Forms.Label();
            this.txtdelayAfterMessagesFromGroup = new WASender.CustomInputs.Int32TextBox();
            this.materialLabel16 = new System.Windows.Forms.Label();
            this.materialCheckbox4 = new System.Windows.Forms.CheckBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.materialLabel17 = new System.Windows.Forms.Label();
            this.btnStartGroup = new System.Windows.Forms.Button();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.materialButton2 = new System.Windows.Forms.Button();
            this.gridTargetsGroup = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panel57 = new System.Windows.Forms.Panel();
            this.panel58 = new System.Windows.Forms.Panel();
            this.panel59 = new System.Windows.Forms.Panel();
            this.btnUploadExcelGroup = new System.Windows.Forms.Button();
            this.button54 = new System.Windows.Forms.Button();
            this.btnDownloadSampleGroup = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachWithMainMessage5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel60 = new System.Windows.Forms.Panel();
            this.button56 = new System.Windows.Forms.Button();
            this.materialButton4 = new System.Windows.Forms.Button();
            this.panel61 = new System.Windows.Forms.Panel();
            this.button23 = new System.Windows.Forms.Button();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.panel62 = new System.Windows.Forms.Panel();
            this.webBrowser6 = new System.Windows.Forms.WebBrowser();
            this.panel63 = new System.Windows.Forms.Panel();
            this.button58 = new System.Windows.Forms.Button();
            this.txtMsgOneGroup = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel64 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachWithMainMessage6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel65 = new System.Windows.Forms.Panel();
            this.button80 = new System.Windows.Forms.Button();
            this.materialButton5 = new System.Windows.Forms.Button();
            this.panel66 = new System.Windows.Forms.Panel();
            this.button28 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.panel67 = new System.Windows.Forms.Panel();
            this.webBrowser7 = new System.Windows.Forms.WebBrowser();
            this.panel68 = new System.Windows.Forms.Panel();
            this.button20 = new System.Windows.Forms.Button();
            this.txtMsgTwoGroup1 = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel69 = new System.Windows.Forms.Panel();
            this.panel70 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button100 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dataGridView8 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachWithMainMessage7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel71 = new System.Windows.Forms.Panel();
            this.button22 = new System.Windows.Forms.Button();
            this.materialButton6 = new System.Windows.Forms.Button();
            this.panel72 = new System.Windows.Forms.Panel();
            this.button29 = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.panel73 = new System.Windows.Forms.Panel();
            this.webBrowser8 = new System.Windows.Forms.WebBrowser();
            this.panel74 = new System.Windows.Forms.Panel();
            this.button31 = new System.Windows.Forms.Button();
            this.txtMsgTHreeGroup = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel75 = new System.Windows.Forms.Panel();
            this.panel76 = new System.Windows.Forms.Panel();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button120 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dataGridView9 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachWithMainMessage8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel77 = new System.Windows.Forms.Panel();
            this.button24 = new System.Windows.Forms.Button();
            this.materialButton7 = new System.Windows.Forms.Button();
            this.panel78 = new System.Windows.Forms.Panel();
            this.button33 = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.panel79 = new System.Windows.Forms.Panel();
            this.webBrowser9 = new System.Windows.Forms.WebBrowser();
            this.panel80 = new System.Windows.Forms.Panel();
            this.button35 = new System.Windows.Forms.Button();
            this.txtMsgFourGroup = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel81 = new System.Windows.Forms.Panel();
            this.panel82 = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button140 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.dataGridView10 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachWithMainMessage9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel83 = new System.Windows.Forms.Panel();
            this.button26 = new System.Windows.Forms.Button();
            this.materialButton8 = new System.Windows.Forms.Button();
            this.panel84 = new System.Windows.Forms.Panel();
            this.button34 = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.panel85 = new System.Windows.Forms.Panel();
            this.webBrowser10 = new System.Windows.Forms.WebBrowser();
            this.panel86 = new System.Windows.Forms.Panel();
            this.button59 = new System.Windows.Forms.Button();
            this.txtMsgFiveGroup = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.panel88 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdelayAfterEveryMessageTo = new WASender.CustomInputs.Int32TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtdelayAfterEveryMessageFrom = new WASender.CustomInputs.Int32TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.materialCheckbox2 = new System.Windows.Forms.CheckBox();
            this.panel87 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtdelayAfterMessagesTo = new WASender.CustomInputs.Int32TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtdelayAfterMessagesFrom = new WASender.CustomInputs.Int32TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.materialCheckbox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.materialButton1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel26 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.gridTargets = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.button18 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachWithMainMessage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel32 = new System.Windows.Forms.Panel();
            this.button16 = new System.Windows.Forms.Button();
            this.btnAddFileOne = new System.Windows.Forms.Button();
            this.panel30 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel29 = new System.Windows.Forms.Panel();
            this.materialButton19 = new System.Windows.Forms.Button();
            this.txtMsgOne = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.button38 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button380 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachWithMainMessage1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel35 = new System.Windows.Forms.Panel();
            this.button40 = new System.Windows.Forms.Button();
            this.btnAddFileTwo = new System.Windows.Forms.Button();
            this.panel36 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.panel37 = new System.Windows.Forms.Panel();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.panel38 = new System.Windows.Forms.Panel();
            this.materialButton20 = new System.Windows.Forms.Button();
            this.txtMsgTwo = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel39 = new System.Windows.Forms.Panel();
            this.panel40 = new System.Windows.Forms.Panel();
            this.button27 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button270 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachWithMainMessage2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel41 = new System.Windows.Forms.Panel();
            this.button42 = new System.Windows.Forms.Button();
            this.btnAddFileThree = new System.Windows.Forms.Button();
            this.panel42 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel43 = new System.Windows.Forms.Panel();
            this.webBrowser3 = new System.Windows.Forms.WebBrowser();
            this.panel44 = new System.Windows.Forms.Panel();
            this.materialButton21 = new System.Windows.Forms.Button();
            this.txtMsgThree = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel45 = new System.Windows.Forms.Panel();
            this.panel46 = new System.Windows.Forms.Panel();
            this.button32 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button320 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachWithMainMessage3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel47 = new System.Windows.Forms.Panel();
            this.button43 = new System.Windows.Forms.Button();
            this.btnAddFileFour = new System.Windows.Forms.Button();
            this.panel48 = new System.Windows.Forms.Panel();
            this.button17 = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.panel49 = new System.Windows.Forms.Panel();
            this.webBrowser4 = new System.Windows.Forms.WebBrowser();
            this.panel50 = new System.Windows.Forms.Panel();
            this.materialButton22 = new System.Windows.Forms.Button();
            this.txtMsgFour = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel51 = new System.Windows.Forms.Panel();
            this.panel52 = new System.Windows.Forms.Panel();
            this.button41 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button410 = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachWithMainMessage4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel53 = new System.Windows.Forms.Panel();
            this.button44 = new System.Windows.Forms.Button();
            this.btnAddFileFive = new System.Windows.Forms.Button();
            this.panel54 = new System.Windows.Forms.Panel();
            this.button19 = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.panel55 = new System.Windows.Forms.Panel();
            this.webBrowser5 = new System.Windows.Forms.WebBrowser();
            this.panel56 = new System.Windows.Forms.Panel();
            this.materialButton23 = new System.Windows.Forms.Button();
            this.txtMsgFive = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.addCountryCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importNumbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.keyMarkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel19.SuspendLayout();
            this.materialCard4.SuspendLayout();
            this.panel90.SuspendLayout();
            this.panel89.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTargetsGroup)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel57.SuspendLayout();
            this.panel58.SuspendLayout();
            this.panel59.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.panel61.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.panel62.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel64.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            this.panel66.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel67.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel69.SuspendLayout();
            this.panel70.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).BeginInit();
            this.panel72.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.panel73.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel75.SuspendLayout();
            this.panel76.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).BeginInit();
            this.panel78.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.panel79.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel81.SuspendLayout();
            this.panel82.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView10)).BeginInit();
            this.panel84.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.panel85.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel10.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.panel88.SuspendLayout();
            this.panel87.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTargets)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel28.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel30.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel34.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel36.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.panel37.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel39.SuspendLayout();
            this.panel40.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panel42.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel43.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel46.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.panel48.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.panel49.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel51.SuspendLayout();
            this.panel52.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.panel54.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.panel55.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "icons8_speech_24px.png");
            // 
            // imageListMainTabs
            // 
            this.imageListMainTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMainTabs.ImageStream")));
            this.imageListMainTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMainTabs.Images.SetKeyName(0, "icons8_user_96px.png");
            this.imageListMainTabs.Images.SetKeyName(1, "icons8_people_96px.png");
            this.imageListMainTabs.Images.SetKeyName(2, "icons8_maintenance_48px.png");
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.ForeColor = System.Drawing.Color.White;
            this.lblSection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSection.Location = new System.Drawing.Point(217, -34);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(44, 16);
            this.lblSection.TabIndex = 1;
            this.lblSection.Text = "label1";
            // 
            // chkDarkMode
            // 
            this.chkDarkMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDarkMode.AutoSize = true;
            this.chkDarkMode.ForeColor = System.Drawing.Color.White;
            this.chkDarkMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkDarkMode.Location = new System.Drawing.Point(1484, -38);
            this.chkDarkMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDarkMode.Name = "chkDarkMode";
            this.chkDarkMode.Size = new System.Drawing.Size(96, 20);
            this.chkDarkMode.TabIndex = 2;
            this.chkDarkMode.Text = "Dark Mode";
            this.chkDarkMode.UseVisualStyleBackColor = true;
            this.chkDarkMode.CheckedChanged += new System.EventHandler(this.chkDarkMode_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.Black;
            this.toolTip1.ForeColor = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1523, -32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 9);
            this.label1.TabIndex = 4;
            this.label1.Text = "V 2.6.6";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1352, -38);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCaptionToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(163, 28);
            // 
            // addCaptionToolStripMenuItem
            // 
            this.addCaptionToolStripMenuItem.Name = "addCaptionToolStripMenuItem";
            this.addCaptionToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.addCaptionToolStripMenuItem.Text = "Add Caption";
            this.addCaptionToolStripMenuItem.Click += new System.EventHandler(this.addCaptionToolStripMenuItem_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(73)))), ((int)(((byte)(88)))));
            this.panel6.Controls.Add(this.panel23);
            this.panel6.Controls.Add(this.panel22);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(25, 5, 15, 5);
            this.panel6.Size = new System.Drawing.Size(1628, 41);
            this.panel6.TabIndex = 23;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            this.panel6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel6_MouseMove);
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.label54);
            this.panel23.Controls.Add(this.label28);
            this.panel23.Controls.Add(this.label20);
            this.panel23.Controls.Add(this.label52);
            this.panel23.Controls.Add(this.label53);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel23.Location = new System.Drawing.Point(1161, 5);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(377, 31);
            this.panel23.TabIndex = 50;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.White;
            this.label54.Location = new System.Drawing.Point(37, 5);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(126, 19);
            this.label54.TabIndex = 44;
            this.label54.Text = "Save Campaign";
            this.label54.Click += new System.EventHandler(this.label54_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(207, 7);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(127, 19);
            this.label28.TabIndex = 42;
            this.label28.Text = "Load Campaign";
            this.label28.Click += new System.EventHandler(this.label28_Click);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(353, 5);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(2, 20);
            this.label20.TabIndex = 48;
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.White;
            this.label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.White;
            this.label52.Location = new System.Drawing.Point(182, 6);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(2, 20);
            this.label52.TabIndex = 43;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.White;
            this.label53.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.White;
            this.label53.Location = new System.Drawing.Point(12, 6);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(2, 20);
            this.label53.TabIndex = 45;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.label14);
            this.panel22.Controls.Add(this.label8);
            this.panel22.Controls.Add(this.label11);
            this.panel22.Controls.Add(this.label4);
            this.panel22.Controls.Add(this.label2);
            this.panel22.Controls.Add(this.pictureBox12);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel22.Location = new System.Drawing.Point(25, 5);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(300, 31);
            this.panel22.TabIndex = 49;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(162, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(2, 20);
            this.label14.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.label8.Location = new System.Drawing.Point(68, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 19);
            this.label8.TabIndex = 25;
            this.label8.Text = "Individual";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(52, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(2, 20);
            this.label11.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(177, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "Group";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(242, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 20);
            this.label2.TabIndex = 27;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(0, 0);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(31, 31);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 5;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Click += new System.EventHandler(this.pictureBox12_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1538, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 35;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // panel8
            // 
            this.panel8.AutoScroll = true;
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.panel21);
            this.panel8.Controls.Add(this.tabControl1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 137);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(18, 22, 0, 0);
            this.panel8.Size = new System.Drawing.Size(1628, 620);
            this.panel8.TabIndex = 49;
            this.panel8.Visible = false;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint_1);
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.panel19);
            this.panel21.Controls.Add(this.panel20);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel21.Location = new System.Drawing.Point(1110, 22);
            this.panel21.Name = "panel21";
            this.panel21.Padding = new System.Windows.Forms.Padding(10, 23, 10, 3);
            this.panel21.Size = new System.Drawing.Size(506, 598);
            this.panel21.TabIndex = 52;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.materialCard4);
            this.panel19.Controls.Add(this.btnStartGroup);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(10, 23);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel19.Size = new System.Drawing.Size(486, 194);
            this.panel19.TabIndex = 50;
            // 
            // materialCard4
            // 
            this.materialCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard4.Controls.Add(this.panel90);
            this.materialCard4.Controls.Add(this.panel89);
            this.materialCard4.Controls.Add(this.panel9);
            this.materialCard4.Depth = 0;
            this.materialCard4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialCard4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard4.Location = new System.Drawing.Point(3, 52);
            this.materialCard4.Margin = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard4.Name = "materialCard4";
            this.materialCard4.Padding = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.materialCard4.Size = new System.Drawing.Size(480, 139);
            this.materialCard4.TabIndex = 46;
            // 
            // panel90
            // 
            this.panel90.AutoSize = true;
            this.panel90.Controls.Add(this.materialLabel10);
            this.panel90.Controls.Add(this.txtdelayAfterEveryMessageToGroup);
            this.panel90.Controls.Add(this.materialLabel11);
            this.panel90.Controls.Add(this.txtdelayAfterEveryMessageFromGroup);
            this.panel90.Controls.Add(this.materialLabel12);
            this.panel90.Controls.Add(this.materialCheckbox3);
            this.panel90.Location = new System.Drawing.Point(10, 91);
            this.panel90.Name = "panel90";
            this.panel90.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.panel90.Size = new System.Drawing.Size(426, 31);
            this.panel90.TabIndex = 55;
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel10.Location = new System.Drawing.Point(165, 7);
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(183, 18);
            this.materialLabel10.TabIndex = 53;
            this.materialLabel10.Text = "seconds before every msg";
            // 
            // txtdelayAfterEveryMessageToGroup
            // 
            this.txtdelayAfterEveryMessageToGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtdelayAfterEveryMessageToGroup.Location = new System.Drawing.Point(121, 7);
            this.txtdelayAfterEveryMessageToGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdelayAfterEveryMessageToGroup.Name = "txtdelayAfterEveryMessageToGroup";
            this.txtdelayAfterEveryMessageToGroup.Size = new System.Drawing.Size(44, 22);
            this.txtdelayAfterEveryMessageToGroup.TabIndex = 52;
            this.txtdelayAfterEveryMessageToGroup.Text = "8";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel11.Location = new System.Drawing.Point(100, 7);
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(21, 18);
            this.materialLabel11.TabIndex = 51;
            this.materialLabel11.Text = "to";
            // 
            // txtdelayAfterEveryMessageFromGroup
            // 
            this.txtdelayAfterEveryMessageFromGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtdelayAfterEveryMessageFromGroup.Location = new System.Drawing.Point(56, 7);
            this.txtdelayAfterEveryMessageFromGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdelayAfterEveryMessageFromGroup.Name = "txtdelayAfterEveryMessageFromGroup";
            this.txtdelayAfterEveryMessageFromGroup.Size = new System.Drawing.Size(44, 22);
            this.txtdelayAfterEveryMessageFromGroup.TabIndex = 50;
            this.txtdelayAfterEveryMessageFromGroup.Text = "4";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel12.Location = new System.Drawing.Point(18, 7);
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(38, 18);
            this.materialLabel12.TabIndex = 49;
            this.materialLabel12.Text = "Wait";
            // 
            // materialCheckbox3
            // 
            this.materialCheckbox3.AutoSize = true;
            this.materialCheckbox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialCheckbox3.Location = new System.Drawing.Point(0, 7);
            this.materialCheckbox3.Name = "materialCheckbox3";
            this.materialCheckbox3.Size = new System.Drawing.Size(18, 24);
            this.materialCheckbox3.TabIndex = 48;
            this.materialCheckbox3.UseVisualStyleBackColor = true;
            this.materialCheckbox3.CheckedChanged += new System.EventHandler(this.materialCheckbox3_CheckedChanged);
            // 
            // panel89
            // 
            this.panel89.AutoSize = true;
            this.panel89.Controls.Add(this.materialLabel13);
            this.panel89.Controls.Add(this.label3);
            this.panel89.Controls.Add(this.materialLabel14);
            this.panel89.Controls.Add(this.txtdelayAfterMessagesToGroup);
            this.panel89.Controls.Add(this.materialLabel15);
            this.panel89.Controls.Add(this.txtdelayAfterMessagesFromGroup);
            this.panel89.Controls.Add(this.materialLabel16);
            this.panel89.Controls.Add(this.materialCheckbox4);
            this.panel89.Location = new System.Drawing.Point(10, 49);
            this.panel89.Name = "panel89";
            this.panel89.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.panel89.Size = new System.Drawing.Size(426, 31);
            this.panel89.TabIndex = 50;
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel13.Location = new System.Drawing.Point(326, 7);
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(45, 18);
            this.materialLabel13.TabIndex = 54;
            this.materialLabel13.Text = "msgs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(302, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 18);
            this.label3.TabIndex = 53;
            this.label3.Text = "10";
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel14.Location = new System.Drawing.Point(165, 7);
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(137, 18);
            this.materialLabel14.TabIndex = 52;
            this.materialLabel14.Text = "seconds after every";
            // 
            // txtdelayAfterMessagesToGroup
            // 
            this.txtdelayAfterMessagesToGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtdelayAfterMessagesToGroup.Location = new System.Drawing.Point(121, 7);
            this.txtdelayAfterMessagesToGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdelayAfterMessagesToGroup.Name = "txtdelayAfterMessagesToGroup";
            this.txtdelayAfterMessagesToGroup.Size = new System.Drawing.Size(44, 22);
            this.txtdelayAfterMessagesToGroup.TabIndex = 51;
            this.txtdelayAfterMessagesToGroup.Text = "20";
            // 
            // materialLabel15
            // 
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel15.Location = new System.Drawing.Point(100, 7);
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(21, 18);
            this.materialLabel15.TabIndex = 50;
            this.materialLabel15.Text = "to";
            // 
            // txtdelayAfterMessagesFromGroup
            // 
            this.txtdelayAfterMessagesFromGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtdelayAfterMessagesFromGroup.Location = new System.Drawing.Point(56, 7);
            this.txtdelayAfterMessagesFromGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdelayAfterMessagesFromGroup.Name = "txtdelayAfterMessagesFromGroup";
            this.txtdelayAfterMessagesFromGroup.Size = new System.Drawing.Size(44, 22);
            this.txtdelayAfterMessagesFromGroup.TabIndex = 49;
            this.txtdelayAfterMessagesFromGroup.Text = "10";
            // 
            // materialLabel16
            // 
            this.materialLabel16.AutoSize = true;
            this.materialLabel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialLabel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel16.Location = new System.Drawing.Point(18, 7);
            this.materialLabel16.Name = "materialLabel16";
            this.materialLabel16.Size = new System.Drawing.Size(38, 18);
            this.materialLabel16.TabIndex = 48;
            this.materialLabel16.Text = "Wait";
            // 
            // materialCheckbox4
            // 
            this.materialCheckbox4.AutoSize = true;
            this.materialCheckbox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialCheckbox4.Location = new System.Drawing.Point(0, 7);
            this.materialCheckbox4.Name = "materialCheckbox4";
            this.materialCheckbox4.Size = new System.Drawing.Size(18, 24);
            this.materialCheckbox4.TabIndex = 47;
            this.materialCheckbox4.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.panel9.Controls.Add(this.materialLabel17);
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(540, 32);
            this.panel9.TabIndex = 47;
            // 
            // materialLabel17
            // 
            this.materialLabel17.AutoSize = true;
            this.materialLabel17.Font = new System.Drawing.Font("Microsoft Tai Le", 9F);
            this.materialLabel17.ForeColor = System.Drawing.Color.White;
            this.materialLabel17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialLabel17.Location = new System.Drawing.Point(16, 6);
            this.materialLabel17.Name = "materialLabel17";
            this.materialLabel17.Size = new System.Drawing.Size(104, 19);
            this.materialLabel17.TabIndex = 4;
            this.materialLabel17.Text = "Delay Settings";
            // 
            // btnStartGroup
            // 
            this.btnStartGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.btnStartGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStartGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGroup.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGroup.ForeColor = System.Drawing.Color.White;
            this.btnStartGroup.Location = new System.Drawing.Point(3, 0);
            this.btnStartGroup.Name = "btnStartGroup";
            this.btnStartGroup.Size = new System.Drawing.Size(480, 49);
            this.btnStartGroup.TabIndex = 45;
            this.btnStartGroup.Text = "START GROUP CAMPAIGN";
            this.btnStartGroup.UseVisualStyleBackColor = false;
            this.btnStartGroup.Click += new System.EventHandler(this.btnStartGroup_Click);
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.panel12);
            this.panel20.Controls.Add(this.materialButton2);
            this.panel20.Controls.Add(this.gridTargetsGroup);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel20.Location = new System.Drawing.Point(10, 292);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(486, 303);
            this.panel20.TabIndex = 51;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.panel12.Controls.Add(this.label17);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(0, 55);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panel12.Size = new System.Drawing.Size(486, 32);
            this.panel12.TabIndex = 50;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Tai Le", 9F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(16, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 19);
            this.label17.TabIndex = 4;
            this.label17.Text = "Edit File";
            // 
            // materialButton2
            // 
            this.materialButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton2.ForeColor = System.Drawing.Color.White;
            this.materialButton2.Location = new System.Drawing.Point(0, 0);
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.Size = new System.Drawing.Size(486, 49);
            this.materialButton2.TabIndex = 46;
            this.materialButton2.Text = "CLEAR";
            this.materialButton2.UseVisualStyleBackColor = false;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // gridTargetsGroup
            // 
            this.gridTargetsGroup.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTargetsGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTargetsGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTargetsGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn21,
            this.GroupID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTargetsGroup.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridTargetsGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridTargetsGroup.Location = new System.Drawing.Point(0, 87);
            this.gridTargetsGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridTargetsGroup.Name = "gridTargetsGroup";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTargetsGroup.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTargetsGroup.RowHeadersWidth = 51;
            this.gridTargetsGroup.RowTemplate.Height = 24;
            this.gridTargetsGroup.Size = new System.Drawing.Size(486, 216);
            this.gridTargetsGroup.TabIndex = 49;
            this.gridTargetsGroup.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridTargetsGroup_RowsAdded);
            this.gridTargetsGroup.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridTargetsGroup_RowsRemoved);
            this.gridTargetsGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridTargets_MouseClick);
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.HeaderText = "Group Names";
            this.dataGridViewTextBoxColumn21.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.Width = 250;
            // 
            // GroupID
            // 
            this.GroupID.HeaderText = "GroupID";
            this.GroupID.MinimumWidth = 6;
            this.GroupID.Name = "GroupID";
            this.GroupID.ReadOnly = true;
            this.GroupID.Width = 250;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(18, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1092, 598);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 43;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.White;
            this.tabPage7.Controls.Add(this.panel57);
            this.tabPage7.Controls.Add(this.txtMsgOneGroup);
            this.tabPage7.ImageKey = "icons8_speech_24px.png";
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(7, 10, 3, 2);
            this.tabPage7.Size = new System.Drawing.Size(1084, 569);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Message 1";
            // 
            // panel57
            // 
            this.panel57.Controls.Add(this.panel58);
            this.panel57.Controls.Add(this.groupBox21);
            this.panel57.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel57.Location = new System.Drawing.Point(599, 10);
            this.panel57.Name = "panel57";
            this.panel57.Padding = new System.Windows.Forms.Padding(5, 0, 0, 25);
            this.panel57.Size = new System.Drawing.Size(473, 557);
            this.panel57.TabIndex = 56;
            this.panel57.Paint += new System.Windows.Forms.PaintEventHandler(this.panel57_Paint);
            // 
            // panel58
            // 
            this.panel58.Controls.Add(this.panel59);
            this.panel58.Controls.Add(this.btnDownloadSampleGroup);
            this.panel58.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel58.Location = new System.Drawing.Point(5, 0);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(468, 85);
            this.panel58.TabIndex = 52;
            // 
            // panel59
            // 
            this.panel59.Controls.Add(this.btnUploadExcelGroup);
            this.panel59.Controls.Add(this.button54);
            this.panel59.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel59.Location = new System.Drawing.Point(0, 0);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(468, 39);
            this.panel59.TabIndex = 5;
            // 
            // btnUploadExcelGroup
            // 
            this.btnUploadExcelGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.btnUploadExcelGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUploadExcelGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadExcelGroup.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadExcelGroup.ForeColor = System.Drawing.Color.White;
            this.btnUploadExcelGroup.Location = new System.Drawing.Point(0, 0);
            this.btnUploadExcelGroup.Name = "btnUploadExcelGroup";
            this.btnUploadExcelGroup.Size = new System.Drawing.Size(229, 39);
            this.btnUploadExcelGroup.TabIndex = 41;
            this.btnUploadExcelGroup.Text = "UPLOAD EXCEL";
            this.btnUploadExcelGroup.UseVisualStyleBackColor = false;
            this.btnUploadExcelGroup.Click += new System.EventHandler(this.btnUploadExcelGroup_Click);
            // 
            // button54
            // 
            this.button54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button54.Dock = System.Windows.Forms.DockStyle.Right;
            this.button54.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button54.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button54.ForeColor = System.Drawing.Color.White;
            this.button54.Location = new System.Drawing.Point(237, 0);
            this.button54.Name = "button54";
            this.button54.Size = new System.Drawing.Size(231, 39);
            this.button54.TabIndex = 44;
            this.button54.Text = "Load Saved Groups";
            this.button54.UseVisualStyleBackColor = false;
            this.button54.Click += new System.EventHandler(this.button29_Click);
            // 
            // btnDownloadSampleGroup
            // 
            this.btnDownloadSampleGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.btnDownloadSampleGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDownloadSampleGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadSampleGroup.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadSampleGroup.ForeColor = System.Drawing.Color.White;
            this.btnDownloadSampleGroup.Location = new System.Drawing.Point(0, 45);
            this.btnDownloadSampleGroup.Name = "btnDownloadSampleGroup";
            this.btnDownloadSampleGroup.Size = new System.Drawing.Size(468, 40);
            this.btnDownloadSampleGroup.TabIndex = 42;
            this.btnDownloadSampleGroup.Text = "Download Sample Excel";
            this.btnDownloadSampleGroup.UseVisualStyleBackColor = false;
            this.btnDownloadSampleGroup.Click += new System.EventHandler(this.btnGroupDownloadExcel_Click);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.dataGridView6);
            this.groupBox21.Controls.Add(this.panel60);
            this.groupBox21.Controls.Add(this.button56);
            this.groupBox21.Controls.Add(this.materialButton4);
            this.groupBox21.Controls.Add(this.panel61);
            this.groupBox21.Controls.Add(this.groupBox22);
            this.groupBox21.Controls.Add(this.panel63);
            this.groupBox21.Controls.Add(this.button58);
            this.groupBox21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox21.Location = new System.Drawing.Point(5, 111);
            this.groupBox21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Padding = new System.Windows.Forms.Padding(7, 5, 7, 2);
            this.groupBox21.Size = new System.Drawing.Size(468, 421);
            this.groupBox21.TabIndex = 1;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Attachments";
            this.controlsResolution.Add(this.groupBox21);
            // 
            // dataGridView6
            // 
            this.dataGridView6.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.AttachWithMainMessage5});
            this.dataGridView6.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView6.Location = new System.Drawing.Point(7, 66);
            this.dataGridView6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView6.MultiSelect = false;
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.RowHeadersWidth = 51;
            this.dataGridView6.RowTemplate.Height = 24;
            this.dataGridView6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView6.Size = new System.Drawing.Size(454, 160);
            this.dataGridView6.TabIndex = 63;
            this.dataGridView6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView6_MouseClick);
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.HeaderText = "File";
            this.dataGridViewTextBoxColumn22.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 280;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.HeaderText = "Caption";
            this.dataGridViewTextBoxColumn23.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.Width = 125;
            // 
            // AttachWithMainMessage5
            // 
            this.AttachWithMainMessage5.FillWeight = 250F;
            this.AttachWithMainMessage5.HeaderText = "Attach With Main Message";
            this.AttachWithMainMessage5.MinimumWidth = 6;
            this.AttachWithMainMessage5.Name = "AttachWithMainMessage5";
            this.AttachWithMainMessage5.ReadOnly = true;
            this.AttachWithMainMessage5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AttachWithMainMessage5.Width = 125;
            // 
            // panel60
            // 
            this.panel60.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel60.Location = new System.Drawing.Point(7, 56);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(454, 10);
            this.panel60.TabIndex = 62;
            // 
            // button56
            // 
            this.button56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button56.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button56.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button56.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button56.ForeColor = System.Drawing.Color.White;
            this.button56.Location = new System.Drawing.Point(7, 240);
            this.button56.Name = "button56";
            this.button56.Size = new System.Drawing.Size(454, 36);
            this.button56.TabIndex = 57;
            this.button56.Text = "Add Keymarker";
            this.button56.UseVisualStyleBackColor = false;
            this.button56.Click += new System.EventHandler(this.keyMarkersToolStripMenuItem_Click);
            // 
            // materialButton4
            // 
            this.materialButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton4.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton4.ForeColor = System.Drawing.Color.White;
            this.materialButton4.Location = new System.Drawing.Point(7, 20);
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.Size = new System.Drawing.Size(454, 36);
            this.materialButton4.TabIndex = 56;
            this.materialButton4.Text = "Add File";
            this.materialButton4.UseVisualStyleBackColor = false;
            this.materialButton4.Click += new System.EventHandler(this.materialButton4_Click);
            // 
            // panel61
            // 
            this.panel61.Controls.Add(this.button23);
            this.panel61.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel61.Location = new System.Drawing.Point(7, 276);
            this.panel61.Name = "panel61";
            this.panel61.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel61.Size = new System.Drawing.Size(454, 44);
            this.panel61.TabIndex = 54;
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.White;
            this.button23.Dock = System.Windows.Forms.DockStyle.Right;
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button23.Location = new System.Drawing.Point(417, 10);
            this.button23.Name = "button23";
            this.button23.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.button23.Size = new System.Drawing.Size(37, 34);
            this.button23.TabIndex = 68;
            this.button23.Text = "?";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.panel62);
            this.groupBox22.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox22.Location = new System.Drawing.Point(7, 320);
            this.groupBox22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox22.Size = new System.Drawing.Size(454, 53);
            this.groupBox22.TabIndex = 53;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Buttons";
            // 
            // panel62
            // 
            this.panel62.AutoScroll = true;
            this.panel62.Controls.Add(this.webBrowser6);
            this.panel62.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel62.Location = new System.Drawing.Point(3, 17);
            this.panel62.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(448, 34);
            this.panel62.TabIndex = 0;
            // 
            // webBrowser6
            // 
            this.webBrowser6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser6.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser6.Location = new System.Drawing.Point(0, 0);
            this.webBrowser6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser6.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser6.Name = "webBrowser6";
            this.webBrowser6.Size = new System.Drawing.Size(448, 34);
            this.webBrowser6.TabIndex = 2;
            // 
            // panel63
            // 
            this.panel63.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel63.Location = new System.Drawing.Point(7, 373);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(454, 10);
            this.panel63.TabIndex = 52;
            // 
            // button58
            // 
            this.button58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button58.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button58.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button58.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button58.ForeColor = System.Drawing.Color.White;
            this.button58.Location = new System.Drawing.Point(7, 383);
            this.button58.Name = "button58";
            this.button58.Size = new System.Drawing.Size(454, 36);
            this.button58.TabIndex = 49;
            this.button58.Text = "Add Button";
            this.button58.UseVisualStyleBackColor = false;
            this.button58.Click += new System.EventHandler(this.button17_Click);
            // 
            // txtMsgOneGroup
            // 
            this.txtMsgOneGroup.AnimateReadOnly = false;
            this.txtMsgOneGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMsgOneGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMsgOneGroup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMsgOneGroup.Depth = 0;
            this.txtMsgOneGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMsgOneGroup.HideSelection = true;
            this.txtMsgOneGroup.Hint = "* Your first message";
            this.txtMsgOneGroup.Location = new System.Drawing.Point(7, 10);
            this.txtMsgOneGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsgOneGroup.MaxLength = 32767;
            this.txtMsgOneGroup.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMsgOneGroup.Name = "txtMsgOneGroup";
            this.txtMsgOneGroup.PasswordChar = '\0';
            this.txtMsgOneGroup.ReadOnly = false;
            this.txtMsgOneGroup.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMsgOneGroup.SelectedText = "";
            this.txtMsgOneGroup.SelectionLength = 0;
            this.txtMsgOneGroup.SelectionStart = 0;
            this.txtMsgOneGroup.ShortcutsEnabled = true;
            this.txtMsgOneGroup.Size = new System.Drawing.Size(592, 557);
            this.txtMsgOneGroup.TabIndex = 0;
            this.txtMsgOneGroup.TabStop = false;
            this.txtMsgOneGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMsgOneGroup.UseSystemPasswordChar = false;
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.White;
            this.tabPage9.Controls.Add(this.panel14);
            this.tabPage9.Controls.Add(this.txtMsgTwoGroup1);
            this.tabPage9.ImageKey = "icons8_speech_24px.png";
            this.tabPage9.Location = new System.Drawing.Point(4, 25);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(7, 10, 3, 2);
            this.tabPage9.Size = new System.Drawing.Size(1084, 569);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "Message 2";
            this.tabPage9.Click += new System.EventHandler(this.tabPage9_Click);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Controls.Add(this.groupBox6);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(599, 10);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(5, 0, 0, 25);
            this.panel14.Size = new System.Drawing.Size(473, 557);
            this.panel14.TabIndex = 56;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.panel64);
            this.panel15.Controls.Add(this.button7);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(5, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(468, 85);
            this.panel15.TabIndex = 52;
            // 
            // panel64
            // 
            this.panel64.Controls.Add(this.button8);
            this.panel64.Controls.Add(this.button3);
            this.panel64.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel64.Location = new System.Drawing.Point(0, 0);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(468, 39);
            this.panel64.TabIndex = 5;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button8.Dock = System.Windows.Forms.DockStyle.Left;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(0, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(229, 39);
            this.button8.TabIndex = 41;
            this.button8.Text = "UPLOAD EXCEL";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.btnUploadExcelGroup_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(237, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(231, 39);
            this.button3.TabIndex = 44;
            this.button3.Text = "Load Saved Groups";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button31_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(0, 45);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(468, 40);
            this.button7.TabIndex = 42;
            this.button7.Text = "Download Sample Excel";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.btnGroupDownloadExcel_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridView7);
            this.groupBox6.Controls.Add(this.panel65);
            this.groupBox6.Controls.Add(this.button80);
            this.groupBox6.Controls.Add(this.materialButton5);
            this.groupBox6.Controls.Add(this.panel66);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.panel68);
            this.groupBox6.Controls.Add(this.button20);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(5, 111);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(7, 10, 7, 2);
            this.groupBox6.Size = new System.Drawing.Size(468, 421);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Attachments";
            this.controlsResolution.Add(this.groupBox6);
            // 
            // dataGridView7
            // 
            this.dataGridView7.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn10,
            this.AttachWithMainMessage6});
            this.dataGridView7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView7.Location = new System.Drawing.Point(7, 71);
            this.dataGridView7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView7.MultiSelect = false;
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.RowHeadersWidth = 51;
            this.dataGridView7.RowTemplate.Height = 24;
            this.dataGridView7.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView7.Size = new System.Drawing.Size(454, 160);
            this.dataGridView7.TabIndex = 63;
            this.dataGridView7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView7_MouseClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "File";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 280;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Caption";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 125;
            // 
            // AttachWithMainMessage6
            // 
            this.AttachWithMainMessage6.FillWeight = 250F;
            this.AttachWithMainMessage6.HeaderText = "Attach With Main Message";
            this.AttachWithMainMessage6.MinimumWidth = 6;
            this.AttachWithMainMessage6.Name = "AttachWithMainMessage6";
            this.AttachWithMainMessage6.ReadOnly = true;
            this.AttachWithMainMessage6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AttachWithMainMessage6.Width = 125;
            // 
            // panel65
            // 
            this.panel65.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel65.Location = new System.Drawing.Point(7, 61);
            this.panel65.Name = "panel65";
            this.panel65.Size = new System.Drawing.Size(454, 10);
            this.panel65.TabIndex = 62;
            // 
            // button80
            // 
            this.button80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button80.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button80.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button80.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button80.ForeColor = System.Drawing.Color.White;
            this.button80.Location = new System.Drawing.Point(7, 240);
            this.button80.Name = "button80";
            this.button80.Size = new System.Drawing.Size(454, 36);
            this.button80.TabIndex = 57;
            this.button80.Text = "Add Keymarker";
            this.button80.UseVisualStyleBackColor = false;
            this.button80.Click += new System.EventHandler(this.keyMarkersToolStripMenuItem_Click);
            // 
            // materialButton5
            // 
            this.materialButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton5.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton5.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton5.ForeColor = System.Drawing.Color.White;
            this.materialButton5.Location = new System.Drawing.Point(7, 25);
            this.materialButton5.Name = "materialButton5";
            this.materialButton5.Size = new System.Drawing.Size(454, 36);
            this.materialButton5.TabIndex = 56;
            this.materialButton5.Text = "Add File";
            this.materialButton5.UseVisualStyleBackColor = false;
            this.materialButton5.Click += new System.EventHandler(this.materialButton5_Click);
            // 
            // panel66
            // 
            this.panel66.Controls.Add(this.button28);
            this.panel66.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel66.Location = new System.Drawing.Point(7, 276);
            this.panel66.Name = "panel66";
            this.panel66.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel66.Size = new System.Drawing.Size(454, 44);
            this.panel66.TabIndex = 54;
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.Color.White;
            this.button28.Dock = System.Windows.Forms.DockStyle.Right;
            this.button28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button28.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button28.Location = new System.Drawing.Point(417, 10);
            this.button28.Name = "button28";
            this.button28.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.button28.Size = new System.Drawing.Size(37, 34);
            this.button28.TabIndex = 68;
            this.button28.Text = "?";
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.panel67);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(7, 320);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(454, 53);
            this.groupBox7.TabIndex = 53;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Buttons";
            // 
            // panel67
            // 
            this.panel67.AutoScroll = true;
            this.panel67.Controls.Add(this.webBrowser7);
            this.panel67.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel67.Location = new System.Drawing.Point(3, 17);
            this.panel67.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel67.Name = "panel67";
            this.panel67.Size = new System.Drawing.Size(448, 34);
            this.panel67.TabIndex = 0;
            // 
            // webBrowser7
            // 
            this.webBrowser7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser7.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser7.Location = new System.Drawing.Point(0, 0);
            this.webBrowser7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser7.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser7.Name = "webBrowser7";
            this.webBrowser7.Size = new System.Drawing.Size(448, 34);
            this.webBrowser7.TabIndex = 2;
            // 
            // panel68
            // 
            this.panel68.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel68.Location = new System.Drawing.Point(7, 373);
            this.panel68.Name = "panel68";
            this.panel68.Size = new System.Drawing.Size(454, 10);
            this.panel68.TabIndex = 52;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button20.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.ForeColor = System.Drawing.Color.White;
            this.button20.Location = new System.Drawing.Point(7, 383);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(454, 36);
            this.button20.TabIndex = 49;
            this.button20.Text = "Add Button";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // txtMsgTwoGroup1
            // 
            this.txtMsgTwoGroup1.AnimateReadOnly = false;
            this.txtMsgTwoGroup1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMsgTwoGroup1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMsgTwoGroup1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMsgTwoGroup1.Depth = 0;
            this.txtMsgTwoGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMsgTwoGroup1.HideSelection = true;
            this.txtMsgTwoGroup1.Hint = "* Your second message";
            this.txtMsgTwoGroup1.Location = new System.Drawing.Point(7, 10);
            this.txtMsgTwoGroup1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsgTwoGroup1.MaxLength = 32767;
            this.txtMsgTwoGroup1.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMsgTwoGroup1.Name = "txtMsgTwoGroup1";
            this.txtMsgTwoGroup1.PasswordChar = '\0';
            this.txtMsgTwoGroup1.ReadOnly = false;
            this.txtMsgTwoGroup1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMsgTwoGroup1.SelectedText = "";
            this.txtMsgTwoGroup1.SelectionLength = 0;
            this.txtMsgTwoGroup1.SelectionStart = 0;
            this.txtMsgTwoGroup1.ShortcutsEnabled = true;
            this.txtMsgTwoGroup1.Size = new System.Drawing.Size(592, 557);
            this.txtMsgTwoGroup1.TabIndex = 4;
            this.txtMsgTwoGroup1.TabStop = false;
            this.txtMsgTwoGroup1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMsgTwoGroup1.UseSystemPasswordChar = false;
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.White;
            this.tabPage10.Controls.Add(this.panel16);
            this.tabPage10.Controls.Add(this.txtMsgTHreeGroup);
            this.tabPage10.ImageKey = "icons8_speech_24px.png";
            this.tabPage10.Location = new System.Drawing.Point(4, 25);
            this.tabPage10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(7, 10, 3, 2);
            this.tabPage10.Size = new System.Drawing.Size(1084, 569);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "Message 3";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel69);
            this.panel16.Controls.Add(this.groupBox8);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(599, 10);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(5, 0, 0, 25);
            this.panel16.Size = new System.Drawing.Size(473, 557);
            this.panel16.TabIndex = 56;
            // 
            // panel69
            // 
            this.panel69.Controls.Add(this.panel70);
            this.panel69.Controls.Add(this.button100);
            this.panel69.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel69.Location = new System.Drawing.Point(5, 0);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(468, 85);
            this.panel69.TabIndex = 52;
            // 
            // panel70
            // 
            this.panel70.Controls.Add(this.button10);
            this.panel70.Controls.Add(this.button9);
            this.panel70.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel70.Location = new System.Drawing.Point(0, 0);
            this.panel70.Name = "panel70";
            this.panel70.Size = new System.Drawing.Size(468, 39);
            this.panel70.TabIndex = 5;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button10.Dock = System.Windows.Forms.DockStyle.Left;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(0, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(229, 39);
            this.button10.TabIndex = 41;
            this.button10.Text = "UPLOAD EXCEL";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.btnUploadExcelGroup_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button9.Dock = System.Windows.Forms.DockStyle.Right;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(237, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(231, 39);
            this.button9.TabIndex = 44;
            this.button9.Text = "Load Saved Groups";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button34_Click);
            // 
            // button100
            // 
            this.button100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button100.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button100.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button100.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button100.ForeColor = System.Drawing.Color.White;
            this.button100.Location = new System.Drawing.Point(0, 45);
            this.button100.Name = "button100";
            this.button100.Size = new System.Drawing.Size(468, 40);
            this.button100.TabIndex = 42;
            this.button100.Text = "Download Sample Excel";
            this.button100.UseVisualStyleBackColor = false;
            this.button100.Click += new System.EventHandler(this.btnGroupDownloadExcel_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dataGridView8);
            this.groupBox8.Controls.Add(this.panel71);
            this.groupBox8.Controls.Add(this.button22);
            this.groupBox8.Controls.Add(this.materialButton6);
            this.groupBox8.Controls.Add(this.panel72);
            this.groupBox8.Controls.Add(this.groupBox16);
            this.groupBox8.Controls.Add(this.panel74);
            this.groupBox8.Controls.Add(this.button31);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox8.Location = new System.Drawing.Point(5, 111);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(7, 10, 7, 2);
            this.groupBox8.Size = new System.Drawing.Size(468, 421);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Attachments";
            this.controlsResolution.Add(this.groupBox8);
            // 
            // dataGridView8
            // 
            this.dataGridView8.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView8.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.AttachWithMainMessage7});
            this.dataGridView8.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView8.Location = new System.Drawing.Point(7, 71);
            this.dataGridView8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView8.MultiSelect = false;
            this.dataGridView8.Name = "dataGridView8";
            this.dataGridView8.RowHeadersWidth = 51;
            this.dataGridView8.RowTemplate.Height = 24;
            this.dataGridView8.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView8.Size = new System.Drawing.Size(454, 160);
            this.dataGridView8.TabIndex = 63;
            this.dataGridView8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView8_MouseClick);
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "File";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 280;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Caption";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 125;
            // 
            // AttachWithMainMessage7
            // 
            this.AttachWithMainMessage7.FillWeight = 250F;
            this.AttachWithMainMessage7.HeaderText = "Attach With Main Message";
            this.AttachWithMainMessage7.MinimumWidth = 6;
            this.AttachWithMainMessage7.Name = "AttachWithMainMessage7";
            this.AttachWithMainMessage7.ReadOnly = true;
            this.AttachWithMainMessage7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AttachWithMainMessage7.Width = 125;
            // 
            // panel71
            // 
            this.panel71.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel71.Location = new System.Drawing.Point(7, 61);
            this.panel71.Name = "panel71";
            this.panel71.Size = new System.Drawing.Size(454, 10);
            this.panel71.TabIndex = 62;
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button22.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.ForeColor = System.Drawing.Color.White;
            this.button22.Location = new System.Drawing.Point(7, 240);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(454, 36);
            this.button22.TabIndex = 57;
            this.button22.Text = "Add Keymarker";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.keyMarkersToolStripMenuItem_Click);
            // 
            // materialButton6
            // 
            this.materialButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton6.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton6.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton6.ForeColor = System.Drawing.Color.White;
            this.materialButton6.Location = new System.Drawing.Point(7, 25);
            this.materialButton6.Name = "materialButton6";
            this.materialButton6.Size = new System.Drawing.Size(454, 36);
            this.materialButton6.TabIndex = 56;
            this.materialButton6.Text = "Add File";
            this.materialButton6.UseVisualStyleBackColor = false;
            this.materialButton6.Click += new System.EventHandler(this.materialButton6_Click);
            // 
            // panel72
            // 
            this.panel72.Controls.Add(this.button29);
            this.panel72.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel72.Location = new System.Drawing.Point(7, 276);
            this.panel72.Name = "panel72";
            this.panel72.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel72.Size = new System.Drawing.Size(454, 44);
            this.panel72.TabIndex = 54;
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.White;
            this.button29.Dock = System.Windows.Forms.DockStyle.Right;
            this.button29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button29.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button29.Location = new System.Drawing.Point(417, 10);
            this.button29.Name = "button29";
            this.button29.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.button29.Size = new System.Drawing.Size(37, 34);
            this.button29.TabIndex = 68;
            this.button29.Text = "?";
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.button29_Click_1);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.panel73);
            this.groupBox16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox16.Location = new System.Drawing.Point(7, 320);
            this.groupBox16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox16.Size = new System.Drawing.Size(454, 53);
            this.groupBox16.TabIndex = 53;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Buttons";
            // 
            // panel73
            // 
            this.panel73.AutoScroll = true;
            this.panel73.Controls.Add(this.webBrowser8);
            this.panel73.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel73.Location = new System.Drawing.Point(3, 17);
            this.panel73.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel73.Name = "panel73";
            this.panel73.Size = new System.Drawing.Size(448, 34);
            this.panel73.TabIndex = 0;
            // 
            // webBrowser8
            // 
            this.webBrowser8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser8.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser8.Location = new System.Drawing.Point(0, 0);
            this.webBrowser8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser8.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser8.Name = "webBrowser8";
            this.webBrowser8.Size = new System.Drawing.Size(448, 34);
            this.webBrowser8.TabIndex = 2;
            // 
            // panel74
            // 
            this.panel74.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel74.Location = new System.Drawing.Point(7, 373);
            this.panel74.Name = "panel74";
            this.panel74.Size = new System.Drawing.Size(454, 10);
            this.panel74.TabIndex = 52;
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button31.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button31.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button31.ForeColor = System.Drawing.Color.White;
            this.button31.Location = new System.Drawing.Point(7, 383);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(454, 36);
            this.button31.TabIndex = 49;
            this.button31.Text = "Add Button";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.button22_Click);
            // 
            // txtMsgTHreeGroup
            // 
            this.txtMsgTHreeGroup.AnimateReadOnly = false;
            this.txtMsgTHreeGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMsgTHreeGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMsgTHreeGroup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMsgTHreeGroup.Depth = 0;
            this.txtMsgTHreeGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMsgTHreeGroup.HideSelection = true;
            this.txtMsgTHreeGroup.Hint = "* Your third message";
            this.txtMsgTHreeGroup.Location = new System.Drawing.Point(7, 10);
            this.txtMsgTHreeGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsgTHreeGroup.MaxLength = 32767;
            this.txtMsgTHreeGroup.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMsgTHreeGroup.Name = "txtMsgTHreeGroup";
            this.txtMsgTHreeGroup.PasswordChar = '\0';
            this.txtMsgTHreeGroup.ReadOnly = false;
            this.txtMsgTHreeGroup.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMsgTHreeGroup.SelectedText = "";
            this.txtMsgTHreeGroup.SelectionLength = 0;
            this.txtMsgTHreeGroup.SelectionStart = 0;
            this.txtMsgTHreeGroup.ShortcutsEnabled = true;
            this.txtMsgTHreeGroup.Size = new System.Drawing.Size(592, 557);
            this.txtMsgTHreeGroup.TabIndex = 2;
            this.txtMsgTHreeGroup.TabStop = false;
            this.txtMsgTHreeGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMsgTHreeGroup.UseSystemPasswordChar = false;
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.Color.White;
            this.tabPage11.Controls.Add(this.panel17);
            this.tabPage11.Controls.Add(this.txtMsgFourGroup);
            this.tabPage11.ImageKey = "icons8_speech_24px.png";
            this.tabPage11.Location = new System.Drawing.Point(4, 25);
            this.tabPage11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(7, 10, 3, 2);
            this.tabPage11.Size = new System.Drawing.Size(1084, 569);
            this.tabPage11.TabIndex = 5;
            this.tabPage11.Text = "Message 4";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.panel75);
            this.panel17.Controls.Add(this.groupBox9);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(599, 10);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(5, 0, 0, 25);
            this.panel17.Size = new System.Drawing.Size(473, 557);
            this.panel17.TabIndex = 56;
            // 
            // panel75
            // 
            this.panel75.Controls.Add(this.panel76);
            this.panel75.Controls.Add(this.button120);
            this.panel75.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel75.Location = new System.Drawing.Point(5, 0);
            this.panel75.Name = "panel75";
            this.panel75.Size = new System.Drawing.Size(468, 85);
            this.panel75.TabIndex = 52;
            // 
            // panel76
            // 
            this.panel76.Controls.Add(this.button12);
            this.panel76.Controls.Add(this.button11);
            this.panel76.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel76.Location = new System.Drawing.Point(0, 0);
            this.panel76.Name = "panel76";
            this.panel76.Size = new System.Drawing.Size(468, 39);
            this.panel76.TabIndex = 5;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button12.Dock = System.Windows.Forms.DockStyle.Left;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(0, 0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(229, 39);
            this.button12.TabIndex = 41;
            this.button12.Text = "UPLOAD EXCEL";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.btnUploadExcelGroup_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button11.Dock = System.Windows.Forms.DockStyle.Right;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(237, 0);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(231, 39);
            this.button11.TabIndex = 44;
            this.button11.Text = "Load Saved Groups";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button35_Click);
            // 
            // button120
            // 
            this.button120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button120.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button120.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button120.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button120.ForeColor = System.Drawing.Color.White;
            this.button120.Location = new System.Drawing.Point(0, 45);
            this.button120.Name = "button120";
            this.button120.Size = new System.Drawing.Size(468, 40);
            this.button120.TabIndex = 42;
            this.button120.Text = "Download Sample Excel";
            this.button120.UseVisualStyleBackColor = false;
            this.button120.Click += new System.EventHandler(this.btnGroupDownloadExcel_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dataGridView9);
            this.groupBox9.Controls.Add(this.panel77);
            this.groupBox9.Controls.Add(this.button24);
            this.groupBox9.Controls.Add(this.materialButton7);
            this.groupBox9.Controls.Add(this.panel78);
            this.groupBox9.Controls.Add(this.groupBox17);
            this.groupBox9.Controls.Add(this.panel80);
            this.groupBox9.Controls.Add(this.button35);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox9.Location = new System.Drawing.Point(5, 111);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(7, 10, 7, 2);
            this.groupBox9.Size = new System.Drawing.Size(468, 421);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Attachments";
            this.controlsResolution.Add(this.groupBox9);
            // 
            // dataGridView9
            // 
            this.dataGridView9.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView9.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.AttachWithMainMessage8});
            this.dataGridView9.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView9.Location = new System.Drawing.Point(7, 71);
            this.dataGridView9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView9.MultiSelect = false;
            this.dataGridView9.Name = "dataGridView9";
            this.dataGridView9.RowHeadersWidth = 51;
            this.dataGridView9.RowTemplate.Height = 24;
            this.dataGridView9.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView9.Size = new System.Drawing.Size(454, 160);
            this.dataGridView9.TabIndex = 63;
            this.dataGridView9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView9_MouseClick);
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "File";
            this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 280;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Caption";
            this.dataGridViewTextBoxColumn14.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 125;
            // 
            // AttachWithMainMessage8
            // 
            this.AttachWithMainMessage8.FillWeight = 250F;
            this.AttachWithMainMessage8.HeaderText = "Attach With Main Message";
            this.AttachWithMainMessage8.MinimumWidth = 6;
            this.AttachWithMainMessage8.Name = "AttachWithMainMessage8";
            this.AttachWithMainMessage8.ReadOnly = true;
            this.AttachWithMainMessage8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AttachWithMainMessage8.Width = 125;
            // 
            // panel77
            // 
            this.panel77.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel77.Location = new System.Drawing.Point(7, 61);
            this.panel77.Name = "panel77";
            this.panel77.Size = new System.Drawing.Size(454, 10);
            this.panel77.TabIndex = 62;
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button24.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button24.ForeColor = System.Drawing.Color.White;
            this.button24.Location = new System.Drawing.Point(7, 240);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(454, 36);
            this.button24.TabIndex = 57;
            this.button24.Text = "Add Keymarker";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.keyMarkersToolStripMenuItem_Click);
            // 
            // materialButton7
            // 
            this.materialButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton7.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton7.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton7.ForeColor = System.Drawing.Color.White;
            this.materialButton7.Location = new System.Drawing.Point(7, 25);
            this.materialButton7.Name = "materialButton7";
            this.materialButton7.Size = new System.Drawing.Size(454, 36);
            this.materialButton7.TabIndex = 56;
            this.materialButton7.Text = "Add File";
            this.materialButton7.UseVisualStyleBackColor = false;
            this.materialButton7.Click += new System.EventHandler(this.materialButton7_Click);
            // 
            // panel78
            // 
            this.panel78.Controls.Add(this.button33);
            this.panel78.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel78.Location = new System.Drawing.Point(7, 276);
            this.panel78.Name = "panel78";
            this.panel78.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel78.Size = new System.Drawing.Size(454, 44);
            this.panel78.TabIndex = 54;
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.Color.White;
            this.button33.Dock = System.Windows.Forms.DockStyle.Right;
            this.button33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button33.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button33.Location = new System.Drawing.Point(417, 10);
            this.button33.Name = "button33";
            this.button33.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.button33.Size = new System.Drawing.Size(37, 34);
            this.button33.TabIndex = 68;
            this.button33.Text = "?";
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.panel79);
            this.groupBox17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox17.Location = new System.Drawing.Point(7, 320);
            this.groupBox17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox17.Size = new System.Drawing.Size(454, 53);
            this.groupBox17.TabIndex = 53;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Buttons";
            // 
            // panel79
            // 
            this.panel79.AutoScroll = true;
            this.panel79.Controls.Add(this.webBrowser9);
            this.panel79.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel79.Location = new System.Drawing.Point(3, 17);
            this.panel79.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel79.Name = "panel79";
            this.panel79.Size = new System.Drawing.Size(448, 34);
            this.panel79.TabIndex = 0;
            // 
            // webBrowser9
            // 
            this.webBrowser9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser9.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser9.Location = new System.Drawing.Point(0, 0);
            this.webBrowser9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser9.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser9.Name = "webBrowser9";
            this.webBrowser9.Size = new System.Drawing.Size(448, 34);
            this.webBrowser9.TabIndex = 2;
            this.webBrowser9.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser81_DocumentCompleted);
            // 
            // panel80
            // 
            this.panel80.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel80.Location = new System.Drawing.Point(7, 373);
            this.panel80.Name = "panel80";
            this.panel80.Size = new System.Drawing.Size(454, 10);
            this.panel80.TabIndex = 52;
            // 
            // button35
            // 
            this.button35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button35.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button35.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button35.ForeColor = System.Drawing.Color.White;
            this.button35.Location = new System.Drawing.Point(7, 383);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(454, 36);
            this.button35.TabIndex = 49;
            this.button35.Text = "Add Button";
            this.button35.UseVisualStyleBackColor = false;
            this.button35.Click += new System.EventHandler(this.button24_Click);
            // 
            // txtMsgFourGroup
            // 
            this.txtMsgFourGroup.AnimateReadOnly = false;
            this.txtMsgFourGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMsgFourGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMsgFourGroup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMsgFourGroup.Depth = 0;
            this.txtMsgFourGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMsgFourGroup.HideSelection = true;
            this.txtMsgFourGroup.Hint = "* Your fourth message";
            this.txtMsgFourGroup.Location = new System.Drawing.Point(7, 10);
            this.txtMsgFourGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsgFourGroup.MaxLength = 32767;
            this.txtMsgFourGroup.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMsgFourGroup.Name = "txtMsgFourGroup";
            this.txtMsgFourGroup.PasswordChar = '\0';
            this.txtMsgFourGroup.ReadOnly = false;
            this.txtMsgFourGroup.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMsgFourGroup.SelectedText = "";
            this.txtMsgFourGroup.SelectionLength = 0;
            this.txtMsgFourGroup.SelectionStart = 0;
            this.txtMsgFourGroup.ShortcutsEnabled = true;
            this.txtMsgFourGroup.Size = new System.Drawing.Size(592, 557);
            this.txtMsgFourGroup.TabIndex = 2;
            this.txtMsgFourGroup.TabStop = false;
            this.txtMsgFourGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMsgFourGroup.UseSystemPasswordChar = false;
            // 
            // tabPage12
            // 
            this.tabPage12.BackColor = System.Drawing.Color.White;
            this.tabPage12.Controls.Add(this.panel18);
            this.tabPage12.Controls.Add(this.txtMsgFiveGroup);
            this.tabPage12.ImageKey = "icons8_speech_24px.png";
            this.tabPage12.Location = new System.Drawing.Point(4, 25);
            this.tabPage12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(7, 10, 3, 2);
            this.tabPage12.Size = new System.Drawing.Size(1084, 569);
            this.tabPage12.TabIndex = 6;
            this.tabPage12.Text = "Message 5";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.panel81);
            this.panel18.Controls.Add(this.groupBox10);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(599, 10);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(5, 0, 0, 25);
            this.panel18.Size = new System.Drawing.Size(473, 557);
            this.panel18.TabIndex = 56;
            // 
            // panel81
            // 
            this.panel81.Controls.Add(this.panel82);
            this.panel81.Controls.Add(this.button140);
            this.panel81.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel81.Location = new System.Drawing.Point(5, 0);
            this.panel81.Name = "panel81";
            this.panel81.Size = new System.Drawing.Size(468, 85);
            this.panel81.TabIndex = 52;
            // 
            // panel82
            // 
            this.panel82.Controls.Add(this.button14);
            this.panel82.Controls.Add(this.button13);
            this.panel82.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel82.Location = new System.Drawing.Point(0, 0);
            this.panel82.Name = "panel82";
            this.panel82.Size = new System.Drawing.Size(468, 39);
            this.panel82.TabIndex = 5;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button14.Dock = System.Windows.Forms.DockStyle.Left;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(0, 0);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(229, 39);
            this.button14.TabIndex = 41;
            this.button14.Text = "UPLOAD EXCEL";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.btnUploadExcelGroup_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button13.Dock = System.Windows.Forms.DockStyle.Right;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(237, 0);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(231, 39);
            this.button13.TabIndex = 44;
            this.button13.Text = "Load Saved Groups";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button36_Click);
            // 
            // button140
            // 
            this.button140.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button140.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button140.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button140.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button140.ForeColor = System.Drawing.Color.White;
            this.button140.Location = new System.Drawing.Point(0, 45);
            this.button140.Name = "button140";
            this.button140.Size = new System.Drawing.Size(468, 40);
            this.button140.TabIndex = 42;
            this.button140.Text = "Download Sample Excel";
            this.button140.UseVisualStyleBackColor = false;
            this.button140.Click += new System.EventHandler(this.btnGroupDownloadExcel_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.dataGridView10);
            this.groupBox10.Controls.Add(this.panel83);
            this.groupBox10.Controls.Add(this.button26);
            this.groupBox10.Controls.Add(this.materialButton8);
            this.groupBox10.Controls.Add(this.panel84);
            this.groupBox10.Controls.Add(this.groupBox18);
            this.groupBox10.Controls.Add(this.panel86);
            this.groupBox10.Controls.Add(this.button59);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox10.Location = new System.Drawing.Point(5, 111);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(7, 10, 7, 2);
            this.groupBox10.Size = new System.Drawing.Size(468, 421);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Attachments";
            this.controlsResolution.Add(this.groupBox10);
            // 
            // dataGridView10
            // 
            this.dataGridView10.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.AttachWithMainMessage9});
            this.dataGridView10.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView10.Location = new System.Drawing.Point(7, 71);
            this.dataGridView10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView10.MultiSelect = false;
            this.dataGridView10.Name = "dataGridView10";
            this.dataGridView10.RowHeadersWidth = 51;
            this.dataGridView10.RowTemplate.Height = 24;
            this.dataGridView10.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView10.Size = new System.Drawing.Size(454, 160);
            this.dataGridView10.TabIndex = 63;
            this.dataGridView10.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView10_MouseClick);
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "File";
            this.dataGridViewTextBoxColumn15.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 280;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Caption";
            this.dataGridViewTextBoxColumn16.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 125;
            // 
            // AttachWithMainMessage9
            // 
            this.AttachWithMainMessage9.FillWeight = 250F;
            this.AttachWithMainMessage9.HeaderText = "Attach With Main Message";
            this.AttachWithMainMessage9.MinimumWidth = 6;
            this.AttachWithMainMessage9.Name = "AttachWithMainMessage9";
            this.AttachWithMainMessage9.ReadOnly = true;
            this.AttachWithMainMessage9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AttachWithMainMessage9.Width = 125;
            // 
            // panel83
            // 
            this.panel83.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel83.Location = new System.Drawing.Point(7, 61);
            this.panel83.Name = "panel83";
            this.panel83.Size = new System.Drawing.Size(454, 10);
            this.panel83.TabIndex = 62;
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button26.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button26.ForeColor = System.Drawing.Color.White;
            this.button26.Location = new System.Drawing.Point(7, 240);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(454, 36);
            this.button26.TabIndex = 57;
            this.button26.Text = "Add Keymarker";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.keyMarkersToolStripMenuItem_Click);
            // 
            // materialButton8
            // 
            this.materialButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton8.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton8.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton8.ForeColor = System.Drawing.Color.White;
            this.materialButton8.Location = new System.Drawing.Point(7, 25);
            this.materialButton8.Name = "materialButton8";
            this.materialButton8.Size = new System.Drawing.Size(454, 36);
            this.materialButton8.TabIndex = 56;
            this.materialButton8.Text = "Add File";
            this.materialButton8.UseVisualStyleBackColor = false;
            this.materialButton8.Click += new System.EventHandler(this.materialButton8_Click);
            // 
            // panel84
            // 
            this.panel84.Controls.Add(this.button34);
            this.panel84.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel84.Location = new System.Drawing.Point(7, 276);
            this.panel84.Name = "panel84";
            this.panel84.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel84.Size = new System.Drawing.Size(454, 44);
            this.panel84.TabIndex = 54;
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.White;
            this.button34.Dock = System.Windows.Forms.DockStyle.Right;
            this.button34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button34.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button34.Location = new System.Drawing.Point(417, 10);
            this.button34.Name = "button34";
            this.button34.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.button34.Size = new System.Drawing.Size(37, 34);
            this.button34.TabIndex = 68;
            this.button34.Text = "?";
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.button34_Click_1);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.panel85);
            this.groupBox18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox18.Location = new System.Drawing.Point(7, 320);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox18.Size = new System.Drawing.Size(454, 53);
            this.groupBox18.TabIndex = 53;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Buttons";
            // 
            // panel85
            // 
            this.panel85.AutoScroll = true;
            this.panel85.Controls.Add(this.webBrowser10);
            this.panel85.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel85.Location = new System.Drawing.Point(3, 17);
            this.panel85.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel85.Name = "panel85";
            this.panel85.Size = new System.Drawing.Size(448, 34);
            this.panel85.TabIndex = 0;
            // 
            // webBrowser10
            // 
            this.webBrowser10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser10.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser10.Location = new System.Drawing.Point(0, 0);
            this.webBrowser10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser10.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser10.Name = "webBrowser10";
            this.webBrowser10.Size = new System.Drawing.Size(448, 34);
            this.webBrowser10.TabIndex = 2;
            // 
            // panel86
            // 
            this.panel86.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel86.Location = new System.Drawing.Point(7, 373);
            this.panel86.Name = "panel86";
            this.panel86.Size = new System.Drawing.Size(454, 10);
            this.panel86.TabIndex = 52;
            // 
            // button59
            // 
            this.button59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button59.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button59.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button59.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button59.ForeColor = System.Drawing.Color.White;
            this.button59.Location = new System.Drawing.Point(7, 383);
            this.button59.Name = "button59";
            this.button59.Size = new System.Drawing.Size(454, 36);
            this.button59.TabIndex = 49;
            this.button59.Text = "Add Button";
            this.button59.UseVisualStyleBackColor = false;
            this.button59.Click += new System.EventHandler(this.button26_Click);
            // 
            // txtMsgFiveGroup
            // 
            this.txtMsgFiveGroup.AnimateReadOnly = false;
            this.txtMsgFiveGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMsgFiveGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMsgFiveGroup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMsgFiveGroup.Depth = 0;
            this.txtMsgFiveGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMsgFiveGroup.HideSelection = true;
            this.txtMsgFiveGroup.Hint = "* Your fifth message";
            this.txtMsgFiveGroup.Location = new System.Drawing.Point(7, 10);
            this.txtMsgFiveGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsgFiveGroup.MaxLength = 32767;
            this.txtMsgFiveGroup.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMsgFiveGroup.Name = "txtMsgFiveGroup";
            this.txtMsgFiveGroup.PasswordChar = '\0';
            this.txtMsgFiveGroup.ReadOnly = false;
            this.txtMsgFiveGroup.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMsgFiveGroup.SelectedText = "";
            this.txtMsgFiveGroup.SelectionLength = 0;
            this.txtMsgFiveGroup.SelectionStart = 0;
            this.txtMsgFiveGroup.ShortcutsEnabled = true;
            this.txtMsgFiveGroup.Size = new System.Drawing.Size(592, 557);
            this.txtMsgFiveGroup.TabIndex = 2;
            this.txtMsgFiveGroup.TabStop = false;
            this.txtMsgFiveGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMsgFiveGroup.UseSystemPasswordChar = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(42, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(83, 86);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Yu Gothic", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(657, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(264, 55);
            this.label22.TabIndex = 3;
            this.label22.Text = "WHATS-BIZ";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Webdings", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(1220, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(387, 45);
            this.label19.TabIndex = 4;
            this.label19.Text = "WHATS-BIZ";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.panel10.Controls.Add(this.label19);
            this.panel10.Controls.Add(this.label22);
            this.panel10.Controls.Add(this.pictureBox5);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 41);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1628, 96);
            this.panel10.TabIndex = 48;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.panel88);
            this.materialCard1.Controls.Add(this.panel87);
            this.materialCard1.Controls.Add(this.panel2);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 52);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.materialCard1.Size = new System.Drawing.Size(480, 139);
            this.materialCard1.TabIndex = 44;
            // 
            // panel88
            // 
            this.panel88.AutoSize = true;
            this.panel88.Controls.Add(this.label7);
            this.panel88.Controls.Add(this.txtdelayAfterEveryMessageTo);
            this.panel88.Controls.Add(this.label9);
            this.panel88.Controls.Add(this.txtdelayAfterEveryMessageFrom);
            this.panel88.Controls.Add(this.label10);
            this.panel88.Controls.Add(this.materialCheckbox2);
            this.panel88.Location = new System.Drawing.Point(10, 91);
            this.panel88.Name = "panel88";
            this.panel88.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.panel88.Size = new System.Drawing.Size(426, 31);
            this.panel88.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(165, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 18);
            this.label7.TabIndex = 53;
            this.label7.Text = "seconds before every msg";
            // 
            // txtdelayAfterEveryMessageTo
            // 
            this.txtdelayAfterEveryMessageTo.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtdelayAfterEveryMessageTo.Location = new System.Drawing.Point(121, 7);
            this.txtdelayAfterEveryMessageTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdelayAfterEveryMessageTo.Name = "txtdelayAfterEveryMessageTo";
            this.txtdelayAfterEveryMessageTo.Size = new System.Drawing.Size(44, 22);
            this.txtdelayAfterEveryMessageTo.TabIndex = 52;
            this.txtdelayAfterEveryMessageTo.Text = "8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(100, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 18);
            this.label9.TabIndex = 51;
            this.label9.Text = "to";
            // 
            // txtdelayAfterEveryMessageFrom
            // 
            this.txtdelayAfterEveryMessageFrom.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtdelayAfterEveryMessageFrom.Location = new System.Drawing.Point(56, 7);
            this.txtdelayAfterEveryMessageFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdelayAfterEveryMessageFrom.Name = "txtdelayAfterEveryMessageFrom";
            this.txtdelayAfterEveryMessageFrom.Size = new System.Drawing.Size(44, 22);
            this.txtdelayAfterEveryMessageFrom.TabIndex = 50;
            this.txtdelayAfterEveryMessageFrom.Text = "4";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(18, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 18);
            this.label10.TabIndex = 49;
            this.label10.Text = "Wait";
            // 
            // materialCheckbox2
            // 
            this.materialCheckbox2.AutoSize = true;
            this.materialCheckbox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialCheckbox2.Location = new System.Drawing.Point(0, 7);
            this.materialCheckbox2.Name = "materialCheckbox2";
            this.materialCheckbox2.Size = new System.Drawing.Size(18, 24);
            this.materialCheckbox2.TabIndex = 48;
            this.materialCheckbox2.UseVisualStyleBackColor = true;
            // 
            // panel87
            // 
            this.panel87.AutoSize = true;
            this.panel87.Controls.Add(this.label12);
            this.panel87.Controls.Add(this.label6);
            this.panel87.Controls.Add(this.label13);
            this.panel87.Controls.Add(this.txtdelayAfterMessagesTo);
            this.panel87.Controls.Add(this.label15);
            this.panel87.Controls.Add(this.txtdelayAfterMessagesFrom);
            this.panel87.Controls.Add(this.label16);
            this.panel87.Controls.Add(this.materialCheckbox1);
            this.panel87.Location = new System.Drawing.Point(10, 49);
            this.panel87.Name = "panel87";
            this.panel87.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.panel87.Size = new System.Drawing.Size(426, 31);
            this.panel87.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(326, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 18);
            this.label12.TabIndex = 54;
            this.label12.Text = "msgs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(302, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 18);
            this.label6.TabIndex = 53;
            this.label6.Text = "10";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(165, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 18);
            this.label13.TabIndex = 52;
            this.label13.Text = "seconds after every";
            // 
            // txtdelayAfterMessagesTo
            // 
            this.txtdelayAfterMessagesTo.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtdelayAfterMessagesTo.Location = new System.Drawing.Point(121, 7);
            this.txtdelayAfterMessagesTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdelayAfterMessagesTo.Name = "txtdelayAfterMessagesTo";
            this.txtdelayAfterMessagesTo.Size = new System.Drawing.Size(44, 22);
            this.txtdelayAfterMessagesTo.TabIndex = 51;
            this.txtdelayAfterMessagesTo.Text = "20";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(100, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 18);
            this.label15.TabIndex = 50;
            this.label15.Text = "to";
            // 
            // txtdelayAfterMessagesFrom
            // 
            this.txtdelayAfterMessagesFrom.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtdelayAfterMessagesFrom.Location = new System.Drawing.Point(56, 7);
            this.txtdelayAfterMessagesFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdelayAfterMessagesFrom.Name = "txtdelayAfterMessagesFrom";
            this.txtdelayAfterMessagesFrom.Size = new System.Drawing.Size(44, 22);
            this.txtdelayAfterMessagesFrom.TabIndex = 49;
            this.txtdelayAfterMessagesFrom.Text = "10";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(18, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 18);
            this.label16.TabIndex = 48;
            this.label16.Text = "Wait";
            // 
            // materialCheckbox1
            // 
            this.materialCheckbox1.AutoSize = true;
            this.materialCheckbox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialCheckbox1.Location = new System.Drawing.Point(0, 7);
            this.materialCheckbox1.Name = "materialCheckbox1";
            this.materialCheckbox1.Size = new System.Drawing.Size(18, 24);
            this.materialCheckbox1.TabIndex = 47;
            this.materialCheckbox1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 32);
            this.panel2.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 9F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(16, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Delay Settings";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(3, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(480, 49);
            this.btnStart.TabIndex = 45;
            this.btnStart.Text = "START INDIVIDUAL CAMPAIGN";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton1.ForeColor = System.Drawing.Color.White;
            this.materialButton1.Location = new System.Drawing.Point(0, 0);
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.Size = new System.Drawing.Size(486, 49);
            this.materialButton1.TabIndex = 46;
            this.materialButton1.Text = "CLEAR";
            this.materialButton1.UseVisualStyleBackColor = false;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel26);
            this.panel1.Controls.Add(this.tabControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 137);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(18, 22, 0, 0);
            this.panel1.Size = new System.Drawing.Size(1628, 620);
            this.panel1.TabIndex = 50;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.panel24);
            this.panel26.Controls.Add(this.panel25);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel26.Location = new System.Drawing.Point(1110, 22);
            this.panel26.Name = "panel26";
            this.panel26.Padding = new System.Windows.Forms.Padding(10, 23, 10, 3);
            this.panel26.Size = new System.Drawing.Size(506, 598);
            this.panel26.TabIndex = 51;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.btnStart);
            this.panel24.Controls.Add(this.materialCard1);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(10, 23);
            this.panel24.Name = "panel24";
            this.panel24.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel24.Size = new System.Drawing.Size(486, 194);
            this.panel24.TabIndex = 50;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.materialButton1);
            this.panel25.Controls.Add(this.panel13);
            this.panel25.Controls.Add(this.gridTargets);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel25.Location = new System.Drawing.Point(10, 283);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(486, 312);
            this.panel25.TabIndex = 45;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.panel13.Controls.Add(this.button2);
            this.panel13.Controls.Add(this.label18);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 55);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panel13.Size = new System.Drawing.Size(486, 32);
            this.panel13.TabIndex = 49;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(435, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 26);
            this.button2.TabIndex = 65;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Tai Le", 9F);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(16, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 19);
            this.label18.TabIndex = 4;
            this.label18.Text = "Edit File";
            // 
            // gridTargets
            // 
            this.gridTargets.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTargets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridTargets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTargets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Column2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTargets.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridTargets.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridTargets.Location = new System.Drawing.Point(0, 87);
            this.gridTargets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridTargets.Name = "gridTargets";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTargets.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridTargets.RowHeadersWidth = 51;
            this.gridTargets.RowTemplate.Height = 24;
            this.gridTargets.Size = new System.Drawing.Size(486, 225);
            this.gridTargets.TabIndex = 47;
            this.gridTargets.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridTargets_RowsAdded);
            this.gridTargets.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridTargets_RowsRemoved);
            this.gridTargets.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridTargets_MouseClick);
            // 
            // Number
            // 
            this.Number.HeaderText = "Number";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.Width = 250;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 250;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl2.Location = new System.Drawing.Point(18, 22);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1092, 598);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 43;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.panel31);
            this.tabPage1.Controls.Add(this.txtMsgOne);
            this.tabPage1.ImageKey = "icons8_speech_24px.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(7, 10, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1084, 569);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Message 1";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.panel27);
            this.panel31.Controls.Add(this.groupBox1);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel31.Location = new System.Drawing.Point(599, 10);
            this.panel31.Name = "panel31";
            this.panel31.Padding = new System.Windows.Forms.Padding(5, 0, 0, 25);
            this.panel31.Size = new System.Drawing.Size(473, 557);
            this.panel31.TabIndex = 52;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.panel28);
            this.panel27.Controls.Add(this.button15);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel27.Location = new System.Drawing.Point(5, 0);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(468, 85);
            this.panel27.TabIndex = 52;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.button18);
            this.panel28.Controls.Add(this.button37);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel28.Location = new System.Drawing.Point(0, 0);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(468, 39);
            this.panel28.TabIndex = 5;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button18.Dock = System.Windows.Forms.DockStyle.Left;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.ForeColor = System.Drawing.Color.White;
            this.button18.Location = new System.Drawing.Point(0, 0);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(229, 39);
            this.button18.TabIndex = 41;
            this.button18.Text = "UPLOAD EXCEL";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.btnUploadExcel_Click);
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button37.Dock = System.Windows.Forms.DockStyle.Right;
            this.button37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button37.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button37.ForeColor = System.Drawing.Color.White;
            this.button37.Location = new System.Drawing.Point(237, 0);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(231, 39);
            this.button37.TabIndex = 44;
            this.button37.Text = "Load Saved Contacts";
            this.button37.UseVisualStyleBackColor = false;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(0, 45);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(468, 40);
            this.button15.TabIndex = 42;
            this.button15.Text = "Download Sample Excel";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.btnDownloadSample_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.panel32);
            this.groupBox1.Controls.Add(this.button16);
            this.groupBox1.Controls.Add(this.btnAddFileOne);
            this.groupBox1.Controls.Add(this.panel30);
            this.groupBox1.Controls.Add(this.groupBox11);
            this.groupBox1.Controls.Add(this.panel29);
            this.groupBox1.Controls.Add(this.materialButton19);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(5, 111);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7, 10, 7, 2);
            this.groupBox1.Size = new System.Drawing.Size(468, 421);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attachments";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            this.controlsResolution.Add(this.groupBox1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.AttachWithMainMessage});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(7, 71);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(454, 160);
            this.dataGridView1.TabIndex = 63;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "File";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 280;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Caption";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // AttachWithMainMessage
            // 
            this.AttachWithMainMessage.FillWeight = 250F;
            this.AttachWithMainMessage.HeaderText = "Attach With Main Message";
            this.AttachWithMainMessage.MinimumWidth = 6;
            this.AttachWithMainMessage.Name = "AttachWithMainMessage";
            this.AttachWithMainMessage.ReadOnly = true;
            this.AttachWithMainMessage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AttachWithMainMessage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AttachWithMainMessage.Width = 125;
            // 
            // panel32
            // 
            this.panel32.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel32.Location = new System.Drawing.Point(7, 61);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(454, 10);
            this.panel32.TabIndex = 62;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.ForeColor = System.Drawing.Color.White;
            this.button16.Location = new System.Drawing.Point(7, 240);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(454, 36);
            this.button16.TabIndex = 57;
            this.button16.Text = "Add Keymarker";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.keyMarkersToolStripMenuItem_Click);
            // 
            // btnAddFileOne
            // 
            this.btnAddFileOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.btnAddFileOne.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddFileOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFileOne.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFileOne.ForeColor = System.Drawing.Color.White;
            this.btnAddFileOne.Location = new System.Drawing.Point(7, 25);
            this.btnAddFileOne.Name = "btnAddFileOne";
            this.btnAddFileOne.Size = new System.Drawing.Size(454, 36);
            this.btnAddFileOne.TabIndex = 56;
            this.btnAddFileOne.Text = "Add File";
            this.btnAddFileOne.UseVisualStyleBackColor = false;
            this.btnAddFileOne.Click += new System.EventHandler(this.btnAddFileOne_Click_1);
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.button4);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel30.Location = new System.Drawing.Point(7, 276);
            this.panel30.Name = "panel30";
            this.panel30.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel30.Size = new System.Drawing.Size(454, 44);
            this.panel30.TabIndex = 54;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Dock = System.Windows.Forms.DockStyle.Right;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button4.Location = new System.Drawing.Point(417, 10);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(37, 34);
            this.button4.TabIndex = 66;
            this.button4.Text = "?";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.panel3);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox11.Location = new System.Drawing.Point(7, 320);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Size = new System.Drawing.Size(454, 53);
            this.groupBox11.TabIndex = 53;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Buttons";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.webBrowser1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 17);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(448, 34);
            this.panel3.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(448, 34);
            this.webBrowser1.TabIndex = 2;
            // 
            // panel29
            // 
            this.panel29.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel29.Location = new System.Drawing.Point(7, 373);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(454, 10);
            this.panel29.TabIndex = 52;
            // 
            // materialButton19
            // 
            this.materialButton19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton19.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialButton19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton19.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton19.ForeColor = System.Drawing.Color.White;
            this.materialButton19.Location = new System.Drawing.Point(7, 383);
            this.materialButton19.Name = "materialButton19";
            this.materialButton19.Size = new System.Drawing.Size(454, 36);
            this.materialButton19.TabIndex = 49;
            this.materialButton19.Text = "Add Button";
            this.materialButton19.UseVisualStyleBackColor = false;
            this.materialButton19.Click += new System.EventHandler(this.materialButton19_Click);
            // 
            // txtMsgOne
            // 
            this.txtMsgOne.AnimateReadOnly = false;
            this.txtMsgOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMsgOne.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMsgOne.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMsgOne.Depth = 0;
            this.txtMsgOne.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMsgOne.HideSelection = true;
            this.txtMsgOne.Hint = "* Your first message";
            this.txtMsgOne.Location = new System.Drawing.Point(7, 10);
            this.txtMsgOne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsgOne.MaxLength = 32767;
            this.txtMsgOne.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMsgOne.Name = "txtMsgOne";
            this.txtMsgOne.PasswordChar = '\0';
            this.txtMsgOne.ReadOnly = false;
            this.txtMsgOne.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMsgOne.SelectedText = "";
            this.txtMsgOne.SelectionLength = 0;
            this.txtMsgOne.SelectionStart = 0;
            this.txtMsgOne.ShortcutsEnabled = true;
            this.txtMsgOne.Size = new System.Drawing.Size(592, 557);
            this.txtMsgOne.TabIndex = 0;
            this.txtMsgOne.TabStop = false;
            this.txtMsgOne.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMsgOne.UseSystemPasswordChar = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.txtMsgTwo);
            this.tabPage2.ImageKey = "icons8_speech_24px.png";
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(7, 10, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1084, 569);
            this.tabPage2.TabIndex = 7;
            this.tabPage2.Text = "Message 2";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel33);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(599, 10);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 25);
            this.panel4.Size = new System.Drawing.Size(473, 557);
            this.panel4.TabIndex = 53;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.panel34);
            this.panel33.Controls.Add(this.button380);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel33.Location = new System.Drawing.Point(5, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(468, 85);
            this.panel33.TabIndex = 52;
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.button38);
            this.panel34.Controls.Add(this.button21);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel34.Location = new System.Drawing.Point(0, 0);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(468, 39);
            this.panel34.TabIndex = 5;
            // 
            // button38
            // 
            this.button38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button38.Dock = System.Windows.Forms.DockStyle.Left;
            this.button38.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button38.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button38.ForeColor = System.Drawing.Color.White;
            this.button38.Location = new System.Drawing.Point(0, 0);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(229, 39);
            this.button38.TabIndex = 41;
            this.button38.Text = "UPLOAD EXCEL";
            this.button38.UseVisualStyleBackColor = false;
            this.button38.Click += new System.EventHandler(this.btnUploadExcel_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button21.Dock = System.Windows.Forms.DockStyle.Right;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.ForeColor = System.Drawing.Color.White;
            this.button21.Location = new System.Drawing.Point(237, 0);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(231, 39);
            this.button21.TabIndex = 44;
            this.button21.Text = "Load Saved Contacts";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button40_Click);
            // 
            // button380
            // 
            this.button380.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button380.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button380.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button380.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button380.ForeColor = System.Drawing.Color.White;
            this.button380.Location = new System.Drawing.Point(0, 45);
            this.button380.Name = "button380";
            this.button380.Size = new System.Drawing.Size(468, 40);
            this.button380.TabIndex = 42;
            this.button380.Text = "Download Sample Excel";
            this.button380.UseVisualStyleBackColor = false;
            this.button380.Click += new System.EventHandler(this.btnDownloadSample_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.panel35);
            this.groupBox2.Controls.Add(this.button40);
            this.groupBox2.Controls.Add(this.btnAddFileTwo);
            this.groupBox2.Controls.Add(this.panel36);
            this.groupBox2.Controls.Add(this.groupBox12);
            this.groupBox2.Controls.Add(this.panel38);
            this.groupBox2.Controls.Add(this.materialButton20);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(5, 111);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(7, 10, 7, 2);
            this.groupBox2.Size = new System.Drawing.Size(468, 421);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attachments";
            this.controlsResolution.Add(this.groupBox2);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.AttachWithMainMessage1});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView2.Location = new System.Drawing.Point(7, 71);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(454, 160);
            this.dataGridView2.TabIndex = 63;
            this.dataGridView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "File";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 280;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Caption";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // AttachWithMainMessage1
            // 
            this.AttachWithMainMessage1.FillWeight = 250F;
            this.AttachWithMainMessage1.HeaderText = "Attach With Main Message";
            this.AttachWithMainMessage1.MinimumWidth = 6;
            this.AttachWithMainMessage1.Name = "AttachWithMainMessage1";
            this.AttachWithMainMessage1.ReadOnly = true;
            this.AttachWithMainMessage1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AttachWithMainMessage1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AttachWithMainMessage1.Width = 125;
            // 
            // panel35
            // 
            this.panel35.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel35.Location = new System.Drawing.Point(7, 61);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(454, 10);
            this.panel35.TabIndex = 62;
            // 
            // button40
            // 
            this.button40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button40.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button40.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button40.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button40.ForeColor = System.Drawing.Color.White;
            this.button40.Location = new System.Drawing.Point(7, 240);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(454, 36);
            this.button40.TabIndex = 57;
            this.button40.Text = "Add Keymarker";
            this.button40.UseVisualStyleBackColor = false;
            this.button40.Click += new System.EventHandler(this.keyMarkersToolStripMenuItem_Click);
            // 
            // btnAddFileTwo
            // 
            this.btnAddFileTwo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.btnAddFileTwo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddFileTwo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFileTwo.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFileTwo.ForeColor = System.Drawing.Color.White;
            this.btnAddFileTwo.Location = new System.Drawing.Point(7, 25);
            this.btnAddFileTwo.Name = "btnAddFileTwo";
            this.btnAddFileTwo.Size = new System.Drawing.Size(454, 36);
            this.btnAddFileTwo.TabIndex = 56;
            this.btnAddFileTwo.Text = "Add File";
            this.btnAddFileTwo.UseVisualStyleBackColor = false;
            this.btnAddFileTwo.Click += new System.EventHandler(this.btnAddFileTwo_Click);
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.button5);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel36.Location = new System.Drawing.Point(7, 276);
            this.panel36.Name = "panel36";
            this.panel36.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel36.Size = new System.Drawing.Size(454, 44);
            this.panel36.TabIndex = 54;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Dock = System.Windows.Forms.DockStyle.Right;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button5.Location = new System.Drawing.Point(417, 10);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(37, 34);
            this.button5.TabIndex = 67;
            this.button5.Text = "?";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.panel37);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox12.Location = new System.Drawing.Point(7, 320);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox12.Size = new System.Drawing.Size(454, 53);
            this.groupBox12.TabIndex = 53;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Buttons";
            // 
            // panel37
            // 
            this.panel37.AutoScroll = true;
            this.panel37.Controls.Add(this.webBrowser2);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel37.Location = new System.Drawing.Point(3, 17);
            this.panel37.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(448, 34);
            this.panel37.TabIndex = 0;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser2.Location = new System.Drawing.Point(0, 0);
            this.webBrowser2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(448, 34);
            this.webBrowser2.TabIndex = 2;
            // 
            // panel38
            // 
            this.panel38.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel38.Location = new System.Drawing.Point(7, 373);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(454, 10);
            this.panel38.TabIndex = 52;
            // 
            // materialButton20
            // 
            this.materialButton20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton20.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialButton20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton20.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton20.ForeColor = System.Drawing.Color.White;
            this.materialButton20.Location = new System.Drawing.Point(7, 383);
            this.materialButton20.Name = "materialButton20";
            this.materialButton20.Size = new System.Drawing.Size(454, 36);
            this.materialButton20.TabIndex = 49;
            this.materialButton20.Text = "Add Button";
            this.materialButton20.UseVisualStyleBackColor = false;
            this.materialButton20.Click += new System.EventHandler(this.materialButton20_Click);
            // 
            // txtMsgTwo
            // 
            this.txtMsgTwo.AnimateReadOnly = false;
            this.txtMsgTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMsgTwo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMsgTwo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMsgTwo.Depth = 0;
            this.txtMsgTwo.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMsgTwo.HideSelection = true;
            this.txtMsgTwo.Hint = "* Your first message";
            this.txtMsgTwo.Location = new System.Drawing.Point(7, 10);
            this.txtMsgTwo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsgTwo.MaxLength = 32767;
            this.txtMsgTwo.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMsgTwo.Name = "txtMsgTwo";
            this.txtMsgTwo.PasswordChar = '\0';
            this.txtMsgTwo.ReadOnly = false;
            this.txtMsgTwo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMsgTwo.SelectedText = "";
            this.txtMsgTwo.SelectionLength = 0;
            this.txtMsgTwo.SelectionStart = 0;
            this.txtMsgTwo.ShortcutsEnabled = true;
            this.txtMsgTwo.Size = new System.Drawing.Size(592, 557);
            this.txtMsgTwo.TabIndex = 0;
            this.txtMsgTwo.TabStop = false;
            this.txtMsgTwo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMsgTwo.UseSystemPasswordChar = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Controls.Add(this.txtMsgThree);
            this.tabPage3.ImageKey = "icons8_speech_24px.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(7, 10, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1084, 569);
            this.tabPage3.TabIndex = 8;
            this.tabPage3.Text = "Message 3";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel39);
            this.panel5.Controls.Add(this.groupBox3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(599, 10);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 25);
            this.panel5.Size = new System.Drawing.Size(473, 557);
            this.panel5.TabIndex = 54;
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.panel40);
            this.panel39.Controls.Add(this.button270);
            this.panel39.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel39.Location = new System.Drawing.Point(5, 0);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(468, 85);
            this.panel39.TabIndex = 52;
            // 
            // panel40
            // 
            this.panel40.Controls.Add(this.button27);
            this.panel40.Controls.Add(this.button25);
            this.panel40.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel40.Location = new System.Drawing.Point(0, 0);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(468, 39);
            this.panel40.TabIndex = 5;
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button27.Dock = System.Windows.Forms.DockStyle.Left;
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button27.ForeColor = System.Drawing.Color.White;
            this.button27.Location = new System.Drawing.Point(0, 0);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(229, 39);
            this.button27.TabIndex = 41;
            this.button27.Text = "UPLOAD EXCEL";
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.btnUploadExcel_Click);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button25.Dock = System.Windows.Forms.DockStyle.Right;
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25.ForeColor = System.Drawing.Color.White;
            this.button25.Location = new System.Drawing.Point(237, 0);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(231, 39);
            this.button25.TabIndex = 44;
            this.button25.Text = "Load Saved Contacts";
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.button42_Click);
            // 
            // button270
            // 
            this.button270.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button270.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button270.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button270.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button270.ForeColor = System.Drawing.Color.White;
            this.button270.Location = new System.Drawing.Point(0, 45);
            this.button270.Name = "button270";
            this.button270.Size = new System.Drawing.Size(468, 40);
            this.button270.TabIndex = 42;
            this.button270.Text = "Download Sample Excel";
            this.button270.UseVisualStyleBackColor = false;
            this.button270.Click += new System.EventHandler(this.btnDownloadSample_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView3);
            this.groupBox3.Controls.Add(this.panel41);
            this.groupBox3.Controls.Add(this.button42);
            this.groupBox3.Controls.Add(this.btnAddFileThree);
            this.groupBox3.Controls.Add(this.panel42);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.panel44);
            this.groupBox3.Controls.Add(this.materialButton21);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(5, 111);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(7, 10, 7, 2);
            this.groupBox3.Size = new System.Drawing.Size(468, 421);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attachments";
            this.controlsResolution.Add(this.groupBox3);
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.AttachWithMainMessage2});
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView3.Location = new System.Drawing.Point(7, 71);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(454, 160);
            this.dataGridView3.TabIndex = 63;
            this.dataGridView3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView3_MouseClick);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "File";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 280;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Caption";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // AttachWithMainMessage2
            // 
            this.AttachWithMainMessage2.FillWeight = 250F;
            this.AttachWithMainMessage2.HeaderText = "Attach With Main Message";
            this.AttachWithMainMessage2.MinimumWidth = 6;
            this.AttachWithMainMessage2.Name = "AttachWithMainMessage2";
            this.AttachWithMainMessage2.ReadOnly = true;
            this.AttachWithMainMessage2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AttachWithMainMessage2.Width = 125;
            // 
            // panel41
            // 
            this.panel41.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel41.Location = new System.Drawing.Point(7, 61);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(454, 10);
            this.panel41.TabIndex = 62;
            // 
            // button42
            // 
            this.button42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button42.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button42.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button42.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button42.ForeColor = System.Drawing.Color.White;
            this.button42.Location = new System.Drawing.Point(7, 240);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(454, 36);
            this.button42.TabIndex = 57;
            this.button42.Text = "Add Keymarker";
            this.button42.UseVisualStyleBackColor = false;
            this.button42.Click += new System.EventHandler(this.keyMarkersToolStripMenuItem_Click);
            // 
            // btnAddFileThree
            // 
            this.btnAddFileThree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.btnAddFileThree.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddFileThree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFileThree.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFileThree.ForeColor = System.Drawing.Color.White;
            this.btnAddFileThree.Location = new System.Drawing.Point(7, 25);
            this.btnAddFileThree.Name = "btnAddFileThree";
            this.btnAddFileThree.Size = new System.Drawing.Size(454, 36);
            this.btnAddFileThree.TabIndex = 56;
            this.btnAddFileThree.Text = "Add File";
            this.btnAddFileThree.UseVisualStyleBackColor = false;
            this.btnAddFileThree.Click += new System.EventHandler(this.btnAddFileThree_Click);
            // 
            // panel42
            // 
            this.panel42.Controls.Add(this.button6);
            this.panel42.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel42.Location = new System.Drawing.Point(7, 276);
            this.panel42.Name = "panel42";
            this.panel42.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel42.Size = new System.Drawing.Size(454, 44);
            this.panel42.TabIndex = 54;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Dock = System.Windows.Forms.DockStyle.Right;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button6.Location = new System.Drawing.Point(417, 10);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(37, 34);
            this.button6.TabIndex = 67;
            this.button6.Text = "?";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel43);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(7, 320);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(454, 53);
            this.groupBox4.TabIndex = 53;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Buttons";
            // 
            // panel43
            // 
            this.panel43.AutoScroll = true;
            this.panel43.Controls.Add(this.webBrowser3);
            this.panel43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel43.Location = new System.Drawing.Point(3, 17);
            this.panel43.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(448, 34);
            this.panel43.TabIndex = 0;
            // 
            // webBrowser3
            // 
            this.webBrowser3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser3.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser3.Location = new System.Drawing.Point(0, 0);
            this.webBrowser3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser3.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser3.Name = "webBrowser3";
            this.webBrowser3.Size = new System.Drawing.Size(448, 34);
            this.webBrowser3.TabIndex = 2;
            // 
            // panel44
            // 
            this.panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel44.Location = new System.Drawing.Point(7, 373);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(454, 10);
            this.panel44.TabIndex = 52;
            // 
            // materialButton21
            // 
            this.materialButton21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialButton21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton21.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton21.ForeColor = System.Drawing.Color.White;
            this.materialButton21.Location = new System.Drawing.Point(7, 383);
            this.materialButton21.Name = "materialButton21";
            this.materialButton21.Size = new System.Drawing.Size(454, 36);
            this.materialButton21.TabIndex = 49;
            this.materialButton21.Text = "Add Button";
            this.materialButton21.UseVisualStyleBackColor = false;
            this.materialButton21.Click += new System.EventHandler(this.materialButton21_Click);
            // 
            // txtMsgThree
            // 
            this.txtMsgThree.AnimateReadOnly = false;
            this.txtMsgThree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMsgThree.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMsgThree.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMsgThree.Depth = 0;
            this.txtMsgThree.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMsgThree.HideSelection = true;
            this.txtMsgThree.Hint = "* Your first message";
            this.txtMsgThree.Location = new System.Drawing.Point(7, 10);
            this.txtMsgThree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsgThree.MaxLength = 32767;
            this.txtMsgThree.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMsgThree.Name = "txtMsgThree";
            this.txtMsgThree.PasswordChar = '\0';
            this.txtMsgThree.ReadOnly = false;
            this.txtMsgThree.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMsgThree.SelectedText = "";
            this.txtMsgThree.SelectionLength = 0;
            this.txtMsgThree.SelectionStart = 0;
            this.txtMsgThree.ShortcutsEnabled = true;
            this.txtMsgThree.Size = new System.Drawing.Size(592, 557);
            this.txtMsgThree.TabIndex = 0;
            this.txtMsgThree.TabStop = false;
            this.txtMsgThree.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMsgThree.UseSystemPasswordChar = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.panel7);
            this.tabPage4.Controls.Add(this.txtMsgFour);
            this.tabPage4.ImageKey = "icons8_speech_24px.png";
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(7, 10, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(1084, 569);
            this.tabPage4.TabIndex = 9;
            this.tabPage4.Text = "Message 4";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel45);
            this.panel7.Controls.Add(this.groupBox5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(599, 10);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 25);
            this.panel7.Size = new System.Drawing.Size(473, 557);
            this.panel7.TabIndex = 54;
            // 
            // panel45
            // 
            this.panel45.Controls.Add(this.panel46);
            this.panel45.Controls.Add(this.button320);
            this.panel45.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel45.Location = new System.Drawing.Point(5, 0);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(468, 85);
            this.panel45.TabIndex = 52;
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.button32);
            this.panel46.Controls.Add(this.button30);
            this.panel46.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel46.Location = new System.Drawing.Point(0, 0);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(468, 39);
            this.panel46.TabIndex = 5;
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button32.Dock = System.Windows.Forms.DockStyle.Left;
            this.button32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button32.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.ForeColor = System.Drawing.Color.White;
            this.button32.Location = new System.Drawing.Point(0, 0);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(229, 39);
            this.button32.TabIndex = 41;
            this.button32.Text = "UPLOAD EXCEL";
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.btnUploadExcel_Click);
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button30.Dock = System.Windows.Forms.DockStyle.Right;
            this.button30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button30.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button30.ForeColor = System.Drawing.Color.White;
            this.button30.Location = new System.Drawing.Point(237, 0);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(231, 39);
            this.button30.TabIndex = 44;
            this.button30.Text = "Load Saved Contacts";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.button43_Click);
            // 
            // button320
            // 
            this.button320.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button320.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button320.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button320.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button320.ForeColor = System.Drawing.Color.White;
            this.button320.Location = new System.Drawing.Point(0, 45);
            this.button320.Name = "button320";
            this.button320.Size = new System.Drawing.Size(468, 40);
            this.button320.TabIndex = 42;
            this.button320.Text = "Download Sample Excel";
            this.button320.UseVisualStyleBackColor = false;
            this.button320.Click += new System.EventHandler(this.btnDownloadSample_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridView4);
            this.groupBox5.Controls.Add(this.panel47);
            this.groupBox5.Controls.Add(this.button43);
            this.groupBox5.Controls.Add(this.btnAddFileFour);
            this.groupBox5.Controls.Add(this.panel48);
            this.groupBox5.Controls.Add(this.groupBox13);
            this.groupBox5.Controls.Add(this.panel50);
            this.groupBox5.Controls.Add(this.materialButton22);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(5, 111);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(7, 10, 7, 2);
            this.groupBox5.Size = new System.Drawing.Size(468, 421);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Attachments";
            this.controlsResolution.Add(this.groupBox5);
            // 
            // dataGridView4
            // 
            this.dataGridView4.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.AttachWithMainMessage3});
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView4.Location = new System.Drawing.Point(7, 71);
            this.dataGridView4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView4.MultiSelect = false;
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersWidth = 51;
            this.dataGridView4.RowTemplate.Height = 24;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(454, 160);
            this.dataGridView4.TabIndex = 63;
            this.dataGridView4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView4_MouseClick);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "File";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 280;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Caption";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // AttachWithMainMessage3
            // 
            this.AttachWithMainMessage3.FillWeight = 250F;
            this.AttachWithMainMessage3.HeaderText = "Attach With Main Message";
            this.AttachWithMainMessage3.MinimumWidth = 6;
            this.AttachWithMainMessage3.Name = "AttachWithMainMessage3";
            this.AttachWithMainMessage3.ReadOnly = true;
            this.AttachWithMainMessage3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AttachWithMainMessage3.Width = 125;
            // 
            // panel47
            // 
            this.panel47.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel47.Location = new System.Drawing.Point(7, 61);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(454, 10);
            this.panel47.TabIndex = 62;
            // 
            // button43
            // 
            this.button43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button43.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button43.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button43.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button43.ForeColor = System.Drawing.Color.White;
            this.button43.Location = new System.Drawing.Point(7, 240);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(454, 36);
            this.button43.TabIndex = 57;
            this.button43.Text = "Add Keymarker";
            this.button43.UseVisualStyleBackColor = false;
            this.button43.Click += new System.EventHandler(this.keyMarkersToolStripMenuItem_Click);
            // 
            // btnAddFileFour
            // 
            this.btnAddFileFour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.btnAddFileFour.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddFileFour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFileFour.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFileFour.ForeColor = System.Drawing.Color.White;
            this.btnAddFileFour.Location = new System.Drawing.Point(7, 25);
            this.btnAddFileFour.Name = "btnAddFileFour";
            this.btnAddFileFour.Size = new System.Drawing.Size(454, 36);
            this.btnAddFileFour.TabIndex = 56;
            this.btnAddFileFour.Text = "Add File";
            this.btnAddFileFour.UseVisualStyleBackColor = false;
            this.btnAddFileFour.Click += new System.EventHandler(this.btnAddFileFour_Click);
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.button17);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel48.Location = new System.Drawing.Point(7, 276);
            this.panel48.Name = "panel48";
            this.panel48.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel48.Size = new System.Drawing.Size(454, 44);
            this.panel48.TabIndex = 54;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.White;
            this.button17.Dock = System.Windows.Forms.DockStyle.Right;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button17.Location = new System.Drawing.Point(417, 10);
            this.button17.Name = "button17";
            this.button17.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.button17.Size = new System.Drawing.Size(37, 34);
            this.button17.TabIndex = 67;
            this.button17.Text = "?";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click_1);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.panel49);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox13.Location = new System.Drawing.Point(7, 320);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Size = new System.Drawing.Size(454, 53);
            this.groupBox13.TabIndex = 53;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Buttons";
            // 
            // panel49
            // 
            this.panel49.AutoScroll = true;
            this.panel49.Controls.Add(this.webBrowser4);
            this.panel49.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel49.Location = new System.Drawing.Point(3, 17);
            this.panel49.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(448, 34);
            this.panel49.TabIndex = 0;
            // 
            // webBrowser4
            // 
            this.webBrowser4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser4.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser4.Location = new System.Drawing.Point(0, 0);
            this.webBrowser4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser4.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser4.Name = "webBrowser4";
            this.webBrowser4.Size = new System.Drawing.Size(448, 34);
            this.webBrowser4.TabIndex = 2;
            // 
            // panel50
            // 
            this.panel50.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel50.Location = new System.Drawing.Point(7, 373);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(454, 10);
            this.panel50.TabIndex = 52;
            // 
            // materialButton22
            // 
            this.materialButton22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton22.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialButton22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton22.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton22.ForeColor = System.Drawing.Color.White;
            this.materialButton22.Location = new System.Drawing.Point(7, 383);
            this.materialButton22.Name = "materialButton22";
            this.materialButton22.Size = new System.Drawing.Size(454, 36);
            this.materialButton22.TabIndex = 49;
            this.materialButton22.Text = "Add Button";
            this.materialButton22.UseVisualStyleBackColor = false;
            this.materialButton22.Click += new System.EventHandler(this.materialButton22_Click);
            // 
            // txtMsgFour
            // 
            this.txtMsgFour.AnimateReadOnly = false;
            this.txtMsgFour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMsgFour.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMsgFour.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMsgFour.Depth = 0;
            this.txtMsgFour.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMsgFour.HideSelection = true;
            this.txtMsgFour.Hint = "* Your first message";
            this.txtMsgFour.Location = new System.Drawing.Point(7, 10);
            this.txtMsgFour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsgFour.MaxLength = 32767;
            this.txtMsgFour.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMsgFour.Name = "txtMsgFour";
            this.txtMsgFour.PasswordChar = '\0';
            this.txtMsgFour.ReadOnly = false;
            this.txtMsgFour.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMsgFour.SelectedText = "";
            this.txtMsgFour.SelectionLength = 0;
            this.txtMsgFour.SelectionStart = 0;
            this.txtMsgFour.ShortcutsEnabled = true;
            this.txtMsgFour.Size = new System.Drawing.Size(592, 557);
            this.txtMsgFour.TabIndex = 0;
            this.txtMsgFour.TabStop = false;
            this.txtMsgFour.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMsgFour.UseSystemPasswordChar = false;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.White;
            this.tabPage5.Controls.Add(this.panel11);
            this.tabPage5.Controls.Add(this.txtMsgFive);
            this.tabPage5.ImageKey = "icons8_speech_24px.png";
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(7, 10, 3, 2);
            this.tabPage5.Size = new System.Drawing.Size(1084, 569);
            this.tabPage5.TabIndex = 10;
            this.tabPage5.Text = "Message 5";
            this.tabPage5.Click += new System.EventHandler(this.tabPage5_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel51);
            this.panel11.Controls.Add(this.groupBox14);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(599, 10);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(5, 0, 0, 25);
            this.panel11.Size = new System.Drawing.Size(473, 557);
            this.panel11.TabIndex = 54;
            // 
            // panel51
            // 
            this.panel51.Controls.Add(this.panel52);
            this.panel51.Controls.Add(this.button410);
            this.panel51.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel51.Location = new System.Drawing.Point(5, 0);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(468, 85);
            this.panel51.TabIndex = 52;
            // 
            // panel52
            // 
            this.panel52.Controls.Add(this.button41);
            this.panel52.Controls.Add(this.button39);
            this.panel52.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel52.Location = new System.Drawing.Point(0, 0);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(468, 39);
            this.panel52.TabIndex = 5;
            // 
            // button41
            // 
            this.button41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button41.Dock = System.Windows.Forms.DockStyle.Left;
            this.button41.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button41.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button41.ForeColor = System.Drawing.Color.White;
            this.button41.Location = new System.Drawing.Point(0, 0);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(229, 39);
            this.button41.TabIndex = 41;
            this.button41.Text = "UPLOAD EXCEL";
            this.button41.UseVisualStyleBackColor = false;
            this.button41.Click += new System.EventHandler(this.btnUploadExcel_Click);
            // 
            // button39
            // 
            this.button39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button39.Dock = System.Windows.Forms.DockStyle.Right;
            this.button39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button39.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button39.ForeColor = System.Drawing.Color.White;
            this.button39.Location = new System.Drawing.Point(237, 0);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(231, 39);
            this.button39.TabIndex = 44;
            this.button39.Text = "Load Saved Contacts";
            this.button39.UseVisualStyleBackColor = false;
            this.button39.Click += new System.EventHandler(this.button44_Click);
            // 
            // button410
            // 
            this.button410.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button410.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button410.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button410.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button410.ForeColor = System.Drawing.Color.White;
            this.button410.Location = new System.Drawing.Point(0, 45);
            this.button410.Name = "button410";
            this.button410.Size = new System.Drawing.Size(468, 40);
            this.button410.TabIndex = 42;
            this.button410.Text = "Download Sample Excel";
            this.button410.UseVisualStyleBackColor = false;
            this.button410.Click += new System.EventHandler(this.btnDownloadSample_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.dataGridView5);
            this.groupBox14.Controls.Add(this.panel53);
            this.groupBox14.Controls.Add(this.button44);
            this.groupBox14.Controls.Add(this.btnAddFileFive);
            this.groupBox14.Controls.Add(this.panel54);
            this.groupBox14.Controls.Add(this.groupBox15);
            this.groupBox14.Controls.Add(this.panel56);
            this.groupBox14.Controls.Add(this.materialButton23);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox14.Location = new System.Drawing.Point(5, 111);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(7, 10, 7, 2);
            this.groupBox14.Size = new System.Drawing.Size(468, 421);
            this.groupBox14.TabIndex = 1;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Attachments";
            this.controlsResolution.Add(this.groupBox14);
            // 
            // dataGridView5
            // 
            this.dataGridView5.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.AttachWithMainMessage4});
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView5.Location = new System.Drawing.Point(7, 71);
            this.dataGridView5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView5.MultiSelect = false;
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowHeadersWidth = 51;
            this.dataGridView5.RowTemplate.Height = 24;
            this.dataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView5.Size = new System.Drawing.Size(454, 160);
            this.dataGridView5.TabIndex = 63;
            this.dataGridView5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView5_MouseClick);
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "File";
            this.dataGridViewTextBoxColumn19.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 280;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "Caption";
            this.dataGridViewTextBoxColumn20.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Width = 125;
            // 
            // AttachWithMainMessage4
            // 
            this.AttachWithMainMessage4.FillWeight = 250F;
            this.AttachWithMainMessage4.HeaderText = "Attach With Main Message";
            this.AttachWithMainMessage4.MinimumWidth = 6;
            this.AttachWithMainMessage4.Name = "AttachWithMainMessage4";
            this.AttachWithMainMessage4.ReadOnly = true;
            this.AttachWithMainMessage4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AttachWithMainMessage4.Width = 125;
            // 
            // panel53
            // 
            this.panel53.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel53.Location = new System.Drawing.Point(7, 61);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(454, 10);
            this.panel53.TabIndex = 62;
            // 
            // button44
            // 
            this.button44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button44.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button44.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button44.ForeColor = System.Drawing.Color.White;
            this.button44.Location = new System.Drawing.Point(7, 240);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(454, 36);
            this.button44.TabIndex = 57;
            this.button44.Text = "Add Keymarker";
            this.button44.UseVisualStyleBackColor = false;
            this.button44.Click += new System.EventHandler(this.keyMarkersToolStripMenuItem_Click);
            // 
            // btnAddFileFive
            // 
            this.btnAddFileFive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.btnAddFileFive.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddFileFive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFileFive.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFileFive.ForeColor = System.Drawing.Color.White;
            this.btnAddFileFive.Location = new System.Drawing.Point(7, 25);
            this.btnAddFileFive.Name = "btnAddFileFive";
            this.btnAddFileFive.Size = new System.Drawing.Size(454, 36);
            this.btnAddFileFive.TabIndex = 56;
            this.btnAddFileFive.Text = "Add File";
            this.btnAddFileFive.UseVisualStyleBackColor = false;
            this.btnAddFileFive.Click += new System.EventHandler(this.btnAddFileFive_Click);
            // 
            // panel54
            // 
            this.panel54.Controls.Add(this.button19);
            this.panel54.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel54.Location = new System.Drawing.Point(7, 276);
            this.panel54.Name = "panel54";
            this.panel54.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel54.Size = new System.Drawing.Size(454, 44);
            this.panel54.TabIndex = 54;
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.White;
            this.button19.Dock = System.Windows.Forms.DockStyle.Right;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button19.Location = new System.Drawing.Point(417, 10);
            this.button19.Name = "button19";
            this.button19.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.button19.Size = new System.Drawing.Size(37, 34);
            this.button19.TabIndex = 67;
            this.button19.Text = "?";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.panel55);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox15.Location = new System.Drawing.Point(7, 320);
            this.groupBox15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox15.Size = new System.Drawing.Size(454, 53);
            this.groupBox15.TabIndex = 53;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Buttons";
            // 
            // panel55
            // 
            this.panel55.AutoScroll = true;
            this.panel55.Controls.Add(this.webBrowser5);
            this.panel55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel55.Location = new System.Drawing.Point(3, 17);
            this.panel55.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(448, 34);
            this.panel55.TabIndex = 0;
            // 
            // webBrowser5
            // 
            this.webBrowser5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser5.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser5.Location = new System.Drawing.Point(0, 0);
            this.webBrowser5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser5.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser5.Name = "webBrowser5";
            this.webBrowser5.Size = new System.Drawing.Size(448, 34);
            this.webBrowser5.TabIndex = 2;
            // 
            // panel56
            // 
            this.panel56.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel56.Location = new System.Drawing.Point(7, 373);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(454, 10);
            this.panel56.TabIndex = 52;
            // 
            // materialButton23
            // 
            this.materialButton23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton23.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialButton23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton23.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton23.ForeColor = System.Drawing.Color.White;
            this.materialButton23.Location = new System.Drawing.Point(7, 383);
            this.materialButton23.Name = "materialButton23";
            this.materialButton23.Size = new System.Drawing.Size(454, 36);
            this.materialButton23.TabIndex = 49;
            this.materialButton23.Text = "Add Button";
            this.materialButton23.UseVisualStyleBackColor = false;
            this.materialButton23.Click += new System.EventHandler(this.materialButton23_Click);
            // 
            // txtMsgFive
            // 
            this.txtMsgFive.AnimateReadOnly = false;
            this.txtMsgFive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMsgFive.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMsgFive.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMsgFive.Depth = 0;
            this.txtMsgFive.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMsgFive.HideSelection = true;
            this.txtMsgFive.Hint = "* Your first message";
            this.txtMsgFive.Location = new System.Drawing.Point(7, 10);
            this.txtMsgFive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsgFive.MaxLength = 32767;
            this.txtMsgFive.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMsgFive.Name = "txtMsgFive";
            this.txtMsgFive.PasswordChar = '\0';
            this.txtMsgFive.ReadOnly = false;
            this.txtMsgFive.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMsgFive.SelectedText = "";
            this.txtMsgFive.SelectionLength = 0;
            this.txtMsgFive.SelectionStart = 0;
            this.txtMsgFive.ShortcutsEnabled = true;
            this.txtMsgFive.Size = new System.Drawing.Size(592, 557);
            this.txtMsgFive.TabIndex = 0;
            this.txtMsgFive.TabStop = false;
            this.txtMsgFive.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMsgFive.UseSystemPasswordChar = false;
            // 
            // addCountryCodeToolStripMenuItem
            // 
            this.addCountryCodeToolStripMenuItem.Name = "addCountryCodeToolStripMenuItem";
            this.addCountryCodeToolStripMenuItem.Size = new System.Drawing.Size(214, 24);
            this.addCountryCodeToolStripMenuItem.Text = "Add Country Code";
            this.addCountryCodeToolStripMenuItem.Click += new System.EventHandler(this.addCountryCodeToolStripMenuItem_Click);
            // 
            // importNumbersToolStripMenuItem
            // 
            this.importNumbersToolStripMenuItem.Name = "importNumbersToolStripMenuItem";
            this.importNumbersToolStripMenuItem.Size = new System.Drawing.Size(214, 24);
            this.importNumbersToolStripMenuItem.Text = "Copy Paste Numbers";
            this.importNumbersToolStripMenuItem.Click += new System.EventHandler(this.importNumbersToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCountryCodeToolStripMenuItem,
            this.importNumbersToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(215, 52);
            // 
            // keyMarkersToolStripMenuItem
            // 
            this.keyMarkersToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.keyMarkersToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.keyMarkersToolStripMenuItem.Enabled = false;
            this.keyMarkersToolStripMenuItem.Name = "keyMarkersToolStripMenuItem";
            this.keyMarkersToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.keyMarkersToolStripMenuItem.Text = "Add KeyMarkers";
            this.keyMarkersToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.keyMarkersToolStripMenuItem.Click += new System.EventHandler(this.keyMarkersToolStripMenuItem_Click);
            // 
            // randomNumberToolStripMenuItem
            // 
            this.randomNumberToolStripMenuItem.Enabled = false;
            this.randomNumberToolStripMenuItem.Name = "randomNumberToolStripMenuItem";
            this.randomNumberToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.randomNumberToolStripMenuItem.Text = "Random Number";
            this.randomNumberToolStripMenuItem.Click += new System.EventHandler(this.randomNumberToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Enabled = false;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyMarkersToolStripMenuItem,
            this.randomNumberToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 52);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // WaSenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1628, 757);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkDarkMode);
            this.Controls.Add(this.lblSection);
            this.DrawerShowIconsWhenHidden = true;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "WaSenderForm";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WhatsBiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaSenderForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WaSenderForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WaSenderForm_KeyPress);
            this.contextMenuStrip3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.materialCard4.ResumeLayout(false);
            this.materialCard4.PerformLayout();
            this.panel90.ResumeLayout(false);
            this.panel90.PerformLayout();
            this.panel89.ResumeLayout(false);
            this.panel89.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTargetsGroup)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.panel57.ResumeLayout(false);
            this.panel58.ResumeLayout(false);
            this.panel59.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.panel61.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.panel62.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel64.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            this.panel66.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.panel67.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel69.ResumeLayout(false);
            this.panel70.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).EndInit();
            this.panel72.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.panel73.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel75.ResumeLayout(false);
            this.panel76.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).EndInit();
            this.panel78.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.panel79.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel81.ResumeLayout(false);
            this.panel82.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView10)).EndInit();
            this.panel84.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.panel85.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.panel88.ResumeLayout(false);
            this.panel88.PerformLayout();
            this.panel87.ResumeLayout(false);
            this.panel87.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTargets)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel30.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel36.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.panel37.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel39.ResumeLayout(false);
            this.panel40.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panel42.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel43.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel45.ResumeLayout(false);
            this.panel46.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.panel48.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.panel49.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel51.ResumeLayout(false);
            this.panel52.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.panel54.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.panel55.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.CheckBox chkDarkMode;
        private System.Windows.Forms.SaveFileDialog savesampleExceldialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageListMainTabs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem addCaptionToolStripMenuItem;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage7;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtMsgOneGroup;
        private System.Windows.Forms.TabPage tabPage9;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtMsgTwoGroup1;
        private System.Windows.Forms.TabPage tabPage10;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtMsgTHreeGroup;
        private System.Windows.Forms.TabPage tabPage11;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtMsgFourGroup;
        private System.Windows.Forms.TabPage tabPage12;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtMsgFiveGroup;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel10;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.CheckBox materialCheckbox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox materialCheckbox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button materialButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button materialButton19;
        private System.Windows.Forms.Button button18;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtMsgOne;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtMsgTwo;
        private System.Windows.Forms.TabPage tabPage3;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtMsgThree;
        private System.Windows.Forms.TabPage tabPage4;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtMsgFour;
        private System.Windows.Forms.TabPage tabPage5;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtMsgFive;
        private System.Windows.Forms.DataGridView gridTargets;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button materialButton2;
        private System.Windows.Forms.DataGridView gridTargetsGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panel19;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private System.Windows.Forms.CheckBox materialCheckbox3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label materialLabel17;
        private System.Windows.Forms.CheckBox materialCheckbox4;
        private System.Windows.Forms.Button btnStartGroup;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.Button btnAddFileOne;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.Panel panel34;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button380;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel35;
        private System.Windows.Forms.Button button40;
        private System.Windows.Forms.Button btnAddFileTwo;
        private System.Windows.Forms.Panel panel36;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Panel panel37;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Panel panel38;
        private System.Windows.Forms.Button materialButton20;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel39;
        private System.Windows.Forms.Panel panel40;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button270;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Panel panel41;
        private System.Windows.Forms.Button button42;
        private System.Windows.Forms.Button btnAddFileThree;
        private System.Windows.Forms.Panel panel42;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel43;
        private System.Windows.Forms.WebBrowser webBrowser3;
        private System.Windows.Forms.Panel panel44;
        private System.Windows.Forms.Button materialButton21;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel45;
        private System.Windows.Forms.Panel panel46;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button320;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Panel panel47;
        private System.Windows.Forms.Button button43;
        private System.Windows.Forms.Button btnAddFileFour;
        private System.Windows.Forms.Panel panel48;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Panel panel49;
        private System.Windows.Forms.WebBrowser webBrowser4;
        private System.Windows.Forms.Panel panel50;
        private System.Windows.Forms.Button materialButton22;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel51;
        private System.Windows.Forms.Panel panel52;
        private System.Windows.Forms.Button button41;
        private System.Windows.Forms.Button button39;
        private System.Windows.Forms.Button button410;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.Panel panel53;
        private System.Windows.Forms.Button button44;
        private System.Windows.Forms.Button btnAddFileFive;
        private System.Windows.Forms.Panel panel54;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Panel panel55;
        private System.Windows.Forms.WebBrowser webBrowser5;
        private System.Windows.Forms.Panel panel56;
        private System.Windows.Forms.Button materialButton23;
        private System.Windows.Forms.Panel panel57;
        private System.Windows.Forms.Panel panel58;
        private System.Windows.Forms.Panel panel59;
        private System.Windows.Forms.Button btnUploadExcelGroup;
        private System.Windows.Forms.Button button54;
        private System.Windows.Forms.Button btnDownloadSampleGroup;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel64;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridView7;
        private System.Windows.Forms.Panel panel65;
        private System.Windows.Forms.Button button80;
        private System.Windows.Forms.Button materialButton5;
        private System.Windows.Forms.Panel panel66;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Panel panel67;
        private System.Windows.Forms.WebBrowser webBrowser7;
        private System.Windows.Forms.Panel panel68;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel69;
        private System.Windows.Forms.Panel panel70;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button100;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dataGridView8;
        private System.Windows.Forms.Panel panel71;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button materialButton6;
        private System.Windows.Forms.Panel panel72;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Panel panel73;
        private System.Windows.Forms.WebBrowser webBrowser8;
        private System.Windows.Forms.Panel panel74;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel75;
        private System.Windows.Forms.Panel panel76;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button120;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.DataGridView dataGridView9;
        private System.Windows.Forms.Panel panel77;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button materialButton7;
        private System.Windows.Forms.Panel panel78;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Panel panel79;
        private System.Windows.Forms.WebBrowser webBrowser9;
        private System.Windows.Forms.Panel panel80;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel81;
        private System.Windows.Forms.Panel panel82;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button140;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.DataGridView dataGridView10;
        private System.Windows.Forms.Panel panel83;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button materialButton8;
        private System.Windows.Forms.Panel panel84;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Panel panel85;
        private System.Windows.Forms.WebBrowser webBrowser10;
        private System.Windows.Forms.Panel panel86;
        private System.Windows.Forms.Button button59;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Panel panel87;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private CustomInputs.Int32TextBox txtdelayAfterMessagesTo;
        private System.Windows.Forms.Label label15;
        private CustomInputs.Int32TextBox txtdelayAfterMessagesFrom;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel88;
        private CustomInputs.Int32TextBox txtdelayAfterEveryMessageTo;
        private System.Windows.Forms.Label label9;
        private CustomInputs.Int32TextBox txtdelayAfterEveryMessageFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel90;
        private System.Windows.Forms.Panel panel89;
        private System.Windows.Forms.Label materialLabel13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label materialLabel14;
        private CustomInputs.Int32TextBox txtdelayAfterMessagesToGroup;
        private System.Windows.Forms.Label materialLabel15;
        private CustomInputs.Int32TextBox txtdelayAfterMessagesFromGroup;
        private System.Windows.Forms.Label materialLabel16;
        private System.Windows.Forms.Label materialLabel10;
        private CustomInputs.Int32TextBox txtdelayAfterEveryMessageToGroup;
        private System.Windows.Forms.Label materialLabel11;
        private CustomInputs.Int32TextBox txtdelayAfterEveryMessageFromGroup;
        private System.Windows.Forms.Label materialLabel12;
        private System.Windows.Forms.ToolStripMenuItem addCountryCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importNumbersToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem keyMarkersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomNumberToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AttachWithMainMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AttachWithMainMessage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AttachWithMainMessage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AttachWithMainMessage3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AttachWithMainMessage4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AttachWithMainMessage6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AttachWithMainMessage7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AttachWithMainMessage8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AttachWithMainMessage9;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AttachWithMainMessage5;
        private System.Windows.Forms.Panel panel60;
        private System.Windows.Forms.Button button56;
        private System.Windows.Forms.Button materialButton4;
        private System.Windows.Forms.Panel panel61;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Panel panel62;
        private System.Windows.Forms.WebBrowser webBrowser6;
        private System.Windows.Forms.Panel panel63;
        private System.Windows.Forms.Button button58;
    }
}
