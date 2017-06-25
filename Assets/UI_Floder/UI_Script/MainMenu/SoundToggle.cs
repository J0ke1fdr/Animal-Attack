using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour {


    private Toggle soundToggle;
	// Use this for initialization
	void Start () {
        soundToggle = gameObject.GetComponent<Toggle>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(soundToggle.isOn);
	}
}
