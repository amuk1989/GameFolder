using System;
using System.Threading.Tasks;
using Main;
using UniRx;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Character
{
    public class CarHealthComponent : MonoBehaviour, IVulnerable
    {
        [SerializeField] private int _maxHealthPoint;
        [SerializeField] private GameObject _explosion;

        private readonly ReactiveCommand _onDead = new();

        public IObservable<Unit> OnDead() => _onDead.AsObservable();

        public void TakeDamage(int damage)
        {
            _maxHealthPoint -= damage;
            if (_maxHealthPoint <= 0) DeadTask();
        }

        private async void DeadTask()
        {
            gameObject.layer = LayerMask.NameToLayer("PhysicsIgnore");
            _explosion.SetActive(true);
            await Task.Delay(TimeSpan.FromSeconds(0.75));
            _onDead.Execute();
        }
    }
}