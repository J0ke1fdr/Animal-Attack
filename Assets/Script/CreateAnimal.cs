using UnityEngine;
using System.Collections;

public class CreateAnimal : MonoBehaviour {

    private bool notUsed = true;
    public GameObject crow;
    public GameObject crab;
	// Use this for initialization
	void Start () {
        StartCoroutine(createAnimal());
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && notUsed)
        {
            notUsed = false;
            StartCoroutine(createAnimal());
        }
    }*/

    IEnumerator createAnimal()
    {
        for(int i=0; i < 20; i++)
        {
            if(i % 3 == 0)
            {
                GameObject obj = (GameObject)Instantiate(crab, transform.position, transform.rotation);
            }
            GameObject obj1 = (GameObject)Instantiate(crow, transform.position, transform.rotation);
            yield return new WaitForSeconds(3);
        }
    }
}


