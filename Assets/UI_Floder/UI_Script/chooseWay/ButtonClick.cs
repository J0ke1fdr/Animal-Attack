using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour {

    private RectTransform creatButton;
    private RectTransform joinInButton;
    private RectTransform closeButton;
    private RectTransform okButton;

    private RectTransform roomPanel;

    private RectTransform creatRoomName;

    /****************MeneScene**************/
  //  private RectTransform choosePlayerScene;
  //  private RectTransform connectScene;

    private void Awake()
    {
        creatButton = GameObject.Find("creatRoom").GetComponent<RectTransform>();
        joinInButton = GameObject.Find("joinInRoom").GetComponent<RectTransform>();
        closeButton = GameObject.Find("closeScene").GetComponent<RectTransform>();
        okButton = GameObject.Find("OK").GetComponent<RectTransform>();

        roomPanel = GameObject.Find("roomPanel").GetComponent<RectTransform>();

        creatRoomName = GameObject.Find("createdRoomName").GetComponent<RectTransform>();

       // choosePlayerScene = GameObject.Find("choosePlayer").GetComponent<RectTransform>();
      //  connectScene = GameObject.Find()



    }

    private void Start()
    {
        //okButton.gameObject.SetActive(false);
        //roomPanel.gameObject.SetActive(false);
        //creatRoomName.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(creatButton.gameObject.activeSelf && joinInButton.gameObject.activeSelf)
        {
            okButton.gameObject.SetActive(false);
            roomPanel.gameObject.SetActive(false);
            creatRoomName.gameObject.SetActive(false);
        }
    }

    public void onCreatRoomClick()///创建游戏
    {
        Debug.Log("creat");
        

        creatButton.gameObject.SetActive(false);
        joinInButton.gameObject.SetActive(false);
        roomPanel.gameObject.SetActive(false);

        okButton.gameObject.SetActive(true);
        creatRoomName.gameObject.SetActive(true);     
    }

    public void onJoinInRoomClick()
    {
        Debug.Log("join");
        creatButton.gameObject.SetActive(false);
        joinInButton.gameObject.SetActive(false);
        okButton.gameObject.SetActive(false);

        roomPanel.gameObject.SetActive(true);
    }

    public void onCloseSceneClick()
    {
        Debug.Log("close");
        if (roomPanel.gameObject.activeSelf)
        {
            roomPanel.gameObject.SetActive(false);
            creatButton.gameObject.SetActive(true);
            joinInButton.gameObject.SetActive(true);
        }
        else if (okButton.gameObject.activeSelf)
        {
            okButton.gameObject.SetActive(false);
            creatRoomName.gameObject.SetActive(false);

            creatButton.gameObject.SetActive(true);
            joinInButton.gameObject.SetActive(true);

        }
        else
        {
            //加载主菜单
            MenuSceneManager.connectScene.gameObject.SetActive(false);
            MenuSceneManager.mainMenuScene.gameObject.SetActive(true);
        }
    }

    public void onOkClick()
    {
        Debug.Log("OK");
        MenuSceneManager.connectScene.gameObject.SetActive(false);
        MenuSceneManager.chooseScene.gameObject.SetActive(true);
    }
}
