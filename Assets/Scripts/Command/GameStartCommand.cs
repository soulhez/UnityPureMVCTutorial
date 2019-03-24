using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;
using Custom.Log;

namespace PureMVC.Tutorial
{
    /// <summary>
    /// 游戏资源数据等初始化
    /// </summary>
    public class GameStartCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            this.Log("游戏启动成功，准备连接服务器获取数据");
            //获取相关数据
            //加载对应的UI
            GameObject canvas = GameObject.Find("Canvas");
           GameObject tempObj = UnityEngine.Object.Instantiate( Resources.Load<GameObject>("HomePanel"));
            tempObj.transform.SetParent(canvas.transform, false);
        }
    }
}

