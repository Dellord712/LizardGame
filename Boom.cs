using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public static bool destroyBoom = false;
    private int limitTime = 15;
    private int time = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerController.hp = 0f;
            PlayerController.lebel = 1;
        }
        if (collision.gameObject.tag == "Tail"|| collision.gameObject.tag == "Infection")
        {
            collision.gameObject.SetActive(false);
            PlayerController.removetail = true;
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(collision.gameObject);
        }
    }
    void FixedUpdate()
    {
        if (PlayerController.gameover||destroyBoom)
        {
            Destroy(gameObject);
            destroyBoom = false;
        }
        if (time > limitTime)
        {
            Destroy(gameObject);
        }
        else
        {
            time++;
        }
    }
}
