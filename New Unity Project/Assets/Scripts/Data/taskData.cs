using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System;

[Serializable]
public class taskData//任务
{
	public string desc;
	public bool shou;
	List<ItemData> jiangli=new List<ItemData>();
	
}
