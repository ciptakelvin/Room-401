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
    private GameObject previousInteractable = null;

    void Start()
    {
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 8f))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                interactable = hit.collider.GetComponent<Interactable>();
                GameObject currentInteractable = hit.collider.gameObject;

                // Check if the previous hit is the same object
                if (currentInteractable != previousInteractable)
                {
                    // The object under the cursor has changed
                    previousInteractable = currentInteractable;
                    hasInteracted = false;
                }

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
                    previousInteractable = null;
                }
            }
        }
        else
        {
            if (hasInteracted)
            {
                onInteractOut.Invoke();
                interactable.InteractOut();
                hasInteracted = false;
                previousInteractable = null;
            }
        }
    }
}
