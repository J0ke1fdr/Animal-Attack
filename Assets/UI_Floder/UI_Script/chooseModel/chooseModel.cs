using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class chooseModel : MonoBehaviour
{
    public Sprite[] Level1picShow;
    public Sprite[] otherModel1picShow;
    private Image Level1;
    private Image otherModel;

    private void Awake()
    {
        Level1 = GameObject.Find("adventureModel").GetComponent<Image>();
        otherModel = GameObject.Find("otherModel").GetComponent<Image>();
    }

    public void onLevel1Click()
    {
        if (Level1.sprite != Level1picShow[1])
        {
            Level1.sprite = Level1picShow[1];
            otherModel.sprite = otherModel1picShow[0];
        }

        MenuSceneManager.choosedScene = 1;
        MenuSceneManager.choosedModel = 0;
        //  Debug.Log("模式" + MenuSceneManager.choosedModel);
    }

    public void onOtherModelClick()
    {
        if (otherModel.sprite != otherModel1picShow[1])
        {
            Level1.sprite = Level1picShow[0];
            otherModel.sprite = otherModel1picShow[1];
        }

        MenuSceneManager.choosedModel = 1;
        MenuSceneManager.choosedScene = 2;
        Debug.Log("模式1" + MenuSceneManager.choosedModel);
    }
}