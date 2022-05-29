using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public float speed;
    public int laneIndex;

    private float[] lanes;
    Rigidbody2D rigBot; 

    void Start()
    {
        lanes = GameController.Lanes;
        rigBot = GetComponent<Rigidbody2D>(); 
        transform.position = new Vector3(transform.position.x, lanes[laneIndex], transform.position.z);
        GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        rigBot.velocity = Vector3.right * speed;
    }
}
