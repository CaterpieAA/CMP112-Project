using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePosition;
    public Camera cam;
    //private LineRenderer laserLine;

    //gun stats

    public float weaponRange = 500f;
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
        //laserLine = GetComponent<LineRenderer>();
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
            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Vector3 ray;
            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, weaponRange)&& !hit.collider.CompareTag("Player"))
            {
                ray = hit.point;
            }
            else
            {
                ray = rayOrigin + (cam.transform.forward * weaponRange);
            }
            Vector3 direction = (ray - FirePosition.position).normalized;

            GameObject bullet = Instantiate(BulletPrefab, FirePosition.position, Quaternion.LookRotation(direction));
            bullet.GetComponent<Bullet>().SetPM(GetComponent<PlayerMove>());
            bullet.GetComponent<Rigidbody>().AddForce(direction * 10000);

            //Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            //RaycastHit hit;
            
            //laserLine.SetPosition(0, FirePosition.position);
            //if(Physics.Raycast(rayOrigin,cam.transform.forward,out hit, weaponRange))
            //{
            //    laserLine.SetPosition(1, hit.point);
            //}
            //else
            //{
            //    laserLine.SetPosition(1, rayOrigin + (cam.transform.forward * weaponRange));
            //}
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
    

