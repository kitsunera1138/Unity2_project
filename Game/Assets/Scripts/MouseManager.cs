using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : Singleton<MouseManager>
{
    [SerializeField] Texture2D texture2D;

    //�θ� Ŭ������ protected�� Awake ��� �־ ������ �� protected�� �����ؾ���
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

    //�̺�Ʈ �Լ� ��� - �� �̵�
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        State(scene.buildIndex);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
