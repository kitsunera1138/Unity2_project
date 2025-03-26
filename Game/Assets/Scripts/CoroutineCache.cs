
using System.Collections.Generic;
using UnityEngine;

public static class CoroutineCache
{
    //���� Ÿ�� // ���� �ν��Ͻ� ������� //= new Dictionary<float, WaitForSeconds>()
    private static Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds WaitforSecond(float time)
    {
        WaitForSeconds waitForSeconds;

        //dictionary.ContainsKey(time) vs TryGetValue //bool ��ȯ
        //TryGetValue �� �� �����ų� ���� 
        if (dictionary.TryGetValue(time, out waitForSeconds)==false)
        {
            dictionary.Add(time, new WaitForSeconds(time));
            waitForSeconds = dictionary[time];
        }

        //if�� �ȿ��� TryGetValue���� waitForSeconds �� ������ �˾Ƽ� ����
        return waitForSeconds;
    }

    //����
    //public static WaitForSeconds WaitforSecond2(float time)
    //{
    //    //dictionary.ContainsKey(time) vs TryGetValue //bool ��ȯ
    //    //TryGetValue �� �� �����ų� ���� 
    //    if (!dictionary.TryGetValue(time, out WaitForSeconds value))
    //    {
    //        dictionary.Add(time, new WaitForSeconds(time));
    //    }

    //    return dictionary[time];
    //}
}
