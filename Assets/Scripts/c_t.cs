using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_t : MonoBehaviour
{
    public Transform camTarget;

    void Update()
    {
        transform.position = camTarget.position;
        transform.rotation = camTarget.rotation;
    }
}
