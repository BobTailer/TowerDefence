using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    [RequireComponent(typeof(MapLevel))]
    public class BranchLevel : MonoBehaviour
    {
        [SerializeField] private MapLevel rootLevel;
        [SerializeField] private Text pointText;

        [SerializeField] private int needPoints = 3;

        public bool RootIsActive { get { return rootLevel.IsComplete; } }

        internal void TryActive()
        {
            gameObject.SetActive(rootLevel.IsComplete);
            
            if (needPoints > MapComlition.Instance.TotalScore)
            {
                pointText.text = needPoints.ToString();
            }
            else
            {
                pointText.transform.parent.gameObject.SetActive(false);
                GetComponent<MapLevel>().Initialize();
            }
        }
    }
}
