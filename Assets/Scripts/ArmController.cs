using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    [SerializeField] private string buttonName;
    [SerializeField] private bool invertButton = false;
    //[SerializeField] private Transform transform;
    [SerializeField] private float maxAngleX = 45f, maxAngleY = 45f;
    [SerializeField] private bool redirectOverflowAngleX = false;
    [SerializeField] private Transform baseTransform;
    private float angleOffsetX, angleOffsetY;

    private void Awake()
    {
        if (baseTransform == null) baseTransform = transform.parent;
        angleOffsetX = transform.rotation.eulerAngles.x;
        angleOffsetY = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Precondición: Que esté pulsando (o que no si el botón está invertido)
        if (!(invertButton ^ Input.GetButton(buttonName))) return;

        float x = transform.rotation.eulerAngles.x - Input.GetAxis("Mouse Y");
        float y = transform.rotation.eulerAngles.y + Input.GetAxis("Mouse X");

        // Comprobar que no se pasen de ángulo autorizado
        //Debug.Log(Mathf.DeltaAngle(baseTransform.eulerAngles.x, x + angleOffsetX));
        bool canX = Mathf.Abs(Mathf.DeltaAngle(baseTransform.eulerAngles.x, x - angleOffsetX)) < maxAngleX;
        bool canY = Mathf.Abs(Mathf.DeltaAngle(baseTransform.eulerAngles.y, y - angleOffsetY)) < maxAngleY;

        // Rotar
        transform.rotation = Quaternion.Euler(
            canX ? x : transform.rotation.eulerAngles.x,
            canY ? y : transform.rotation.eulerAngles.y,
            transform.rotation.eulerAngles.z
        );

        // Precondición para segunda parte: Que no se quiera rotar un padre
        // cuando no se ha podido girar por exceso de ángulo
        if (!redirectOverflowAngleX) return;

        y = baseTransform.rotation.eulerAngles.y + Input.GetAxis("Mouse X");

        // Rotar padre
        baseTransform.rotation = Quaternion.Euler(
            baseTransform.rotation.eulerAngles.x,
            !canY ? y : baseTransform.rotation.eulerAngles.y,
            baseTransform.rotation.eulerAngles.z
        );

    }
}
