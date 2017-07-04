using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelShowTestScript : MonoBehaviour
{
    private levelShow levelShowScript;
    private msgShow msgShowText;

    private GameResult GameResult;

    private void Awake()
    {
        levelShowScript = GameObject.Find("levelShow").GetComponent<levelShow>();
        //  msgShowText = GameObject.Find("msgShow").GetComponent<msgShow>();
        // GameResult = GameObject.Find("GameResult").GetComponent<GameResult>();
    }

    public void onButtonClick()
    {
        Debug.Log("进入Game Over");
        //  GameResult.showGameWinPanel();
        GameResult.showGameOverPanel();
        //  msgShowText.ShowMsg(2);
    }
}