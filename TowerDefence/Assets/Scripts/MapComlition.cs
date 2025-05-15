using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter;
using System;

namespace TowerDefence
{
    public class MapComlition : MonoSingleton<MapComlition>
    {
        [Serializable]
        private class EpisodeScore
        {
            public Episode episode;
            public int score;
        }
        public static void SaveEpisodeResult(int levelScore)
        {
            Instance.SaveResult(LevelSequenceController.Instance.CurrentEpisode, levelScore);
        }
        [SerializeField] private EpisodeScore[] complitionData;
        public bool TryIndex(int id, out Episode episode, out int score)
        {
            if (id >= 0 && id < complitionData.Length)
            {
                episode = complitionData[id].episode;
                score = complitionData[id].score;

                return true;
            }
            episode = null;
            score = 0;
            return false;
        }

        private void SaveResult(Episode currentEpisode, int levelScore)
        {
            foreach (var item in complitionData)
            {
                if (item.episode == currentEpisode)
                {
                    if (levelScore > item.score) item.score = levelScore;
                }
            }
        }
    }
}
