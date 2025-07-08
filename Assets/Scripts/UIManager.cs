using UnityEngine;

public class UIManager : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void InteractIn()
    {
        animator.SetTrigger("interactIn");
    }
    public void InteractOut()
    {
        animator.SetTrigger("interactOut");
    }
}
