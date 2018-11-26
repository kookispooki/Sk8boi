using UnityEngine;

public class CameraShake : MonoBehaviour {

    public Vector2 shakeAmplitude;
    public Vector2 shakeSpeed;
    public float shakeAmount;

	void Start () {
		
	}
	
	void Update () {
        Vector3 cameraPos = new Vector3(
            Mathf.Sin(Time.time * shakeSpeed.x) * shakeAmplitude.x * shakeAmount,
            Mathf.Sin(Time.time * shakeSpeed.y) * shakeAmplitude.y * shakeAmount,
            -10);
        Camera.main.transform.localPosition = cameraPos;
    }
}
