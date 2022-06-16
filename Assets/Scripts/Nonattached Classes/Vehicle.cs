using UnityEngine; 

public class Vehicle
{
    private int[] speeds = {5, 10, 15, 20, 25, 30};
    // Bot: 2, 4, 18, 20
    // Cop: 6, 11, 17, 22
    private float[] lanes; 
    private int speedIndex;
    private int laneIndex;
    private bool speedLockOn; 

    public Vehicle(int speedIndex, int laneIndex)
    {
        lanes = GameController.Lanes;
        this.speedIndex = speedIndex;
        this.laneIndex = laneIndex;
    }

    public void increaseSpeed()
    {
        if (speedIndex < speeds.Length-1 && !speedLockOn) speedIndex += 1;
    }

    public void decreaseSpeed()
    {
        if (speedIndex > 0) speedIndex -= 1;
    }
                     
    public Vector2 currentSpeed()
    {
        return Vector2.right * speeds[speedIndex] * GameController.PlayerSpeedMaster;
    }

    public int currentSpeedInt()
    {
        return speeds[speedIndex]; 
    }

    public void toggleSpeedLock(bool toggleOn)
    {
        if (toggleOn)
        {
            speedLockOn = true;
            speedIndex = 0; 
        } else
        {
            speedLockOn = false; 
        }
    }

    public bool isSpeedLockOn()
    {
        return speedLockOn; 
    }

    public bool inLastSpeed()
    {
        return (speedIndex + 1) == speeds.Length; 
    }

    public void moveLaneUp()
    {
        laneIndex += 1;
    }

    public void moveLaneDown()
    {
        laneIndex -= 1;
    }

    public float currentPositionY()
    {
        return lanes[laneIndex]; 
    }

    public int getSpeedIndex()
    {
        return speedIndex; 
    }

    public int getLaneIndex()
    {
        return laneIndex; 
    }

    public int numSpeeds()
    {
        return speeds.Length; 
    }
}