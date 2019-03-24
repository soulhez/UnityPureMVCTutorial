//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Concurrent;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Core
{

    public class Controller: IController
    {

        public Controller()
        {
            if (instance != null) throw new Exception(Singleton_MSG);
            instance = this;
            commandMap = new ConcurrentDictionary<string, Func<ICommand>>();
            InitializeController();
        }

        protected virtual void InitializeController()
        {
            view = View.GetInstance(() => new View());
        }


        public static IController GetInstance(Func<IController> controllerFunc)
        {
            if (instance == null) {
                instance = controllerFunc();
            }
            return instance;
        }

        public virtual void ExecuteCommand(INotification notification)
        {
            if (commandMap.TryGetValue(notification.Name, out Func<ICommand> commandFunc))
            {
                ICommand commandInstance = commandFunc();
                commandInstance.Execute(notification);
            }
        }

        public virtual void RegisterCommand(string notificationName, Func<ICommand> commandFunc)
        {
            if (commandMap.TryGetValue(notificationName, out Func<ICommand> _) == false)
            {
                view.RegisterObserver(notificationName, new Observer(ExecuteCommand, this));
            }
            commandMap[notificationName] = commandFunc;
        }


        public virtual void RemoveCommand(string notificationName)
        {
            if (commandMap.TryRemove(notificationName, out Func<ICommand> _))
            {
                view.RemoveObserver(notificationName, this);
            }
        }


        public virtual bool HasCommand(string notificationName)
        {
            return commandMap.ContainsKey(notificationName);
        }

        protected IView view;

        protected readonly ConcurrentDictionary<string, Func<ICommand>> commandMap;

        protected static IController instance;

        protected const string Singleton_MSG = "Controller Singleton already constructed!";
    }
}
