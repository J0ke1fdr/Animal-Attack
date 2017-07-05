using UnityEngine;
using System.Collections;

public class GameResult : MonoBehaviour
{
    public static RectTransform gameOverPanel;
    public static RectTransform gameWinPanel;

    // Use this for initialization
    private void Awake()
    {
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
        Time.timeScale = 0;
        gameOverPanel.gameObject.SetActive(true);
    }

    public void showGameWinPanel()
    {
        Time.timeScale = 0;
        gameWinPanel.gameObject.SetActive(true);
    }
}