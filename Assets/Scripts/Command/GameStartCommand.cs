using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;
using Custom.Log;

namespace PureMVC.Tutorial
{
    public class GameStartCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            this.Log("游戏启动成功，准备连接服务器获取数据");
        }
    }
}

