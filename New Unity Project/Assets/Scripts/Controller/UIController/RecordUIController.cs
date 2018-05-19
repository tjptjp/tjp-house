using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class RecordUIController : closeopen 
{
	Fsm fsmrecord=new Fsm();
	GComponent record;
	GComponent recordjuqing;
	GComponent recordtujian;
	GComponent recordfuben;
	GComponent jiqingnv;
	public Action ringclose;
	public Action ringopen;
	public Action juqingas;
	void Start() 
	{
		var ui=GetComponent<UIPanel>().ui;
		record=ui.GetChild("n1").asCom;
		jiqingnv=record.GetChild("n0").asCom;
		recordjuqing=ui.GetChild("n2").asCom;
		recordtujian=ui.GetChild("n3").asCom;
		recordfuben=ui.GetChild("n4").asCom;
		guana();
		Initfsm();
		fsmrecord.SetsendEventName("AllToRecord");
		jiqingnv.onClick.Add(()=>{juqingas();});
	}
	void Initfsm()
	{
		fsmrecord.AddState("rec");
		fsmrecord.SetCurrStateName("rec");
		fsmrecord.AddState("Record",
		()=>
		{
			ringopen();
			record.visible=true;
		},()=>
		{

		},()=>
		{
			record.visible=false;
		});
		fsmrecord.AddState("Recordjuqing",
		()=>
		{
			ringclose();
			recordjuqing.visible=true;
		},()=>
		{
			
		},()=>
		{
			recordjuqing.visible=false;
		});
		fsmrecord.AddState("Recordtujian",
		()=>
		{
			ringopen();
			recordtujian.visible=true;
		},()=>
		{
			
		},()=>
		{
			recordtujian.visible=false;
		});
		fsmrecord.AddState("Recordfuben",
		()=>
		{
			ringopen();
			recordfuben.visible=true;
		},()=>
		{
			
		},()=>
		{
			recordfuben.visible=false;
		});

	}
	void guana()
	{
		record.visible=false;
		recordjuqing.visible=false;
		recordtujian.visible=false;
		recordfuben.visible=false;
	}
	void Update() 
	{
		fsmrecord.Update();
	}
}
