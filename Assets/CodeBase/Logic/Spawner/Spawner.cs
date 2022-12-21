using System;
using System.Collections;
using CodeBase.Infrastructure.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Logic.Spawner
{
    public class Spawner : MonoBehaviour
    {
        private const int ProbabilityRatio = 20;

        [SerializeField] public GameObject[] _goodEmojiPrefab;
        [SerializeField] private GameObject[] _badEmojiPrefab;

        [Header("Spawner setting")] [SerializeField]
        private float _leftPointSpawn;

        [SerializeField] private float _rightPointSpawn;

        [Header("Spawner timer setting")] 
        [SerializeField] private float _secondsBetweenSpawn;
        [SerializeField] private float _nonBoostSpawnTimer;
        [SerializeField] private float _boostSpawnTimer;
        [SerializeField] private float _minSecondsBetweenSpawn;
        [SerializeField] private float _maxSecondsBetweenSpawn;
        [SerializeField] private float _delayBoost;

        public static event Action<float> SpeedGame; 

        private bool _isGame = true;

        private void Start()
        {
            StartCoroutine(EmojiSpawn());
            StartCoroutine(SpawnIntervalCounter());
        }

        private void OnEnable() =>
            GameOver.GameLost += StopSpawn;

        private void StopSpawn()
        {
            ObjectPool.DestroyAllPools();
            GameOver.GameLost -= StopSpawn;
            _isGame = false;
        }

        private IEnumerator EmojiSpawn()
        {
            while (_isGame)
            {
                if (IsProbabilitiesOfBadEmoji())
                    ObjectPool.Spawn(_badEmojiPrefab[Random.Range(0, _badEmojiPrefab.Length)], GetPosition(),
                        Quaternion.identity);
                else
                    ObjectPool.Spawn(_goodEmojiPrefab[Random.Range(0, _goodEmojiPrefab.Length)], GetPosition(),
                        Quaternion.identity);

                yield return new WaitForSeconds(_secondsBetweenSpawn);
                SpeedGame?.Invoke(_secondsBetweenSpawn);
            }
        }

        private static bool IsProbabilitiesOfBadEmoji() =>
            Random.Range(0, 100) <= ProbabilityRatio;

        private Vector3 GetPosition()
        {
            float wanted = Random.Range(_leftPointSpawn, _rightPointSpawn);
            Vector3 position = new(wanted, transform.position.y);
            return position;
        }

        private IEnumerator SpawnIntervalCounter()
        {
            yield return new WaitForSeconds(_nonBoostSpawnTimer);

            while (_isGame)
            {
                yield return new WaitForSeconds(_delayBoost);
                _secondsBetweenSpawn -= _boostSpawnTimer;
                _secondsBetweenSpawn =
                    Math.Clamp(_secondsBetweenSpawn, _minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);
            }
        }
    }
}