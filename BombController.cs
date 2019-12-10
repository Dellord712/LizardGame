using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public Transform bombPool;
    public GameObject bombObj;
    public GameObject boomObj;
    private List<float> position_x = new List<float>();
    private List<float> position_y = new List<float>();
    private int x_size = 18;
    private int y_size = 27;
    private float discount = 0.1667f;
    private int limittime = 200;
    private int timer = 200;

    private void CreateBomb()
    {
        int x = (int)Random.Range(0.0f, 17.9f);
        int y = (int)Random.Range(0.0f, 26.9f);
        GameObject bomb = Instantiate(bombObj,bombPool);
        bomb.transform.position = new Vector2(position_x[x], position_y[y]);
    }

    void Awake()
    {
        for (int i = 0; i < x_size; i++)
        {
            position_x.Add(-1.40f + discount * i);
        }
        for (int i = 0; i < y_size; i++)
        {
            position_y.Add(-11.51f + discount * i);
        }
    }

    private void FixedUpdate()
    {
        if (PlayerController.lebel >= 4)
        {
            if (timer > limittime)
            {
                CreateBomb();
                CreateBomb();
                timer = 0;
            }
            else
            {
                timer++;
            }
        }
    }
}
