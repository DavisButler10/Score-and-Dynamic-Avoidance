using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidance : MonoBehaviour
{
    public Kinematic character;
    float maxAcceleration = 5f;

    public Kinematic[] targets;

    float radius = 2f;

    public SteeringOutput getSteering()
    {
        float shortestTime = float.PositiveInfinity;

        Kinematic firstTarget = null;
        float firstMinSeparation = 0f; ;
        float firstDistance = 0f;
        Vector3 firstRelativePos = new Vector3(0, 0, 0);
        Vector3 firstRelativeVel = new Vector3(0, 0, 0);
        Vector3 relativePos;
        Vector3 relativeVel;

        foreach (Kinematic target in targets)
        {
            relativePos = target.transform.position - character.transform.position;
            relativeVel = target.linear - character.linear;
            float relativeSpeed = relativeVel.magnitude;
            float timeToCollision = Vector3.Dot(relativePos, relativeVel) / (relativeSpeed * relativeSpeed);

            float distance = relativePos.magnitude;
            float minSeparation = distance - relativeSpeed * timeToCollision;
            if (minSeparation > 2 * radius)
            {
                continue;
            }

            if (timeToCollision > 0 && timeToCollision < shortestTime)
            {
                shortestTime = timeToCollision;
                firstTarget = target;
                firstDistance = distance;
                firstRelativePos = relativePos;
                firstRelativeVel = relativeVel;
            }
        }
        if (!firstTarget)
        {
            return null;
        }

        /*if(firstMinSeparation <= 0 || firstDistance < 2 * radius)
        {
            relativePos = firstTarget.transform.position - character.transform.position;
        }
        else
        {
            relativePos = firstRelativePos + firstRelativeVel * shortestTime;
        }
        relativePos.Normalize();*/

        SteeringOutput result = new SteeringOutput();


        float dotResult = Vector3.Dot(character.linear.normalized, firstTarget.linear.normalized);
        if (dotResult < -0.9 && dotResult > -1.1)
        {

            result.linear = -firstTarget.transform.right;
        }
        else
        {
            result.linear = -firstTarget.linear;
        }
        result.linear.Normalize();
        result.linear *= maxAcceleration;
        result.angular = 0;
        return result;
    }
}
