using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring
{
    private float strength;   //绳子振动的频率
    private float damper;   //绳子稳定的快慢
    private float target;
    private float velocity;   //绳子出枪的速度 ?
    private float value;   // ?

    // Update is called once per frame
    public void Update(float deltaTime)
    {
        var direction = target - value >= 0 ? 1f : -1f;
        var force = Mathf.Abs(target - value) * strength;
        velocity += (force * direction - velocity * damper) * deltaTime;
        value += velocity * deltaTime;
    }

    public void Reset()
    {
        velocity = 0f;
        value = 0f;
    }

    public void SetValue(float value)
    {
        this.value = value;
    }

    public void SetTarget(float target)
    {
        this.target = target;
    }

    public void SetDamper(float damper)
    {
        this.damper = damper;
    }

    public void SetStrength(float strength)
    {
        this.strength = strength;
    }

    public void SetVelocity(float velocity)
    {
        this.velocity = velocity;
    }

    public float Value => value;
}