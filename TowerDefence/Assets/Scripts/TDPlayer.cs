using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter;
using System;
using UnityEngine.U2D;

namespace TowerDefence
{
    public class TDPlayer : Player
    {
        public static new TDPlayer Instance { get { return Player.Instance as TDPlayer;  } }

        private static event Action<int> OnGoldUpdate;
        public static void GoldUpdateSubscribe(Action<int> act)
        {
            OnGoldUpdate += act;
            act(Instance.m_gold);
        }
        public static event Action<int> OnLifeUpdate;
        public static void LifeUpdateSubscribe(Action<int> act)
        {
            OnLifeUpdate += act;
            act(Instance.NumLives);
        }

        [SerializeField] private int m_gold = 0;

        public void ChangeGold(int change)
        {
            m_gold += change;

            OnGoldUpdate(m_gold);
        }

        public void ReduceLife(int change)
        {
            TakeDamage(change);
            OnLifeUpdate(NumLives);
        }

        [SerializeField] private Tower m_towerPrefab;
        public void TryBuild(TowerAsset towerAsset, Transform buildSide)
        {
            ChangeGold(-towerAsset.goldCost);
            var tower = Instantiate(m_towerPrefab, buildSide.position, Quaternion.identity);
            tower.GetComponentInChildren<SpriteRenderer>().sprite = towerAsset.sprite;
            Destroy(buildSide.gameObject);
        }

        [SerializeField] private UpgradeAsset healthUpgrade;
        private new void Awake()
        {
            base.Awake();
            var level = Upgrades.GetUpgradeLevel(healthUpgrade);
            TakeDamage(-level * 5);
        }

        private void OnDestroy()
        {
            OnGoldUpdate = null;
            OnLifeUpdate = null;
        }
    }
}
