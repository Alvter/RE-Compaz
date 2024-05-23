using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapper : MonoBehaviour
{
    float time = 0f;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1f) gameObject.SetActive(false);
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) return;
        Color color = spriteRenderer.color;
        spriteRenderer.color = new Color(color.r, color.g, color.b,time);
        gameObject.transform.localScale = new Vector2(time, time);
    }
}
