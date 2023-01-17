using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchInteractable : Interactable
{
    private Transform target;
    private Vector3 positionOffset = Vector3.zero;
    private Vector3 rotationVector = Vector3.zero;
    private Rigidbody rb;
    private Collider collider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (target == null) return;

        transform.position = target.position + positionOffset;
        rotationVector.y = target.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    public override void Interact(Hand hand)
    {
        if (target == null)
        {
            target = hand.transform;
            //positionOffset = transform.position - hand.transform.position;
            rotationVector = transform.rotation.eulerAngles;
            if (rb != null)
            {
                rb.isKinematic = true;
                collider.isTrigger = true;
            }
        }
        else if (hand.transform == target)
        {
            target = null;
            if (rb != null)
            {
                rb.isKinematic = false;
                collider.isTrigger = false;
            }
        }
    }

    public override bool Exit(Hand hand)
    {
        return false;
    }
}
