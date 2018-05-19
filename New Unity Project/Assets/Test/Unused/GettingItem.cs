using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
using System.Xml;
using System.IO;

public class GettingItem 
{
    public List<int> rndLevelList = new List<int>();
    public List<string> rndRareList = new List<string>();
    public List<string> rndLeixingList = new List<string>();
    // Use this for initialization

    int cishu = 0;
    int gailv, dengji = 0;
    string rare, leixing;
    

    void addRList(int gailv, int level, string rare, string leixing)//添加到掉落池
    {

        for (int a = 0; a < gailv; a = a + 1)
        {
            rndLevelList.Add(level);
            rndRareList.Add(rare);
            rndLeixingList.Add(leixing);
        }

    }

    public void UnNameFuckingDude(int QuestNum)//获得道具的随机转盘
    {
        string data = Resources.Load("Dungeon").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        //得到objects节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllDungeon").ChildNodes;
        //遍历所有子节点
        foreach (XmlElement xl1 in xmlNodeList)
        {

            if (int.Parse(xl1.GetAttribute("ItemList")) == QuestNum)//读取任务奖励
            {
                string str = xl1.GetAttribute("ItemList");
                string[] sArray = str.Split(',');
                int a = 0;
                int b = 0;
                
                foreach (string i in sArray)
                {
                    if (a == 0)
                    {
                        cishu = int.Parse(sArray[b]);
                        a = 1;
                    }
                    else if (a == 1)
                    {
                        gailv = int.Parse(sArray[b]);
                        a = 2;
                    }
                    else if (a == 2)
                    {
                        dengji = int.Parse(sArray[b]);
                        a = 3;
                    }
                    else if (a == 3)
                    {
                        rare = sArray[b];
                        a = 4;
                    }
                    else if (a == 4)
                    {
                        if (sArray[b] == "WP")
                        {
                            leixing = "Weapon";
                        }
                        else if (sArray[b] == "SX")
                        {
                            int c = Random.Range(0, 2);
                            if (c == 1)
                            {
                                leixing = "ShangZhuang";
                            }
                            else
                            {
                                leixing = "XiaZhuang";
                            }
                        }
                        else if (sArray[b] == "SP")
                        {
                            leixing = "ShiPin";
                        }
                        else if (sArray[b] == "SC")
                        {
                            leixing = "SuCai";
                        }
                        else if (sArray[b] == "WU")
                        {
                            leixing = "WU";
                        }
                        addRList(gailv, dengji, rare, leixing);
                        a = 1;
                    }
                    b++;
                }
                Getitem();//转完获取
            }
            else
            {
                break;
            }
        }
    }

    public void Getitem()//获得道具
    {
        int KingDice = Random.Range(0, 100);
        int DiceDance = 5;
        string rare = rndRareList[KingDice];
        string leixing = rndLeixingList[KingDice];
        if (leixing == "")
        {
            DiceDance = Random.Range(0, 4);
        }

        if (leixing == "Weapon" || DiceDance == 0)
        {

            List<armsData> dsfas = new List<armsData>();
            // dsfas = tools.ListRare(rare, leixing);
            // List<ItemData> sds =dsfas.AsitemList<armsData,ItemData>();
            int jieguo = Random.Range(0, dsfas.Count);
        }
        if (leixing == "ShangZhuang" || DiceDance == 1)
        {

            List<equipmentdownData> dsfas = new List<equipmentdownData>();
            // dsfas = tools.ListRare(rare, leixing);
        }
        if (leixing == "XiaZhuang" || DiceDance == 2)
        {

            List<equipmentupData> dsfas = new List<equipmentupData>();
            // dsfas = tools.ListRare(rare, leixing);
        }
        if (leixing == "ShiPin" || DiceDance == 3)
        {

            List<OrnamentsData> dsfas = new List<OrnamentsData>();
            // dsfas = tools.ListRare(rare, leixing);
        }
        if (leixing == "SuCai")
        {
            //你看着加吧。。。。好像没有素材。。
        }
        rndRareList.Clear();
        rndLeixingList.Clear();
        rndLevelList.Clear();//清空道具相关列表
    }
}
