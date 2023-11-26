using System;
using Main;
using UnityEngine;

public class Tower5GMissile : BaseBullet
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _lifeTime;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _fire;

    [SerializeField] private Transform target;
    [SerializeField] public float missileSpeed = 5f;

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
        gameObject.layer = LayerMask.NameToLayer("PhysicsIgnore");
        
        SetDamage(collision);
        
        _rigidbody.AddForce(Vector3.zero);
        _rigidbody.isKinematic = true;

        Destroy(gameObject, 0.5f);
        missileSpeed = 0;

        _fire.SetActive(false);
        _explosion.SetActive(true);
    }
}