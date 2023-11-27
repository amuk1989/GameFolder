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
        [SerializeField] private HealthBar _healthBar;
        private int _currentHealthPoint;


        protected override void Start()
        {
            base.Start();
            _currentHealthPoint = _maxHealthPoint;
        }

        private bool _isDead = false;

        public void TakeDamage(int damage)
        {
            _currentHealthPoint -= damage;

            _healthBar.UpdateHealthBar(_maxHealthPoint, _currentHealthPoint);

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