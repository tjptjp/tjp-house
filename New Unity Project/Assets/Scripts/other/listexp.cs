using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class listexp 
{
	public static void AddList<T>(this List<T> target, List<T> list)
        {
            foreach (var item in list)
            {
                target.Add(item);
            }
        }
    public static List<ItemData> AsitemList<T,ItemData>(this List<T> target)where T:ItemData
    {
        List<ItemData> dfsd=new List<ItemData>();
        foreach (var item in target)
        {
            dfsd.Add(item);
        }
        return dfsd;
    }
}
