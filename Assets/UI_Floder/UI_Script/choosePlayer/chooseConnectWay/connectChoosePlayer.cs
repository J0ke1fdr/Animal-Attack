using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class connectChoosePlayer : MonoBehaviour
{
    private Button choosePlayerButton;
    public Sprite[] player;

    public Image choosedPlayerImage;
    private Text choosedPlayerName;
    private string Name;

    private void Start()
    {
        choosePlayerButton = gameObject.GetComponent<Button>();

        choosedPlayerImage = GameObject.Find("choosedPlayer/choosedPlayerImg").GetComponent<Image>();
        choosedPlayerName = GameObject.Find("choosedPlayerText").GetComponent<Text>();

        choosedPlayerName.text = "Farmer";
    }

    public void onChooseClick()
    {
        switch (choosePlayerButton.name)
        {
            case "Farmer": MenuSceneManager.choosedPlayer = 0; name = "Farmer"; break;
            case "Athlete": MenuSceneManager.choosedPlayer = 1; name = "Athlete"; break;
            case "Soldier": MenuSceneManager.choosedPlayer = 2; name = "Soldier"; break;
        }
        // Debug.Log("Left" + choosePlayerManager.leftChoosedPlayer);
        choosedPlayerImage.sprite = player[MenuSceneManager.choosedPlayer];
        choosedPlayerName.text = gameObject.name;
    }
}