using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
public class AdventurousRecordController : MonoBehaviour 
{
	public List<TaskDetailsdata> sda=new List<TaskDetailsdata>();
	public GComponent Maoxianjilu;
	GList list;
	public void Init()
	{
		list=Maoxianjilu.GetChild("n2").asList;
		list.numItems=0;
		list.itemRenderer=RenderListItem;
	}
	public void fsmopen()
	{
		list.numItems=sda.Count;
		list.EnsureBoundsCorrect();
	}
	void RenderListItem(int index,GObject obj)
	{
		GButton button = obj.asButton;
		GTextField NAME1=button.GetChild("n5").asTextField;
		NAME1.text=tools.indexfenbenname(sda[index].fuben);
		GTextField chengong=button.GetChild("n2").asTextField;
		chengong.text=tools.poolchengong(sda[index].chenggong);
	}


	void Update()
	{
		
	}
}
