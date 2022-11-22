using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatController : MonoBehaviour
{
    [SerializeField]
    public UnityEvent onAttack;

    [SerializeField]
    public UnityEvent onFire;


    void Attack()
    {
        if (onAttack != null)
        {
            onAttack.Invoke();
        }
    }


    void Fire()
    {
        if (onFire != null)
        {
            onFire.Invoke();
        }
    }
}
