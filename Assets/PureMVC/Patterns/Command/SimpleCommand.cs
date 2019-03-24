//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Command
{

    public class SimpleCommand : Notifier, ICommand, INotifier
    {
        public virtual void Execute(INotification notification)
        {
        }
    }
}
