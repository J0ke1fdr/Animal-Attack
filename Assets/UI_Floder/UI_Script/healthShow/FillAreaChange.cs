using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillAreaChange : MonoBehaviour {

  //  private Image background;
    private Slider healthSlider;
  //  private Slider lifeSlider;
    private Image healthFillArea;
  //  private Image lifeFillArea;
    

    public int maxHealthValue = 100;
 //   public int maxLifeValue = 5;

    public Text healthTextShow;
//    private Text lifeTextShow;
	// Use this for initialization
	void Start () {

      //  background = GameObject.Find("healthSlider/Background").GetComponent<Image>();
       // if(gameObject.name == "healthSlider")
      //  {
            healthSlider = GameObject.Find("healthSlider").GetComponent<Slider>();
      //  }
//else if (gameObject.name == "lifeSlider")
      //  {
       //     lifeSlider = GameObject.Find("lifeSlider").GetComponent<Slider>();
     //   }
        
        
        
        healthFillArea = GameObject.Find("healthSlider/Fill Area/Fill").GetComponent<Image>();
       // lifeFillArea = GameObject.Find("lifeSlider/Fill Area/Fill").GetComponent<Image>();

        healthTextShow = GameObject.Find("healthTextShow").GetComponent<Text>();
       // lifeTextShow = GameObject.Find("lifeTextShow").GetComponent<Text>();
        
        healthSlider.enabled = false;
       // lifeSlider.enabled = false;

        healthSlider.maxValue = maxHealthValue;
       // lifeSlider.maxValue = maxLifeValue;

      //  lifeSlider.value = maxLifeValue;
        healthSlider.value = maxHealthValue;

	}
	
	// Update is called once per frame
	void Update () {
        healthTextShow.text = healthSlider.value + "/" + maxHealthValue;
      //  lifeTextShow.text = lifeSlider.value + "/" + maxLifeValue;
         // healthSlider.value--;
         //  lifeSlider.value--;
        if (healthSlider.value == 0)
        {
            // fillArea.color = background.color;
            healthFillArea.gameObject.SetActive(false);
        }
        else
        {
            //fillArea.color = Color.green;
            healthFillArea.gameObject.SetActive(true);
        }

        //if(lifeSlider.value == 0)
        //{
        //    healthFillArea.gameObject.SetActive(false);
        //}
        //else
        //{
        //    healthFillArea.gameObject.SetActive(true);
        //}

        //  
        //healthSlider.maxValue = maxHealthValue;
        //maxHealthValue++;
        //healthSlider.value = maxHealthValue;
		
	}
}
