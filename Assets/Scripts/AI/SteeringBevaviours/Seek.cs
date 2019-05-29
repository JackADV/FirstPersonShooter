using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    public Transform target;

    public override Vector3 GetForce(AI owner)
    {
        // Set force to zero
        Vector3 force = Vector3.zero;

        // Implement seek here
        // If target is not null
        if (target) // Shorthand for target != null
        {
            // Set desiredForce to target - current (position)
            Vector3 desiredForce = target.position - transform.position;
            // Set force to desiredForce normalized x weighting
            force += desiredForce.normalized * weighting;
        }


        // Return force
        return force;
    }
}
