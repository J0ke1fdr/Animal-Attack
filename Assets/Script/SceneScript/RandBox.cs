using UnityEngine;
using System.Collections;

public class RandBox : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetTrigger("OnFloor");
        }
        else if (collision.gameObject.tag == "Player")
        {
            // collision.gameObject.SendMessage("AddWeapon", 1);
            Destroy(gameObject);
        }
    }

    private void RandWeapon()
    {
    }
}