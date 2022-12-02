using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    bool isfacingRight;

    [SerializeField]
    float contador;

    [SerializeField]
    float tiempoCambio = 4.0F;

    void Update()
    {
        if (isfacingRight == true )
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            transform.localScale = new Vector3(3, 3, 3);

        }
        else {
            transform.position += Vector3.left * speed * Time.deltaTime;

            transform.localScale = new Vector3(-3,3,3);

        }

        contador -= Time.deltaTime;

        if (contador <= 0) {
            contador = tiempoCambio;
            isfacingRight = !isfacingRight;
        }
    }
}
