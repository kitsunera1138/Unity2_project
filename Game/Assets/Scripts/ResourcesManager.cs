using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    //���׸� ���� ���� ����: Object Ÿ��
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    //���� ������Ʈ ��ȯ //�⺻ �Ű� ���� ���
    public GameObject Instantiate(string path, Transform parent = null)
    {
        //���� ���� // ���ҽ� ������ �ִ� ������Ʈ ����
        GameObject prefab = Load<GameObject>(path);

        //���� ���ϴ� ��� null ��ȯ
        if (prefab == null)
        {
            Debug.Log("Failed to Load Prefab : " + prefab);
            return null;
        }

        //�Լ� �̸��� �ߺ��̶� Object.Instantiate�� �����Ѵ�.
        GameObject clone = Object.Instantiate(prefab, parent);

        //������Ʈ �̸� �ڿ� �ٴ� (clone) ����
        //string[] n = clone.name.Split("(Clone)");
        //clone.name = n[0];
        //string n2 = clone.name.Substring(name.Length -7,7);

        clone.name = clone.name.Replace("(Clone)", "");

        return clone;
    }
}
