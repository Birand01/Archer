using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyConfiguration : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO;

    private void OnEnable()
    {
        SetUpEnemy();
    }



    private void SetUpEnemy()
    {
        this.gameObject.GetComponent<EnemyHealth>().goldGive = enemySO.goldGive;
        this.gameObject.GetComponent<EnemyHealth>().Health = enemySO.health;
        this.gameObject.GetComponent<NavMeshAgent>().speed = enemySO.speed;
        this.gameObject.GetComponentInChildren<AttackState>().attackValue = enemySO.attackValue;

    }
}
