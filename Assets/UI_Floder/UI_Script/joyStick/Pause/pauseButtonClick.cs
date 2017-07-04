using UnityEngine;
using System.Collections;

public class pauseButtonClick : MonoBehaviour {

    private static RectTransform pausePanel;

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
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
