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
using UnityEngine.EventSystems;

namespace PureMVC.Tutorial
{
    public class SettingPanelMediator : Mediator
    {
        public static new string NAME = "SettingPanelMediator";

        public SettingPanelMediator(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
        {
        }

        protected SettingPanel GetSettingPanel
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
            GetSettingPanel.MusicSliderChangeAction = MusicSliderActionHandle;
            GetSettingPanel.SoundSliderChangeAction = SoundSliderActionHandle;

            GetSettingPanel.MusicSliderPointerDownAction = MusicSliderPointerDownActionHandle;
            GetSettingPanel.SoundSliderPointerDownAction = SoundSliderPointerDownActionHandle;
        }

        protected void MusicSliderPointerDownActionHandle(BaseEventData obj)
        {
            ManagerFacade.Instance.PlayMusic("Plop");
        }
        protected void SoundSliderPointerDownActionHandle(BaseEventData obj)
        {
            ManagerFacade.Instance.PlayMusic("Plop");
        }

        public override void OnRemove()
        {
            base.OnRemove();
            GetSettingPanel.CloseButtonAction = null;
            GetSettingPanel.BoyToggleAction = null;
            GetSettingPanel.GrilToggleAction = null;
            GetSettingPanel.MusicSliderChangeAction = null;
            GetSettingPanel.SoundSliderChangeAction = null;
        }

        protected void CloseButtonActionHandle()
        {
            //播放音效
            ManagerFacade.Instance.PlayMusic("Button");

            SendNotification(Notification.SettingToHomeCommond, GetSettingPanel, null);
            SendNotification(Notification.OpenHomePanel, null, null);
        }

        protected void BoyToggleActionHandle(bool tempBool)
        {
            if (tempBool)
            {
                //播放音效
                ManagerFacade.Instance.PlayMusic("Plop");

                GetSettingPanel.tempBoyOrGirl = 1;
            }
        }

        protected void GrilToggleActionHandle(bool tempBool)
        {
            if (tempBool)
            {
                //播放音效
                ManagerFacade.Instance.PlayMusic("Plop");

                GetSettingPanel.tempBoyOrGirl = 0;
            }
        }

        protected void MusicSliderActionHandle(float tempVolume)
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

        protected void SoundSliderActionHandle(float tempVolume)
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
            listNotificationInterests.Add("null");

            return listNotificationInterests.ToArray();
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case "null":
                    {
                        this.Log("null");
                        break;
                    }

                default:
                    break;
            }
        }
    }
}
