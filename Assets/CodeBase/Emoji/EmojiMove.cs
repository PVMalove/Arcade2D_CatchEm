using CodeBase.Logic.Spawner;
using UnityEngine;

namespace CodeBase.Emoji
{
    public class EmojiMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;

        private void OnEnable() =>
            Spawner.SpeedGame += BoostSpeed;

        private void Update() =>
            transform.Translate(Vector3.down * _speed * Time.deltaTime);

        private void BoostSpeed(float timeSpawn)
        {
            _speed += timeSpawn / 20;
            _speed = Mathf.Clamp(_speed, _minSpeed, _maxSpeed);
            if (_speed == _maxSpeed) 
                Spawner.SpeedGame -= BoostSpeed;
        }
    }
}