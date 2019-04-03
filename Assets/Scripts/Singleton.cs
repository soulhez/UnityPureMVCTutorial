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
    public class Singleton<T> : MonoBehaviour
    {
        static Singleton() { }
        protected Singleton() { }
        protected static volatile Singleton<T> instance = null;
        protected readonly object syncRoot = new object();
        protected static readonly object staticSyncRoot = new object();

        public static Singleton<T> Instance
        {
            get
            {
                return instance;
            }
        }

        public void Awake()
        {
            instance = this;
        }

    }
}

