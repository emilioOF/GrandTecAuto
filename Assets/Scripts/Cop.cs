using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop: MonoBehaviour
{
    public float speedIncreaseRate;
    public float initialDistance;

    private int[] speeds = {4, 9, 14};
    private Transform playerTran;
    private int speedIndex;
    private float xPosition;
    private float lastTime;
    private bool finalSpeed; 

    void Awake()
    {
        playerTran = GameObject.Find("Player").transform;
        speedIndex = 0;
        xPosition = playerTran.position.x - initialDistance;
        lastTime = Time.time;
        finalSpeed = false;
    }

    void Update()
    {
        increaseSpeed();

        if (hasCrashed())
        {
            GameController.endGame(); 
        }

        if (!finalSpeed)
        {
            if ((Time.time - lastTime) > speedIncreaseRate)
            {
                upSpeed();
                lastTime = Time.time; 
            }
        }
    }
 
    private bool hasCrashed()
    {
        return distanceToPlayer() < 1; 
    }

    private void increaseSpeed()
    {
        xPosition += speeds[speedIndex] * Time.deltaTime;
    }

    private void upSpeed()
    {
        if (speedIndex < speeds.Length-1)
        {
            speedIndex += 1;
            return; 
        }
        finalSpeed = true;
    }

    public float distanceToPlayer()
    {
        return playerTran.position.x - xPosition;
    }

    public void pushBack(float dis)
    {
        xPosition -= dis; 
    }
}
