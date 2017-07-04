using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class soundEffectSwich : MonoBehaviour {
    
    public Sprite[] soundImg;
    private Button soundButton;

    private void Awake()
    {      
        soundButton = GameObject.Find("soundEffect").GetComponent<Button>();
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
        soundButton.image.sprite = soundImg[soundImgIndex];
    }
}
