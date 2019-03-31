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
    public class SettingPanelView : MonoBehaviour
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
            InitSettingPanel();
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

        private void InitSettingPanel()
        {
            boyToggle = transform.Find("ToggleGroup/BoyToggle").GetComponent<Toggle>();
            grilToggle = transform.Find("ToggleGroup/GirlToggle").GetComponent<Toggle>();
            musicSlider = transform.Find("MusicImage/musicSlider").GetComponent<Slider>();
            soundSlider = transform.Find("SoundImage/soundSlider").GetComponent<Slider>();
            closeButton = transform.Find("closeButton").GetComponent<Button>();
        }

        private void RegisterComponent()
        {
            boyToggle.onValueChanged.AddListener(BoyToggleOnValueChanged);
            grilToggle.onValueChanged.AddListener(GrilToggleOnValueChanged);
        }

        private void UnRegisterComponent()
        {
            boyToggle.onValueChanged.RemoveAllListeners();
            grilToggle.onValueChanged.RemoveAllListeners();
        }

        private void RegisterCommond()
        {
            closeButton.onClick.AddListener(CloseButtonOnClick);
        }

        private void UnRegisterCommond()
        {
            closeButton.onClick.RemoveAllListeners();
        }

        private void RegisterMediator()
        {
            ApplicationFacade.Instance.RegisterMediator(new SettingPanelMediator(settingPanelViewName, this));
        }

        private void UnRegisterMediator()
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
