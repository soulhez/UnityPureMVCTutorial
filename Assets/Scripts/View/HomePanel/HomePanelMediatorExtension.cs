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
    public class HomePanelMediatorExtension : Mediator
    {
        public HomePanelMediatorExtension(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
        {
        }


        public HomePanelView GetHomePanelView
        {
            get
            {
                return ViewComponent as HomePanelView;
            }
        }

        public override void OnRegister()
        {
            base.OnRegister();
            GetHomePanelView.SettingAction += SettingActionHandle;
        }


        public override void OnRemove()
        {
            base.OnRemove();
            GetHomePanelView.SettingAction = null;
        }

        public void SettingActionHandle()
        {
            this.Log("加载设置面板");
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

