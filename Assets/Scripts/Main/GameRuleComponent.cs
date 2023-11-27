using System;
using System.Threading.Tasks;
using Character;
using DG.Tweening;
using KartGame.KartSystems;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main
{
    public class GameRuleComponent: MonoBehaviour
    {
        [SerializeField] private CarHealthComponent _carHealth;
        [SerializeField] private ArcadeKart _arcadeKart;
        [SerializeField] private Tower5GHealth[] _tower5G;
        [SerializeField] private Tower5GHealth _mainPower5G;
        [SerializeField] private GameObject _shield;
        [SerializeField] private SpriteRenderer _valve;
        [SerializeField] private Image _gameOverPanel;
        [SerializeField] private Image _winPanel;
        [SerializeField] private InputController _inputController;

        private int _deadCount = 0;
        private bool _isDead = false;
        private bool _isWin = false;
        
        private void Start()
        {
            _valve.DOFade(0, 2);
            _carHealth
                .OnDead()
                .Subscribe(async _ =>
                {
                    if (_winPanel.IsActive() || _isWin) return;
                    _isDead = true;
                    _inputController.StopInput();
                    _arcadeKart.SetCanMove(false);

                    await Task.Delay(2000);
                    _gameOverPanel.gameObject.SetActive(true);
                    _gameOverPanel.DOFade(1, 2);
                })
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
                    if (_gameOverPanel.IsActive() || _isDead) return;
                    _isWin = true;
                    
                    _carHealth.MakeImmortal();
                    await Task.Delay(5000);
                    
                    _winPanel.gameObject.SetActive(true);
                    _winPanel.DOFade(1, 2);
                })
                .AddTo(this);
        }

        private bool WasAllTowerDestroyed()
        {
            return _deadCount >= _tower5G.Length;
        }
    }
}