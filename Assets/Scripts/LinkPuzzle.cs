using UnityEngine;
using UnityEngine.Events;

public class LinkPuzzle : MonoBehaviour
{
    public UnityEvent Finished;
    public LinkRotator[] linkRotator;
    int count = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (LinkRotator l in linkRotator)
        {
            l.OnRotate.AddListener(OnRotate);
        }

    }
    void OnRotate()
    {
        count = 0;
        foreach(LinkRotator l in linkRotator)
        {
            if(l.IsCorrect())
            {
                count++;
                if (count == linkRotator.Length)
                {
                    Finished.Invoke();
                }
            }
        }
    }

    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
