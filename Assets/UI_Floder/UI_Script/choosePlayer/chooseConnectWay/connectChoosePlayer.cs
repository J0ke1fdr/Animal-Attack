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
            case "1": MenuSceneManager.choosedPlayer = 0; break;
            case "2": MenuSceneManager.choosedPlayer = 1; break;
            case "3": MenuSceneManager.choosedPlayer = 2; break;
            case "4": MenuSceneManager.choosedPlayer = 3; break;
        }
        // Debug.Log("Left" + choosePlayerManager.leftChoosedPlayer);
        choosedPlayerImage.sprite = player[MenuSceneManager.choosedPlayer];
        choosedPlayerName.text = "角色" + gameObject.name;

    }
}
