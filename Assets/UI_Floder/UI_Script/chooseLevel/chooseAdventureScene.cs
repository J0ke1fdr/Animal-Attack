using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class chooseAdventureScene : MonoBehaviour
{
    public Sprite[] unChoosed;
    public Sprite[] Choosed;

    private Image level1;

    private void Awake()
    {
        level1 = GameObject.Find("Level1").GetComponent<Image>();
    }

    public void onChooseClick()
    {
        //   choosedScene.text = gameObject.name;

        MenuSceneManager.choosedScene = 1;

        if (gameObject.name == "Level1")
        {
            //choosedPlayerIndex.SceneIndex = 1;
            MenuSceneManager.choosedScene = 1;

            if (level1.sprite != Choosed[0])
            {
                level1.sprite = Choosed[0];
            }
        }
    }
}