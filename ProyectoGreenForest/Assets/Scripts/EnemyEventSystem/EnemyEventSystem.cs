using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyEventSystem : MonoBehaviour
{

    [SerializeField]
    Transform damegeEffect;

    [SerializeField]
    TMP_Text score;

    void Start()
    {
        FindObjectOfType<HealthController>()?.onDie.AddListener(OnDie);

    }


    void OnDie(GameObject go)
    {
        Destroy(go);

        int value = int.Parse(score.text);
        value = value + 5;
        score.text = value.ToString();
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
