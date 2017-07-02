using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class creatServerItem : MonoBehaviour {

  //  public List<ServerModel.Server> ServerItemList;
    public RectTransform ServerItemButton;
    private float startYPos;
    private static int ServerCount = 2;
    private const int deltaY = 45;

   // public static List<ServerModel.Server> serverList { get; set; }
    static int i = 0;

    public Button createdButton;

    // Use this for initialization
    void Start () {
        startYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        List<ServerModel.Server> serverList = ServerModel.ServerManager.GetServerList();
        for (;i< serverList.Count;i++)
        {
            GameObject newServer = Instantiate(ServerItemButton.gameObject, new Vector3(transform.position.x, transform.position.y - deltaY * (i + 1)), transform.rotation, transform) as GameObject;


            newServer.name = serverList[i].Name; ;
            Debug.Log(newServer.name);
            // Debug.Log(createdButton.gameObject.name);
        }
        if(serverList.Count != i)//如果列表服务器数目和输出的不一样，说明有改动，则重新生成
        {
            i = 0;
        }
        //如果有新的，创建一个实例，取消时销毁        
    }
}
