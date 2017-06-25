using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour {
    public GameObject blood;
	// Use this for initialization
	void Start () {
	    for (int i = 0; i < 50; i++)
        {
            /*GameObject obj = (GameObject)Instantiate(blood, transform.position,
                   Quaternion.EulerAngles(20f, Random.Range(-5, 5), Random.Range(-5, 5)));*/
            GameObject obj = (GameObject)Instantiate(blood, transform.position, transform.rotation);
        }            
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
