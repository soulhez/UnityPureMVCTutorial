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
    public class CurrencyPanel : Panel
    {
        public const string currencyPanelMediatorName = "currencyPanelMediator";

        #region Component
        private Text goldText = null;
        private Text silverText = null;
        private Text bronzeText = null;
        #endregion

        protected override void InitPanel()
        {
            goldText = transform.Find("GoldCupBG/numberText").GetComponent<Text>();
            silverText = transform.Find("SilverCupBG/numberText").GetComponent<Text>();
            bronzeText = transform.Find("BronzeCupBG/numberText").GetComponent<Text>();
        }


        protected override void RegisterComponent()
        {

        }
        protected override void UnRegisterComponent()
        {

        }
        protected override void RegisterCommond()
        {

        }
        protected override void UnRegisterCommond()
        {

        }

        protected override void RegisterMediator()
        {
            ApplicationFacade.Instance.RegisterMediator(new CurrencyPanelMediator(currencyPanelMediatorName, this));
        }
        protected override void UnRegisterMediator()
        {
            ApplicationFacade.Instance.RemoveMediator(currencyPanelMediatorName);
        }
    }
}


