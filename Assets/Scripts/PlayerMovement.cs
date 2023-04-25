using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Velocidad de movimiento
    [SerializeField] private float jumpForce = 5f; // Fuerza del salto
    [SerializeField] private float groundDistance = 0.2f; // Distancia al suelo
    [SerializeField] private LayerMask groundMask; // Capa del suelo

    private Rigidbody rb;
    private bool isGrounded;

    public float moveSpeed = 10.0f;
    public float sensitivity = 0.1f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Mover el personaje
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;
        rb.MovePosition(transform.position + moveDir * speed * Time.deltaTime);

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        yaw += horizontal * sensitivity;
        pitch -= vertical * sensitivity;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        float forward = Input.GetAxis("Vertical");
        float sideways = Input.GetAxis("Horizontal");

        Vector3 direction = (transform.forward * forward) + (transform.right * sideways);
        direction.y = 0f;

        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        // Comprobar si el personaje está en el suelo
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
    }
}