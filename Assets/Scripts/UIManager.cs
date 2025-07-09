using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void InteractIn()
    {
        animator.SetBool("isActiveInteract", true);
    }
    public void InteractOut()
    {
        animator.SetBool("isActiveInteract", false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    { 
        gameObject.SetActive(true);
    }
}
