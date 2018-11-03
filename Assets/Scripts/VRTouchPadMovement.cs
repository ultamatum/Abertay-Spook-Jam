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
    public Collider colliderObj;
    public float movementSpeed = 5;
    
    Vector3 prevPosition;
    GameObject[] walls;

    void Start ()
    {
        /*
        if (capCollider == null)
            capCollider = colliderObj.GetComponent<CapsuleCollider>();*/

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
                if (wall.GetComponent<MeshCollider>().bounds.Intersects(colliderObj.bounds))
                {
                    rig.position = prevPosition;
                    Debug.Log("COLLIDED: " + colliderObj + " Hand: Right");
                    return;
                }
            }
            rig.position += new Vector3(newPos.x, 0, newPos.z);
        }

        prevPosition = rig.position;
    }
}
