using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LoadChart;
using static Updater;

public class EventProcess : MonoBehaviour
{
    public bool isStart = false;

    public GameObject clock;
    public Text cover;
    public Transform rect;

    float posx = 0f;
    float posy = 0f;
    float size = 1f;
    float alpha = 1f;
    float rotate = 0f;

    float _posx = 0f;
    float _posy = 0f;
    float _size = 1f;
    float _alpha = 1f;
    float _rotate = 0f;

    public void ScriptStart()
    {
        rect = clock.transform;
        isStart = !isStart;
    }

    void Update()
    {
        if (!isStart) return;

        if (chart.eventlist == null) return;
        for (int i = 0; i < chart.eventlist.Length; i++)
        {
            var events = chart.eventlist[i];
            var type = events.movetype;
            if (events.isProcess) continue;

            float runTime = realTime - events.st;//运行时间
            float resTime = events.et - realTime;//剩余时间
            if (runTime < 0) continue;
            switch (events.type)
            {
                case 0:
                    if (events.lasttime == 0 && runTime > 0)
                    {
                        posx = events.param[0];
                        posy = events.param[1];
                        _posx = events.param[0];
                        _posy = events.param[1];
                        events.isProcess = true;
                    }
                    else if (runTime > 0 && resTime > 0)
                    {
                        posx = _posx + EasingType.Curve(events.movetype, ((float)runTime / events.set)) * (events.param[0] - _posx);
                        posy = _posy + EasingType.Curve(events.movetype, ((float)runTime / events.set)) * (events.param[1] - _posy);
                    }
                    else if (resTime < 0)
                    {
                        posx = events.param[0];
                        posy = events.param[1];
                        _posx = events.param[0];
                        _posy = events.param[1];
                        events.isProcess = true;
                    }
                    break;
                case 1:
                    if (events.lasttime == 0 && runTime > 0)
                    {
                        rotate = events.param[0];
                        _rotate = events.param[0];
                        events.isProcess = true;
                    }
                    else if (runTime > 0 && resTime > 0)
                    {
                        rotate = _rotate + EasingType.Curve(events.movetype, ((float)runTime / events.set)) * (events.param[0] - _rotate);
                    }
                    else if (resTime < 0)
                    {
                        rotate = events.param[0];
                        _rotate = events.param[0];
                        events.isProcess = true;
                    }
                    break;
                case 2:
                    if (events.lasttime == 0 && runTime > 0)
                    {
                        alpha = events.param[0];
                        _alpha = events.param[0];
                        events.isProcess = true;
                    }
                    else if (runTime > 0 && resTime > 0)
                    {
                        alpha = _alpha + EasingType.Curve(events.movetype, ((float)runTime / events.set)) * (events.param[0] - _alpha);
                    }
                    else if (resTime < 0)
                    {
                        alpha = events.param[0];
                        _alpha = events.param[0];
                        events.isProcess = true;
                    }
                    break;
                case 3:
                    if (events.lasttime == 0 && runTime > 0)
                    {
                        size = events.param[0];
                        _size = events.param[0];
                        events.isProcess = true;
                    }
                    else if (runTime > 0 && resTime > 0)
                    {
                        size = _size + EasingType.Curve(events.movetype, ((float)runTime / events.set)) * (events.param[0] - _size);
                    }
                    else if (resTime < 0)
                    {
                        size = events.param[0];
                        _size = events.param[0];
                        events.isProcess = true;
                    }
                    break;
                default:
                    break;
            }
        }
        rect.position = new Vector2(posx * sx, posy * sy);
        rect.eulerAngles = new Vector3(0, 0, rotate);
        cover.color = new Color(cover.color.r, cover.color.g, cover.color.b, 1 - alpha);
        rect.localScale = new Vector2(size, size);

    }
}
