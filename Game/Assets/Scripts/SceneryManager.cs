using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneryManager : Singleton<SceneryManager>
{
    [SerializeField] Image screenImage;

    //이벤트 등록
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public IEnumerator FadeIn()
    {
        screenImage.gameObject.SetActive(true);
        Debug.Log("FadeIn" + screenImage);
        Color color = screenImage.color;
        color.a = 1f;

        while (color.a >= 0)
        {
            color.a -= Time.deltaTime;
            screenImage.color = color;
            yield return null;
        }

        screenImage.gameObject.SetActive(false);
        Debug.Log("FadeIn" + screenImage);

    }

    //public IEnumerator FadeOut()
    //{
    //    //screenImage.gameObject.SetActive(true);

    //    Color color = screenImage.color;
    //    color.a = 0;

    //    while (color.a < 1)
    //    {
    //        color.a += Time.deltaTime;
    //        screenImage.color = color;
    //        yield return new WaitForSeconds(0.005f);
    //    }

    //    screenImage.gameObject.SetActive(false);
    //}

    //비동기 씬이동
    public IEnumerator AsyncLoad(int index)
    {
        screenImage.gameObject.SetActive(true);

        //빌드 인덱스로 씬 이동등 관련 설정
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        
        //<asyncOperation.allowSceneActivation>
        //장면이 준비된 즉시 장면이 활성화 되는 것을 허용하는 변수입니다.
        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;
        color.a = 0f;

        //<asyncOperation.isDone>
        //해당 동작이 완료되었는 지 나타내는 변수입니다.
        //다 받았으면 true나 false 반환

        //Scene을 아직 다 불러오지 않았다면
        while (asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;
            screenImage.color = color;

            //<asyncOperation.progress>
            //작업의 진행 상태를 나타내는 변수입니다.
            if(asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f,Time.deltaTime);
                screenImage.color = color;

                if(color.a >= 1.0f)
                {
                    //페이드아웃이 다 되었으면 장면 전환 활성화
                    asyncOperation.allowSceneActivation = true;
                    yield break;
                }
            }
            yield return null;
        }
    }

    //이벤트 함수 등록 - 씬 이동
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(FadeIn());
    }

    //이벤트 해제
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
