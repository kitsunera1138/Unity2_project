using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedManager : Singleton<SpeedManager>
{
    [SerializeField] private float speed = 30f;
    public float Speed { get { return speed; } }
    float limitSpeed = 60.0f;

    [SerializeField] WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);

    //이벤트 등록
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        speed = 30f;

        if (scene.buildIndex == 1)
        {
            StartCoroutine(Increase());
        }
    }

    //SpeedManager가 게임 씬에서만 증가 하도록 해야함
    IEnumerator Increase()
    {
        while (GameManager.Instance.State && speed < limitSpeed)
        {
            yield return waitForSeconds;

            speed += 2.5f;
        }
    }

    //이벤트 해제
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    ////씬 이동 시 호출할 함수 //리셋
    //public void Initialization()
    //{
    //    speed = 30f;
    //    limitSpeed = 60f;
    //}
}
