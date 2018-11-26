using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;

    void Start()
    {
    }

    void Update()
    {
        transform.localPosition = new Vector3(Camera.main.transform.position.x * -speed, transform.localPosition.y, transform.localPosition.z);
    }
}
