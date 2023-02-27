using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehaviour : MonoBehaviour
{
    [SerializeField]
    float rotationRadius = 3f, angularSpeed = 50f;
    float angle = 0f;
    Vector3 center;
    public LayerMask mask;
    public float rango = 4f;
    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the RigidBody2D component
        center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!Physics2D.OverlapCircle(transform.position, rango, mask))
        {
            angle += Time.deltaTime * angularSpeed; // update angle
            Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up; // calculate direction from center - rotate the up vector Angle degrees clockwise
            transform.position = center + direction * rotationRadius; // update position based on center, the direction, and the radius (which is a constant)
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);
        }
    }
}