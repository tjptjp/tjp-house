using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;
using System.IO;

public static class SaveManager
{

    public static void SaveTime(int QuestNum, DateTime d1)//写完才TM发现好像有个东西叫EASYSAVE
    {
        PlayerPrefs.SetInt("Year" + QuestNum, d1.Year);
        PlayerPrefs.SetInt("Month" + QuestNum, d1.Month);
        PlayerPrefs.SetInt("Day" + QuestNum, d1.Day);
        PlayerPrefs.SetInt("Hour" + QuestNum, d1.Hour);
        PlayerPrefs.SetInt("Minute" + QuestNum, d1.Minute);
        PlayerPrefs.SetInt("Second" + QuestNum, d1.Second);
    }
    public static void SaveTeamNum(int QuestNum, int TeamNum)//写完才TM发现好像有个东西叫EASYSAVE
    {
        PlayerPrefs.SetInt("TeamNum" + QuestNum, TeamNum);
    }
    
    public static DateTime TimeLoader(int QuestNum)//读取第QuestNum个任务的任务时间，直接 smg.TimeLoader(QuestNum);就行
    {
        return new DateTime(PlayerPrefs.GetInt("Year" + QuestNum), PlayerPrefs.GetInt("Month" + QuestNum), PlayerPrefs.GetInt("Day" + QuestNum), PlayerPrefs.GetInt("Hour" + QuestNum), PlayerPrefs.GetInt("Minute" + QuestNum), PlayerPrefs.GetInt("Second" + QuestNum));
    }


}

/*
 * 垃圾玩意儿。。别看了。。心累
    public static string LoadTime(int TeamNum)
    {
        string data = Resources.Load("Character").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        //得到objects节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("SOL").ChildNodes;
        foreach (XmlElement xl1 in xmlNodeList)
        {
            if (xl1.GetAttribute("Time") == TeamNum.ToString())
            {
                return xl1.InnerText;
            }
            else
            {
                break;
            }
        }
        return null;
    }*/
/*    public static void SaveChenggong(int QuestNum,bool Chenggong)//好像这个没啥用
    {
        {
            string path = Application.dataPath + "/Test/QuestAbout.xml";
            if (File.Exists(path))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(path);
                XmlNodeList xmlNodeList = xml.SelectSingleNode("SOL").ChildNodes;
                foreach (XmlElement xl1 in xmlNodeList)
                {
                    if (xl1.GetAttribute("QuestNum") == QuestNum.ToString())
                    {
                        xl1.SetAttribute("bool", Chenggong.ToString());
                    }
                }
                xml.Save(path);
            }
        }
    }

    public static bool LoadChenggong(int QuestNum)
    {
        XmlDocument xml = new XmlDocument();
        XmlReaderSettings set = new XmlReaderSettings();
        set.IgnoreComments = true;//这个设置是忽略xml注释文档的影响。有时候注释会影响到xml的读取
        xml.Load(XmlReader.Create((Application.dataPath + "/Test/QuestAbout.xml"), set));
        //得到SOL节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("SOL").ChildNodes;
        foreach (XmlElement xl1 in xmlNodeList)
        {
            if (xl1.GetAttribute("QuestName") == QuestNum.ToString())
            {
                if (xl1.GetAttribute("bool") == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;//如果没找到返回false
    }//好像这个也没啥用
    
*/
/*    public static void SaveChenggong(int QuestNum,bool Chenggong)//好像这个没啥用
    {
        {
            string path = Application.dataPath + "/Test/QuestAbout.xml";
            if (File.Exists(path))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(path);
                XmlNodeList xmlNodeList = xml.SelectSingleNode("SOL").ChildNodes;
                foreach (XmlElement xl1 in xmlNodeList)
                {
                    if (xl1.GetAttribute("QuestNum") == QuestNum.ToString())
                    {
                        xl1.SetAttribute("bool", Chenggong.ToString());
                    }
                }
                xml.Save(path);
            }
        }
    }

    public static bool LoadChenggong(int QuestNum)
    {
        XmlDocument xml = new XmlDocument();
        XmlReaderSettings set = new XmlReaderSettings();
        set.IgnoreComments = true;//这个设置是忽略xml注释文档的影响。有时候注释会影响到xml的读取
        xml.Load(XmlReader.Create((Application.dataPath + "/Test/QuestAbout.xml"), set));
        //得到SOL节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("SOL").ChildNodes;
        foreach (XmlElement xl1 in xmlNodeList)
        {
            if (xl1.GetAttribute("QuestName") == QuestNum.ToString())
            {
                if (xl1.GetAttribute("bool") == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;//如果没找到返回false
    }//好像这个也没啥用
    
*/
/*public static void SaveAbleUsed(int QuestNum, bool Chenggong)//好像这个没啥用
{
    {
        string path = Application.dataPath + "/Test/QuestAbout.xml";
        if (File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList xmlNodeList = xml.SelectSingleNode("SOL").ChildNodes;
            foreach (XmlElement xl1 in xmlNodeList)
            {
                if (xl1.GetAttribute("QuestNum") == QuestNum.ToString())
                {
                    xl1.SetAttribute("bool", Chenggong.ToString());
                }
            }
            xml.Save(path);
        }
    }
}*/
/*public static bool LoadAbleUsed(int QuestNum)
{
    XmlDocument xml = new XmlDocument();//声明XML文件
    XmlReaderSettings set = new XmlReaderSettings();//声明设置
    set.IgnoreComments = true;//这个设置是忽略xml注释文档的影响。有时候注释会影响到xml的读取
    xml.Load(XmlReader.Create((Application.dataPath + "/Test/QuestAbout.xml"), set));//读取，这种写法是只读，用xml.Load(路径)也行
    XmlNodeList xmlNodeList = xml.SelectSingleNode("SOL").ChildNodes;//得到SOL节点下的所有子节点
    foreach (XmlElement xl1 in xmlNodeList)//遍历所有SOL下的节点
    {
        if (xl1.GetAttribute("QuestName") == QuestNum.ToString())//如果获取的QuestNum和输入的QuestNum相同
        {
            if (xl1.GetAttribute("bool") == "true")//而且获取的bool是true
            {
                return true;//返回true
            }
            else
            {
                return false;
            }
        }
    }
    return false;//如果没找到返回false
}//好像这个也没啥用*/

