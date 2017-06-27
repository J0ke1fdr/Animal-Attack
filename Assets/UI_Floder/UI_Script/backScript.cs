using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backScript : MonoBehaviour {
    private string sceneName;
	// Use this for initialization
	public void onBackClick()
    {
        sceneName = SceneManager.GetActiveScene().name;
        switch(sceneName)
        {
            case "choosePlayerScene": ;break;//如果是单人选择玩家场景，则加载主菜单场景
            case "chooseLevelScene": ;break;//加载选择人物场景（需判断单人或多人）
            case "chooseConnectWay":;break;//如果是多人选择模式，玩家场景，加载主菜单场景
        }

    }
}
