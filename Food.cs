using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static bool destroyFood = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerController.hp += 17f;
            PlayerController.createtail = true;
            if (gameObject.tag == "Cake")
            {
                PlayerController.createtail2 = true;
            }
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (PlayerController.gameover||destroyFood)
        {
            Destroy(gameObject);
            destroyFood = false;
        }
    }
}
