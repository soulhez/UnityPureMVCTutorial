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

namespace PureMVC.Tutorial
{
    public class ItemComponent : MonoBehaviour
    {
        public Image itemBG = null;
        public Image icon = null;
        public Button buyButton = null;
        public Text numberText = null;
        public GlobalData tempGlobalData = null;
        void Start()
        {
            itemBG = transform.Find("itemBG").GetComponent<Image>();
            icon = transform.Find("itemBG/Icon").GetComponent<Image>();
            buyButton = transform.Find("BuyButton").GetComponent<Button>();
            numberText = transform.Find("priceIcon/numberText").GetComponent<Text>();

            ChangeTheme();
        }

        public void SetData(GlobalData globalData)
        {
            tempGlobalData = globalData;
        }

        public void ChangeTheme()
        {
            int index = tempGlobalData.ThemeIndex;

            if (index == 1)
            {
                itemBG.sprite = Resources.Load<Sprite>("Sprite/IceItemBG_1");
                icon.sprite = Resources.Load<Sprite>("Sprite/ItemBlue");
            }
            else if (index == 2)
            {
                itemBG.sprite = Resources.Load<Sprite>("Sprite/IceItemBG_4");
                icon.sprite = Resources.Load<Sprite>("Sprite/ItemChoco");
            }

        }
    }
}
