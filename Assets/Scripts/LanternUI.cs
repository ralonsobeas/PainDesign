using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternUI : MonoBehaviour
{
    private UIVRButton buffer;
    [SerializeField] private string selectButton;
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.up,out hit, 10, 1 << 7))
        {
            UIVRButton button = hit.collider.GetComponent<UIVRButton>();
            if (button != null)
            {
                Debug.Log(button.name);
                if (buffer != null && buffer != button)
                {
                    buffer.UnHover();
                    buffer = null;
                    button.Hover();
                }
                if (buffer == null)
                {
                    buffer = button;
                    button.Hover();
                }
            }else if (buffer != null)
            {
                buffer.UnHover();
                buffer = null;
            }
        }else if (buffer != null)
        {
            buffer.UnHover();
            buffer = null;
        }
        if (buffer != null && Input.GetButtonDown(selectButton))
            buffer.Click();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * 10);
    }
}
