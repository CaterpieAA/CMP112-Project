using UnityEngine;

public class Shooting : MonoBehaviour
{
    //gun stats

    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magzineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    private Animator animation;

    //bools

    bool shooting, readyToShoot, reloading;



    void Start()
    {
        animation = GetComponent<Animator>();
    }
    
    
    void FixedUpdate()
    {
        while (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animation.SetBool("isShooting", true);
        }
        
    }

}

