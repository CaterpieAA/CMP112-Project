using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    void Update()
    {
        Vector2 mouseDelta=Mouse.current.delta.ReadValue();

        turn.y += mouseDelta.y * sensitivity;
        turn.x += mouseDelta.x * sensitivity;
        transform.localRotation=Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
