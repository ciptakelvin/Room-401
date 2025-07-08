using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public UnityEvent onInteractIn;
    public UnityEvent onInteractOut;

    RaycastHit hit;
    private bool hasInteracted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Ray dari kamera ke posisi kursor

        if (Physics.Raycast(ray, out hit, 1000f)) // max jarak 100 unit
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (!hasInteracted)
                {
                    onInteractIn.Invoke();
                    hasInteracted = true;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    interactable.Interact();
                }
            }
            else
            {
                if (hasInteracted)
                {
                    onInteractOut.Invoke();
                    hasInteracted = false;

                }
            }
        }
    }
}
