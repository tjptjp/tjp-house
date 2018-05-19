using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceshaid : MonoBehaviour
{
    Fsm fsmsa = new Fsm();
    vaitorlist Vaitorlist=new vaitorlist();
    // Use this for initialization
    void Start()
    {
        Vaitorlist.clear();
        init();      
        // Vaitorlist.addvlist(()=>
        // {
        //     return fsm.currStateId;
        // },()=>
        // {
        //     Debug.Log("世界线变动");
        // });
		fsmsa.SetsendEventName("AllTostart");
        // List<ItemData> sda=new List<ItemData>();
        // sda=tools.ListRare("R","Weapon");
        // Debug.Log(""+sda[0].name);
        // ItemData dsf=new ItemData();
        // dsf=tools.IDRare<ItemData>("#02R099");
        // equipmentupData fdsf=new equipmentupData();
        // fdsf=dsf as equipmentupData;
        // Debug.Log(""+fdsf.name);
    }
    void init()
    {
		fsmsa.SetCurrStateName("Idle");
        fsmsa.AddState("Idle");
        fsmsa.AddState("start",
        () =>
        {
            Debug.Log("进入start");
        },
        () =>
        {
			// Debug.Log("进入start");
        },
        () =>
        {
            Debug.Log("退出start");
        });
    }
	
    // Update is called once per frame
    void Update()
    {
        fsmsa.Update();
        Vaitorlist.Update();
    }
}
