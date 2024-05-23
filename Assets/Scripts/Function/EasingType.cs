using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EasingType : MonoBehaviour
{
    public static float Curve(int id, float x)
    {
        return id switch
        {
            0 => LineX(x),
            1 => InSine(x),
            2 => OutSine(x),
            _ => x,// 默认情况下返回 x
        };
    }

    public static float LineX(float x)
    {
        return x;
    }

    public static float InSine(float x)
    {
        return 1 - (float)Math.Cos((x * Math.PI) / 2);
    }

    public static float OutSine(float x)
    {
        return (float)Math.Sin((x * Math.PI) / 2);
    }
}
