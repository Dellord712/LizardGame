using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public static bool destroyTail = false;
    public Sprite infection;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerController.hp = 0f;
        }
        if (collision.gameObject.tag == "Ghost"&&transform.gameObject.tag=="Tail")
        {
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = infection;
            transform.gameObject.tag = "Infection";
            collision.gameObject.SetActive(false);
            GhostController.setghost = false;
            PlayerController.tailCount = 0;
        }
    }
    private void FixedUpdate()
    {
        if (PlayerController.gameover||destroyTail)
        {
            Destroy(gameObject);
            destroyTail = false;
        }
    }
}
