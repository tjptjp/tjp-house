using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class vaitorlist
{
	List<Ivaitor> vaitorList;
	public  vaitorlist()
    {
        vaitorList = new List<Ivaitor>();
    }
	public void addvlist<T>(Func<T> func,Action action)
	{
		vaitorList.Add(new vaitor<T>(func,action));
	}
	public void clear()
	{
		vaitorList.Clear();
	}
	public void Update() 
	{
		foreach (var item in vaitorList)
		{
			item.Update();
		}	
	}
}
