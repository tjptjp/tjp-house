using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class test :MonoBehaviour,IPointerEnterHandler ,IPointerExitHandler,IPointerUpHandler,IPointerDownHandler{
    public int index;
	eventsprite Eventsprite;
	public Action uuup;
	public Action <int> nowindexcon;
	public Action <Sprite,int> ddown;
	
	void Start () {
	GameObject gameObject=this.gameObject.transform.parent.gameObject;
	Eventsprite=gameObject.transform.Find("gsdffsd").GetComponent<eventsprite>();
	}
	public void OnPointerEnter(PointerEventData data){
		eventsprite.nowindex=index;
		//nowindexcon(index);
	}
	public void OnPointerExit(PointerEventData data){
		eventsprite.nowindex=-1;
		// nowindexcon(-1);
	}
	public void OnPointerUp(PointerEventData data){
		Eventsprite.up();
		//uuup();
	}
	public void OnPointerDown(PointerEventData data){
		if(this.gameObject.GetComponent<Image>().sprite!=null){
			eventsprite.index=index;
			Eventsprite.down(this.gameObject.GetComponent<Image>().sprite);
			// ddown(this.gameObject.GetComponent<Image>().sprite,index);
			close();
		}
	}
	
	public void close(){
		this.gameObject.GetComponent<Image>().sprite=null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
