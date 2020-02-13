using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum steeringBehaviors
{
    Seek, Flee, Arrive, Align, Face, LookWhereGoing, PathFollow, Pursue, Separate, CollisionAvoidance, ObstacleAvoidance, None
}

public class Kinematic : MonoBehaviour
{

    public Vector3 linear;
    public float angular; //In degrees
    public GameObject newTarget;
    public float maxSpeed = 10.0f;
    public float maxAngularVelocity = 45.0f; // degrees


    public steeringBehaviors choiceOfBehavior;
    public GameObject[] path;
    public Kinematic[] targets;
    PathFollow follow = new PathFollow();
    LookWhereGoing lookwg = new LookWhereGoing();

    // Update is called once per frame
    void Update()
    {
        switch (choiceOfBehavior)
        {
            case steeringBehaviors.None:
                ResetOrientation();
                break;
            default:
                MainSteeringBehaviors();
                break;
        }
    }


    void MainSteeringBehaviors()
    {
        ResetOrientation();

        switch (choiceOfBehavior)
        {
            case steeringBehaviors.Seek:
                Seek seek = new Seek();
                seek.character = this;
                seek.target = newTarget;
                SteeringOutput seeking = seek.getSteering();
                if (seeking != null)
                {
                    linear += seeking.linear * Time.deltaTime;
                    angular += seeking.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Flee:
                Flee flee = new Flee();
                flee.character = this;
                flee.target = newTarget;
                SteeringOutput fleeing = flee.getSteering();
                if (fleeing != null)
                {
                    linear += fleeing.linear * Time.deltaTime;
                    angular += fleeing.angular * Time.deltaTime;
                }
                break;

            case steeringBehaviors.Align:
                Align align = new Align();
                align.character = this;
                align.target = newTarget;
                SteeringOutput aligning = align.getSteering();
                if (aligning != null)
                {
                    linear += aligning.linear * Time.deltaTime;
                    angular += aligning.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Face:
                Face face = new Face();
                face.character = this;
                face.target = newTarget;
                SteeringOutput facing = face.getSteering();
                if (facing != null)
                {
                    linear += facing.linear * Time.deltaTime;
                    angular += facing.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.LookWhereGoing:
                LookWhereGoing look = new LookWhereGoing();
                look.character = this;
                look.target = newTarget;
                SteeringOutput looking = look.getSteering();
                if (looking != null)
                {
                    linear += looking.linear * Time.deltaTime;
                    angular += looking.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Arrive:
                Arrive arrive = new Arrive();
                arrive.character = this;
                arrive.target = newTarget;
                SteeringOutput arriving = arrive.getSteering();
                if (arriving != null)
                {
                    linear += arriving.linear * Time.deltaTime;
                    angular += arriving.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.PathFollow:


                follow.character = this;
                lookwg.character = this;

                follow.path = path;
                lookwg.target = newTarget;

                SteeringOutput following = follow.getSteering();
                SteeringOutput lookingwg = lookwg.getSteering();

                if (following != null)
                {
                    linear += following.linear * Time.deltaTime;
                    // angular += lookingwg.angular* Time.deltaTime;
                }
                break;
            case steeringBehaviors.Pursue:
                Pursue pursue = new Pursue();
                LookWhereGoing PursuelookWhereGoing = new LookWhereGoing();
                pursue.character = this;
                PursuelookWhereGoing.character = this;
                pursue.target = newTarget;
                PursuelookWhereGoing.target = newTarget;
                SteeringOutput pursuing = pursue.getSteering();
                SteeringOutput pursuelookingWhereGoing = PursuelookWhereGoing.getSteering();

                if (pursuing != null)
                {
                    linear += pursuing.linear * Time.deltaTime;
                    angular += pursuing.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Separate:
                Separate separate = new Separate();
                LookWhereGoing lookWhereGoing = new LookWhereGoing();
                separate.character = this;
                lookWhereGoing.character = this;
                separate.targets = targets;
                lookWhereGoing.target = newTarget;
                SteeringOutput lookingWhereGoing = lookWhereGoing.getSteering();
                SteeringOutput separating = separate.getSteering();
                if (separating != null)
                {
                    linear += separating.linear * Time.deltaTime;
                    angular += separating.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.CollisionAvoidance:
                CollisionAvoidance avoid = new CollisionAvoidance();
                LookWhereGoing AvoidlookWhereGoing = new LookWhereGoing();
                avoid.character = this;
                AvoidlookWhereGoing.character = this;
                avoid.targets = targets;
                AvoidlookWhereGoing.target = newTarget;
                SteeringOutput AvoidlookingWhereGoing = AvoidlookWhereGoing.getSteering();
                SteeringOutput avoiding = avoid.getSteering();
                if (avoiding != null)
                {
                    linear += avoiding.linear * Time.deltaTime;
                    angular += avoiding.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.ObstacleAvoidance:
                ObstacleAvoidance obAvoid = new ObstacleAvoidance();
                LookWhereGoing obAvoidlookWhereGoing = new LookWhereGoing();
                obAvoid.character = this;
                obAvoidlookWhereGoing.character = this;
                obAvoid.target = newTarget;
                obAvoidlookWhereGoing.target = newTarget;
                SteeringOutput obAvoiding = obAvoid.getSteering();
                SteeringOutput obAvoidlookingWhereGoing = obAvoidlookWhereGoing.getSteering();
                if (obAvoiding != null)
                {
                    linear += obAvoiding.linear * Time.deltaTime;
                    angular += obAvoiding.angular * Time.deltaTime;
                }
                break;
        }

    }


    void ResetOrientation()
    {
        //Update position and rotation
        transform.position += linear * Time.deltaTime;
        Vector3 angularIncrement = new Vector3(0, angular * Time.deltaTime, 0);
        transform.eulerAngles += angularIncrement;
    }

}