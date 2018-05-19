using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class WarehouseController : closeopen 
{
	GComponent fanhui;
	public Action fanhuia;
	void Start() 
	{
		var ui=GetComponent<UIPanel>().ui;
		fanhui=ui.GetChild("n6").asCom;
		fanhui.onClick.Add(()=>{fanhuia();});
	}
}
