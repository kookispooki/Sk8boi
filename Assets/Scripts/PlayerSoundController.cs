using UnityEngine;
using UnityEngine.Audio;

public class PlayerSoundController : MonoBehaviour
{
    PlayerController playerController;
    AudioSource[] audioSources;
    //0 - roll
    //1 - pop
    //2 - land

    bool groundedLastFrame = false;


    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    void Update()
    {
        if(playerController != null)
        {
            float xVel = playerController.rb.velocity.x;

            if (playerController.isGrounded() && !audioSources[0].isPlaying)
            {
                audioSources[0].Play();
            } else if (!playerController.isGrounded() && audioSources[0].isPlaying)
            {
                audioSources[0].Stop();
            }
            if(Mathf.Abs(xVel) >= 5f) { audioSources[0].volume = 1; }
            else
            {
                audioSources[0].volume = Mathf.Abs(xVel) / 5;
            }

            if (!playerController.isGrounded() && groundedLastFrame)
            {
                audioSources[1].Play();
            }

            if (playerController.isGrounded() && !groundedLastFrame)
            {
                audioSources[2].Play();
            }

            groundedLastFrame = playerController.isGrounded();
        }
    }
}
