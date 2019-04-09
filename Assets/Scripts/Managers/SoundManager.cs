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
    public class SoundManager : Singleton<SoundManager>
    {
        public enum SoundType
        {
            Default,
            BackGround,
            Other
        }
        public Dictionary<string, AudioClip> audioClipDictionary = new Dictionary<string, AudioClip>();

        public AudioSource defaultAudioSource = null;
        public AudioSource backGroundAudioSource = null;
        public AudioSource otherAudioSource = null;

        void Start()
        {
            defaultAudioSource = gameObject.AddComponent<AudioSource>();
            backGroundAudioSource = gameObject.AddComponent<AudioSource>();
            otherAudioSource = gameObject.AddComponent<AudioSource>();
            defaultAudioSource.playOnAwake = false;
            backGroundAudioSource.playOnAwake = false;
            otherAudioSource.playOnAwake = false;
        }

        public void PlayMusic(string musicName, SoundType soundType= SoundType.Default)
        {
            if (!audioClipDictionary.ContainsKey(musicName))
            {
                AudioClip audioClip = Resources.Load<AudioClip>(musicName);
                audioClipDictionary.Add(musicName, audioClip);
            }
            if (soundType == SoundType.Default)
            {
                if (defaultAudioSource.isPlaying == true)
                {
                    defaultAudioSource.Stop();
                }
                defaultAudioSource.clip = audioClipDictionary[musicName];
                defaultAudioSource.Play();
            }
            else if (soundType == SoundType.BackGround)
            {
                if (backGroundAudioSource.isPlaying == true)
                {
                    backGroundAudioSource.Stop();
                }
                backGroundAudioSource.clip = audioClipDictionary[musicName];
                backGroundAudioSource.Play();
            }
            else if (soundType == SoundType.Other)
            {
                if (otherAudioSource.isPlaying == true)
                {
                    otherAudioSource.Stop();
                }
                otherAudioSource.clip = audioClipDictionary[musicName];
                otherAudioSource.Play();
            }
        }
    }
}

