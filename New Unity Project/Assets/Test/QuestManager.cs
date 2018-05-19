using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;
using System.IO;
public class QuestManager : MonoBehaviour//握草写成TimeManager了妈的
{
    int FYM = 0;//QuestManager
    int cishu = 0;//GettingItems
    int gailv, dengji = 0;//GettingItems
    int Bianshi = 0;//GailvManager
    System.DateTime date1;//QuestManager
    DateTime d1 = DateTime.Now;//QuestManager
    public TeamManager teamManager;//QuestManager
    public List<int> QuestNumUsed = new List<int>();//QuestManager
    public List<int> TimeIsMoney = new List<int>();//QuestManager
    public List<int> rndLevelList = new List<int>();//GettingItems
    public List<int> QuestAtk, QuestHp, QuestBp = new List<int>();//GailvManager
    public List<string> rndRareList, rndLeixingList = new List<string>();//GettingItems
    public List<string> ChenggongL, ShibaiL = new List<string>();//任务描述list
    public List<bool> Fubenkeyong, Renwuwancheng = new List<bool>();//Suorenwu
    public List<ItemData> DiaoluoQian = new List<ItemData>();
    public Action<List<ItemData>, int, bool, string> dsada;//委托
    string rare, leixing;//GettingItems
    
    void Update()
    {
        string FuckPanding1 = date1.ToString();
        string FuckPanding2 = System.DateTime.Now.ToString();
        if (FuckPanding1 != FuckPanding2)
        {
            foreach (int QuestNum in QuestNumUsed)
            {
                if (SaveManager.TimeLoader(QuestNum) <= DateTime.Now)//更新任务完成进度
                {
                    //   teamManager.teamrenwu(i, false);//解锁？
                    Debug.Log("完成第" + QuestNum + "个副本");
                    WanchengRenwu(QuestNum, true);
                    shouhui(QuestNum);
                    Debug.Log(DiaoluoQian.Count);
                    for (int i = 0; i < DiaoluoQian.Count; i++)
                    {
                        Debug.Log("有货");
                    }
                    dsada(DiaoluoQian, QuestNum, Zongjisuan(QuestNum),Reporter(QuestNum,Zongjisuan(QuestNum)));
                    QuestNumUsed.Remove(QuestNum);//移除正在进行的任务
                    SaveManager. SaveTeamNum(QuestNum, 999);
                    break;
                }
            }
        }
        date1 = System.DateTime.Now;
    }
    public void paichu(int TeamNum, int QuestNum)
    {
        teamManager.teamrenwu(TeamNum, false);//锁定队伍状态
        SuoRenWu(QuestNum, false);//锁定任务
        int a = TimeTravelr(QuestNum); //计算完成时间 这里是不是换成静态比较好？
        d1 = DateTime.Now;//计算完成时间
        d1 = d1.AddMinutes(a); //计算完成时间
        QuestNumUsed.Add(QuestNum);//正在进行的任务
        SaveManager.SaveTime(QuestNum, d1);//记录完成时间
        SaveManager.SaveTeamNum(QuestNum, TeamNum);//记录队伍
    }
    public void shouhui(int QuestNum)
    {
        teamManager.teamrenwu(QATeamNum(QuestNum), true);//解锁队伍状态 
        SuoRenWu(QuestNum, true);//解锁任务
        if (Zongjisuan(QuestNum) == true)//成功判定
        {
            Debug.Log("掉落成功");
            UnNameFuckingDude(QuestNum);
            
        }
        else//如果输了
        {
            
        }
        //WanchengRenwu(QuestNum, false);
    }
    void Start()//建立任务时间List
    {
        SearchCount("BattlePointHp", QuestHp);
        SearchCount("BattlePointAtk", QuestAtk);
        SearchCount("BPNeed", QuestBp);
        TimeIsMoney.Clear();
        TimeIsMoney.Add(0);
        Fubenkeyong.Add(false);
        ChenggongL.Add("");
        ShibaiL.Add("");
        Renwuwancheng.Add(false);
        string data = Resources.Load("Dungeon").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        //得到objects节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllDungeon").ChildNodes;
        //遍历所有子节点
        int a=1;
        foreach (XmlElement xl1 in xmlNodeList)
        {
            TimeIsMoney.Add(int.Parse(xl1.GetAttribute("QuestTime")));//获取int格式的QuestTime
            ChenggongL.Add(xl1.GetAttribute("FininshReport"));
            ShibaiL.Add(xl1.GetAttribute("FailReport"));
            Renwuwancheng.Add(false);
            if (PlayerPrefs.GetString("QuestAbleUsed" + a) == "")
            {
                PlayerPrefs.SetString("QuestAbleUsed" + a, true.ToString());
            }
            Fubenkeyong.Add(Convert.ToBoolean(PlayerPrefs.GetString("QuestAbleUsed" + a)));//获取Bool格式的AbleToUsed}
        }
        ChongZhi();
    }
    public int QATeamNum(int QuestNum)
    {
        return PlayerPrefs.GetInt("TeamNum" + QuestNum);
    }
    public int TimeTravelr(int Timmmmmmmm)//读取具体任务时间
    {
        return TimeIsMoney[Timmmmmmmm];
    }
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
            if (xl1.GetAttribute("DungeonNum") == QuestNum.ToString())//读取任务奖励
            {
                string str = xl1.GetAttribute("ItemList");
                Debug.Log(str);
                string[] sArray = str.Split(',');
                int a = 0;
                int b = 0;
                for (int i= 0;i<sArray.Length; i++)
                  {
                    Debug.Log(sArray[i]);
                }
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
                            int c = UnityEngine.Random.Range(0, 2);
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

        
                Getitem(cishu*5);//转完获取
            }
        }
    }
    public void Getitem(int a)//获得道具
    {
        Debug.Log("成功");
        Debug.Log(a);
        for (int b = 0; b < a; b++)
        {
            Debug.Log("成功");
            int KingDice = UnityEngine.Random.Range(0, 100);
            string rare = rndRareList[KingDice];
            string leixing = rndLeixingList[KingDice];
            Debug.Log(rndRareList[KingDice] + rndLeixingList[KingDice]);
            List<ItemData> Linshi = new List<ItemData>();
            Linshi = tools.ListRare(rare, leixing);
            int c = UnityEngine.Random.Range(0, Linshi.Count);
            Debug.Log("C=" + c+"元素数"+Linshi.Count);
            if (leixing != "WU"&& leixing != "SuCai")
            {
                Debug.Log(leixing);
                DiaoluoQian.Add(Linshi[c]);
            }
        }
        rndRareList.Clear();
        rndLeixingList.Clear();
        rndLevelList.Clear();//清空道具相关列表
    }
    public void SearchCount(string SearchCi, List<int> xxx)//读取任务HP ATK BP需求的组件，不要使用
    {
        xxx.Add(0);
        string data = Resources.Load("Dungeon").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllDungeon").ChildNodes;
        foreach (XmlElement xl1 in xmlNodeList)
        {
            if (xl1.GetAttribute(SearchCi) != null)//读取任务时间
            {
                int QUestInt = int.Parse(xl1.GetAttribute(SearchCi));
                xxx.Add(QUestInt);
            }
        }
    }
    public bool Zongjisuan(int QuestNum)//计算第TeamNum队的战斗力是否比第QuestNum任务高
    {
        
        int TeamNum = QATeamNum(QuestNum);
        //如果 任务战斗力需求 < 第TeamNum队Hp*任务Hp系数+第TeamNum队Atk*任务Atk系数（也就是战斗力）
        if (QuestBp[QuestNum] <= teamManager.indexlist(TeamNum, "Hp") * QuestHp[QuestNum] + teamManager.indexlist(TeamNum, "Atk") * QuestAtk[QuestNum])
        {
    
            return true;
        }
        else
        {
            return false;
        }
    }
    public TimeSpan Shengyushijian(int QuestNum)
    {
        if (SaveManager.TimeLoader(QuestNum) > DateTime.Now)
        {
            // return SaveManager.TimeLoader(QuestNum) - DateTime.Now;
            return new TimeSpan((SaveManager.TimeLoader(QuestNum) - DateTime.Now).Hours, (SaveManager.TimeLoader(QuestNum) - DateTime.Now).Minutes, (SaveManager.TimeLoader(QuestNum) - DateTime.Now).Seconds);
        }
        else
        {
            return TimeSpan.Zero;
        }
    }
    public void SuoRenWu(int QuestNum, bool AbleUsed)
    {
        string data = Resources.Load("Dungeon").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllDungeon").ChildNodes;
        string Diqu = "";
        foreach (XmlElement xl1 in xmlNodeList)
        {
            if (xl1.GetAttribute("DungeonNum") == QuestNum.ToString())//读取任务地区
            {
                Diqu = xl1.GetAttribute("Name");
                break;
            }
        }
        int a = 1;
        foreach (XmlElement xl1 in xmlNodeList)
        {
            if (xl1.GetAttribute("Name") == Diqu)//搜索任务地区
            {
                Fubenkeyong[a] = AbleUsed;
                PlayerPrefs.SetString("QuestAbleUsed" + a,AbleUsed.ToString());//获取Bool格式的AbleToUsed
                a++; 
            }
        }

    }
    public void WanchengRenwu(int QuestNum, bool WanCheng)
    {
        PlayerPrefs.SetString("WanCheng" + QuestNum, WanCheng.ToString());
        Renwuwancheng[QuestNum] = WanCheng;
    }
    public string Reporter(int QuestNum,bool Chenggong )
    {
        if (Chenggong == true)
        {
            return ChenggongL[QuestNum];
        }
        else
        {
            return ShibaiL[QuestNum];
        }
    }   
    public void ChongZhi()
    {
        for (int i = 1; i < 10; i++)
        {
            SaveManager.SaveTime(i, new DateTime(2088, 1, 1, 1, 1, 1,DateTimeKind.Unspecified));
            SaveManager.SaveTeamNum(i,999);
            SuoRenWu(i, true);
            WanchengRenwu(i, false);
        }
    }
}
/*    List<int>year, mouth, day, hour, min, sec= new List<int>();
    public string timeURL = "http://cgi.im.qq.com/cgi-bin/cgi_svrtime";
    void Start()
    {
        StartCoroutine(GetTime(0));//0是系统时间，每个队伍对应一个数字
    }
    public void Jilushijian(int SchoolHandsome)
    {
        StartCoroutine(GetTime(SchoolHandsome));
    }
    IEnumerator GetTime(int UsedtoFirst)//从腾讯获取时间
    {
        WWW www = new WWW(timeURL);
        while (!www.isDone)
        {
            yield return www;
        }
         SplitTime(www.text,UsedtoFirst);

    }

    void SplitTime(string dateTime,int UsedtoSecond)
    {
        dateTime = dateTime.Replace("-", "|");
        dateTime = dateTime.Replace(" ", "|");
        dateTime = dateTime.Replace(":", "|");
        string[] Times = dateTime.Split('|');

        if (Times[0] != null)
        {
            year[UsedtoSecond] = int.Parse(Times[0]);
            mouth[UsedtoSecond] = int.Parse(Times[1]);
            day[UsedtoSecond] = int.Parse(Times[2]);
            hour[UsedtoSecond] = int.Parse(Times[3]);
            min[UsedtoSecond] = int.Parse(Times[4]);--
            sec[UsedtoSecond] = int.Parse(Times[5]);
        }
        else {
            Debug.Log("傻逼了吧");//妈的真傻逼了

        }
        if (UsedtoSecond != 0 && Times[0] != null)
        {
            DateTime d1 = new DateTime(year[0], mouth[0], day[0], hour[0], min[0], sec[0]);
            DateTime d2 = new DateTime(year[UsedtoSecond], mouth[UsedtoSecond], day[UsedtoSecond], hour[UsedtoSecond], min[UsedtoSecond], sec[UsedtoSecond]);
            TimeSpan d3 = d1.Subtract(d2);
            Debug.Log("相差:" + d3.Days.ToString() + "天" + d3.Hours.ToString() + "小时" + d3.Minutes.ToString() + "分钟" + d3.Seconds.ToString() + "秒");
            // int NowTime,BeforeTime,ReturnTime;
            // NowTime = year[0] * mouth[0] * day[0] * hour[0] * min[0] * sec[0];
        }

    }*/
/*GetItem

            if (leixing == "Weapon" || DiceDance == 0)
            //{

            //     List<ItemData> sds =dsfas.AsitemList<armsData,ItemData>();
            //    int jieguo = UnityEngine.Random.Range(0, dsfas.Count);
            //    List<ItemData> ListRare
            {
                List<ItemData> Linshi = new List<ItemData>();
                Linshi = tools.ListRare(rare, leixing);
                int c = UnityEngine.Random.Range(0, Linshi.Count);
                DiaoluoQian.Add(tools.ListRare(rare, leixing)[c]);
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
     */
