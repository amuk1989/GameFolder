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
        
        public void LookAt(Vector3 position)
        {
            transform.LookAt(position);
        }

        public void Fire()
        {
            Instantiate(_bulletPrefab, _bulletSpawnTransform.position, Quaternion.identity).Throw(transform.forward * _power);
        }
    }
}