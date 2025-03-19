using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text text;
    float t;
    private void Update()
    {
        t += Time.deltaTime;
        text.text = t.ToString();
    }
}
