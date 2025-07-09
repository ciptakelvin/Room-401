using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public UIManager uiManager;
    public GameMode gameMode = GameMode.FirstPerson;
    public enum GameMode
    {
        FirstPerson,
        Dialogue,
        Fixed
    }
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

        SetGameMode();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetGameMode()
    {
        switch (gameMode)
        {
            case GameMode.FirstPerson:
                SetFirstPersonMode();
                break;
            case GameMode.Dialogue:
                SetDialogueMode();
                break;
            case GameMode.Fixed:
                SetFixedMode();
                break;
            default:
                break;
        }
    }
    void onInteract()
    {
        SetDialogueMode();
    }
    void onInteractIn()
    {
        uiManager.InteractIn();
    }

    void onInteractOut()
    {
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
        firstPersonMovement.enabled = true;
        mouseLook.enabled = true;
        uiManager.Show();
    }

    public void SetDialogueMode()
    {
        ResetMode();
        uiManager.Hide();
    }

    public void SetFixedMode()
    {
        ResetMode();
        firstPersonMovement.enabled = false;
        mouseLook.enabled = true;
    }

    public void OnStoryEnded()
    {
        SetGameMode();
        uiManager.Show();
    }
}
