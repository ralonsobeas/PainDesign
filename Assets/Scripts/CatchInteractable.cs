using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchInteractable : Interactable
{
    private Transform baseParent;
    private Rigidbody rb;

    private void Awake()
    {
        baseParent = transform.parent;
        rb = GetComponent<Rigidbody>();
    }

    public override void Interact(Hand hand)
    {
        if (transform.parent == baseParent)
        {
            transform.SetParent(hand.transform);
            if (rb != null)
                rb.isKinematic = true;
        }
        else
        {
            transform.SetParent(baseParent);
            if (rb != null)
                rb.isKinematic = false;
        }
    }
}
