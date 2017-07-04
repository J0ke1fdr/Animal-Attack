using UnityEngine;
using System.Collections;

public class RandBox : MonoBehaviour
{
    public int maxWeaponCount = 3;
    public Collider col;
    private bool canPickUp = false;

    private int currentLevel;

    private void Start()
    {
        try
        {
            currentLevel = GameObject.Find("CreateAnimalPoints").GetComponent<LevelManager>().getLevel();
        }
        catch
        {
            currentLevel = maxWeaponCount;
        }
    }

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
            other.gameObject.SendMessage("AddWeaponByIndex", RandWeapon());
            Destroy(gameObject);
        }
    }

    private int RandWeapon()
    {
        int randCount = Mathf.Min(currentLevel, maxWeaponCount);

        return Random.Range(1, currentLevel);
    }
}