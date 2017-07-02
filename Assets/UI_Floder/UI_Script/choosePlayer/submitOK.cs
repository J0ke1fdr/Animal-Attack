using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class submitOK : MonoBehaviour {
    private Text createdRoomName;

    private void Start()
    {
        createdRoomName = GameObject.Find("createdRoomName/Text").GetComponent<Text>();
    }
    public void onOkButtonClick()
    {
        switch(gameObject.name)
        {
            case "okButton": submitChoosedPlayer(); break;//选择玩家的提交按钮
            case "OK": submitCreatedRoom(); break;//创建房间后确认按钮
            case "": enterGame(); break;//场景和角色选择完成后进入游戏的提交按钮
        }
    }

    private void submitChoosedPlayer()
    {
        Debug.Log("进入submitChoosedPlayer");
        //进入选择场景
    }

    private void submitCreatedRoom()
    {
        Debug.Log("进入submitCreatedRoom");
        //进入选择场景
    }

    private void enterGame()
    {
        Debug.Log("进入enterGame");
        //进入游戏
    }

}
