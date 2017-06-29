using UnityEngine;
using System.Collections;

public class cameraTest : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(player);
    }
}