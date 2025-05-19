using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter;
using System;

namespace TowerDefence
{
    public class MapComlition : MonoSingleton<MapComlition>
    {
        public const string fileName = "complition.dat";

        [Serializable]
        private class EpisodeScore
        {
            public Episode episode;
            public int score;
        }

        public static void SaveEpisodeResult(int levelScore)
        {
            if (Instance)
            {
                Instance.SaveResult(LevelSequenceController.Instance.CurrentEpisode, levelScore);
            } else
            {
                Debug.Log($"Episode complete with score {levelScore}");
            }
        }

        private void SaveResult(Episode currentEpisode, int levelScore)
        {
            foreach (var item in complitionData)
            {
                if (item.episode == currentEpisode)
                {
                    if (levelScore > item.score)
                    {
                        totalScore += levelScore - item.score;
                        item.score = levelScore;
                        Saver<EpisodeScore[]>.Save(fileName, complitionData);
                    }
                }
            }
        }

        [SerializeField] private EpisodeScore[] complitionData;
        private int totalScore;
        public int TotalScore {get {return totalScore;} }

        private new void Awake()
        {
            base.Awake();
            Saver<EpisodeScore[]>.TryLoad(fileName, ref complitionData);
            foreach (var episodeScore in complitionData)
            {
                totalScore += episodeScore.score;
            }
        }

        public int GetEpisodeScore(Episode m_episode)
        {
            foreach (var data in complitionData)
            {
                if (data.episode == m_episode)
                {
                    return data.score;
                }
            }
            return 0;
        }
    }
}
