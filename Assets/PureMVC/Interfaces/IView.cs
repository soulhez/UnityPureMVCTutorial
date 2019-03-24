//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{

    public interface IView
    {

        void RegisterObserver(string notificationName, IObserver observer);

        void RemoveObserver(string notificationName, object notifyContext);

        void NotifyObservers(INotification notification);

        void RegisterMediator(IMediator mediator);

        IMediator RetrieveMediator(string mediatorName);

        IMediator RemoveMediator(string mediatorName);

        bool HasMediator(string mediatorName);
    }
}
