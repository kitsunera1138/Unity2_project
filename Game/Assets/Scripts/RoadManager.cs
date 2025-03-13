using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads = new List<GameObject>();
    [SerializeField] float roadSpeed = 10f;

    [SerializeField] public Transform lastPos;
    public int count =0;

    private void Awake()
    {
        Debug.Log(roads.Capacity);
    }

    private void Update()
    {
        Vector3 vec = new Vector3(0,0,-1);
        for(int i = 0; i < roads.Count; i++)
        {
            //roads[i].transform.position += vec * Time.deltaTime * roadSpeed;
            roads[i].transform.Translate(Vector3.back* roadSpeed * Time.deltaTime);
        }

        lastPos = roads[roads.Count - 1].transform;
    }

}
