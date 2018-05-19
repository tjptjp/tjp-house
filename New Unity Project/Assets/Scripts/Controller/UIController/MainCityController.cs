using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using DG.Tweening;
public class MainCityController : closeopen
{
	GComponent itemshop;
	GComponent UI;
	GComponent dealer;
	GComponent Mercenary;
	public Action itemshopop;
	public Action dealerop;
	public Action Mercenaryop;
	private void Start() 
	{
		var ui=GetComponent<UIPanel>().ui;
		UI=ui;
		itemshop=ui.GetChild("n4").asCom;
		dealer=ui.GetChild("n2").asCom;
		Mercenary=ui.GetChild("n3").asCom;
		itemshop.onClick.Add(()=>{itemshopop();});
		dealer.onClick.Add(()=>{dealerop();});
		Mercenary.onClick.Add(()=>{Mercenaryop();});
	}

    // public void FsmOpeN()
    // {
	// 	// UI.SetPivot(0.5f,0.5f);
	// 	// UI.SetScale(0.8f,0.8f);
    //     UI.visible=true;
	// 	UI.DoVsible(1,0.2f);
    // }

    // public void FsmClosE()
    // {
    //     var ui=GetComponent<UIPanel>().ui;
	// 	ui.DoVsible(0,0.2f).OnComplete(()=>{ui.visible=false;});
    // }
}
