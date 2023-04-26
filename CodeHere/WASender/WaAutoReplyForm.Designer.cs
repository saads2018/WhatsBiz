using WaAutoReplyBot.Models;

namespace WaAutoReplyBot
{
    partial class WaAutoReplyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaAutoReplyForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.lblInitStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.gridRulesets = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label100 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.materialCard3 = new MaterialSkin.Controls.MaterialCard();
            this.materialButton1 = new System.Windows.Forms.Button();
            this.materialButton4 = new System.Windows.Forms.Button();
            this.materialButton2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExportRule = new System.Windows.Forms.ToolStripMenuItem();
            this.savesampleExceldialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRulesets)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.materialCard3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(73)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.pictureBox12);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 41);
            this.panel1.TabIndex = 23;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(25, 5);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(27, 26);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 5;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Click += new System.EventHandler(this.pictureBox12_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(749, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 35;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.panel10.Controls.Add(this.button2);
            this.panel10.Controls.Add(this.label22);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 41);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(830, 40);
            this.panel10.TabIndex = 61;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(171, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 26);
            this.button2.TabIndex = 96;
            this.button2.Text = "Import Rule";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.VisibleChanged += new System.EventHandler(this.button2_VisibleChanged);
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(298, 7);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(198, 26);
            this.label22.TabIndex = 3;
            this.label22.Text = "Auto Responder Bot";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInitStatus
            // 
            this.lblInitStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInitStatus.AutoSize = true;
            this.lblInitStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitStatus.Location = new System.Drawing.Point(483, 726);
            this.lblInitStatus.Name = "lblInitStatus";
            this.lblInitStatus.Size = new System.Drawing.Size(102, 16);
            this.lblInitStatus.TabIndex = 11;
            this.lblInitStatus.Text = "Not Initialised";
            this.lblInitStatus.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(420, 726);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Status";
            this.label7.Visible = false;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtLog.Location = new System.Drawing.Point(415, 48);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(395, 233);
            this.txtLog.TabIndex = 13;
            // 
            // gridRulesets
            // 
            this.gridRulesets.AllowUserToAddRows = false;
            this.gridRulesets.AllowUserToDeleteRows = false;
            this.gridRulesets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRulesets.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridRulesets.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridRulesets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRulesets.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridRulesets.Location = new System.Drawing.Point(12, 47);
            this.gridRulesets.MultiSelect = false;
            this.gridRulesets.Name = "gridRulesets";
            this.gridRulesets.RowHeadersWidth = 51;
            this.gridRulesets.RowTemplate.Height = 24;
            this.gridRulesets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRulesets.ShowEditingIcon = false;
            this.gridRulesets.Size = new System.Drawing.Size(397, 234);
            this.gridRulesets.TabIndex = 16;
            this.gridRulesets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRulesets_CellClick);
            this.gridRulesets.DoubleClick += new System.EventHandler(this.gridRulesets_DoubleClick);
            this.gridRulesets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridRulesets_KeyDown);
            this.gridRulesets.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridRulesets_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.panel2.Controls.Add(this.label100);
            this.panel2.Location = new System.Drawing.Point(415, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 38);
            this.panel2.TabIndex = 78;
            // 
            // label100
            // 
            this.label100.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label100.AutoSize = true;
            this.label100.BackColor = System.Drawing.Color.Transparent;
            this.label100.Font = new System.Drawing.Font("Microsoft Tai Le", 9F);
            this.label100.ForeColor = System.Drawing.Color.White;
            this.label100.Location = new System.Drawing.Point(173, 11);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(40, 19);
            this.label100.TabIndex = 3;
            this.label100.Text = "Logs";
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(397, 38);
            this.panel3.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(174, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rules";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialCard3
            // 
            this.materialCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard3.Controls.Add(this.materialButton1);
            this.materialCard3.Controls.Add(this.materialButton4);
            this.materialCard3.Controls.Add(this.materialButton2);
            this.materialCard3.Controls.Add(this.panel3);
            this.materialCard3.Controls.Add(this.panel2);
            this.materialCard3.Controls.Add(this.gridRulesets);
            this.materialCard3.Controls.Add(this.txtLog);
            this.materialCard3.Depth = 0;
            this.materialCard3.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard3.Location = new System.Drawing.Point(0, 81);
            this.materialCard3.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard3.Name = "materialCard3";
            this.materialCard3.Padding = new System.Windows.Forms.Padding(14, 14, 14, 3);
            this.materialCard3.Size = new System.Drawing.Size(830, 388);
            this.materialCard3.TabIndex = 62;
            this.materialCard3.Paint += new System.Windows.Forms.PaintEventHandler(this.materialCard3_Paint);
            // 
            // materialButton1
            // 
            this.materialButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton1.ForeColor = System.Drawing.Color.White;
            this.materialButton1.Location = new System.Drawing.Point(12, 340);
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.Size = new System.Drawing.Size(397, 36);
            this.materialButton1.TabIndex = 95;
            this.materialButton1.Text = "Start";
            this.materialButton1.UseVisualStyleBackColor = false;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // materialButton4
            // 
            this.materialButton4.BackColor = System.Drawing.Color.White;
            this.materialButton4.Enabled = false;
            this.materialButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton4.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton4.Location = new System.Drawing.Point(415, 340);
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.Size = new System.Drawing.Size(395, 36);
            this.materialButton4.TabIndex = 92;
            this.materialButton4.Text = "Stop";
            this.materialButton4.UseVisualStyleBackColor = false;
            this.materialButton4.Click += new System.EventHandler(this.materialButton4_Click);
            // 
            // materialButton2
            // 
            this.materialButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(171)))), ((int)(((byte)(134)))));
            this.materialButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton2.ForeColor = System.Drawing.Color.White;
            this.materialButton2.Location = new System.Drawing.Point(12, 287);
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.Size = new System.Drawing.Size(798, 36);
            this.materialButton2.TabIndex = 80;
            this.materialButton2.Text = "Add Rule";
            this.materialButton2.UseVisualStyleBackColor = false;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Enabled = false;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportRule});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 28);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ExportRule
            // 
            this.ExportRule.Enabled = false;
            this.ExportRule.Name = "ExportRule";
            this.ExportRule.Size = new System.Drawing.Size(154, 24);
            this.ExportRule.Text = "Export Rule";
            this.ExportRule.Click += new System.EventHandler(this.ExportRule_Click);
            // 
            // WaAutoReplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 467);
            this.Controls.Add(this.materialCard3);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblInitStatus);
            this.Controls.Add(this.label7);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WaAutoReplyForm";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WhatsApp Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaAutoReplyForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WaAutoReplyForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.WaAutoReplyForm_VisibleChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRulesets)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.materialCard3.ResumeLayout(false);
            this.materialCard3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblInitStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.DataGridView gridRulesets;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private System.Windows.Forms.Button materialButton2;
        private System.Windows.Forms.Button materialButton4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button materialButton1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExportRule;
        private System.Windows.Forms.SaveFileDialog savesampleExceldialog;
    }
}

