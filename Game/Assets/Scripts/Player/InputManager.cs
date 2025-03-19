using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Action action;

    private void Update()
    {
        //키 입력이 들어왔는가
        if(Input.anyKey == false){ return; }
        if(action != null) { action?.Invoke(); }
    }
}
