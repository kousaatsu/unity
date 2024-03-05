using System;
using UnityEngine;

namespace BulletSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        private float _currentLifeTime;
        private ObjectPool _owner;

        private void OnEnable()
        {
            _currentLifeTime = lifeTime;
        }

        public void SetOwner(ObjectPool objectPool)
        {
            _owner = objectPool;
        }
        void Update()
        {
            transform.position += transform.right * speed * Time.deltaTime;
            _currentLifeTime -= Time.deltaTime;
            if (_currentLifeTime <= 0)
            {
                _owner.ReturnToPool(gameObject);
            }
        }
    }
}
