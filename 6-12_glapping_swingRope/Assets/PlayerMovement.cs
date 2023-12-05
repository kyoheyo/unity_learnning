using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public Camera mCam;
    public LayerMask whatIsJumpPosition;
    public Transform hitPoint;

    private float X;
    private float Y;
    private float fov;
    private Vector3 camForward;
    public bool isGround;
    public KeyCode JumpKey = KeyCode.Space;

    [Header("Input")]
    public float itsmass = 1.0f;
    public int jumpNumInAir = 1;
    public bool unlimitJump;
    public float itsGravity = -25f;
    public float moveSpeed = 5f;
    public float jumpSpeed = 10f;
    public float angleSpeed = 0.008f;
    public float fovSpeed = 10f;
    public float YMinLimit = -80f;
    public float YMaxLimit = 60f;
    public float hitDistance = 0.4f;

    void Start()
    {
        fov = 60f;

        rb.useGravity = false;
    }

    void Update()
    {
        Move();

        RotateWithMouse();

        CameraFov();
    }

    void FixedUpdate()
    {
        SetGravity(itsGravity);

        if(unlimitJump)
        {
            isGround = true;
        }
        else
        {
            if(Physics.Raycast(hitPoint.position, Vector3.down, hitDistance, whatIsJumpPosition))
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }
        }
        
    }

    void SetGravity(float gravity)
    {
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        camForward = Vector3.Cross(transform.right, Vector3.up);

        transform.Translate(transform.right * h * moveSpeed * Time.deltaTime + camForward * v * moveSpeed * Time.deltaTime, Space.World);
    
        
        if(isGround)
        {
            jumpNumInAir = 1;
            if(Input.GetKeyDown(JumpKey))
            {
                rb.velocity = new Vector3(0f, jumpSpeed, 0f);
            }
        }
        else
        {
            if(Input.GetKeyDown(JumpKey) & jumpNumInAir > 0)
            {
                jumpNumInAir -= 1;
                rb.velocity = new Vector3(0f, jumpSpeed, 0f);
            }
        }
    }

    void RotateWithMouse()
    {
        X += Input.GetAxis("Mouse X") * angleSpeed;
        Y -= Input.GetAxis("Mouse Y") * angleSpeed;
        Y = ClamAngle(Y, YMinLimit, YMaxLimit);

        transform.localEulerAngles = new Vector3(Y, X, 0);
    }

    void CameraFov()
    {
        fov += Input.GetAxis("Mouse ScrollWheel") * fovSpeed;

        mCam.fieldOfView = fov;
    }

    public void GrappleToPosition(Vector3 targetPosition, float trajectoryHeight)
    {
        rb.velocity = CalculateGrappleVelocity(transform.position, targetPosition, trajectoryHeight);
    }

    public Vector3 CalculateGrappleVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = itsGravity * itsmass;
        
        float displacementY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity) + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / gravity));

        return velocityXZ + velocityY;
    }

    public void MoveStopControl()
    {
        rb.velocity = Vector3.zero;
    }

    static float ClamAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if(angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
