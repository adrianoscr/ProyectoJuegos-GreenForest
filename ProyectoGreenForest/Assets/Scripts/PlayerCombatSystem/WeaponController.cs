using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    Transform rbPowerPrefab;

    [SerializeField]
    float LifeTime = 5.0F;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    float fireRange = 20.0F;

    [SerializeField]
    float fireRate = 1;

    [SerializeField]
    Animator animator;

    float nextFireTime;


    void Start()
    {
        FindObjectOfType<CombatController>()?.onFire.AddListener(Fire);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time > nextFireTime)
            {
                animator.SetTrigger("Fire");
                AudioController.instance.PlayAudio(AudioController.instance.shot);
                nextFireTime = Time.time + fireRange / fireRate;
            }
        }
    }

    //Shoot the power
    void Fire()
    {
        Transform projectile =
                Instantiate(rbPowerPrefab, firePoint.position, firePoint.rotation);

        Destroy(projectile.gameObject, LifeTime);
    }

}
