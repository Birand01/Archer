using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthBar", menuName = "ScriptableObjects/HealthBar", order = 0)]

public class HealthBarSO : ScriptableObject
{
    public Sprite collectableImage;
    public float amount;
    public Color fillbarColor;
}
