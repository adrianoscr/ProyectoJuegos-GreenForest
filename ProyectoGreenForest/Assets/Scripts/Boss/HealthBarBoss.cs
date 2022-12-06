using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBoss : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChageMaxLife(float maxLife) {
        slider.maxValue = maxLife;
    }

    public void ChageActualLife(float amountOfLife) {
        slider.value = amountOfLife;
    }

    public void StartBar(float amountOfLife) {
        ChageMaxLife(amountOfLife);
        ChageActualLife(amountOfLife); 
    }

}
