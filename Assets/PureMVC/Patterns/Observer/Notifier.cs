//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;

namespace PureMVC.Patterns.Observer
{

    public class Notifier: INotifier
    {

        public virtual void SendNotification(string notificationName, object body, string type)
        {
            Facade.SendNotification(notificationName, body, type);
        }


        protected IFacade Facade
        {
            get {
                return Patterns.Facade.Facade.GetInstance(() => new Facade.Facade());
            }
        }
    }
}
