using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IKillable killable = collision.GetComponent<IKillable>();
        if (killable != null)
        {
            killable.Death();
        }
    }
}
