using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class TowerBuyControl : MonoBehaviour
    {

        [SerializeField] private TowerAsset m_ta;
        [SerializeField] private Text m_text;
        [SerializeField] private Button m_button;
        [SerializeField] private Transform buildSide;

        public void  SetBuildSite(Transform value) 
        {
            buildSide = value;
        }

        private void Start()
        {
            TDPlayer.GoldUpdateSubscribe(GoldStatusCheck);
            m_text.text = m_ta.goldCost.ToString();
            m_button.GetComponent<Image>().sprite = m_ta.GUIsprite;
        }

        private void GoldStatusCheck(int gold)
        {
            if (gold >= m_ta.goldCost != m_button.interactable)
            {
                m_button.interactable = !m_button.interactable;
                m_text.color = m_button.interactable ? new Color(255, 183, 0) : Color.red;
            }
        }

        public void Buy()
        {
            TDPlayer.Instance.TryBuild(m_ta, buildSide);
            BuildSite.HideControls();
        }
    }
}

