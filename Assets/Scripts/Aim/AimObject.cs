using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimObject : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _carTransform;
    [Range(1f,10f)][SerializeField] private float _multiplier;
    
    private void Update()
    {
        var mouseDirection = _mainCamera.ScreenPointToRay(Input.mousePosition).direction;

        transform.position = _carTransform.position + mouseDirection * _multiplier;
    }
}
