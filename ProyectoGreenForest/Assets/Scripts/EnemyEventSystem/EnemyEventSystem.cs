using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventSystem : MonoBehaviour
{

    [SerializeField]
    Transform damegeEffect;

    void Start()
    {
        FindObjectOfType<HealthController>()?.onDie.AddListener(OnDie);

    }


    void OnDie(GameObject go)
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
