using UnityEngine;
using System.Collections;

public class GameResult : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    private void Awake()
    {
        if (gameObject.name == "GameOver")
        {
        }
        else if (gameObject.name == "GameWin")
        {
        }
    }

    // Use this for initialization
    private void Start()
    {
        // gameOverPanel = GameObject.FindGameObjectWithTag("Lose");
        // gameWinPanel = GameObject.Find("GameWinPanel").GetComponent<RectTransform>();
        // gameOverPanel.SetActive(false);
        // gameWinPanel.SetActive(false);
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