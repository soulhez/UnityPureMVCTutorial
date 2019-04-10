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
        public const string HomePanelMediatorName = "HomePanelMediator";

        #region Component
        [SerializeField]
        private AnimatedButton playButton = null;
        [SerializeField]
        private AnimatedButton settingButton = null;
        [SerializeField]
        private CanvasGroup canvasGroup = null;

        public Action PlayAction = null;
        public Action SettingAction = null;
        #endregion

        #region 初始化相关
        protected sealed override void InitPanel()
        {
            playButton = transform.Find("playButton").GetComponent<AnimatedButton>();
            settingButton = transform.Find("settingButton").GetComponent<AnimatedButton>();
            canvasGroup = GetComponent<CanvasGroup>();
        }
        protected override void InitDataAndSetComponentState()
        {

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
            ApplicationFacade.Instance.RegisterCommand(Notification.HomeToSettingCommond, () => new HomeToSettingCommond());
            ApplicationFacade.Instance.RegisterCommand(Notification.HomeToStoreCommond, () => new HomeToStoreCommond());
        }

        protected sealed override void UnRegisterCommond()
        {
            ApplicationFacade.Instance.RemoveCommand(Notification.HomeToSettingCommond);
            ApplicationFacade.Instance.RemoveCommand(Notification.HomeToStoreCommond);
        }

        protected sealed override void RegisterMediator()
        {
            ApplicationFacade.Instance.RegisterMediator(new HomePanelMediator(HomePanelMediatorName, this));
        }

        protected sealed override void UnRegisterMediator()
        {
            ApplicationFacade.Instance.RemoveMediator(HomePanelMediatorName);
        }

        #endregion

        #region Event
        private void PlayButtonOnClick()
        {
            PlayAction?.Invoke();
        }

        private void SettingButtonOnClick()
        {
            SettingAction?.Invoke();
        }
        #endregion

        #region ComponentHandle
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

        #endregion
    }
}

