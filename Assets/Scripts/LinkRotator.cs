using UnityEngine;
using UnityEngine.Events;

public class LinkRotator : MonoBehaviour
{
    public UnityEvent OnRotate;

    public float correctRotation = 0.0f;

    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, 90));
        OnRotate.Invoke();
    }

    public bool IsCorrect()
    {
        if (correctRotation == -1)
        {
            if (transform.eulerAngles.z == 0 || transform.eulerAngles.z == 180)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (correctRotation == -2)
        {
            if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (transform.rotation.eulerAngles.z % 360 == correctRotation)
            return true;
        else
            return false;
    }
}
