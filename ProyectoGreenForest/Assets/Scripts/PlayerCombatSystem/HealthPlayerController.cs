using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthPlayerController : Singleton<HealthPlayerController>
{
    [SerializeField]
    Slider healthBar;

    [HideInInspector]
    public UnityEvent<float> OnDamage;


    /// <summary>
    /// Show in the slider the porcentage of health
    /// </summary>
    /// <param name="percentage"></param>
    public void UpdateHeal(float percentage)
    {
        healthBar.value = percentage;
    }

}
