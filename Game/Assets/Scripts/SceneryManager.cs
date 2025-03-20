using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneryManager : Singleton<SceneryManager>
{
    [SerializeField] Image screenImage;

    //�̺�Ʈ ���
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

    //�񵿱� ���̵�
    public IEnumerator AsyncLoad(int index)
    {
        screenImage.gameObject.SetActive(true);

        //���� �ε����� �� �̵��� ���� ����
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        
        //<asyncOperation.allowSceneActivation>
        //����� �غ�� ��� ����� Ȱ��ȭ �Ǵ� ���� ����ϴ� �����Դϴ�.
        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;
        color.a = 0f;

        //<asyncOperation.isDone>
        //�ش� ������ �Ϸ�Ǿ��� �� ��Ÿ���� �����Դϴ�.
        //�� �޾����� true�� false ��ȯ

        //Scene�� ���� �� �ҷ����� �ʾҴٸ�
        while (asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;
            screenImage.color = color;

            //<asyncOperation.progress>
            //�۾��� ���� ���¸� ��Ÿ���� �����Դϴ�.
            if(asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f,Time.deltaTime);
                screenImage.color = color;

                if(color.a >= 1.0f)
                {
                    //���̵�ƿ��� �� �Ǿ����� ��� ��ȯ Ȱ��ȭ
                    asyncOperation.allowSceneActivation = true;
                    yield break;
                }
            }
            yield return null;
        }
    }

    //�̺�Ʈ �Լ� ��� - �� �̵�
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(FadeIn());
    }

    //�̺�Ʈ ����
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
