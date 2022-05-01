using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAI : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float MovementSpeed = 1;
    public Vector3 moveAmount;

    public float minDistanceToPlayer = 1.5f;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Follow the player
        var dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (dist < minDistanceToPlayer)
        {
            // if close enough to the player do nothing
        }
        else
        {
            // else move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
                Time.deltaTime * MovementSpeed);
            
        }

        // face the chicken towards the player.
        spriteRenderer.flipX = player.transform.position.x < this.transform.position.x;
    }
}
