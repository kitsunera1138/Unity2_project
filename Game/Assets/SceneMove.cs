using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : Singleton<SceneMove>
{
    //�̺�Ʈ ���
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //�̺�Ʈ �Լ� ��� - �� �̵�
    //(���� ���� �� ������Ʈ ���� ���� �ٷ� ȣ��)
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        //���̵� �� ȣ���� �Լ��� �ڷ�ƾ
        SceneCheck(scene);
    }

    //�̺�Ʈ ����
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void SceneCheck(Scene scene)
    {
        Debug.Log("���� ��: " + scene.buildIndex);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            
        }
    }
}
