using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

    public Quaternion originRotation;
    public Quaternion attackRotation;
    private PlayerControl playerControl;

	// Use this for initialization
	void Start ()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
        originRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(playerControl.CheckAttack())
        {
            //transform.rotation = Quaternion.AngleAxis(45, Vector3.up);
            //Quaternion.EulerAngles(0, 0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.2f)
            transform.rotation = Quaternion.EulerAngles(0, 0, -Mathf.Atan2(transform.up.x, transform.up.y));
        }
    }
}
