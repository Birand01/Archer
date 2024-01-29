using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ParticleType
{
    ArrowHit,EnemyDead,HealthBoost,TotalHealth,AttackRange,Gold
}
public class ParticleManager : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> particles = new List<ParticleSystem>();


    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            particles.Add(transform.GetChild(i).gameObject.GetComponent<ParticleSystem>());
        }
    }


    private void OnEnable()
    {
        GoldInteraction.OnGoldParticle += PlayParticle;
        PlayerHealth.OnTotalHealthBoostParticle += PlayParticle;
        PlayerHealth.OnHealthBoostParticle += PlayParticle;
        EnemyHealth.OnEnemyDeadParticle += PlayParticle;
        ArrowInteraction.OnArrowHitParticle += PlayParticle;   
        AttackRadius.OnAttackRangeParticle += PlayParticle;
    }

    private void OnDisable()
    {
        ArrowInteraction.OnArrowHitParticle -= PlayParticle;
        EnemyHealth.OnEnemyDeadParticle -= PlayParticle;
        PlayerHealth.OnHealthBoostParticle -= PlayParticle;
        PlayerHealth.OnTotalHealthBoostParticle -= PlayParticle;
        AttackRadius.OnAttackRangeParticle -= PlayParticle;
        GoldInteraction.OnGoldParticle -= PlayParticle;


    }
    private void PlayParticle(ParticleType typeOfParticle, Vector3 _position)
    {
        for (int i = 0; i < particles.Count; i++)
        {
            if (particles[i].GetComponent<ParticleConfig>().particleSO.particleType == typeOfParticle)
            {
                //Debug.Log(particles[i].name);
                particles[i].transform.position = _position;
                particles[i].Play();
                particles[i].Clear();
                return;
            }

        }

    }
}
