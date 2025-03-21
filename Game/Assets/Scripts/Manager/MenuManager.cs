using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Execute()
    {
        GameManager.Instance.Execute();
        //SceneManager.LoadScene("Game");

        //1씬으로 이동 + 비동기 이동 함수
        StartCoroutine(SceneryManager.Instance.AsyncLoad(1));
    }

    public void Exit()
    {
        Debug.Log("Quit");

        //유니티 에디터에서 종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif

    }

}
