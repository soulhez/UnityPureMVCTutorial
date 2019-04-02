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
    public class SettingPanel : Panel
    {

        #region Mediator

        public const string settingPanelViewName = "SettingPanelView";

        public SettingPanelMediator settingPanelMediator = null;

        #endregion

        #region Component
        [SerializeField]
        private Toggle boyToggle = null;
        [SerializeField]
        private Toggle grilToggle = null;
        [SerializeField]
        private Slider musicSlider = null;
        [SerializeField]
        private Slider soundSlider = null;
        [SerializeField]
        private Button closeButton = null;

        public Action CloseButtonAction = null;
        #endregion

        public int tempBoyOrGirl;
        public float tempMusicVolume;
        public float tempSoundVolume;

        void Start()
        {
            InitPanel();
            RegisterComponent();
            RegisterCommond();
            RegisterMediator();
        }

        public void OnDestroy()
        {
            UnRegisterComponent();
            UnRegisterMediator();
            UnRegisterCommond();
        }

        #region 初始化相关

        protected sealed override void InitPanel()
        {
            boyToggle = transform.Find("ToggleGroup/BoyToggle").GetComponent<Toggle>();
            grilToggle = transform.Find("ToggleGroup/GirlToggle").GetComponent<Toggle>();
            musicSlider = transform.Find("MusicImage/musicSlider").GetComponent<Slider>();
            soundSlider = transform.Find("SoundImage/soundSlider").GetComponent<Slider>();
            closeButton = transform.Find("closeButton").GetComponent<Button>();
        }

        protected sealed override void RegisterComponent()
        {
            boyToggle.onValueChanged.AddListener(BoyToggleOnValueChanged);
            grilToggle.onValueChanged.AddListener(GrilToggleOnValueChanged);
        }

        protected sealed override void UnRegisterComponent()
        {
            boyToggle.onValueChanged.RemoveAllListeners();
            grilToggle.onValueChanged.RemoveAllListeners();
        }

        protected sealed override void RegisterCommond()
        {
            closeButton.onClick.AddListener(CloseButtonOnClick);
        }

        protected sealed override void UnRegisterCommond()
        {
            closeButton.onClick.RemoveAllListeners();
        }

        protected sealed override void RegisterMediator()
        {
            ApplicationFacade.Instance.RegisterMediator(new SettingPanelMediator(settingPanelViewName, this));
        }

        protected sealed override void UnRegisterMediator()
        {
            ApplicationFacade.Instance.RemoveMediator(settingPanelViewName);
        }


        #endregion

        public void BoyToggleOnValueChanged(bool tempBool)
        {

        }

        public void GrilToggleOnValueChanged(bool tempBool)
        {

        }

        public void CloseButtonOnClick()
        {
            this.Log("关闭");
            CloseButtonAction?.Invoke();
            Destroy(gameObject);
        }

    }
}
