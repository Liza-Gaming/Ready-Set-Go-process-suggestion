using UnityEngine;
using UnityEngine.InputSystem;

public class BasketMover : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Control the player with defined keyboard buttons")]
    public InputAction PlayerControls;

    [SerializeField]
    [Tooltip("Movement speed in meters per second")]
    private float _speed = 5f;


    private Rigidbody rb;

    // Direction vector to apply movement.
    Vector3 moveDir = Vector3.zero;


    void OnEnable()
    {
        PlayerControls.Enable();
    }

    void OnDisable()
    {
        PlayerControls.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = PlayerControls.ReadValue<Vector2>();
        moveDir = new Vector3(inputVector.x, 0, 0); // Move only along X-axis
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * _speed; // 'speed' should be a predefined float value
    }

}