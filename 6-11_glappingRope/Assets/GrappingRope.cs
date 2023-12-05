using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappingRope : MonoBehaviour
{
    private Spring spring;   //actual simulation that runs now we just
    private LineRenderer lr;
    public GrappingGun grapplingGun;
    private Vector3 currentGrapplePosition;

    public int quality;   //how many actual parts they are in the rope
    public float damper;
    public float strength;
    public float velocity;
    public float waveCount;
    public float waveHeight;
    public AnimationCurve affectCurve;

    void Awake()
    {
        lr = GetComponent<LineRenderer>(); 
        spring = new Spring();
        spring.SetTarget(0);
    }

    void LateUpdate()
    {
        /*
        if(grapplingGun.grappling)
        {
           lr.SetPosition(0, grapplingGun.gunTip.position);
        }
        */
        DrawRope();
    }

    void DrawRope()
    {
        //如果没有连接，则不显示绳索
        if(!grapplingGun.IsGrappling())
        {
            currentGrapplePosition = grapplingGun.gunTip.position;
            spring.Reset();
            if(lr.positionCount > 0)
                lr.positionCount = 0;
            return;
        }

        if(lr.positionCount == 0)
        {
            spring.SetVelocity(velocity);
            lr.positionCount = quality + 1;
        }

        spring.SetDamper(damper);
        spring.SetStrength(strength);
        spring.Update(Time.deltaTime);

        var grapplePoint = grapplingGun.GetGrapplePoint();
        var gunTipPosition = grapplingGun.gunTip.position;
        var up = Quaternion.LookRotation(grapplePoint - gunTipPosition).normalized * Vector3.up;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        for(var i = 0; i < quality + 1; i++)
        {
            var delta = i / (float) quality;
            var offset = up * waveHeight * Mathf.Sin(delta * waveCount * Mathf.PI) * spring.Value * affectCurve.Evaluate(delta);

            lr.SetPosition(i, Vector3.Lerp(gunTipPosition, currentGrapplePosition, delta) + offset);
        }
    }
}
