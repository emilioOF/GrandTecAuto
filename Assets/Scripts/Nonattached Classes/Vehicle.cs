using UnityEngine; 

public class Vehicle
{
    private int[] speeds = {3, 10, 20};
    private float[] lanes = { -4.0f, -1.4f, 1.47f, 4.0f };
    private int speedIndex ;
    private int laneIndex;
    private bool direction;
    
    public Vehicle(int speedIndex, int laneIndex, bool direction)
    {
        this.speedIndex = speedIndex;
        this.laneIndex = laneIndex; 
        this.direction = direction;
    }

    public void increaseSpeed()
    {
        if (speedIndex < speeds.Length-1)
        {
            speedIndex += 1; 
        }
    }

    public void decreaseSpeed()
    {
        if (speedIndex > 0)
        {
            speedIndex -= 1;
        }
    }
                     
    public Vector2 currentSpeed()
    {
        return Vector2.right * speeds[speedIndex] * directionToInt();  
    }

    public void moveLaneUp()
    {
        if (laneIndex < lanes.Length - 1)
        {
            laneIndex += 1; 
        }
    }

    public void moveLaneDown()
    {
        if (laneIndex > 0)
        {
            laneIndex -= 1;
        }
    }

    public float currentPositionY()
    {
        return lanes[laneIndex]; 
    }

    private int directionToInt()
    {
        if (direction)
        {
            return 1; 
        }
        else
        {
            return -1; 
        }
    }
}