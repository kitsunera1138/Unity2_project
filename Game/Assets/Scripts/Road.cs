using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    RoadManager roadManager;
    // Start is called before the first frame update
    void Start()
    {
        roadManager = GetComponentInParent<RoadManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obj"))
        {

            roadManager.count = (roadManager.count % 4) +1;
            Vector3 vec = new Vector3(0, 0, roadManager.lastPos.position.z + 40f * roadManager.count);
            transform.position = vec;
        }
    }
}
