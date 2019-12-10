using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    private float x;
    private float y;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GhostController.setghost = false;
            PlayerController.hp = 0f;
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Vector3 fixedposition = new Vector2(player.position.x, player.position.y);
        transform.position = Vector2.MoveTowards(transform.position, fixedposition, Time.deltaTime*0.3f);
        x = player.position.x - transform.position.x;
        y = player.position.y - transform.position.y;
        animator.SetFloat("x", x);
        animator.SetFloat("y", y);
    }
}
