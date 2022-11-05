using CodeBase.Infrastructure.Pool;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Emoji
{
    public class GoodEmoji : MonoBehaviour
    {
        [SerializeField]private float _cost = 10f;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            Dispose();
        }

        private void Dispose()
        {
            ObjectPool.Despawn(gameObject,0.1f);
        }

        private void OnMouseDown()
        {
            Debug.Log("Cost" + _cost);
            Dispose();
        }


    }
}