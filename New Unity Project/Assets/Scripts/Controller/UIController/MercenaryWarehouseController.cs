using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class MercenaryWarehouseController : MonoBehaviour 
{
	vaitorlist vaitorlist=new vaitorlist();
	public TeamManager teamManager;
	List <MercenaryData> Mercenarylist=new List<MercenaryData>();
	// Use this for initialization
	public GComponent Warehouse;
	GList MercenaryWarehouse;
	public Action <int,int> omclick;
	public void Init ()
	{
		vaitorlist.clear();
		MercenaryWarehouse=Warehouse.GetChild("n0").asList;
		MercenaryWarehouse.numItems=0;
		MercenaryWarehouse.itemRenderer=WarehouseRenderList;
		MercenaryWarehouse.onClickItem.Add(WarehouseOnclick);
		Initvaitorlist();
	}
	void Initvaitorlist()
	{
		// vaitorlist.addvlist(()=>
		// {
		// 	if (teamManager!=null)
		// 	{
		// 		return teamManager.shunchong;
		// 	}
		// 	return null;
		// },()=>
		// {
		// 	if (teamManager.shunchong!=null&&teamManager.shunchong.Count!=0)
		// 	{
		// 		int i=0;
		// 		if (teamManager.shunchong[i].listch!=null&&teamManager.shunchong[i].listch.Count!=0)
		// 		{
		// 			foreach (var item in teamManager.shunchong)
		// 			{
		// 				int a=0;
		// 				foreach (var otem in item.listch)
		// 				{
		// 					Mercenarylist.Add(new MercenaryData(i,a,otem));
		// 					a++;
		// 				}
		// 				i++;
		// 			}
		// 		}
		// 	}
		// 	MercenaryWarehouse.numItems=Mercenarylist.Count;
		// 	MercenaryWarehouse.EnsureBoundsCorrect();
		// });
		// vaitorlist.addvlist(()=>
		// {
		// 	if (teamManager!=null)
		// 	{
		// 		return teamManager.bagren.Count;
		// 	}
		// 	return 0;
		// },()=>
		// {
		// 	if (teamManager.bagren!=null&&teamManager.bagren.Count!=0)
		// 	{
		// 		int a=0;
		// 		foreach (var otem in teamManager.bagren)
		// 		{
		// 			Mercenarylist.Add(new MercenaryData(-1,a,otem));
		// 			a++;
		// 		}
		// 	}
		// 	MercenaryWarehouse.numItems=Mercenarylist.Count;
		// });
	}
	public void fsmopen()
	{
		if (teamManager.shunchong!=null&&teamManager.shunchong.Count!=0)
		{
			int i=0;
			if (teamManager.shunchong[i].listch!=null&&teamManager.shunchong[i].listch.Count!=0)
			{
				foreach (var item in teamManager.shunchong)
				{
					int a=0;
					foreach (var otem in item.listch)
					{
						Mercenarylist.Add(new MercenaryData(teamManager.shunchong.IndexOf(item),item.listch.IndexOf(otem),otem));
						a++;
					}
					i++;
				}
			}
		}
		if (teamManager.bagren!=null&&teamManager.bagren.Count!=0)
			{
				int a=0;
				foreach (var otem in teamManager.bagren)
				{
					Mercenarylist.Add(new MercenaryData(-1,teamManager.bagren.IndexOf(otem),otem));
					a++;
				}
			}
		MercenaryWarehouse.numItems=Mercenarylist.Count;
	}
	public void fsmclose()
	{
		Mercenarylist.Clear();
	}
	void WarehouseRenderList(int index, GObject obj)
	{
		GButton button = obj.asButton;
		GLoader sdas=button.GetChild("icon").asLoader;
		sdas.url="ItemIcon/role/hand/"+Mercenarylist[index].character.id;
	}
	void WarehouseOnclick(EventContext etext)
	{
		GObject sdfsad=(GObject)etext.data;
		int ssa=MercenaryWarehouse.GetChildIndex(sdfsad);
		omclick(Mercenarylist[ssa].ListIndex,Mercenarylist[ssa].Index);
	}
	
	// Update is called once per frame
	void Update () 
	{
		vaitorlist.Update();	
	}
}
