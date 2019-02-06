using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace chat
{
    static class IPhelper
    {
        static PingReply reply;
        static BindingList<string> list = new BindingList<string>();
        public static void getIP_List() {
            list.AllowRemove = true;
            list.Clear();
            for (int i = 2; i < 255; i++) {
                Ping ping = new Ping();
                ping.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
                ping.SendAsync("192.168.0." + i,null);
            }
        }
        private static void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            if(e.Reply.Status == IPStatus.Success)
                list.Add(e.Reply.Address.ToString());
        }

        public static BindingList<string> GetList() {
            return list;
        }
    }
}
