using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SpeedManager : Singleton<SpeedManager>
{
    [SerializeField] private float speed = 30f;
    [SerializeField] float initializeSpeed = 30f;
    private float limitSpeed = 60.0f;

    public float Speed { get { return speed; } }
    public float InitializeSpeed { get { return initializeSpeed; } }

    [SerializeField] Runner runner;

    //CoroutineCache 방법으로 변경
    //[SerializeField] WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);

    //public UnityEvent callBack;


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
        initializeSpeed = 30f;
        if (scene.buildIndex == 1)
        {
            StartCoroutine(Increase());

            //runner = GameObject.FindAnyObjectByType<Runner>();
            runner = GameObject.Find("Runner").GetComponent<Runner>();
            

        }
    }

    //SpeedManager가 게임 씬에서만 증가 하도록 해야함
    IEnumerator Increase()
    {
        while (GameManager.Instance.State && speed < limitSpeed)
        {
            yield return CoroutineCache.WaitforSecond(5.0f);
            speed += 2.5f;

            if (runner != null) runner.Synchronize();
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
