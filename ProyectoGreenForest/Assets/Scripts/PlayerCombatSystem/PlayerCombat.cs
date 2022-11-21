using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Animation control")]
    [SerializeField]
    Animator animator;


    [Header("Attack control")]
    [SerializeField]
    Transform meleBiteAttack;

    [SerializeField]
    float attackBiteRange = 0.5F;

    [SerializeField]
    LayerMask enemyLayers;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SlimeBite();
        }
    }

    void SlimeBite()
    {

        //ANIMATE

        if (animator.GetFloat("power") < 0.01F && animator.GetFloat("power") > -0.01F)
        {
            animator.SetTrigger("meleAttack");
        }

        //DETECT ENEMIES IN RANGE OF ATTACK
        //This functione create and detect in a circle al the colliders
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleBiteAttack.position, attackBiteRange, enemyLayers);


        //DAMAGE THEM
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
        }

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

        Gizmos.DrawWireSphere(meleBiteAttack.position, attackBiteRange);
    }
}
