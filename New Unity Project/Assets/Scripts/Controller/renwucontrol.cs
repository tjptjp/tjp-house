using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class renwucontrol : MonoBehaviour {
	public Transform kanakn;
	public Text one;
	public Text two;
	public Text time;
	public Text baogao;
	public Text gan;
	public Image pow;
	public Image baogaobeijing;
	public Text zhan;
	public Sprite sp1;
	public Sprite sp2;
	public Sprite sp3;
	public Sprite sp4;
	public Sprite sp5;
	// Use this for initialization
	void Start () {
		baogaobeijing.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void stopbaojing(){
			pow.transform.position = new Vector3 (kanakn.position.x,kanakn.position.y,kanakn.position.z);
			baogaobeijing.enabled = false;
			zhan.enabled = false;
		    gan.enabled = false;
	}
	public void play1(){
		pow.overrideSprite = sp1;
		one.text = "城市探索中";
			two.text="尼伯龙根";
		time.text="00:56:36";
		baogao.enabled = false;
		zhan.enabled = false;
		gan.enabled = false;
	}
	public void play2(){
		pow.overrideSprite = sp2;
		one.text = "副本攻略中";
			two.text="龙岛火山深处";
		time.text="01:35:21";
		baogao.enabled = false;
		zhan.enabled = false;
		gan.enabled = false;
	}
	public void play3(){
		pow.overrideSprite = sp3;
		one.text = "地区清理中";
			two.text="溪林";
		time.text="02:23:59";
		baogao.enabled = false;
		zhan.enabled = false;
		gan.enabled = false;
	}
	public void play4(){
		pow.overrideSprite = sp4;
		one.text = "地区清理成功";
		two.text = "雪原";
		time.text="";
		baogao.enabled = true;
		baogao.text = "我队克服了雪原寒冷的环境，\n侦察到大量魔物，\n对魔物进行讨伐行动获得了成功，\n收获了一大批战利品" ;
		pow.transform.Translate (Vector3.up*100);
		baogaobeijing.enabled = true;
		zhan.enabled = true;
		gan.enabled = true;
	}
	public void play5(){
		pow.overrideSprite = sp5;
		one.text = "地区清理失败";
		two.text = "阿拉米格一区";
		time.text="";
		baogao.enabled = true;
		pow.transform.Translate (Vector3.up*100);
		baogao.text = "我队遭遇敌人突袭，\n敌人使用了大量毒素武器，\n天气炎热，\n我队发挥不良，\n几番思考下，\n决定撤退来日再战";
		baogaobeijing.enabled = true;
		zhan.enabled = true;
		gan.enabled = true;
	}
}
