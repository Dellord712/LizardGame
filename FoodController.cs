using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public Transform foodPool;
    public GameObject apple;
    public GameObject cake;

    private int foodlimittime = 120;
    private int foodtimer = 80;
    private bool chage = false;

    void CreateApple()
    {
        GameObject food = Instantiate(apple, foodPool);
        food.transform.position = new Vector2(Random.Range(-1.4f, 1.4f), Random.Range(-11.5f, -7.3f));
    }
    void CreateCake()
    {
        GameObject food = Instantiate(cake, foodPool);
        food.transform.position = new Vector2(Random.Range(-1.4f, 1.4f), Random.Range(-11.5f, -7.3f));
    }

    private void FixedUpdate()
    {
        if (foodtimer > foodlimittime)
        {
            foodtimer = 0;
            if (PlayerController.lebel <= 2)
            {
                CreateApple();
            }
            else
            {
                if (chage)
                {
                    CreateApple();
                    chage = false;
                }
                else
                {
                    CreateCake();
                    chage = true;
                }
            } 
        }
        else
        {
            foodtimer++;
        }
        if (PlayerController.gameover)
        {
            foodtimer = 80;
        }
    }
}
