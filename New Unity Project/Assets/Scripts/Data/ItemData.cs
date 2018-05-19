using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System;

[Serializable]
public class ItemData
{
    //装备类型
    public EquipType equiptype = EquipType.O;
    //品级
    public EquipQuality equipQuality = EquipQuality.O;
    //使用等级
    public int Grade;
    //血量
    public int hp;
    //力量
    public int power;
    //敏捷
    public int agile;
    //法术
    public int Spell;
    //幸运
    public int lucky;
    //特技描述
    public string tejimiaoshu;
    //装备描述
    public string desc;
    //编号
    public string id;
    
    public string imgid()
    {
        return id.Substring(0,3)+equiptype.ToString();
    }
    //名字
    public string name;
    public CharacterData shiyongzhe;
    public void character(CharacterData ds)
    {
        shiyongzhe = ds;
    }
    public int shuyongzhedengji
    {
        get { if (shiyongzhe != null) { return shiyongzhe.dengji; } else { return 0; } }
    }
    // public float hpxi;
    // //力量系数
    // public float powerxi;
    // //敏捷系数
    // public float agilexi;
    // //法术系数
    // public float Spellxi;
    // //幸运系数
    // public float luckyxi;
    //最终血量

    //最终力量
    public int hpmax
    {
        get { return (int) hp; }
    }

    public int Powermax
    {
        get { return (int) power; }
    }
    //最终敏捷
    public int agilemax
    {
        get { return (int)agile; }
    }
    //最终法术
    public int Spellmax
    {
        get { return (int)Spell; }
    }
    //最终幸运
    public int luckymax
    {
        get { return (int)lucky; }
    }
    // public void shuju(float HPxi = 0/*血量系数*/, float Powxi = 0/*力量系数*/, float Agilexi = 0/*敏捷系数*/, float spellxi = 0/*法术系数*/, float Luckyxi = 0/*幸运系数*/)
    // {
    //     hpxi = HPxi;
    //     powerxi = Powxi;
    //     agilexi = Agilexi;
    //     Spellxi = spellxi;
    //     luckyxi = Luckyxi;
    // }
    public void itemshuju(int HP = 0/*血量*/, int POWER = 0/*力量*/, int AGILE = 0/*敏捷*/, int SPELL = 0/*法术*/, int LUCKY = 0/*幸运*/, int GRADE = 0/*使用等级*/, string NAME = null/*名字*/, string ID = null/*编号*/, string DESC = null/*描述*/, string TEJIMIAOSHU = null/*特技描述*/)
    {
        hp = HP;
        power = POWER;
        agile = AGILE;
        Spell = SPELL;
        lucky = LUCKY;

        Grade = GRADE;

        name = NAME;
        id = ID;
        desc = DESC;
        tejimiaoshu = TEJIMIAOSHU;

        // equiptype=zhuangtype;

    }

}
