using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthbarConfig : MonoBehaviour
{

    //[SerializeField] private HealthBarSO healtBarSO;
    //[SerializeField] private SpriteRenderer sprite;
    //[SerializeField] private Image fillBarImage;
    //[SerializeField] private TMP_Text amount;

    private void OnEnable()
    {
       // SetUpHealthBar();
    }
    private void FixedUpdate()
    {
        LookAtCamera();
    }

    //private void SetUpHealthBar()
    //{
    //    sprite.sprite = healtBarSO.collectableImage;
    //   // amount.text = healtBarSO.amount.ToString();
    //    fillBarImage.color = healtBarSO.fillbarColor;
    //}
    private void LookAtCamera()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
