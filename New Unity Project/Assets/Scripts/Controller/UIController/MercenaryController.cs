using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class MercenaryData
{
	int listindex;
	int index;
	CharacterData asad;
	public CharacterData character{get{return asad;}}
	public int ListIndex{get{return listindex;}}
	public int Index{get{return index;}}
	public MercenaryData(int adas,int asdas,CharacterData sdfa)
	{
		listindex=adas;
		index=asdas;
		asad=sdfa;
	}
}
public class MercenaryController : closeopen 
{
	MercenaryWarehouseController mercenaryWarehouseController;
	MercenaryRoleImgController mercenaryRoleImgController;
	MercenaryEquipController mercenaryEquipController;
	MercenaryformationController mercenaryformationController;
	vaitorlist vaitorlist=new vaitorlist();
	Fsm fsmtran=new Fsm();
	GComponent mercenary;
	GComponent formation;
	GComponent warehouse;
	GComponent mercenaryrole;
	GComponent bianannv;
	GComponent duiyuanannv;
	GComponent roleimg;
	GComponent roleequip;
	GComponent zhuzai;
	GComponent formationqudin;
	GComponent mercenaryrolefanhui;
	GList biandui;
	GLoader roleimgimg;
	public Action zhuzzai;
	public Action ringclose;
	public Action ringopen;
	public TeamManager teamManager;
	int listindext=0;
	void Start()
	{
		mercenaryWarehouseController=GetComponent<MercenaryWarehouseController>();
		mercenaryRoleImgController=GetComponent<MercenaryRoleImgController>();
		mercenaryEquipController=GetComponent<MercenaryEquipController>();
		mercenaryformationController=GetComponent<MercenaryformationController>();
		vaitorlist.clear();
		var ui=GetComponent<UIPanel>().ui;
		mercenary=ui.GetChild("n3").asCom;
		formation=ui.GetChild("n1").asCom;
		warehouse=ui.GetChild("n2").asCom;
		mercenaryrole=ui.GetChild("n4").asCom;
		roleimg=ui.GetChild("n5").asCom;
		roleimgimg=roleimg.GetChild("n1").asLoader;
		GComponent sdas=roleimg.GetChild("n0").asCom;
		roleequip=ui.GetChild("n6").asCom;
		zhuzai=mercenary.GetChild("n4").asCom;
		bianannv=mercenary.GetChild("n2").asCom;
		biandui=mercenary.GetChild("n1").asList;
		duiyuanannv=mercenary.GetChild("n3").asCom;
		formationqudin=formation.GetChild("n5").asCom;
		mercenaryrolefanhui=mercenaryrole.GetChild("n6").asCom;
		GComponent eqfanhui=roleequip.GetChild("n6").asCom;
		GComponent merfanhui=warehouse.GetChild("n1").asCom;
		
		zhuzai.onClick.Add(()=>{zhuzzai();});
		merfanhui.onClick.Add(()=>{fsmtran.SetsendEventName("AllToMercenary");});
		vis();
		InitFsm();
		fsmtran.SetsendEventName("AllToMercenary");
		
		Initvaitorlist();
		glistinit();
		formationqudin.onClick.Add(()=>{fsmtran.SetsendEventName("AllToMercenary");});
		duiyuanannv.onClick.Add(()=>{fsmtran.SetsendEventName("AllToWarehouse");});
		eqfanhui.onClick.Add(()=>{fsmtran.SetsendEventName("AllToMercenaryRole");});
		mercenaryrolefanhui.onClick.Add(()=>{Debug.Log("mercenaryrolefanhui");fsmtran.SetsendEventName("AllToWarehouse");});
		sdas.onClick.Add(()=>{fsmtran.SetsendEventName("AllToMercenaryRole");});
		bianannv.onClick.Add(()=>{Debug.Log("ok");
		if (teamManager.shunchong.Count<5)
		{
			teamManager.xinjianxiao();
		};});
		mercenaryWarehouseController.Warehouse=warehouse;
		mercenaryRoleImgController.roleimg=mercenaryrole;
		mercenaryEquipController.roleequip=roleequip;
		mercenaryformationController.formation=formation;
		mercenaryWarehouseController.Init();
		mercenaryRoleImgController.Init();
		mercenaryEquipController.Init();
		mercenaryformationController.Init();
		mercenaryWarehouseController.omclick=(int listisa,int dsasdas)=>
		{
		mercenaryRoleImgController.qidong(listisa,dsasdas);
		fsmtran.SetsendEventName("AllToMercenaryRole");
		};
		mercenaryRoleImgController.onimg=(string sdasdad)=>{roleimgimg.url="ItemIcon/role/img/"+sdasdad;fsmtran.SetsendEventName("AllToRoleImg");};
		mercenaryRoleImgController.onclickequip=(int lisindex,int Index,EquipType equipType)=>
		{
			mercenaryEquipController.qidong(lisindex,Index,equipType);
			fsmtran.SetsendEventName("AllToRoleEquip");};
		mercenaryEquipController.fsmss=()=>{
			fsmtran.SetsendEventName("AllToMercenaryRole");
			};
		}
	void glistinit()
	{
		biandui.numItems=shunchongco();
		biandui.itemRenderer=RenderListItem;
		biandui.onClickItem.Add(onClickItem);
	}
	int shunchongco()
	{
		if(teamManager!=null)
		{
			if (teamManager.shunchong==null)
			{
				return 0;
			}else
			{
				return teamManager.shunchong.Count;
			}
			
		}else
		{
			return 0;
		}
	}

