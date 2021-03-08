using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private List<EnemyController> Enemies;
    private Text EnemyQuantityText;
    private float time;
    private Text TimeText;
    private Image Health;

    void Start()
    {
        time = 70f;
        Enemies = FindObjectsOfType<EnemyController>().ToList();
        EnemyQuantityText = GameObject.Find("PointText").GetComponent<Text>();
        TimeText = GameObject.Find("TimerText").GetComponent<Text>();
        Health = GameObject.Find("HealthBar").GetComponent<Image>();
    }

    void Update()
    {
        ParseTime(time);
        time -= Time.deltaTime;
        EnemyQuantityText.text = Enemies.Count.ToString();
    }

    public void RemoveFromEnemyQuantity(EnemyController enemy)
    {
        Enemies.Remove(enemy);
    }

    void ParseTime(float time)
    {
        int minutes;
        int seconds;

        minutes = (int)time / 60;
        seconds = (int)time % 60;
        TimeText.text = ($"{minutes.ToString("00")}:{seconds.ToString("00")}");
    }

    public void ShowHealth(float healthPercent)
    {
        Health.fillAmount = healthPercent;
    }
}
