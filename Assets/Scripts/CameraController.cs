using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, 0.5f, 0);
    public float xTilt = 10;

    Vector3 destination = Vector3.zero;
    CharacterController characterController;
    float rotateVel = 0;

}
