using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;
using System.IO;
public static class tools
{

    public static CharacterData xmlcharacterData(string bianhaoid)
    {
        CharacterData cHaracterData=new CharacterData();
        string data = Resources.Load("Character").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllCharacter").ChildNodes;
        foreach (XmlElement xl1 in xmlNodeList)
        {
            if (xl1.GetAttribute("ChaNum")==bianhaoid)
            {
                cHaracterData.shuju
                (
                    xl1.GetAttribute("Name"),
                    xl1.GetAttribute("ChaNum"),
                    int.Parse(xl1.GetAttribute("Hp")),
                    int.Parse(xl1.GetAttribute("Str")),
                    int.Parse(xl1.GetAttribute("Spd")),
                    int.Parse(xl1.GetAttribute("Int")),
                    int.Parse(xl1.GetAttribute("Luc")),
                    0,
                    float.Parse(xl1.GetAttribute("HpLevel")),
                    float.Parse(xl1.GetAttribute("StrLevel")),
                    float.Parse(xl1.GetAttribute("SpdLevel")),
                    float.Parse(xl1.GetAttribute("IntLevel")),
                    float.Parse(xl1.GetAttribute("LucLevel"))
                );
                cHaracterData.Race=xmlRace(xl1.GetAttribute("Race"));
                cHaracterData.qualityGrade=xmlqualityadsa(xl1.GetAttribute("Rare"));
                cHaracterData.dengji=1;
                break;
            }
        }
        return cHaracterData;
    }
    public static CharacterData xmlramcharacterData()
    {
        int sda =UnityEngine.Random.Range(0, 7);
        int sd=0;
        CharacterData cHaracterData=new CharacterData();
        string data = Resources.Load("Character").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllCharacter").ChildNodes;
        foreach (XmlElement xl1 in xmlNodeList)
        {
            if (sd==sda)
            {
                cHaracterData.shuju
                (
                    xl1.GetAttribute("Name"),
                    xl1.GetAttribute("ChaNum"),
                    int.Parse(xl1.GetAttribute("Hp")),
                    int.Parse(xl1.GetAttribute("Str")),
                    int.Parse(xl1.GetAttribute("Spd")),
                    int.Parse(xl1.GetAttribute("Int")),
                    int.Parse(xl1.GetAttribute("Luc")),
                    0,
                    float.Parse(xl1.GetAttribute("HpLevel")),
                    float.Parse(xl1.GetAttribute("StrLevel")),
                    float.Parse(xl1.GetAttribute("SpdLevel")),
                    float.Parse(xl1.GetAttribute("IntLevel")),
                    float.Parse(xl1.GetAttribute("LucLevel"))
                );
                cHaracterData.Race=xmlRace(xl1.GetAttribute("Race"));
                cHaracterData.qualityGrade=xmlqualityadsa(xl1.GetAttribute("Rare"));
                cHaracterData.dengji=1;
                break;
            }
            sd++;
        }
        return cHaracterData;
    }
    //返回根据稀有度和类型的装备list
    public static List<ItemData> ListRare(string rare = null/*稀有度*/, string leixing = null/*装备类型*/)
    {

        List<ItemData> sad = new List<ItemData>();
        string data = Resources.Load("Equip").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllEquip").ChildNodes;
        //遍历所有子节点
        foreach (XmlElement xl1 in xmlNodeList)
        {
            // XmlNodeList xmldsaNodeList = xl1.SelectSingleNode(leixing).ChildNodes;
            if (xl1.Name == leixing)
            {
                foreach (XmlElement xl2 in xl1.ChildNodes)
                {

                    if (xl2.GetAttribute("Rare") == rare)//搜索稀有度的装备
                    {
                        ItemData DSADASA = new ItemData();
                        switch (xl1.Name)
                        {
                            case "Weapon":
                                armsData sadad = new armsData();
                                sadad.itemshuju
                                    (
                                        int.Parse(xl2.GetAttribute("Hp")),
                                        int.Parse(xl2.GetAttribute("Str")),
                                        int.Parse(xl2.GetAttribute("Spd")),
                                        int.Parse(xl2.GetAttribute("Int")),
                                        int.Parse(xl2.GetAttribute("Luc")),
                                        int.Parse(xl2.GetAttribute("UserLevel")),
                                        xl2.GetAttribute("Name"),
                                        xl2.GetAttribute("ItemNum")
                                    );
                                // dasd(sadad, leixing, rare);
                                sadad.equipQuality = XmlEquipQuality(rare);
                                sadad.equiptype = XmlEquipType(leixing);
                                DSADASA=sadad as ItemData;
                                break;
                            case "ShangZhuang":
                                equipmentupData afaasdag = new equipmentupData();
                                afaasdag.itemshuju
                                    (
                                        int.Parse(xl2.GetAttribute("Hp")),
                                        int.Parse(xl2.GetAttribute("Str")),
                                        int.Parse(xl2.GetAttribute("Spd")),
                                        int.Parse(xl2.GetAttribute("Int")),
                                        int.Parse(xl2.GetAttribute("Luc")),
                                        int.Parse(xl2.GetAttribute("UserLevel")),
                                        xl2.GetAttribute("Name"),
                                        xl2.GetAttribute("ItemNum")
                                    );
                                // dasd(afaasdag, leixing, rare);
                                afaasdag.equipQuality = XmlEquipQuality(rare);
                                afaasdag.equiptype = XmlEquipType(leixing);
                                DSADASA=afaasdag as ItemData;
                                break;
                            case "XiaZhuang":
                                equipmentdownData frrfw = new equipmentdownData();
                                frrfw.itemshuju
                                    (
                                        int.Parse(xl2.GetAttribute("Hp")),
                                        int.Parse(xl2.GetAttribute("Str")),
                                        int.Parse(xl2.GetAttribute("Spd")),
                                        int.Parse(xl2.GetAttribute("Int")),
                                        int.Parse(xl2.GetAttribute("Luc")),
                                        int.Parse(xl2.GetAttribute("UserLevel")),
                                        xl2.GetAttribute("Name"),
                                        xl2.GetAttribute("ItemNum")
                                    );
                                // dasd(frrfw, leixing, rare);
                                frrfw.equipQuality = XmlEquipQuality(rare);
                                frrfw.equiptype = XmlEquipType(leixing);
                                DSADASA=frrfw as ItemData;
                                break;
                            case "ShiPin":
                                OrnamentsData daacdsa = new OrnamentsData();
                                daacdsa.itemshuju
                                    (
                                        int.Parse(xl2.GetAttribute("Hp")),
                                        int.Parse(xl2.GetAttribute("Str")),
                                        int.Parse(xl2.GetAttribute("Spd")),
                                        int.Parse(xl2.GetAttribute("Int")),
                                        int.Parse(xl2.GetAttribute("Luc")),
                                        int.Parse(xl2.GetAttribute("UserLevel")),
                                        xl2.GetAttribute("Name"),
                                        xl2.GetAttribute("ItemNum")
                                    );
                                // dasd(daacdsa, leixing, rare);
                                daacdsa.equipQuality = XmlEquipQuality(rare);
                                daacdsa.equiptype = XmlEquipType(leixing);
                                DSADASA=daacdsa as ItemData;
                                break;
                        }

                        // equipmentuplist();
                        sad.Add(DSADASA);

                    }
                }
                break;
            }

        }
        return sad;
    }
    //xml转种族枚举类型
    public static race xmlRace(string racestring)
    {
        race Race=race.renzu;
        switch (racestring)
        {
            case "人族":
            Race=race.renzu;
            break;
            case "石人族":
            Race=race.shiren;
            break;
            case "暗影族":
            Race=race.anyingzu;
            break;
            case "龙族":
            Race=race.longzu;
            break;
            case "兽族":
            Race=race.souzu;
            break;
            case "精灵族":
            Race=race.jinglin;
            break;
        }
        return Race;
    }
    //xml转换装备枚举类型
    public static EquipType XmlEquipType(string leixing)
    {
        EquipType HUAN = EquipType.O;
        switch (leixing)
        {
            case "Weapon":
                HUAN = EquipType.arms;
                break;
            case "ShangZhuang":
                HUAN = EquipType.equipmentup;
                break;
            case "XiaZhuang":
                HUAN = EquipType.equipmentdown;
                break;
            case "ShiPin":
                HUAN = EquipType.Ornaments;
                break;
        }
        return HUAN;
    }
    public static string EquipTypeXml(EquipType leixing)
    {
        string HUAN="";
        switch (leixing)
        {
            case EquipType.arms:
                HUAN ="Weapon";
                break;
            case EquipType.equipmentup:
                HUAN ="ShangZhuang";
                break;
            case EquipType.equipmentdown:
                HUAN ="XiaZhuang";
                break;
            case EquipType.Ornaments:
                HUAN ="ShiPin";
                break;
        }
        return HUAN;
    }
    //xml转换装备品级枚举类型
    public static EquipQuality XmlEquipQuality(string rare)
    {
        EquipQuality HUAN = EquipQuality.O;
        switch (rare)
        {
            case "R":
                HUAN = EquipQuality.R;
                break;
            case "P":
                HUAN = EquipQuality.P;
                break;
            case "B":
                HUAN = EquipQuality.B;
                break;
            case "G":
                HUAN = EquipQuality.G;
                break;
            case "W":
                HUAN = EquipQuality.W;
                break;
        }
        return HUAN;
    }
    //根据编号赋值游戏对象
    public static T IDRare<T>(string ID = null/*编号*/) where T : ItemData
    {
        ItemData DSADASA = new ItemData();
        string data = Resources.Load("Equip").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        //得到objects节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllEquip").ChildNodes;
        //遍历所有子节点
        foreach (XmlElement xl1 in xmlNodeList)
        {

            // XmlNodeList xmldsaNodeList = xl1.SelectSingleNode(leixing).ChildNodes;

            foreach (XmlElement xl2 in xl1.ChildNodes)
            {

                if (xl2.GetAttribute("ItemNum") == ID)//搜索稀有度的装备
                {
                    switch (xl1.Name)
                    {
                        case "Weapon":
                            armsData dsf = new armsData();
                            dsf.itemshuju
                            (
                                int.Parse(xl2.GetAttribute("Hp")),
                                int.Parse(xl2.GetAttribute("Str")),
                                int.Parse(xl2.GetAttribute("Spd")),
                                int.Parse(xl2.GetAttribute("Int")),
                                int.Parse(xl2.GetAttribute("Luc")),
                                int.Parse(xl2.GetAttribute("UserLevel")),
                                xl2.GetAttribute("Name"),
                                xl2.GetAttribute("ItemNum")
                            );
                            // dasd(dsf, xl1.Name, xl2.Name);
                            dsf.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                            dsf.equiptype = XmlEquipType(xl1.Name);
                            DSADASA = dsf as ItemData;
                            break;
                        case "ShangZhuang":
                            equipmentupData ada = new equipmentupData();
                            ada.itemshuju
                            (
                                int.Parse(xl2.GetAttribute("Hp")),
                                int.Parse(xl2.GetAttribute("Str")),
                                int.Parse(xl2.GetAttribute("Spd")),
                                int.Parse(xl2.GetAttribute("Int")),
                                int.Parse(xl2.GetAttribute("Luc")),
                                int.Parse(xl2.GetAttribute("UserLevel")),
                                xl2.GetAttribute("Name"),
                                xl2.GetAttribute("ItemNum")
                            );
                            // dasd(ada, xl1.Name, xl2.Name);
                            ada.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                            ada.equiptype = XmlEquipType(xl1.Name);
                            DSADASA = ada as ItemData;
                            break;
                        case "XiaZhuang":
                            equipmentdownData sadsad = new equipmentdownData();
                            sadsad.itemshuju
                            (
                                int.Parse(xl2.GetAttribute("Hp")),
                                int.Parse(xl2.GetAttribute("Str")),
                                int.Parse(xl2.GetAttribute("Spd")),
                                int.Parse(xl2.GetAttribute("Int")),
                                int.Parse(xl2.GetAttribute("Luc")),
                                int.Parse(xl2.GetAttribute("UserLevel")),
                                xl2.GetAttribute("Name"),
                                xl2.GetAttribute("ItemNum")
                            );
                            // dasd(sadsad, xl1.Name, xl2.Name);
                            sadsad.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                            sadsad.equiptype = XmlEquipType(xl1.Name);
                            DSADASA = sadsad as ItemData;
                            break;
                        case "ShiPin":
                            OrnamentsData fsfsfs = new OrnamentsData();
                            fsfsfs.itemshuju
                            (
                                int.Parse(xl2.GetAttribute("Hp")),
                                int.Parse(xl2.GetAttribute("Str")),
                                int.Parse(xl2.GetAttribute("Spd")),
                                int.Parse(xl2.GetAttribute("Int")),
                                int.Parse(xl2.GetAttribute("Luc")),
                                int.Parse(xl2.GetAttribute("UserLevel")),
                                xl2.GetAttribute("Name"),
                                xl2.GetAttribute("ItemNum")
                            );
                            // dasd(fsfsfs, xl1.Name, xl2.Name);
                            fsfsfs.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                            fsfsfs.equiptype = XmlEquipType(xl1.Name);
                            DSADASA = fsfsfs as ItemData;
                            break;
                    }
                    // DSADASA.itemshuju
                    // (
                    //     int.Parse(xl2.GetAttribute("Hp")),
                    //     int.Parse(xl2.GetAttribute("Str")),
                    //     int.Parse(xl2.GetAttribute("Spd")),
                    //     int.Parse(xl2.GetAttribute("Int")),
                    //     int.Parse(xl2.GetAttribute("Luc")),
                    //     int.Parse(xl2.GetAttribute("UserLevel")),
                    //     xl2.GetAttribute("Name")
                    // );
                    // dasd(DSADASA,xl1.Name, xl2.Name);
                    // DSADASA.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                    // DSADASA.equiptype = XmlEquipType(xl1.Name);

                    break;
                }
            }
        }
        return DSADASA as T;

    }
       public static List<ItemData> ListnoRare(string rare = null/*稀有度*/)
    {

        List<ItemData> sad = new List<ItemData>();

        string data = Resources.Load("Equip").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        //得到objects节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllEquip").ChildNodes;
        //遍历所有子节点
        foreach (XmlElement xl1 in xmlNodeList)
        {
            // XmlNodeList xmldsaNodeList = xl1.SelectSingleNode(leixing).ChildNodes;
            
                foreach (XmlElement xl2 in xl1.ChildNodes)
                {

                    if (xl2.GetAttribute("Rare") == rare)//搜索稀有度的装备
                    {
                        ItemData DSADASA = new ItemData();
                        switch (xl1.Name)
                        {
                            case "Weapon":
                                armsData sadad = new armsData();
                                sadad.itemshuju
                                    (
                                        int.Parse(xl2.GetAttribute("Hp")),
                                        int.Parse(xl2.GetAttribute("Str")),
                                        int.Parse(xl2.GetAttribute("Spd")),
                                        int.Parse(xl2.GetAttribute("Int")),
                                        int.Parse(xl2.GetAttribute("Luc")),
                                        int.Parse(xl2.GetAttribute("UserLevel")),
                                        xl2.GetAttribute("Name"),
                                        xl2.GetAttribute("ItemNum")
                                    );
                                // dasd(sadad, leixing, rare);
                                sadad.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                                sadad.equiptype = XmlEquipType(xl1.Name);
                                DSADASA=sadad as ItemData;
                                break;
                            case "ShangZhuang":
                                equipmentupData afaasdag = new equipmentupData();
                                afaasdag.itemshuju
                                    (
                                        int.Parse(xl2.GetAttribute("Hp")),
                                        int.Parse(xl2.GetAttribute("Str")),
                                        int.Parse(xl2.GetAttribute("Spd")),
                                        int.Parse(xl2.GetAttribute("Int")),
                                        int.Parse(xl2.GetAttribute("Luc")),
                                        int.Parse(xl2.GetAttribute("UserLevel")),
                                        xl2.GetAttribute("Name"),
                                        xl2.GetAttribute("ItemNum")
                                    );
                                // dasd(afaasdag, leixing, rare);
                                afaasdag.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                                afaasdag.equiptype = XmlEquipType(xl1.Name);
                                DSADASA=afaasdag as ItemData;
                                break;
                            case "XiaZhuang":
                                equipmentdownData frrfw = new equipmentdownData();
                                frrfw.itemshuju
                                    (
                                        int.Parse(xl2.GetAttribute("Hp")),
                                        int.Parse(xl2.GetAttribute("Str")),
                                        int.Parse(xl2.GetAttribute("Spd")),
                                        int.Parse(xl2.GetAttribute("Int")),
                                        int.Parse(xl2.GetAttribute("Luc")),
                                        int.Parse(xl2.GetAttribute("UserLevel")),
                                        xl2.GetAttribute("Name"),
                                        xl2.GetAttribute("ItemNum")
                                    );
                                // dasd(frrfw, leixing, rare);
                                frrfw.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                                frrfw.equiptype = XmlEquipType(xl1.Name);
                                DSADASA=frrfw as ItemData;
                                break;
                            case "ShiPin":
                                OrnamentsData daacdsa = new OrnamentsData();
                                daacdsa.itemshuju
                                    (
                                        int.Parse(xl2.GetAttribute("Hp")),
                                        int.Parse(xl2.GetAttribute("Str")),
                                        int.Parse(xl2.GetAttribute("Spd")),
                                        int.Parse(xl2.GetAttribute("Int")),
                                        int.Parse(xl2.GetAttribute("Luc")),
                                        int.Parse(xl2.GetAttribute("UserLevel")),
                                        xl2.GetAttribute("Name"),
                                        xl2.GetAttribute("ItemNum")
                                    );
                                // dasd(daacdsa, leixing, rare);
                                daacdsa.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                                daacdsa.equiptype = XmlEquipType(xl1.Name);
                                DSADASA=daacdsa as ItemData;
                                break;
                        }

                        // equipmentuplist();
                        sad.Add(DSADASA);

                    }
                }
                break;
            

        }
        return sad;
    }
    public static string indexfenbenname(int insd)
	{
        String FSAA;
		switch (insd)
		{
			case 1:
			FSAA="东区";
			break;
			case 2:
			FSAA="西区";
			break;
			case 3:
			FSAA="卡斯城近郊";
			break;
			case 4:
			FSAA="卡斯城远郊";
			break;
			case 5:
			FSAA="叹息之地";
			break;
			case 6:
			FSAA="望城山";
			break;
			case 7:
			FSAA="克里斯村";
			break;
			default:
			FSAA="";
			break;
		}
        return FSAA;
	}
    public static QualityGrade xmlqualityadsa(string rgb)
    {
        QualityGrade ssdas;
        switch (rgb)
        {
            case "R":
            ssdas=QualityGrade.R;
            break;
            case "G":
            ssdas=QualityGrade.G;
            break;
            case "B":
            ssdas=QualityGrade.B;
            break;
            case "W":
            ssdas=QualityGrade.W;
            break;
            case "P":
            ssdas=QualityGrade.P;
            break;
            default:
            ssdas=QualityGrade.O;
            break;
        }
        return ssdas;
    }
    public static string poolchengong(bool insd)
	{
        if (insd)
        {
            return "成功";
        }else
        {
            return "失败";
        }
	}
        public static List<ItemData> itemlistRare()
        {
        List<ItemData> DSADASA = new List<ItemData>();
        string data = Resources.Load("Equip").ToString();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(data);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("AllEquip").ChildNodes;
        //遍历所有子节点
        foreach (XmlElement xl1 in xmlNodeList)
        {

            // XmlNodeList xmldsaNodeList = xl1.SelectSingleNode(leixing).ChildNodes;

            foreach (XmlElement xl2 in xl1.ChildNodes)
            {

                // if (xl2.GetAttribute("ItemNum") == ID)//搜索稀有度的装备
                // {
                    switch (xl1.Name)
                    {
                        case "Weapon":
                            armsData dsf = new armsData();
                            dsf.itemshuju
                            (
                                int.Parse(xl2.GetAttribute("Hp")),
                                int.Parse(xl2.GetAttribute("Str")),
                                int.Parse(xl2.GetAttribute("Spd")),
                                int.Parse(xl2.GetAttribute("Int")),
                                int.Parse(xl2.GetAttribute("Luc")),
                                int.Parse(xl2.GetAttribute("UserLevel")),
                                xl2.GetAttribute("Name"),
                                xl2.GetAttribute("ItemNum")
                                
                            );
                            // dasd(dsf, xl1.Name, xl2.Name);
                            dsf.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                            dsf.equiptype = XmlEquipType(xl1.Name);
                            DSADASA.Add(dsf as ItemData);
                            break;
                        case "ShangZhuang":
                            equipmentupData ada = new equipmentupData();
                            ada.itemshuju
                            (
                                int.Parse(xl2.GetAttribute("Hp")),
                                int.Parse(xl2.GetAttribute("Str")),
                                int.Parse(xl2.GetAttribute("Spd")),
                                int.Parse(xl2.GetAttribute("Int")),
                                int.Parse(xl2.GetAttribute("Luc")),
                                int.Parse(xl2.GetAttribute("UserLevel")),
                                xl2.GetAttribute("Name"),
                                xl2.GetAttribute("ItemNum")
                                
                            );
                            // dasd(ada, xl1.Name, xl2.Name);
                            ada.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                            ada.equiptype = XmlEquipType(xl1.Name);
                            DSADASA.Add(ada as ItemData);
                            break;
                        case "XiaZhuang":
                            equipmentdownData sadsad = new equipmentdownData();
                            sadsad.itemshuju
                            (
                                int.Parse(xl2.GetAttribute("Hp")),
                                int.Parse(xl2.GetAttribute("Str")),
                                int.Parse(xl2.GetAttribute("Spd")),
                                int.Parse(xl2.GetAttribute("Int")),
                                int.Parse(xl2.GetAttribute("Luc")),
                                int.Parse(xl2.GetAttribute("UserLevel")),
                                xl2.GetAttribute("Name"),
                                xl2.GetAttribute("ItemNum")
                            );
                            // dasd(sadsad, xl1.Name, xl2.Name);
                            sadsad.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                            sadsad.equiptype = XmlEquipType(xl1.Name);
                            DSADASA.Add(sadsad as ItemData);
                            break;
                        case "ShiPin":
                            OrnamentsData fsfsfs = new OrnamentsData();
                            fsfsfs.itemshuju
                            (
                                int.Parse(xl2.GetAttribute("Hp")),
                                int.Parse(xl2.GetAttribute("Str")),
                                int.Parse(xl2.GetAttribute("Spd")),
                                int.Parse(xl2.GetAttribute("Int")),
                                int.Parse(xl2.GetAttribute("Luc")),
                                int.Parse(xl2.GetAttribute("UserLevel")),
                                xl2.GetAttribute("Name"),
                                xl2.GetAttribute("ItemNum")
                            );
                            // dasd(fsfsfs, xl1.Name, xl2.Name);
                            fsfsfs.equipQuality = XmlEquipQuality(xl2.GetAttribute("Rare"));
                            fsfsfs.equiptype = XmlEquipType(xl1.Name);
                            DSADASA.Add(fsfsfs as ItemData);
                            break;
                    }

                    
                // }
            }
        }
        return DSADASA;

    }


}
