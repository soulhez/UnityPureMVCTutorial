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
using LitJson;
using System.IO;

namespace PureMVC.Tutorial
{
    public class GlobalDataProxy : Proxy
    {
        public new static string NAME = "GlobalDataProxy";

        public GlobalDataProxy(string proxyName, object data = null) : base(proxyName, data)
        {
        }

        public GlobalData GetGlobalData
        {
            get
            {
                return Data as GlobalData;
            }
        }

        public override void OnRegister()
        {
            base.OnRegister();
            DeserializeData();
        }

        public override void OnRemove()
        {
            base.OnRemove();
            SerializeData();
        }

        public void SerializeData()
        {
            string jsonStr = JsonMapper.ToJson(GetGlobalData);

            this.Log(jsonStr);
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }
            File.WriteAllText(Application.streamingAssetsPath + "/" + "GlobalData.json", jsonStr);
        }

        public void DeserializeData()
        {
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }
            string jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/" + "GlobalData.json");

            this.Log(jsonStr);

            Data = JsonMapper.ToObject<GlobalData>(jsonStr);
        }
    }

    [Serializable]
    public class GlobalData
    {
        public int BoyOrGirl { get; set; }
        public double MusicVolume { get; set; }
        public double SoundVolume { get; set; }
        public int ThemeIndex { get; set; }
        public int ItemCount { get; set; }

        public int GoldCup { get; set; }
        public int SilverCup { get; set; }
        public int BronzeCup { get; set; }
    }
}

