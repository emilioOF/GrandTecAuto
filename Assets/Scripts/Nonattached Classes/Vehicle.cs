using UnityEngine; 

public class Vehicle
{
    private int[] speeds = {6, 10, 15, 20, 25};
    private float[] lanes; 
    private int speedIndex ;
    private int laneIndex;
    private bool direction;
    
    public Vehicle(int speedIndex, int laneIndex, bool direction)
    {
        this.speedIndex = speedIndex;
        this.laneIndex = laneIndex; 
        this.direction = direction;
        lanes = GameController.Lanes; 
    }

    public void increaseSpeed()
    {
        if (speedIndex < speeds.Length-1) speedIndex += 1; 
    }

    public void decreaseSpeed()
    {
        if (speedIndex > 0) speedIndex -= 1;
    }
                     
    public Vector2 currentSpeed()
    {
        return Vector2.right * speeds[speedIndex] * directionToInt();  
    }

    public void moveLaneUp()
    {
        if (laneIndex < lanes.Length - 1) laneIndex += 1; 
    }

    public void moveLaneDown()
    {
        if (laneIndex > 0) laneIndex -= 1; 
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