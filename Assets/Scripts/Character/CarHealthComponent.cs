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