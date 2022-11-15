using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    //velocidad de movimiento del fondo
    [SerializeField]
    private Vector2 BgMovement;

    private Vector2 offset;

    private Material material;

    private Rigidbody2D playerRB;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        offset = (playerRB.velocity.x*0.1f)* BgMovement * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
