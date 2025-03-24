using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSize : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
    }

    public void OnMouseExitButton()
    {
        text.fontSize = 65;
    }

    public void OnMouseEnterButton()
    {
        text.fontSize = 80;
    }

    public void OnMouseSelectButton()
    {
        text.fontSize = 50;
    }
}
