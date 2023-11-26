using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Main;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Tower5GHealth : MonoBehaviour, IVulnerable
{
    [SerializeField] private float _explosionTime;
    [SerializeField] private GameObject _explosionCOntainer;
    [SerializeField] private GameObject _view;
    
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
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
        Destroy(gameObject);
    }
}
