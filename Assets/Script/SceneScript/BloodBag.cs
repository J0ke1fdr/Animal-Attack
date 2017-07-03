using UnityEngine;
using System.Collections;

public class BloodBag : MonoBehaviour
{
    public int minblood = 10;
    public int maxblood = 50;

    public Collider col;
    private bool canPickUp = false;

    public void DestroyProp(int deadTime)
    {
        Destroy(gameObject, deadTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            canPickUp = true;
            col.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && canPickUp)
        {
            other.gameObject.SendMessage("ApplyHealth", RandBlood());
            Destroy(gameObject);
        }
    }

    private int RandBlood()
    {
        return Random.Range(minblood, maxblood);
    }
}