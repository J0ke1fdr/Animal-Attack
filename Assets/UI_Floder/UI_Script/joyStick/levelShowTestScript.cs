using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelShowTestScript : MonoBehaviour
{
    private levelShow levelShowScript;
    private msgShow msgShowText;

    private GameResult gameResult;

    private void Awake()
    {
        levelShowScript = GameObject.Find("levelShow").GetComponent<levelShow>();
        //  msgShowText = GameObject.Find("msgShow").GetComponent<msgShow>();
        gameResult = GameObject.Find("GameResult").GetComponent<GameResult>();
    }

    private void Start()
    {
        //gameOver.showGameOverPanel();
    }

    public void onButtonClick()
    {
        Debug.Log("进入Game Over");
        // levelShowScript.ShowCurrentLevel(0);
        // msgShowText.ShowMsg(1);
        //  gameOver.showGameOverPanel();
        // GameResult.gameOverPanel.gameObject.SetActive(true);
        gameResult.showGameWinPanel();
    }
}