using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using DG.Tweening;
public class closeopen : MonoBehaviour,IAFsmopcl
{
	Tweener tweener;
    public void FsmOpeN()
    {
		
        var ui=GetComponent<UIPanel>().ui;
		ui.SetPivot(0.5f,0.5f);
		ui.SetScale(0.8f,0.8f);
		ui.alpha=1;
		ui.visible=true;

		if (tweener!=null)
		{
			tweener.Kill();
		}
		tweener=ui.Doscale(new Vector2(1,1),0.2f).OnComplete(()=>{tweener=null;});
    }

    public void FsmClosE()
    {
        var ui=GetComponent<UIPanel>().ui;
		if (tweener!=null)
		{
			tweener.Kill();
		}
		tweener=ui.DoVsible(0,0.2f).OnComplete(()=>{tweener=null;ui.visible=false;});
    }

    
}
