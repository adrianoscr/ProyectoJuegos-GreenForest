using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100.00F;

    [SerializeField]
    float health = 0.0F;

    [SerializeField]
    public UnityEvent<GameObject, float, float> onDamage;

    [SerializeField]
    public UnityEvent<GameObject> onDie;

    void Start()
    {
        health = maxHealth;

    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            onDie.Invoke(gameObject);
        }

       onDamage.Invoke(gameObject, damage, health);

    }
}
