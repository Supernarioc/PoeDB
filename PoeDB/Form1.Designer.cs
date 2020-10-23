using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PoeDB
{
    partial class PoeDbForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PoeDbForm));
            this.poeLable = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.monBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.settingBtn = new System.Windows.Forms.Button();
            this.homePanel = new System.Windows.Forms.Panel();
            this.tabDoc = new System.Windows.Forms.WebBrowser();
            this.headPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabLink = new System.Windows.Forms.Label();
            this.tabText = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusBox = new System.Windows.Forms.ListBox();
            this.trade = new System.Windows.Forms.ComboBox();
            this.mainHeadPanel = new System.Windows.Forms.Panel();
            this.map = new System.Windows.Forms.ComboBox();
            this.quest = new System.Windows.Forms.ComboBox();
            this.item = new System.Windows.Forms.ComboBox();
            this.mod = new System.Windows.Forms.ComboBox();
            this.gem = new System.Windows.Forms.ComboBox();
            this.versionBar = new System.Windows.Forms.ProgressBar();
            this.tradeLb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.settingPanel = new System.Windows.Forms.Panel();
            this.dbUrlText = new System.Windows.Forms.TextBox();
            this.dbUrlLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.homePanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.mainHeadPanel.SuspendLayout();
            this.settingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // poeLable
            // 
            this.poeLable.AutoSize = true;
            this.poeLable.BackColor = System.Drawing.Color.Transparent;
            this.poeLable.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.poeLable.ForeColor = System.Drawing.Color.White;
            this.poeLable.Location = new System.Drawing.Point(9, 9);
            this.poeLable.Name = "poeLable";
            this.poeLable.Size = new System.Drawing.Size(87, 15);
            this.poeLable.TabIndex = 0;
            this.poeLable.Text = "PoeDb_v1.0";
            this.poeLable.Click += new System.EventHandler(this.poeLable_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.monBtn);
            this.panel1.Controls.Add(this.homeBtn);
            this.panel1.Controls.Add(this.settingBtn);
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(84, 411);
            this.panel1.TabIndex = 5;
            // 
            // monBtn
            // 
            this.monBtn.BackColor = System.Drawing.Color.Transparent;
            this.monBtn.BackgroundImage = global::PoeDB.Properties.Resources.Summon_Skeleton_skill_icon;
            this.monBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.monBtn.FlatAppearance.BorderSize = 0;
            this.monBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.monBtn.Location = new System.Drawing.Point(0, 60);
            this.monBtn.Name = "monBtn";
            this.monBtn.Size = new System.Drawing.Size(84, 54);
            this.monBtn.TabIndex = 5;
            this.monBtn.Text = "\r\n";
            this.monBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.monBtn.UseVisualStyleBackColor = false;
            this.monBtn.Click += new System.EventHandler(this.monBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.Transparent;
            this.homeBtn.BackgroundImage = global::PoeDB.Properties.Resources.homepage;
            this.homeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Location = new System.Drawing.Point(0, 0);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(84, 54);
            this.homeBtn.TabIndex = 3;
            this.homeBtn.Text = "\r\n";
            this.homeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.homeBtn.UseVisualStyleBackColor = false;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // settingBtn
            // 
            this.settingBtn.BackColor = System.Drawing.Color.Transparent;
            this.settingBtn.BackgroundImage = global::PoeDB.Properties.Resources.browser_settings;
            this.settingBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settingBtn.FlatAppearance.BorderSize = 0;
            this.settingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingBtn.Location = new System.Drawing.Point(0, 120);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(84, 54);
            this.settingBtn.TabIndex = 4;
            this.settingBtn.Text = "\r\n";
            this.settingBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.settingBtn.UseVisualStyleBackColor = false;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // homePanel
            // 
            this.homePanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.homePanel.Controls.Add(this.tabDoc);
            this.homePanel.Controls.Add(this.headPanel);
            this.homePanel.Location = new System.Drawing.Point(102, 54);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(955, 411);
            this.homePanel.TabIndex = 6;
            // 
            // tabDoc
            // 
            this.tabDoc.Location = new System.Drawing.Point(0, 39);
            this.tabDoc.MinimumSize = new System.Drawing.Size(20, 20);
            this.tabDoc.Name = "tabDoc";
            this.tabDoc.Size = new System.Drawing.Size(955, 372);
            this.tabDoc.TabIndex = 2;
            this.tabDoc.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.tabDoc_DocumentCompleted);
            // 
            // headPanel
            // 
            this.headPanel.AutoSize = true;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(952, 33);
            this.headPanel.TabIndex = 0;
            // 
            // tabLink
            // 
            this.tabLink.AutoSize = true;
            this.tabLink.BackColor = System.Drawing.Color.DarkGray;
            this.tabLink.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabLink.Location = new System.Drawing.Point(15, 20);
            this.tabLink.Name = "tabLink";
            this.tabLink.Size = new System.Drawing.Size(69, 20);
            this.tabLink.TabIndex = 3;
            this.tabLink.Text = "label6";
            // 
            // tabText
            // 
            this.tabText.AutoSize = true;
            this.tabText.BackColor = System.Drawing.Color.DarkGray;
            this.tabText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabText.Location = new System.Drawing.Point(15, 0);
            this.tabText.Name = "tabText";
            this.tabText.Size = new System.Drawing.Size(69, 20);
            this.tabText.TabIndex = 2;
            this.tabText.Text = "label6";
            this.tabText.Click += new System.EventHandler(this.tabText_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.statusBox);
            this.panel3.Controls.Add(this.tabLink);
            this.panel3.Controls.Add(this.tabText);
            this.panel3.Location = new System.Drawing.Point(12, 471);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1045, 93);
            this.panel3.TabIndex = 7;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // statusBox
            // 
            this.statusBox.BackColor = System.Drawing.Color.DarkGray;
            this.statusBox.FormattingEnabled = true;
            this.statusBox.ItemHeight = 12;
            this.statusBox.Location = new System.Drawing.Point(90, 0);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(955, 88);
            this.statusBox.TabIndex = 4;
            this.statusBox.ValueMemberChanged += new System.EventHandler(this.statusBox_AddedItem);
            // 
            // trade
            // 
            this.trade.DisplayMember = "Text";
            this.trade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.trade.Font = new System.Drawing.Font("Ubuntu Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trade.FormattingEnabled = true;
            this.trade.Location = new System.Drawing.Point(0, 0);
            this.trade.Name = "trade";
            this.trade.Size = new System.Drawing.Size(121, 23);
            this.trade.TabIndex = 9;
            this.trade.SelectedIndexChanged += new System.EventHandler(this.share_SelectedIndexChanged);
            // 
            // mainHeadPanel
            // 
            this.mainHeadPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainHeadPanel.Controls.Add(this.map);
            this.mainHeadPanel.Controls.Add(this.quest);
            this.mainHeadPanel.Controls.Add(this.item);
            this.mainHeadPanel.Controls.Add(this.mod);
            this.mainHeadPanel.Controls.Add(this.gem);
            this.mainHeadPanel.Controls.Add(this.trade);
            this.mainHeadPanel.Location = new System.Drawing.Point(193, 22);
            this.mainHeadPanel.Name = "mainHeadPanel";
            this.mainHeadPanel.Size = new System.Drawing.Size(757, 26);
            this.mainHeadPanel.TabIndex = 10;
            // 
            // map
            // 
            this.map.DisplayMember = "Text";
            this.map.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.map.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.map.Font = new System.Drawing.Font("Ubuntu Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.map.FormattingEnabled = true;
            this.map.Location = new System.Drawing.Point(636, 0);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(121, 23);
            this.map.TabIndex = 14;
            this.map.SelectedIndexChanged += new System.EventHandler(this.share_SelectedIndexChanged);
            // 
            // quest
            // 
            this.quest.DisplayMember = "Text";
            this.quest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.quest.Font = new System.Drawing.Font("Ubuntu Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quest.FormattingEnabled = true;
            this.quest.Location = new System.Drawing.Point(508, 0);
            this.quest.Name = "quest";
            this.quest.Size = new System.Drawing.Size(121, 23);
            this.quest.TabIndex = 13;
            this.quest.SelectedIndexChanged += new System.EventHandler(this.share_SelectedIndexChanged);
            // 
            // item
            // 
            this.item.DisplayMember = "Text";
            this.item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.item.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.item.Font = new System.Drawing.Font("Ubuntu Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item.FormattingEnabled = true;
            this.item.Location = new System.Drawing.Point(127, 0);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(121, 23);
            this.item.TabIndex = 12;
            this.item.SelectedIndexChanged += new System.EventHandler(this.share_SelectedIndexChanged);
            // 
            // mod
            // 
            this.mod.DisplayMember = "Text";
            this.mod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.mod.Font = new System.Drawing.Font("Ubuntu Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mod.FormattingEnabled = true;
            this.mod.Location = new System.Drawing.Point(254, 0);
            this.mod.Name = "mod";
            this.mod.Size = new System.Drawing.Size(121, 23);
            this.mod.TabIndex = 11;
            this.mod.SelectedIndexChanged += new System.EventHandler(this.share_SelectedIndexChanged);
            // 
            // gem
            // 
            this.gem.DisplayMember = "Text";
            this.gem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gem.Font = new System.Drawing.Font("Ubuntu Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gem.FormattingEnabled = true;
            this.gem.Location = new System.Drawing.Point(381, 0);
            this.gem.Name = "gem";
            this.gem.Size = new System.Drawing.Size(121, 23);
            this.gem.TabIndex = 10;
            this.gem.SelectedIndexChanged += new System.EventHandler(this.share_SelectedIndexChanged);
            // 
            // versionBar
            // 
            this.versionBar.Location = new System.Drawing.Point(12, 27);
            this.versionBar.Name = "versionBar";
            this.versionBar.Size = new System.Drawing.Size(84, 21);
            this.versionBar.TabIndex = 11;
            // 
            // tradeLb
            // 
            this.tradeLb.AutoSize = true;
            this.tradeLb.BackColor = System.Drawing.Color.Transparent;
            this.tradeLb.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tradeLb.ForeColor = System.Drawing.Color.White;
            this.tradeLb.Location = new System.Drawing.Point(233, 9);
            this.tradeLb.Name = "tradeLb";
            this.tradeLb.Size = new System.Drawing.Size(37, 14);
            this.tradeLb.TabIndex = 12;
            this.tradeLb.Text = "交易";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(869, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "地图";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(744, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "任务";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(616, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "宝石";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(491, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "词缀";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(362, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "物品";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // settingPanel
            // 
            this.settingPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.settingPanel.Controls.Add(this.dbUrlText);
            this.settingPanel.Controls.Add(this.dbUrlLabel);
            this.settingPanel.Location = new System.Drawing.Point(102, 54);
            this.settingPanel.Name = "settingPanel";
            this.settingPanel.Size = new System.Drawing.Size(734, 411);
            this.settingPanel.TabIndex = 18;
            this.settingPanel.Visible = false;
            // 
            // dbUrlText
            // 
            this.dbUrlText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbUrlText.Location = new System.Drawing.Point(66, 7);
            this.dbUrlText.MaxLength = 500;
            this.dbUrlText.Name = "dbUrlText";
            this.dbUrlText.ReadOnly = true;
            this.dbUrlText.Size = new System.Drawing.Size(272, 26);
            this.dbUrlText.TabIndex = 1;
            // 
            // dbUrlLabel
            // 
            this.dbUrlLabel.AutoSize = true;
            this.dbUrlLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbUrlLabel.Location = new System.Drawing.Point(4, 10);
            this.dbUrlLabel.Name = "dbUrlLabel";
            this.dbUrlLabel.Size = new System.Drawing.Size(64, 16);
            this.dbUrlLabel.TabIndex = 0;
            this.dbUrlLabel.Text = "主页Url";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // PoeDbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1069, 567);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tradeLb);
            this.Controls.Add(this.versionBar);
            this.Controls.Add(this.mainHeadPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.homePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.poeLable);
            this.Controls.Add(this.settingPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PoeDbForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PoeDbWebCraw_V1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.homePanel.ResumeLayout(false);
            this.homePanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.mainHeadPanel.ResumeLayout(false);
            this.settingPanel.ResumeLayout(false);
            this.settingPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label poeLable;
        private Button homeBtn;
        private Button settingBtn;
        private Panel panel1;
        private Panel homePanel;
        private Panel panel3;
        private FlowLayoutPanel headPanel;
        private ComboBox trade;
        private Panel mainHeadPanel;
        private ComboBox map;
        private ComboBox quest;
        private ComboBox item;
        private ComboBox mod;
        private ComboBox gem;
        private ProgressBar versionBar;
        private Label tradeLb;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label tabText;
        private Label tabLink;
        private WebBrowser tabDoc;
        private ListBox statusBox;
        private Panel settingPanel;
        private TextBox dbUrlText;
        private Label dbUrlLabel;
        private Button monBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

