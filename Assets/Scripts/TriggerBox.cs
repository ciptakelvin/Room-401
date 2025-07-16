using UnityEngine;
using UnityEngine.Events;

public class TriggerBox : MonoBehaviour
{
    public UnityEvent TriggerAction;
    public bool destroyAfterTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerAction.Invoke();
            if (destroyAfterTrigger)
            {
                Destroy(gameObject);
            }
        }
    }
}
