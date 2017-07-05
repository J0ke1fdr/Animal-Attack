using UnityEngine;
using System.Collections;

public class LookCamera : MonoBehaviour
{
    // Use this for initialization

    private Camera cam;

    private void Start()
    {
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(cam.transform);
    }
}