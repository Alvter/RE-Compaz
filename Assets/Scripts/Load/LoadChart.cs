using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;

public class LoadChart : MonoBehaviour
{
    [System.Serializable]
    public class NoteList
    {
        public float starttime;
        public int type;
        public int trace;
        public int angle;
        public string id;
        public bool isPlayAudio;
    }

    [System.Serializable]
    public class EventList
    {
        public int starttime;
        public int lasttime;
        public int type;
        public int movetype;
        public int angle;
        public float[] param;

        public float st;
        public float et;
        public float set;
        public bool isProcess = false;
    }

    [System.Serializable]
    public class Chart
    {
        public string songwriter;
        public float bpm;
        public int notenum;
        public float songdelay;
        public float[] speed1;
        public float[] speed2;
        public NoteList[] notelist;
        public EventList[] eventlist;
    }

    public static string chartName = "disorder";
    public static string difficult = "sp";
    public static Chart chart;
    public TextAsset textAsset;
    public string json;
    public UnityEvent ChartLoadOver;
    public AudioSource music;
    public bool isOver = false;

    public static float sx = 270f;//x方向长度
    public static float sy = 180f;//y方向宽度

    void Awake()
    {
        textAsset = Resources.Load<TextAsset>("Chart/" + chartName + "/" + chartName + "_" + difficult);
        json = textAsset.text;
        chart = JsonUtility.FromJson<Chart>(json);

        music.clip = Resources.Load<AudioClip>("Chart/" + chartName + "/" + chartName);

        Application.targetFrameRate = 250;
    }

    void Update()
    {
        if (chart != null && !isOver)
        {
            isOver = true;
            ChartLoadOver.Invoke();
        }
    }

}
