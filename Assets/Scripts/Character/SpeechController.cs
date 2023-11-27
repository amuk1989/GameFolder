using System;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Character
{
    public class SpeechController : MonoBehaviour
    {
        [SerializeField] private AudioSource[] _towerDestroySpeech;

        private Tower5GHealth[] _towers;
        private void Start()
        {
            _towers = Object.FindObjectsOfType<Tower5GHealth>();

            foreach (var tower in _towers)
            {
                tower
                    .OnDead()
                    .Subscribe(_ =>
                    {
                        var randIndex = Random.Range(0, _towerDestroySpeech.Length);
                        _towerDestroySpeech[randIndex].Play();
                    })
                    .AddTo(this);
            }
        }
    }
}