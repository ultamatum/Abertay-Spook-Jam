using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float inputDeadzone = 0.1f;
    public float forwardVel = 12;
    public float horizontalVel = 12;

    Quaternion targetRotation;
    Rigidbody rigidbody;
    float forwardInput, horizontalInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rigidbody = GetComponent<Rigidbody>();
        else
            Debug.LogError("Character doesn't have a rigidbody");

        forwardInput = horizontalInput = 0;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        Run();
    }
    
    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDeadzone || Mathf.Abs(horizontalInput) > inputDeadzone)
        {
            rigidbody.velocity = (transform.forward * forwardInput * forwardVel) + (transform.right * horizontalInput * horizontalVel);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }

        
    }
}
