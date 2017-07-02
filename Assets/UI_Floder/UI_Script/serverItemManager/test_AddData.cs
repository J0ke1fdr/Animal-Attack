using UnityEngine;
using System.Collections;

public class test_AddData : MonoBehaviour {
    public ServerModel creat;
	// Use this for initialization
	void Start () {
        creat = GameObject.Find("serverItem").GetComponent<ServerModel>();
	}
    static int i = 0;
	
	public void onAddClick()
    {
        ServerModel.Server newData = new ServerModel.Server();
        newData.Name = "Socket" + i;
        ServerModel.ServerManager.AddServerToServerList(newData);
        i++;
    }
}
