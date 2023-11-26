using System;
using UniRx;
using UnityEngine;

namespace Main
{
    public abstract class HealthBaseComponent : MonoBehaviour
    {
        [SerializeField] private bool _isImmortal;
        
        protected readonly ReactiveCommand _onDead = new();
        public bool IsImmortal { get; protected set; }
        public IObservable<Unit> OnDead() => _onDead.AsObservable();

        public void MakeMortal() => IsImmortal = false;

        protected virtual void Start()
        {
            IsImmortal = _isImmortal;
        }
    }
}