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
        public Image itemIcon = null;
        public Image priceIcon = null;
        public Button buyButton = null;
        public Text numberText = null;
        public GlobalData tempGlobalData = null;
        public CurrencyType currencyType;
        public int number;
        void Start()
        {
            itemBG = transform.Find("itemBG").GetComponent<Image>();
            priceIcon = transform.Find("priceIcon").GetComponent<Image>();
            itemIcon = transform.Find("itemBG/Icon").GetComponent<Image>();
            buyButton = transform.Find("BuyButton").GetComponent<Button>();
            numberText = transform.Find("priceIcon/numberText").GetComponent<Text>();

            GlobalDataProxy gloalDataProxy = ApplicationFacade.Instance.RetrieveProxy(GlobalDataProxy.NAME) as GlobalDataProxy;
            GlobalData gloalData = gloalDataProxy.GetGlobalData;
            tempGlobalData = gloalData;
            currencyType = (CurrencyType)UnityEngine.Random.Range(1, 4);

            priceIcon.sprite = ManagerFacade.Instance.LoadSprite(currencyType + "Cup");

            number = UnityEngine.Random.Range(20, 50);
            numberText.text = number.ToString();
            buyButton.onClick.AddListener(BuyButtonOnClick);

            ChangeTheme();
        }


        public void ChangeTheme()
        {
            int index = tempGlobalData.ThemeIndex;

            if (index == 1)
            {
                itemBG.sprite = Resources.Load<Sprite>("Sprite/IceItemBG_1");
                itemIcon.sprite = Resources.Load<Sprite>("Sprite/ItemBlue");
            }
            else if (index == 2)
            {
                itemBG.sprite = Resources.Load<Sprite>("Sprite/IceItemBG_4");
                itemIcon.sprite = Resources.Load<Sprite>("Sprite/ItemChoco");
            }
        }

        public void BuyButtonOnClick()
        {
            //播放音效
            ManagerFacade.Instance.PlayMusic("ComplimentText");

            ApplicationFacade.Instance.SendNotification(Notification.CostCupCommond, new CostCupCommond.Data(currencyType, int.Parse(numberText.text)));
        }
    }
}
