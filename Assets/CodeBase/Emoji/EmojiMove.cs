using UnityEngine;

namespace CodeBase.Emoji
{
    public class EmojiMove : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;

        private void Update() => 
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}