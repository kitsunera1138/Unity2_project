using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool state;
    public bool State { get { return state; } }
    [SerializeField] bool on;
    public void Execute()
    {
        state = true;
    }

    public void Finish()
    {
        state = false;

        //���콺 Ȱ��ȭ
        MouseManager.Instance.State(0);
    }

    private void Update()
    {
        if (on) { state = false; }
        else { state = true; }
    }
}
