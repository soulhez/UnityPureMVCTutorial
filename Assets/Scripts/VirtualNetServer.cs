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
    public class VirtualNetServer :Singleton<VirtualNetServer>
    {
        public GlobalData netServerGloalData = null;
        public void Awake()
        {
            base.Awake();
            netServerGloalData = new GlobalData();
        }
        void Start()
        {

        }

        public void RequestGloalData()
        {
            StartCoroutine(IERequestGloalData());
        }

        private IEnumerator IERequestGloalData()
        {
            yield return new WaitForSeconds(0.1f);
            ApplicationFacade.Instance.SendNotification(Notification.GetGlobalData, netServerGloalData, null);
        }

        public void RequestChangeGlodCup(int costCount)
        {
            StartCoroutine(IEChangeGlodCup(costCount));
        }

        private IEnumerator IEChangeGlodCup(int costCount)
        {
            yield return new WaitForSeconds(0.1f);
             netServerGloalData.GoldCup = netServerGloalData.GoldCup - costCount;
            ApplicationFacade.Instance.SendNotification(Notification.ChangeGlodCup, netServerGloalData.GoldCup, null);
        }

        public void RequestChangeSilverCup(int costCount)
        {
            StartCoroutine(IEChangeSilverCup(costCount));
        }

        private IEnumerator IEChangeSilverCup(int costCount)
        {
            yield return new WaitForSeconds(0.1f);
            netServerGloalData.SilverCup = netServerGloalData.SilverCup - costCount;
            ApplicationFacade.Instance.SendNotification(Notification.ChangeSilverCup, netServerGloalData.GoldCup, null);
        }

        public void RequestChangeBronzeCup(int costCount)
        {
            StartCoroutine(IEChangeBronzeCup(costCount));
        }

        private IEnumerator IEChangeBronzeCup(int costCount)
        {
            yield return new WaitForSeconds(0.1f);
            netServerGloalData.BronzeCup = netServerGloalData.BronzeCup - costCount;
            ApplicationFacade.Instance.SendNotification(Notification.ChangeGlodCup, netServerGloalData.BronzeCup, null);
        }

    }
}


