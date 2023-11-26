using Aim;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Tower5GTipController : MonoBehaviour
{
    [SerializeField] public Tower5GMissile missilePrefab;
    [SerializeField] private Transform _bulletSpawnTransform;
    [SerializeField] public float shootingInterval = 3f;
    [SerializeField] public float missileSpeed = 10f;
    [SerializeField] public float detectionRange = 50000f;
    [SerializeField] private float _power = 2;

    private float timeSinceLastShot = 0f;

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootingInterval)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
    }

    private void Shoot()
    {
        Tower5GMissile missile = Instantiate(missilePrefab, _bulletSpawnTransform.position, Quaternion.identity);

        Tower5GMissile missileScript = missile.GetComponent<Tower5GMissile>();
        if (missileScript != null)
        {
            missileScript.SetTarget();
        }
    }
}
