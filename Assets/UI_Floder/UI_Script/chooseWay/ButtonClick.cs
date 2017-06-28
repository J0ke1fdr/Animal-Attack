using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour {

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
        okButton = GameObject.Find("OK").GetComponent<RectTransform>();

        roomPanel = GameObject.Find("roomPanel").GetComponent<Image>();

        creatRoomName = GameObject.Find("roomName").GetComponent<Image>();
    }

    private void Start()
    {
        okButton.gameObject.SetActive(false);
        roomPanel.gameObject.SetActive(false);
        creatRoomName.gameObject.SetActive(false);
    }

    public void onCreatRoomClick()///创建游戏
    {
        Debug.Log("creat");
        okButton.gameObject.SetActive(true);
        creatRoomName.gameObject.SetActive(true);

        creatButton.gameObject.SetActive(false);
        joinInButton.gameObject.SetActive(false);


        //  if (!okButton.gameObject.activeSelf)
        // {

        //  }

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
            SceneManager.LoadScene(0);//加载主菜单
        }

    }

    public void onOkClick()
    {
        Debug.Log("OK");
    }
}
