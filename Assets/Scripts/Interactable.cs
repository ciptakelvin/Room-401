using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public string interactableName;
    public TextMeshProUGUI description;
    public GameObject descriptionContainer;
    StoryManager storyManager;

    public int sceneToLoad = -1;

    public void Start()
    {
        description.text = "";
    }
    public void Interact()
    {
        if (sceneToLoad != -1)
        {
            SceneManager.LoadScene(sceneToLoad);
            return;
        }
        Debug.Log("Interact");
        storyManager = GetComponent<StoryManager>();
        storyManager.StartDialogue();
        storyManager.onStoryEnded.AddListener(onStoryEnded);
        description.text = "";
    }
    public void InteractIn()
    {
        description.text = interactableName;
        descriptionContainer.SetActive(true);
    }
    public void InteractOut()
    {
        description.text = "";
        descriptionContainer.SetActive(false);
    }

    public void onStoryEnded()
    {
        description.text = "interactableName";
    }
}
