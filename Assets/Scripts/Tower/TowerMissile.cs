using System;
using UnityEngine;

namespace Aim
{
    public class TowerMissile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _lifeTime;
        [SerializeField] private GameObject _explosion;
        [SerializeField] private GameObject _fire;

        private Transform target;
        public float missileSpeed = 5f;
        public int damage = 10;

        public void SetTarget()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, missileSpeed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _rigidbody.AddForce(Vector3.zero);
            _rigidbody.isKinematic = true;

            Destroy(gameObject, 0.5f);

            _fire.SetActive(false);
            _explosion.SetActive(true);

            //TowerHealth targetHealth = other.GetComponent<TowerHealth>();

            //if (targetHealth != null)
            //{
            //    targetHealth.TakeDamage(damage);
            //}
        }
    }
}