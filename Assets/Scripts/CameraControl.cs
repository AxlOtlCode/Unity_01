using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float sensitivity = 1.0f;
    public float maxVerticalAngle = 80f;
    public float minVerticalAngle = -80f;

    private float currentRotationX = 0f;

    void Update() {
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        currentRotationX += mouseY;
        currentRotationX = Mathf.Clamp(currentRotationX, minVerticalAngle, maxVerticalAngle);

        transform.localEulerAngles = new Vector3(-currentRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}