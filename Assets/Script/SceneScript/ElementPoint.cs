using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ElementPoint : MonoBehaviour
{
    public float stayTime = 30;
    public GameObject ElementObj;
    public sliderManager slider;
    private float currentTime = 0;
    private bool playerIn = false;
    public Color color;

    private void Update()
    {
        if (playerIn)
        {
            currentTime += Time.deltaTime;
            slider.setValue(stayTime - currentTime);
            if (currentTime >= stayTime)
            {
                Instantiate(ElementObj, transform.position, transform.rotation);
                slider.setActive(false);
                Destroy(gameObject);
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(currentTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIn = true;
            slider.setActive(true);
            slider.setMaxValue(stayTime);
            slider.setColor(color);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIn = false;
            slider.setActive(false);
        }
    }
}