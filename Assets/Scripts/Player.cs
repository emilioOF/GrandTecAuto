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
    private ColorController colorController; 
    private bool slowMotionOn; 
    
    void Awake()
    {
        vehicle = new Vehicle(speedIndex, laneIndex);
        battery = new Battery(); 
        rigVehicle = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        cop = transform.Find("Cop").GetComponent<Cop>();
        colorController = GameObject.Find("Lanes").GetComponent<ColorController>(); 
        Time.timeScale = 1f;
        slowMotionOn = false; 
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            electricAttack(); 
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!slowMotionOn)
            {
                colorController.slowMoAnimation(true);
            } else
            {
                colorController.slowMoAnimation(false);
            }
            slowMotion();
        }

        transform.position = new Vector3(transform.position.x, vehicle.currentPositionY(), 0);

        if (slowMotionOn)
        {
            battery.discharge(20);
        } else
        {
            if (vehicle.getLaneIndex() < 2)
            {
                battery.discharge(vehicle.currentSpeedInt());
            }
            else
            {
                battery.charge(vehicle.currentSpeedInt());
            }
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
        slowMotionOn = !slowMotionOn; 
        if (slowMotionOn)
        {
            GameController.SpeedMaster = 0.2f; 
        } else
        {
            GameController.SpeedMaster = 1f;
        }
    }

    public bool getSlowMotionStatus()
    {
        return slowMotionOn; 
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
