using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] List<string> obstaclesNames = new List<string> { "Barrier", "Bollard", "Traffic Cone" };

    [SerializeField] int createCount = 5;

    private void Awake()
    {
        obstacles.Capacity = 10;

        Create();
        StartCoroutine(ActiveObstacle());
    }

    void Create()
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject prefab = Instantiate(Resources.Load<GameObject>(obstaclesNames[Random.Range(0, obstaclesNames.Count)]), gameObject.transform);

            prefab.SetActive(false);
            obstacles.Add(prefab);
        }
    }

    bool ExamineActive()
    {
        //안에서 다 검사하는데 하나라도 비활성화 되어 있으면 return
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }
        return true;
    }

    //ㅁㅁ
    //IEnumerator ObstacleActive()
    //{
    //    int count = 0;
    //    //이게 더 빠르게 나와서 더 탐색필요 X
    //    //비활성화 된 오브젝트
    //    int activeCount = 0;

    //    for (int i = 0; i < obstacles.Count; i++)
    //    {
    //        if (obstacles[i].activeSelf == false)
    //        {
    //            activeCount++;
    //        }
    //    }
    //    Debug.Log("비활성화 된 오브젝트: " + activeCount);

    //    while (count < activeCount)
    //    {
    //        int random = Random.Range(0, obstacles.Count);

    //        if (obstacles[random].activeSelf == false)
    //        {
    //            obstacles[random].SetActive(true);
    //            count++;
    //            yield return new WaitForSeconds(2.5f);

    //        }
    //        else
    //        {
    //            int over = (random + 1) % obstacles.Count;

    //            while (true)
    //            {
    //                //(count 써서 사실 다 탐색 필요가 없음)
    //                if (over == random) { Debug.Log("over End"); yield break; }

    //                if (obstacles[over].activeSelf == false)
    //                {
    //                    obstacles[over].SetActive(true);
    //                    count++;
    //                    yield return new WaitForSeconds(2.5f);
    //                    break;
    //                }
    //                over = (over + 1) % obstacles.Count;
    //            }
    //        }
    //    }
    //    Debug.Log("while End");
    //}

    //void CreateObstacle()
    //{
    //    GameObject prefab = Instantiate(Resources.Load<GameObject>(obstaclesNames[Random.Range(0, obstaclesNames.Count)]), gameObject.transform);

    //    prefab.SetActive(false);
    //    obstacles.Add(prefab);
    //}

    [SerializeField] int random;
    IEnumerator ActiveObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);

            //if (!GameManager.Instance.State) { continue; }

            random = Random.Range(0, obstacles.Count);

            //현재 게임 오브젝트가 활성화 되어 있는 지 확인합니다.
            while (obstacles[random].activeSelf == true)
            {
                //현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                if (ExamineActive())
                {
                    //모든 게임 오브젝트가 활성화 되어 있다면 게임 오브젝트를 새로 생성한 다음 obstacles 리스트에 넣어줍니다.

                    GameObject clone = Instantiate(Resources.Load<GameObject>(obstaclesNames[Random.Range(0, obstaclesNames.Count)]), gameObject.transform);

                    clone.SetActive(false);
                    obstacles.Add(clone);
                }

                //현재 인덱스에 있는 게임 오브젝트가 활성화 되어 있으면 random 변수의 값을 +1 해서 다시 검색합니다.
                random = (random + 1) % obstacles.Count;
            }

            obstacles[random].SetActive(true);
        }
    }

    //ㅁㅁ
    //GameObject obstacle;

    //void obstacleAdd()
    //{
    //    int random = Random.Range(0, 3);

    //    switch (random)
    //    {
    //        case 0:
    //            obstacle = Instantiate(Resources.Load<GameObject>("Barrier"));
    //            break;
    //        case 1:
    //            obstacle = Instantiate(Resources.Load<GameObject>("Bollard"));
    //            break;
    //        case 2:
    //            obstacle = Instantiate(Resources.Load<GameObject>("Traffic Cone"));
    //            break;
    //        default: break;
    //    }
    //    obstacle.SetActive(false);
    //    obstacles.Add(obstacle);
    //}

    //string[] obstacleNames2 = { "Barrier", "Bollard", "Traffic Cone" };

    //void obstacleAdd2()
    //{
    //    int random = Random.Range(0, obstacleNames2.Length);

    //    // 리소스를 로드하고 인스턴스화
    //    obstacle = Instantiate(Resources.Load<GameObject>(obstacleNames2[random]));

    //    obstacle.SetActive(false);
    //    obstacles.Add(obstacle);
    //}
}
