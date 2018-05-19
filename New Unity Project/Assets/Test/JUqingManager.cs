using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System.IO;
using System.Xml;
using System;
public class JUqingManager : closeopen
{
    public UIPanel panel;
    public GList gList;
    string data;
    XmlDocument xml;
    XmlNodeList xmlNodeList;
    int CA1, CA2, CA3, CB1, CB21, CB22 = 0;
    bool A1, A2, A3, B1, B21, B22 = false;
    bool BA1, BA2, BA3, BB1, BB21, BB22 = false;
    GComponent ZZ, XX, gCom;
    int Jiange = 90;
    public Action fanhui;
    int Timmmm = 0;
    GComponent DreamWalker, DreamShaker,DreamBreaker;
    // Use this for initialization
    void Start()
    {
        TheStart();
        //Qingkong();
        // if(PlayerPrefs.GetString("DYZ-A1"+ "Name"+"1") == "")
        // {
        Debug.Log(1);
        Debug.Log(PlayerPrefs.GetInt("YouxiKaishi"));
        if (PlayerPrefs.GetInt("YouxiKaishi") == 1)
        {
            UIPanel DreamMaker = gameObject.GetComponent<UIPanel>();
            DreamWalker = DreamMaker.ui.GetChild("n6").asCom;
            DreamWalker.visible = true;
            DreamWalker.touchable = true;

        }
        else
        {
            data = Resources.Load("Talk").ToString();
            xml = new XmlDocument();
            xml.LoadXml(data);
            xmlNodeList = xml.SelectSingleNode("Juqing").ChildNodes;
            foreach (XmlElement xl1 in xmlNodeList)
            {
                foreach (XmlElement xl2 in xl1.ChildNodes)
                {
                    PlayerPrefs.SetString(xl1.GetAttribute("id") + "Name" + xl2.GetAttribute("Num"), xl2.GetAttribute("Name"));
                    PlayerPrefs.SetString(xl1.GetAttribute("id") + "Speak" + xl2.GetAttribute("Num"), xl2.GetAttribute("Speak"));
                }
            }

        }
        //Zong("DYZ-A1");
        A1 = true;
    }
    void Update()
    {
        if (A1 && Timmmm >= Jiange)
        {
            if (CA1 + CA2 + CA3 + CB1 + CB21 + CB22 == 0)
            {
                panel = gameObject.GetComponent<UIPanel>();
                gList = panel.ui.GetChild("n14").asList;
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
            }
            CA1++;
            ShengCheng(CA1 + CA2 + CA3 + CB1 + CB21 + CB22, "DYZ-A1", PlayerPrefs.GetString("DYZ-A1" + "Name" + CA1), CA1);
            Timmmm = 0;
            gList.scrollPane.SetPercY(1, true);
        }
        if (A2 && Timmmm >= Jiange)
        {
            if (CA1 + CA2 + CA3 + CB1 + CB21 + CB22 == 0)
            {
                panel = gameObject.GetComponent<UIPanel>();
                gList = panel.ui.GetChild("n14").asList;
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
            }
            CA2++;
            ShengCheng(CA1 + CA2 + CA3 + CB1 + CB21 + CB22, "DYZ-A2", PlayerPrefs.GetString("DYZ-A2" + "Name" + CA2), CA2);
            Timmmm = 0;
            gList.scrollPane.SetPercY(1, true);
        }
        if (A3 && Timmmm >= Jiange)
        {
            if (CA1 + CA2 + CA3 + CB1 + CB21 + CB22 == 0)
            {
                panel = gameObject.GetComponent<UIPanel>();
                gList = panel.ui.GetChild("n14").asList;
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
            }
            CA3++;
            ShengCheng(CA1 + CA2 + CA3 + CB1 + CB21 + CB22, "DYZ-A3", PlayerPrefs.GetString("DYZ-A3" + "Name" + CA3), CA3);
            Timmmm = 0;
            if (PlayerPrefs.GetString("DYZ-A3" + "Name" + (CA3 + 1)) == "")
            {
                A3 = false;
            }
            gList.scrollPane.SetPercY(1, true);
        }
        if (B1 && Timmmm >= Jiange)
        {
            if (CA1 + CA2 + CA3 + CB1 + CB21 + CB22 == 0)
            {
                panel = gameObject.GetComponent<UIPanel>();
                gList = panel.ui.GetChild("n14").asList;
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
            }
            CB1++;
            ShengCheng(CA1 + CA2 + CA3 + CB1 + CB21 + CB22, "DYZ-B1", PlayerPrefs.GetString("DYZ-B1" + "Name" + CB1), CB1);
            Timmmm = 0;
            gList.scrollPane.SetPercY(1, true);
        }
        if (B21 && Timmmm >= Jiange)
        {
            if (CA1 + CA2 + CA3 + CB1 + CB21 + CB22 == 0)
            {
                panel = gameObject.GetComponent<UIPanel>();
                gList = panel.ui.GetChild("n14").asList;
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
            }
            CB21++;
            ShengCheng(CA1 + CA2 + CA3 + CB1 + CB21 + CB22, "DYZ-B2-1", PlayerPrefs.GetString("DYZ-B2-1" + "Name" + CB21), CB21);
            Timmmm = 0;
            gList.scrollPane.SetPercY(1, true);
        }
        if (B22 && Timmmm >= Jiange)
        {
            if (CA1 + CA2 + CA3 + CB1 + CB21 + CB22 == 0)
            {
                panel = gameObject.GetComponent<UIPanel>();
                gList = panel.ui.GetChild("n14").asList;
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
                gList.AddItemFromPool("ui://ghsm6segneqiu");
            }
            CB22++;
            ShengCheng(CA1 + CA2 + CA3 + CB1 + CB21 + CB22, "DYZ-B2-2", PlayerPrefs.GetString("DYZ-B2-2" + "Name" + CB22), CB22);
            Timmmm = 0;
            gList.scrollPane.SetPercY(1, true);
        }

        Timmmm++;
    }
    void ShengCheng(int JuqingNum, string JuqingBianHao, string Name, int WBShunxu)
    {
        panel = gameObject.GetComponent<UIPanel>();
        gList = panel.ui.GetChild("n14").asList;

        if (Name == "主角" || Name == "少年")
        {
            gList.AddItemFromPool("ui://ghsm6segk59lr");
            yasuo(JuqingNum, JuqingBianHao, Name, WBShunxu);
            GTextField TName = ZZ.GetChild("Name").asTextField;
            TName.text = PlayerPrefs.GetString(JuqingBianHao + "Name" + WBShunxu);
        }
        else if (Name == "旁白")
        {
            gList.AddItemFromPool("ui://ghsm6segneqit");
            yasuo(JuqingNum, JuqingBianHao, Name, WBShunxu);
            GTextField TName = ZZ.GetChild("Name").asTextField;
            TName.text = "";
        }
        else if (Name == "玩家")
        {
            gList.AddItemFromPool("ui://ghsm6segk59lm");
            yasuo(JuqingNum, JuqingBianHao, Name, WBShunxu);
        }
        else if (Name == "大字")
        {
            gList.AddItemFromPool("ui://ghsm6seguurmy");
            yasuo(JuqingNum, JuqingBianHao, Name, WBShunxu);
            GTextField TName = ZZ.GetChild("Name").asTextField;
            TName.text = "";
        }
        else if (Name == "选项")
        {
            gList.AddItemFromPool("ui://ghsm6seg84poz");
            DXyasuo(JuqingNum, JuqingBianHao, Name, WBShunxu);
            delJianting();
        }
        else if (Name == "选项1")
        {
            gList.AddItemFromPool("ui://ghsm6seg84poz");
            SXyasuo(JuqingNum, JuqingBianHao, Name, WBShunxu);
            //GTextField TName = ZZ.GetChild("Name").asTextField;
            //TName.text = "";
        }
        else
        {
            gList.AddItemFromPool("ui://ghsm6segk59ls");
            yasuo(JuqingNum, JuqingBianHao, Name, WBShunxu);
            GTextField TName = ZZ.GetChild("Name").asTextField;
            TName.text = PlayerPrefs.GetString(JuqingBianHao + "Name" + WBShunxu);
        }

    }
    void yasuo(int JuqingNum, string JuqingBianHao, string Name, int WBShunxu)
    {
        panel = gameObject.GetComponent<UIPanel>();
        gList = panel.ui.GetChild("n14").asList;
        ZZ = gList.GetChildAt(JuqingNum + 3).asCom;
        GTextField Speak = ZZ.GetChild("Speak").asTextField;
        Speak.text = PlayerPrefs.GetString(JuqingBianHao + "Speak" + WBShunxu);
        if (JuqingBianHao == "DYZ-B2-2" && WBShunxu == 7)
        {
            Tiaozhuan("A3");
        }
        else if (JuqingBianHao == "DYZ-B2-1" && WBShunxu == 7)
        {
            Tiaozhuan("A3");
        }
        else if (JuqingBianHao == "DYZ-A3" && WBShunxu == 33)
        {
            DreamWalker.visible = true;
            DreamWalker.touchable = true;
            PlayerPrefs.SetInt("YouxiKaishi", 1);
        }
    }
    void DXyasuo(int JuqingNum, string JuqingBianHao, string Name, int WBShunxu)
    {
        panel = gameObject.GetComponent<UIPanel>();
        gCom = panel.ui.GetChild("n15").asCom;
        gCom.visible = true;
        gCom.touchable = true;
        GTextField Speak = gCom.GetChild("Speak").asTextField;
        Speak.text = PlayerPrefs.GetString(JuqingBianHao + "Speak" + WBShunxu);
        gCom.onClick.Clear();
        if (JuqingBianHao == "DYZ-B1" && WBShunxu == 7)
        {
            gCom.onClick.Add(() => Tiaozhuan("A2"));
        }
        else
        {
            gCom.onClick.Add(addJianting);
        }

    }
    void SXyasuo(int JuqingNum, string JuqingBianHao, string Name, int WBShunxu)
    {
        panel = gameObject.GetComponent<UIPanel>();
        gCom = panel.ui.GetChild("n16").asCom;
        gCom.visible = true;
        gCom.touchable = true;
        GComponent Btn1 = gCom.GetChild("Btn1").asCom;
        GComponent Btn2 = gCom.GetChild("Btn2").asCom;
        GTextField Speak1 = Btn1.GetChild("Speak").asTextField;
        GTextField Speak2 = Btn2.GetChild("Speak").asTextField;
        Speak1.text = PlayerPrefs.GetString(JuqingBianHao + "Speak" + WBShunxu);
        Speak2.text = PlayerPrefs.GetString(JuqingBianHao + "Speak" + (WBShunxu + 1));
        Btn1.onClick.Clear();
        Btn2.onClick.Clear();
        if ((JuqingBianHao == "DYZ-A1" && WBShunxu == 11))
        {
            Btn1.onClick.Add(() => Tiaozhuan("A2"));
            Btn2.onClick.Add(() => Tiaozhuan("B1"));
        }
        else if (JuqingBianHao == "DYZ-A2" && WBShunxu == 39)
        {
            Btn1.onClick.Add(() => Tiaozhuan("B21"));
            Btn2.onClick.Add(() => Tiaozhuan("B22"));
        }
        else
        {
            gCom.onClick.Add(addJianting);
        }
        Btn2.onClick.Add(() => addJianting());
        delJianting();
    }
    void Qingkong()
    {
        QKChild("DYZ-A1");
        QKChild("DYZ-A2");
        QKChild("DYZ-B1");
        QKChild("DYZ-B2-1");
        QKChild("DYZ-B2-2");
        QKChild("DYZ-A3");
    }
    void QKChild(string id)
    {
        for (int i = 0; i < 200; i++)
        {
            PlayerPrefs.SetString(id + "Name" + i, "");
            PlayerPrefs.SetString(id + "Speak" + i, "");
        }
    }
    void addJianting()
    {
        Timmmm = Jiange + 1;
        gCom.visible = false;
        gCom.touchable = false;
        if (BA1)
        {
            A1 = true;
            BA1 = false;
        }
        if (BA2)
        {
            A2 = true;
            BA2 = false;
        }
        if (BA3)
        {
            A3 = true;
            BA3 = false;
        }
        if (BB1)
        {
            B1 = true;
            BB1 = false;
        }
        if (BB21)
        {
            B21 = true;
            BB21 = false;
        }
        if (BB22)
        {
            B22 = true;
            BB22 = false;
        }
    }
    void delJianting()
    {
        if (A1)
        {
            BA1 = true;
            A1 = false;
        }
        if (A2)
        {
            BA2 = true;
            A2 = false;
        }
        if (A3)
        {
            BA3 = true;
            A3 = false;
        }
        if (B1)
        {
            BB1 = true;
            B1 = false;
        }
        if (B21)
        {
            BB21 = true;
            B21 = false;
        }
        if (B22)
        {
            BB22 = true;
            B22 = false;
        }
    }
    void Tiaozhuan(string Kaiguan)
    {
        Timmmm = Jiange + 1;
        gCom.visible = false;
        gCom.touchable = false;
        BA1 = false;
        A1 = false;
        BA2 = false;
        A2 = false;
        BA3 = false;
        A3 = false;
        BB1 = false;
        B1 = false;
        BB21 = false;
        B21 = false;
        BB22 = false;
        B22 = false;
        if (Kaiguan == "A1")
        {
            A1 = true;
        }
        else if (Kaiguan == "A2")
        {
            A2 = true;
        }
        else if (Kaiguan == "A3")
        {
            A3 = true;
        }
        else if (Kaiguan == "B1")
        {
            B1 = true;
        }
        else if (Kaiguan == "B21")
        {
            B21 = true;
        }
        else if (Kaiguan == "B22")
        {
            B22 = true;
        }
        Timmmm = Jiange + 1;
    }
    int ClickCount = 0;
    void Skip(int spd)
    {
        Jiange = spd;
        if (Jiange > 50)
        {
            DreamBreaker.touchable = false;
            DreamBreaker.visible = false;
            DreamShaker.touchable = true;
            DreamShaker.visible = true;
        }
        else
        {
            DreamBreaker.touchable = true;
            DreamBreaker.visible = true;
            DreamShaker.touchable = false;
            DreamShaker.visible = false;
        }
        
     //   Timmmm = Jiange + 1;
    }
    void GoBack()
    {
        // panel.ui.visible = false;
        // panel.ui.touchable = false;
        CA1 = 0;
        CA2 = 0;
        CA3 = 0;
        CB1 = 0;
        CB21 = 0;
        CB22 = 0;
        BA1 = false;
        A1 = false;
        BA2 = false;
        A2 = false;
        BA3 = false;
        A3 = false;
        BB1 = false;
        B1 = false;
        BB21 = false;
        B21 = false;
        BB22 = false;
        B22 = false;
        fanhui();
    }
    void TheStart()
    {
        UIPanel DreamMaker = gameObject.GetComponent<UIPanel>();
        DreamWalker = DreamMaker.ui.GetChild("n6").asCom;
        DreamWalker.onClick.Add(() => GoBack());
        DreamShaker = DreamMaker.ui.GetChild("n7").asCom;
        DreamShaker.onClick.Add(() => Skip(20));
        DreamBreaker = DreamMaker.ui.GetChild("n8").asCom;
        DreamBreaker.onClick.Add(() => Skip(90));
    }
    public void Kaiqi()
    {
        if (gList.numChildren != 0)
        {
            gList.RemoveChildrenToPool();
        }
        CA1 = 0;
        CA2 = 0;
        CA3 = 0;
        CB1 = 0;
        CB21 = 0;
        CB22 = 0;
        BA1 = false;
        A1 = false;
        BA2 = false;
        A2 = false;
        BA3 = false;
        A3 = false;
        BB1 = false;
        B1 = false;
        BB21 = false;
        B21 = false;
        BB22 = false;
        B22 = false;
        // panel.ui.visible = true;
        // panel.ui.touchable = true;
        A1 = true;
    }
}
/*void Zong(string JuqingBianHao)
{
    int a = 1;
    foreach (XmlElement xl1 in xmlNodeList)
    {
        foreach (XmlElement xl2 in xl1.ChildNodes)
        {
            if (xl1.GetAttribute("id") == JuqingBianHao)
            {
                Debug.Log("a");
                ShengCheng(a, JuqingBianHao, xl2.GetAttribute("Name"));
                a++;
            }
        }
    }
}*/

