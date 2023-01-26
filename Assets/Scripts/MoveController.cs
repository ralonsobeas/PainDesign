using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveController : MonoBehaviour
{
    private CharacterController characterController;
    private Transform cam;
    private Vector3 movement = Vector3.zero;

    [SerializeField] private float speed = 3f, runSpeed = 7f;
    [SerializeField] private string runButtonName;
    [SerializeField] private Transform height, maxHeight, minHeight;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        movement = cam.TransformDirection(movement);
        movement.y = 0f;
        
        if (Input.GetButtonDown("Crawl"))
        {
            height.position = minHeight.position;
        }else if (Input.GetButtonUp("Crawl"))
        {
            height.position = maxHeight.position;
        }

        characterController.Move(movement.normalized * (Input.GetButton(runButtonName) ? runSpeed : speed) * Time.deltaTime);
    }
}
