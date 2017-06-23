using UnityEngine;
using System.Collections;

public class LeftTouch : MonoBehaviour {

    public RectTransform leftTouchButton;
    public RectTransform bgPanel;
   // public RectTransform 

	// Use this for initialization
	void Start () {
        leftTouchButton = GameObject.Find("LeftTouchButton").GetComponent<RectTransform>();
        bgPanel = GameObject.Find("bg").GetComponent<RectTransform>();
	
	}

    //private void OnMouseDrag()
    //{
    //    Debug.Log(bgPanel.position.x + ";" + bgPanel.position.y);
    //}
    //private void OnMouseOver()
    //{
    //    Debug.Log(bgPanel.position.x + ";" + bgPanel.position.y);
    //}

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        Debug.Log(mousePosition.x + ";" + mousePosition.y);
    }

    public void onPress()
    {

    }
	// Update is called once per frame
	void Update () {
        



    }
}
