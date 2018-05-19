using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class ItemShopController : closeopen 
{
	Fsm fsmit=new Fsm();
	GComponent xuan;
	GComponent chushou;
	GComponent guomai;
	GLoader fanhui1;
	GComponent chumeng;
	GComponent chushousada;
	GComponent goumaisn;
	GLoader fanhui2;
	public Action chumengd;
	public Action ringclose;
	public Action ringopen;
	void Start() 
	{
		var ui=GetComponent<UIPanel>().ui;
		xuan=ui.GetChild("n3").asCom;
		chushou=ui.GetChild("n2").asCom;
		guomai=ui.GetChild("n4").asCom;
		chumeng=xuan.GetChild("n8").asCom;
		chushousada=xuan.GetChild("n5").asCom;
		goumaisn=xuan.GetChild("n7").asCom;
		fanhui1=chushou.GetChild("n4").asLoader;
		fanhui2=guomai.GetChild("n6").asLoader;
		sadas();
		initfsm();
		fsmit.SetsendEventName("AllTostartit");
		chumeng.onClick.Add(()=>{chumengd();});
		chushousada.onClick.Add(()=>{fsmit.SetsendEventName("AllToChushou");});
		goumaisn.onClick.Add(()=>{fsmit.SetsendEventName("AllToGoumai");});
		fanhui1.onClick.Add(()=>{fsmit.SetsendEventName("AllTostartit");});
		fanhui2.onClick.Add(()=>{fsmit.SetsendEventName("AllTostartit");});
	}
	void initfsm()
	{
		fsmit.SetCurrStateName("itle");
        fsmit.AddState("itle");
		fsmit.AddState("startit",
        () =>
        {
			ringopen();
			xuan.visible=true;
        },
        () =>
        {
        },
        () =>
        {
			xuan.visible=false;
        });
		fsmit.AddState("Chushou",
        () =>
        {
			ringclose();
			chushou.visible=true;
        },
        () =>
        {
        },
        () =>
        {
			chushou.visible=false;
        });
		fsmit.AddState("Goumai",
        () =>
        {
			ringclose();
			guomai.visible=true;
        },
        () =>
        {
        },
        () =>
        {
			guomai.visible=false;
        });
	}
	void sadas()
	{
		xuan.visible=false;
		chushou.visible=false;
		guomai.visible=false;
	}
	void Update() 
	{
		fsmit.Update();	
	}
}
