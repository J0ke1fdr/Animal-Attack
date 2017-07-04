using UnityEngine;
using System.Collections;

public class camera_follow : MonoBehaviour
{
    public float xMargin;
    public float zMargin;
    public float xSmooth;
    public float zSmooth;
    public Vector3 maxXAndZ;
    public Vector3 minXAndZ;

    //[HideInInspector]
    public Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    private bool CheckzMargin()
    {
        return Mathf.Abs(transform.position.z - player.position.z) > zMargin;
    }

    private void TrackPlayer()
    {
        float targetX = transform.position.x;
        float targetZ = transform.position.z;

        if (CheckXMargin())

            //targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth);

        if (CheckzMargin())
            //targetZ = Mathf.Lerp(transform.position.z, player.position.z, zSmooth);
            targetZ = Mathf.Lerp(transform.position.z, player.position.z - 10, zSmooth);

        targetX = Mathf.Clamp(targetX, minXAndZ.x, maxXAndZ.x);
        targetZ = Mathf.Clamp(targetZ, minXAndZ.z, maxXAndZ.z);

        transform.position = new Vector3(targetX, transform.position.y, targetZ);
    }

    public void Update()
    {
        TrackPlayer();
    }
}