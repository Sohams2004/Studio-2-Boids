using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector2 velocity;
    public float maxVelocity;

    private void Update()
    {
        if (velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }

        gameObject.transform.position = gameObject.transform.position + new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.FromToRotation(Vector2.up, velocity); 
    }
}
