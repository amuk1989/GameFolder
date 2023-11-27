using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    [SerializeField] private GameObject _soundEffect;
    
    public void SoundShow()
    {
        _soundEffect.SetActive(true);
    }
    
    public void SoundHide()
    {
        _soundEffect.SetActive(false);
    }
}
