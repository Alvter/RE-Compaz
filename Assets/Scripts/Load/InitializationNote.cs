using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadChart;

public class InitializationNote : MonoBehaviour
{
    public bool isStart = false;

    public GameObject WaitClock;

    //note‘§÷∆ÃÂ
    public GameObject Tap;
    public GameObject Flick;
    public GameObject Drag;

    public void ScriptStart()
    {
        for (int i = 0; i < chart.notenum; i++)
        {
            if (chart.notelist[i].trace == 0)
            {
                switch (chart.notelist[i].type)
                {
                    case 0:
                        GameObject tap = Instantiate(Tap, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f,90 + chart.notelist[i].angle), WaitClock.transform.GetChild(0));
                        tap.transform.GetChild(0).localPosition = new Vector2(120,0);
                        break;
                    case 1:
                        GameObject drag = Instantiate(Drag, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 90 + chart.notelist[i].angle), WaitClock.transform.GetChild(0));
                        drag.transform.GetChild(0).localPosition = new Vector2(120, 0);
                        break;
                    case 2:
                        GameObject flick = Instantiate(Flick, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 90 + chart.notelist[i].angle), WaitClock.transform.GetChild(0));
                        flick.transform.GetChild(0).localPosition = new Vector2(120, 0);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (chart.notelist[i].type)
                {
                    case 0:
                        GameObject tap = Instantiate(Tap, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 90 + chart.notelist[i].angle), WaitClock.transform.GetChild(1));
                        tap.transform.GetChild(0).localPosition = new Vector2(45, 0);
                        break;
                    case 1:
                        GameObject drag = Instantiate(Drag, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 90 + chart.notelist[i].angle), WaitClock.transform.GetChild(1));
                        drag.transform.GetChild(0).localPosition = new Vector2(45, 0);
                        break;
                    case 2:
                        GameObject flick = Instantiate(Flick, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 90 + chart.notelist[i].angle), WaitClock.transform.GetChild(1));
                        flick.transform.GetChild(0).localPosition = new Vector2(45, 0);
                        break;
                    default:
                        break;
                }
            }
        }

        isStart = !isStart;
    }

    void Update()
    {
        if (!isStart) return;

        
    }
}
