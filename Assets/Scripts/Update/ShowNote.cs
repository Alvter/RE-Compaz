using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadChart;
using static Updater;

public class ShowNote : MonoBehaviour
{
    public bool isStart = false;

    public int index = 0;

    public RectTransform RealClock;
    public RectTransform WaitClock;

    public void ScriptStart()
    {
        isStart = !isStart;
    }

    void Update()
    {
        if (!isStart) return;

        NoteList note = chart.notelist[index];
        if (note.starttime / 1000f - realTime > 1f) return;
        WaitClock.GetChild(note.trace).GetChild(0).GetChild(0).gameObject.AddComponent<Disapper>();
        WaitClock.GetChild(note.trace).GetChild(0).parent = RealClock.GetChild(note.trace);
        if (index == chart.notelist.Length - 1) gameObject.SetActive(false);
        index++;
    }
}
