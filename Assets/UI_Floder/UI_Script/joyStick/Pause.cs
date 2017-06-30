using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {


	public void onPauseClick()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
    }
}
