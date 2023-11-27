using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Main;
using UnityEngine;

public class Tower5GHealth : HealthBaseComponent, IVulnerable
{
    [SerializeField] private float _explosionTime;
    [SerializeField] private GameObject _explosionCOntainer;
    [SerializeField] private GameObject _view;
    [SerializeField] private AudioSource _explosionSound;
    
    public int maxHealth = 100;
    private int currentHealth;

    protected override void Start()
    {
        base.Start();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (IsImmortal) return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            DestroyProcess();
        }
    }

    private async void DestroyProcess()
    {
        gameObject.layer = LayerMask.NameToLayer("PhysicsIgnore");
        _explosionCOntainer.gameObject.SetActive(true);
        await Task.Delay(TimeSpan.FromSeconds(_explosionTime/2f));
        _view.SetActive(false);
        await Task.Delay(TimeSpan.FromSeconds(_explosionTime/2f));
        _onDead.Execute();
        Destroy(gameObject);
    }
}
