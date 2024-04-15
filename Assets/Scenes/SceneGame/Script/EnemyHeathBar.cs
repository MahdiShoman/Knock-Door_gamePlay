using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHeathBar : MonoBehaviour
{
    public GameObject enemyGameObject;
    public GameObject heathTextGameObject;


    private Slider slider;
    private Enemy enemy;
    private TextMeshProUGUI heathText;



    void Start()
    {
        slider = GetComponent<Slider>();
        enemy = enemyGameObject.GetComponent<Enemy>();
        heathText = heathTextGameObject.GetComponent<TextMeshProUGUI>();
        slider.maxValue = enemy.Health;
        slider.value = enemy.Health;
        heathText.text = enemy.Health.ToString();

    }

    void Update()
    {
        slider.value = enemy.Health;
        heathText.text = enemy.Health.ToString();
    }
}
