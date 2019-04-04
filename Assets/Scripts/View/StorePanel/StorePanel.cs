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
        public const string storePanelMediatorName = "storePanelMediatorName";

        [SerializeField]
        private GameObject templateItem = null;
        [SerializeField]
        private Toggle coldThemeToggle = null;
        [SerializeField]
        private Toggle warmThemeToggle = null;
        [SerializeField]
        private GameObject boy = null;
        [SerializeField]
        private GameObject girl = null;

        public Action<bool> coldThemeToggleAction = null;
        public Action<bool> warmThemeToggleAction = null;

        protected override void InitPanel()
        {
            templateItem = transform.Find("ItemScrollView/Viewport/template/Item").gameObject;
            coldThemeToggle = transform.Find("ToggleGroup/coldThemeToggle").GetComponent<Toggle>();
            warmThemeToggle = transform.Find("ToggleGroup/warmThemeToggle").GetComponent<Toggle>();
            boy = transform.Find("people/boyImage").gameObject;
            girl = transform.Find("people/girlImage").gameObject;

            templateItem.SetActive(false);
        }

        protected override void RegisterComponent()
        {
            coldThemeToggle.onValueChanged.AddListener(ColdThemeOnValueChanged);
            warmThemeToggle.onValueChanged.AddListener(WarmThemeOnValueChanged);
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
            ApplicationFacade.Instance.RegisterMediator(new StorePanelMediator(storePanelMediatorName, this));
        }
        protected override void UnRegisterMediator()
        {
            ApplicationFacade.Instance.RemoveMediator(storePanelMediatorName);
        }





        public void ColdThemeOnValueChanged(bool tempIs)
        {
            coldThemeToggleAction?.Invoke(tempIs);
        }
        public void WarmThemeOnValueChanged(bool tempIs)
        {
            warmThemeToggleAction?.Invoke(tempIs);
        }
    }

}
