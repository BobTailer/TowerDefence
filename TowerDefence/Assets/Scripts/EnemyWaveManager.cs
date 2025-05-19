using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class EnemyWaveManager : MonoBehaviour
    {
        [SerializeField] private Enemy m_EnemyPrefabs;
        [SerializeField] private Path[] paths;
        [SerializeField] private EnemyWave currentWave;

        public event Action OnAllWavesDead;
        
        private int activeEnemyCount = 0;

        private void RecordEnemyDead() 
        { 
            if (--activeEnemyCount == 0)
            {
                ForceNextWave();
            } 
        }

        private void Start()
        {
            currentWave.Prepare(SpawnEnemies);
        }

        private void SpawnEnemies()
        {
            foreach ((EnemyAsset asset, int count, int pathIndex) in currentWave.EnumerateSquads())
            {
                if (pathIndex < paths.Length)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var e = Instantiate(m_EnemyPrefabs, paths[pathIndex].StartArea.RandomInsideZone, Quaternion.identity);
                        e.OnEnd += RecordEnemyDead;
                        e.Use(asset);
                        e.GetComponent<TDPatrolController>().SetPath(paths[pathIndex]);
                        activeEnemyCount++;
                    }
                }
                else
                {
                    Debug.LogWarning($"Invalid pathIndax in {name}");
                }
            }

            currentWave = currentWave.PrepareNext(SpawnEnemies);
        }

        public void ForceNextWave()
        {
            if (currentWave)
            {
                TDPlayer.Instance.ChangeGold((int)currentWave.GetRemainingTime());
                SpawnEnemies();
            }
            else
            {
                if (activeEnemyCount == 0)
                    OnAllWavesDead?.Invoke();
            }
        }
    }
}
