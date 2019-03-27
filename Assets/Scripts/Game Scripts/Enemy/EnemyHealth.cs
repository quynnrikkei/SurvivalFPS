using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    public Image HealthBar;
    
    public void Display_HealthEnemy(float health)
    {
        health /= 100;
        HealthBar.fillAmount = health;
    }
}
