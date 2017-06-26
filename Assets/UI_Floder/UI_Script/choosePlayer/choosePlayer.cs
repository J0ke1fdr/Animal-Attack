using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class choosePlayer : MonoBehaviour {

    private Button choosePlayerButton;
    public Image choosedPlayerImage;
    public Sprite[] player;
    private Text playerName;

    private void Start()
    {
        choosePlayerButton = gameObject.GetComponent<Button>();
        choosedPlayerImage = GameObject.Find("choosedPlayerImg").GetComponent<Image>();
        string str = gameObject.name + "/Text";
        // playerName = gameObject.GetComponentInChildren<Text>();
        playerName = GameObject.Find("choosedPlayerText").GetComponent<Text>();
        playerName.text = "角色1";

    }
    public void onChooseClick()
    {
        //Debug.Log()
        choosedPlayerIndex.choosedIndex = choosePlayerButton.name;

        switch (choosePlayerButton.name)
        {
            case "1": choosedPlayerImage.sprite = player[0]; break;
            case "2": choosedPlayerImage.sprite = player[1]; break;
            case "3": choosedPlayerImage.sprite = player[2]; break;
            case "4": choosedPlayerImage.sprite = player[3]; break;
        }
        playerName.text = "角色" + gameObject.name;

        // Debug.Log(playerName + gameObject.name);
    }

}
