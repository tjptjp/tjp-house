using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class equipbaglists
{
	ItemData itemData;
	int index;
	public ItemData Item{get{return itemData;}}
	public int INDEX{get{return index;}}
	public equipbaglists(ItemData dfs,int dfsa)
	{
		itemData=dfs;
		index=dfsa;
	}
}
public class MercenaryEquipController : MonoBehaviour 
{
	vaitorlist Vaitorlist=new vaitorlist();
	List<equipbaglists> listeq=new List<equipbaglists>();
	public GComponent roleequip;
	public TeamManager teamManager;
	public BagManager bagManager;
	GLoader roleimg;
	GTextField name1;
	GTextField shuxin1;
	GTextField shuxin2;
	GTextField shuxin3;
	GTextField shuxin4;
	GComponent annv1;
	GComponent annv2;
	GComponent annv3;
	GTextField annv1text;
	GList euqiplist;
	string danqianid;
	EquipType deq;
	int ListIndex;
	int Index;
	int bagnow;
	public bool shifuzhangbei;
	public Action fsmss;
	public void Init () 
	{
		Vaitorlist.clear();
		roleimg=roleequip.GetChild("n2").asLoader;
		name1=roleequip.GetChild("name").asTextField;
		shuxin1=roleequip.GetChild("n11").asTextField;
		shuxin2=roleequip.GetChild("n12").asTextField;
		shuxin3=roleequip.GetChild("n15").asTextField;
		shuxin4=roleequip.GetChild("n16").asTextField;
		euqiplist=roleequip.GetChild("n0").asList;
		annv1=roleequip.GetChild("n5").asCom;
		annv2=roleequip.GetChild("n4").asCom;
		annv3=roleequip.GetChild("n6").asCom;
		annv1text=annv1.GetChild("n1").asTextField;
		euqiplist.numItems=0;
		euqiplist.itemRenderer=RenderListItem;
		euqiplist.onClickItem.Add(onClickItem);
		annv1.onClick.Add(()=>{annv1onclick();fsmss();});
		annv2.onClick.Add(()=>{annv2onclick();fsmss();});
		annv3.onClick.Add(()=>{fsmss();});
		Vaitorlist.addvlist(()=>
		{
			return shifuzhangbei;
		},()=>
		{
			if (shifuzhangbei)
			{
				annv1text.text="卸下";
			}else
			{
				annv1text.text="装备";
			}
		});
		
	}
	public void qidong (int listindex,int index,EquipType equipType)
	{
		ListIndex=listindex;
		Index=index;
		deq=equipType;
		if (listindex==-1)
		{
			switch (equipType)
			{
				case EquipType.arms:
				if (teamManager.bagren[index].Wuqi!=null)
				{
				roleimg.url="ItemIcon/item/"+teamManager.bagren[index].Wuqi.imgid();
				name1.text=teamManager.bagren[index].Wuqi.name;
				shuxin1.text=teamManager.bagren[index].Wuqi.Powermax.ToString();
				shuxin2.text=teamManager.bagren[index].Wuqi.Spellmax.ToString();
				shuxin3.text=teamManager.bagren[index].Wuqi.agilemax.ToString();
				shuxin4.text=teamManager.bagren[index].Wuqi.luckymax.ToString();
				shifuzhangbei=true;
				annv1text.text="卸下";
				}else
				{
					shifuzhangbei=false;
					annv1text.text="装备";
				}
				break;
				case EquipType.Ornaments:
				if (teamManager.bagren[index].Shiping!=null)
				{
					roleimg.url="ItemIcon/item/"+teamManager.bagren[index].Shiping.imgid();
					name1.text=teamManager.bagren[index].Shiping.name;
					shuxin1.text=teamManager.bagren[index].Shiping.Powermax.ToString();
					shuxin2.text=teamManager.bagren[index].Shiping.Spellmax.ToString();
					shuxin3.text=teamManager.bagren[index].Shiping.agilemax.ToString();
					shuxin4.text=teamManager.bagren[index].Shiping.luckymax.ToString();
					shifuzhangbei=true;
					annv1text.text="卸下";
				}else
				{
					shifuzhangbei=false;
					annv1text.text="装备";
				}
				break;
				case EquipType.equipmentdown:
				if (teamManager.bagren[index].Xianzhuang!=null)
				{
					roleimg.url="ItemIcon/item/"+teamManager.bagren[index].Xianzhuang.imgid();
					name1.text=teamManager.bagren[index].Xianzhuang.name;
					shuxin1.text=teamManager.bagren[index].Xianzhuang.Powermax.ToString();
					shuxin2.text=teamManager.bagren[index].Xianzhuang.Spellmax.ToString();
					shuxin3.text=teamManager.bagren[index].Xianzhuang.agilemax.ToString();
					shuxin4.text=teamManager.bagren[index].Shiping.luckymax.ToString();
					shifuzhangbei=true;
					annv1text.text="卸下";
				}else
				{
					shifuzhangbei=false;
					annv1text.text="装备";
				}
				
				break;
				case EquipType.equipmentup:
				if (teamManager.bagren[index].Shangzhuang!=null)
				{
					roleimg.url="ItemIcon/item/"+teamManager.bagren[index].Shangzhuang.imgid();
					name1.text=teamManager.bagren[index].Shangzhuang.name;
					shuxin1.text=teamManager.bagren[index].Shangzhuang.Powermax.ToString();
					shuxin2.text=teamManager.bagren[index].Shangzhuang.Spellmax.ToString();
					shuxin3.text=teamManager.bagren[index].Shangzhuang.agilemax.ToString();
					shuxin4.text=teamManager.bagren[index].Shangzhuang.luckymax.ToString();
					shifuzhangbei=true;
					annv1text.text="卸下";
				}else
				{
					shifuzhangbei=false;
					annv1text.text="装备";
				}
				
				break;
			}
		}else
		{
			switch (equipType)
			{
				case EquipType.arms:
					if (teamManager.shunchong[listindex].listch[index].Wuqi!=null)
					{
						roleimg.url="ItemIcon/item/"+teamManager.shunchong[listindex].listch[index].Wuqi.imgid();
						name1.text=teamManager.shunchong[listindex].listch[index].Wuqi.name;
						shuxin1.text=teamManager.shunchong[listindex].listch[index].Wuqi.Powermax.ToString();
						shuxin2.text=teamManager.shunchong[listindex].listch[index].Wuqi.Spellmax.ToString();
						shuxin3.text=teamManager.shunchong[listindex].listch[index].Wuqi.agilemax.ToString();
						shuxin4.text=teamManager.shunchong[listindex].listch[index].Wuqi.luckymax.ToString();
						shifuzhangbei=true;
						annv1text.text="卸下";
					}else
					{
						shifuzhangbei=false;
						annv1text.text="装备";
					}
				break;
				case EquipType.Ornaments:
					if (teamManager.shunchong[listindex].listch[index].Shiping!=null)
					{
						roleimg.url="ItemIcon/item/"+teamManager.shunchong[listindex].listch[index].Shiping.imgid();
						name1.text=teamManager.shunchong[listindex].listch[index].Shiping.name;
						shuxin1.text=teamManager.shunchong[listindex].listch[index].Shiping.Powermax.ToString();
						shuxin2.text=teamManager.shunchong[listindex].listch[index].Shiping.Spellmax.ToString();
						shuxin3.text=teamManager.shunchong[listindex].listch[index].Shiping.agilemax.ToString();
						shuxin4.text=teamManager.shunchong[listindex].listch[index].Shiping.luckymax.ToString();
						shifuzhangbei=true;
						annv1text.text="卸下";
					}else
					{
						shifuzhangbei=false;
						annv1text.text="装备";
					}
				break;
				case EquipType.equipmentdown:
					if (teamManager.shunchong[listindex].listch[index].Xianzhuang!=null)
					{
						roleimg.url="ItemIcon/item/"+teamManager.shunchong[listindex].listch[index].Xianzhuang.imgid();
						name1.text=teamManager.shunchong[listindex].listch[index].Xianzhuang.name;
						shuxin1.text=teamManager.shunchong[listindex].listch[index].Xianzhuang.Powermax.ToString();
						shuxin2.text=teamManager.shunchong[listindex].listch[index].Xianzhuang.Spellmax.ToString();
						shuxin3.text=teamManager.shunchong[listindex].listch[index].Xianzhuang.agilemax.ToString();
						shuxin4.text=teamManager.shunchong[listindex].listch[index].Xianzhuang.luckymax.ToString();
						shifuzhangbei=true;
						annv1text.text="卸下";
					}else
					{
						shifuzhangbei=false;
						annv1text.text="装备";
					}
				break;
				case EquipType.equipmentup:
					if (teamManager.shunchong[listindex].listch[index].Shangzhuang!=null)
					{
						roleimg.url="ItemIcon/item/"+teamManager.shunchong[listindex].listch[index].Shangzhuang.imgid();
						name1.text=teamManager.shunchong[listindex].listch[index].Shangzhuang.name;
						shuxin1.text=teamManager.shunchong[listindex].listch[index].Shangzhuang.Powermax.ToString();
						shuxin2.text=teamManager.shunchong[listindex].listch[index].Shangzhuang.Spellmax.ToString();
						shuxin3.text=teamManager.shunchong[listindex].listch[index].Shangzhuang.agilemax.ToString();
						shuxin4.text=teamManager.shunchong[listindex].listch[index].Shangzhuang.luckymax.ToString();
						shifuzhangbei=true;
						annv1text.text="卸下";
					}else
					{
						shifuzhangbei=false;
						annv1text.text="装备";
					}
				break;
			}
		}
	}
	public void fsmopen()
	{
		int Qate=0;
		foreach (var item in bagManager.baglist)
		{
			if (item.equiptype==deq)
			{
				listeq.Add(new equipbaglists(item,bagManager.baglist.IndexOf(item)));
			}
			Qate++;
		}
		euqiplist.numItems=listeq.Count;
		euqiplist.EnsureBoundsCorrect();
	}
	public void fsmclose()
	{
		listeq.Clear();
		zhanshi1("","","","","","");
	}
	void zhanshi1(string id,string name,string xhuxin1,string xhuxin2,string xhuxin3,string xhuxin4)
	{
		roleimg.url="ItemIcon/item/"+id;
		name1.text=name;
		shuxin1.text=xhuxin1;
		shuxin2.text=xhuxin2;
		shuxin3.text=xhuxin3;
		shuxin4.text=xhuxin4;
	}
	void RenderListItem(int index, GObject obj)
	{
		GButton button = obj.asButton;
		GLoader img=button.GetChild("n0").asLoader;
		img.url="ItemIcon/item/"+listeq[index].Item.imgid();
	}
	void onClickItem(EventContext etext)
	{
		GObject sdfsad=(GObject)etext.data;
		zhanshi1(listeq[euqiplist.GetChildIndex(sdfsad)].Item.imgid(),listeq[euqiplist.GetChildIndex(sdfsad)].Item.name,listeq[euqiplist.GetChildIndex(sdfsad)].Item.Powermax.ToString(),listeq[euqiplist.GetChildIndex(sdfsad)].Item.Spellmax.ToString(),listeq[euqiplist.GetChildIndex(sdfsad)].Item.agilemax.ToString(),listeq[euqiplist.GetChildIndex(sdfsad)].Item.luckymax.ToString());
		bagnow=euqiplist.GetChildIndex(sdfsad);
	}
	void annv1onclick()
	{
		if (ListIndex==-1)
		{
			if (shifuzhangbei)
			{
				teamManager.equiptuoxia(Index,deq);
			}else
			{
				teamManager.equipcangku(bagManager.daochu(listeq[bagnow].INDEX),Index);
				if (bagManager.daochu(listeq[bagnow].INDEX).Grade<=teamManager.bagren[Index].dengji)
				{
					bagManager.RemoveAtlist(listeq[bagnow].INDEX);
					Debug.Log("装备成功");
				}
			}
		}
		else
		{
			if (teamManager.shunchong[ListIndex].paiqian)
			{
				if (shifuzhangbei)
				{
					teamManager.equipcangtuoxia(ListIndex,Index,deq);
				}else
				{
					teamManager.equipchange(bagManager.daochu(listeq[bagnow].INDEX),ListIndex,Index);
					if (bagManager.daochu(listeq[bagnow].INDEX).Grade<=teamManager.shunchong[ListIndex].listch[Index].dengji)
					{
						bagManager.RemoveAtlist(listeq[bagnow].INDEX);
						Debug.Log("装备成功");
					}
				}
			}else
			{
				Debug.Log("小队任务进行中");
			}
		}
		
	}
	void annv2onclick()
	{
		if (ListIndex==-1)
		{
			teamManager.equipcangku(bagManager.daochu(listeq[bagnow].INDEX),Index);
			if (bagManager.daochu(listeq[bagnow].INDEX).Grade<=teamManager.bagren[Index].dengji)
			{
				bagManager.RemoveAtlist(listeq[bagnow].INDEX);
				Debug.Log("装备成功");
			}
		}else
		{
			if (teamManager.shunchong[ListIndex].paiqian)
			{
				teamManager.equipchange(bagManager.daochu(listeq[bagnow].INDEX),ListIndex,Index);
				if (bagManager.daochu(listeq[bagnow].INDEX).Grade<=teamManager.shunchong[ListIndex].listch[Index].dengji)
				{
					bagManager.RemoveAtlist(listeq[bagnow].INDEX);
					Debug.Log("装备成功");
				}
			}else
			{
				Debug.Log("小队任务进行中");
			}
		}
	}
	void Update ()
	{
		Vaitorlist.Update();
	}
}
