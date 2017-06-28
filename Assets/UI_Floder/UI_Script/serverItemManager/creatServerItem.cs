using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class creatServerItem : MonoBehaviour {

  //  public List<ServerModel.Server> ServerItemList;
    public RectTransform ServerItemButton;
    private float startYPos;
    private static int SetverCount = 2;
    private const int deltaY = 45;

   // public static List<ServerModel.Server> serverList { get; set; }
    static int i = 0;

    public Button createdButton;

    // Use this for initialization
    void Start () {
        startYPos = transform.position.y;

      //  serverList = new List<ServerModel.Server>();
      //  serverList = ServerModel.ServerManager.GetServerList();
        
    }

    // Update is called once per frame
    void Update()
    {
        List<ServerModel.Server> serverList = ServerModel.ServerManager.GetServerList();
        for (;i< serverList.Count;i++)
        {
            Instantiate(ServerItemButton.gameObject, new Vector3(transform.position.x, transform.position.y - deltaY * (i + 1)), transform.rotation, transform);
            // Debug.Log(serverList[i].Name);
           // Debug.Log(createdButton.gameObject.name);
        }
        //如果有新的，创建一个实例，取消时销毁
        //if (i < ServerModel.ServerManager.GetServerList().Count)
        //{
        //    foreach (var serverItem in ServerModel.ServerManager.GetServerList())
        //    {
        //        if (i < ServerModel.ServerManager.GetServerList().Count)
        //        {

        //            //   Debug.Log(serverItem.Name + "\n");

        //            // Button newServerItem;
        //            //  RectTransform newServerItem = new RectTransform();
        //            //Instantiate(ServerItemButton.gameObject, new Vector3(transform.position.x, transform.position.y - deltaY * i), transform.rotation, transform);

        //            // Text serverName = newServerItem.GetComponentInChildren<Text>();
        //            Debug.Log(serverItem.Name);
        //            //serverName.text = serverItem.Name;   

        //            i++;
        //        }
        //    }
            
        //}
    }
}
