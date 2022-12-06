using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private Animator animator;

    public Rigidbody2D rb2D;

    public Transform Player;

    private bool lookingR = true;


    [Header("Area De Vida")]
    [SerializeField] private float life=100;
    [SerializeField] private HealthBarBoss healthBarBoss;

    [Header("Area De Ataque")]
    [SerializeField] private Transform AttackControllerB;
    [SerializeField] private float radioA;
    [SerializeField] private float damageA;

     void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        healthBarBoss.StartBar(life);
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        float DistanceP = Vector2.Distance(transform.position, Player.position);
        //animacion
        animator.SetFloat("DistanceP", DistanceP);
    }


    //Daño al jefe
    public void takeDamage(float damage) {

        life -= damage;

        healthBarBoss.ChageActualLife(life);

        if (life <= 0) {

            animator.SetTrigger("Death");
        }
    }



    //Muerte
    private void Death() {

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

    //Area de daño
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(AttackControllerB.position,radioA);
    }
}
