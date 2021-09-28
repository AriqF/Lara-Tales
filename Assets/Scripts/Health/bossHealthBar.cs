using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossHealthBar : MonoBehaviour
{
    [SerializeField] private enemyHealth bossHealths;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = bossHealths.currentHealth / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = bossHealths.currentHealth / 10;
    }
}
