using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyEventSystem : MonoBehaviour
{

    //[SerializeField]
    //Transform damegeEffect;

    //[SerializeField]
    //TMP_Text score;

    void Start()
    {
        FindObjectOfType<HealthController>()?.onDie.AddListener(meMuero);

    }


    void meMuero(GameObject go)
    {
        Destroy(go);
        //StartCoroutine(OnDieCoroutine(go));


    }

    IEnumerator OnDieCoroutine(GameObject go)
    {

        //damegeEffect.gameObject.SetActive(true);
        //damegeEffect.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(0.5F);
        Destroy(go);
    }
}
