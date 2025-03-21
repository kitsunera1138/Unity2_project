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
        //�ȿ��� �� �˻��ϴµ� �ϳ��� ��Ȱ��ȭ �Ǿ� ������ return
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }
        return true;
    }

    //����
    //IEnumerator ObstacleActive()
    //{
    //    int count = 0;
    //    //�̰� �� ������ ���ͼ� �� Ž���ʿ� X
    //    //��Ȱ��ȭ �� ������Ʈ
    //    int activeCount = 0;

    //    for (int i = 0; i < obstacles.Count; i++)
    //    {
    //        if (obstacles[i].activeSelf == false)
    //        {
    //            activeCount++;
    //        }
    //    }
    //    Debug.Log("��Ȱ��ȭ �� ������Ʈ: " + activeCount);

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
    //                //(count �Ἥ ��� �� Ž�� �ʿ䰡 ����)
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

            //���� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� �ִ� �� Ȯ���մϴ�.
            while (obstacles[random].activeSelf == true)
            {
                //���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                if (ExamineActive())
                {
                    //��� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� �ִٸ� ���� ������Ʈ�� ���� ������ ���� obstacles ����Ʈ�� �־��ݴϴ�.

                    GameObject clone = Instantiate(Resources.Load<GameObject>(obstaclesNames[Random.Range(0, obstaclesNames.Count)]), gameObject.transform);

                    clone.SetActive(false);
                    obstacles.Add(clone);
                }

                //���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� ������ random ������ ���� +1 �ؼ� �ٽ� �˻��մϴ�.
                random = (random + 1) % obstacles.Count;
            }

            obstacles[random].SetActive(true);
        }
    }

    //����
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

    //    // ���ҽ��� �ε��ϰ� �ν��Ͻ�ȭ
    //    obstacle = Instantiate(Resources.Load<GameObject>(obstacleNames2[random]));

    //    obstacle.SetActive(false);
    //    obstacles.Add(obstacle);
    //}
}
