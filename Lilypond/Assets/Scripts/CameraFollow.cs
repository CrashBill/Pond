using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform followObject;
    [SerializeField] MovementController moveObject;
    [SerializeField] float posLag;
    [SerializeField] float trailDist;
    [SerializeField] float speedMultiplier;
    [SerializeField] LayerMask groundLayer;
    float trailOffset;
    Vector3 vel = Vector3.zero;
    float posLagDelta = 0f;

    void Start()
    {
        trailOffset = trailDist;
    }

    void Update()
    {
        if (moveObject.lastForce.magnitude > 0)
        {
            trailOffset = Mathf.MoveTowards(trailOffset, trailDist + (moveObject.lastForce.magnitude * speedMultiplier), trailDist/100);
        }
        else
        {
            trailOffset = Mathf.MoveTowards(trailOffset, trailDist + (moveObject.lastForce.magnitude * speedMultiplier), trailDist/2);
        }
        
        Vector3 destPosition = DestinationPosition();

        //float x = Mathf.SmoothDamp(transform.position.x, destPosition.x, ref vel, posLag);
        //float y = Mathf.MoveTowards(transform.position.y, destPosition.y, posLag);
        //float z = Mathf.MoveTowards(transform.position.z, destPosition.z, posLag);

        //Debug.Log(moveObject.lastForce.magnitude);

        transform.localPosition = Vector3.SmoothDamp(transform.position, destPosition, ref vel, posLag);

        /*if (moveObject.lastForce.magnitude > 0)
        {
            //posLagDelta = Mathf.MoveTowards(posLagDelta, posLag, posLag*Time.deltaTime*2);
            transform.localPosition = Vector3.SmoothDamp(transform.position, destPosition, ref vel, posLag/moveObject.lastForce.magnitude);
        }
        else
        {
            //posLagDelta = Mathf.MoveTowards(posLagDelta, posLag, posLag*Time.deltaTime*2);
            transform.localPosition = Vector3.SmoothDamp(transform.position, destPosition, ref vel, posLag);
        }*/
    }

    void LateUpdate()
    {
        //transform.localRotation = followObject.localRotation;
    }

    Vector3 DestinationPosition()
    {
        Vector3 destPosition = followObject.position - (transform.forward * trailOffset);

        bool inFloor = Physics.CheckSphere(destPosition, 0.5f);

        while (!inFloor)
        {
            destPosition += transform.forward * 0.5f;
            inFloor = Physics.CheckSphere(destPosition, 0.5f);
        }

        return destPosition;
    }
}
