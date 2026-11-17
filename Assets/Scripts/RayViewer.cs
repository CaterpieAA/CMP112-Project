using UnityEngine;

public class RayViewer : MonoBehaviour
{
    public float weaponRange = 50f;

    public Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lineOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrigin, cam.transform.forward * weaponRange, Color.green);
    }
}
