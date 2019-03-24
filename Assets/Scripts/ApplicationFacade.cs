using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Core;
using PureMVC.Interfaces;
using PureMVC.Patterns.Facade;

namespace PureMVC.Tutorial
{
    public class ApplicationFacade : Facade
    {
        public static IFacade Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GetInstance(() => new ApplicationFacade());
                }
                return instance as ApplicationFacade;
            }
        }


        protected override void InitializeController()
        {
            base.InitializeController();

            RegisterCommand(Notification.StartUp, () => new StartupCommand());
            RegisterCommand(Notification.GameStart, () => new GameStartCommand());
            RegisterCommand(Notification.LoginSuccess, () => new LoginSuccessCommand());
            RegisterCommand(Notification.LoginSuccessProxy, () => new GetPrefsCommand());
        }


        public void StartUpHandle()
        {
            SendNotification(Notification.StartUp);
            SendNotification(Notification.GameStart);
        }
    }
}



