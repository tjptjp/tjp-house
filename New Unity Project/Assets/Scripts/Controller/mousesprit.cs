using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mousesprit : MonoBehaviour {
	private float thx;
	private float thy;
	// Use this for initialization
	void Start () {
		 close();
	}
	public void show(Sprite sprite){
		this.GetComponent<Image>().color=new Color(255,255,255,1);
		this.GetComponent<Image>().sprite=sprite;
	}
	public void close(){
		this.GetComponent<Image>().color=new Color(0,0,0,0);
		this.GetComponent<Image>().sprite=null;

	}
	public Sprite rtexture(){
		return this.GetComponent<Image>().sprite;
	}
	public bool youwu(){
		if(this.GetComponent<Image>().sprite==null){return false;}else{return true;}
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			this.transform.position = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0);
		}else
			this.transform.position = new Vector3(500,0,0);
	}
}
