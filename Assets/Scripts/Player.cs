using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour
{
    public int speedIndex;
    public int laneIndex;

    private Vehicle vehicle;
    private Battery battery;
    private Rigidbody2D rigVehicle;
    private Cop cop; 
    
    void Awake()
    {
        vehicle = new Vehicle(speedIndex, laneIndex);
        battery = new Battery(); 
        rigVehicle = GetComponent<Rigidbody2D>(); 
    }

    private void Start()
    {
        cop = transform.Find("Cop").GetComponent<Cop>();  
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            electricAttack(); 
        }

        transform.position = new Vector3(transform.position.x, vehicle.currentPositionY(), 0);

        if (vehicle.getLaneIndex() < 2)
        {
            battery.discharge(vehicle.currentSpeedInt());
        } else
        {
            battery.charge(vehicle.currentSpeedInt());
        }
    }

    private void FixedUpdate()
    {
        rigVehicle.velocity = vehicle.currentSpeed(); 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.endGame(); 
    }

    private void electricAttack()
    {
        if (battery.currentBattery() >= 60)
        {
            battery.strongDischarge(25f);
            cop.pushBack(20f); 
        }
    }

    private void slowMotion()
    {
        
    }

    public Vehicle getPlayerVehicle()
    {
        return vehicle;
    }

    public Battery getPlayerBattery()
    {
        return battery; 
    }
}
