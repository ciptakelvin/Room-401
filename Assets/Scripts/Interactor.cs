using UnityEngine;

public class Interactor : MonoBehaviour
{
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
                if (!hasInteracted)
                {
                    Debug.Log("Look At");
                    hasInteracted = true;
                }
            }
            else
            {
                hasInteracted = false;
            }
        }
    }
}
