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
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Update()
    {
        var isAttacked = (transform.position - _arcadeKart.transform.position).sqrMagnitude < 2f;
        if (isAttacked)
        {
            _animator.SetTrigger(Attack);
            _agent.velocity = Vector3.zero;
        }
        else
        {
            _agent.SetDestination(_arcadeKart.transform.position);
        }

        _animator.SetBool(IsRunning, !isAttacked);
    }
}
