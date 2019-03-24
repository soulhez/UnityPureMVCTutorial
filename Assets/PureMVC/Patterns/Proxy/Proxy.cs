//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Proxy
{

    public class Proxy: Notifier, IProxy, INotifier
    {

        public static string NAME = "Proxy";


        public Proxy(string proxyName, object data=null)
        {
            ProxyName = proxyName ?? Proxy.NAME;
            if (data != null) Data = data;
        }


        public virtual void OnRegister()
        { 
        }


        public virtual void OnRemove()
        {
        }


        public string ProxyName { get; protected set; }

        public object Data { get; set; }
    }
}
