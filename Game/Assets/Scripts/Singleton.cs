using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//제네릭 싱글톤
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        //오브젝트를 찾아서 instance에 넣어줌
        if (instance == null)
        {
            //FindAnyObjectByType가 성능에 더 유리하다.
            //instance = FindObjectOfType<T>();
            //instance = FindAnyObjectByType<T>();

            instance = (T)FindAnyObjectByType(typeof(T));

            //찾지 못했으면 게임 오브젝트 생성
            if (instance == null)
            {
                Debug.Log(typeof(T).Name + "Singleton add");
                GameObject obj = new GameObject(typeof(T).Name);
                instance = obj.AddComponent<T>();
            }
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
