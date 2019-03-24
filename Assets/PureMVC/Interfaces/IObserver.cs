//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;

namespace PureMVC.Interfaces
{

    public interface IObserver
    {
        Action<INotification> NotifyMethod { set; }

        object NotifyContext { set; }

        void NotifyObserver(INotification notification);

        bool CompareNotifyContext(object obj);
    }
}
