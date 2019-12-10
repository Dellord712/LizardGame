using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallClear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Wall")
        {
            Destroy(collision.gameObject);
        }
    }
    void FixedUpdate()
    {
        Vector3 fixedposition = new Vector2(0.008f, -7.1f);
        transform.position = Vector2.MoveTowards(transform.position, fixedposition, Time.deltaTime*6);
        if(transform.position==fixedposition||PlayerController.gameover)
        {
            Destroy(transform.gameObject);
        }
    }
}
