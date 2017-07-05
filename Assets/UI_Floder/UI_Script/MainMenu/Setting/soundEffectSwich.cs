using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class soundEffectSwich : MonoBehaviour
{
    public Sprite[] soundImg;
    private Button soundButton;
    private bool musicOpen = true;

    private void Awake()
    {
        soundButton = GameObject.Find("soundEffect").GetComponent<Button>();
        soundImgIndex = PlayerPrefs.GetInt("MusicSetting", 1);
        soundButton.image.sprite = soundImg[soundImgIndex];
    }

    private static int soundImgIndex = 0;

    public void onSoundClick()
    {
        if (soundImgIndex == 0)
        {
            soundImgIndex++;
            musicOpen = true;
        }
        else if (soundImgIndex == 1)
        {
            soundImgIndex--;
            musicOpen = false;
        }
        soundButton.image.sprite = soundImg[soundImgIndex];
        SaveSetting(musicOpen);
    }

    public bool GetSoundEffectStatus()
    {
        return musicOpen;
    }

    private void SaveSetting(bool play)
    {
        PlayerPrefs.SetInt("MusicSetting", play ? 1 : 0);
        PlayerPrefs.SetInt("CharacterMusicSetting", play ? 1 : 0);
    }
}