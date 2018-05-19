using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BagManager : MonoBehaviour
{
    public List<ItemData> baglist= new List<ItemData>();
    public List<ItemData> publicbag{get{return baglist;}}
    void Start() 
    {
        daoru(tools.ListRare("R","Weapon"));
        Debug.Log(""+baglist[0].imgid());
    }
    //导入装备列表
    public void daoru(List<ItemData> bag = null)
    {
        if(bag!=null)
        {
            baglist.AddList(bag);
        }
    }
    //导入单个装备
    public void daoruitem(ItemData bag=null)
    {
        if (bag!=null)
        {
            baglist.Add(bag);
        }
    }
    //清除单个装备
    public void RemoveAtlist(int index)
    {
        baglist.RemoveAt(index);
        
    }
    //向外部导装备
    public ItemData daochu(int index)
    {
        return baglist[index];
        
    }
    
	// public void Destroylistindex<T>(List<T> list,int index){
	// 	list.RemoveAt(index);
	// }
}
