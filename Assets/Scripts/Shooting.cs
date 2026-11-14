using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePosition;

    //gun stats

    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magzineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    private Animator animation;

    //bools

    bool shooting, readyToShoot, reloading;
    bool aiming = false;


    void Start()
    {
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (aiming==true)
            {
                aiming = false;
            }
            else
            {
                aiming = true;
            }
            AimAction();
        }
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(BulletPrefab, FirePosition.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
        }


        //if (Input.GetKey(KeyCode.Mouse1))
        //{
        //    animation.SetBool("isShooting", true);
        //}
        //else
        //{
        //    animation.SetBool("isShooting", false);
        //}

    }



    void FixedUpdate()
    {

        

    }   
    private void AimAction()
    {
        if (aiming==true)
        {
            animation.SetBool("isShooting", true);
        }
        else
        {
            animation.SetBool("isShooting", false);
        }
    }
}
    

