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
    public class SettingToHomeCommond : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            SettingPanel settingPanelView = notification.Body as SettingPanel;
            if (settingPanelView == null)
            {
                this.LogError("settingPanelView为null，请检查");
                return;
            }

            GlobalDataProxy gloalDataProxy = ApplicationFacade.Instance.RetrieveProxy(GlobalDataProxy.NAME) as GlobalDataProxy;
            GlobalData gloalData = gloalDataProxy.GetGlobalData;
            gloalData.BoyOrGirl = settingPanelView.tempBoyOrGirl;
            gloalData.MusicVolume = settingPanelView.tempMusicVolume;
            gloalData.SoundVolume = settingPanelView.tempSoundVolume;
            gloalDataProxy.SerializeData();

            //设置声音相关
            ManagerFacade.Instance.SetMusicVolume((float)gloalData.MusicVolume);
            ManagerFacade.Instance.SetSoundVolume((float)gloalData.SoundVolume);
        }
    }
}
