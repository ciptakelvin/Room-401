using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public UnityEvent OnInteract;
    public string interactableName;
    public TextMeshProUGUI description;
    public GameObject descriptionContainer;
    StoryManager storyManager;

    public int sceneToLoad = -1;

    public void Start()
    {
        description.text = "";
        storyManager = GetComponent<StoryManager>();
        storyManager.onStoryEnded.AddListener(onStoryEnded);
    }
    public void Interact()
    {
        if (sceneToLoad != -1)
        {
            SceneManager.LoadScene(sceneToLoad);
            return;
        }
        OnInteract.Invoke();
        description.text = "";
        descriptionContainer.SetActive(false);
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
        description.text = interactableName;
    }
}
