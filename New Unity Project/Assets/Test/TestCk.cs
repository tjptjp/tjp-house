using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using System.Xml;
public class TestCk : closeopen
{

    public UIPanel panel;
    public GList gList;
    public BagManager bmg;
    public bool Shuaxinqiu = false;
    public List<ItemData> baglist = new List<ItemData>();
    void Start()
    {
        
        //baglist = tools.itemlistRare();
        panel = gameObject.GetComponent<UIPanel>();
        gList = panel.ui.GetChild("n14").asList;

        for (int i = 0; i < baglist.Count; i++)
        {
            String kale = "";
            gList.AddItemFromPool("ui://ghsm6seg7z5n17");
            GComponent ZZ = gList.GetChildAt(i).asCom;
            GTextField Name = ZZ.GetChild("Name").asTextField;
            GTextField Str = ZZ.GetChild("Str").asTextField;
            GTextField Spd = ZZ.GetChild("Spd").asTextField;
            GTextField Int = ZZ.GetChild("Int").asTextField;
            GTextField Hp = ZZ.GetChild("Hp").asTextField;
            GTextField Luc = ZZ.GetChild("Luc").asTextField;
            GTextField Level = ZZ.GetChild("Level").asTextField;
            if (baglist[i].id.ToString().Substring(3, 1) == "G")
            {
                kale = "08e808";
            }
            else if (baglist[i].id.ToString().Substring(3, 1) == "B")
            {
                kale = "0000e1";
            }
            else if (baglist[i].id.ToString().Substring(3, 1) == "P")
            {
                kale = "d81bd8";
            }
            else if (baglist[i].id.ToString().Substring(3, 1) == "R")
            {
                kale = "e71818";
            }
            else
            {
                kale = "ffffff";
            }
            ZZ.GetChild(baglist[i].id.ToString().Substring(1, 2)).asImage.visible = true;

            Name.text = "[color=#" + kale + "]" + baglist[i].name + "[/color]";
            Level.text = "需要等级：" + baglist[i].Grade;
            Hp.text = "Hp：" + baglist[i].hp;
            Str.text = "力量：" + baglist[i].power;
            Spd.text = "敏捷：" + baglist[i].agile;
            Int.text = "智力：" + baglist[i].Spell;
            Luc.text = "幸运：" + baglist[i].lucky;

        }
    }

    void Update()
    {
        if (Shuaxinqiu)
        {
            shuaxin();
            Shuaxinqiu = !Shuaxinqiu;
        }
    }
   public void ReFlash()
    {
        Shuaxinqiu = true;
    }
    public void shuaxin()
    {
        baglist = bmg.publicbag;
        //baglist = tools.itemlistRare();//如果上面那个不行的话试试这个正常列表
        panel = gameObject.GetComponent<UIPanel>();
        gList = panel.ui.GetChild("n14").asList;
        gList.RemoveChildrenToPool();
        for (int i = 0; i < baglist.Count; i++)
        {

            String kale = "";
            gList.AddItemFromPool("ui://ghsm6seg7z5n17");
            GComponent ZZ = gList.GetChildAt(i).asCom;
            GTextField Name = ZZ.GetChild("Name").asTextField;
            GTextField Str = ZZ.GetChild("Str").asTextField;
            GTextField Spd = ZZ.GetChild("Spd").asTextField;
            GTextField Int = ZZ.GetChild("Int").asTextField;
            GTextField Hp = ZZ.GetChild("Hp").asTextField;
            GTextField Luc = ZZ.GetChild("Luc").asTextField;
            GTextField Level = ZZ.GetChild("Level").asTextField;
            if (baglist[i].id.ToString().Substring(3, 1) == "G")
            {
                kale = "08e808";
            }
            else if (baglist[i].id.ToString().Substring(3, 1) == "B")
            {
                kale = "0000e1";
            }
            else if (baglist[i].id.ToString().Substring(3, 1) == "P")
            {
                kale = "d81bd8";
            }
            else if (baglist[i].id.ToString().Substring(3, 1) == "R")
            {
                kale = "e71818";
            }
            else
            {
                kale = "ffffff";
            }
            ZZ.GetChild(baglist[i].id.ToString().Substring(1, 2)).asImage.visible = true;


            Name.text = "[color=#" + kale + "]" + baglist[i].name + "[/color]";
            Level.text = "需要等级：" + baglist[i].Grade;
            Hp.text = "Hp：" + baglist[i].hp;
            Str.text = "力量：" + baglist[i].power;
            Spd.text = "敏捷：" + baglist[i].agile;
            Int.text = "智力：" + baglist[i].Spell;
            Luc.text = "幸运：" + baglist[i].lucky;

        }
    }
}
/*
if (baglist[i].id.ToString().Substring(1, 2) == "01")
{
    ZZ.GetChild("01").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "02")
{
    ZZ.GetChild("02").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "03")
{
    ZZ.GetChild("03").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "04")
{
    ZZ.GetChild("04").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "05")
{
    ZZ.GetChild("05").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "06")
{
    ZZ.GetChild("06").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "07")
{
    ZZ.GetChild("07").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "08")
{
    ZZ.GetChild("08").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "09")
{
    ZZ.GetChild("09").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "10")
{
    ZZ.GetChild("10").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "11")
{
    ZZ.GetChild("11").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "12")
{
    ZZ.GetChild("12").asImage.visible = true;
}
else if (baglist[i].id.ToString().Substring(1, 2) == "13")
{
    ZZ.GetChild("13").asImage.visible = true;
}*/
