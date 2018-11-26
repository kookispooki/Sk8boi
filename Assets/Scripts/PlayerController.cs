using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IKillable
{
    public float groundSpeed;
    public float airSpeed;
    public float jumpForce;

    private Vector3 startPos;

    private bool airSlideReady = true;
    private bool inAirSlide = false;
    private float airSlideEnd;
    public float airSlideDuration;

    public float maxBoostVelocity; //Andel av bashastigheten som läggs till med maxBoost
    public float maxVelocity;
    public float boost; //Boost i %
    public float boostIncreaseSpeed;
    public float boostDecaySpeed; //Hur snabbt boosten ändras PER SEK

    public Vector2 groundCheckOffset;
    public float groundCheckLength;

    public Text boostText; //TEMPORARY

    public Rigidbody2D rb;

    private ParticleSystem.MainModule fireParticle;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        fireParticle = transform.Find("FireParticle").GetComponent<ParticleSystem>().main;
    }

    void Update()
    {
        if (isGrounded())
        {
            Debug.Log("grounded");
            airSlideReady = true;
            inAirSlide = false;
        }

        if (Input.GetButtonDown("Jump")) { Jump(); }

        if(Input.GetAxis("Horizontal") > 0) {
            boost += boostIncreaseSpeed * Time.deltaTime;
        } else {
            boost -= boostDecaySpeed * Time.deltaTime;
        }

        if(boost > 100) { boost = 100; }
        if (boost < 0) { boost = 0; }

        boostText.text = boost.ToString();

        float fireAlpha = boost / 100;
        fireParticle.startColor = new Color(fireParticle.startColor.color.r, fireParticle.startColor.color.g, fireParticle.startColor.color.b, fireAlpha);
    }

    void FixedUpdate()
    {
        Vector2 moveForce;
        if (isGrounded())
        {
            moveForce = new Vector2(Input.GetAxis("Horizontal") * groundSpeed, 0);
        } else
        {
            moveForce = new Vector2(Input.GetAxis("Horizontal") * airSpeed, 0);
        }
        rb.AddForce(moveForce);

        float addedMaxVelocity = maxVelocity + (maxBoostVelocity * boost/100);
        if (rb.velocity.x >= addedMaxVelocity) { rb.velocity = new Vector2(addedMaxVelocity, rb.velocity.y); }
        if (rb.velocity.x <= -addedMaxVelocity) { rb.velocity = new Vector2(-addedMaxVelocity, rb.velocity.y); }

        if(inAirSlide && Time.time < airSlideEnd) { rb.velocity = new Vector2(rb.velocity.x, 0); }
        else if (inAirSlide) { inAirSlide = false; }
    }

    void Jump()
    {
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce));
        } else if (airSlideReady)
        {
            inAirSlide = true;
            airSlideEnd = Time.time + airSlideDuration;
            airSlideReady = false;
        }
    }

    public bool isGrounded()
    {
        return Physics2D.Raycast((new Vector2(transform.position.x, transform.position.y) + groundCheckOffset), new Vector2(0, -1), groundCheckLength);
    }

    public void Death()
    {
        transform.position = startPos;
        rb.velocity = Vector2.zero;
        boost = 0;
    }
}
