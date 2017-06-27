using UnityEngine;
using System.Collections;

public class LightRoadFlash : MonoBehaviour
{
    public Light lightRoad;
    public float lightIntensity;
    public float changeSpeed;

    private void FixedUpdate()
    {
        float random = Random.Range(0, lightIntensity);
        LightChange(random);
    }

    public void LightChange(float intensity)
    {
        lightRoad.intensity = Mathf.Lerp(lightRoad.intensity, intensity, Time.deltaTime * changeSpeed);
    }
}