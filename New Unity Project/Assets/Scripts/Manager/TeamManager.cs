using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//编队
public class CharacterListData
{
    public List<CharacterData> listch=new List<CharacterData>();//小队里队员列表
    public bool paiqian=true;//小队中的任务状态
    
    public CharacterData Listindex(int index)
    {
        if(index<=listch.Count)
        {
            return listch[index];
        }else
        {
            return null;
        }
        
    }
    public int lvdengji()
    {
        int sdas=0;
        foreach (var item in listch)
        {
            sdas+=item.dengji;
        }
        return sdas;
    }
    //整个队伍单个属性计算
    public int zhandoulijishuang(string zhiliexing = null)
    {
        int liejia = 0;
        foreach (var item in listch)
        {
          switch (zhiliexing)
                {
                    case "Hp":
                        liejia += item.hpmax;
                        break;
                    case "Str":
                        liejia += item.Powermax;
                        break;
                    case "Spd":
                        liejia += item.agilemax;
                        break;
                    case "Int":
                        liejia += item.Spellmax;
                        break;
                    case "Luc":
                        liejia += item.luckymax;
                        break;
                }
        }
        return liejia;
    }
}
//小队系统
public class TeamManager : MonoBehaviour
{
    public Action<ItemData> bag;
    public List<CharacterListData> shunchong = new List<CharacterListData>();//CharacterListData队伍数据结构 这是小队的列表
     
    public List<CharacterData> bagren = new List<CharacterData>();
    
