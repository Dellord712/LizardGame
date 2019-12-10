using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerController.createBombTail = true;
            Destroy(gameObject);
        }
    }*/
    public static bool destroyBomb = false;
    public GameObject boomObj;
    private SpriteRenderer render;
    private float discount = 0.1667f;
    void CreateBoom()
    {
        for(int i = 0; i<3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if ((transform.position.x + (i - 1) * discount > -1.5 && transform.position.x + (i - 1) * discount < 1.5) &&
                    (transform.position.y + (j - 1) * discount>-11.6&& transform.position.y + (j - 1) * discount<-7.1))
                {
                    GameObject bomb = Instantiate(boomObj);
                    bomb.transform.position = new Vector2(transform.position.x + (i - 1) * discount, transform.position.y + (j - 1) * discount);
                }
            }
        }
    }
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if (PlayerController.gameover||destroyBomb)
        {
            Destroy(gameObject);
            destroyBomb = false;
        }
        if(render.sprite.name == "Boom")
        {
            Destroy(gameObject);
            CreateBoom();
        }
    }
}
