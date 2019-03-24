//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{

    public interface INotifier
    {
        void SendNotification(string notificationName, object body = null, string type = null);
    }
}
