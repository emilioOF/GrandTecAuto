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
        rigVehicle = gameObject.GetComponent<Rigidbody2D>();

        transform.position = new Vector3(transform.position.x, vehicle.currentPositionY(), 0);
    }

    private void FixedUpdate()
    {
        rigVehicle.velocity = vehicle.currentSpeed();  
    }
}
