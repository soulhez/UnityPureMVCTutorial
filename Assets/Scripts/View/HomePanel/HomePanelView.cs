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

namespace PureMVC.Tutorial
{
    public class HomePanelView : MonoBehaviour
    {
        public const string homePanelMediatorName = "HomePanelMediator";
        public const string homePanelMediatorExtensionName = "HomePanelMediatorExtension";

        public HomePanelMediator homePanelMediator = null;
        public HomePanelMediatorExtension homePanelMediatorExtension = null;

        void Start()
        {
            InitHomePanelView();
            Register();
            RegisterMediator();
        }

        #region 初始化相关
        private void InitHomePanelView()
        {

        }

        private void Register()
        {
        }

        private void UnRegister()
        {
        }

        private void RegisterMediator()
        {
            homePanelMediator = new HomePanelMediator(homePanelMediatorName, this);
            homePanelMediatorExtension = new HomePanelMediatorExtension(homePanelMediatorExtensionName, this);

            ApplicationFacade.Instance.RegisterMediator(homePanelMediator);
            ApplicationFacade.Instance.RegisterMediator(homePanelMediatorExtension);
        }

        private void UnRegisterMediator()
        {
            ApplicationFacade.Instance.RemoveMediator(homePanelMediatorName);
            ApplicationFacade.Instance.RemoveMediator(homePanelMediatorExtensionName);
        }


        public void OnDestroy()
        {
            UnRegister();
            UnRegisterMediator();
        }
        #endregion


    }
}

