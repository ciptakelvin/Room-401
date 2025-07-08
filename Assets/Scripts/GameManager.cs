using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public Interactor interactor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactor.onInteractIn.AddListener(onInteractIn);
        interactor.onInteractOut.AddListener(onInteractOut);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onInteractIn()
    {
        Debug.Log("Interact In");
        uiManager.InteractIn();
    }

    void onInteractOut()
    {
        Debug.Log("Interact Out");
        uiManager.InteractOut();
    }
}
