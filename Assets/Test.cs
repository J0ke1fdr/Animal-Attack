using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    public List<GameObject> animalList = new List<GameObject>();
    public GameObject points;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Instantiate(points, transform) as GameObject;
            Vector3 pos = transform.position;
            float x = Random.Range(transform.position.x - 10, transform.position.x + 10);
            float z = Random.Range(transform.position.z - 10, transform.position.z + 10);
            pos.x = x;
            pos.z = z;
            obj.transform.position = pos;
            animalList.Add(obj);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(animalList[0]);
            animalList.RemoveAt(0);
        }
    }
}