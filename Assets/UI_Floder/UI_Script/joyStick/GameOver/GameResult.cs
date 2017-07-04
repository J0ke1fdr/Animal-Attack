using UnityEngine;
using System.Collections;

public class GameResult : MonoBehaviour {

    public static RectTransform gameOverPanel;
    public static RectTransform gameWinPanel;
	// Use this for initialization
	void Awake () {
        gameOverPanel = GameObject.Find("GameOverPanel").GetComponent<RectTransform>();
        gameWinPanel = GameObject.Find("GameWinPanel").GetComponent<RectTransform>();
        
    }

    private void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
        gameWinPanel.gameObject.SetActive(false);
    }

    public void showGameOverPanel()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

    public void showGameWinPanel()
    {
        gameWinPanel.gameObject.SetActive(true);
    }


}
