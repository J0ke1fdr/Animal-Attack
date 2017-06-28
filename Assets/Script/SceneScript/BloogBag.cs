using UnityEngine;
using System.Collections;

public class BloogBag : MonoBehaviour
{
    public int minblood = 10;
    public int maxblood = 50;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("AddBlood", randBlood());
        }
    }

    private int randBlood()
    {
        return Random.Range(minblood, maxblood);
    }

    private IEnumerator waitDestroy()
    {
        for (int i = 0; i < 10; i++)
        {
            // GetComponent<Material>().Ap
            yield return null;
        }
    }
}