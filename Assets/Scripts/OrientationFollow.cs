using UnityEngine;

public class OrientationFollow : MonoBehaviour
{
    public Transform cameraTarget;

    void LateUpdate()
    {
        Vector3 direction = cameraTarget.forward;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}