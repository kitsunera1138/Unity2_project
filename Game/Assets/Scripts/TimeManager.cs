using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] float activeTime = 2.5f;
    [SerializeField] float limitTime = 2.5f;

    [SerializeField] float bestTime;
    public float ActiveTime {  get { return activeTime; } }

    public void SetTime(float time)
    {
        bestTime = PlayerPrefs.GetFloat("Time"); //값 반환

        Debug.Log("Current Time: " + time);
        Debug.Log("Best Time: " + bestTime);

        if (time > bestTime)
        {
            //갱신
            PlayerPrefs.SetFloat("Time", time);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    IEnumerator Decrease()
    {
        while (activeTime > limitTime && GameManager.Instance.State)
        {
            yield return CoroutineCache.WaitforSecond(5f);
            activeTime -= 0.25f;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        //씬이동 시 호출할 함수나 코루틴
        activeTime = 2.5f;
        //게임 씬에서만 호출
        if(scene.buildIndex == 1)
        {
            StartCoroutine(Decrease());
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
