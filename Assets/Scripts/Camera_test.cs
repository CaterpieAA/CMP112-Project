using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test : MonoBehaviour
{
    public Transform camTarget;
    public float pLerp = .02f;
    public float rLerp = .01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camTarget.position;
        transform.rotation = camTarget.rotation;
    }
}
