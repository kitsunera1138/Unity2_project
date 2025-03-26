using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractZone : MonoBehaviour
{
    //���� ��� ��Ģ - SOLID ��Ģ
    private void OnTriggerEnter(Collider other)
    {
        IHitable hitable = other.GetComponent<IHitable>();

        if (hitable != null) hitable.Activate();
    }
}
