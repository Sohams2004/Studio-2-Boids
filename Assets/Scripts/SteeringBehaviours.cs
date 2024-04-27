using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{
    [SerializeField] float seekSpeed;
    [SerializeField] float fleeSpeed;

    [SerializeField] bool isSeeking, isFleeing;

    [SerializeField] float detectionRadius;

    [SerializeField] GameObject player;

    [SerializeField] Rigidbody2D rb;

    void Seek()
    {
        if (isSeeking)
        {
            Vector2 desiredVelocity = (player.transform.position - transform.position).normalized * seekSpeed;
            Vector2 steeringForce = desiredVelocity - rb.velocity;
            rb.velocity = steeringForce;
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Flee()
    {
        if (isFleeing)
        {
            Vector2 desiredVelocity = (transform.position - player.transform.position).normalized * fleeSpeed;
            Vector2 steeringForce = desiredVelocity - rb.velocity;
            rb.velocity = steeringForce;
        }
    }

    private void Update()
    {
        Seek();
        Flee();
    }
}
