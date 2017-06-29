using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    private RectTransform creatButton;
    private RectTransform joinInButton;
    private RectTransform closeButton;
    private RectTransform okButton;

    private Image roomPanel;

    private Image creatRoomName;

    private void Awake()
    {
        creatButton = GameObject.Find("creatRoom").GetComponent<RectTransform>();
        joinInButton = GameObject.Find("joinInRoom").GetComponent<RectTransform>();
        closeButton = GameObject.Find("closeScene").GetComponent<RectTransform>();
        okButton = GameObject.Find("okButton").GetComponent<RectTransform>();

        roomPanel = GameObject.Find("roomPanel").GetComponent<Image>();

        creatRoomName = GameObject.Find("roomName").GetComponent<Image>();
    }
    // Use this for initialization
    void Start () {


        okButton.gameObject.SetActive(false);
        roomPanel.gameObject.SetActive(false);
        creatRoomName.gameObject.SetActive(false);
    }
	

    
}
