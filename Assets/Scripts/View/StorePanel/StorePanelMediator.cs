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
        public new static string NAME = "StorePanelMediator";
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
            GetStorePanel.CloseButtonAction = CloseOnClickActionHandle;
            CreatItem();
        }

        public void CreatItem()
        {
            GlobalDataProxy gloalDataProxy = ApplicationFacade.Instance.RetrieveProxy(GlobalDataProxy.NAME) as GlobalDataProxy;
            GlobalData gloalData = gloalDataProxy.GetGlobalData;
            int count = gloalData.ItemCount;
            for (int i = 0; i < count; i++)
            {
               GameObject tempObj =  UnityEngine.GameObject.Instantiate(GetStorePanel.templateItem);
                ItemComponent itemComponent = tempObj.AddComponent<ItemComponent>();
                GetStorePanel.itemComponents.Add(itemComponent);
                tempObj.name = "Item_" + i;
                tempObj.transform.SetParent(GetStorePanel.target, false);
                tempObj.SetActive(true);
            }
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
                SendNotification(Notification.ColdTheme, null,null);
            }
        }

        public void WarmThemeToggleActionHandle(bool tempIs)
        {
            if (tempIs)
            {
                SendNotification(Notification.WarmTheme, null, null);
            }
        }

        public void CloseOnClickActionHandle()
        {
            SendNotification(Notification.CloseCurrencyPanel, null, null);
            SendNotification(Notification.OpenHomePanel, null, null);
        }

        public override string[] ListNotificationInterests()
        {
            List<string> listNotificationInterests = new List<string>();
            listNotificationInterests.Add(Notification.ColdTheme);
            listNotificationInterests.Add(Notification.WarmTheme);
            return listNotificationInterests.ToArray();
        }

        public override void HandleNotification(INotification notification)
        {
            GlobalDataProxy gloalDataProxy = ApplicationFacade.Instance.RetrieveProxy(GlobalDataProxy.NAME) as GlobalDataProxy;
            GlobalData gloalData = gloalDataProxy.GetGlobalData;
            switch (notification.Name)
            {
                case Notification.ColdTheme:
                    {
                        gloalData.ThemeIndex = 1;
                        for (int i = 0; i < GetStorePanel.itemComponents.Count; i++)
                        {
                            GetStorePanel.itemComponents[i].ChangeTheme();
                        }
                        break;
                    }
                    case Notification.WarmTheme:
                    {
                        gloalData.ThemeIndex = 2;
                        for (int i = 0; i < GetStorePanel.itemComponents.Count; i++)
                        {
                            GetStorePanel.itemComponents[i].ChangeTheme();
                        }
                        break;
                    }

                default:
                    break;
            }
        }
    }
}


