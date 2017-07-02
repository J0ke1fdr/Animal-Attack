using UnityEngine;
using System.Collections;

public class LockDoor : MonoBehaviour
{
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && col.isTrigger)
        {
        }
    }
}