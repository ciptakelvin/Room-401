using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform cameraT;
    public bool isClampX = true;
    public bool isClampY = true;

    float mouseSensitivity = 1000f;
    float rotationX = 0f;
    float rotationY = 0f;


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
        if (isClampX)
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        rotationY += MouseX;
        if (isClampY)
            rotationY = Mathf.Clamp(rotationY, -35f, 35f);

        //cameraT.Rotate(Vector3.left * MouseX);
        cameraT.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, rotationY, 0f);
        //transform.Rotate(Vector3.up * MouseX);
    }
}
