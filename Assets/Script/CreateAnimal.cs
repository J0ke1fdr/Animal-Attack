using UnityEngine;
using System.Collections;

public class CreateAnimal : MonoBehaviour {

    private bool notUsed = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && notUsed)
        {
            notUsed = true;
        }
    }
}


