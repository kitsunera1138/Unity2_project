using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    //제네릭 형식 제약 조건: Object 타입
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    //게임 오브젝트 반환 //기본 매개 변수 사용
    public GameObject Instantiate(string path, Transform parent = null)
    {
        //참조 변수 // 리소스 폴더에 있는 오브젝트 참조
        GameObject prefab = Load<GameObject>(path);

        //참조 못하는 경우 null 반환
        if (prefab == null)
        {
            Debug.Log("Failed to Load Prefab : " + prefab);
            return null;
        }

        //함수 이름이 중복이라 Object.Instantiate로 생성한다.
        GameObject clone = Object.Instantiate(prefab, parent);

        //오브젝트 이름 뒤에 붙는 (clone) 삭제
        //string[] n = clone.name.Split("(Clone)");
        //clone.name = n[0];
        //string n2 = clone.name.Substring(name.Length -7,7);

        clone.name = clone.name.Replace("(Clone)", "");

        return clone;
    }
}
