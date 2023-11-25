using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Aim
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnTransform;
        [SerializeField] private uint _bulletCount;
        [SerializeField] private float _power;

        private Bullet _bullet = null;
        
        private void Start()
        {
            // _bullet = Instantiate(_bulletPrefab, _bulletSpawnTransform);
        }

        public void LookAt(Vector3 position)
        {
            transform.LookAt(position);
        }

        public void Fire()
        {
            Instantiate(_bulletPrefab).Throw(transform.forward * _power);
            // _bullet = Instantiate(_bulletPrefab, _bulletSpawnTransform);
        }
    }
}