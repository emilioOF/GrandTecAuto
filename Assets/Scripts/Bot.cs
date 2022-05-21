using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public float speed;
    public int laneIndex;

    private float[] lanes; 

    Rigidbody2D rigVehicle; 

    void Start()
    {
        lanes = GameController.Lanes; 
        rigVehicle = gameObject.GetComponent<Rigidbody2D>();

        transform.position = new Vector3(transform.position.x, lanes[laneIndex], transform.position.z);

        GetComponent<SpriteRenderer>().color = Random.ColorHSV(); 
    }

    private void FixedUpdate()
    {
        rigVehicle.velocity = Vector2.right * speed;  
    }

}