	void Initvaitorlist()
	{
		vaitorlist.addvlist(()=>
		{
			if (teamManager!=null)
			{
				return teamManager.shunchong.Count;
			}
			return 0;
		},()=>
		{
			if (teamManager!=null)
			{
				if (teamManager.shunchong!=null)
				{
					biandui.numItems=teamManager.shunchong.Count;
				}
			}
			biandui.EnsureBoundsCorrect();
		});
	}
	void InitFsm()
	{
		fsmtran.AddState("tran");
		fsmtran.SetCurrStateName("tran");
		fsmtran.AddState("Mercenary",
		()=>
		{
			ringopen();
			biandui.EnsureBoundsCorrect();
			mercenary.visible=true;
		},()=>
		{

		},()=>
		{
			mercenary.visible=false;
		});
		fsmtran.AddState("MercenaryFormation",
		()=>
		{
			ringclose();
			formation.visible=true;
			

		},()=>
		{

		},()=>
		{
			biandui.numItems=teamManager.shunchong.Count;
			biandui.EnsureBoundsCorrect();
			formation.visible=false;
		});
		fsmtran.AddState("Warehouse",
		()=>
		{
			ringopen();
			mercenaryWarehouseController.fsmopen();
			warehouse.visible=true;
		},()=>
		{

		},()=>
		{
			warehouse.visible=false;
			mercenaryWarehouseController.fsmclose();
		});
		fsmtran.AddState("MercenaryRole",
		()=>
		{
			ringclose();
			mercenaryRoleImgController.fsmopen();
			mercenaryrole.visible=true;
		},()=>
		{

		},()=>
		{
			mercenaryrole.visible=false;
		});
		fsmtran.AddState("RoleImg",
		()=>
		{
			ringclose();
			roleimg.visible=true;
		},()=>
		{

		},()=>
		{
			roleimg.visible=false;
		});
		fsmtran.AddState("RoleEquip",
		()=>
		{
			ringclose();
			mercenaryEquipController.fsmopen();
			roleequip.visible=true;
		},()=>
		{

		},()=>
		{
			roleequip.visible=false;
			mercenaryEquipController.fsmclose();
		});
	}
	void vis()
	{
		mercenary.visible=false;
		formation.visible=false;
		warehouse.visible=false;
		mercenaryrole.visible=false;
		roleimg.visible=false;
		roleequip.visible=false;
	}
	CharacterListData characterListData;
	void RenderListItem(int index, GObject obj)
	{
    	GButton button = obj.asButton;
    	GList duiwutouxiang=button.GetChild("n6").asList;
		GTextField renshu=button.GetChild("n13").asTextField;
		GTextField denji=button.GetChild("n12").asTextField;
		GTextField bianduibianhao=button.GetChild("n14").asTextField;
		characterListData=teamManager.shunchong[index];
		duiwutouxiang.numItems=characterListData.listch.Count;
		renshu.text=characterListData.listch.Count.ToString();
		denji.text=characterListData.lvdengji().ToString();
		bianduibianhao.text=index.ToString();
		duiwutouxiang.itemRenderer = endasd;
		duiwutouxiang.EnsureBoundsCorrect();
		
	}
	void endasd(int index, GObject obj)
	{
		GButton button = obj.asButton;
		GLoader icon=button.GetChild("icon").asLoader;
		icon.url="ItemIcon/role/hand/"+characterListData.listch[index].id;
	}

	void onClickItem(EventContext etext)
	{
		GObject sdfsad=(GObject)etext.data;
		listindext=biandui.GetChildIndex(sdfsad);
		if (teamManager.shunchong[listindext].paiqian)
		{
			mercenaryformationController.listindext=listindext;
			fsmtran.SetsendEventName("AllToMercenaryFormation");
		}
	}
	public void fsmclose()
	{
		fsmtran.SetsendEventName("AllToMercenary");
	}
	void Update() 
	{
		fsmtran.Update();
		vaitorlist.Update();	
	}
}
