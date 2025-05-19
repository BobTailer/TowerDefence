using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpaceShooter;
using System;
using UnityEngine.SocialPlatforms.Impl;

namespace TowerDefence
{
    public class MapLevel : MonoBehaviour
    {
        [SerializeField] private Episode m_episode;

        //[SerializeField] private RectTransform resultPanel;
        [SerializeField] private Image[] resultImages;

        public bool IsComplete { get { return gameObject.activeSelf && resultImages[0].color == Color.white; } }

        public void LoadLevel()
        {
            if (m_episode)
            {
                LevelSequenceController.Instance.StartEpisode(m_episode);
            }
        }

        public void Initialize()
        {
             var score = MapComlition.Instance.GetEpisodeScore(m_episode);
             for (int i = 0; i < score; i++)
             {
                 resultImages[i].color = Color.white;
             }
        }
    }
}
