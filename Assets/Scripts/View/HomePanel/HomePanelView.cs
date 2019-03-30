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
    public class HomePanelView : MonoBehaviour
    {
        #region Mediator
        public const string homePanelMediatorName = "HomePanelMediator";
        public const string homePanelMediatorExtensionName = "HomePanelMediatorExtension";

        public HomePanelMediator homePanelMediator = null;
        public HomePanelMediatorExtension homePanelMediatorExtension = null;
        #endregion

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
        void Start()
        {
            InitHomePanel();
            Register();
            RegisterMediator();
        }

        #region 初始化相关
        private void InitHomePanel()
        {
            playButton = transform.Find("playButton").GetComponent<Button>();
            settingButton = transform.Find("settingButton").GetComponent<Button>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Register()
        {
            playButton.onClick.AddListener(PlayButtonOnClick);
            settingButton.onClick.AddListener(SettingButtonOnClick);
        }

        private void UnRegister()
        {
            playButton.onClick.RemoveAllListeners();
            settingButton.onClick.RemoveAllListeners();
        }

        private void RegisterMediator()
        {
            homePanelMediator = new HomePanelMediator(homePanelMediatorName, this);
            homePanelMediatorExtension = new HomePanelMediatorExtension(homePanelMediatorExtensionName, this);

            ApplicationFacade.Instance.RegisterMediator(homePanelMediator);
        }

        private void UnRegisterMediator()
        {
            ApplicationFacade.Instance.RemoveMediator(homePanelMediatorName);
        }


        public void OnDestroy()
        {
            UnRegister();
            UnRegisterMediator();
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

