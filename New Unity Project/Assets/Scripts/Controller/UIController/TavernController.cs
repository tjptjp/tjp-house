using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FairyGUI;

public class TavernController : closeopen
{
    Fsm fsmta = new Fsm();
    public TeamManager teamManager;
    CharacterData character;
    GComponent renwu;
    GComponent chumeng;
    GComponent kongzhi;
    GLoader fanhui;
    GLoader imgas;
    GTextField n11;
    GTextField n10;
    public Action chumieng;
    public Action ringclose;
    public Action ringopen;
    int shipingbianho;
    bool chukalengque = false;
#if UNITY_STANDALONE_WIN
		GameObject GameObj;
		videocontroller Videocontroller;
#endif
    void Start()
    {
        var ui = GetComponent<UIPanel>().ui;
        renwu = ui.GetChild("n5").asCom;
        fanhui = renwu.GetChild("n1").asLoader;
        imgas = renwu.GetChild("n0").asLoader;
        chumeng = ui.GetChild("n4").asCom;
        kongzhi = ui.GetChild("n2").asCom;
        n10 = ui.GetChild("n10").asTextField;
        n11 = ui.GetChild("n11").asTextField;
        renwu.visible = false;
        n10.visible = false;
        n11.visible = false;
        initfsmta();
        fsmta.SetsendEventName("AllTotavern");
        fanhui.onClick.Add(() => { fsmta.SetsendEventName("AllTotavern"); });
        chumeng.onClick.Add(() => { chumieng(); });
        kongzhi.onClick.Add(() =>
        {
            if (chukalengque == false)
            {
                onkongchi();
                kongzhi.grayed = true;
            }

        });
#if UNITY_STANDALONE_WIN
			GameObj=GameObject.Instantiate(Resources.Load("Camera"),new Vector3(6,6,0),new Quaternion(0,0,0,0)) as GameObject;
			Videocontroller=GameObj.GetComponent<videocontroller>();
#endif
    }
    void onkongchi()
    {
        SaveTime(60);
        jitime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        // jitime.AddSeconds(60);
        chukalengque = true;
        n10.visible = true;
        n11.visible = true;
        character = tools.xmlramcharacterData();

        teamManager.bagren.Add(character);
        fsmta.SetsendEventName("AllTotavernrenwu");
        Debug.Log("" + character.name);
    }
    public void initfsmta()
    {
        fsmta.AddState("taf");
        fsmta.SetCurrStateName("taf");
        fsmta.AddState("tavern",
        () =>
        {
            // renwu.visible=false;
            ringopen();
        }, () =>
         {

         }, () =>
         {

         });
        fsmta.AddState("tavernrenwu",
        () =>
        {
            ringclose();
#if UNITY_ANDROID
            switch (pingji(character.qualityGrade))
            {
                case 1:
                Handheld.PlayFullScreenMovie("Ring03_W.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFit);
                break;
                case 2:
                Handheld.PlayFullScreenMovie("Ring03_P.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFit);
                break;
                case 3:
                Handheld.PlayFullScreenMovie("Ring03_R.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFit);
                break;
                default:
                break;
            }
            
#endif
#if UNITY_STANDALONE_WIN
			Videocontroller.playStart(pingji(character.qualityGrade));
#endif
            imgas.url = "ItemIcon/role/img/" + character.id;
            renwu.visible = true;
        }, () =>
         {

         }, () =>
         {
             renwu.visible = false;
         });
    }
    float adaadfa = 0;
    DateTime jitime;
    TimeSpan asd;
    DateTime date1;
    void Update()
    {
        fsmta.Update();
        if (chukalengque)
        {
            string FuckPanding1 = date1.ToString();
            string FuckPanding2 = System.DateTime.Now.ToString();
            if (FuckPanding1 != FuckPanding2)
            {
                if (LoadTime() <= DateTime.Now)
                {
                    qidf();
                }
                else
                {
                    TimeSpan a = LoadTime() - DateTime.Now;
                    if (a.Minutes < 10)
                    {
                        n11.text = "0"+a.Minutes.ToString() + ":" + a.Seconds.ToString();
                    }
                    else
                    {
                        n11.text = a.Minutes.ToString() + ":" + a.Seconds.ToString();
                    }
                }

            }
        }
        date1 = System.DateTime.Now;

        /*
        if (adaadfa < 1)
        {
            adaadfa += Time.deltaTime;
        }
        else
        {
            asd = new TimeSpan((DateTime.Now - jitime).Hours, (DateTime.Now - jitime).Minutes, (DateTime.Now - jitime).Seconds);
            n11.text = asd.Minutes + ":" + (60 - asd.Seconds).ToString();
            adaadfa = 0;
            if (asd.Seconds == 0)
            {
                qidf();
            }
        }
        */
    
    }
    void qidf()
    {
        chukalengque = false;
        n10.visible = false;
        n11.visible = false;
        kongzhi.grayed = false;
    }
    int pingji(QualityGrade quda)
    {
        int dsad;
        switch (quda)
        {
            case QualityGrade.W:
                dsad = 1;
                break;
            case QualityGrade.P:
                dsad = 2;
                break;
            case QualityGrade.R:
                dsad = 3;
                break;
            case QualityGrade.G:
                dsad = 1;
                break;
            case QualityGrade.B:
                dsad = 1;
                break;
            default:
                dsad = 1;
                break;
        }
        return dsad;
    }
    void SaveTime(int AddSecond)
    {
        PlayerPrefs.SetInt("Year" + "ChouKa", DateTime.Now.AddSeconds(AddSecond).Year);
        PlayerPrefs.SetInt("Month" + "ChouKa", DateTime.Now.AddSeconds(AddSecond).Month);
        PlayerPrefs.SetInt("Day" + "ChouKa", DateTime.Now.AddSeconds(AddSecond).Day);
        PlayerPrefs.SetInt("Hour" + "ChouKa", DateTime.Now.AddSeconds(AddSecond).Hour);
        PlayerPrefs.SetInt("Minute" + "ChouKa", DateTime.Now.AddSeconds(AddSecond).Minute);
        PlayerPrefs.SetInt("Second" + "ChouKa", DateTime.Now.AddSeconds(AddSecond).Second);
    }
    DateTime LoadTime()
    {
        DateTime a = new DateTime(PlayerPrefs.GetInt("Year" + "ChouKa", DateTime.Now.Year), PlayerPrefs.GetInt("Month" + "ChouKa", DateTime.Now.Month), PlayerPrefs.GetInt("Day" + "ChouKa", DateTime.Now.Day), PlayerPrefs.GetInt("Hour" + "ChouKa", DateTime.Now.Hour), PlayerPrefs.GetInt("Minute" + "ChouKa", DateTime.Now.Minute), PlayerPrefs.GetInt("Second" + "ChouKa", DateTime.Now.Second));
        return a;
    }
}
