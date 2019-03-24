using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;
using Custom.Log;

namespace PureMVC.Tutorial
{
    public class StartupCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            GameObject gameStart = GameObject.Find("GameStart");
            if (gameStart == null)
            {
                this.LogError("GameStart is Null,Please check it");
                return;
            }

            gameStart.AddComponent<ResourcesManager>();
            gameStart.AddComponent<SoundManager>();
        }
    }
}

