using UnityEngine;
using System.Collections;

public class ElementsManager : MonoBehaviour
{
    public GameObject lockDoor;
    private int maxElementCount = 3;
    private int currentGetElementCount = 0;
    private bool getAllElements = false;

    public void GetElement()
    {
        currentGetElementCount++;
    }

    private void Update()
    {
        if (currentGetElementCount >= maxElementCount && !getAllElements)
        {
            lockDoor.GetComponent<Collider>().isTrigger = true;

            getAllElements = true;
        }
    }
}