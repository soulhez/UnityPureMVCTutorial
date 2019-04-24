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
    public class GameStart : MonoBehaviour
    {
        private void Awake()
        {
            UnityEngine.Random.InitState((int)DateTime.Now.Ticks);

            ApplicationFacade.Instance.StartUpHandle();
        }
        void Start()
        {
            ApplicationFacade.Instance.GameStartHandle();
        }

        private void OnDestroy()
        {
            ApplicationFacade.Instance.RemoveProxy(GlobalDataProxy.NAME);
        }

        private void OnDisable()
        {
    
        }

        private void OnEnable()
        {
     
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GlobalDataProxy globalDataProxy = (GlobalDataProxy)applicationFacade.RetrieveProxy(GlobalDataProxy.NAME);
                globalDataProxy.SerializeData();
                this.Log("按键1");
            }
        }
    }
}
