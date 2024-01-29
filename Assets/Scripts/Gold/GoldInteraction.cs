using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldInteraction : InteractionBase
{
    internal float goldGive;
    public static event Action<float> OnIncreaseGoldAmount;
    public static event Action<SoundType, bool> OnGoldCollectSound;
    public static event Action<ParticleType, Vector3> OnGoldParticle;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnGoldParticle?.Invoke(ParticleType.Gold,collider.transform.position);
        OnGoldCollectSound?.Invoke(SoundType.GoldCollectSound, true);
        OnIncreaseGoldAmount?.Invoke(goldGive);
        gameObject.SetActive(false);
    }
}
