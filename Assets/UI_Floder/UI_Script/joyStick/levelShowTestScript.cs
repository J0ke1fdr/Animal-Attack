using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelShowTestScript : MonoBehaviour {

    private levelShow levelShowScript;

    private void Awake()
    {
        levelShowScript = GameObject.Find("levelShow").GetComponent<levelShow>();    
    }

    public void onButtonClick()
    {    
        levelShowScript.ShowCurrentLevel(0);
    }
}
