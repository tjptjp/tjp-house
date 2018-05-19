using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using DG.Tweening;
public class RingUIController : MonoBehaviour 
{
	vaitorlist panduan=new vaitorlist();
	public bool fenqingjing=true;
	GLoader ring;
	GComponent jilu;
	GComponent zhuzai;
	GComponent duiwu;
	GComponent UI;
	GComponent zhaohuan;
	GTextField jiqie;
	GTextField ringtext;
	public Action renwud;
	public Action zhuzaia;
	public Action zhucheng;
	public Action jilua;
	public Action duiwua;
	public Action zhaohan;
	bool losadng=true;
	public bool firstclos=false;
	void Start () {
		panduan.clear();
		var ui=GetComponent<UIPanel>().ui;
		UI=ui;
		jilu=ui.GetChild("n6").asCom;
		ringtext=ui.GetChild("n8").asTextField;
		zhuzai=ui.GetChild("n3").asCom;
		duiwu=ui.GetChild("n2").asCom;
		zhaohuan=ui.GetChild("n5").asCom;
		ring=ui.GetChild("n7").asLoader;
		jiqie=zhuzai.GetChild("n1").asTextField;
		ringtext.alpha=0;
		jilu.visible=false;
		zhuzai.visible=false;
		duiwu.visible=false;
		zhaohuan.visible=false;
		ring.onClick.Add(ringclick);
		ring.url="ItemIcon/jiezhi";
		zhuzai.onClick.Add(zhuzaiclick);
		duiwu.onClick.Add(()=>{duiwua();});
		jilu.onClick.Add(()=>{jilua();});
		zhaohuan.onClick.Add(()=>{zhaohan();});
		LongPressGesture longPress=new LongPressGesture(ring);
		longPress.once=false;
		longPress.interval=0.5f;
		longPress.onAction.Add(onlonghand);
		panduan.addvlist(()=>
		{
			return fenqingjing;
		},()=>
		{
			if(fenqingjing)
			{
				jiqie.text="主城";
				// ring.url="ItemIcon/jiezhi";
				// ringtext.alpha=0;
				// zhuzai.grayed = false;
			}else
			{
				jiqie.text="住宅";
				// ring.url="ItemIcon/bgsddf";
				// ringtext.alpha=1;
				// zhuzai.grayed = true;
			}
		});
	}
	void open()
	{
		jilu.x=460;
		zhuzai.x=450;
		duiwu.x=450;
		zhaohuan.x=460;
		UI.visible=true;
		jilu.visible=true;
		zhuzai.visible=true;
		duiwu.visible=true;
		zhaohuan.visible=true;
		// ring.url="ItemIcon/jiezhi";
		if (jds!=null)
		{
			jds.Kill();
		}
		if (zhuza!=null)
		{
			zhuza.Kill();
		}
		if (duiwa!=null)
		{
			duiwa.Kill();
		}
		if (zhana!=null)
		{
			zhana.Kill();
		}
		jds=jilu.DoSetsizex(69,0.2f);
		zhuza=zhuzai.DoSetsizex(664,0.2f);
		duiwa=duiwu.DoSetsizex(235,0.2f);
		zhana=zhaohuan.DoSetsizex(850,0.2f).OnComplete(()=>
		{
			if (firstclos)
			{
				ring.url="ItemIcon/bgsddf";
				ringtext.alpha=1;
			}else
			{
				firstclos=true;
			}
		});
	}
	Tweener jds;
	Tweener zhuza;
	Tweener duiwa;
	Tweener zhana;
	void close()
	{
		if (jds!=null)
		{
			jds.Kill();
		}
		if (zhuza!=null)
		{
			zhuza.Kill();
		}
		if (duiwa!=null)
		{
			duiwa.Kill();
		}
		if (zhana!=null)
		{
			zhana.Kill();
		}
		jds=jilu.DoSetsizex(460,0.2f).OnComplete(()=>{jilu.visible=false;});
		zhuza=zhuzai.DoSetsizex(450,0.2f).OnComplete(()=>{zhuzai.visible=false;});
		duiwa=duiwu.DoSetsizex(450,0.2f).OnComplete(()=>{duiwu.visible=false;});
		zhana=zhaohuan.DoSetsizex(460,0.2f).OnComplete(()=>{zhaohuan.visible=false;ring.visible=false;UI.visible=false;});
	}
	void longclose()
	{
		if (jds!=null)
		{
			jds.Kill();
		}
		if (zhuza!=null)
		{
			zhuza.Kill();
		}
		if (duiwa!=null)
		{
			duiwa.Kill();
		}
		if (zhana!=null)
		{
			zhana.Kill();
		}
		jds=jilu.DoSetsizex(460,0.2f).OnComplete(()=>{jilu.visible=false;});
		zhuza=zhuzai.DoSetsizex(450,0.2f).OnComplete(()=>{zhuzai.visible=false;});
		duiwa=duiwu.DoSetsizex(450,0.2f).OnComplete(()=>{duiwu.visible=false;});
		zhana=zhaohuan.DoSetsizex(460,0.2f).OnComplete(()=>{zhaohuan.visible=false;});
	}
	public void ringclose()
	{
		if(ring.visible==true)
		{
			close();
			
		}
		
	}
	public void ringopen()
	{
		if(ring.visible==false)
		{
			open();
			ring.visible=true;
		}
		
	}
	void ringclick()
	{
		if (losadng)
		{
			if(jilu.visible==false)
			{
				open();
				
			}else
			{
				ring.url="ItemIcon/bgsddf";
				ringtext.alpha=1;
				renwud();
			}
		}else
		{
			losadng=true;
		}
		
	}
	void zhuzaiclick()
	{
		if (fenqingjing)
		{
			zhucheng();
		}else
		{
			zhuzaia();
		}
	}
	private void Update() 
	{
		panduan.Update();
	}
	public void boolture()
	{
		if(fenqingjing==false)
		{
			fenqingjing=true;
		}
	}
	void onlonghand()
	{
		if (jilu.visible==true)
		{
			ring.url="ItemIcon/jiezhi";
			ringtext.alpha=0;
			longclose();
			losadng=false;
		}
	}
	public void boolfalse()
	{
		if(fenqingjing==true)
		{
			fenqingjing=false;
		}
	}
	
}
