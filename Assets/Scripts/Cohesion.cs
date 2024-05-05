using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cohesion : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float neighborBoid;
    Boid boid;

    void Start()
    {
        boid = GetComponent<Boid>();
    }

    void CohesionBehaviour()
    {
        var boids = FindObjectsOfType<Boid>();
        var average = Vector2.zero;
        neighborBoid = 0;


        for (int i = 0; i < boids.Length; i++)
        {
            if (boids[i] != boid)
            {
                Vector2 difference = boids[i].transform.position - gameObject.transform.position;

                if (difference.magnitude < radius)
                {
                    average += difference;
                    neighborBoid++;
                }
            }
        }

        if (neighborBoid > 0)
        {
            average = average / neighborBoid;
            boid.velocity += Vector2.Lerp(Vector2.zero, average, average.magnitude / radius);
        }
    }

    void Update()
    {
        CohesionBehaviour();
    }
}
