using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
   private Animator animator;
    private readonly string attackAnimName = "Attack",deadAnimName="Dead";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeadEvent += PlayerDeadAnim;
        AttackRadius.OnAttackAnimationEvent += AttackAnimaton;
    }
    private void OnDisable()
    {
        AttackRadius.OnAttackAnimationEvent -= AttackAnimaton;
        PlayerHealth.OnPlayerDeadEvent -= PlayerDeadAnim;

    }

    private void AttackAnimaton()
    {
        animator.SetTrigger(attackAnimName);
    }
    private void PlayerDeadAnim(bool state)
    {
        animator.SetBool(deadAnimName,true);
    }
}
