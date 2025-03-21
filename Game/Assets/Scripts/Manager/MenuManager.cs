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

        //1������ �̵� + �񵿱� �̵� �Լ�
        StartCoroutine(SceneryManager.Instance.AsyncLoad(1));
    }

    public void Exit()
    {
        Debug.Log("Quit");

        //����Ƽ �����Ϳ��� ����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif

    }

}
