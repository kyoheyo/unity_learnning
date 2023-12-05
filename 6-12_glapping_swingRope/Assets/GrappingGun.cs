using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappingGun : MonoBehaviour
{
    [Header("References")]
    public PlayerMovement pm;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, cam, player;

    [Header("Grappling")]
    public float maxDistance;
    public float grappleDelayTime;
    public float overshootYAxis;

    private Vector3 grapplePoint;

    [Header("Cooldown")]
    public float grapplingCd;
    private float grapplingCdTimer;

    [Header("Input")]
    public KeyCode swingKey = KeyCode.Q;
    public KeyCode grapplingKey = KeyCode.E;
    
    private bool grappling;   //是否处于发射绳索状态
    private SpringJoint joint;

    private void Update()
    {
        if(Input.GetKeyDown(swingKey))
        {
            StartSwing();
        }
        else if(Input.GetKeyUp(swingKey))
        {
            StopSwing();
        }
        
        if(Input.GetKeyDown(grapplingKey))
        {
            StartGrapple();
        }
        else if(Input.GetKeyUp(grapplingKey))
        {
            StopGrapple();
        }
    }

    private void FixedUpdate()
    {
        if(grapplingCdTimer > 0)
        {
            grapplingCdTimer -= Time.deltaTime;
        }
    }

    private void StartSwing()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grappling = true;
            grapplePoint = hit.point;
            
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(gunTip.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.3f;

            joint.spring = 2f;
            joint.damper = 15f;
            joint.massScale = 4.5f;
        }
    }

    private void StopSwing()
    {
        grappling = false;

        Destroy(joint);
    }

    private void StartGrapple()
    {
        if(grapplingCdTimer > 0) return;

        grappling = true;
        grapplingCdTimer = grapplingCd;

        pm.MoveStopControl();

        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;

            Invoke(nameof(ExecuteGrapple), grappleDelayTime);
        }
        else
        {
            grapplePoint = cam.position + cam.forward * maxDistance;

            Invoke(nameof(StopGrapple), grappleDelayTime);
        }
/*
        line.enabled = true;
        line.positionCount = 2;
        if(grappling)
        {
            line.SetPosition(0, gunTip.position);
        }
        line.SetPosition(1, grapplePoint);
*/
    }

    private void ExecuteGrapple()
    {
        Vector3 lowestPosition = player.position;

        float grapplePointRelativeY = grapplePoint.y - lowestPosition.y;
        float highestPosition = grapplePointRelativeY + overshootYAxis;
        
        if(grapplePointRelativeY < 0 ) highestPosition = overshootYAxis;
        //Debug.Log(pm);
        
        pm.GrappleToPosition(grapplePoint, highestPosition);
    }

    private void StopGrapple()
    {
        grappling = false;

        //line.enabled = false;
    }

    public bool IsGrappling()   //是否存在连接
    {
        return grappling == true;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
