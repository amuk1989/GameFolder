using System;
using UniRx;
using UnityEngine;

namespace Main
{
    public abstract class HealthBaseComponent : MonoBehaviour
    {
        [SerializeField] private bool _isImmortal;
        
        protected readonly ReactiveCommand _onDead = new();
        protected bool IsImmortal { get; set; }
        public IObservable<Unit> OnDead() => _onDead.AsObservable();

        public void MakeMortal() => IsImmortal = false;

        protected virtual void Start()
        {
            IsImmortal = _isImmortal;
        }
    }
}