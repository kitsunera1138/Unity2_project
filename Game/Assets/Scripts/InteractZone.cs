using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractZone : MonoBehaviour
{
    //°³¹æ Æó¼â ¿øÄ¢ - SOLID ¿øÄ¢
    private void OnTriggerEnter(Collider other)
    {
        IHitable hitable = other.GetComponent<IHitable>();

        if (hitable != null) hitable.Activate();
    }
}
