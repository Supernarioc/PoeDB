using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoeDB
{
    public class DBsettings
    {
        /// <summary>
        /// 主页URL
        /// </summary>
        public static readonly string monURL = "https://poedb.tw";
        public static readonly string DBURL = "https://poedb.tw/cn/";//todo:可更改
        public static readonly List<string> mainHeadBox = new List<string> { "trade", "item", "mod", "gem", "quest", "map" };
        public static readonly string styleSheet = "<html><head><link href= 'https://poedb.tw/css/stdtheme.css?20200704_23' rel='stylesheet'>"
                                                  +"<link rel = 'stylesheet' href='https://poedb.tw/css/theme/darkly/bootstrap.min.css' crossorigin='anonymous'>"
                                                  +"</head><body>";
        public static readonly string htmlEnd = "</body></html>";
        public static readonly string htmlTableBodyTx = "<tbody aria-live='polite' aria-relevant='all'>";
    }
}
