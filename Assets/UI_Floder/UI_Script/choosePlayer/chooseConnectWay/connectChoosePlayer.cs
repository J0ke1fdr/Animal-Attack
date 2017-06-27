using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class connectChoosePlayer : MonoBehaviour {

    
    private Button choosePlayerButton;
    public Sprite[] player;

    public Image leftChoosedPlayerImage; 
    private Text leftPlayerName;

    public Image rightChoosedPlayerImage;
    private Text rightPlayerName;

    private Text leftPlayerIdText;
    private Text rightPlayerIdText;
    private Text errorText;

    private void Start()
    {
        choosePlayerButton = gameObject.GetComponent<Button>();

        leftChoosedPlayerImage = GameObject.Find("leftChoosedPlayer/choosedPlayerImg").GetComponent<Image>();
        leftPlayerName = GameObject.Find("leftChoosedPlayer/choosedPlayerText").GetComponent<Text>();

        rightChoosedPlayerImage = GameObject.Find("rightChoosedPlayer/choosedPlayerImg").GetComponent<Image>();
        rightPlayerName = GameObject.Find("rightChoosedPlayer/choosedPlayerText").GetComponent<Text>();

        leftPlayerIdText = GameObject.Find("leftChoosedPlayer/leftPlayerIdText").GetComponent<Text>();
        rightPlayerIdText = GameObject.Find("rightChoosedPlayer/rightPlayerIdText").GetComponent<Text>();

        leftPlayerName.text = "角色名称";
        rightPlayerName.text = "角色名称";

        errorText = GameObject.Find("ErrorText").GetComponent<Text>();
        errorText.text = "请选择联机方式";

    }
    public void onChooseClick()
    {

        // choosedPlayerIndex.choosedIndex = choosePlayerButton.name;
        if (choosePlayerManager.choosedConnectWay == -1)//未选择联机方式
        {
           // errorText.gameObject.SetActive(true);
            errorText.text = "请先选择联机方式";
            
        }

         else if (choosePlayerManager.choosedConnectWay == 0)//左边
        {         
            switch (choosePlayerButton.name)
            {
                case "1": choosePlayerManager.leftChoosedPlayer = 0; break;
                case "2": choosePlayerManager.leftChoosedPlayer = 1; break;
                case "3": choosePlayerManager.leftChoosedPlayer = 2; break;
                case "4": choosePlayerManager.leftChoosedPlayer = 3; break;
            }
            Debug.Log("Left" + choosePlayerManager.leftChoosedPlayer);
            leftChoosedPlayerImage.sprite = player[choosePlayerManager.leftChoosedPlayer];
            leftPlayerName.text = "角色" + gameObject.name;

            leftPlayerIdText.text = "我";
            rightPlayerIdText.text = "其它玩家名";
        }

        else if (choosePlayerManager.choosedConnectWay == 1)//右边
        {
             switch (choosePlayerButton.name)
            {
                case "1": choosePlayerManager.righrChoosedPlayer = 0; break;
                case "2": choosePlayerManager.righrChoosedPlayer = 1; break;
                case "3": choosePlayerManager.righrChoosedPlayer = 2; break;
                case "4": choosePlayerManager.righrChoosedPlayer = 3; break;
            }
            Debug.Log("Left" + choosePlayerManager.righrChoosedPlayer);
            rightChoosedPlayerImage.sprite = player[choosePlayerManager.righrChoosedPlayer];
            rightPlayerName.text = "角色" + gameObject.name;

            rightPlayerIdText.text = "我";
            leftPlayerIdText.text = "其它玩家名";
        }      
    }
}
