using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIVRButton : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private Color hoverColor;
    private Color baseColor;
    [SerializeField] private UnityEvent onClick;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        baseColor = text.color;
    }
    public void Hover()
    {
        text.color = hoverColor;
    }
    public void UnHover()
    {
        text.color = baseColor;
    }
    public void Click()
    {
        Debug.Log("Sa pulsao" + name);
        onClick.Invoke();
    }
}
