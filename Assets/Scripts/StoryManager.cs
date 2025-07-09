using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public UnityEvent onStoryEnded;
    public GameObject canvas;
    public RawImage character;
    public TextMeshProUGUI title;
    public TextMeshProUGUI body;
    public GameObject flash;

    public string[] dialogues; // Array to hold dialogue strings
    public Texture[] characters;
    public AudioClip[] dialogueVO; // Array to hold audio clips for each dialogue
    public string[] dialogueEffect; //normal,flash,shake

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
        Texture characterTexture = characters[currentDialogueIndex];
        string effect = dialogueEffect[currentDialogueIndex];

        title.text = name;
        body.text = text;
        character.texture = characterTexture;

        switch(effect)
        {
            case "flash":
                flash.SetActive(true);
                break;
            default:
                flash.SetActive(false);
                break;
        }

        currentDialogueIndex++;
    }

    void enableFP()
    {
        FindFirstObjectByType<GameManager>().OnStoryEnded();
        currentDialogueIndex = 0; // Reset the dialogue index for the next interaction
    }
}
