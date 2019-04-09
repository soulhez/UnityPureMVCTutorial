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
    public class SettingPanelMediator : Mediator
    {
        public new static string NAME = "SettingPanelMediator";

        public SettingPanelMediator(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
        {
        }

        public SettingPanel GetSettingPanel
        {
            get
            {
                return ViewComponent as SettingPanel;
            }
        }
        public override void OnRegister()
        {
            base.OnRegister();
            GetSettingPanel.CloseButtonAction = CloseButtonActionHandle;
            GetSettingPanel.BoyToggleAction = BoyToggleActionHandle;
            GetSettingPanel.GrilToggleAction = GrilToggleActionHandle;
            GetSettingPanel.MusicSliderAction = MusicSliderActionHandle;
            GetSettingPanel.SoundSliderAction = SoundSliderActionHandle;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            GetSettingPanel.CloseButtonAction = null;
            GetSettingPanel.BoyToggleAction = null;
            GetSettingPanel.GrilToggleAction = null;
            GetSettingPanel.MusicSliderAction = null;
            GetSettingPanel.SoundSliderAction = null;
        }

        public void CloseButtonActionHandle()
        {
            SendNotification(Notification.LoadHomeCommond, GetSettingPanel, null);
            SendNotification(Notification.OpenHomePanel, null, null);
        }

        public void BoyToggleActionHandle(bool tempBool)
        {
            if (tempBool)
            {
                GetSettingPanel.tempBoyOrGirl = 1;
            }
        }

        public void GrilToggleActionHandle(bool tempBool)
        {
            if (tempBool)
            {
                GetSettingPanel.tempBoyOrGirl = 0;
            }
        }

        public void MusicSliderActionHandle(float tempVolume)
        {
            GetSettingPanel.tempMusicVolume = tempVolume;
            if (tempVolume <= 0)
            {
                GetSettingPanel.OpenMusicMuteBg();
            }
            else
            {
                GetSettingPanel.CloseMusicMuteBg();
            }
        }

        public void SoundSliderActionHandle(float tempVolume)
        {
            GetSettingPanel.tempSoundVolume = tempVolume;
            if (tempVolume <= 0)
            {
                GetSettingPanel.OpenSoundMuteBg();
            }
            else
            {
                GetSettingPanel.CloseSoundMuteBg();
            }
        }

        public override string[] ListNotificationInterests()
        {
            List<string> listNotificationInterests = new List<string>();
            listNotificationInterests.Add("123123");

            return listNotificationInterests.ToArray();
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case "123":
                    {
                        this.Log("123123123");
                        break;
                    }

                default:
                    break;
            }
        }
    }
}
