using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AA : MonoBehaviour
{
    [SerializeField]GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(A());
        //obj = ResourcesManager.Instance.Instantiate("Bollard");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField] int count;
    IEnumerator A()
    {
        count = 0;
        while(count < 10)
        {
            count++;
            yield return CoroutineCache.WaitforSecond(10f);

        }
    }
}
