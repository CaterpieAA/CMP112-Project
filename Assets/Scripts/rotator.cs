using UnityEngine.InputSystem;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Transform player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        turn.y += mouseDelta.y * sensitivity;
        turn.x += mouseDelta.x * sensitivity;

        Quaternion targetRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        transform.localRotation = Quaternion.Inverse(player.rotation) * targetRotation;
    }
}