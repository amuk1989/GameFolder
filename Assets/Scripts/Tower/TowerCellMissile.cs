using System;
using Main;
using UnityEngine;

public class TowerCellMissile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _lifeTime;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _fire;

    [SerializeField] private Transform target;
    [SerializeField] public float missileSpeed = 5f;
    [SerializeField] public int damage = 30;

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
        if (collision.gameObject.CompareTag("TowerColliderToIgnore"))
            return;

        _rigidbody.AddForce(Vector3.zero);
        _rigidbody.isKinematic = true;

        Destroy(gameObject, 0.5f);
        missileSpeed = 0;

        _fire.SetActive(false);
        _explosion.SetActive(true);

        //TowerHealth targetHealth = other.GetComponent<TowerHealth>();

        //if (targetHealth != null)
        //{
        //    targetHealth.TakeDamage(damage);
        //}
    }
}