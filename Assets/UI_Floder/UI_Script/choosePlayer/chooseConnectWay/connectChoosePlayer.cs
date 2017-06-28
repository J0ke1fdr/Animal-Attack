using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class connectChoosePlayer : MonoBehaviour {

    
    private Button choosePlayerButton;
    public Sprite[] player;

    public Image choosedPlayerImage; 
    private Text choosedPlayerName;

    private void Start()
    {
        choosePlayerButton = gameObject.GetComponent<Button>();

        choosedPlayerImage = GameObject.Find("choosedPlayer/choosedPlayerImg").GetComponent<Image>();
        choosedPlayerName = GameObject.Find("choosedPlayerText").GetComponent<Text>();

        choosedPlayerName.text = "角色名称";
    }
    public void onChooseClick()
    {

        switch (choosePlayerButton.name)
        {
            case "1": choosePlayerManager.leftChoosedPlayer = 0; break;
            case "2": choosePlayerManager.leftChoosedPlayer = 1; break;
            case "3": choosePlayerManager.leftChoosedPlayer = 2; break;
            case "4": choosePlayerManager.leftChoosedPlayer = 3; break;
        }
        // Debug.Log("Left" + choosePlayerManager.leftChoosedPlayer);
        choosedPlayerImage.sprite = player[choosePlayerManager.leftChoosedPlayer];
        choosedPlayerName.text = "角色" + gameObject.name;

    }
}
