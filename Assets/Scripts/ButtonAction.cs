using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] private string buttonName;
    [SerializeField] private UnityEvent onDown, onUp, onStay;


    void Update()
    {
        if (Input.GetButtonDown(buttonName)) onDown.Invoke();
        else if (Input.GetButtonUp(buttonName)) onUp.Invoke();
        else if (Input.GetButton(buttonName)) onUp.Invoke();
    }
}
