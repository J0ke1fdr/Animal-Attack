﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class chooseScene : MonoBehaviour {

    private Text choosedScene;

    private void Start()
    {
        choosedScene = GameObject.Find("choosedScene").GetComponent<Text>();
        choosedScene.text = "Level1";
    }

    public void onChooseClick()
    {
        choosedScene.text = gameObject.name;
        if (gameObject.name == "Level1")
        {
            choosedPlayerIndex.SceneIndex = 0;          
        }
        else if(gameObject.name == "Level2")
        {
            choosedPlayerIndex.SceneIndex = 1;
        }
        //Debug.Log(gameObject.name);
    }

   
}
