using UnityEngine;
using System.Collections;

public class serverItemClick : MonoBehaviour {


	public void onServerItemClick()
    {
        foreach (var serverItem in ServerModel.ServerManager.GetServerList())
        {
            if(gameObject.name == serverItem.Name)
            {
                //开始连接
                Debug.Log(gameObject.name + "开始连接");
            }
        }
    }
}
