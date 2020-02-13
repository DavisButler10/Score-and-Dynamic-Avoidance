using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separate : MonoBehaviour
{
    public Kinematic character;
    public Kinematic[] targets;

    private float maxAcceleration = 25f;
    private float threshold = 10f;
    private float decayCoefficient = 10f;


    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        for (int i = 0; i < targets.Length; i++)
        {
            Vector3 direction = character.transform.position-targets[i].transform.position;
            float distance = direction.magnitude;


            if (distance < threshold)
            {
                //Get strength of repulsion using inverse square law\
                float strength = Mathf.Min(decayCoefficient / (distance * distance), maxAcceleration);

                direction = direction.normalized;
                result.linear += strength * direction;
            }
        }
        return result;
    }
}