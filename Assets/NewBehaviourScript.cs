using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Use this for initialization

    public BackgroundMusic bgm;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayerPrefs.SetInt("MusicSetting", 0);
        if (Input.GetKeyDown(KeyCode.C))
            PlayerPrefs.SetInt("MusicSetting", 1);

        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerPrefs.SetInt("CharacterMusicSetting", 1);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.SetInt("CharacterMusicSetting", 0);
        }
    }
}