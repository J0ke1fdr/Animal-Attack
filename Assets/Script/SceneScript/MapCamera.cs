using UnityEngine;
using System.Collections;

public class MapCamera : MonoBehaviour
{
    private Transform player;

    // Use this for initialization
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 pos = player.transform.position;
        pos.y = transform.position.y;
        transform.position = pos;
    }
}