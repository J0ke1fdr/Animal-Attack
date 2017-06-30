using UnityEngine;
using System.Collections;

public class RandBox : MonoBehaviour
{
    public int maxWeaponCount = 3;

    public void DestroyProp(int deadTime)
    {
        Destroy(gameObject, deadTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("AddWeaponByIndex", RandWeapon());
            Destroy(gameObject);
        }
    }

    private int RandWeapon()
    {
        return Random.Range(1, maxWeaponCount + 1);
    }
}