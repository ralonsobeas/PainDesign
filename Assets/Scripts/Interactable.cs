using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact(Hand hand);
    public abstract bool Exit(Hand hand);
}
