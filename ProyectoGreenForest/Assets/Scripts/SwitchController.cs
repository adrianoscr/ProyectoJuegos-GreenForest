using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] DoorController doorController;

    [SerializeField] bool isDoorOpenSwitch;
    [SerializeField] bool isDoorClosedSwitch;

    float switchSizeY;
    Vector3 switcPosUp;
    Vector3 switcPosDown;
    float switchSpeed = 1.4f;
    float switchDelay = 0.2f;
    bool isPressingPlank = false;

    private void Awake()
    {

        switchSizeY = transform.localScale.y / 2;
        switcPosUp = transform.position;
        switcPosDown = new Vector3(transform.position.x
            ,transform.position.y - switchSizeY,transform.position.z);
    }

    private void Update()
    {

        if (isPressingPlank)
        {

            MoveSwitchDown();
        }
        else if (!isPressingPlank)
        {
            MoveSwitchUp();
        }
    }

    //precionar el boton abajo
    void MoveSwitchDown()
    {
        if (transform.position != switcPosDown)
        {
            AudioController.instance.PlayAudio(AudioController.instance.BossHit);
            transform.position = Vector3.MoveTowards(transform.position,
                switcPosDown,switchSpeed * Time.deltaTime);
            
        }

    }

    //precionar el boton arriba
    void MoveSwitchUp()
    {
        if (transform.position != switcPosUp)
        {
            AudioController.instance.PlayAudio(AudioController.instance.BossHit);
            transform.position = Vector3.MoveTowards(transform.position,
                switcPosUp, switchSpeed * Time.deltaTime);
        }
    }
   

    //Cuando se entra en colision del switch se hace la condicion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPressingPlank = !isPressingPlank;

            if (isDoorOpenSwitch && !doorController.isDoorOpen) {

                doorController.isDoorOpen = !doorController.isDoorOpen;
            }
            else if (isDoorClosedSwitch && doorController.isDoorOpen) {
   
                doorController.isDoorOpen = !doorController.isDoorOpen;
            }
        }
    }

    //cuando se sale del switch se activa la condicion
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){

            StartCoroutine(SwitchUpDelay(switchDelay));
        }
    }

    //tiempo de espera hasta que se jecute otra vez el switch
    IEnumerator SwitchUpDelay(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        isPressingPlank = false;
    }

}
