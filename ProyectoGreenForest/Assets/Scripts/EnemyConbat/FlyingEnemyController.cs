using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    [SerializeField]
    Transform objective;

    [SerializeField]
    float speed;

    [SerializeField]
    bool mustChaseYou;

    [SerializeField]
    float distance;

    [SerializeField]
    float absoluteDistance;


    void Update()
    {

        distance = objective.position.x - transform.position.x;

        //Remove - from distance.
        absoluteDistance = Mathf.Abs(distance);

        if (absoluteDistance < 5)
        {
            mustChaseYou = true;
        }
        else {
            mustChaseYou = false;
        }


        if (mustChaseYou == true) {
            transform.position = Vector2.MoveTowards(transform.position, objective.position, (speed * Time.deltaTime));

            if (distance > 0.0F)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }


    }
}
