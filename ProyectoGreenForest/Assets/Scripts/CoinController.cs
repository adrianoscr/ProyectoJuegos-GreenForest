using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") {


            //carga de la sig escena, en este caso en el deepForest
            SceneManager.LoadScene(3);
        
        }   
    }
}
