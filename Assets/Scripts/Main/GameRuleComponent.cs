using System;
using System.Threading.Tasks;
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
        [SerializeField] private GameObject _shield;

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
                        _deadCount++;
                        if (!WasAllTowerDestroyed()) return;
                        
                        Debug.Log("[GameRuleComponent] All destroyed");
                        _mainPower5G.MakeMortal();
                        _shield.SetActive(false);
                    })
                    .AddTo(this);
            }

            _mainPower5G
                .OnDead()
                .Subscribe(async _ =>
                {
                    await Task.Delay(5000);
                    SceneManager.LoadScene("StartMenu");
                })
                .AddTo(this);
        }

        private bool WasAllTowerDestroyed()
        {
            return _deadCount >= _tower5G.Length;
        }
    }
}