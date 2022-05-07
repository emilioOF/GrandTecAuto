public class Vehicle
{
    private int[] speeds = {3, 10, 20};
    private int speedIndex ;
    private float[] lanes = {4.0f , 1.4f, -1.47f, -4.0f};
    private int laneIndex;
    private bool direction;
    
    public Vehicle(int speedIndex, int laneIndex, bool direction)
    {
        this.speedIndex = speedIndex;
        this.laneIndex = laneIndex; 
        this.direction = direction;
    }

    public void modSpeed(int change)
    {
        speedIndex += change;

        if (speedIndex < 0)
        {
            speedIndex = 0;
        }

        if (speedIndex >= speeds.Length)
        {
            speedIndex = speeds.Length - 1;
        }
    }

    public void modLane(int change)
    {
        laneIndex += change;

        if (laneIndex < 0) {
            laneIndex = 0; 
        }

        if (laneIndex >= lanes.Length)
        {
            laneIndex = lanes.Length -1;
        }
    }

    public int currentSpeed()
    {
        if (direction)
        {
            return speeds[speedIndex]; 
        } else
        {
            return speeds[speedIndex] * -1; 
        }

    }

    public float currentLane()
    {
        return lanes[laneIndex]; 
    }
}