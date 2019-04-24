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
        public static ApplicationFacade Instance
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
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();
            RegisterProxy(new GlobalDataProxy(GlobalDataProxy.NAME,new GlobalData()));
        }

        public void StartUpHandle()
        {
            SendNotification(Notification.StartUp);

        }
        public void GameStartHandle()
        {
            SendNotification(Notification.GameStart);
        }


    }
}



