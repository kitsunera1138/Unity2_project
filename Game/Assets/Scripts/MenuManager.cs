using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Execute()
    {
        Debug.Log("start");
        SceneManager.LoadScene("Game");
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
