using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class listCharacterDispatch
{
	public CharacterListData characterListData;
	public int INDEX;
	public listCharacterDispatch(CharacterListData character,int index)
	{
		characterListData=character;
		INDEX=index;
	}
}
public class DispatchController : MonoBehaviour {
	List<listCharacterDispatch> chlist=new List<listCharacterDispatch>();
	public TeamManager teamManager;
	public QuestManager questManager;
	public GComponent dispatch;
	GComponent xuanzheduiwu;
	GLoader fanhuixian;
	GComboBox xialakuan;
	GComboBox haiwuan;
	GComboBox kelisi;
	GList listxia;
	public Action <int,int> kaishirenwu;
	// Use this for initialization
	public void Init () 
	{
		xialakuan=dispatch.GetChild("n0").asComboBox;
		haiwuan=dispatch.GetChild("n4").asComboBox;
		kelisi=dispatch.GetChild("n5").asComboBox;
		xuanzheduiwu=dispatch.GetChild("n3").asCom;
		listxia=xuanzheduiwu.GetChild("n0").asList;
		fanhuixian=xuanzheduiwu.GetChild("n2").asLoader;
		listxia.numItems=0;
		listxia.itemRenderer=RenderListItem;
		xialakuan.onChanged.Add(onChanged);
		haiwuan.onChanged.Add(onChanged1);
		kelisi.onChanged.Add(onChanged2);
		xuanzheduiwu.visible=false;
		listxia.onClickItem.Add(onClickItem);
		fanhuixian.onClick.Add(()=>{xuanzheduiwu.visible=false;});
	}
	CharacterListData characterListData;
	public void fsmopen()
	{
		if (teamManager.shunchong!=null&&teamManager.shunchong.Count!=0)
		{
			foreach (var item in teamManager.shunchong)
			{
				if (item.paiqian&&item.listch.Count!=0)
				{
					chlist.Add(new listCharacterDispatch(item,teamManager.shunchong.IndexOf(item)));
				}
			}
		}
		listxia.numItems=chlist.Count;
		listxia.EnsureBoundsCorrect();
	}
	public void fsmclose()
	{
		chlist.Clear();
	}
	void RenderListItem(int index, GObject obj)
	{
		GButton button = obj.asButton;
		GList duiwutouxiang=button.GetChild("n6").asList;
		GTextField renshu=button.GetChild("n13").asTextField;
		GTextField denji=button.GetChild("n12").asTextField;
		GTextField bianduibianhao=button.GetChild("n14").asTextField;
		characterListData=chlist[index].characterListData;
		duiwutouxiang.numItems=characterListData.listch.Count;
		renshu.text=characterListData.listch.Count.ToString();
		denji.text=characterListData.lvdengji().ToString();
		bianduibianhao.text=index.ToString();
		duiwutouxiang.itemRenderer = endasd;
		duiwutouxiang.EnsureBoundsCorrect();
	}
	void onClickItem(EventContext etext)
	{
		GObject sdfsad=(GObject)etext.data;
		int listindext=listxia.GetChildIndex(sdfsad);
		int sdsad=chlist[listindext].INDEX;
		kaishirenwu(fubenin,sdsad);
		xuanzheduiwu.visible=false;
	}
	void endasd(int index, GObject obj)
	{
		GButton button = obj.asButton;
		GLoader icon=button.GetChild("icon").asLoader;
		icon.url="ItemIcon/role/hand/"+characterListData.listch[index].id;
		
	}
	int fubenin;
	void onChanged()
	{
		// Debug.Log(""+xialakuan.selectedIndex);
		fubenin=int.Parse(xialakuan.value);
		if (questManager.Fubenkeyong[fubenin])
		{
			xuanzheduiwu.visible=true;
		}else
		{
			Debug.Log("副本有队伍了");
		}
		
	}
	void onChanged1()
	{
		// Debug.Log(""+haiwuan.selectedIndex);
		fubenin=int.Parse(haiwuan.value);
		if (questManager.Fubenkeyong[fubenin])
		{
			xuanzheduiwu.visible=true;
		}else
		{
			Debug.Log("副本有队伍了");
		}
	}
	void onChanged2()
	{
		// Debug.Log(""+kelisi.selectedIndex);
		fubenin=int.Parse(kelisi.value);
		if (questManager.Fubenkeyong[fubenin])
		{
			xuanzheduiwu.visible=true;
		}else
		{
			Debug.Log("副本有队伍了");
		}
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
}
