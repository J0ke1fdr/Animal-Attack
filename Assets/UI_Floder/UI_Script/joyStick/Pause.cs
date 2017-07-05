using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    private RectTransform pausePanel;
    public Sprite[] soundImg;


    private void Awake()
    {
        pausePanel = GameObject.Find("AddUI/pausePanel").GetComponent<RectTransform>();
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

    private static int soundImgIndex = 0;
    public void onSoundClick()
    {
        if (soundImgIndex == 0)
        {

            soundImgIndex++;
        }
        else if (soundImgIndex == 1)
        {
            soundImgIndex--;
        }
    }
}
