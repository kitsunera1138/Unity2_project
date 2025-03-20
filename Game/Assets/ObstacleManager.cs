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


    IEnumerator ObstacleActive()
    {
        int count = 0;
        //이게 더 빠르게 나와서 더 탐색필요 X
        //비활성화 된 오브젝트
        int activeCount = 0;

        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                activeCount++;
            }
        }
        Debug.Log("비활성화 된 오브젝트: " + activeCount);

        while (count < activeCount)
        {
            int random = Random.Range(0, obstacles.Count);

            if (obstacles[random].activeSelf == false)
            {
                obstacles[random].SetActive(true);
                count++;
                yield return new WaitForSeconds(2.5f);

            }
            else
            {
                int over = (random + 1) % obstacles.Count;

                while (true)
                {
                    //(count 써서 사실 다 탐색 필요가 없음)
                    if (over == random) { Debug.Log("over End"); yield break; }

                    if (obstacles[over].activeSelf == false)
                    {
                        obstacles[over].SetActive(true);
                        count++;
                        yield return new WaitForSeconds(2.5f);
                        break;
                    }
                    over = (over + 1) % obstacles.Count;
                }
            }
        }
        Debug.Log("while End");
    }

    [SerializeField] int random;
    IEnumerator ActiveObstacle()
    {
        int count = 0;

        while (true)
        {
            if (count >= obstacles.Count)
            {
                yield break;
            }

            yield return new WaitForSeconds(2.5f);

            random = Random.Range(0, obstacles.Count);


            while (obstacles[random].activeSelf == true)
            {
                random = (random + 1) % obstacles.Count;
            }

            obstacles[random].SetActive(true);

            count++;
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
