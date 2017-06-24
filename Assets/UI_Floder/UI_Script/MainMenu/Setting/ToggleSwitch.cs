using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour {

    public Toggle Toggle;
   
    private Slider bgmSlider;
    private Slider soundEffectSlider;

    private Text musicToggleText;
    private Text soundEffectToggleText;
	// Use this for initialization
	void Start () {
        Toggle = gameObject.GetComponent<Toggle>();
        if (gameObject.name == "bgmToggle")
        {
            bgmSlider = GameObject.Find("music/Slider").GetComponent<Slider>();
            musicToggleText = GameObject.Find("bgmToggle/Label").GetComponent<Text>();
        }
        else if(gameObject.name == "soundEffectToggle")
        {          
            soundEffectSlider = GameObject.Find("soundEffect/Slider").GetComponent<Slider>();
            soundEffectToggleText = GameObject.Find("soundEffectToggle/Label").GetComponent<Text>();
        }
	}
	
    public void onToggleSwitch()
    {
        if(Toggle.isOn)
        {
            Debug.Log(gameObject.name);
            if(Toggle.gameObject.name == "bgmToggle")
            {
                bgmSlider.enabled = true;
                musicToggleText.text = "开";
            }
            else if(gameObject.name == "soundEffectToggle")
            {
                soundEffectSlider.enabled = true;
                soundEffectToggleText.text = "开";
            }
            
        }
        else
        {
            Debug.Log(gameObject.name);
            if (Toggle.gameObject.name == "bgmToggle")
            {
                bgmSlider.enabled = false;
                musicToggleText.text = "关";

            }
            else if (Toggle.gameObject.name == "soundEffectToggle")
            {
                soundEffectSlider.enabled = false;
                soundEffectToggleText.text = "关";
            }
        }
    }
}
