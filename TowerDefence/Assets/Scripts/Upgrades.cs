using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SpaceShooter;

namespace TowerDefence
{
    public class Upgrades : MonoSingleton<Upgrades>
    {
        public const string fileName = "upgrades.dat";
        [Serializable]
        private class UpgradeSave
        {
            public UpgradeAsset asset;
            public int level = 0;
        }

        private new void Awake()
        {
            base.Awake();
            Saver<UpgradeSave[]>.TryLoad(fileName, ref save);
        }

        [SerializeField] private UpgradeSave[] save;
        public static void BuyUpgrade(UpgradeAsset asset)
        {
            foreach (var upgrade in Instance.save)
            {
                if (upgrade.asset == asset)
                {
                    upgrade.level++;
                    Saver<UpgradeSave[]>.Save(fileName, Instance.save);
                }
            }
        }

        public static int GetTotalCost()
        {
            int result = 0;
            foreach (var upgrade in Instance.save)
            {
                for (int i = 0; i < upgrade.level; i++)
                {
                    result += upgrade.asset.costBuyLevel[i];
                }
            }

            return result;
        }

        public static int GetUpgradeLevel(UpgradeAsset asset)
        {
            foreach (var upgrade in Instance.save)
            {
                if (upgrade.asset == asset)
                {
                    return upgrade.level;
                }
            }
            return 0;
        }
    }
}
