using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Road : MonoBehaviour, IHitable
{
    [SerializeField] public UnityEvent callBack;

    public void Activate()
    {
        if (callBack != null) callBack.Invoke();
    }


    //¤±¤±
    //RoadManager roadManager;
    //void Awake()
    //{
    //    roadManager = GetComponentInParent<RoadManager>();
    //}


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("obj"))
    //    {

    //        roadManager.count = (roadManager.count % 4) + 1;
    //        Vector3 vec = new Vector3(0, 0, roadManager.lastPos.position.z + 40f * roadManager.count);
    //        transform.position = vec;
    //    }
    //}
}
