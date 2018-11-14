using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 playerOffset;
    GameObject player;

    public float smoothTime;
    private Vector3 currentSmoothVel;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerOffset = transform.position - player.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPos = Vector3.SmoothDamp(transform.position, player.transform.position + playerOffset, ref currentSmoothVel, smoothTime);
        transform.position = targetPos;
    }
}
