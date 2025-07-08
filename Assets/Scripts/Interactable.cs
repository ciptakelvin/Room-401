using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void Interact()
    {
        Debug.Log("Interact");
        GetComponent<StoryManager>().StartDialogue();
    }
}
