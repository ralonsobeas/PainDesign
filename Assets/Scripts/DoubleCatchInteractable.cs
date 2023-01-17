using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCatchInteractable : Interactable
{
    private Transform target1, target2;
    private Vector3 positionOffset = Vector3.zero;
    private Vector3 rotationVector = Vector3.zero;
    private Rigidbody rb;
    private Collider _collider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (target1 == null || target2 == null) return;
        transform.position = positionOffset + target1.position + (target2.position - target1.position)/2f;
        rotationVector.y = target1.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    public override void Interact(Hand hand)
    {
        if (target1 == null)
        {
            target1 = hand.transform;
            rotationVector = transform.rotation.eulerAngles;
        }
        else if (target2 == null && hand.transform != target1)
        {
            target2 = hand.transform;
            positionOffset = transform.position - (target1.position + (target2.position - target1.position) / 2f);
            rotationVector = transform.rotation.eulerAngles;
            if (rb != null)
            {
                rb.isKinematic = true;
                _collider.isTrigger = true;
            }
        }
        else
        {
            if (hand.transform == target1) {
                target1 = target2;
                target2 = null;
            }
            else if (hand.transform == target2) target2 = null;
            if (rb != null && target1 == null && target2 == null)
            {
                rb.isKinematic = false;
                _collider.isTrigger = false;
            }
        }
    }

    public override bool Exit(Hand hand)
    {
        if (hand.transform == target1) target1 = null;
        else if (hand.transform == target2) target2 = null;
        return true;
    }
}
