using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Use this for initialization

    public GameObject grassBroken;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(grassBroken);
    }
}