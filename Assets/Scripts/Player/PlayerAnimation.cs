using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
   private Animator animator;
    private readonly string attackAnimName = "Attack";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        AttackRadius.OnAttackAnimationEvent += AttackAnimaton;
    }
    private void OnDisable()
    {
        AttackRadius.OnAttackAnimationEvent -= AttackAnimaton;

    }

    private void AttackAnimaton()
    {
        animator.SetTrigger(attackAnimName);
    }
}
