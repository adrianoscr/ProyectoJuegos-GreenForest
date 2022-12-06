using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //indicador de que la puerta este o no abierta
    public bool isDoorOpen = false;

    //Indicador de la posicion de la puerta
    Vector3 doorClosedPos;
    Vector3 doorOpenPos;
    float doorSpeed = 10f;

     void Awake()
    {
        doorClosedPos = transform.position;
        doorOpenPos = new Vector3(transform.position.x,
            transform.position.y + 18.66f, transform.position.z);
    }


    //chequeo del estado de la puerta
    private void Update()
    {
        if (isDoorOpen) {

            OpenDoor();
        }
        else if (!isDoorOpen) {
            CloseDoor();
        }
    }

    void OpenDoor() {
        if (transform.position !=doorOpenPos) {
            //se mueve la puerta a una nueva pos
            //el primer idicador es donde se esta, luego a donde se va y por ultimo la velocidad de apertura
            transform.position = Vector3.MoveTowards(transform.position,
                doorOpenPos,doorSpeed*Time.deltaTime);
        }
    }

    void CloseDoor() { 
            if (transform.position != doorClosedPos)
            {
                //se mueve la puerta a una nueva pos
                //el primer idicador es donde se esta, luego a donde se va y por ultimo la velocidad de apertura
                transform.position = Vector3.MoveTowards(transform.position, 
                    doorClosedPos, doorSpeed * Time.deltaTime);
            }
        }
    
}
