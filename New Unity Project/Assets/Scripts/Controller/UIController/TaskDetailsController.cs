using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class TaskDetailsdata
{
	public List<ItemData> itemlist=new List<ItemData>();
	public int fuben;
	public bool chenggong;
	public string desc;
	public TaskDetailsdata(List<ItemData> list,int fin,bool bl,string sds)
	{
		itemlist=list;
		fuben=fin;
		chenggong=bl;
		desc=sds;
	}
}
public class TaskDetailsController : MonoBehaviour 
{
	public List<TaskDetailsdata> sdf=new List<TaskDetailsdata>();
	public GComponent TaskDetails;
	public QuestManager questManager;
	public BagManager bagManager;
	GComponent taskbaogao;
	GLoader img;
	GTextField nametext;
	GTextField texttop;
	GTextField time;
	GList zhanliping;
	GTextField baogoao;
	public int fubentime;
	public string fengsfsa;
	public bool panduanmoshi;
	public int guicaixianxing;
	public Action<int> rssda;
	public Action<int> shuanxingjiemian;
	public void Init ()
	{
		taskbaogao=TaskDetails.GetChild("n5").asCom;
		GLoader dfas=TaskDetails.GetChild("n3").asLoader;
		baogoao=taskbaogao.GetChild("n1").asTextField;
		zhanliping=taskbaogao.GetChild("n2").asList;
		img=TaskDetails.GetChild("n4").asLoader;
		texttop=TaskDetails.GetChild("n1").asTextField;
		nametext=TaskDetails.GetChild("n2").asTextField;
		time=TaskDetails.GetChild("n0").asTextField;
		zhanliping.numItems=0;
		zhanliping.itemRenderer=RenderListItem;
		zhanliping.onClickItem.Add(onclicksa);
		dfas.onClick.Add(()=>{if (panduanmoshi==false)
		{
			sdf.RemoveAt(dfsdf);
			rssda(dfsdf);
		}});
		taskbaogao.visible=false;
		shuanxingjiemian=(int dsad)=>
		{
			if (dsad==guicaixianxing)
			{
				panduanmoshi=false;
				taskfsmop();
				zhanliping.numItems=sdf[dsad].itemlist.Count;
				// zhanliping.EnsureBoundsCorrect();
			}
			
		};
	}

	public void taskfsmop()
	{
		if (panduanmoshi)
		{
			time.visible=true;
			taskbaogao.visible=false;
			// texttop.SetXY(287,59);
			// nametext.SetXY(473,181);
			// img.SetXY(0,436);
			texttop.SetXY(287,319);
			nametext.SetXY(473,441);
			img.SetXY(0,696);
			texttop.text="地区清理中";
			nametext.text=fengsfsa;
		}
		else
		{
			time.visible=false;
			taskbaogao.visible=true;
			texttop.SetXY(287,59);
			nametext.SetXY(473,181);
			img.SetXY(0,436);
			// texttop.SetXY(287,319);
			// nametext.SetXY(473,441);
			// img.SetXY(0,696);
			nametext.text=tools.indexfenbenname(sdf[dfsdf].fuben);
			texttop.text=tools.poolchengong(sdf[dfsdf].chenggong);
		}
	}
	public void taskshuan(int asdfas)
	{
		dfsdf=asdfas;
		zhanliping.numItems=sdf[asdfas].itemlist.Count;
	}
	int dfsdf;
	void RenderListItem(int index,GObject obj)
	{
		GButton button = obj.asButton;
		GLoader bus=button.GetChild("n1").asLoader;
		bus.url="ItemIcon/item/"+sdf[dfsdf].itemlist[index].imgid();
	}
	void onclicksa(EventContext etext)
	{
		GObject sdfsad=(GObject)etext.data;
		bagManager.daoruitem(sdf[dfsdf].itemlist[zhanliping.GetChildIndex(sdfsad)]);
		sdf[dfsdf].itemlist.RemoveAt(zhanliping.GetChildIndex(sdfsad));
		zhanliping.numItems=sdf[dfsdf].itemlist.Count;
	}
	float wds=0;
	// Update is called once per frame
	void Update () 
	{
		if (wds<1)
		{
			wds+=Time.deltaTime;
		}else
		{
			if (fubentime!=0)
            {
                time.text = questManager.Shengyushijian(fubentime).ToString();
            }
			wds=0;
		}
	}
}
