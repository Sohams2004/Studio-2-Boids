using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    [SerializeField] GameObject[] maxBoids;
    [SerializeField] GameObject boid;
    [SerializeField] GameObject parentGameObject;

    [SerializeField] int no_Of_Boids;

    [SerializeField] Vector2 radius = new Vector2();

    private void Start()
    {
        boid = GameObject.FindWithTag("Boid");
        parentGameObject = GameObject.FindWithTag("Parent");
    }

    private void Awake()
    {
        maxBoids = new GameObject[no_Of_Boids];

        for (int i = 0; i < no_Of_Boids; i++)
        {
            Vector2 position = transform.position + new Vector3(Random.Range(-radius.x, radius.x), Random.Range(-radius.y, radius.y));
            maxBoids[i] = Instantiate(boid, position, Quaternion.identity);
            maxBoids[i].transform.parent = parentGameObject.transform;
        }
    }
}
