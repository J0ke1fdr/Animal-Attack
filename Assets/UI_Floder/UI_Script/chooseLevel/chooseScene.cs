using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class chooseScene : MonoBehaviour
{
    //private Text choosedScene;

    public Sprite[] dayScenePic;
    public Sprite[] nightScenePic;

    private Image dayScene;
    private Image nightScene;

    private void Awake()
    {
        dayScene = GameObject.Find("Level2").GetComponent<Image>();
        nightScene = GameObject.Find("Level3").GetComponent<Image>();
    }

    public void onChooseClick()
    {
        if (gameObject.name == "Level2")
        {
            MenuSceneManager.choosedScene = 2;

            if (dayScene.sprite != dayScenePic[1])
            {
                dayScene.sprite = dayScenePic[1];
                nightScene.sprite = nightScenePic[0];
            }
        }
        else if (gameObject.name == "Level3")
        {
            MenuSceneManager.choosedScene = 3;

            if (nightScene.sprite != nightScenePic[1])
            {
                dayScene.sprite = dayScenePic[0];
                nightScene.sprite = nightScenePic[1];
            }
        }
    }
}