using System;
using Main;
using UnityEngine;

namespace Aim
{
    public class Bullet : BaseBullet
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _lifeTime;
        [SerializeField] private GameObject _explosion;
        [SerializeField] private GameObject _fire;
        
        public void Throw(Vector3 power)
        {
            _rigidbody.AddForce(power, ForceMode.Impulse);
            Destroy(gameObject, _lifeTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            gameObject.layer = LayerMask.NameToLayer("PhysicsIgnore");
            
            SetDamage(collision);
            
            _rigidbody.AddForce(Vector3.zero);
            _rigidbody.isKinematic = true;
            
            Destroy(gameObject, 0.5f);
            
            _fire.SetActive(false);
            _explosion.SetActive(true);
        }
    }
}