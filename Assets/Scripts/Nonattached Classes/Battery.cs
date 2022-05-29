using UnityEngine;

public class Battery
{
    private float chargeRate;
    private float dischargeRate; 
    private float remaining;

    public Battery()
    {
        chargeRate = 0.7f;
        dischargeRate = 0.3f;
        remaining = 100; 
    }

    public void charge(int velocity)
    {
        if (remaining <= 100)
        {
            remaining += velocity * chargeRate * Time.deltaTime;
        }
    }

    public void discharge(int velocity)
    {
        if (remaining >= 0)
        {
            remaining -= velocity * dischargeRate * Time.deltaTime;
        }
    }

    public void strongDischarge(float amount)
    {
        remaining -= amount; 
    }

    public float currentBattery()
    {
        return remaining; 
    }
}
