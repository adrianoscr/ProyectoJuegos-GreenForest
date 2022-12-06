using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private float damage;

    [SerializeField] private Vector2 boxDimension;

    [SerializeField] private Transform boxPosition;

    [SerializeField] private float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Hit() {
        Collider2D[] objcts = Physics2D.OverlapBoxAll(boxPosition.position,boxDimension,0f);

        foreach (Collider2D collisions in objcts) {

            if (collisions.CompareTag("Player")) {
                AudioController.instance.PlayAudio(AudioController.instance.playSound);
                collisions.GetComponent<HealthController>().TakeDamage(damage);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxPosition.position, boxDimension);
    }
}
