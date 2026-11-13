using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private Animator animator;

    public InputAction jump;

    public float jumpForce = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        jump.Enable();
    }


    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(moveDirection == Vector3.zero)
        {
            animator.SetFloat("speed", 0);
        }
        else
        {
            animator.SetFloat("speed", 1);
        }
    }
    private void FixedUpdate()
    {

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        // Vector3 moveVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //rb.AddForce(moveVector * speed);

        MovePlayer();

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
                     

        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);

        if (Input.GetKey(KeyCode.W))
        {
            float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
            Vector3 rotation = new Vector3(0, (angle - 0), 0);
            //transform.eulerAngles = rotation;
        }
        if (Input.GetKey(KeyCode.S))
        {
            float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
            Vector3 rotation = new Vector3(0, (angle - 0), 0);
            //transform.eulerAngles = rotation;
        }
        if (Input.GetKey(KeyCode.A))
        {
            float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
            Vector3 rotation = new Vector3(0, (angle - 180), 0);
            //transform.eulerAngles = rotation;
        }
        if (Input.GetKey(KeyCode.D))
        {
            float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
            Vector3 rotation = new Vector3(0, (angle - 180), 0);
            //transform.eulerAngles = rotation;
        }

        //float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
        //Vector3 rotation = new Vector3(0, (angle - 270), 0);
        //transform.eulerAngles = rotation;
    }
}

