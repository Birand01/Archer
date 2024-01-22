using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;
    public bool willAttack;
    private static float AttackMovementSpeed => 0.25f + 0.1f * 50/*ArcheryGame.CurrentScore*/;
    private static float DelayBeforeAttack => 5f * Mathf.Pow(0.9f,1 /*ArcheryGame.CurrentScore*/);
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
    }


    private void Start()
    {
        StartCoroutine(IndicateAndAttackCoroutine());
    }
    private void OnEnable()
    {
        _agent.speed = AttackMovementSpeed;
    }

    private IEnumerator IndicateAndAttackCoroutine()
    {

        yield return new WaitForSeconds(DelayBeforeAttack);
       
        _agent.SetDestination(_player.position);
       
    }
}
