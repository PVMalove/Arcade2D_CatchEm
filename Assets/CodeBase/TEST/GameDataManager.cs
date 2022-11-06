using System;
using CodeBase.Emoji;
using UnityEngine;

namespace CodeBase.TEST
{
    public class GameDataManager : MonoBehaviour
    {
        public static event Action<GameData> ScoresUpdated;
        
        [SerializeField] private GameData _gameData;
        
        
        private void Start()
        {
            UpdateScores();
        }

        private void UpdateScores()
        {
            ScoresUpdated?.Invoke(_gameData);
        }
        
        
        /////

        private void OnEnable()
        {
            GoodEmoji.Scoring += Accrual;
        }
        private void OnDisable()
        {
            GoodEmoji.Scoring -= Accrual;
        }

        private void Accrual()
        {
            _gameData.Scores++;
        }
    }
}