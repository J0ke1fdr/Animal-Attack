using UnityEngine;
using System.Collections;

public class ElementPoint : MonoBehaviour
{
    public float stayTime = 30;
    public GameObject ElementObj;
    private float currentTime = 0;
    private bool playerIn = false;
    // private bool getElement = false;

    private void Update()
    {
        if (playerIn)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= stayTime)
            {
                Instantiate(ElementObj, transform.position, transform.rotation);
                Destroy(gameObject);
                //  getElement = true;
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(currentTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIn = false;
        }
    }
}