using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AA : MonoBehaviour
{
    [SerializeField]GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = ResourcesManager.Instance.Instantiate("Bollard");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
