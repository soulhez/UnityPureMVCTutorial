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
    public class CurrencyPanelMediator : Mediator
    {
        public CurrencyPanelMediator(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
        {
        }


        public CurrencyPanel GetCurrencyPanel
        {
            get
            {
                return ViewComponent as CurrencyPanel;
            }
        }


        public override string[] ListNotificationInterests()
        {
            List<string> listNotificationInterests = new List<string>();
            listNotificationInterests.Add(Notification.ChangeGold);
            listNotificationInterests.Add(Notification.ChangeSilver);
            listNotificationInterests.Add(Notification.ChangeBronze);

            return listNotificationInterests.ToArray();
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case Notification.ChangeGold:
                    {
                        this.Log("123123123");
                        break;
                    }
                case Notification.ChangeSilver:
                    {
                        this.Log("123123123");
                        break;
                    }
                case Notification.ChangeBronze:
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

