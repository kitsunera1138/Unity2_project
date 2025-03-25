using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : Singleton<SceneMove>
{
    //이벤트 등록
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //이벤트 함수 등록 - 씬 이동
    //(현재 씬에 이 오브젝트 있을 때도 바로 호출)
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        //씬이동 시 호출할 함수나 코루틴
        SceneCheck(scene);
    }

    //이벤트 해제
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void SceneCheck(Scene scene)
    {
        Debug.Log("현재 씬: " + scene.buildIndex);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            
        }
    }
}
