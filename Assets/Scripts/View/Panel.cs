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
    public abstract class Panel : MonoBehaviour
    {
      protected virtual  void Start()
        {
            InitPanel();
            RegisterComponent();
            RegisterCommond();
            RegisterMediator();
        }

        protected abstract void InitPanel();
        protected abstract void RegisterComponent();
        protected abstract void RegisterCommond();
        protected abstract void RegisterMediator();

        public virtual void OnDestroy()
        {
            UnRegisterComponent();
            UnRegisterCommond();
            UnRegisterMediator();
        }
        protected abstract void UnRegisterComponent();
        protected abstract void UnRegisterCommond();
        protected abstract void UnRegisterMediator();

    }
}


