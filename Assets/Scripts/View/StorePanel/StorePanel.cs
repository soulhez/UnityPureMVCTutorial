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
    public class StorePanel :Panel
    {
        public const string StorePanelMediatorName = "StorePanelMediator";

        #region Component
        [SerializeField]
        public GameObject templateItem = null;
        [SerializeField]
        private Toggle coldThemeToggle = null;
        [SerializeField]
        private Toggle warmThemeToggle = null;
        [SerializeField]
        public GameObject boy = null;
        [SerializeField]
        public GameObject girl = null;
        [SerializeField]
        public Transform target = null;
        [SerializeField]
        private AnimatedButton closeButton = null;

        public Action<bool> coldThemeToggleAction = null;
        public Action<bool> warmThemeToggleAction = null;
        public Action CloseButtonAction = null;
        #endregion

        #region Data
        public List<ItemComponent> itemComponents = new List<ItemComponent>();
        #endregion

        protected override void InitPanel()
        {
            templateItem = transform.Find("ItemScrollView/Viewport/template/Item").gameObject;
            coldThemeToggle = transform.Find("ToggleGroup/coldThemeToggle").GetComponent<Toggle>();
            warmThemeToggle = transform.Find("ToggleGroup/warmThemeToggle").GetComponent<Toggle>();
            boy = transform.Find("people/boyImage").gameObject;
            girl = transform.Find("people/girlImage").gameObject;
            target = transform.Find("ItemScrollView/Viewport/Content");
            closeButton = transform.Find("closeButton").GetComponent<AnimatedButton>();
            templateItem.SetActive(false);
        }

        protected override void InitDataAndSetComponentState()
        {
            GlobalDataProxy gloalDataProxy = ApplicationFacade.Instance.RetrieveProxy(GlobalDataProxy.NAME) as GlobalDataProxy;
            GlobalData gloalData = gloalDataProxy.GetGlobalData;
            if (gloalData.ThemeIndex == 1)
            {
                coldThemeToggle.isOn = true;
            }
            else
            {
                warmThemeToggle.isOn = true;
            }

            if (gloalData.BoyOrGirl == 0)
            {
                girl.SetActive(true);
                boy.SetActive(false);
            }
            else
            {
                girl.SetActive(false);
                boy.SetActive(true);
            }
        }

        protected override void RegisterComponent()
        {
            coldThemeToggle.onValueChanged.AddListener(ColdThemeOnValueChanged);
            warmThemeToggle.onValueChanged.AddListener(WarmThemeOnValueChanged);
            closeButton.onClick.AddListener(CloseOnClick);
        }

        protected override void UnRegisterComponent()
        {
            coldThemeToggle.onValueChanged.RemoveAllListeners();
            warmThemeToggle.onValueChanged.RemoveAllListeners();
            closeButton.onClick.RemoveAllListeners();
        }

        protected override void RegisterCommond()
        {

        }
        protected override void UnRegisterCommond()
        {

        }

        protected override void RegisterMediator()
        {
            ApplicationFacade.Instance.RegisterMediator(new StorePanelMediator(StorePanelMediatorName, this));
        }
        protected override void UnRegisterMediator()
        {
            ApplicationFacade.Instance.RemoveMediator(StorePanelMediatorName);
        }

        public void ColdThemeOnValueChanged(bool tempIs)
        {
            coldThemeToggleAction?.Invoke(tempIs);
        }
        public void WarmThemeOnValueChanged(bool tempIs)
        {
            warmThemeToggleAction?.Invoke(tempIs);
        }

        public void CloseOnClick()
        {
            CloseButtonAction?.Invoke();
            Destroy(gameObject);
        }
    }

}
