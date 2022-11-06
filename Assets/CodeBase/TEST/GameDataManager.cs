using System;
using CodeBase.Emoji;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.TEST
{
    public class GameDataManager : MonoBehaviour
    {
        public static event Action<GameData> ScoresUpdated;

        [SerializeField] private GameData _gameData;
        [SerializeField] private IncreaseHealth _health;

        private void Start()
        {
            UpdateScores();
        }

        private void UpdateScores()
        {
            ScoresUpdated?.Invoke(_gameData);
        }

        private void OnEnable()
        {
            GoodEmoji.Scoring += Accrual;
            BadEmoji.Damage += TakeDamage;
        }

        private void TakeDamage()
        {
            Debug.Log("sss");
            _health.TakeDamage();
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