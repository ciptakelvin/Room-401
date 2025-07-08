using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform cameraT;
    float mouseSensitivity = 1000f;
    float rotationX = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= MouseY;
        rotationX = Mathf.Clamp(rotationX, -35f, 35f);

        cameraT.Rotate(Vector3.left * MouseX);
        cameraT.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        transform.Rotate(Vector3.up * MouseX);
    }
}
