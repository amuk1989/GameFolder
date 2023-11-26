using System;
using Character;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public class GameRuleComponent: MonoBehaviour
    {
        [SerializeField] private CarHealthComponent _carHealth;

        private void Start()
        {
            _carHealth
                .OnDead()
                .Subscribe(_ => SceneManager.LoadScene("StartMenu"))
                .AddTo(this);
        }
    }
}