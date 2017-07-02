using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour
{
    private ElementsManager manager;

    private void Start()
    {
        manager = GameObject.Find("Elements").GetComponent<ElementsManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.GetElement();
            Destroy(gameObject);
        }
    }
}