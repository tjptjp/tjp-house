using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
public class TalkManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GTextField Name, Speak;
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        Speak = panel.ui.GetChild("Speak").asTextField;
        Speak.text = "DOTA2天下第一";
        if (panel.ui.gameObjectName == "玩家的话")
        {
        }
        else
        {
            Name = panel.ui.GetChild("Name").asTextField;
        }
        
        //GList GL = obj3.
        //GList Gl = animation;
    }
    // Update is called once per frame
    void Update()
    {


    }
}
