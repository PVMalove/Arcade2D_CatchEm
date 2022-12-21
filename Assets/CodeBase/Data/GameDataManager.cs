using System;
using CodeBase.Emoji;
using CodeBase.Logic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Data
{
    public class GameDataManager : MonoBehaviour
    {
        public static event Action<GameData> ScoresUpdated;

        [SerializeField] private GameData _gameData;
        [SerializeField] private IncreaseHealth _health;

        private void Start() => 
            UpdateScores();

        private void UpdateScores() => 
            ScoresUpdated?.Invoke(_gameData);

        private void OnEnable()
        {
            GoodEmoji.Scoring += Accrual;
            BadEmoji.Damage += TakeDamage;
        }

        private void TakeDamage() => 
            _health.TakeDamage();

        private void OnDisable() => 
            GoodEmoji.Scoring -= Accrual;

        private void Accrual()
        {
            int rand = Random.Range(20, 40);
            _gameData.Scores += rand;
            UpdateScores();
        }
    }
}