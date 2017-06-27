using UnityEngine;
using System.Collections;

public class CrowAttack : MonoBehaviour {
    public bool attack_flag = false;
    private float lastTime = 0;
    private float currentTime = 0;
    private Collider target = null;
    // Use this for initialization
    void Start () {
        attack_flag = true;
        
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(target != null && (currentTime - lastTime > 0.25) && attack_flag)
        {
            target.SendMessage("ApplyDamage", 34);
            Debug.Log("crow Attack!!");
            attack_flag = false;
        }
        if (currentTime - lastTime > 0.35)
        {
            attack_flag = true;
            lastTime = currentTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && attack_flag)
        {
            target = other;
        }
        else
        {
            target = null;
        }
    }
}
