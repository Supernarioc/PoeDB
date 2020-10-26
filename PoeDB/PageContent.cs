using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using PoeDB.FormDisplayType;
using System.Threading;

namespace PoeDB
{
    public class PageContent
    {
        public HtmlAgilityPack.HtmlNode[] areaTab_B = new HtmlAgilityPack.HtmlNode[] { };
        public HtmlAgilityPack.HtmlNode[] areaTab_G = new HtmlAgilityPack.HtmlNode[] { };
        public HtmlAgilityPack.HtmlNode monTable = null;
        public string _thead = "";
        object _lock = new object();

        public HtmlAgilityPack.HtmlNode areaTab_Main;
        public HashSet<string> monUrlSet = new HashSet<string>();

        public HtmlAgilityPack.HtmlNode[] M_headline = new HtmlAgilityPack.HtmlNode[] { };
        private string outHtml;

        /// <summary>
        /// 初始化爬取
        /// </summary>
        public PageContent() {
            getMainPage();
        }
        /// <summary>
        /// 获取标题
        /// </summary>
        /// <returns></returns>
        public M_headline[] getM_HeadlineTx() {
            List<M_headline> M_heads = new List<FormDisplayType.M_headline>();
            M_headline m_head = new M_headline();
            foreach (var mhead in M_headline) {
                //get main headline tx 
                //div[@id='pane-news'] 默认搜索id为pane-news
                //a[contains(@class,'nav-link')] 搜索包含nav-link的class
                m_head.M_head = mhead.SelectSingleNode("//a[contains(@class,'nav-link')]").InnerText;
                List<Tuple<string,string>> sub_heads = new List<Tuple<string,string>>();
                //get sub headline tx
                var subnode = mhead.SelectNodes("div/a");
                //loop to get sub heads
                if (subnode != null)
                {
                    foreach (var sub in subnode)
                    {
                        string link = sub.GetAttributeValue("href", "").Trim();
                        sub_heads.Add(Tuple.Create(sub.InnerText,link));
                    }
                }
                m_head.Sub_head = sub_heads.ToArray();
                M_heads.Add(m_head);
                m_head = new M_headline();
            }
            return M_heads.ToArray();
        }

        public void getMainPage()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //monster page
            Uri uri = new Uri(DBsettings.DBURL);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            
            var CrawlResult = WebRequest.RequestAction(new RequestOptions() { Uri = uri, Method = "Get" });
            //加载页面
            doc.LoadHtml(CrawlResult);

