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
    public GameObject colliderObj;
    public float movementSpeed = 5;

    Collider collider;
    Vector3 prevPosition;
    GameObject[] walls;

    void Start ()
    {
        if (hand == null)
            hand = this.GetComponent<Hand>();

        if (collider == null)
            collider = colliderObj.GetComponent<Collider>();

        if (walls == null)
            walls = GameObject.FindGameObjectsWithTag("Wall");
	}
	
	void Update ()
    {

        if(touch.GetState(hand.handType))
        {
            Vector3 newPos = (((transform.right * move.GetAxis(hand.handType).x + transform.forward * move.GetAxis(hand.handType).y) * movementSpeed) * Time.deltaTime);
            foreach (GameObject wall in walls)
            {
                if (collider.bounds.Intersects(wall.GetComponent<Collider>().bounds))
                {
                    rig.position = prevPosition;
                    Debug.Log("COLLIDED");
                    return;
                }
            }
            rig.position += new Vector3(newPos.x, 0, newPos.z);
        }

        prevPosition = rig.position;
    }
}
