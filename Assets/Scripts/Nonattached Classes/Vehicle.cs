using UnityEngine; 

public class Vehicle
{
    private int[] speeds = {5, 10, 15, 20, 25, 30};
    // Bot: 2, 4, 8, 16
    // Cop: 6, 11, 16, 21
    private float[] lanes; 
    private int speedIndex;
    private int laneIndex;
    
    public Vehicle(int speedIndex, int laneIndex)
    {
        lanes = GameController.Lanes;
        this.speedIndex = speedIndex;
        this.laneIndex = laneIndex;
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
        return Vector2.right * speeds[speedIndex] * GameController.SpeedMaster;  
    }

    public int currentSpeedInt()
    {
        return speeds[speedIndex]; 
    }

    public bool inLastSpeed()
    {
        return (speedIndex + 1) == speeds.Length; 
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

    public int getSpeedIndex()
    {
        return speedIndex; 
    }

    public int getLaneIndex()
    {
        return laneIndex; 
    }
}