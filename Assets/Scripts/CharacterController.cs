using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float inputDeadzone = 0.1f;
    public float forwardVel = 12;
    public float rotateVel = 100;

    Quaternion targetRotation;
    Rigidbody rigidbody;
    float forwardInput, turnInput;

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

        forwardInput = turnInput = 0;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        GetInput();
        Turn();
    }

    void FixedUpdate()
    {
        Run();
    }
    
    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDeadzone)
        {
            rigidbody
        } else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    void Turn()
    {

    }
}
