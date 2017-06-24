using UnityEngine;
using System.Collections;

public class camera_follow : MonoBehaviour {

    public float xMargin;		
    public float zMargin;		
    public float xSmooth;		
    public float zSmooth;		
    public Vector3 maxXAndZ;	
    public Vector3 minXAndZ;	

    //[HideInInspector]
    public Transform player;


    void Start()
    {
        //player = GameObject.Find("man").transform;


    }


    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }


    bool CheckzMargin()
    {
        return Mathf.Abs(transform.position.z - player.position.z) > zMargin;
    }
    

    void TrackPlayer()
    {
        float targetX = transform.position.x;
        float targetZ = transform.position.z;

        if (CheckXMargin())
          
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);

        if (CheckzMargin())

            targetZ = Mathf.Lerp(transform.position.z, player.position.z, zSmooth * Time.deltaTime);

        targetX = Mathf.Clamp(targetX, minXAndZ.x, maxXAndZ.x);
        targetZ = Mathf.Clamp(targetZ, minXAndZ.z, maxXAndZ.z);

        //transform.position = new Vector3(targetX, transform.position.y, targetZ);
        transform.position = new Vector3(player.position.x, transform.position.y, targetZ - 2);
    }
    public void LateUpdate()
    {
        TrackPlayer();
    }
}
