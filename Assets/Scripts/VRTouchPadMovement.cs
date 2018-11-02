using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class VRTouchPadMovement : MonoBehaviour
{
    [SerializeField]
    private Transform rig;

    public Hand hand;
    public SteamVR_Action_Boolean touch;
    public SteamVR_Action_Vector2 move;
    public float movementSpeed = 5;

	void Start ()
    {
        if (hand == null)
            hand = this.GetComponent<Hand>();
	}
	
	void Update ()
    {
        if(touch.GetState(hand.handType))
        {
            rig.position += (((transform.right * move.GetAxis(hand.handType).x + transform.forward * move.GetAxis(hand.handType).y) * movementSpeed) * Time.deltaTime);
            rig.position = new Vector3(rig.position.x, 0, rig.position.z);
            Debug.Log(rig.position);
            Debug.Log(move.GetAxis(hand.handType));
            Debug.Log(touch.GetStateDown(hand.handType));
        }
    }
}
