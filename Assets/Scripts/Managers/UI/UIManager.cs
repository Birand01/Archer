using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameLostUI;


    private void OnEnable()
    {
        PlayerHealth.OnGameOverEvent += RestartLevelUI;
    }

    private void OnDisable()
    {
        PlayerHealth.OnGameOverEvent -= RestartLevelUI;

    }





    private void RestartLevelUI()
    {
        gameLostUI.SetActive(true);
    }
    public void RestartLevelButton()
    {
        SceneManager.LoadScene(0);
    }
}
