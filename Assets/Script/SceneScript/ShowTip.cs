using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowTip : MonoBehaviour
{
    public Text tip;

    private void Start()
    {
        Debug.Log("OK");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tip.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tip.gameObject.SetActive(false);
        }
    }
}