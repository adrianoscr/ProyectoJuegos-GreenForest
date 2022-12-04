using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyController : MonoBehaviour
{

    [Header("General variables")]

    [SerializeField]
    float speed;

    [SerializeField]
    bool isfacingRight;

    [SerializeField]
    float contador;

    [SerializeField]
    float tiempoCambio = 4.0F;

    [Header("Chace variables")]

    float chaceSpeed;

    [SerializeField]
    Transform objective;

    [SerializeField]
    float distance;

    [SerializeField]
    float absoluteDistance;


    void Start()
    {
        contador = tiempoCambio;
    }

    void Update()
    {

        distance = objective.position.x - transform.position.x;

        //Remove - from distance.
        absoluteDistance = Mathf.Abs(distance);


        if (absoluteDistance > 5.0F)
        {

            timerMoving();

        }
        else {

            mustChace();

        }

    }

    void timerMoving(){

        if (isfacingRight == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            transform.localScale = new Vector3(3, 3, 3);

        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            transform.localScale = new Vector3(-3, 3, 3);

        }

        contador -= Time.deltaTime;

        if (contador <= 0)
        {
            contador = tiempoCambio;
            isfacingRight = !isfacingRight;
        }
    }


    void mustChace() {

        chaceSpeed = speed * 1.5F;

        transform.position = Vector2.MoveTowards(transform.position, objective.position, (chaceSpeed * Time.deltaTime));


        if (distance > 0.0F)
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        else
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }

    }


}
