using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] protected float turretRotationSpeed;
    Vector3 finalLookDirection;
    private void OnEnable()
    {
        AttackRadius.OnAttackEvent += Aim;
    }

    private void OnDisable()
    {
        AttackRadius.OnAttackEvent -= Aim;

    }

    public virtual void Aim(IDamageable damageable)
    {

        var rotationSpeed = turretRotationSpeed * Time.deltaTime;
        Vector3 direction = damageable.GetTransform().position - transform.position;
        direction.y = 0f;
        finalLookDirection = Vector3.Lerp(finalLookDirection, direction, rotationSpeed);
        transform.rotation = Quaternion.LookRotation(finalLookDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, finalLookDirection);
    }
}
