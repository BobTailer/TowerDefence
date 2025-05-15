using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class TextUpdate : MonoBehaviour
    {
        public enum updateSource
        {
            Gold,
            Life
        }

        public updateSource source = updateSource.Gold;

        private Text m_text;

        void Start()
        {
            m_text = GetComponent<Text>();

            switch (source)
            {
                case updateSource.Gold: 
                    TDPlayer.GoldUpdateSubscribe(UpdateText);
                    break;

                case updateSource.Life:
                    TDPlayer.LifeUpdateSubscribe(UpdateText);
                    break;
            }
            
        }

        private void UpdateText(int money)
        {
            m_text.text = money.ToString();
        }
    }
}
