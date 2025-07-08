using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public UIManager uiManager;
    Interactor interactor;

    //First Person Mode Component
    PlayerMovement firstPersonMovement;
    MouseLook mouseLook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactor = player.GetComponent<Interactor>();
        firstPersonMovement = player.GetComponent<PlayerMovement>();
        mouseLook = player.GetComponent<MouseLook>();

        interactor.onInteractIn.AddListener(onInteractIn);
        interactor.onInteractOut.AddListener(onInteractOut);
        interactor.onInteract.AddListener(onInteract);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void onInteract()
    {
        SetDialogueMode();
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

    void ResetMode()
    {
        firstPersonMovement.enabled = false;
        mouseLook.enabled = false;
    }
    public void SetFirstPersonMode()
    {
        ResetMode();
        Debug.Log("Setting First Person Mode");
        uiManager.Show();
        uiManager.InteractIn();
        firstPersonMovement.enabled = true;
        mouseLook.enabled = true;
    }

    public void SetDialogueMode()
    {
        ResetMode();
        uiManager.Hide();
        uiManager.InteractOut();
    }

    public void SetFixedMode()
    {
        ResetMode();
        firstPersonMovement.enabled = false;
        mouseLook.enabled = true;
    }
}
