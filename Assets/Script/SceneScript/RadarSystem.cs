using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RadarSystem : MonoBehaviour
{
    public float viewRadius = 20;
    public GameObject animalPrefab;

    private Transform playerHelper;
    public List<GameObject> animalList;
    public List<GameObject> borderAnimals = new List<GameObject>();
    private Camera mapCamera;
    private float scale = 0.92f;
    public Test test;

    private void Start()
    {
        mapCamera = GetComponentInChildren<Camera>();
        mapCamera.orthographicSize = viewRadius;
        playerHelper = GameObject.FindGameObjectWithTag("PlayerHelper").transform;
        animalList = test.animalList;
    }

    private void Update()
    {
        ClearBorderList();
        foreach (var animal in animalList)
        {
            if (Vector3.Distance(playerHelper.position, animal.transform.position) > viewRadius * scale)
            {
                GameObject point = Instantiate(animalPrefab) as GameObject;
                borderAnimals.Add(point);
                playerHelper.LookAt(animal.transform);
                point.transform.position = playerHelper.position + playerHelper.forward * viewRadius * scale;
            }
        }
    }

    private void ClearBorderList()
    {
        foreach (var point in borderAnimals)
        {
            Destroy(point);
        }
        borderAnimals.Clear();
    }
}