using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour
{
    public int speedIndex;
    public int laneIndex;

    Vehicle vehicle;
    Rigidbody2D rigVehicle; 
    
    void Start()
    {
        vehicle = new Vehicle(speedIndex, laneIndex);
        rigVehicle = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            vehicle.increaseSpeed();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            vehicle.decreaseSpeed();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vehicle.moveLaneUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            vehicle.moveLaneDown();
        }
       
        transform.position = new Vector3(transform.position.x, vehicle.currentPositionY(), 0);
    }

    private void FixedUpdate()
    {
        rigVehicle.velocity = vehicle.currentSpeed(); 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.endGame(); 
    }
}
