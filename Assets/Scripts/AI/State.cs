using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State : MonoBehaviour
{
    protected Transform _player;
    protected NavMeshAgent agent;
    protected Animator animator;
    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public abstract State RunCurrentState();
}
