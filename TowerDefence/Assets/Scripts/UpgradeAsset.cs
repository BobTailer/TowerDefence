using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu]
    public sealed class UpgradeAsset : ScriptableObject
    {
        [Header("Внешний вид")]
        public Sprite sprite;

        public int[] costBuyLevel = { 3 };
    }
}