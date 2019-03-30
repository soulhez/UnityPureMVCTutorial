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
    public class OpenSettingCommond : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            GameObject canvasObj = GameObject.Find("Canvas");
            GameObject tempObj = ResourcesManager.GetInstance.LoadPrefab("SettingPanel");
            tempObj.transform.SetParent(canvasObj.transform, false);
        }
    }
}
