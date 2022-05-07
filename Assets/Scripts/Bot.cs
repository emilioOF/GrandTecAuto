using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public int speedIndex;
    public int laneIndex;
    public bool direction; 

    Vehicle vehicle;
    Rigidbody2D rigVehicle; 

    void Start()
    {
        vehicle = new Vehicle(speedIndex, laneIndex, direction);
        transform.position = new Vector3(transform.position.x, vehicle.currentLane(), 0);
        rigVehicle = gameObject.GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigVehicle.velocity = new Vector2(vehicle.currentSpeed(),0); 
    }
}
