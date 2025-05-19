using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class UpgradeShop : MonoBehaviour
    {
        [SerializeField] private int Money;
        [SerializeField] private Text moneyText;
        [SerializeField] private BuyUpgrade[] sales;

        private void Start()
        {
            foreach (var slot in sales)
            {
                slot.Initialize();
                slot.transform.Find("Button (Legacy)").GetComponent<Button>().onClick.AddListener(UpdateMoney);
            }
            UpdateMoney();
        }

        public void UpdateMoney()
        {
            Money = MapComlition.Instance.TotalScore;
            Money -= Upgrades.GetTotalCost();
            moneyText.text = Money.ToString();
            
            foreach (var slot in sales)
            {
                slot.CheckCost(Money);
            }
        }
    }
}
