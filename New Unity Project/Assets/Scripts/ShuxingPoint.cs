using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;
//using UnityEditor;
using System.IO;

public class ShuxingPoint : MonoBehaviour
{

    int whatEver;
    void Start()
    {
        // tools.ListRare<armsData>();
        string data = Resources.Load("Equip").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        //得到objects节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllEquip").ChildNodes;
        //遍历所有子节点
        foreach (XmlElement xl1 in xmlNodeList)
        {
            //print("0");
            if (xl1.GetAttribute("WK") == "Str")
            {
                //print("1");
                foreach (XmlElement xl2 in xl1.ChildNodes)
                {
                    //print("2");

                    if (xl2.GetAttribute("Rare") == "R")//搜索稀有度为R的装备
                    {
                        print("装备名：" + xl2.GetAttribute("Name") + "，稀有度：" + xl2.GetAttribute("Rare"));
                    }
                }
                foreach (XmlElement xl2 in xl1.ChildNodes)
                {
                    print("2");
                    if (xl2.GetAttribute("ItemNum") == "#01W015")//搜索编号为#01W015的装备
                    {
                        print("装备名：" + xl2.GetAttribute("Name") + "，稀有度：" + xl2.GetAttribute("Rare") + "，编号：" + xl2.GetAttribute("ItemNum"));

                    }
                }
            }
        }
        print(xml.OuterXml);

    }
    // public List<equipmentupData> equipmentuplist(string rare = null, string leixing = null)
    // {
    //     List<equipmentupData> fdg = new List<equipmentupData>();
    //     fdg = ListRare<equipmentupData>(rare, leixing);
    //     //赋值系数
    //     foreach (var item in fdg)
    //     {
    //         switch (rare)
    //         {
    //             case "R":
    //                 item.shuju();
    //             break;
    //         }

    //     }
    //     return fdg;
    // }

    //返回根据稀有度和类型的装备list
    public List<T> ListRare<T>(string rare = null, string leixing = null) where T : ItemData
    {

        List<T> sad = new List<T>();
        List<T> soulDataList = new List<T>();
        string data = Resources.Load("Equip").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllEquip").ChildNodes;
        //遍历所有子节点
        foreach (XmlElement xl1 in xmlNodeList)
        {
            //print("0");
            if (xl1.GetAttribute("WK") == leixing)
            {
                //print("1");
                foreach (XmlElement xl2 in xl1.ChildNodes)
                {
                    //print("2");

                    if (xl2.GetAttribute("Rare") == rare)//搜索稀有度为R的装备
                    {
                        print("装备名：" + xl2.GetAttribute("Name") + "，稀有度：" + xl2.GetAttribute("Rare"));
                        T DSADASA = null;
                        DSADASA.itemshuju(
                            int.Parse(xl2.GetAttribute("Hp")),
                            int.Parse(xl2.GetAttribute("Str")),
                            int.Parse(xl2.GetAttribute("Spd")),
                            int.Parse(xl2.GetAttribute("Int")),
                            int.Parse(xl2.GetAttribute("Luc")),
                            int.Parse(xl2.GetAttribute("UserLevel")),
                            // xl2.GetAttribute("Rare"),
                            xl2.GetAttribute("Name"),
                            xl2.GetAttribute("ItemNum")
                            );
                        sad.Add(DSADASA);

                    }

                }
                break;
            }
        }
        return sad;
    }


}
