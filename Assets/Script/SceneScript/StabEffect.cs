using UnityEngine;
using System.Collections;

public class StabEffect : MonoBehaviour
{
    private float damage = 30;
    public float damageTimeSpan = 0.1f;
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