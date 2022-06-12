using UnityEngine;

public class Cop: MonoBehaviour
{
    public float speedIncreaseRate;
    public float initialDistance;

    private int[] speeds = {6, 11, 18, 24};
    private Transform playerTran;
    private int speedIndex;
    private float xPosition;
    private float lastTime;
    private bool finalSpeed;

    private UIController uIController; 

    void Awake()
    {
        playerTran = GameObject.Find("Player").transform;
        speedIndex = 0;
        xPosition = playerTran.position.x - initialDistance;
        lastTime = Time.time;
        finalSpeed = false;

        uIController = GameObject.Find("UI").GetComponent<UIController>(); 
    }

    void Update()
    {
        advance();

        if (hasCrashed())
        {
            playerTran.GetComponent<Player>().endGamePlayer("caught"); 
        }

        if (!finalSpeed)
        {
            if ((Time.time - lastTime) > speedIncreaseRate)
            {
                increaseSpeed();
                lastTime = Time.time; 
            }
        }
    }
 
    private bool hasCrashed()
    {
        return distanceToPlayer() < 1; 
    }

    private void advance()
    {
        xPosition += speeds[speedIndex] * Time.deltaTime * GameController.TrafficSpeedMaster;
    }

    private void increaseSpeed()
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
