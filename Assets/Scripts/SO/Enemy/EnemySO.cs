using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemySO : ScriptableObject
{
    public float goldGive;
    public float health;
    public float attackValue;  
    public float takenDamage;
    public float waitIdleTime;
    [Header("Navmesh Attributes")]
    public float attackStoppingDistance;
    public float angularSpeed;
    public float acceleration;
    public float speed;
}
