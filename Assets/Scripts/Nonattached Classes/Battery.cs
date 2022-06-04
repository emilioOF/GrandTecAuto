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

    public void fillBattery()
    {
        remaining = 100; 
    }

    public bool canUseElectricAttack()
    {
        if (remaining >= 60)
        {
            return true; 
        } else
        {
            return false; 
        }
    }

    public float currentBattery()
    {
        return remaining; 
    }

    public Color currentBatteryColor(bool useBlues)
    {
        if (!useBlues && remaining > 40)
        {
            return Color.white; 
        } else if (remaining >= 100)
        {
            return Colors.ElectricDarkBlue; 
        } else if (remaining > 40 && remaining < 100)
        {
            return Colors.ElectricBlue; 
        } else if (remaining <= 40 && remaining > 20)
        {
            return Colors.ElectricYellow; 
        } else
        {
            return Colors.ElectricTangerine; 
        }
    }
}
