using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Target"))
        {
            other.gameObject.SetActive(false);
        }
        Destroy(gameObject);
    }
}
