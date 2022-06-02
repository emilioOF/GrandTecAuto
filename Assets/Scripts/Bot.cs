using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public float speed;
    public int laneIndex;

    private Rigidbody2D rigBot;

    void Start()
    {
        rigBot = GetComponent<Rigidbody2D>(); 
        transform.position = new Vector3(transform.position.x, GameController.Lanes[laneIndex], transform.position.z);
        GetComponent<SpriteRenderer>().color = GameObject.Find("Lanes").GetComponent<ColorController>().currentCarColor();
    }

    private void FixedUpdate()
    {
        rigBot.velocity = Vector3.right * speed * GameController.SpeedMaster;
    }
}