            HtmlAgilityPack.HtmlNode headlineN = doc.DocumentNode.SelectSingleNode("//div[@class = 'collapse navbar-collapse']");
            if (headlineN != null)
                M_headline = headlineN.SelectNodes(".//li").ToArray();
        }
        /// <summary>
        /// 获取其他页面
        /// </summary>
        public string getCertainPage(string subUrl) {
            var _subUrl = subUrl.Split('/');
            Uri uri = new Uri(DBsettings.DBURL + (_subUrl.Count() > 1 ? _subUrl[1] : subUrl));
            string resp = "";
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            var simpleCrawlResult = WebRequest.RequestAction(new RequestOptions() { Uri = uri, Method = "Get" });
            //加载页面
            doc.LoadHtml(simpleCrawlResult);
            //tab-content
            HtmlAgilityPack.HtmlNode tab_content = doc.DocumentNode.SelectSingleNode("//div[@class = 'tab-content']");
            if (subUrl.Contains('/'))
                tab_content = tab_content.SelectSingleNode(".//div[1]");
            //areaTab_Main = tab_content.SelectSingleNode("div[@class = 'table-responsive']");
            //blue-area tab
            //HtmlAgilityPack.HtmlNode headlineN = doc.DocumentNode.SelectSingleNode("//div[@id = 'navbarColor02']");
            //areaTab_B = headlineN.SelectNodes(".//a")?.ToArray();
            //gray-area tab
            //HtmlAgilityPack.HtmlNode gray_nav = doc.DocumentNode.SelectSingleNode("//ul[@class = 'nav nav-tabs d-flex flex-wrap']");
            //areaTab_G = headlineN.SelectNodes(".//a")?.ToArray();

            //monster_list
            HtmlAgilityPack.HtmlNode inputNode = doc.DocumentNode.SelectSingleNode("//div[@class = 'query input-group']");
            resp = inputNode?.OuterHtml; 
            if (subUrl == "mon.php")
                //get monster detail list
                resp += monPage();
            else if(tab_content == null)
                return "<h1>Content not found</h1>"; 
            else
                //return main page tab-content html
                resp += tab_content.InnerHtml;
            
            return resp;
        }
        public string monPage() {
            Uri uri = new Uri(DBsettings.DBURL + "mon.php");
            string resp = null;
            //monster list doc
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //monster detail doc
            //HtmlAgilityPack.HtmlDocument subdoc = new HtmlAgilityPack.HtmlDocument();
            //tempary doc
            HtmlAgilityPack.HtmlDocument _doc = new HtmlAgilityPack.HtmlDocument();
            //create empty table
            monTable = null;
            outHtml = "";
            monUrlSet = new HashSet<string>();
            monTable = _doc.CreateElement("table");
            //monTable.AddClass("table table-striped table-bordered");
            monTable.AppendChild(_doc.CreateElement("thead"));
            monTable.AppendChild(_doc.CreateElement("tbody"));
            var theadNode = monTable.SelectSingleNode(".//thead");


            var monList = new HtmlAgilityPack.HtmlNode[] { };
            var simpleCrawlResult = WebRequest.RequestAction(new RequestOptions() { Uri = uri, Method = "Get" });
            //load monster list 
            doc.LoadHtml(simpleCrawlResult);
            var monSpan = doc.DocumentNode.SelectSingleNode("//h5[@class='card-header']").InnerHtml;
            resp = monSpan;
            areaTab_Main = doc.DocumentNode.SelectSingleNode("//div[@id = 'Monstermon_list15']");
            string tableClass = areaTab_Main.SelectSingleNode(".//table").GetAttributeValue("class", "");
            monTable.AddClass(tableClass);
            HtmlAgilityPack.HtmlNode[] mons = areaTab_Main.SelectNodes(".//tbody/tr[position() < 10 ]").ToArray();

            //var _thead = monTable.SelectSingleNode(".//thead");
            //add thead
            if (_thead == "")
            {
                string[] monTh = DBsettings.monTableHead;
                foreach (var th in monTh)
                    _thead += "<th>" + th + "</th>";
                theadNode.InnerHtml = _thead;
            }
            if (theadNode.InnerHtml == "")
                theadNode.InnerHtml = _thead;

            //ParallelOptions option = new ParallelOptions();
            //option.MaxDegreeOfParallelism = 4;
            int index = 0;
            //string outHtml = "";
            //Parallel.ForEach(mons, option, (mon) =>
            //{
            //    Thread.Sleep(100);
            //    outHtml += monDetailPg(mon, index++);
            //});
            //threadpool
            //ThreadPool.SetMaxThreads(5, 5);
            //foreach (var mon in mons) {
            //    ThreadPool.QueueUserWorkItem(state => monThread(mon));
            //    Console.Out.WriteLine("T"+ ++index);
            //}
            //Thread[] threads = new Thread[9];

            foreach (var mon in mons) {
                Thread thread = new Thread(() => monThread(mon));
                thread.Start();
            }

            //loop get mon detail resp
            //foreach (var mon in mons)
            //{
            //    //fetch monster detail
            //    //var suburl = mon.SelectSingleNode("td[1]/a").GetAttributeValue("href", "");
            //    //if (!monUrlSet.Contains(suburl)&&suburl.StartsWith("/cn/"))
            //    //{
            //    //    monUrlSet.Add(suburl);
            //    //    Uri monLink = new Uri(DBsettings.monURL + suburl);
            //    //    var monCrawl = WebRequest.RequestAction(new RequestOptions() { Uri = monLink, Method = "Get" });
            //    //    subdoc.LoadHtml(monCrawl);
            //    //    var monName = subdoc.DocumentNode.SelectSingleNode("//h4");
            //    //    var detailTab = subdoc.DocumentNode.SelectSingleNode("//div[@class = 'tab-content'][1]/div[1]/table");
            //    //    if (detailTab.SelectNodes("tr").Count > 16)
            //    //    {
            //    //        //todo: add td according to th 
            //    //        var monTd = detailTab.SelectNodes("tr[position() = 1 or position() > 2 and position() < 15]/td");

            //    //        if (first)
            //    //        {
            //    //            //add name
            //    //            var monTh = detailTab.SelectNodes("tr[position() = 1 or position() > 2 and position() < 15]/th");
            //    //            _thead.InnerHtml = "<th>名字</th>";
            //    //            foreach (var th in monTh)
            //    //                _thead.InnerHtml += th.OuterHtml;
            //    //            first = false;
            //    //        }
            //    //        //new element
            //    //        var _tr = _doc.CreateElement("tr");
            //    //        _tr.InnerHtml += "<td>" + monName.InnerHtml + "</td>";
            //    //        foreach (var td in monTd)
            //    //        {
            //    //            _tr.AppendChild(td);
            //    //        }
            //    //        monTable.SelectSingleNode(".//tbody").InnerHtml += _tr.OuterHtml;
            //    //    }
            //    //}
            //}
            monTable.SelectSingleNode(".//tbody").InnerHtml += outHtml;
            resp += monTable.OuterHtml;
            return resp;
        }
        public static async Task<string> update() {
            await Task.Delay(20);
            return "update";
        }

        private void monThread(object objs) {
            //lock (_lock)
            //{
                outHtml += monDetailPg((HtmlAgilityPack.HtmlNode)objs);
            //}
        }

        private string monDetailPg(HtmlAgilityPack.HtmlNode monNode) {
            HtmlAgilityPack.HtmlDocument _doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlDocument subdoc = new HtmlAgilityPack.HtmlDocument();

            var suburl = monNode.SelectSingleNode("td[1]/a").GetAttributeValue("href", "");
            if (!monUrlSet.Contains(suburl) && suburl.StartsWith("/cn/"))
            {
                monUrlSet.Add(suburl);
                Uri monLink = new Uri(DBsettings.monURL + suburl);
                var monCrawl = WebRequest.RequestAction(new RequestOptions() { Uri = monLink, Method = "Get" });
                subdoc.LoadHtml(monCrawl);
                var monName = subdoc.DocumentNode.SelectSingleNode("//h4");
                var detailTab = subdoc.DocumentNode.SelectSingleNode("//div[@class = 'tab-content'][1]/div[1]/table");
                if (detailTab.SelectNodes("tr").Count > 16)
                {
                    //todo: add td according to th 
                    var monTd = detailTab.SelectNodes("tr[position() = 1 or position() > 2 and position() < 15]/td");

                    //new element
                    var _tr = _doc.CreateElement("tr");
                    _tr.InnerHtml += "<td>" + monName.InnerHtml + "</td>";
                    foreach (var td in monTd)
                    {
                        _tr.AppendChild(td);
                    }
                    //final add tr outerhtml to montable
                    return _tr.OuterHtml;
                }
            }
            //Console.Out.WriteLine("Thread "+index);
            return "";
        }
    }
}
