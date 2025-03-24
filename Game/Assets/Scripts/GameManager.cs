using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private bool state;
    public bool State { get { return state; } }
    [SerializeField] bool on;

    public void Execute() //게임씬에서는 호출안되어서 Timer 안됨
    {
        state = true;
    }

    public void Finish()
    {
        state = false;

        //마우스 활성화
        MouseManager.Instance.State(0);
    }

    private void Update()
    {
        //if (on) { state = false; }
        //else { state = true; }
    }
}
