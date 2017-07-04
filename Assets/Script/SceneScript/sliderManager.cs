using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sliderManager : MonoBehaviour
{
    private Slider slider;
    public Image image;

    public void Start()
    {
        slider = GetComponent<Slider>();
        gameObject.SetActive(false);
    }

    public void setMaxValue(float max)
    {
        slider.maxValue = max;
    }

    public float getValue()
    {
        return slider.value;
    }

    public void setValue(float value)
    {
        slider.value = value;
    }

    public void setActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void setColor(Color color)
    {
        image.color = color;
    }
}