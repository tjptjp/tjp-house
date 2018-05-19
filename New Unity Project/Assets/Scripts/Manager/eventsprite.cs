using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class eventsprite : MonoBehaviour
{
    public mousesprit Mousesprit;
    List<GameObject> testobj = new List<GameObject>();
    List<Image> testimg = new List<Image>();
    List<Sprite> df = new List<Sprite>();
    public GameObject fuji;
    public static int index;
    public static int nowindex;
    public Image n0;
    public Image n1;
    public void down(Sprite sprite)
    {
        Mousesprit.show(sprite);
    }

    public void up()
    {
        if (nowindex == -1)
        {
            switch (index)
            {
                case 0:
                    n0.sprite = Mousesprit.rtexture();
                    break;
                case 1:
                    n1.sprite = Mousesprit.rtexture();
                    break;

            }
        }
        else if (Mousesprit.youwu())
        {
            switch (nowindex)
            {
                case 0:
                    n0.sprite = Mousesprit.rtexture();
                    break;
                case 1:
                    n1.sprite = Mousesprit.rtexture();
                    break;

            }
        }
        else
        {

        }
        index = -1;
        Mousesprit.close();
    }
    void panduan()
    {

    }
    void newtest(int index)
    {
        GameObject cubePreb = Resources.Load("testbg", typeof(GameObject)) as GameObject;
        for (int i = 0; i < index; i++)
        {
            GameObject cube = Instantiate(cubePreb);
            cube.transform.parent = fuji.transform;
            testobj.Add(cube);
            testimg.Add(cube.GetComponent<Image>());
            cube.GetComponent<test>().index = i;
			cube.GetComponent<test>().ddown=(Sprite fds,int ds)=>{
				index=ds;
				down(fds);
			};
			cube.GetComponent<test>().uuup=()=>{
				vvvup();
			};
			cube.GetComponent<test>().nowindexcon=(int sada)=>{
				nowindex=sada;
			};
        }

    }
    void shuanxing()
    {
        int dsad = 0;
        foreach (var item in testimg)
        {
            item.sprite = df[dsad];
            dsad++;
        }
    }
    void vvvup()
    {
        if (nowindex == -1)
        {
            if (index != -1)
            {
                testimg[index].sprite = Mousesprit.rtexture();
            }
        }
        else if (Mousesprit.youwu())
        {
            if (nowindex != -1)
            {
                if (testimg[nowindex].sprite != null)
                {
                    testimg[index].sprite = testimg[nowindex].sprite;
                    testimg[nowindex].sprite = Mousesprit.rtexture();
                }
                else
                {
                    testimg[nowindex].sprite = Mousesprit.rtexture();
                }
            }
        }
        else
        {

        }
        index = -1;
        Mousesprit.close();
    }

}
