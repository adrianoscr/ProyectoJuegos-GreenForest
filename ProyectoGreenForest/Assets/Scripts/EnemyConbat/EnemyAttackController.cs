using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{

    [Header("Attack control")]

    [SerializeField]
    float damage = 10.0F;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player")) {

            DamageableController controller = collision.gameObject.GetComponent<DamageableController>();

            if (controller != null)
            {

                controller.TakeDamage(damage, collision.GetContact(0).normal);

            }
        }
        
    }

}
