using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    private RectTransform pausePanel;

    private void Awake()
    {
        pausePanel = GameObject.Find("pausePanel").GetComponent<RectTransform>();
    }
    private void Start()
    {
        pausePanel.gameObject.SetActive(false);

    }

    public void onPauseClick()
    {
        Time.timeScale = 0;
        pausePanel.gameObject.SetActive(true);
    }

    public void onPlayClick()
    {
        Time.timeScale = 1;
        pausePanel.gameObject.SetActive(false);
    }

    public void onHomeClick()
    {
        SceneManager.LoadScene(0);
    }


}
