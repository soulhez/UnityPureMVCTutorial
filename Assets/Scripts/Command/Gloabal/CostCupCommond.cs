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
    public class CostCupCommond : SimpleCommand
    {
        public class Data
        {
            public Data(CurrencyType tempCurrencyType,int tempCupNumber)
            {
                currencyType = tempCurrencyType;
                cupNumber = tempCupNumber;
            }
            public CurrencyType currencyType = CurrencyType.None;
            public int cupNumber = 0;
        }
        public override void Execute(INotification notification)
        {
            base.Execute(notification);

            Data data = notification.Body as Data;
            if (data==null)
            {
                return;
            }

            GlobalDataProxy globalDataProxy = (GlobalDataProxy)ApplicationFacade.Instance.RetrieveProxy(GlobalDataProxy.NAME);
            GlobalData GlobalData = globalDataProxy.GetGlobalData;

            switch (data.currencyType)
            {

                case CurrencyType.Gold:
                    GlobalData.GoldCup -= data.cupNumber;
                    ApplicationFacade.Instance.SendNotification(Notification.ChangeGlodCup, GlobalData.GoldCup);
                    break;
                case CurrencyType.Silver:
                    GlobalData.SilverCup -= data.cupNumber;
                    ApplicationFacade.Instance.SendNotification(Notification.ChangeSilverCup, GlobalData.SilverCup);
                    break;
                case CurrencyType.Bronze:
                    GlobalData.BronzeCup -= data.cupNumber;
                    ApplicationFacade.Instance.SendNotification(Notification.ChangeBronzeCup, GlobalData.BronzeCup);
                    break;
            }
        }
    }
}

