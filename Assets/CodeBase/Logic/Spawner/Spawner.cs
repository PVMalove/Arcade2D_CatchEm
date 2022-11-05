using System.Collections;
using CodeBase.Infrastructure.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Logic.Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] public GameObject[] _goodEmojiPrefab;
        [SerializeField] private GameObject[] _badEmojiPrefab;

        [Header("Spawner setting")] [SerializeField]
        private float _leftPointSpawn;

        [SerializeField] private float _rightPointSpawn;
        [SerializeField] private float _secondsBetweenSpawn;

        private void Start()
        {
            StartCoroutine(EmojiSpawn());
        }

        private IEnumerator EmojiSpawn()
        {
            while (true)
            {
                float wanted = Random.Range(_leftPointSpawn, _rightPointSpawn);
                Vector3 position = new Vector3(wanted, transform.position.y);
                
                if(Random.Range(0,100) <= 80)
                    ObjectPool.Spawn(_goodEmojiPrefab[Random.Range(0, _goodEmojiPrefab.Length)], position,
                        Quaternion.identity);
                else
                    ObjectPool.Spawn(_badEmojiPrefab[Random.Range(0, _badEmojiPrefab.Length)], position,
                        Quaternion.identity);
                yield return new WaitForSeconds(_secondsBetweenSpawn);
            }
        }
    }
}