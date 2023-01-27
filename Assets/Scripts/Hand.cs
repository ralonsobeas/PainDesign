using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Interactable buffer;
    private Interactable cached;
    [SerializeField] private string interactButton;

    private void Update()
    {
        if (!Input.GetButtonDown(interactButton)) return;

        if (cached != null)
        {
            if (!cached.Interact(this)) cached = null;
        }
        else if (buffer != null && buffer.Interact(this)) cached = buffer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (cached != null) return;
        Interactable interactable= other.GetComponent<Interactable>();
        Debug.Log(other.name);
        if (interactable == null) return;
        buffer = interactable;
    }
    private void OnTriggerExit(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable == null) return;
        if (buffer == interactable) buffer = null;
        if (cached == interactable && interactable.Exit(this)) cached = null;
    }
}
