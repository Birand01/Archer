using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldCounterManager : MonoBehaviour
{
    [SerializeField] private TMP_Text goldCounterText;
    [SerializeField] private float totalGoldAmount;
    private void OnEnable()
    {
        GoldInteraction.OnIncreaseGoldAmount += GoldCounter;
    }
    private void OnDisable()
    {
        GoldInteraction.OnIncreaseGoldAmount -= GoldCounter;

    }



    private void GoldCounter(float value)
    {
        totalGoldAmount += value;
        goldCounterText.text = totalGoldAmount.ToString();

    }
}
