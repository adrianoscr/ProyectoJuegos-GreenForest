using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [Header("Attack control")]
    [SerializeField]
    LayerMask enemyLayers;

    [SerializeField]
    Transform meleBiteAttack;

    [SerializeField]
    float attackRadius = 0.5F;

    [SerializeField]
    float attackBiteRange = 0.5F;

    [SerializeField]
    int attackRate = 2;

    [SerializeField]
    float damage = 25.0F;

    [Header("Animation control")]
    [SerializeField]
    Animator animator;

    float nextAttackTime;


    void Start()
    {
        FindObjectOfType<CombatController>()?.onAttack.AddListener(SlimeBite);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (nextAttackTime < Time.time)
            {
                if (animator.GetFloat("power") < 0.01F)
                {
                    animator.SetTrigger("meleAttack");
                    AudioController.instance.PlayAudio(AudioController.instance.bite);
                    nextAttackTime = Time.time + attackBiteRange / attackRate;
                }
            }
        }
    }

    void SlimeBite()
    {

        //DETECT ENEMIES IN RANGE OF ATTACK
        //This functione create and detect in a circle al the colliders
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleBiteAttack.position, attackRadius, enemyLayers);

        if (hitEnemies.Length > 0)
        {
            //DAMAGE THEM
            foreach (Collider2D enemy in hitEnemies)
            {
                HealthController controller = enemy.GetComponent<HealthController>();

                if (controller != null)
                {
                    controller.TakeDamage(damage);
                }
            }
        }

        animator.ResetTrigger("meleAttack");

    }

    /// <summary>
    /// Drawing a circle area of damage
    /// </summary>
    void OnDrawGizmosSelected()
    {
        if (meleBiteAttack == null)
        {
            return;
        }

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(meleBiteAttack.position, attackRadius);
    }
}

