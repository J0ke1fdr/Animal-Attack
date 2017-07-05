﻿using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour
{
    public GameObject blood;

    // Use this for initialization
    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            /*GameObject obj = (GameObject)Instantiate(blood, transform.position,
                   Quaternion.EulerAngles(20f, Random.Range(-5, 5), Random.Range(-5, 5)));*/
            GameObject obj = (GameObject)Instantiate(blood, transform.position + new Vector3(0, 1.5f, 0), transform.rotation);
        }
        Destroy(gameObject);
    }
}