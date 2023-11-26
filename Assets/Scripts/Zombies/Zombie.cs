using System.Collections;
using System.Collections.Generic;
using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private ArcadeKart _arcadeKart;
    [SerializeField] private Animator _animator;
    
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    private void Update()
    {
        _agent.SetDestination(_arcadeKart.transform.position);

        _animator.SetBool(IsRunning, true);
    }
}
