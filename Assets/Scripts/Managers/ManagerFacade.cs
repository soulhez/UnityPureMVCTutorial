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

namespace PureMVC.Tutorial
{
    public class ManagerFacade : Singleton<ManagerFacade>
    {
        public ResourcesManager resourcesManager = null;
        public SoundManager soundManager = null;

        public static new  ManagerFacade Instance
        {
            get
            {
                return instance as ManagerFacade;
            }
        }
        protected override sealed void  Awake()
        {
            base.Awake();
            resourcesManager = GameObject.FindObjectOfType<ResourcesManager>();
            soundManager = GameObject.FindObjectOfType<SoundManager>();
        }

        #region SoundManager

        public void PlayMusic(string musicName, SoundManager.SoundType soundType = SoundManager.SoundType.Default)
        {
            soundManager.PlayMusic( musicName,  soundType);
        }

        public void SetMusicVolume(float volume)
        {
            soundManager.SetMusicVolume(volume);
        }

        public void SetSoundVolume(float volume)
        {
            soundManager.SetSoundVolume(volume);
        }
        #endregion

        #region ResourcesManager

        public GameObject LoadPrefab(string prefabName)
        {
          return  resourcesManager.LoadPrefab(prefabName);
        }

        public Sprite LoadSprite(string spriteName)
        {
            return resourcesManager.LoadSprite(spriteName);
        }

        public AudioClip LoadAudioClip(string audioClipName)
        {
            return resourcesManager.LoadAudioClip(audioClipName);
        }

        #endregion

    }
}
