using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    private PlayerMove playerMove_Script;

    public void SetPM(PlayerMove p)
    {
        playerMove_Script = p;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            other.gameObject.SetActive(false);
            playerMove_Script.addScore(1);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            playerMove_Script.addScore(2);
        }
        Destroy(gameObject);
    }

}
