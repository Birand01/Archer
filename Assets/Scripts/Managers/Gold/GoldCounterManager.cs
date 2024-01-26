using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldCounterManager : MonoBehaviour
{
    [SerializeField] private TMP_Text goldCounterText;
    [SerializeField] internal float totalGoldAmount;

    private void Awake()
    {
        goldCounterText.text=totalGoldAmount.ToString();
    }
    private void OnEnable()
    {
        GoldInteraction.OnIncreaseGoldAmount += GoldCounter;
    }
    private void OnDisable()
    {
        GoldInteraction.OnIncreaseGoldAmount -= GoldCounter;

    }

   

    internal void GoldCounter(float value)
    {
        totalGoldAmount += value;
        totalGoldAmount=Mathf.Clamp(totalGoldAmount, 0f, float.MaxValue);
        goldCounterText.text =string.Format("{0}", totalGoldAmount.ToString());

    }
}
