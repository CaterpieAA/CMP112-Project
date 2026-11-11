using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        // Vector3 moveVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //rb.AddForce(moveVector * speed);

        MovePlayer();

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);

        float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
        Vector3 rotation = new Vector3(0, angle, 0);
        transform.eulerAngles = rotation;
    }
}

