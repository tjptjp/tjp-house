using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameobjManager : MonoBehaviour 
{
    public TestCk testCk;
    public TeamManager teamManager;
	public BagManager bagManager;
    public JUqingManager jUqingManager;
    public StartController startController;
    public MainCityController mainCityController;
    public BlacksmithShopController blacksmithShopController;
    public TavernController tavernController;
    public ItemShopController itemShopController;
    public HouseController houseController;
    public TaskUIController taskUIController;
    public RecordUIController recordUIController;
    public MercenaryController mercenaryController;
    public WarehouseController warehouseController;
    public RingUIController ringUIController;
    Fsm fsm=new Fsm();
    bool firstopen=true;
    void Start() 
    {
        jUqingManager.enabled=false;
        mercenaryController.teamManager=teamManager;
        close();
        InitFSM();
        fsm.SetsendEventName("AllTostart");
        InitAction();
    }
    public void InitFSM()
    {
        fsm.SetCurrStateName("Idle");
        fsm.AddState("Idle");
        fsm.AddState("start",
        () =>
        {
            Debug.Log("start");
           
            // startController.FsmOpeN();
            // startController.gameObject.SetActive(true);
        },
        () =>
        {
        },
        () =>
        {
            Debug.Log("closestart");
            startController.FsmClosE();
        });
        fsm.AddState("juqing",
        () =>
        {
            Debug.Log("juqing");
            jUqingManager.enabled=true;
            jUqingManager.FsmOpeN();
            // jUqingManager.Kaiqi();
            ringUIController.ringclose();
        },
        () =>
        {
        },
        () =>
        {
            Debug.Log("closejuqing");
            jUqingManager.FsmClosE();
            // jUqingManager.enabled=false;
            ringUIController.ringopen();
        });
        fsm.AddState("testck",
        () =>
        {
            testCk.FsmOpeN();
            testCk.ReFlash();
        },
        () =>
        {
        },
        () =>
        {
            testCk.FsmClosE();
        });
        fsm.AddState("MainCity",
        () =>
        {
            mainCityController.FsmOpeN();
            ringUIController.boolfalse();
        },
        () =>
        {
        },
        () =>
        {
            mainCityController.FsmClosE();
        });
        fsm.AddState("BlacksmithShop",
        () =>
        {
           blacksmithShopController.FsmOpeN();
           ringUIController.boolfalse();
        },
        () =>
        {
        },
        () =>
        {
            blacksmithShopController.FsmClosE();
        });
        fsm.AddState("Tavern",
        () =>
        {
           tavernController.FsmOpeN();
           ringUIController.boolfalse();
        },
        () =>
        {
        },
        () =>
        {
            tavernController.FsmClosE();
        });
        fsm.AddState("ItemShop",
        () =>
        {
           itemShopController.FsmOpeN();
           ringUIController.boolfalse();
        },
        () =>
        {
        },
        () =>
        {
            itemShopController.FsmClosE();
        });
        fsm.AddState("House",
        () =>
        {
           houseController.FsmOpeN();
           ringUIController.boolture();
        },
        () =>
        {
        },
        () =>
        {
            houseController.FsmClosE();
        });
        fsm.AddState("Task",
        () =>
        {
           taskUIController.FsmOpeN();
           ringUIController.boolture();
        },
        () =>
        {
        },
        () =>
        {
            taskUIController.FsmClosE();
        });
        fsm.AddState("RecordUI",
        () =>
        {
           recordUIController.FsmOpeN();
           ringUIController.boolfalse();
        },
        () =>
        {
        },
        () =>
        {
            recordUIController.FsmClosE();
        });
        fsm.AddState("Mercenary",
        () =>
        {
           mercenaryController.FsmOpeN();
           ringUIController.boolture();
        },
        () =>
        {
        },
        () =>
        {
            mercenaryController.fsmclose();
            mercenaryController.FsmClosE();
            // mercenaryController.gameObject.SetActive(false);

        });
        fsm.AddState("Warehouse",
        () =>
        {
            warehouseController.FsmOpeN();
            ringUIController.boolture();
        },
        () =>
        {
        },
        () =>
        {
            warehouseController.FsmClosE();
        });
    }
    void close()
    {
        testCk.FsmClosE();
        mainCityController.FsmClosE();
        blacksmithShopController.FsmClosE();
        tavernController.FsmClosE();
        itemShopController.FsmClosE();
        houseController.FsmClosE();
        taskUIController.FsmClosE();
        recordUIController.FsmClosE();
        mercenaryController.FsmClosE();
        warehouseController.FsmClosE();
    }
    public void InitAction()
    {
        startController.onclicka=()=>
        {
            fsm.SetsendEventName("AllTojuqing");
        };
        mainCityController.itemshopop=()=>
        {
            fsm.SetsendEventName("AllToItemShop");
        };
        mainCityController.Mercenaryop=()=>
        {
            fsm.SetsendEventName("AllToMercenary");
        };
        mainCityController.dealerop=()=>
        {
            fsm.SetsendEventName("AllToItemShop");
        };
        tavernController.chumieng=()=>
        {
            fsm.SetsendEventName("AllToMainCity");
        };
        blacksmithShopController.chumen=()=>
        {
            fsm.SetsendEventName("AllToHouse");
        };
        houseController.TAvern=()=>
        {
            fsm.SetsendEventName("AllToTavern");
        };
        houseController.blacks=()=>
        {
            fsm.SetsendEventName("AllToBlacksmithShop");
        };
        houseController.recor=()=>
        {
            fsm.SetsendEventName("AllToRecordUI");
        };
        houseController.Mercen=()=>
        {
            fsm.SetsendEventName("AllToMercenary");
        };
        houseController.canku=()=>
        {
            fsm.SetsendEventName("AllTotestck");
        };
        taskUIController.zhuzaiac=()=>
        {
            fsm.SetsendEventName("AllToHouse");
        };
        itemShopController.chumengd=()=>
        {
            fsm.SetsendEventName("AllToMainCity");
        };
        mercenaryController.zhuzzai=()=>
        {
            fsm.SetsendEventName("AllToHouse");
        };
        warehouseController.fanhuia=()=>
        {
            fsm.SetsendEventName("AllToHouse");
        };
        ringUIController.renwud=()=>
        {
            fsm.SetsendEventName("AllToTask");
        };
        ringUIController.zhaohan=()=>
        {
            fsm.SetsendEventName("AllToTavern");
        };
        ringUIController.zhucheng=()=>
        {
            fsm.SetsendEventName("AllToMainCity");
        };
        ringUIController.zhuzaia=()=>
        {
            fsm.SetsendEventName("AllToHouse");
        };
        ringUIController.jilua=()=>
        {
            fsm.SetsendEventName("AllToRecordUI");
        };
        ringUIController.duiwua=()=>
        {
            fsm.SetsendEventName("AllToMercenary");
        };
        jUqingManager.fanhui=()=>
        {
            if (firstopen)
            {
                fsm.SetsendEventName("AllToMainCity");
                firstopen=false;
            }else
            {
                fsm.SetsendEventName("AllToRecordUI");
            }
            
        };
        recordUIController.juqingas=()=>
        {
            jUqingManager.Kaiqi();
            fsm.SetsendEventName("AllTojuqing");
        };
        blacksmithShopController.ringclose=()=>
        {
            ringUIController.ringclose();
        };
        blacksmithShopController.ringopen=()=>
        {
            ringUIController.ringopen();
        };
        tavernController.ringclose=()=>
        {
            ringUIController.ringclose();
        };
        tavernController.ringopen=()=>
        {
            ringUIController.ringopen();
        };
        itemShopController.ringclose=()=>
        {
            ringUIController.ringclose();
        };
        itemShopController.ringopen=()=>
        {
            ringUIController.ringopen();
        };
        taskUIController.ringclose=()=>
        {
            ringUIController.ringclose();
        };
        taskUIController.ringopen=()=>
        {
            ringUIController.ringopen();
        };
        recordUIController.ringclose=()=>
        {
            ringUIController.ringclose();
        };
        recordUIController.ringopen=()=>
        {
            ringUIController.ringopen();
        };
        mercenaryController.ringclose=()=>
        {
            ringUIController.ringclose();
        };
        mercenaryController.ringopen=()=>
        {
            ringUIController.ringopen();
        };
        teamManager.bag=(ItemData item)=>{
            bagManager.daoruitem(item);
        };
    }
    private void Update()
    {
        fsm.Update();
    }
}
