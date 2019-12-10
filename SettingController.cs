using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingController : MonoBehaviour
{
    public Button startButton;
    public Transform lobby;
    public Transform player;
    public Button leftHanded;
    public Button rightHanded;
    public Button explanation;
    public Transform explanationObj;
    public Button exit;
    public Button back;
    public Text bestTime;
    public Image cake;
    public Image hpbar;
    public Text time;
    public Text cleanerCount;
    public Text BestText;
    public Button cleanerButton;
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;
    public Button versionButton;
    public Text version;
    private bool setting = false;
    public void ClickBack()
    {
        explanationObj.gameObject.SetActive(false);
        leftHanded.gameObject.SetActive(true);
        rightHanded.gameObject.SetActive(true);
        explanation.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
        version.gameObject.SetActive(false);
        versionButton.gameObject.SetActive(false);
    }
    public void ClickExplanation()
    {
        explanationObj.gameObject.SetActive(true);
        leftHanded.gameObject.SetActive(false);
        rightHanded.gameObject.SetActive(false);
        explanation.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        versionButton.gameObject.SetActive(true);
    }
    public void ClickVersion()
    {
        version.gameObject.SetActive(true);
    }
    public void ClickLeftHanded()
    {
        cake.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(30f, -823f);
        hpbar.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(400f, -821f);
        time.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(240f, -1040f);
        cleanerButton.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0f, -1190f);
        cleanerCount.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-20f, -1092f);
        leftButton.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-600f, -985f);
        upButton.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-413f, -800f);
        rightButton.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-230f, -985f);
        downButton.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-413f, -1169f);
        BestText.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(221f, -916f);
        PlayerPrefs.SetInt("setting", 1);
    }
    public void ClickRightHanded()
    {
        cake.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-521f,-823f);
        hpbar.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-148f, -821f);
        time.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-450f, -1040f);
        cleanerButton.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(60f, -1190f);
        cleanerCount.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(39f, -1092f);
        leftButton.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(219f, -985f);
        upButton.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(402f, -800f);
        rightButton.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(588f, -985f);
        downButton.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(402f, -1169f);
        BestText.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-487f,-916f);
        PlayerPrefs.SetInt("setting", 0);
    }
    public void ClickSetting()
    {
        if (setting)
        {
            startButton.gameObject.SetActive(true);
            lobby.gameObject.SetActive(true);
            explanationObj.gameObject.SetActive(false);
            leftHanded.gameObject.SetActive(false);
            rightHanded.gameObject.SetActive(false);
            explanation.gameObject.SetActive(false);
            exit.gameObject.SetActive(false);
            back.gameObject.SetActive(false);
            bestTime.gameObject.SetActive(true);
            version.gameObject.SetActive(false);
            versionButton.gameObject.SetActive(false);
            setting = false;
        }
        else
        {
            player.position = new Vector2(0f, -1f);
            startButton.gameObject.SetActive(false);
            lobby.gameObject.SetActive(false);
            leftHanded.gameObject.SetActive(true);
            rightHanded.gameObject.SetActive(true);
            explanation.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            bestTime.gameObject.SetActive(false);
            setting = true;
        }
    }

    private void Awake()
    {
        if (PlayerPrefs.GetInt("setting") == 1)
        {
            ClickLeftHanded();   
        }
        else
        {
            ClickRightHanded();
        }
    }
}
