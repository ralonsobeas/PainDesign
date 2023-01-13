using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchInteractable : Interactable
{
    private Transform baseParent;

    private void Awake()
    {
        baseParent = transform.parent;
    }

    public override void Interact(Hand hand)
    {
        if (transform.parent == baseParent)
            transform.SetParent(hand.transform);
        else
            transform.SetParent(baseParent);
    }
}
