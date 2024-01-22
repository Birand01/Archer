using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyState
{
    Idle,
    Chase,
    Attack
}
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private Transform _player;
    [SerializeField] private float attackRange;
    private EnemyState currentState=EnemyState.Idle;
    private static float AttackMovementSpeed => 0.25f + 0.1f * 50/*ArcheryGame.CurrentScore*/;
    private static float DelayBeforeAttack => 5f * Mathf.Pow(0.9f,10 /*ArcheryGame.CurrentScore*/);
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        UpdateState();
      
    }
    private void OnEnable()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void UpdateState()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case EnemyState.Idle:
                StartCoroutine(HandleIdleState());
                break;
            case EnemyState.Chase:
                StartCoroutine(HandleChaseState());
                break;
            case EnemyState.Attack:
                StartCoroutine(HandleAttackState());
                break;
            default:
                break;
        }
    }

    private IEnumerator HandleIdleState()
    {
        yield return new WaitForSeconds(DelayBeforeAttack);
        SetState(EnemyState.Chase);
    }


   
    private IEnumerator HandleChaseState()
    {

       
        _agent.SetDestination(_player.position);
        _agent.transform.LookAt(_player.position);
        float distance = Vector3.Distance(transform.position ,_player.position);
        Debug.Log(distance);
        if (_agent.remainingDistance<=_agent.stoppingDistance)
        {
            SetState(EnemyState.Attack);
        }
        yield return new WaitForSeconds(0.1f);
    }
    private IEnumerator HandleAttackState()
    {
        yield return null;
        _agent.isStopped = true;
        Debug.Log("ATTACK");
    }
    private void SetState(EnemyState newState)
    {
        _animator.CrossFadeInFixedTime(newState.ToString(), 0.5f);
        _agent.speed = AttackMovementSpeed;
        if (currentState==newState)
        {
            return;
        }
        currentState = newState;
        OnStateChanged(newState);
    }

    private void OnStateChanged(EnemyState newState)
    {
        UpdateState();
    }
    
}
