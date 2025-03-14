using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads = new List<GameObject>();
    [SerializeField] float roadSpeed = 10f;
    [SerializeField] float offSet = 40f;


    //[SerializeField] public Transform lastPos;
    //public int count =0;

    private void Awake()
    {
        //Debug.Log(roads.Capacity);
    }

    private void Update()
    {
        //Vector3 vec = new Vector3(0,0,-1);
        for(int i = 0; i < roads.Count; i++)
        {
            //roads[i].transform.position += vec * Time.deltaTime * roadSpeed;
            roads[i].transform.Translate(Vector3.back* roadSpeed * Time.deltaTime);
        }

        //lastPos = roads[roads.Count - 1].transform;
    }

    //이벤트 등록 public
    public void InitializePosition()
    {
        Debug.Log("Initialize Position");

        //참조 변수 NewRoad는 roads의 첫번째 인덱스를 가리키도록 한다.
        GameObject NewRoad = roads[0];
        //roads[0] 제거 //[1] -> [0] 등 밀려감
        roads.Remove(NewRoad);

        float newZ = roads[roads.Count - 1].transform.position.z + offSet;
        //그냥 transform하면 골때리게 자신 가리킴(RoadManager) 이벤트 사용 오브젝트 참조하려면 함수에서 참조
        NewRoad.transform.position = new Vector3(0, 0, newZ);

        roads.Add(NewRoad);
    }

}
