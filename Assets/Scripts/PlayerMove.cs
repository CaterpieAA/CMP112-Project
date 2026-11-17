using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public TextMeshProUGUI countText;

    public int score_count;

    public float speed = 5f;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private Animator animator;

    public InputAction jump;

    public float jumpForce = 5f;

    public bool isAiming;

    public rotator rotatorScript;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        animator = GetComponent<Animator>();
        SetCountText();
    }

    private void OnEnable()
    {
        jump.Enable();
    }


    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        isAiming = Input.GetMouseButton(1);

        if (moveDirection == Vector3.zero)
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

        if (isAiming)
        {

            Quaternion targetRotation = Quaternion.Euler(0, rotatorScript.turn.x, 0);

            rb.MoveRotation(targetRotation);
        }

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
                     

        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);

        if (!isAiming)
        {
            if (Input.GetKey(KeyCode.W))
            {
                float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
                angle = angle + orientation.eulerAngles.y - 90;
                Vector3 rotation = new Vector3(0, (angle - 0), 0);
                transform.eulerAngles = rotation;
            }
            if (Input.GetKey(KeyCode.S))
            {
                float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
                angle = angle + orientation.eulerAngles.y - 90;
                Vector3 rotation = new Vector3(0, (angle - 0), 0);
                transform.eulerAngles = rotation;
            }
            if (Input.GetKey(KeyCode.A))
            {
                float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
                angle = angle + orientation.eulerAngles.y - 90;
                Vector3 rotation = new Vector3(0, (angle - 180), 0);
                transform.eulerAngles = rotation;
            }
            if (Input.GetKey(KeyCode.D))
            {
                float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
                angle = angle + orientation.eulerAngles.y - 90;
                Vector3 rotation = new Vector3(0, (angle - 180), 0);
                transform.eulerAngles = rotation;
            }
        }

        

        //float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
        //Vector3 rotation = new Vector3(0, (angle - 270), 0);
        //transform.eulerAngles = rotation;
    }

    public void addScore(int n)
    {
        score_count+=n;
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Count: " + score_count.ToString();
    }
}

