using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthPlayerController : Singleton<HealthPlayerController>
{
    [SerializeField]
    Slider healthBar;

    [SerializeField]
    GameObject panelMuerte;

    [SerializeField]
    GameObject panelUI;

    [HideInInspector]
    public UnityEvent<float> OnDamage;


    [HideInInspector]
    public UnityEvent muerteEvento;


    private void Start()
    {
        Instance.muerteEvento.AddListener(PanelMuerte);
    }

    /// <summary>
    /// Show in the slider the porcentage of health
    /// </summary>
    /// <param name="percentage"></param>
    public void UpdateHeal(float percentage)
    {
        healthBar.value = percentage;

    }

    public void PanelMuerte() { 

       panelUI.SetActive(false);
       panelMuerte.SetActive(true);

    }


}
