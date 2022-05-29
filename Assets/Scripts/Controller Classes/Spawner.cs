using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] bots; 
    public float baseSpawnRate;

    private float lastPosX;
    private Chooser chooser;
    private Vehicle vehicle;

    // Start is called before the first frame update
    void Start()
    {
        lastPosX = transform.position.x;
        chooser = new Chooser(new int[] {0,1,2,3});
        vehicle = GameObject.Find("Player").GetComponent<Player>().getPlayerVehicle();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - lastPosX) > currentSpawnRate())
        {
            createBot();
            lastPosX = transform.position.x; 
        }
    }

    private void createBot()
    {
        Instantiate(bots[chooser.choose()], transform.position, transform.rotation);
    }

    private float currentSpawnRate()
    {
        // 5 es el valor de la primera velocidad del jugador
        return baseSpawnRate - ((vehicle.currentSpeedInt() / 5) - 1);
    }
}