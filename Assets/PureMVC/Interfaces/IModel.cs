//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{

    public interface IModel
    {

        void RegisterProxy(IProxy proxy);

        IProxy RetrieveProxy(string proxyName);


        IProxy RemoveProxy(string proxyName);

        bool HasProxy(string proxyName);
    }
}
