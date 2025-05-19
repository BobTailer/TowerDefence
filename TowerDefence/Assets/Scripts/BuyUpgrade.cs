using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class BuyUpgrade : MonoBehaviour
    {
        [SerializeField] private UpgradeAsset asset;
        [SerializeField] private Image upgradeIcon;
        [SerializeField] private Text level, cost;
        [SerializeField] private Button buyButton;

        private int costNum = 0;

        public void Initialize ()
        {
            upgradeIcon.sprite = asset.sprite;
            var savedLevel = Upgrades.GetUpgradeLevel(asset);

            if (savedLevel >= asset.costBuyLevel.Length)
            {
                level.text = $"Lvl:{savedLevel + 1} (MAX)";
                buyButton.interactable = false;
                buyButton.transform.Find("Image (1)").gameObject.SetActive(false);
                buyButton.transform.Find("Text (Legacy)").gameObject.SetActive(false);
                cost.text = "X";
                costNum = int.MaxValue;
            }
            else
            {
                level.text = $"Lvl:{savedLevel + 1}";
                cost.text = asset.costBuyLevel[savedLevel].ToString();
                costNum = asset.costBuyLevel[savedLevel];
            }
        }

        public void Buy()
        {
            Upgrades.BuyUpgrade(asset);
            Initialize();
        }

        public void CheckCost(int money)
        {
            buyButton.interactable = money >= costNum;
        }
    }
}
