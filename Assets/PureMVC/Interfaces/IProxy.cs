//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{

    public interface IProxy: INotifier
    {

        string ProxyName { get; }

        object Data { get; set; }


        void OnRegister();

        void OnRemove();
    }
}
