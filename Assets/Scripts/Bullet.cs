using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    private PlayerMove playerMove;

    public void SetPM(PlayerMove p)
    {
        playerMove = p;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Target"))
        {
            other.gameObject.SetActive(false);
            playerMove.addScore();
        }
        Destroy(gameObject);
    }

}
