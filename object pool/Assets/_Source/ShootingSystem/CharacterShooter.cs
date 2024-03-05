using BulletSystem;
using UnityEngine;

namespace ShootingSystem
{
    public class CharacterShooter : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        private ObjectPool _objectPool;

        public void Construct(ObjectPool objectPool)
        {
            _objectPool = objectPool;
        }

        public void Shoot()
        {
            if (_objectPool.TryGetFromPool(out GameObject bulletInstance))
            {
                bulletInstance.transform.position = firePoint.position;
            }
        }
    }
}
