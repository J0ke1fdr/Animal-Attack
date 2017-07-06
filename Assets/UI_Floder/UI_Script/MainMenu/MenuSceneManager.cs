using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{
    public static RectTransform mainMenuScene;
    public static RectTransform choosePlayerScene;
    public static RectTransform connectScene;
    public static RectTransform chooseScene;
    public static RectTransform chooseModel;
    public static RectTransform chooseAdventureLevelScene;

    public static int gameWay = 0;//游戏模式，单人，多人
    public static int choosedPlayer = 0;//选择的角色
    public static int choosedScene = 1;//选择场景
    public static int choosedModel = 0;//选择模式

    public static int enablePlayerIndex = 0;

    public Sprite[] enablePlayer;//3个
    public Sprite[] unEnablePlayer;//3个

    private Image Player1;
    private Image Player2;
    private Image Player3;

    private void Awake()
    {
        mainMenuScene = GameObject.Find("mainMenu").GetComponent<RectTransform>();
        choosePlayerScene = GameObject.Find("choosePlayer").GetComponent<RectTransform>();
        connectScene = GameObject.Find("connectScene").GetComponent<RectTransform>();
        chooseScene = GameObject.Find("chooseScene").GetComponent<RectTransform>();
        chooseModel = GameObject.Find("chooseModel").GetComponent<RectTransform>();
        chooseAdventureLevelScene = GameObject.Find("chooseAdventureLevelScene").GetComponent<RectTransform>();

        Player1 = GameObject.Find("Farmer").GetComponent<Image>();
        Player2 = GameObject.Find("Athlete").GetComponent<Image>();
        Player3 = GameObject.Find("Soldier").GetComponent<Image>();

        enablePlayerIndex = PlayerPrefs.GetInt("enablePlayerIndex", 0);
    }

    private void Start()
    {
        choosePlayerScene.gameObject.SetActive(false);
        connectScene.gameObject.SetActive(false);
        chooseScene.gameObject.SetActive(false);
        chooseModel.gameObject.SetActive(false);
        chooseAdventureLevelScene.gameObject.SetActive(false);

        UpdateEnablePlayer();
    }

    public void UpdateEnablePlayer()
    {
        if (enablePlayerIndex == 0)
        {
            Player1.sprite = enablePlayer[0];
            Player2.sprite = unEnablePlayer[1];
            Player3.sprite = unEnablePlayer[2];
        }
        else if (enablePlayerIndex == 1)
        {
            Player1.sprite = enablePlayer[0];
            Player2.sprite = enablePlayer[1];
            Player3.sprite = unEnablePlayer[2];
        }
        else if (enablePlayerIndex == 2)
        {
            Player1.sprite = enablePlayer[0];
            Player2.sprite = enablePlayer[1];
            Player3.sprite = enablePlayer[2];
        }
    }
}