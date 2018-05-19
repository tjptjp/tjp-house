using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System;

[Serializable]
public class CharacterData
{
	//编号
	public string id;
	//外貌描述
	public string desc;
	//特技描述
	public string tejidesc;
	//血量基础
	public int hp;
	//力量基础
	public int Power;
	//敏捷基础
	public int agile;
	//法术基础
	public int Spell;
	//幸运基础
	public int lucky;
	//等级
	public int dengji;
	int Exp;
	public int exp{
		get{return Exp;}
		set{}
		
	}
	//血量系数
	public float hpxishu;
	//力量系数
	public float Powerxishu;
	//敏捷系数
	public float agilexishu;
	//法术系数
	public float Spellxishu;
	//上装
	equipmentupData shangzhuang=null;
	public equipmentupData Shangzhuang
	{
		get{return shangzhuang;}
		set{
				if (value==null)
				{
					shangzhuang=null;
				}else
				{
					if(value.Grade<=dengji){
						shangzhuang=value;
						// Shangzhuang.character(this);
					}else{Debug.Log("装备失败");}
				}
			}
			
	}
	//下装
	equipmentdownData xianzhuang=null;
	public equipmentdownData Xianzhuang
	{
		get{return xianzhuang;}
		set{
				if (value==null)
				{
					xianzhuang=null;
				}else
				{
					if(value.Grade<=dengji)
					{
						xianzhuang=value;
						// xianzhuang.character(this);
					}else{Debug.Log("装备失败");}
				}
			}
			
	}
	//武器
	armsData wuqi=null;
	public armsData Wuqi
	{
		get{return wuqi;}
		set{
			if (value==null)
			{
				wuqi=null;
			}else
			{
				if(value.Grade<=dengji)
				{
					wuqi=value;
					// wuqi.character(this);
				}
				else{Debug.Log("装备失败");}
				}
			}
			
	}
	//饰品
	OrnamentsData shiping=null;
	public OrnamentsData Shiping
	{
		get{return shiping;}
		set{
				if (value==null)
				{
					shiping=null;
				}else
				{
					if(value.Grade<=dengji){
						shiping=value;
						// shiping.character(this);
					}else{Debug.Log("装备失败");}
				}
			}
			
	}
	//幸运系数
	public float luckyxishu;
	//最终血量
	public int hpmax
	{
		get{return(int)((dengji*hpxishu)+hp)+poolupmax(shangzhuang,"hp")+poolupmax(xianzhuang,"hp")+poolupmax(shiping,"hp");}
	}
	//最终力量
	public int Powermax
	{
		get{return(int)((dengji*Powerxishu)+Power)+poolupmax(shangzhuang,"Power")+poolupmax(xianzhuang,"Power")+poolupmax(wuqi,"Power")+poolupmax(shiping,"Power");}
	}
	//最终敏捷
	public int agilemax
	{
		get{return(int)((dengji*agilexishu)+agile)+poolupmax(shangzhuang,"agile")+poolupmax(xianzhuang,"agile")+poolupmax(wuqi,"agile")+poolupmax(shiping,"agile");}
	}
	//最终法术
	public int Spellmax
	{
		get{return(int)((dengji*Spellxishu)+Spell)+poolupmax(shangzhuang,"Spell")+poolupmax(xianzhuang,"Spell")+poolupmax(wuqi,"Spell")+poolupmax(shiping,"Spell");}
	}
	//最终幸运
	public int luckymax
	{
		get{return(int)((dengji*luckyxishu)+lucky)+poolupmax(shangzhuang,"lucky")+poolupmax(xianzhuang,"lucky")+poolupmax(wuqi,"lucky")+poolupmax(shiping,"lucky");}
	}
	//种族
	public race Race=race.renzu;
	//品级
	public QualityGrade qualityGrade=QualityGrade.O;
	//职业
	public Occupation offer;
	//性别
	Gender mw=Gender.man;
	//名字
	public string name;
	public int poolupmax(ItemData item,string leixing)
	{
		int sadda;
		if(item!=null)
		{
			switch (leixing)
			{
				case "hp":
				sadda=item.hpmax;
				break;
				case "Power":
				sadda= item.Powermax;
				break;
				case "agile":
				sadda= item.agilemax;
				break;
				case "Spell":
				sadda= item.Spellmax;
				break;
				case "lucky":
				sadda= item.luckymax;
				break;
				default:
				sadda= 0;
				break;
			}
			return sadda;
		}
		else
		{
			return 0;
		}
	}
	// public int pooldownmax(int dssad)
	// {
	// 	if(xianzhuang!=null)
	// 	{
	// 		return dssad;
	// 	}
	// 	else
	// 	{
	// 		return 0;
	// 	}
	// }
	// public int shipingmax(int dssad)
	// {
	// 	if(shiping!=null)
	// 	{
	// 		return dssad;
	// 	}
	// 	else
	// 	{
	// 		return 0;
	// 	}
	// }
	// public int wuqimax(int dssad)
	// {
	// 	if(wuqi!=null)
	// 	{
	// 		return dssad;
	// 	}
	// 	else
	// 	{
	// 		return 0;
	// 	}
	// }
	public void shuju(string NAME,string ID,int HP,int POWER,int AGILE,int SPELL,int LUCKY,int DENGJI,float HPXISHU,float POWERXISHU,float AGILEXISHU,float SPELLXISHU,float LUCKYXISHU,string DESC=null,string TEJIDESC=null)
	{
		name=NAME;
		id=ID;
		desc=DESC;
		tejidesc=TEJIDESC;
		hp=HP;
		Power=POWER;
		agile=AGILE;
		Spell=SPELL;
		lucky=LUCKY;
		dengji=DENGJI;
		hpxishu=HPXISHU;
		Powerxishu=POWERXISHU;
		agilexishu=AGILEXISHU;
		Spellxishu=SPELLXISHU;
		luckyxishu=LUCKYXISHU;
	}

}
