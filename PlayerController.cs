using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject gameovermsg;
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;
    public Button reset_button;
    public Button start_button;
    public Button lobby_button;
    public Button back_button;
    public Button exit_button;
    public Text best;
    public Text cleanerText;
    public GameObject lobby;
    public GameObject gameover_time;
    public GameObject bombTail;
    public Button setting_button;
    public Text bestTime;
    public Sprite wall;
    public Sprite infection;
    public Transform ghost;
    public static bool gameover = false;
    public static bool reset = false;
    public static int lebel = 1;
    public static List<Vector3> path = new List<Vector3>();
    private bool onClickUp = false;
    private bool onClickDown = false;
    private bool onClickLeft = false;
    private bool onClickRight = false;
    private int x_size = 18;
    private int y_size = 27;
    private float discount = 0.1667f;
    private int updatetime = 6;
    private int updatecount = 0;
    private float vertical;
    private float horizontal;
    private bool axis_x = true;
    private int limittime = 5;
    private int counttime = 5;
    private List<float> position_x=new List<float>();
    private List<float> position_y=new List<float>();
    private int x_num = 1;
    private int y_num = 8;
    private bool controller_bool = true;
    public static int tailCount = 0;
    private int tailTime = 150;
    private bool tailInfection = false;
    private bool translation = false;
    public void OnClickUp()
    {
        if (controller_bool&&axis_x)
        {
            onClickUp = true;
        }
    }
    public void OnClickDown()
    {
        if (controller_bool&&axis_x)
        {
            onClickDown = true;
        }
    }
    public void OnClickLeft()
    {
        if (controller_bool&&!axis_x)
        {
            onClickLeft = true;
        }
    }
    public void OnClickRight()
    {
        if (controller_bool&&!axis_x)
        {
            onClickRight = true;
        }
    }
    public void ResetClick()
    {
        x_num = 1;
        y_num = 8;
        transform.position = new Vector2(position_x[x_num], position_y[y_num]);
        gameovermsg.SetActive(false);
        reset_button.gameObject.SetActive(false);
        counttime = 10;
        axis_x = true;
        horizontal = 1.0f;
        vertical = 0.0f;
        controller_bool = true;
        path.Insert(0, transform.position);
        updatecount = 0;
        hp = 100f;
        gameover = false;
        best.gameObject.SetActive(false);
        start_button.gameObject.SetActive(false);
        lobby_button.gameObject.SetActive(false);
        lobby.SetActive(false);
        LaserController.createlaser = true;
        TimerController.isLobby = false;
        back_button.gameObject.SetActive(false);
        exit_button.gameObject.SetActive(false);
        setting_button.gameObject.SetActive(false);
        bestTime.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void LobbyClick()
    {
        gameovermsg.SetActive(false);
        reset_button.gameObject.SetActive(false);
        lobby_button.gameObject.SetActive(false);
        gameover_time.SetActive(false);
        lobby.SetActive(true);
        start_button.gameObject.SetActive(true);
        TimerController.isLobby = true;
        hp_Img.fillAmount = 100f;
        bottom_best_min.text = "00";
        bottom_best_sec.text = "00";
        setting_button.gameObject.SetActive(true);
        bestTime.gameObject.SetActive(true);
        best.gameObject.SetActive(false);
    }

    public void BackClick()
    {
        back_button.gameObject.SetActive(false);
        exit_button.gameObject.SetActive(false);
        controller_bool = true;
        Time.timeScale = 1;
    }

    public void EscClick()
    {
        back_button.gameObject.SetActive(true);
        exit_button.gameObject.SetActive(true);
        controller_bool = false;
        Time.timeScale = 0;
    }

    public void ExitClick()
    {
        Application.Quit();
    }

    void AwakeGameOver()
    {
        lebel = 1;
        gameover = true;
        gameovermsg.SetActive(true);
        reset_button.gameObject.SetActive(true);
        lobby_button.gameObject.SetActive(true);
        ghost.gameObject.SetActive(false);
        controller_bool = false;
        path.Clear();
        tailGameObjects.Clear();
        CleanerController.cleanerCount = 0;
        cleanerText.text = "0";
    }
    void GameOver()
    {
        Time.timeScale = 0;
    }

    public Text bottom_best_min;
    public Text bottom_best_sec;
    public void Load()
    {
        if (gameover||TimerController.isLobby)
        {
            best.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("min") < 10) 
            {
                bottom_best_min.text = "0"+PlayerPrefs.GetInt("min").ToString();
            }
            else
            {
                bottom_best_min.text = PlayerPrefs.GetInt("min").ToString();
            }
            if (PlayerPrefs.GetInt("sec") < 10)
            {
                bottom_best_sec.text = "0"+PlayerPrefs.GetInt("sec").ToString();
            }
            else
            {
                bottom_best_sec.text = PlayerPrefs.GetInt("sec").ToString();
            }
            
        }
    }

    public Transform tailPool;
    public GameObject tailPrefab;
    public static bool createtail = false;
    public static bool createtail2 = false;
    //public static bool createBombTail = false;
    public List<GameObject> tailGameObjects = new List<GameObject>();

    public static float hp=100f;
    public Image hp_Img;

    int d_index = 0;
    public static bool removetail = false;
    private void CreateTail()
    {
        GameObject tail = Instantiate(tailPrefab, tailPool);
        tailGameObjects.Insert(0,tail);
    }
    /*
    private void CreateBombTail()
    {
        GameObject b_tail = Instantiate(bombTail, tailPool);
        tailGameObjects.Insert(0,b_tail);
    }*/
    void Awake()
    {
        animator = GetComponent<Animator>();
        for (int i = 0; i < x_size; i++)
        {
            position_x.Add(-1.40f + discount * i);
        }
        for (int i = 0; i < y_size; i++)
        {
            position_y.Add(-11.51f + discount * i);
        }
        transform.position = new Vector2(position_x[x_num], position_y[y_num]);
        path.Insert(0, transform.position);
        controller_bool = false;
        Time.timeScale = 0;
    }

    void Start()
    {
        horizontal = 1.0f;
    }

    void FixedUpdate()
    {
        if (removetail)
        {
            int index = 0;
            bool frontdestroy = false;
            foreach (GameObject obj in tailGameObjects)
            {
                if (obj.activeSelf == false && !frontdestroy)
                {
                    d_index = index;
                    frontdestroy = true;
                }
                if (frontdestroy)
                {
                    obj.gameObject.GetComponent<SpriteRenderer>().sprite = wall;
                    obj.tag = "Wall";
                }
                if (obj.activeSelf == false)
                {
                    Destroy(obj);
                }
                index++;
            }
            if (d_index < tailGameObjects.Count)
            {
                if (d_index == 0)
                {
                    tailGameObjects.Clear();
                }
                else
                {
                    int count = tailGameObjects.Count;
                    for (int i = d_index; i < count; i++)
                    {
                        tailGameObjects.RemoveAt(d_index);
                    }
                }
            }
            removetail = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscClick();
        }
        if (hp > 100)
        {
            hp = 100;
        }
        hp_Img.fillAmount = hp / 100f;
        if (counttime > limittime)
        {
            if (axis_x)
            {
                if (Input.GetKeyDown(KeyCode.S) || onClickDown)
                {
                    axis_x = false;
                    horizontal = 0.0f;
                    vertical = -1.0f;
                    counttime = 0;
                    onClickDown = false;
                }
                else if (Input.GetKeyDown(KeyCode.W) || onClickUp)
                {
                    axis_x = false;
                    horizontal = 0.0f;
                    vertical = 1.0f;
                    counttime = 0;
                    onClickUp = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A) || onClickLeft)
                {
                    axis_x = true;
                    vertical = 0.0f;
                    horizontal = -1.0f;
                    counttime = 0;
                    onClickLeft = false;
                }
                else if (Input.GetKeyDown(KeyCode.D) || onClickRight)
                {
                    axis_x = true;
                    vertical = 0.0f;
                    horizontal = 1.0f;
                    counttime = 0;
                    onClickRight = false;
                }
            }
        }
        else
        {
            counttime++;
        }
        animator.SetFloat("x", horizontal);
        animator.SetFloat("y", vertical);

        if (createtail)
        {
            CreateTail();
            createtail = false;
        }
        if (createtail2)
        {
            CreateTail();
            createtail2 = false;
        }
        /*
        if(createBombTail)
        {
            CreateBombTail();
            createBombTail = false;
        }*/
        Vector2 fixedposition;
        if (updatecount > updatetime)
        {
            hp -= 1;
            updatecount = 0;
            if (hp < 0)
            {
                AwakeGameOver();
                GameOver();
            }
            if (horizontal == 1)
            {
                if (x_num < x_size - 1)
                {
                    path.Insert(0, new Vector3(position_x[x_num], position_y[y_num]));
                    x_num++;
                }
                else
                {
                    AwakeGameOver();
                    GameOver();
                }
                fixedposition = new Vector2(position_x[x_num], position_y[y_num]);

            }
            else if (horizontal == -1)
            {
                if (x_num > 0)
                {
                    path.Insert(0, new Vector3(position_x[x_num], position_y[y_num]));
                    x_num--;
                }
                else
                {
                    AwakeGameOver();
                    GameOver();
                }
                fixedposition = new Vector2(position_x[x_num], position_y[y_num]);
            }
            else if (vertical == 1)
            {
                if (y_num < y_size - 1)
                {
                    path.Insert(0, new Vector3(position_x[x_num], position_y[y_num]));
                    y_num++;
                }
                else
                {
                    AwakeGameOver();
                    GameOver();
                }
                fixedposition = new Vector2(position_x[x_num], position_y[y_num]);
            }
            else
            {
                if (y_num > 0)
                {
                    path.Insert(0, new Vector3(position_x[x_num], position_y[y_num]));
                    y_num--;
                }
                else
                {
                    AwakeGameOver();
                    GameOver();
                }
                fixedposition = new Vector2(position_x[x_num], position_y[y_num]);
            }
            transform.position = fixedposition;
        }
        else
        {
            updatecount++;
        }

        for (int i = 0; i < tailGameObjects.Count; i++)
        {
            tailGameObjects[i].transform.position = path[i];
            /*
            if(tailGameObjects[i].transform.position==transform.position)
            {
                AwakeGameOver();
                GameOver();
            }*/
        }

        if (path.Count > 100)
        {
            path.RemoveAt(100);
        }

        if (lebel >= 5)
        {
            if (tailInfection)
            {
                if (tailCount >= tailTime)
                {
                    translation = true;
                    tailCount = 0;
                }
                else
                {
                    tailCount++;
                }
            }
            int tailNum = 0;
            int tailsize = tailGameObjects.Count;
            foreach (GameObject obj in tailGameObjects)
            {
                if (obj.transform.gameObject.tag == "Infection")
                {
                    tailInfection = true;
                }
                else if (tailNum==tailsize-1&&translation)
                {
                    tailInfection = false;
                    tailCount = 0;
                }
                if (obj.transform.gameObject.tag == "Infection" && tailNum >= 1 && tailNum <= tailsize - 1 && translation)
                {
                    if (tailGameObjects[tailNum - 1].transform.gameObject.tag == "Tail")
                    {
                        tailGameObjects[tailNum - 1].transform.gameObject.GetComponent<SpriteRenderer>().sprite = infection;
                        tailGameObjects[tailNum - 1].transform.gameObject.tag = "Infection";
                        for(int i = tailNum + 1; i < tailsize; i++)
                        {
                            tailGameObjects[i].transform.gameObject.GetComponent<SpriteRenderer>().sprite = infection;
                            tailGameObjects[i].transform.gameObject.tag = "Infection";
                        }
                    }
                    translation = false;
                    break;
                }
                else if (obj.transform.gameObject.tag == "Infection" && tailNum == 0 && translation)
                {
                    AwakeGameOver();
                    GameOver();
                    break;
                }
                tailNum++;
            }
        }
    }
}