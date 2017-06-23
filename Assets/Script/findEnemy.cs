using UnityEngine;
using System.Collections;

public class findEnemy : MonoBehaviour {

    private GameObject currentEnemy = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(currentEnemy != null)
        {
            //Debug.Log(Vector3.Distance(currentEnemy.transform.position, transform.position));
            if (Vector3.Distance(currentEnemy.transform.position, transform.position) > 60)
            {
                currentEnemy = null;
            }
            else
            {
                transform.LookAt(currentEnemy.transform);
            }
        }
            
            
    }

    private void OnTriggerStay(Collider other)
    {
        if(currentEnemy == null)
        {
            currentEnemy = other.gameObject;
            Debug.Log("find enemy");
        }
        
    }

}
