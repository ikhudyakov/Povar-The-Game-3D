using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int Health;
    private TextMesh HealthText;
    private UIController uIController;
    public delegate void EnemyHandler(EnemyController enemy);
    public event EnemyHandler Notify;

    private void Start()
    {
        uIController = FindObjectOfType<UIController>();
        HealthText = GetComponentInChildren<TextMesh>();
        HealthText.text = Health.ToString();
        Notify += uIController.RemoveFromEnemyQuantity;
    }
    internal void GetDamage(int damage)
    {
        Health -= damage;
        HealthText.text = Health.ToString();
    }

    private void Update()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Notify.Invoke(this);
        Notify -= uIController.RemoveFromEnemyQuantity;
    }
}