using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Seek
{
    float avoidDistance = 100f;

    float lookahead = 10f;

    protected override Vector3 getTargetPosition()
    {
        RaycastHit hit;

        if (Physics.Raycast(character.transform.position + new Vector3(0f, 0, 0.5f), character.linear, out hit, lookahead))
        {
            Debug.DrawRay(character.transform.position + new Vector3(0f, 0, 0.5f), character.linear * hit.distance, Color.yellow, 0.5f);
            Debug.Log("Hit " + hit.collider);
            return hit.point + (hit.normal * avoidDistance);
        }
        else if (Physics.Raycast(character.transform.position + new Vector3(0f, 0, -0.5f), character.linear, out hit, lookahead))
        {
            Debug.DrawRay(character.transform.position + new Vector3(0f, 0, -0.5f), character.linear * hit.distance, Color.yellow, 0.5f);
            Debug.Log("Hit " + hit.collider);
            return hit.point + (hit.normal * avoidDistance);
        }
        else
        {
            Debug.DrawRay(character.transform.position, character.linear * lookahead, Color.white, 0.5f);
            Debug.Log("Hitting Nothing");
        }
        return base.getTargetPosition();
    }
}