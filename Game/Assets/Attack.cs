using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject target;
    private void Update()
    {
        transform.position = target.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Obstacle>() != null)
        {
            other.gameObject.SetActive(false);
        }
    }
}
