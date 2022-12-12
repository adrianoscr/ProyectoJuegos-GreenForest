using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableController : MonoBehaviour
{

    [SerializeField]
    float maxHealth = 100.0F;

    float currentHealth;

    [SerializeField]
    float loseControllTime;

    Character2DController playerController;



    void Start()
    {

        playerController = GetComponent<Character2DController>();
        

        currentHealth = maxHealth;

        HealthPlayerController.Instance.OnDamage.AddListener(OnDamage);

    }

    public void TakeDamage(float damage)
    {

        currentHealth -= damage;
        float percentage = currentHealth * 100 / maxHealth;
        HealthPlayerController.Instance.OnDamage.Invoke(percentage);

    }

    public void TakeDamage(float damage, Vector2 position)
    {

        currentHealth -= damage;
        float percentage = currentHealth * 100 / maxHealth;

        HealthPlayerController.Instance.OnDamage.Invoke(percentage);

        playerController.rebound(position, loseControllTime);

        if (currentHealth <= 0) {
            HealthPlayerController.Instance.muerteEvento.Invoke();

            Destroy(gameObject);
        }

    }

    public void OnDamage(float percentage)
    {
        HealthPlayerController.Instance.UpdateHeal(percentage);
    }




}
