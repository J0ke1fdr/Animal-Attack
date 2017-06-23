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
            transform.LookAt(currentEnemy.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentEnemy = other.gameObject;
        Debug.Log("find enemy");
        
    }
}
