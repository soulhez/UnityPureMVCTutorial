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
    public class StoreToHomeCommond : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            SendNotification(Notification.CloseCurrencyPanel, null, null);
            SendNotification(Notification.OpenHomePanel, null, null);
        }
    }
}

