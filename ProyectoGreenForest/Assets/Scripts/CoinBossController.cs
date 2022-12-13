using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinBossController : MonoBehaviour
{

    //Variables aparicion
    [SerializeField]
    int llaves;

    [SerializeField]
    GameObject tpBoss;

     void Start()
    {
        llaves = SessionManager.Instance.GetLlaves();
    }
    void Update()
    {

        if (llaves == 2)
        {
            tpBoss.SetActive(true);
        }
        else {
            tpBoss.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(4);

        }
    }
}
