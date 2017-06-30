using UnityEngine;
using System.Collections;

public class StabEffect : MonoBehaviour
{
    public float damage = 10;
    public float damageTimeSpan = 1;
    private float lastTime = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && Time.time - lastTime > damageTimeSpan)
        {
            other.gameObject.SendMessage("ApplyDamage", damage);
            lastTime = Time.time;
        }
    }
}