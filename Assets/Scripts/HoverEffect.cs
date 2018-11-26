using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public float amplitude;
    public float speed;
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float relativeTime = Time.time - startTime;
        float yPos = Mathf.Sin(relativeTime * speed) * amplitude;
        transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
    }
}
