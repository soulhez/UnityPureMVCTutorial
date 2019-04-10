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
            this.Log("游戏启动成功");

            GameObject canvas = GameObject.Find("Canvas");
            GameObject tempObj = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Prefab/HomePanel"));
            tempObj.name = "HomePanel";
            tempObj.transform.SetParent(canvas.transform, false);
            tempObj.AddComponent<HomePanel>();
            //获取数据
            GlobalDataProxy gloalDataProxy = ApplicationFacade.Instance.RetrieveProxy(GlobalDataProxy.NAME) as GlobalDataProxy;
            GlobalData gloalData = gloalDataProxy.GetGlobalData;
            //初始化声音
            ManagerFacade.Instance.SetMusicVolume((float)gloalData.MusicVolume);
            ManagerFacade.Instance.SetMusicVolume((float)gloalData.SoundVolume);
            ManagerFacade.Instance.PlayMusic("Background Music", SoundManager.SoundType.BackGround);

        }
    }
}

