using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StoryManager : MonoBehaviour
{
    public UnityEvent onStoryEnded;
    public GameObject canvas;
    public TextMeshProUGUI title;
    public TextMeshProUGUI body;

    public string[] dialogues; // Array to hold dialogue strings
    public AudioClip[] dialogueVO; // Array to hold audio clips for each dialogue
    public AudioClip[] dialogueEffect;

    public int currentDialogueIndex = 0; // Index to track the current dialogue

    public void StartDialogue()
    {
 
        if (currentDialogueIndex >= dialogues.Length)
        {
            canvas.SetActive(false);
            onStoryEnded.Invoke();
            Invoke("enableFP", 0.2f);
            return;
        }
        Debug.Log("Starting Dialogue");
        canvas.SetActive(true);
        string name = dialogues[currentDialogueIndex].Split(",")[0];
        string text = dialogues[currentDialogueIndex].Split(",")[1];

        title.text = name;
        body.text = text;

        currentDialogueIndex++;
    }

    void enableFP()
    {
        FindFirstObjectByType<GameManager>().OnStoryEnded();
        currentDialogueIndex = 0; // Reset the dialogue index for the next interaction
    }
}
