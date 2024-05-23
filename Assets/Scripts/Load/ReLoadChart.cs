using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using static LoadChart;

public class ReLoadChart : MonoBehaviour
{
    public bool isStart = false;

    public static List<EventList> eventList = new();

    public UnityEvent ChartLoadOver;

    public void ScriptStart()
    {
        if (chart.eventlist != null)
        {
            eventList = chart.eventlist.ToList();
            eventList.Sort((event1, event2) => event1.starttime.CompareTo(event2.lasttime));
            eventList.Sort((event1, event2) => event1.starttime.CompareTo(event2.starttime));
            chart.eventlist = eventList.ToArray();
        }

        for (int i = 0; i < chart.eventlist.Length; i++)
        {
            var events = chart.eventlist[i];
            events.st = events.starttime / 1000f;
            events.et = (events.starttime + events.lasttime) / 1000f;
            events.set = events.lasttime / 1000f;
        }

        ChartLoadOver.Invoke();

        isStart = !isStart;
    }

    void Update()
    {
        if (!isStart) return;


    }
}
