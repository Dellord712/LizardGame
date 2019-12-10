using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public static bool isLobby = true;
    private float timer = 0f;
    private int sec=0;
    private int min=0;
    private bool onerun = false;
    private bool onerun2 = false;
    public Text text_sec;
    public Text text_min;
    public Text over_sec;
    public Text over_min;
    public Text over_dot;
    public Text best;
    public Text bestMinite;
    public Text bestSecond;
    private void BestTimeLoad()
    {
        if (PlayerPrefs.GetInt("min") < 10)
        {
            bestMinite.text = "0" + PlayerPrefs.GetInt("min").ToString();
        }
        else
        {
            bestMinite.text = PlayerPrefs.GetInt("min").ToString();
        }
        if (PlayerPrefs.GetInt("sec") < 10)
        {
            bestSecond.text = "0" + PlayerPrefs.GetInt("sec").ToString();
        }
        else
        {
            bestSecond.text = PlayerPrefs.GetInt("sec").ToString();
        }
    }
    private void Save()
    {
        if (PlayerPrefs.GetInt("min") * 60 + PlayerPrefs.GetInt("sec") < min * 60 + sec)
        {
            PlayerPrefs.SetInt("min", int.Parse(over_min.text));
            PlayerPrefs.SetInt("sec", int.Parse(over_sec.text));
        }
    }

    public void BackLoad()
    {
        if (PlayerController.gameover||isLobby)
        {
            best.gameObject.SetActive(false);
            text_min.text = "00";
            text_sec.text = "00";
        }
    }
    private void Awake()
    {
        BestTimeLoad();
    }
    private void FixedUpdate()
    {
        if (PlayerController.gameover)
        {
            over_min.gameObject.SetActive(true);
            onerun = true;
            if (onerun)
            {
                if (sec < 10)
                {
                   over_sec.GetComponent<Text>().text = '0' + sec.ToString();
                }
                else
                {
                    over_sec.GetComponent<Text>().text = sec.ToString();
                }
                if (min < 10)
                {
                    over_min.GetComponent<Text>().text = '0' + min.ToString();
                }
                else
                {
                    over_min.GetComponent<Text>().text = min.ToString();
                }
                Save();
                BestTimeLoad();
                onerun = false;
                onerun2 = true;
            }
        }
        else
        {
            if (onerun2)
            {
                timer = 0f;
                onerun2 = false;
            }
            over_min.gameObject.SetActive(false);
            if (min * 60 + sec == 10)
            {
                PlayerController.lebel = 2;
            }
            else if (min * 60 + sec == 30)
            {
                PlayerController.lebel = 3;
            }
            else if (min * 60 + sec == 60)
            {
                PlayerController.lebel = 4;
            }
            else if (min * 60 + sec == 90)
            {
                PlayerController.lebel = 5;
            }
        }
        if (sec < 10)
        {
            text_sec.GetComponent<Text>().text = '0' + sec.ToString();
        }
        else
        {
            text_sec.GetComponent<Text>().text = sec.ToString();
        }
        if (min < 10)
        {
            text_min.GetComponent<Text>().text = '0' + min.ToString();
        }
        else
        {
            text_min.GetComponent<Text>().text = min.ToString();
        }
        timer += Time.deltaTime;
        sec = (int)timer % 60;
        min = (int)timer / 60;
    }
}
