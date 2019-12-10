using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public Transform laserPool;
    public GameObject laserObj;
    //private int x_count = 18;
    private int y_count = 14;
    private float discount = 0.1667f;
    private float pos_x = 0.01f;
    //private float[] position_x = new float[18];
    private float[] position_y = new float[14];
    public static bool createlaser = false;

    private void CreateLaser(float x,float y)
    {
        GameObject laser = Instantiate(laserObj, laserPool);
        laser.transform.position = new Vector2(x,y);
    }
    private void FixedUpdate()
    {
        if (createlaser)
        {
            for (int i = 0; i < y_count; i++)
            {
                position_y[i] = -11.51f + discount * 2 * i;
                CreateLaser(pos_x, position_y[i]);
            }
            createlaser = false;
        }
    }
}
