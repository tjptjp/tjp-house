using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class BlacksmithShopController : closeopen 
{
	Fsm fsms=new Fsm();
	GComponent xuan;
	GComponent duanzhao;
	GComponent fumo;
	
	GComponent fsmfumo;
	GComponent fsmduanzhao;
	GLoader fanhui1;
	GLoader fanhui2;
	GComponent chumeng;
	public Action chumen;
	public Action ringclose;
	public Action ringopen;
	void Start()
	{
		var ui=GetComponent<UIPanel>().ui;
		xuan=ui.GetChild("n5").asCom;
		duanzhao=ui.GetChild("n4").asCom;
		fumo=ui.GetChild("n2").asCom;
		
		chumeng=xuan.GetChild("n5").asCom;
		fsmfumo=xuan.GetChild("zhuanbeifumo").asCom;
		fsmduanzhao=xuan.GetChild("zhuanbeiduanzhao").asCom;
		fanhui2=fumo.GetChild("fanhuiua").asLoader;
		fanhui1=duanzhao.GetChild("fnahuiannv").asLoader;
		Stfl();
		InitFsm();
		fsms.SetsendEventName("AllToxuanzhe");
		InitAction();
		
	}
	void InitFsm()
	{
		// fsms.SetCurrStateName("yrt");
        fsms.AddState("yrt");
		fsms.SetCurrStateName("yrt");
		fsms.AddState("xuanzhe",
		()=>
		{
			ringopen();
			xuan.visible=true;
			fsmduanzhao.onClick.Add(()=>{fsms.SetsendEventName("AllToduanzhao");});
			fsmfumo.onClick.Add(()=>{fsms.SetsendEventName("AllTofumo");});
			chumeng.onClick.Add(()=>{chumen();});
		},()=>
		{

		},()=>
		{
			xuan.visible=false;
		});
		fsms.AddState("duanzhao",
		()=>
		{
			ringclose();
			duanzhao.visible=true;
			fanhui1.onClick.Add(()=>{initthis();});
		},()=>
		{

		},()=>
		{
			duanzhao.visible=false;
		});
		fsms.AddState("fumo",
		()=>
		{
			ringclose();
			fumo.visible=true;
			fanhui2.onClick.Add(()=>{initthis();});
		},()=>
		{

		},()=>
		{
			fumo.visible=false;
		});

		
	}
	void InitAction()
	{
		
		
		
	}
	void initthis()
	{
		fsms.SetsendEventName("AllToxuanzhe");
	}
	void Stfl()
	{
		xuan.visible=false;
		duanzhao.visible=false;
		fumo.visible=false;
	}
	void Update()
	{
		fsms.Update();
	}
}
