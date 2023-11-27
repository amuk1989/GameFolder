using System;
using System.Threading.Tasks;
using Main;
using UnityEngine;

namespace Character
{
    public class CarHealthComponent : HealthBaseComponent, IVulnerable
    {
        [SerializeField] private int _maxHealthPoint;
        [SerializeField] private GameObject _explosion;

        private bool _isDead = false;

        public void TakeDamage(int damage)
        {
            _maxHealthPoint -= damage;
            if (_maxHealthPoint <= 0 && !_isDead) DeadTask();
        }

        private async void DeadTask()
        {
            _isDead = true;
            gameObject.layer = LayerMask.NameToLayer("PhysicsIgnore");
            _explosion.SetActive(true);
            await Task.Delay(TimeSpan.FromSeconds(0.75));
            _onDead.Execute();
        }
    }
}