using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Fsm
{
    List<Event> EventList { get; set; }
    Dictionary<int, State> StateDic { get; set; }

    int Allid = "All".GetHashCode();
    State CurrState { get { return StateDic[currStateId]; } }
    public int currStateId;
    int sendEventName = 0;
    public class Event
    {
        public string name{get;}
        public int Id { get; }
        public int ToId { get; }
        public int formId { get; }
        // public string ToName{get;}
        // public string FormName{get;}
        // public string EventName{get;}
        public System.Func<bool> Condition;
        public System.Action action;

        public Event(string eventname, string formname, string toname, System.Func<bool> condition, System.Action Action)
        {
            //  EventName=eventname;
            //  FormName=formname;
            //  ToName=toname;
            name=eventname;
            Id = eventname.GetHashCode();
            ToId = toname.GetHashCode();
            formId = formname.GetHashCode();
            Condition = condition;
            action = Action;
        }
    }
    public class State
    {
        public string Name;
        public int Id;
        public Action OnBegin { get; }
        public Action OnUpdate { get; }
        public Action OnEnd { get; }
        public State(string name, Action begin, Action update, Action end)
        {
            Name=name;
            Id = name.GetHashCode();
            OnBegin = begin;
            OnUpdate = update;
            OnEnd = end;
        }

    }
    public Fsm()
    {
        EventList = new List<Event>();
        StateDic = new Dictionary<int, State>();
    }

    public void SetCurrStateName(string name)
    {
        currStateId = name.GetHashCode();
    }
    public void SetsendEventName(string name)
    {
        sendEventName = name.GetHashCode();
    }

    public void AddState(string statename, Action begin = null, Action update = null, Action end = null)
    {
        var ret = new State(statename, begin, update, end);
        StateDic.Add(ret.Id, ret);
        AddEvent("AllTo" + statename, "All", statename, () => { return false; });
    }
    public Event AddEvent(string eventname, string formname, string toname, System.Func<bool> condition, System.Action Action = null)
    {
        var eve = new Event(eventname, formname, toname, condition, Action);
        EventList.Add(eve);
        return eve;
    }
    public void Update()
    {
        var currState = CurrState;
        if (currState.OnUpdate != null)
        {
            currState.OnUpdate();
        }
        foreach (var item in EventList)
        {
            if ((item.formId == Allid||currStateId.Equals(item.formId))&& sendEventName != item.ToId)
            {
                int sdasd=("AllTo" + currStateId).GetHashCode();
                string gfd=item.name;
                if (item.Condition() || item.Id == sendEventName)
                {
                    if (item.action != null)
                    {
                        item.action();
                    }
                    string fdssf=currState.Name;
                    if (currState.OnEnd != null)
                    {
                        currState.OnEnd();
                    }
                    currStateId = item.ToId;
                    if (CurrState.OnBegin != null)
                    {
                        CurrState.OnBegin();
                    }
                    break;
                }
            }
        }
        sendEventName = 0;

    }
}
