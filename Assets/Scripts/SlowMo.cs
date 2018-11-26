using UnityEngine;
using UnityEngine.Audio;

public class SlowMo : MonoBehaviour
{
    public float effect;
    CameraShake camShake;
    GameObject musicObject;
    AudioReverbFilter reverb;
    AudioLowPassFilter lowPass;

    private void Start()
    {
        camShake = Camera.main.gameObject.GetComponent<CameraShake>();
        musicObject = transform.Find("Music").gameObject;
        reverb = musicObject.GetComponent<AudioReverbFilter>();
        lowPass = musicObject.GetComponent<AudioLowPassFilter>();
    }

    void Update()
    {
        Time.timeScale = 1 - (effect * 0.5f);
        if (reverb != null) { reverb.room = -1000 + (1000 * effect); }
        if (lowPass != null) { lowPass.cutoffFrequency = 12000 - (10600 * effect); }
        if(camShake != null) { camShake.shakeAmount = effect; }

        //TEMPORARY
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Animator>().SetTrigger("EffectTrigger");
        }
    }
}
