using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watch : MonoBehaviour
{
    [SerializeField] Text textTime;
    [SerializeField] float time = 0;

    [SerializeField] int minute; //분
    [SerializeField] int second; //초
    [SerializeField] int milliSeconds; //밀리초

    private void Awake()
    {
        textTime = GetComponent<Text>();
        StartCoroutine(Measure());
    }

    IEnumerator Measure()
    {
        //int h = 0;
        //int c = 0;
        //int m = 0;

        while (GameManager.Instance.State && time < 1000f)
        {
            time += Time.deltaTime;

            //h = Mathf.Clamp((int)time / 60, 0, 60); // Mathf.Clamp( ㅁ , 최솟값, 최댓값 )
            //c = Mathf.Clamp(((int)time % 60), 0, 60);
            //m = (int)((time * 100) % 100);

            minute = (int)time / 60;
            second = (int)time % 60;
            milliSeconds = (int)((time * 100) % 100);

            textTime.text = string.Format("{0:D2}:{1:D2}:{2:D2}", minute, second, milliSeconds);

            yield return null;
        }
    }
}
