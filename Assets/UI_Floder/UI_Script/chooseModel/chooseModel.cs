using UnityEngine;
using System.Collections;

public class chooseModel : MonoBehaviour {

	public void onLevel1Click()
    {
        MenuSceneManager.choosedScene = 0;
        MenuSceneManager.choosedModel = 0;
        Debug.Log("模式" + MenuSceneManager.choosedModel);
    }

    public void onOtherModelClick()
    {
        MenuSceneManager.choosedModel = 1;
        MenuSceneManager.choosedScene = 1;
        Debug.Log("模式1" + MenuSceneManager.choosedModel);
    }
}
