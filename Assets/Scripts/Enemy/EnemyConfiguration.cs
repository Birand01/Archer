using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(StateManager))]
[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(BoxCollider))]
public class EnemyConfiguration : MonoBehaviour
{
   
    [SerializeField] private EnemySO enemySO;
    private LayerMask _layerMask;
  
    private void OnEnable()
    {
       
        SetUpEnemy();
        InitializeParameters();
    }

    private void InitializeParameters()
    {
        _layerMask.value = 9; 
    }

    private void SetUpEnemy()
    {
        this.gameObject.GetComponent<NavMeshAgent>().angularSpeed=enemySO.angularSpeed;
        this.gameObject.GetComponent<NavMeshAgent>().acceleration = enemySO.acceleration;
        this.gameObject.GetComponent<NavMeshAgent>().stoppingDistance = enemySO.attackStoppingDistance;
        this.gameObject.GetComponentInChildren<IdleState>().maxWaitIdleTime = enemySO.waitIdleTime;
        this.gameObject.GetComponent<EnemyHealth>().takenDamage = enemySO.takenDamage;
        this.gameObject.GetComponent<EnemyHealth>().goldGive = enemySO.goldGive;
        this.gameObject.GetComponent<EnemyHealth>().Health = enemySO.health;
        this.gameObject.GetComponent<NavMeshAgent>().speed = enemySO.speed;
        this.gameObject.GetComponentInChildren<AttackState>().attackValue = enemySO.attackValue;

    }
}
