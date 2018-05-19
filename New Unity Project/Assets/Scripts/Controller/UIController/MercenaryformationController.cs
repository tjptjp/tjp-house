using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
public class MercenaryformationController : MonoBehaviour 
{
	vaitorlist vaitorlist=new vaitorlist();
	public GComponent formation;
	public TeamManager teamManager;
	GList formationlist1;
	GList formationlist2;
	public int listindext;
	public void Init () 
	{
		vaitorlist.clear();
		formationlist1=formation.GetChild("n0").asList;
		formationlist2=formation.GetChild("n4").asList;

		formationlist1.numItems=0;
		formationlist1.itemRenderer=formationRenderList1;
		formationlist1.onClickItem.Add(formationList1onClick);
		formationlist2.numItems=0;
		formationlist2.itemRenderer=formationRenderList2;
		formationlist2.onClickItem.Add(formationList2onClick);
		initvaitorlist();
	}
	void initvaitorlist()
	{
		vaitorlist.addvlist(()=>
		{
			// if (teamManager!=null)
			// {
				if (teamManager.shunchong!=null&&teamManager.shunchong.Count!=0)
				{
					if (teamManager.shunchong[listindext]!=null)
					{
						return teamManager.shunchong[listindext].listch.Count;
					}
					
				}
				
			// }		
			return 0;
		},()=>
		{
			if (teamManager!=null)
			{
				if (teamManager.shunchong[listindext]!=null)
				{
					if (teamManager.shunchong[listindext].listch!=null)
					{
						formationlist1.numItems=teamManager.shunchong[listindext].listch.Count;
					}
				}
				
			}
			formationlist1.EnsureBoundsCorrect();
		});
		vaitorlist.addvlist(()=>
		{
			return teamManager.bagren.Count;
		},()=>
		{
			if (teamManager.bagren!=null)
			{
				formationlist2.numItems=teamManager.bagren.Count;
			}
			formationlist2.EnsureBoundsCorrect();
		});
	}
	void formationRenderList1(int index, GObject obj)
	{
		GButton button = obj.asButton;
		GLoader icon=button.GetChild("icon").asLoader;
		icon.url="ItemIcon/role/hand/"+teamManager.shunchong[listindext].listch[index].id;
	}
	void formationList1onClick(EventContext etext)
	{
		GObject sdfsad=(GObject)etext.data;
		int sdfas=formationlist1.GetChildIndex(sdfsad);
		teamManager.bianduire(listindext,sdfas);
	}
	void formationRenderList2(int index, GObject obj)
	{
		GButton button = obj.asButton;
		GLoader icon=button.GetChild("icon").asLoader;
		icon.url="ItemIcon/role/hand/"+teamManager.bagren[index].id;
	}
	void formationList2onClick(EventContext etext)
	{
		GObject sdfsad=(GObject)etext.data;
		int sdfas=formationlist2.GetChildIndex(sdfsad);
		if (teamManager.shunchong[listindext].listch.Count<5)
		{
			teamManager.biandui(listindext,sdfas);
		}
		
		formationlist1.EnsureBoundsCorrect();
		formationlist2.EnsureBoundsCorrect();
	}

	void Update () 
	{
		vaitorlist.Update();
	}
}
