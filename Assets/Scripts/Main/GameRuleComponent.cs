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
        [SerializeField] private Tower5GHealth[] _tower5G;
        [SerializeField] private Tower5GHealth _mainPower5G;

        private int _deadCount;
        
        private void Start()
        {
            _carHealth
                .OnDead()
                .Subscribe(_ => SceneManager.LoadScene("StartMenu"))
                .AddTo(this);

            foreach (var tower in _tower5G)
            {
                tower
                    .OnDead()
                    .Subscribe(_ =>
                    {
                        if (WasAllTowerDestroyed()) _mainPower5G.MakeMortal();
                    })
                    .AddTo(this);
            }

            _mainPower5G
                .OnDead()
                .Subscribe(_ => SceneManager.LoadScene("StartMenu"))
                .AddTo(this);
        }

        private bool WasAllTowerDestroyed()
        {
            return _deadCount >= _tower5G.Length;
        }
    }
}