    // public List<MapData> fubeng = new List<MapData>();
    // public List<ItemData> ItemDatalist = new List<ItemData>();
    public void clear()
    {
        
    }
    private void Start() {
        bagren.Add(tools.xmlcharacterData("#RW0009"));
       
       
        
        // Debug.Log(""+bagren[0].Race.ToString());
    }
    //替换在编队中人物的装备
    public void equipchange(ItemData zhuangbei/*装备*/,int listindex/*编队编号*/,int index/*编队中人物编号*/)
    {
        if(zhuangbei is armsData)
        {
            if(bagren[listindex].Wuqi==null)
            {
                shunchong[listindex].listch[index].Wuqi=zhuangbei as armsData;
            }else
            {
                bag(shunchong[listindex].listch[index].Wuqi);
                shunchong[listindex].listch[index].Wuqi=zhuangbei as armsData;
            }
            //armsData bata=zhuangbei as armsData;
            
        }
        else if(zhuangbei is equipmentdownData)
        {
            if(bagren[listindex].Xianzhuang==null)
            {
                shunchong[listindex].listch[index].Xianzhuang=zhuangbei as equipmentdownData;
            }
            else
            {
                bag(shunchong[listindex].listch[index].Xianzhuang);
                shunchong[listindex].listch[index].Xianzhuang=zhuangbei as equipmentdownData;
            }
            // equipmentdownData bata=zhuangbei as equipmentdownData;
            
        }
        else if(zhuangbei is equipmentupData)
        {
            if(bagren[listindex].Shangzhuang==null)
            {
                shunchong[listindex].listch[index].Shangzhuang=zhuangbei as equipmentupData;
            }
            else
            {
                bag(shunchong[listindex].listch[index].Shangzhuang);
                shunchong[listindex].listch[index].Shangzhuang=zhuangbei as equipmentupData;
            }
            
        }
        else if(zhuangbei is OrnamentsData)
        {
            if(bagren[listindex].Shiping==null)
            {
                shunchong[listindex].listch[index].Shiping=zhuangbei as OrnamentsData;
            }
            else
            {
                bag(shunchong[listindex].listch[index].Shiping);
                shunchong[listindex].listch[index].Shiping=zhuangbei as OrnamentsData;
            }
            
        }
        else{
            
        }
    }
    //卸下在仓库中人物的装备
    public void equiptuoxia(int index,EquipType leixin)
    {
        switch(leixin)
        {
            case EquipType.arms:
                bag(bagren[index].Wuqi);
                bagren[index].Wuqi=null;
            break;
            case EquipType.equipmentdown:
                bag(bagren[index].Xianzhuang);
                bagren[index].Xianzhuang=null;
            break;
            case EquipType.equipmentup:
                bag(bagren[index].Shangzhuang);
                bagren[index].Shangzhuang=null;
            break;
            case EquipType.Ornaments:
                bag(bagren[index].Shiping);
                bagren[index].Shiping=null;
            break;
        }
    }
    //卸下在编队中人物的装备
    public void equipcangtuoxia(int listindex,int index,EquipType leixin)
    {
        switch(leixin)
        {
            case EquipType.arms:
                bag(shunchong[listindex].listch[index].Wuqi);
                shunchong[listindex].listch[index].Wuqi=null;
            break;
            case EquipType.equipmentdown:
                bag(shunchong[listindex].listch[index].Xianzhuang);
                shunchong[listindex].listch[index].Xianzhuang=null;
            break;
            case EquipType.equipmentup:
                bag(shunchong[listindex].listch[index].Shangzhuang);
                shunchong[listindex].listch[index].Shangzhuang=null;
            break;
            case EquipType.Ornaments:
                bag(shunchong[listindex].listch[index].Shiping);
                shunchong[listindex].listch[index].Shiping=null;
            break;
        }
    }
    //替换在仓库中人物的装备
    public void equipcangku(ItemData zhuangbei/*装备*/,int listindex/*仓库编号*/)
    {
        if(zhuangbei is armsData)
        {
            if(bagren[listindex].Wuqi==null)
            {
                armsData sda=zhuangbei as armsData;
                bagren[listindex].Wuqi=sda;
                
            }else
            {
                bag(bagren[listindex].Wuqi as ItemData);
                bagren[listindex].Wuqi=zhuangbei as armsData;
            }
        }
        else if(zhuangbei is equipmentdownData)
        {
            if (bagren[listindex].Xianzhuang==null)
            {
                bagren[listindex].Xianzhuang=zhuangbei as equipmentdownData;
            }else
            {
                bag(bagren[listindex].Xianzhuang as ItemData);
                bagren[listindex].Xianzhuang=zhuangbei as equipmentdownData;
            }
            // equipmentdownData bata=zhuangbei as equipmentdownData;
            
        }
        else if(zhuangbei is equipmentupData)
        {
            if (bagren[listindex].Shangzhuang==null)
            {
                bagren[listindex].Shangzhuang=zhuangbei as equipmentupData;
            }else
            {
                bag(bagren[listindex].Shangzhuang as ItemData);
                bagren[listindex].Shangzhuang=zhuangbei as equipmentupData;
            }
            // equipmentupData bata=zhuangbei as equipmentupData;
            
        }
        else if(zhuangbei is OrnamentsData)
        {
            if (bagren[listindex].Shiping==null)
            {
                bagren[listindex].Shiping=zhuangbei as OrnamentsData;
            }else
            {
                bag(bagren[listindex].Shiping as ItemData);
                bagren[listindex].Shiping=zhuangbei as OrnamentsData;
            }
            // OrnamentsData bata=zhuangbei as OrnamentsData;
            
        }
        else{
            
        }
    }
    //从编队中删除操作
    public void bianduire(int dicindex/*编队编号*/,int diclistindex/*编队中人物编号*/)
    {
        if (shunchong[dicindex]!=null)
        {
            bagren.Add(shunchong[dicindex].Listindex(diclistindex));
            shunchong[dicindex].listch.RemoveAt(diclistindex);
        }
    }
    //从仓库中编入编队中
    public void biandui(int dicindex/*编队编号*/,int listindex/*仓库编号*/)
    {
        if (shunchong[dicindex]==null)
        {
            CharacterListData newch=new CharacterListData();
            newch.listch.Add(bagren[listindex]);
            shunchong.Add(newch);
            bagren.RemoveAt(listindex);
            // if(shunchong[dicindex].Listindex(diclistindex)==null)
            // {
            //     shunchong[dicindex].listch.Add(bagren[listindex]);
            //     bagren.RemoveAt(listindex);
            // }
            // else
            // {
            //     bagren.Add(shunchong[dicindex].Listindex(diclistindex));
            //     shunchong[dicindex].listch[diclistindex]=bagren[listindex];
            //     bagren.RemoveAt(listindex);
            // }
        }
        else
        {
            // CharacterListData newch=new CharacterListData();
            // newch.listch.Add(bagren[listindex]);
            // shunchong.Add(dicindex,newch);
            // bagren.RemoveAt(listindex);
                
                    shunchong[dicindex].listch.Add(bagren[listindex]);
                    bagren.RemoveAt(listindex);
                
                
            
                // bagren.Add(shunchong[dicindex].Listindex(diclistindex));
                // shunchong[dicindex].listch[diclistindex]=bagren[listindex];
                // bagren.RemoveAt(listindex);
            
        }
    }
    //整个队伍单个属性计算
    public int indexlist(int index = -1/*队伍编号*/, string zhiliexing = null/*数值类型*/)
    {
        int liejia = 0;
        liejia=shunchong[index].zhandoulijishuang(zhiliexing);
        return liejia;
    }
    //执行任务队伍状态
    public void teamrenwu(int index,bool tf)
    {
        shunchong[index].paiqian=tf;
    }
    //新建小队
    public void xinjianxiao()
    {
        shunchong.Add(new CharacterListData());
        Debug.Log("okxinjianxiao"+shunchong.Count);
    }
}
