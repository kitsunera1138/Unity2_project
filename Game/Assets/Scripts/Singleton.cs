using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//���׸� �̱���
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        //������Ʈ�� ã�Ƽ� instance�� �־���
        if (instance == null)
        {
            //FindAnyObjectByType�� ���ɿ� �� �����ϴ�.
            //instance = FindObjectOfType<T>();
            //instance = FindAnyObjectByType<T>();

            instance = (T)FindAnyObjectByType(typeof(T));

            //ã�� �������� ���� ������Ʈ ����
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
