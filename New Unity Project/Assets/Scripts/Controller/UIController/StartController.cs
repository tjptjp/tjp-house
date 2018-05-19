using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using DG.Tweening;
public class StartController : closeopen {
	public GLoader anv;
	public GComponent UI;
	public Action onclicka;
	public GLoader lego;
	public GTextField text;
	Tweener tweener=null;
	bool sdsad;
    // Use this for initialization
    void Start () 
	{
		var ui=GetComponent<UIPanel>().ui;
		UI=ui;
 		anv=ui.GetChild("gmae").asLoader;
		lego=ui.GetChild("n2").asLoader;
		
		text=ui.GetChild("n3").asTextField;
		
		lego.alpha=0;
		lego.DoVsible(1,3f);
		sdsad=true;
		anv.onClick.Add(()=>{anv.TweenFade(0,0.2f);onclicka();sdsad=false;});
	}
	
	
	void Update () {
		if (sdsad==true&&tweener==null)
		{
			tweener=text.DoVsible(0,1.5f).OnComplete(()=>
			{
				tweener=text.DoVsible(1,1.5f).OnComplete(()=>
				{
					tweener=null;
				});
			});
		}
	}
}
