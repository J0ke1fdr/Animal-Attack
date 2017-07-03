using UnityEngine;
using System.Collections;

public class AppearBox : MonoBehaviour
{
    private Collider col;
    public GameObject BossElement;
    public Transform bossAppear;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && col.isTrigger)
        {
            Instantiate(BossElement, bossAppear.position, bossAppear.rotation);
            Destroy(gameObject);
        }
    }
}