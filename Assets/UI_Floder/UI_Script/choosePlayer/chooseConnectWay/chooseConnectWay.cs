using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class chooseConnectWay : MonoBehaviour {

 //   private Button choosedWay;

    private Button creatRoomButton;
    private Button joinInRoomButton;

    private Text errorText;
    // Use this for initialization
    void Start () {
     //   choosedWay = gameObject.GetComponent<Button>();

        creatRoomButton = GameObject.Find("creatRoom").GetComponent<Button>();
        joinInRoomButton = GameObject.Find("joinInRoom").GetComponent<Button>();

        errorText = GameObject.Find("ErrorText").GetComponent<Text>();
        // errorText.gameObject.SetActive(false);
        errorText.text = "请选择联机方式";

        creatRoomButton.enabled = true;
        joinInRoomButton.enabled = true;

    }

   
	
	public void onChoosedWayClick()
    {
        switch(gameObject.name)
        {
            case "creatRoom":choosePlayerManager.choosedConnectWay = 0;break;
            case "joinInRoom": choosePlayerManager.choosedConnectWay = 1; break;
        }
        //Debug.Log(choosePlayerManager.choosedConnectWay);
        if(errorText.gameObject.activeSelf)
        {
            errorText.gameObject.SetActive(false);
        }
        creatRoomButton.enabled = false;
        joinInRoomButton.enabled = false;
    }

}
