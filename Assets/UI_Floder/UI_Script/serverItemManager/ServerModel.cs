using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ServerModel : MonoBehaviour {

    public class Server
    {
        public String Name { get; set; }
        //String IP;
    }

    public static List<Server> ServerList = new List<Server>();

    public class ServerManager
    {           
        public static List<Server> GetServerList()
        {
            //ServerList.Add(new Server { Name = "Socket1" });
            //ServerList.Add(new Server { Name = "Socket2" });
            //ServerList.Add(new Server { Name = "Socket3" });
            return ServerList;
        }

        public static void AddServerToServerList(Server newServer)
        {
            bool hasValue = false;
            foreach(var item in ServerList)
            {
                if(item.Name == newServer.Name)
                {
                    hasValue = true;
                }
                
            }
            if(!hasValue)
            {
                ServerList.Add(newServer);
            }
            
        }

        public static void RemoveServerToServerList(Server newServer)
        {          
            foreach (var item in ServerList)
            {
                if (item.Name == newServer.Name)
                {
                    ServerList.Remove(item);
                }

            }        
        }

    }

}
