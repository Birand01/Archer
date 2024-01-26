using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounterManager : MonoBehaviour
{
    [SerializeField] private TMP_Text killCounterText;
    [SerializeField] internal int totalScore = 0;

    private void Awake()
    {
        killCounterText.text=totalScore.ToString();
    }
    private void OnEnable()
    {
        EnemyHealth.OnScoreCounterEvent += ScoreCounter;
    }
    private void OnDisable()
    {
        EnemyHealth.OnScoreCounterEvent -= ScoreCounter;

    }

    private void ScoreCounter(int killToAdd)
    {
        totalScore += killToAdd;
        killCounterText.text = totalScore.ToString();
    }
}
