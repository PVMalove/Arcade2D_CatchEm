using System.Collections;
using CodeBase.Infrastructure.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Logic.Spawner
{
    public class Spawner : MonoBehaviour
    {
        private const int ProbabilityRatio = 20;

        [SerializeField] private GameOver _gameOver;

        [SerializeField] public GameObject[] _goodEmojiPrefab;
        [SerializeField] private GameObject[] _badEmojiPrefab;

        [Header("Spawner setting")] [SerializeField]
        private float _leftPointSpawn;

        [SerializeField] private float _rightPointSpawn;
        [SerializeField] private float _secondsBetweenSpawn;

        private bool _isGame = true;

        private void Start()
        {
            StartCoroutine(EmojiSpawn());
        }

        private void OnEnable() =>
            _gameOver.Happend += StopSpawn;

        private void StopSpawn()
        {
            ObjectPool.DestroyAllPools();
            _gameOver.Happend -= StopSpawn;
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
            }
        }

        private static bool IsProbabilitiesOfBadEmoji() =>
            Random.Range(0, 100) <= ProbabilityRatio;

        private Vector3 GetPosition()
        {
            float wanted = Random.Range(_leftPointSpawn, _rightPointSpawn);
            Vector3 position = new Vector3(wanted, transform.position.y);
            return position;
        }
    }
}