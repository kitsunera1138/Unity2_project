using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Vector3[] randomVector3 = new Vector3[3];

    private void Awake()
    {
        randomVector3[0] = new Vector3(-4, 0, 0);
        randomVector3[1] = new Vector3(0, 0, 0);
        randomVector3[2] = new Vector3(4, 0, 0);
    }

    private void OnEnable()
    {
        //랜덤 위치 배열
        transform.position = randomVector3[Random.Range(0, randomVector3.Length)];
    }


    //ㅁㅁ
    //void Position()
    //{
    //    //대충 z 위치
    //    transform.position = new Vector3(0, 0, 20);

    //    int random = Random.Range(0, 3);
    //    Vector3 vec = Vector3.zero;

    //    switch (random)
    //    {
    //        case 0:
    //            vec = new Vector3(4, 0, 0);
    //            break;
    //        case 1:
    //            vec = Vector3.zero;
    //            break;
    //        case 2:
    //            vec = new Vector3(-4, 0, 0);
    //            break;
    //        default: vec = new Vector3(4, 0, 0); break;
    //    }

    //    gameObject.transform.position += vec;
    //}
}
