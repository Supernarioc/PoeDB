using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoeDB
{
    public class AsyncMsgBox
    {
        public delegate void msgDelegate(string str);
        
        public static msgDelegate msgDelegateInstance;
        public static void showMsg(string str)
        {
            msgDelegateInstance.BeginInvoke(str, new System.AsyncCallback(msgCallback), "MessageBox Begin");
        }

        private static void msgCallback(IAsyncResult iasync)
        {
            msgDelegateInstance.EndInvoke(iasync);
            string state = (string)iasync.AsyncState;
            Console.Out.WriteLine(state);
        }
        /// <summary>
        /// 调用方法
        /// </summary>
        /// <param name="str"></param>
        public static void msgMethod(string str)
        {
            MessageBox.Show(str);
            
        }
    }
}
