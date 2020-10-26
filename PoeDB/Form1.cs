using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoeDB
{
    public partial class PoeDbForm : Form
    {
        public PoeDbForm()
        {
            InitializeComponent();
            //initial panel switch
            pre_panel = this.homePanel;
            watch = Stopwatch.StartNew();
        }

        private string pre_box = "";
        private string pre_listItem = "";
        private static Panel pre_panel = null;
        private Stopwatch watch;
        private PageContent pgdata = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SuppressScriptErrorsOnly(tabDoc);
                Connection();
                initial_header();
            }
            catch(Exception ex) {
                updateStatusBox("PoeDb connection failed");
                Console.Write(ex.Message);
            }
            //BackgroundWorker 
            //var asyncT = await updateStatus();
        }

        //public async Task<string> updateStatus() {
        //    trade.Items.Add("update");
        //    statusBox.Items.Add("update");
        //    return "update";
        //}
        private string res = "";
        private void paralle() {
            string[] strs = new string[]{"1","2","3"};
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 1;
            Parallel.ForEach(strs,options,(str) =>
            {
                task(str);
            });
            updateStatusBox(res);
        }

        private void task(string str) {
            res += str;
        }

        private void initial_header()
        {
            this.pgdata = new PageContent();
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();
            updateStatusBox("Initializing PoeDB header...");
            //initial all combobox 
            //ComboBox[] boxList = { trade, item, mod, gem, quest, map };
            //mod only have one subtitle
            mod.Items.Add(new { Text = "词缀", Link = "mod.php" });
            var headlinetx = pgdata.getM_HeadlineTx();
            if (headlinetx != null)
            {
                //box list index
                int index = 0;
                //dynamic add item to box
                foreach (var m_head in headlinetx)
                {
                    foreach (Tuple<string, string> sub_head in m_head.Sub_head)
                    {
                        ComboBox box = this.Controls.Find(DBsettings.mainHeadBox[index],true).FirstOrDefault() as ComboBox;
                        box.Items.Add(new { Text = sub_head.Item1, Link = sub_head.Item2 });
                    }
                    index++;
                }
                watch.Stop();
                updateStatusBox("PoeDB header complete " + Math.Round((double)watch.ElapsedMilliseconds / 1000, 3) + "s");
            }
            else {
                watch.Stop();
                updateStatusBox("Error occured in fetching?? " + Math.Round((double)watch.ElapsedMilliseconds / 1000, 3) + "s");
            }

        }

        /// <summary>
        /// fetch page data
        /// </summary>
        private void Connection()
        {
            //get Main_headlineTx
            //dynamic add buttons
            
            //foreach (var node in headlineTx.Sub_head) {
            //    Button headBtn = new Button();
            //    //headbtn style
            //    headBtn.Text = node.InnerText;
            //    headBtn.BackColor = System.Drawing.Color.Transparent;
            //    headBtn.FlatAppearance.BorderSize = 0;
            //    headBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            //    this.headPanel.Controls.Add(headBtn);
            //}
        }
        private void ProcessData(int length, IProgress<VersionCheckProgress> progress) {
            var progressReport = new VersionCheckProgress();
            for (int i = 0; i < length; i++)
            {
                Thread.Sleep(10);
                progressReport.PercentComplete = (i * 100) / length;
                progress.Report(progressReport);
            }
        }
        /// <summary>
        /// 检查新版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void poeLable_Click(object sender, EventArgs e)
        {
            //initial delegate
            AsyncMsgBox.msgDelegateInstance = new AsyncMsgBox.msgDelegate(AsyncMsgBox.msgMethod);
            updateStatusBox("Checking PoeDB version...");
            updateStatusBox("Local PoeDB version is " + poeLable.Text.Split('_')[1]);

            var updateRequired = false;
            var progress = new Progress<VersionCheckProgress>();
            progress.ProgressChanged += (o, report) => {
                Console.WriteLine(report.PercentComplete);
                versionBar.Value = report.PercentComplete;
                versionBar.Update();
            };
            await Task.Run(() => ProcessData(100, progress));
            if (updateRequired) {
                AsyncMsgBox.showMsg("Update required");
            }
            else {
                AsyncMsgBox.showMsg("Version is latest");
            }
            string wait = await PageContent.update();
            statusBox.Items.Add(wait);
            //todo: add latest version from fetched data
            updateStatusBox("PoeDB version check complete");

            versionBar.Value = 0;
        }
        
        private void textBox_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            //clear main page selected value and broswer content
            //this.headPanel.Invalidate();
            //foreach (var box in this.mainHeadPanel.Controls.OfType<ComboBox>()) {
            //    box.SelectedIndex = -1;
            //}
            //tabDoc.Navigate("about:blank");
            //bind button to panel may complex
            pre_panel.Visible = false;
            this.homePanel.Visible = true;
            pre_panel = this.homePanel;
        }
        private void settingBtn_Click(object sender, EventArgs e) {
            loadSettingPage();
            pre_panel.Visible = false;
            this.settingPanel.Visible = true;
            pre_panel = this.settingPanel;
            paralle();
        }

        private void loadSettingPage()
        {
            var mainUrl = DBsettings.DBURL;
            dbUrlText.Text = mainUrl;
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// threadpool
        /// </summary>
        /// <param name="str"></param>
        private void tasks(object str) {

        }
        private void pool() {
            ThreadPool.SetMaxThreads(5,5);
            for (var i = 0; i < 10; i++) {
                ThreadPool.QueueUserWorkItem(tasks,"task ");
            }
            Thread.Sleep(100);
        }
        private void share_SelectedIndexChanged(object sender, EventArgs e)
        {
            var boxSender = sender as ComboBox;
            if(boxSender != null)
                if (boxSender.SelectedIndex > -1) {
                    if (pre_box != "" && pre_box != boxSender.Name) {
                        ComboBox pre_combo = this.Controls.Find(pre_box, true).FirstOrDefault() as ComboBox;
                        pre_combo.SelectedIndex = -1;
                    }
                    else
                        pre_box = boxSender.Name;
                    var Selected_tx = (boxSender.SelectedItem as dynamic).Text;
                    var Selected_lk = (boxSender.SelectedItem as dynamic).Link;
                    if (pre_listItem != Selected_tx)
                    {
                        //clear input box
                        this.monSearchBox.Text = "";
                        //update page label
                        pre_listItem = Selected_tx;
                        tabText.Text = Selected_tx;
                        tabLink.Text = Selected_lk;
                        if (Selected_tx == "怪物")
                        {
                            this.monSearchBtn.Visible = this.monSearchBox.Visible = true;
                        }
                        else {
                            this.monSearchBtn.Visible = this.monSearchBox.Visible = false;
                        }
                        this.watch = Stopwatch.StartNew();
                        this.watch.Start();

                        updateStatusBox("Loading " + Selected_tx + " page...");
                        
                        //load html doc from selected index
                        var sub_pageDt = pgdata.getCertainPage(Selected_lk);
                        //initial webbrowser
                        tabDoc.Navigate("about:blank");
                        HtmlDocument doc = tabDoc.Document;
                        doc.Write(String.Empty);
                        //TODO: seprate doc thread with form thread
                        tabDoc.DocumentText = DBsettings.styleSheet + sub_pageDt + DBsettings.htmlEnd;
                    }
                }
        }

        private void updateStatusBox(string status) {
            statusBox.Items.Add(status);
            if(statusBox.Items.Count > 6)
                statusBox.TopIndex = statusBox.Items.Count - 1;
        }
        private void trade_MouseHover(object sender, EventArgs e)
        {
            this.trade.DroppedDown = true;
        }
        private void trade_MouseLeave(object sender, EventArgs e)
        {
            this.trade.DroppedDown = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabDoc_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.watch.Stop();
            updateStatusBox("Page loaded " + Math.Round((double)watch.ElapsedMilliseconds / 1000, 3) + "s" + "    " + System.DateTime.Now.ToString(DBsettings.timeFormat));
        }

        // Hides script errors without hiding other dialog boxes.
        private void SuppressScriptErrorsOnly(WebBrowser browser)
        {
            browser.ScriptErrorsSuppressed = true;
        }

        private void statusBox_AddedItem(object sender, EventArgs e)
        {
            //auto scroll
            bool scroll = false;
            if (this.statusBox.TopIndex == this.statusBox.Items.Count - (int)(this.statusBox.Height / this.statusBox.ItemHeight))
                scroll = true;
            if(scroll)
                this.statusBox.TopIndex = this.statusBox.Items.Count - (int)(this.statusBox.Height / this.statusBox.ItemHeight);
        }

        private void tabText_Click(object sender, EventArgs e)
        {

        }

        private void monBtn_Click(object sender, EventArgs e)
        {
            this.watch = Stopwatch.StartNew();
            this.watch.Start();
            updateStatusBox("Loading 怪物 page...");
            var sub_pageDt = pgdata.getCertainPage("mon.php");
            //initial webbrowser
            tabDoc.Navigate("about:blank");
            HtmlDocument doc = tabDoc.Document;
            doc.Write(String.Empty);
            tabDoc.DocumentText = DBsettings.styleSheet + sub_pageDt + DBsettings.htmlEnd;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void monSearch_Click(object sender, EventArgs e)
        {
            //input eg: aspect of might => Aspect_of_Might
            //
            var inputText = this.monSearchBox.Text.ToString(); ;
            if (inputText != "" || inputText.Contains('_'))
            {
                var _name = inputText.Split(' ');
                var monUrl = "";
                if (_name.Count() > 1)
                {
                    for (var i = 0; i < _name.Count(); ++i)
                    {
                        monUrl += char.ToUpper(_name[i][0]) + _name[i].Substring(1);
                        if (i != _name.Count() - 1)
                            monUrl += "_";
                    }
                }
                tabDoc.Navigate("about:blank");
                HtmlDocument doc = tabDoc.Document;
                doc.Write(String.Empty);
                this.watch = Stopwatch.StartNew();
                this.watch.Start();
                tabDoc.DocumentText = DBsettings.styleSheet + pgdata.getCertainPage("/" + (monUrl == "" ? inputText : monUrl)) + DBsettings.htmlEnd;
            }
            else {
                updateStatusBox("Monster name invalid");
            }
        }

        private void monSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                monSearchBtn.PerformClick();
            }
        }
    }
}
