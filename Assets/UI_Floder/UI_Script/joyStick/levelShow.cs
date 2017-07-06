using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelShow : MonoBehaviour
{
    private Text levelShowText;

    // Use this for initialization
    private void Awake()
    {
        levelShowText = GameObject.Find("levelShow").GetComponent<Text>();
    }

    public void ShowCurrentLevel(int level)
    {
        levelShowText.text = "Level " + level;
        levelShowText.CrossFadeAlpha(255, 1, true);
        levelShowText.CrossFadeAlpha(0, 3, true);
    }
}