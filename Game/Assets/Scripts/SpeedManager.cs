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

    //�̺�Ʈ ���
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

    //SpeedManager�� ���� �������� ���� �ϵ��� �ؾ���
    IEnumerator Increase()
    {
        while (GameManager.Instance.State && speed < limitSpeed)
        {
            yield return waitForSeconds;

            speed += 2.5f;
        }
    }

    //�̺�Ʈ ����
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    ////�� �̵� �� ȣ���� �Լ� //����
    //public void Initialization()
    //{
    //    speed = 30f;
    //    limitSpeed = 60f;
    //}
}
