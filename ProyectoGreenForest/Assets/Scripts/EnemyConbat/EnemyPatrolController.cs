using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolController : MonoBehaviour
{

    [SerializeField]
    float speed = 2.0F;

    [SerializeField]
    bool facingRight = false;

    [SerializeField]
    LayerMask whatIsGround;

    [SerializeField]
    float distanceToGround = 0.75F;

    [SerializeField]
    Transform groundChecker;

    Rigidbody2D rb;
    Vector2 moveDirection;

    bool isFacingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isFacingRight = facingRight;

        moveDirection =
            facingRight
                ? Vector2.right
                : Vector2.left;
    }

    void FixedUpdate()
    {
        rb.MovePosition
            (rb.position + moveDirection * speed * Time.fixedDeltaTime);

        Collider2D collider =
            Physics2D.OverlapBox
                (
                groundChecker.position,
                new Vector2(0.50F, 0.03F),
                0.0F,
                whatIsGround
                );

        if (collider == null)
        {
            isFacingRight = !isFacingRight;

            moveDirection =
                moveDirection == Vector2.right
                ? Vector2.left
                : Vector2.right;

            transform.Rotate(new Vector2(0.0F, -180.0F));
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireCube(groundChecker.position, new Vector2(0.50F, 0.03F));
    }

}



