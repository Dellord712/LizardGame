using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            CleanerController.cleanerCount++;
            Destroy(transform.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(PlayerController.gameover)
        {
            Destroy(transform.gameObject);
        }
    }
}
