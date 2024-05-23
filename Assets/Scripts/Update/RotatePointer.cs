using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Updater;
using static LoadChart;

public class RotatePointer : MonoBehaviour
{
    public bool isStart = false;
    public int beat = 0;
    public int lastBeat = 0;
    public float bpm;
    public float[] rotation = new float[2] { 0, 0 };
    public float rotate = 0;
    public AudioSource tap;
    public AudioSource music;

    public GameObject pointer_long;
    public GameObject pointer_short;

    public GameObject clock;

    public void ScriptStart()
    {
        isStart = !isStart;
        bpm = chart.bpm;
    }

    void Update()
    {
        if (!isStart || realTime < 0) return;
        
        if (realTime > (beat + 1) * (240 / bpm))
        {
            beat++;
        }
        if (beat == chart.speed1.Length - 1) gameObject.SetActive(false);
        if (beat > lastBeat)
        {
            rotation[0] += 360f * chart.speed1[lastBeat] / (bpm * 1.5f);
            rotation[1] += 360f * chart.speed2[lastBeat] / (bpm * 1.5f);
            lastBeat = beat;
        }

        float rotationAngle = rotation[0] - (realTime - (beat) * (240f / bpm)) / (240f / bpm) * (-360f * chart.speed1[beat] / (bpm * 1.5f));
        // 获取父对象的当前Z轴旋转角度
        float parentZRotation = transform.parent.rotation.eulerAngles.z;
        // 计算最终的Z轴旋转角度
        float finalZRotation = parentZRotation + rotationAngle;
        pointer_long.transform.localRotation = Quaternion.Euler(0, 0, finalZRotation);

        rotationAngle = rotation[1] - (realTime - (beat) * (240f / bpm)) / (240f / bpm) * (-360f * chart.speed2[beat] / (bpm * 1.5f));
        // 获取父对象的当前Z轴旋转角度
        parentZRotation = transform.parent.rotation.eulerAngles.z;
        // 计算最终的Z轴旋转角度
        finalZRotation = parentZRotation + rotationAngle;
        pointer_short.transform.localRotation = Quaternion.Euler(0, 0, finalZRotation);

        //pointer_long.transform.eulerAngles = new Vector3(0, 0, rotation[0] - (realTime - (beat) * (240f / bpm)) / (240f / bpm) * (-360f * chart.speed1[beat] / (bpm * 1.5f)));
        //pointer_short.transform.eulerAngles = new Vector3(0, 0, rotation[1] - (realTime - (beat) * (240f / bpm)) / (240f / bpm) * (-360f * chart.speed2[beat] / (bpm * 1.5f)));
    }
}
