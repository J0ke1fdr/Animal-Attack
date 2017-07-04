using UnityEngine;
using System.Collections;

public class MenuSceneManager : MonoBehaviour {

    public static RectTransform mainMenuScene;
    public static RectTransform choosePlayerScene;
    public static RectTransform connectScene;
    public static RectTransform chooseScene;
    public static RectTransform chooseModel;

    public static int gameWay = 0;//游戏模式，单人，多人
    public static int choosedPlayer = 0;//选择的角色
    public static int choosedScene = 0;//选择场景
    public static int choosedModel = 0;//选择模式

    private void Awake()
    {
        mainMenuScene = GameObject.Find("mainMenu").GetComponent<RectTransform>();
        choosePlayerScene = GameObject.Find("choosePlayer").GetComponent<RectTransform>();
        connectScene = GameObject.Find("connectScene").GetComponent<RectTransform>();
        chooseScene = GameObject.Find("chooseScene").GetComponent<RectTransform>();
        chooseModel = GameObject.Find("chooseModel").GetComponent<RectTransform>();
    }

    private void Start()
    {
        choosePlayerScene.gameObject.SetActive(false);
        connectScene.gameObject.SetActive(false);
        chooseScene.gameObject.SetActive(false);
        chooseModel.gameObject.SetActive(false);
    }

}
