using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Movimiento del jugador
    public float speed = 10.0f;

    //Rotación del jugador
    public float cameraspeed = 10.0f;
    public float sensitivity = 1.0f;

    float horizontalRotation = 0.0f;


    void Update() {

        //Movimiento del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * speed);

        //Rotación del jugador
        float mouseX = Input.GetAxis("Mouse X");

        horizontalRotation += mouseX * sensitivity;

        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
    }

    /*void FixedUpdate() {

        //rotación del jugador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(movement * cameraspeed);
    }*/


}