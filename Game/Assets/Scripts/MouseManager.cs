using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : Singleton<MouseManager>
{
    [SerializeField] Texture2D texture2D;

    //부모 클래스가 protected로 Awake 잡고 있어서 재정의 시 protected로 세팅해야함
    protected override void Awake()
    {
        base.Awake();
        texture2D = Resources.Load<Texture2D>("Default");
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void State(int state)
    {
        //if (!texture2D)
        //    texture2D = Resources.Load<Texture2D>("Default");

        switch (state)
        {
            case 0:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                break;
            case 1:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                break;
        }

        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }

    //이벤트 함수 등록 - 씬 이동
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        State(scene.buildIndex);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
