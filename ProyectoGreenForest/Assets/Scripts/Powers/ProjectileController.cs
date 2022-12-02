using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    LayerMask whatIsEnemy;

    [SerializeField]
    LayerMask whatIsGround;

    [SerializeField]
    float speed = 2.0F;

    [SerializeField]
    float damage = 30.0F;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity =
               (transform.right * -1) * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (whatIsEnemy == (whatIsEnemy | (1 << collision.gameObject.layer)) || whatIsGround == (whatIsGround | (1 << collision.gameObject.layer)))
        {

            HealthController controller =
                collision.GetComponent<HealthController>();

            if (controller != null)
            {
                controller.TakeDamage(damage);
            }

            Destroy(gameObject);

        }

    }
}
