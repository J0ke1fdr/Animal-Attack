using UnityEngine;
using System.Collections;

public class BloodBag : MonoBehaviour
{
    public int minblood = 10;
    public int maxblood = 50;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            // collision.gameObject.SendMessage("AddBlood", randBlood());
            Destroy(gameObject);
        }
    }

    private int RandBlood()
    {
        return Random.Range(minblood, maxblood);
    }
}