using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class MercenaryRoleImgController : MonoBehaviour {
	vaitorlist vaitorlist=new vaitorlist();
	public TeamManager teamManager;
	public GComponent roleimg;
	GComponent rolexinxi;
	GComponent zhuang1;
	GComponent zhuang2;
	GComponent zhuang3;
	GComponent zhuang4;
	GLoader zhuang1img;
	GLoader zhuang2img;
	GLoader zhuang3img;
	GLoader zhuang4img;

	GTextField namead;
	GTextField lv;
	GTextField hp;
	GTextField atk;
	GTextField power;
	GTextField fast;
	GTextField fashu;
	GTextField lucky;
	GLoader jueseimg;
	public Action<string> onimg;
	public Action <int,int,EquipType> onclickequip;
	int ListIndex;
	int Index;
	public void Init () 
	{
		vaitorlist.clear();
		rolexinxi=roleimg.GetChild("n7").asCom;

		jueseimg=roleimg.GetChild("n1").asLoader;

		zhuang1=roleimg.GetChild("zhuang1").asCom;
		zhuang2=roleimg.GetChild("zhuang2").asCom;
		zhuang3=roleimg.GetChild("zhuang3").asCom;
		zhuang4=roleimg.GetChild("zhuang4").asCom;
		zhuang1img=zhuang1.GetChild("n0").asLoader;
		zhuang2img=zhuang2.GetChild("n0").asLoader;
		zhuang3img=zhuang3.GetChild("n0").asLoader;
		zhuang4img=zhuang4.GetChild("n0").asLoader;

		namead=rolexinxi.GetChild("n0").asTextField;
		lv=rolexinxi.GetChild("lv").asTextField;
		hp=rolexinxi.GetChild("hp").asTextField;
		atk=rolexinxi.GetChild("atk").asTextField;
		power=rolexinxi.GetChild("power").asTextField;
		fast=rolexinxi.GetChild("fast").asTextField;
		fashu=rolexinxi.GetChild("fashu").asTextField;
		lucky=rolexinxi.GetChild("lucky").asTextField;
		jueseimg.onClick.Add(()=>{onimg(roleimgstring());});
		zhuang1.onClick.Add(()=>{zhuangbeipanduan(EquipType.arms);});
		zhuang2.onClick.Add(()=>{zhuangbeipanduan(EquipType.equipmentup);});
		zhuang3.onClick.Add(()=>{zhuangbeipanduan(EquipType.equipmentdown);});
		zhuang4.onClick.Add(()=>{zhuangbeipanduan(EquipType.Ornaments);});
	}
	public string roleimgstring()
	{
		string sdas;
		if (ListIndex==-1)
		{
			sdas=teamManager.bagren[Index].id;
		}else
		{
			sdas=teamManager.shunchong[ListIndex].listch[Index].id;
		}
		return sdas;
	}
	public void fsmopen()
	{
		if (ListIndex==-1)
		{
			jueseimg.url="ItemIcon/role/img/"+teamManager.bagren[Index].id;
			namead.text=teamManager.bagren[Index].name;
			lv.text=teamManager.bagren[Index].dengji.ToString();
			hp.text=teamManager.bagren[Index].hpmax.ToString();
			power.text=teamManager.bagren[Index].Powermax.ToString();
			fast.text=teamManager.bagren[Index].agilemax.ToString();
			fashu.text=teamManager.bagren[Index].Spellmax.ToString();
			lucky.text=teamManager.bagren[Index].luckymax.ToString();
		}
		else
		{
			jueseimg.url="ItemIcon/role/img/"+teamManager.shunchong[ListIndex].listch[Index].id;
			namead.text=teamManager.shunchong[ListIndex].listch[Index].name;
			lv.text=teamManager.shunchong[ListIndex].listch[Index].dengji.ToString();
			hp.text=teamManager.shunchong[ListIndex].listch[Index].hpmax.ToString();
			power.text=teamManager.shunchong[ListIndex].listch[Index].Powermax.ToString();
			fast.text=teamManager.shunchong[ListIndex].listch[Index].agilemax.ToString();
			fashu.text=teamManager.shunchong[ListIndex].listch[Index].Spellmax.ToString();
			lucky.text=teamManager.shunchong[ListIndex].listch[Index].luckymax.ToString();
		}
		
	}
	public void qidong(int listindex,int index)
	{
		ListIndex=listindex;
		Index=index;
		if (listindex==-1)
		{
			jueseimg.url="ItemIcon/role/img/"+teamManager.bagren[Index].id;
			namead.text=teamManager.bagren[index].name;
			lv.text=teamManager.bagren[index].dengji.ToString();
			hp.text=teamManager.bagren[index].hpmax.ToString();
			power.text=teamManager.bagren[index].Powermax.ToString();
			fast.text=teamManager.bagren[index].agilemax.ToString();
			fashu.text=teamManager.bagren[index].Spellmax.ToString();
			lucky.text=teamManager.bagren[index].luckymax.ToString();
			vaitorlist.addvlist(()=>
			{
				if (teamManager.bagren[index].Wuqi!=null)
				{
					return teamManager.bagren[index].Wuqi;
				}
				return null;
			},()=>
			{
				if (teamManager.bagren[index].Wuqi!=null)
				{
					zhuang1img.url="ItemIcon/item/"+teamManager.bagren[index].Wuqi.imgid();
				}else
				{
					zhuang1img.url="";
				}
			});
			vaitorlist.addvlist(()=>
			{
				if (teamManager.bagren[index].Shangzhuang!=null)
				{
					return teamManager.bagren[index].Shangzhuang;
				}
				return null;
			},()=>
			{
				if (teamManager.bagren[index].Shangzhuang!=null)
				{
					zhuang2img.url="ItemIcon/item/"+teamManager.bagren[index].Shangzhuang.imgid();
				}else
				{
					zhuang2img.url="";
				}
			});
			vaitorlist.addvlist(()=>
			{
				if (teamManager.bagren[index].Xianzhuang!=null)
				{
					return teamManager.bagren[index].Xianzhuang;
				}
				return null;
			},()=>
			{
				if (teamManager.bagren[index].Xianzhuang!=null)
				{
					zhuang3img.url="ItemIcon/item/"+teamManager.bagren[index].Xianzhuang.imgid();
				}else
				{
					zhuang3img.url="";
				}
			});
			vaitorlist.addvlist(()=>
			{
				return teamManager.bagren[index].Xianzhuang;
			},()=>
			{
				if (teamManager.bagren[index].Shiping!=null)
				{
					zhuang4img.url="ItemIcon/item/"+teamManager.bagren[index].Shiping.imgid();
				}else
				{
					zhuang4img.url="";
				}
			});
		}
		else
		{
			jueseimg.url="ItemIcon/role/img/"+teamManager.shunchong[ListIndex].listch[Index].id;
			namead.text=teamManager.shunchong[listindex].listch[index].name;
			lv.text=teamManager.shunchong[listindex].listch[index].dengji.ToString();
			hp.text=teamManager.shunchong[listindex].listch[index].hpmax.ToString();
			power.text=teamManager.shunchong[listindex].listch[index].Powermax.ToString();
			fast.text=teamManager.shunchong[listindex].listch[index].agilemax.ToString();
			fashu.text=teamManager.shunchong[listindex].listch[index].Spellmax.ToString();
			lucky.text=teamManager.shunchong[listindex].listch[index].luckymax.ToString();

			vaitorlist.addvlist(()=>
			{
				if (teamManager.shunchong[listindex].listch[index]!=null)
				{
					return teamManager.shunchong[listindex].listch[index].Wuqi;
				}
				return null;
			},()=>
			{
				if (teamManager.shunchong[listindex].listch[index].Wuqi!=null)
				{
					zhuang1img.url="ItemIcon/item/"+teamManager.shunchong[listindex].listch[index].Wuqi.imgid();
				}else
				{
					zhuang1img.url="";
				}
			});
			vaitorlist.addvlist(()=>
			{
				if (teamManager.shunchong[listindex].listch[index].Shangzhuang!=null)
				{
					return teamManager.shunchong[listindex].listch[index].Shangzhuang;	
				}
				return null;
			},()=>
			{
				if (teamManager.shunchong[listindex].listch[index].Shangzhuang!=null)
				{
					zhuang2img.url="ItemIcon/item/"+teamManager.shunchong[listindex].listch[index].Shangzhuang.imgid();
				}else
				{
					zhuang2img.url="";
				}
			});
			vaitorlist.addvlist(()=>
			{
				if (teamManager.shunchong[listindex].listch[index].Xianzhuang!=null)
				{
					return teamManager.shunchong[listindex].listch[index].Xianzhuang;
				}
				return null;
			},()=>
			{
				if (teamManager.shunchong[listindex].listch[index].Xianzhuang!=null)
				{
					zhuang3img.url="ItemIcon/item/"+teamManager.shunchong[listindex].listch[index].Xianzhuang.imgid();
				}else
				{
					zhuang3img.url="";
				}
			});
			vaitorlist.addvlist(()=>
			{
				if (teamManager.shunchong[listindex].listch[index].Shiping!=null)
				{
					return teamManager.shunchong[listindex].listch[index].Shiping;	
				}
				return null;
			},()=>
			{
				if (teamManager.shunchong[listindex].listch[index].Shiping!=null)
				{
					zhuang4img.url="ItemIcon/item/"+teamManager.shunchong[listindex].listch[index].Shiping.imgid();
				}else
				{
					zhuang4img.url="";
				}
			});
		}
		

	}
	void zhuangbeipanduan(EquipType equipType)
	{
		if(ListIndex!=-1)
		{
			if (teamManager.shunchong[ListIndex].paiqian)
			{
				switch (equipType)
				{
					case EquipType.arms:
					onclickequip(ListIndex,Index,EquipType.arms);
					break;
					case EquipType.Ornaments:
					onclickequip(ListIndex,Index,EquipType.Ornaments);
					break;
					case EquipType.equipmentdown:
					onclickequip(ListIndex,Index,EquipType.equipmentdown);
					break;
					case EquipType.equipmentup:
					onclickequip(ListIndex,Index,EquipType.equipmentup);
					break;
				}
			}
		}else
		{
			switch (equipType)
			{
				case EquipType.arms:
				onclickequip(ListIndex,Index,EquipType.arms);
				break;
				case EquipType.Ornaments:
				onclickequip(ListIndex,Index,EquipType.Ornaments);
				break;
				case EquipType.equipmentdown:
				onclickequip(ListIndex,Index,EquipType.equipmentdown);
				break;
				case EquipType.equipmentup:
				onclickequip(ListIndex,Index,EquipType.equipmentup);
				break;
			}
		}
		
	}
	void Update () 
	{
		vaitorlist.Update();
	}
}
