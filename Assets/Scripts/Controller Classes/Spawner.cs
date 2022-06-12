using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] bots; 
    public float[] spawnRates;
    public int[] weighs; 

    private float lastPosX;
    private Chooser chooser;
    private Vehicle vehicle;

    void Start()
    {
        lastPosX = transform.position.x;
        chooser = new Chooser(weighs);
        vehicle = GameObject.Find("Player").GetComponent<Player>().getPlayerVehicle();
    }

    void Update()
    {
        if ((transform.position.x - lastPosX) > spawnRates[vehicle.getSpeedIndex()])
        {
            createBot();
            lastPosX = transform.position.x; 
        }
    }

    private void createBot()
    {
        Instantiate(bots[chooser.choose()], transform.position, transform.rotation);
    }
}