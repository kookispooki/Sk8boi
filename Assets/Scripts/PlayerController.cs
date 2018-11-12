using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float groundSpeed;
    public float airSpeed;

    public float maxBoost; //Andel av bashastigheten som läggs till med maxBoost
    private float boost; //Hur mycket boost man har
    public float boostDecaySpeed; //Hur snabbt boosten ändras

    Rigidbody2D rb;

    void Start()
    {

    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0f));
    }
}
