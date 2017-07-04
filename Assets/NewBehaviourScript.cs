using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Use this for initialization

    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Test);
    }

    void Test()
    {
        Debug.Log("onclick");
    }
}