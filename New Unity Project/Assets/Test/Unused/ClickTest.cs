using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickHandler : MonoBehaviour
{
    //public TimeManager other;
    // public TimeManager tmg;
    
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

        /*   
        for (int i = 1; i < 5; i++)
        {
            tmg.TimeWalker(i);
        }
        */
    }

    void OnClick()
    {

        for(int i = 1; i < 5; i++)
        {
        }
        //TimeManager
        //TimeWalker;
    }

}