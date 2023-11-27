using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OldWomanBehavior : MonoBehaviour
{
    [SerializeField] private Transform _hidePos;
    [SerializeField] private Transform _showPos;
    [SerializeField] private float _showDuration;

    public void Show()
    {
        transform.DOMove(_showPos.position, _showDuration);
    }
    
    public void Hide()
    {
        transform.DOMove(_hidePos.position, _showDuration);
    }
}
