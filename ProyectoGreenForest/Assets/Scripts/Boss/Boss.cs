using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //ref al animator
    private Animator animator;

    //rb
    public Rigidbody2D rb2D;
    //ubicacion del player
    public Transform Player;
    //donde apunta el enemigo
    private bool lookingR = true;


    [Header("Area De Ataque")]
    [SerializeField] private Transform AttackControllerB;
    //radio
    [SerializeField] private float radioA;
    //daño
    [SerializeField] private float damageA;

     void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        //busqueda del jugador
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        //distancia entre el jefe y el jugador
        float DistanceP = Vector2.Distance(transform.position, Player.position);
        //animacion
        animator.SetFloat("DistanceP", DistanceP);
    }


    //Daño al jefe
   /* public void takeDamage(float damage) {

        life -= damage;

        healthBarBoss.ChageActualLife(life);

        if (life <= 0) {

            animator.SetTrigger("Death");
        }
    }
   */


    //Muerte
    public void Death() {

        animator.SetTrigger("Death");
        Destroy(gameObject);
        
    }

    

    //Rotacion
    public void lookingPlayer() {

        if ((Player.position.x > transform.position.x && !lookingR) || (Player.position.x < transform.position.x && lookingR)) {

            lookingR = !lookingR;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    //Ataque
    public void Attack(){

        Collider2D[] objcts = Physics2D.OverlapCircleAll(AttackControllerB.position, radioA);

        foreach (Collider2D collision in objcts) {

            if (collision.CompareTag("Player")) {

                collision.GetComponent<DamageableController>().TakeDamage(damageA);
                AudioController.instance.PlayAudio(AudioController.instance.BossHit);
            }
        }
    }

    //Area de daño,visual
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(AttackControllerB.position,radioA);
    }
}
