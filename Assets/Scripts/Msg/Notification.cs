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
    public static class Notification
    {
        public const string StartUp = "StartUp";
        public const string GameStart = "GameStart";
        public const string LoginSuccess = "LoginSuccess";
        public const string LoginSuccessProxy = "LoginSuccessProxy";
        public const string OpenSettingCommond = "OpenSettingCommond";
        public const string SaveSettingDataCommond = "SaveSettingDataCommond";
        public const string OpenHomePanel = "OpenHomePanel";
        public const string CloseHomePanel = "CloseHomePanel";
        public const string PlayGameCommond = "PlayGameCommond";
    }
}
