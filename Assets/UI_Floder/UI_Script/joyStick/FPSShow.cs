using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSShow : MonoBehaviour {

    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames = 0;
    private float fps;
    Text FPSText;
    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
        FPSText = gameObject.GetComponent<Text>();
    }
    void OnGUI()
    {
       // GUILayout.Label(" " + fps.ToString("f2"));
    }
    void Update()
    {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (int)(frames / (timeNow - lastInterval));
            FPSText.text = "FPS:" + fps.ToString();
            frames = 0;
            lastInterval = timeNow;
        }
        
    }

}
