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
        vehicle = new Vehicle(speedIndex, laneIndex, true);
        rigVehicle = gameObject.GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            vehicle.modSpeed(1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            vehicle.modSpeed(-1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vehicle.modLane(-1);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            vehicle.modLane(1);
        }

        transform.position = new Vector3(transform.position.x, vehicle.currentLane(), 0); 
    }

    private void FixedUpdate()
    {
        rigVehicle.velocity = new Vector2(vehicle.currentSpeed(),0); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("MainScene");
    }
}
