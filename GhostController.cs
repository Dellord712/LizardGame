using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public static bool setghost = false;
    public Transform ghost;
    private int count = 290;
    private int time = 300;

    private void Awake()
    {
        ghost.gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (PlayerController.lebel < 5)
        {
            setghost = false;
            count = 290;
        }
        if (PlayerController.lebel >= 5&&!setghost)
        {
            if (count > time)
            {
                ghost.gameObject.SetActive(true);
                setghost = true;
                ghost.position = new Vector2(-1.4f,-6.98f);
                count = 0;
            }
            else
            {
                count++;
            }
        }
    }
}
