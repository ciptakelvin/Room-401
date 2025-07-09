using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public UnityEvent onInteractIn;
    public UnityEvent onInteractOut;
    public UnityEvent onInteract;

    RaycastHit hit;
    private bool hasInteracted = false;
    Interactable interactable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Ray dari kamera ke posisi kursor

        if (Physics.Raycast(ray, out hit, 25f)) // max jarak 10 unit
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                interactable = hit.collider.GetComponent<Interactable>();
                if (!hasInteracted)
                {
                    onInteractIn.Invoke();
                    interactable.InteractIn();
                    hasInteracted = true;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    interactable.Interact();
                    onInteract.Invoke();
                }
            }
            else
            {
                if (hasInteracted)
                {
                    onInteractOut.Invoke();
                    interactable.InteractOut();
                    hasInteracted = false;

                }
            }
        }
    }
}
