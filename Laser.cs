using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private SpriteRenderer render;
    private Animator animator;
    private int nexttime = 200;
    private int timecount = 200;
    private float randomNum;
    private float probability = 10f;
    private bool shot = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player"&& render.sprite.name == "Laser_6")
        {
            PlayerController.hp = 0f;
        }
        if(collision.gameObject.tag=="Tail" && render.sprite.name == "Laser_6")
        {
            collision.gameObject.SetActive(false);
            PlayerController.removetail = true;
        }
        if (collision.gameObject.tag == "Wall" && render.sprite.name == "Laser_6")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Infection" && render.sprite.name == "Laser_6")
        {
            collision.gameObject.SetActive(false);
            PlayerController.removetail = true;
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if(timecount>nexttime)
        {
            randomNum = Random.Range(0f, 100f);
            if (randomNum<probability)
            {
                shot = true;
            }
            timecount =0;
        }
        else
        {
            if (PlayerController.lebel > 1)
            {
                timecount++;
            }
        }
        if (render.sprite.name == "Laser_7")
        {
            shot = false;
        }
        switch (PlayerController.lebel)
        {
            case 1:
                shot = false;
                timecount = 200;
                break;
            default:
                break;
        }
        animator.SetBool("shot", shot);
        if (PlayerController.gameover)
        {
            Destroy(gameObject);
        }
    }
}
