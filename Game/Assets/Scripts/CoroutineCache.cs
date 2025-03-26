
using System.Collections.Generic;
using UnityEngine;

public static class CoroutineCache
{
    //참조 타입 // 직접 인스턴스 해줘야함 //= new Dictionary<float, WaitForSeconds>()
    private static Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds WaitforSecond(float time)
    {
        WaitForSeconds waitForSeconds;

        //dictionary.ContainsKey(time) vs TryGetValue //bool 반환
        //TryGetValue 가 더 빠르거나 같음 
        if (dictionary.TryGetValue(time, out waitForSeconds)==false)
        {
            dictionary.Add(time, new WaitForSeconds(time));
            waitForSeconds = dictionary[time];
        }

        //if문 안에서 TryGetValue에서 waitForSeconds 값 참조를 알아서 해줌
        return waitForSeconds;
    }

    //ㅁㅁ
    //public static WaitForSeconds WaitforSecond2(float time)
    //{
    //    //dictionary.ContainsKey(time) vs TryGetValue //bool 반환
    //    //TryGetValue 가 더 빠르거나 같음 
    //    if (!dictionary.TryGetValue(time, out WaitForSeconds value))
    //    {
    //        dictionary.Add(time, new WaitForSeconds(time));
    //    }

    //    return dictionary[time];
    //}
}
