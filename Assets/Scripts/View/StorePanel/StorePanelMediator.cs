using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Core;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVC.Patterns.Command;
using PureMVC.Patterns.Facade;
using PureMVC.Patterns.Mediator;
using PureMVC.Patterns.Observer;
using PureMVC.Patterns.Proxy;
using Custom.Log;

namespace PureMVC.Tutorial
{
    public class StorePanelMediator : Mediator
    {
        public StorePanelMediator(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
        {
        }

        public StorePanel GetStorePanel
        {
            get
            {
                return ViewComponent as StorePanel;
            }
        }

        public override void OnRegister()
        {
            base.OnRegister();
            GetStorePanel.coldThemeToggleAction = ColdThemeToggleActionHandle;
            GetStorePanel.warmThemeToggleAction = WarmThemeToggleActionHandle;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            GetStorePanel.coldThemeToggleAction = null;
            GetStorePanel.warmThemeToggleAction = null;
        }

        public void ColdThemeToggleActionHandle(bool tempIs)
        {
            if (tempIs)
            {
                this.Log("冷色主题");
                SendNotification(Notification.ColdTheme, null,null);
            }
        }

        public void WarmThemeToggleActionHandle(bool tempIs)
        {
            if (tempIs)
            {
                this.Log("暖色主题");
                SendNotification(Notification.WarmTheme, null, null);
            }
        }


        public override string[] ListNotificationInterests()
        {
            List<string> listNotificationInterests = new List<string>();
            listNotificationInterests.Add("123123");

            return listNotificationInterests.ToArray();
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case "123":
                    {
                        this.Log("123123123");
                        break;
                    }

                default:
                    break;
            }
        }
    }
}


