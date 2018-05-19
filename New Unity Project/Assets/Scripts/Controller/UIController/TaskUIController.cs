using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using DG.Tweening;
public class TaskUIController : closeopen 
{
	vaitorlist Vaitorlist=new vaitorlist();
	List<GTextField> timelist=new List<GTextField>();
	DispatchController dispatchController;
	TaskDetailsController taskDetailsController;
	AdventurousRecordController adventurousRecordController;
	public QuestManager questManager;
	Fsm fsmTask=new Fsm();
	GComponent TASK;
	GComponent taskDetails;
	GComponent dispatch;
	GComponent Maoxianjilu;
	GLoader madamdad;
	GLoader fanhui1;
	GLoader fanhui2;
	GLoader fanhui3;
	GLoader zhuzai;
	GLoader paiqian;
	GList tasking;
	GList taskover;
	public Action zhuzaiac;
	public Action ringclose;
	public Action ringopen;
	int renwudian;
	int fubenade;
	List<int> fubenlist=new List<int>();
	public List<TaskDetailsdata> tsdkdata=new List<TaskDetailsdata>();
	void Start() 
	{
		Vaitorlist.clear();
		dispatchController=GetComponent<DispatchController>();
		taskDetailsController=GetComponent<TaskDetailsController>();
		adventurousRecordController=GetComponent<AdventurousRecordController>();
		var ui=GetComponent<UIPanel>().ui;
		TASK=ui.GetChild("n1").asCom;
		taskDetails=ui.GetChild("n2").asCom;
		dispatch=ui.GetChild("n3").asCom;
		Maoxianjilu=ui.GetChild("n4").asCom;
		fanhui1=taskDetails.GetChild("n3").asLoader;
		fanhui2=dispatch.GetChild("n1").asLoader;
		fanhui3=Maoxianjilu.GetChild("n1").asLoader;
		madamdad=TASK.GetChild("n1").asLoader;
		zhuzai=TASK.GetChild("n3").asLoader;
		paiqian=TASK.GetChild("n2").asLoader;
		tasking=TASK.GetChild("n6").asList;
		taskover=TASK.GetChild("n7").asList;
		tasking.numItems=0;
		taskover.numItems=0;
		tasking.itemRenderer=RenderListItem1;
		taskover.itemRenderer=RenderListItem2;
		tasking.onClickItem.Add(onClickItem1);
		taskover.onClickItem.Add(onClickItem2);
		vis();

		Initfsm();
		fsmTask.SetsendEventName("AllToTask");
		fanhui1.onClick.Add(()=>{fsmTask.SetsendEventName("AllToTask");});
		fanhui2.onClick.Add(()=>{fsmTask.SetsendEventName("AllToTask");});
		fanhui3.onClick.Add(()=>{fsmTask.SetsendEventName("AllToTask");});
		paiqian.onClick.Add(()=>{fsmTask.SetsendEventName("AllToDispatch");});
		madamdad.onClick.Add(()=>{fsmTask.SetsendEventName("AllTomaoxianjilu");});
		zhuzai.onClick.Add(()=>{zhuzaiac();});
		dispatchController.dispatch=dispatch;
		taskDetailsController.TaskDetails=taskDetails;
		adventurousRecordController.Maoxianjilu=Maoxianjilu;
		dispatchController.Init();
		taskDetailsController.Init();
		adventurousRecordController.Init();
		dispatchController.kaishirenwu=(int fuben,int duiwu)=>{fubenade=fuben;fubenlist.Add(fuben);questManager.paichu(duiwu,fuben);fsmTask.SetsendEventName("AllToTask");};
		questManager.dsada=(List<ItemData> list,int sdfs,bool sdasdd,string sdasd)=>
		{
			tsdkdata.Add(new TaskDetailsdata(list,sdfs,sdasdd,sdasd));
			adventurousRecordController.sda.Add(new TaskDetailsdata(list,sdfs,sdasdd,sdasd));
			taskDetailsController.sdf=tsdkdata;
			taskDetailsController.shuanxingjiemian(renwudian);
			taskover.numItems=tsdkdata.Count;
			fubenlist.Remove(sdfs);
			
		};
		taskDetailsController.rssda=(int sadas)=>{
			// tsdkdata.RemoveAt(sadas);
			taskover.numItems=tsdkdata.Count;
		};
	}
	void Initfsm()
	{
		fsmTask.AddState("ta");
		fsmTask.SetCurrStateName("ta");
		fsmTask.AddState("Task",
		()=>
		{
			ringopen();
			
			TASK.visible=true;
			
		},()=>
		{

		},()=>
		{
			
			TASK.visible=false;
		});
		fsmTask.AddState("TaskDetails",
		()=>
		{
			ringclose();
			taskDetailsController.taskfsmop();
			taskDetails.visible=true;
		},()=>
		{

		},()=>
		{
			taskDetails.visible=false;
		});
		fsmTask.AddState("Dispatch",
		()=>
		{
			ringclose();
			dispatchController.fsmopen();
			dispatch.visible=true;
		},()=>
		{

		},()=>
		{
			dispatch.visible=false;
			dispatchController.fsmclose();
		});
		fsmTask.AddState("maoxianjilu",
		()=>
		{
			ringclose();
			adventurousRecordController.fsmopen();
			Maoxianjilu.visible=true;
		},()=>
		{

		},()=>
		{
			Maoxianjilu.visible=false;
		});
		Vaitorlist.addvlist(()=>
		{
			return fubenlist.Count;
		},()=>
		{
			timelist.Clear();
			tasking.numItems=fubenlist.Count;
		});
	}
	void vis()
	{
		TASK.visible=false;
		taskDetails.visible=false;
		dispatch.visible=false;
		Maoxianjilu.visible=false;
	}
	void RenderListItem1(int index,GObject obj)
	{
		GButton button = obj.asButton;
		GTextField NAME1=button.GetChild("n5").asTextField;
		GTextField time=button.GetChild("n2").asTextField;
		NAME1.text=tools.indexfenbenname(fubenlist[index]);
		time.text=questManager.Shengyushijian(fubenlist[index]).ToString();
		timelist.Add(time);
	}
	void RenderListItem2(int index,GObject obj)
	{
		GButton button = obj.asButton;
		GTextField NAME1=button.GetChild("n5").asTextField;
		NAME1.text=tools.indexfenbenname(tsdkdata[index].fuben);
		GTextField chengong=button.GetChild("n2").asTextField;
		chengong.text=tools.poolchengong(tsdkdata[index].chenggong);
	}
	void onClickItem1(EventContext etext)
	{
		GObject sdfsad=(GObject)etext.data;
		taskDetailsController.panduanmoshi=true;
		taskDetailsController.fubentime=fubenade;
		taskDetailsController.guicaixianxing=tasking.GetChildIndex(sdfsad);
		taskDetailsController.fengsfsa=tools.indexfenbenname(fubenlist[tasking.GetChildIndex(sdfsad)]);
		fsmTask.SetsendEventName("AllToTaskDetails");
	}
	void onClickItem2(EventContext etext)
	{
		GObject sdfsad=(GObject)etext.data;
		
		taskDetailsController.panduanmoshi=false;
		taskDetailsController.taskshuan(taskover.GetChildIndex(sdfsad));
		fsmTask.SetsendEventName("AllToTaskDetails");
	}

	// float sds=0;
	float adaadfa=0;
	void Update() 
	{
		Vaitorlist.Update();
		fsmTask.Update();


		// if (fubenlist!=null&&fubenlist.Count!=0)
		// {
			
		// 	// if (sds<0.5f)
		// 	// {
		// 	// 	sds+=Time.deltaTime;
		// 	// }else
		// 	// {
		// 		// foreach (var item in fubenlist)
		// 		// {
		// 		// 	if (questManager.Shengyushijian(item).Seconds<=0&&questManager.Shengyushijian(item).Minutes==0)
		// 		// 	{
		// 		// 		fubenlist.Remove(item);
		// 		// 	}
		// 		// }
		// 		sds=0;
		// 	// }
		// }

		if (timelist!=null&&timelist.Count!=0)
		{
			if (adaadfa<1)
			{
				adaadfa+=Time.deltaTime;
			}else
			{
				foreach (var item in timelist)
				{
					Debug.Log("okdas");
					item.text=questManager.Shengyushijian(fubenlist[timelist.IndexOf(item)]).ToString();
				}
				adaadfa=0;
			}
		}
		
	}
}
