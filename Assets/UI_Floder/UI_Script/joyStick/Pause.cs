using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    private RectTransform pausePanel;

    private void Awake()
    {
        pausePanel = GameObject.Find("AddUI/pausePanel").GetComponent<RectTransform>();       
    }

    private void Start()
    {
        pausePanel.gameObject.SetActive(false);
    }

    public void onPauseClick()
    {
        Debug.Log(gameObject.name);
        //if (!pausePanel.gameObject.activeSelf)
      //  {
            pausePanel.gameObject.SetActive(true);
            Time.timeScale = 0;
      //  }

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
