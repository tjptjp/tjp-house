using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour {
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;
	public GameObject button5;
	public GameObject button6;
	public GameObject button7;
	public GameObject button8;
	public Canvas Canvas1;
	public Canvas Canvas2;
	public Canvas Canvas3;
	public Canvas Canvas4;
	public Canvas Canvas5;
	public Canvas Canvas6;
	public Canvas Canvas7;
	public Canvas Canvas8;
	public Canvas Canvas9;
	public Canvas Canvas10;
	public Canvas Canvas11;
	public Canvas Canvas12;
	public Canvas Canvas13;
	public Canvas Canvas14;
	public Canvas Canvas15;
	public Canvas Canvas16;
	public Canvas Canvas17;
	public Canvas Canvas18;
	public Canvas Canvas19;
	public Canvas Canvas20;
	public Canvas Canvas21;
	public Canvas Canvas22;
	public Canvas Canvas23;
	public Canvas Canvas24;
	public Canvas Canvas25;
	public Canvas Canvas26;
	public Canvas Canvas27;
	public Canvas Canvas28;
	public Canvas canvas29;
	// Use this for initialization
	void Start () {
		ExitCanvas1 ();
		exitjie();
		ExitCanvas3 ();
		ExitCanvas4 ();
		ExitCanvas5 ();
		ExitCanvas6 ();
		ExitCanvas7 ();
		ExitCanvas8 ();
		ExitCanvas9 ();
		ExitCanvas10 ();
		ExitCanvas11 ();
		ExitCanvas12 ();
		ExitCanvas13 ();
		ExitCanvas14 ();
		ExitCanvas15 ();
		ExitCanvas16 ();
		ExitCanvas17 ();
		ExitCanvas18 ();
		ExitCanvas19 ();
		ExitCanvas20 ();
		ExitCanvas21 ();
		ExitCanvas22 ();
		ExitCanvas23 ();
		ExitCanvas24 ();
		ExitCanvas25 ();
		ExitCanvas26 ();
		ExitCanvas27 ();
		ExitCanvas28 ();
		ExitCanvas29 ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void panduan(){
		switch (button1.activeSelf) {
		case false:
			startjie ();
			break;
		case true:
			exitjie ();
			break;
		default:
			break;
		}

	
	}
	public void panduan2(){
		switch (button5.activeSelf) {
		case false:
			startjie2 ();
			break;
		case true:
			exitjie2 ();
			break;
		default:
			break;
		}


	}
	public void stopjie(){
		canvas29.enabled = false;
		Canvas1.enabled = false;
	}
	public void startjie2(){
		button5.SetActive(true);
		button6.SetActive(true);
		button7.SetActive(true);
		button8.SetActive(true);
	}
	public void exitjie2(){
		button5.SetActive(false);
		button6.SetActive(false);
		button7.SetActive(false);
		button8.SetActive(false);
	}
	public void startjie(){
		button1.SetActive(true);
		button2.SetActive(true);
		button3.SetActive(true);
		button4.SetActive(true);
	}
	public void exitjie(){
		button1.SetActive(false);
		button2.SetActive(false);
		button3.SetActive(false);
		button4.SetActive(false);
	}
	public void ExitCanvas1(){
		Canvas1.enabled = false;
	}
	public void ExitCanvas2(){
		Canvas2.enabled = false;
	}
	public void ExitCanvas3(){
		Canvas3.enabled = false;
	}
	public void ExitCanvas4(){
		Canvas4.enabled = false;
	}
	public void ExitCanvas5(){
		Canvas5.enabled = false;
	}
	public void ExitCanvas6(){
		Canvas6.enabled = false;
	}
	public void ExitCanvas7(){
		Canvas7.enabled = false;
	}
	public void ExitCanvas8(){
		Canvas8.enabled = false;
	}
	public void ExitCanvas9(){
		Canvas9.enabled = false;
	}
	public void ExitCanvas10(){
		Canvas10.enabled = false;
	}
	public void ExitCanvas11(){
		Canvas11.enabled = false;
	}
	public void ExitCanvas12(){
		Canvas12.enabled = false;
	}
	public void ExitCanvas13(){
		Canvas13.enabled = false;
	}
	public void ExitCanvas14(){
		Canvas14.enabled = false;
	}
	public void ExitCanvas15(){
		Canvas15.enabled = false;
	}
	public void ExitCanvas16(){
		Canvas16.enabled = false;
	}
	public void ExitCanvas17(){
		Canvas17.enabled = false;
	}
	public void ExitCanvas18(){
		Canvas18.enabled = false;
	}
	public void ExitCanvas19(){
		Canvas19.enabled = false;
	}
	public void ExitCanvas20(){
		Canvas20.enabled = false;
	}
	public void ExitCanvas21(){
		Canvas21.enabled = false;
	}
	public void ExitCanvas22(){
		Canvas22.enabled = false;
	}
	public void ExitCanvas23(){
		Canvas23.enabled = false;
	}
	public void ExitCanvas24(){
		Canvas24.enabled = false;
	}
	public void ExitCanvas25(){
		Canvas25.enabled = false;
	}
	public void ExitCanvas26(){
		Canvas26.enabled = false;
	}
	public void ExitCanvas27(){
		Canvas27.enabled = false;
	}
	public void ExitCanvas28(){
		Canvas28.enabled = false;
	}
	public void ExitCanvas29(){
		canvas29.enabled = false;
	}
	public void StartCanvas1(){
		Canvas1.enabled = true;
	}
	public void StartCanvas2(){
		Canvas2.enabled = true;
	}
	public void StartCanvas3(){
		Canvas3.enabled = true;
	}
	public void StartCanvas4(){
		Canvas4.enabled = true;
	}
	public void StartCanvas5(){
		Canvas5.enabled = true;
	}
	public void StartCanvas6(){
		Canvas6.enabled = true;
	}
	public void StartCanvas7(){
		Canvas7.enabled = true;
	}
	public void StartCanvas8(){
		Canvas8.enabled = true;
	}
	public void StartCanvas9(){
		Canvas9.enabled = true;
	}
	public void StartCanvas10(){
		Canvas10.enabled = true;
	}
	public void StartCanvas11(){
		Canvas11.enabled = true;
	}
	public void StartCanvas12(){
		Canvas12.enabled = true;
	}
	public void StartCanvas13(){
		Canvas13.enabled = true;
	}
	public void StartCanvas14(){
		Canvas14.enabled = true;
	}
	public void StartCanvas15(){
		Canvas15.enabled = true;
	}
	public void StartCanvas16(){
		Canvas16.enabled = true;
	}
	public void StartCanvas17(){
		Canvas17.enabled = true;
	}
	public void StartCanvas18(){
		Canvas18.enabled = true;
	}
	public void StartCanvas19(){
		Canvas19.enabled = true;
	}
	public void StartCanvas20(){
		Canvas20.enabled = true;
	}
	public void StartCanvas21(){
		Canvas21.enabled = true;
	}
	public void StartCanvas22(){
		Canvas22.enabled = true;
	}
	public void StartCanvas23(){
		Canvas23.enabled = true;
	}
	public void StartCanvas24(){
		Canvas24.enabled = true;
	}
	public void StartCanvas25(){
		Canvas25.enabled = true;
	}
	public void StartCanvas26(){
		Canvas26.enabled = true;
	}
	public void StartCanvas27(){
		Canvas27.enabled = true;
	}
	public void StartCanvas28(){
		Canvas28.enabled = true;
	}
	public void StartCanvas29(){
		canvas29.enabled = true;
	}
	public void qingkong(){
		ExitCanvas2 ();
		ExitCanvas3 ();
		ExitCanvas4 ();
		ExitCanvas5 ();
		ExitCanvas6 ();
		ExitCanvas7 ();
		ExitCanvas8 ();
		ExitCanvas9 ();
		ExitCanvas10 ();
		ExitCanvas11 ();
		ExitCanvas12 ();
		ExitCanvas13 ();
		ExitCanvas14 ();
		ExitCanvas15 ();
		ExitCanvas16 ();
		ExitCanvas17 ();
		ExitCanvas18 ();
		ExitCanvas19 ();
		ExitCanvas20 ();
		ExitCanvas21 ();
		ExitCanvas22 ();
		ExitCanvas23 ();
		ExitCanvas24 ();
		ExitCanvas25 ();
		ExitCanvas26 ();
		ExitCanvas27 ();
		ExitCanvas28 ();
	}
}
