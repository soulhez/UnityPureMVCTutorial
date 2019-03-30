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
    public class ResourcesManager : Singleton<ResourcesManager>
    {
        public Dictionary<string, UnityEngine.Object> resourcesDictionary = new Dictionary<string, UnityEngine.Object>();

        public static ResourcesManager GetInstance
        {
            get
            {
                return instance as ResourcesManager;
            }
        }

        public GameObject LoadPrefab(string prefabName)
        {
            GameObject tempObj = null;
            if (!resourcesDictionary.ContainsKey(prefabName))
            {
                resourcesDictionary[prefabName] = Resources.Load<GameObject>("Prefab/" + prefabName);
            }
            tempObj = Instantiate(resourcesDictionary[prefabName] as GameObject);
            tempObj.name = prefabName;
            return tempObj;
        }

        public Sprite LoadSprite(string spriteName)
        {
            Sprite tempSprite = null;
            if (!resourcesDictionary.ContainsKey(spriteName))
            {
                resourcesDictionary[spriteName] = Resources.Load<GameObject>("Sprite/" + spriteName);
            }
            tempSprite = resourcesDictionary[spriteName] as Sprite;
            return tempSprite;
        }

        public AudioClip LoadAudioClip(string audioClipName)
        {
            AudioClip tempAudioClip = null;
            if (!resourcesDictionary.ContainsKey(audioClipName))
            {
                resourcesDictionary[audioClipName] = Resources.Load<GameObject>("AudioClip/" + audioClipName);
            }
            tempAudioClip = resourcesDictionary[audioClipName] as AudioClip;
            return tempAudioClip;
        }
    }
}

