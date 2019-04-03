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
    public class HomePanel : Panel
    {
        public const string homePanelMediatorName = "HomePanelMediator";

        #region Component
        [SerializeField]
        private Button playButton = null;
        [SerializeField]
        private Button settingButton = null;
        [SerializeField]
        private CanvasGroup canvasGroup = null;

        public Action PlayAction = null;
        public Action SettingAction = null;

        #endregion

        #region 初始化相关
        protected sealed override void InitPanel()
        {
            playButton = transform.Find("playButton").GetComponent<Button>();
            settingButton = transform.Find("settingButton").GetComponent<Button>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        protected sealed override void RegisterComponent()
        {
            playButton.onClick.AddListener(PlayButtonOnClick);
            settingButton.onClick.AddListener(SettingButtonOnClick);
        }

        protected sealed override void UnRegisterComponent()
        {
            playButton.onClick.RemoveAllListeners();
            settingButton.onClick.RemoveAllListeners();
        }

        protected sealed override void RegisterCommond()
        {
            ApplicationFacade.Instance.RegisterCommand(Notification.OpenSettingCommond, () => new OpenSettingCommond());
            ApplicationFacade.Instance.RegisterCommand(Notification.PlayGameCommond, () => new PlayGameCommond());
        }

        protected sealed override void UnRegisterCommond()
        {
            ApplicationFacade.Instance.RemoveCommand(Notification.OpenSettingCommond);
            ApplicationFacade.Instance.RemoveCommand(Notification.PlayGameCommond);
        }

        protected sealed override void RegisterMediator()
        {
            ApplicationFacade.Instance.RegisterMediator(new HomePanelMediator(homePanelMediatorName, this));
        }

        protected sealed override void UnRegisterMediator()
        {
            ApplicationFacade.Instance.RemoveMediator(homePanelMediatorName);
        }

        #endregion


        public void PlayButtonOnClick()
        {
            PlayAction?.Invoke();
        }

        public void SettingButtonOnClick()
        {
            SettingAction?.Invoke();
        }

        public void OpenHomePanel()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public void CloseHomePanel()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}

