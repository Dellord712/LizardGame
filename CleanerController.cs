using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CleanerController : MonoBehaviour
{
    public static int cleanerCount = 0;
    public Text cleanerText;
    public GameObject cleanerObj;
    public GameObject wallClearObj;
    public Transform wallClearPool;
    public Text text_sec;
    public Text text_min;
    private bool createCleaner = false;

    public void ClickCleaner()
    {
        if (!PlayerController.gameover&&!TimerController.isLobby&&cleanerCount>0)
        {
            GameObject wallClear = Instantiate(wallClearObj, wallClearPool);
            wallClear.transform.position = new Vector2(0.008f, -11.57f);
            cleanerCount--;
        }
    }

    private void CreateCleaner()
    {
        GameObject cleaner = Instantiate(cleanerObj, wallClearPool);
        cleaner.transform.position = new Vector2(Random.Range(-1.4f, 1.4f), Random.Range(-11.5f, -7.3f));
    }

    private void FixedUpdate()
    {
        int min = int.Parse(text_min.text);
        int sec = int.Parse(text_sec.text);
        if((min*60+sec)%30==0&& min * 60 + sec>0&&!createCleaner)
        {
            createCleaner = true;
            CreateCleaner();
        }
        if ((min * 60 + sec) % 30 == 1 && min * 60 + sec > 1 && createCleaner)
        {
            createCleaner = false;
        }
        cleanerText.text = cleanerCount.ToString();
        if (PlayerController.gameover)
        {
            createCleaner = false;
        }
    }
}
