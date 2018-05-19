using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class HouseController : closeopen 
{
	GComponent blackshop;
	GComponent tavern;
	GComponent cangku;
	GComponent jilu;
	GComponent yongbin;
	public Action blacks;
	public Action TAvern;
	public Action Mercen;
	public Action recor;
	public Action canku;
	void Start() 
	{
		var ui=GetComponent<UIPanel>().ui;
		blackshop=ui.GetChild("n7").asCom;
		tavern=ui.GetChild("n2").asCom;
		cangku=ui.GetChild("n5").asCom;
		jilu=ui.GetChild("n6").asCom;
		yongbin=ui.GetChild("n1").asCom;
		blackshop.onClick.Add(()=>{blacks();});
		tavern.onClick.Add(()=>{TAvern();});
		yongbin.onClick.Add(()=>{Mercen();});
		jilu.onClick.Add(()=>{recor();});
		cangku.onClick.Add(()=>{canku();});
	}
}
