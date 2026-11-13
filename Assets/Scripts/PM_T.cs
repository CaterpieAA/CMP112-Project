
using UnityEngine;
using UnityEngine.InputSystem;

public class PM_T : MonoBehaviour
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

    private void OnDisable()
    {
        jump.Disable();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horizontalInput) < 0.01f &&
            Mathf.Abs(verticalInput) < 0.01f)
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
        MovePlayer();

        if (jump.WasPressedThisFrame())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void MovePlayer()
    {
        // Get camera directions
        Vector3 forward = orientation.forward;
        Vector3 right = orientation.right;

        // Ignore vertical direction
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calculate movement direction
        moveDirection = forward * verticalInput
                      + right * horizontalInput;

        // Prevent faster diagonal movement
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        // Move player
        rb.AddForce(moveDirection * speed, ForceMode.Force);

        // Rotate player towards movement direction
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(moveDirection);

            rb.MoveRotation(targetRotation);
        }
    }
}
