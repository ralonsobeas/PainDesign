using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Interactable buffer;
    [SerializeField] private string interactButton;
    private bool free = true;

    private void Update()
    {
        if (buffer != null && Input.GetButtonDown(interactButton))
            buffer.Interact(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!free && buffer.gameObject != other.gameObject) return;
        Interactable interactable= other.GetComponent<Interactable>();
        if (interactable == null) return;
        buffer = interactable;
    }
    private void OnTriggerExit(Collider other)
    {
        if (!free && !buffer.Exit(this))
            return;
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable == null) return;
        buffer = null;
    }
}
