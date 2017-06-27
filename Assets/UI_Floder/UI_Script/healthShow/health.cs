using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class health : MonoBehaviour {

    public int maxHealth = 100;//最大血量
    public int healthValue = 100;//当前血量
    private Slider healthSlider;
    private RectTransform FillArea;

    private Text textShow;
	// Use this for initialization
	void Start () {
        healthSlider = gameObject.GetComponent<Slider>();
        healthSlider.maxValue = maxHealth;
        textShow = GameObject.Find("healthTextShow").GetComponent<Text>();
        FillArea = GameObject.Find("healthSlider/Fill Area").GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        healthSlider.maxValue = maxHealth;
        if (healthValue > maxHealth)
        {
            healthValue = maxHealth;
        }
        else if(healthValue < 0)
        {
            healthValue = 0;
        }
        
        healthSlider.value = healthValue;

        if(healthSlider.value == 0)
        {
            if(FillArea.gameObject.activeSelf)
            {
                FillArea.gameObject.SetActive(false);
            }
        }
        else
        {
            if(!FillArea.gameObject.activeSelf)
            {
                FillArea.gameObject.SetActive(true);
            }
        }

        textShow.text = healthSlider.value + "/" + healthSlider.maxValue;
	}
}
