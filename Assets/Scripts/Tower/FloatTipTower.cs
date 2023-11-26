using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class FloatTower : MonoBehaviour
{
    private float _rotationSpeed = 30.0f;
    private float _minFloatRange = 0f;
    private float _maxFloatRange = 0.5f;

    private Vector3 rotationCenter;

    void Start()
    {
        rotationCenter = transform.position; // Set the rotation center to the initial position
    }

    void Update()
    {
        float randomOffsetY = Mathf.Lerp(_minFloatRange, _maxFloatRange, Mathf.PerlinNoise(Time.time, 0));

        float newY = rotationCenter.y + randomOffsetY;   

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        transform.RotateAround(rotationCenter, Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
