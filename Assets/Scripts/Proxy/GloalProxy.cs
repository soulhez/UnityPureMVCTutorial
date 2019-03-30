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
    public class GloalDataProxy : Proxy
    {
        public GloalDataProxy(string proxyName, object data = null) : base(proxyName, data)
        {
        }

        public override void OnRegister()
        {
            base.OnRegister();
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }
    }

    public class GloalData
    {
        public int BoyOrGirl { get; set; }
        public float MusicVolume { get; set; }
        public float SoundVolume { get; set; }
        public int ThemeIndex { get; set; }

    }
}

