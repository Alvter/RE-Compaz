using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadChart;
using static Updater;

public class HitAudioPlayer : MonoBehaviour
{
    public AudioSource tap;
    public AudioSource flick;
    public AudioSource drag;

    public bool isStart = false;
    public void ScriptStart()
    {
        isStart = !isStart;
    }

    void Update()
    {
        if (!isStart) return;

        for (int i = 0; i < chart.notenum; i++)
        {
            var note = chart.notelist[i];
            if (realTime - note.starttime/1000f < 0 || note.isPlayAudio) continue;
            switch (note.type)
            {
                case 0:
                    tap.PlayOneShot(tap.clip);
                    break;
                case 1:
                    drag.PlayOneShot(drag.clip);
                    break;
                case 2:
                    flick.PlayOneShot(flick.clip);
                    break;
            }
            note.isPlayAudio = true;
        }
    }
}
