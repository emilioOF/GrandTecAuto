using UnityEngine;
using UnityEngine.UI; 

public class UIController : MonoBehaviour
{
    private Cop cop;
    private Vehicle vehicle; 
    private Battery battery;
    private Transform energyBar;
    private Text velocityMeterNum; 
    private float cameraWidth; 

    void Start()
    {
        cop = GameObject.Find("Cop").GetComponent<Cop>();
        vehicle = GameObject.Find("Player").GetComponent<Player>().getPlayerVehicle(); 
        battery = GameObject.Find("Player").GetComponent<Player>().getPlayerBattery();
        energyBar = GameObject.Find("EnergyBar").transform;
        velocityMeterNum = transform.Find("VelocityMeterNum").GetComponent<Text>(); 
        cameraWidth = GameObject.Find("GameCamera").GetComponent<GameCamera>().CameraWidth; 
    }

    void Update()
    {
        velocityMeterNum.text = toString(vehicle.getSpeedIndex() + 1); 
        controlEnergyBar(); 
    }

    private string toString(float value)
    {
        int valueInt = (int)value;
        return valueInt.ToString(); 
    }

    private string toString(int value)
    {
        return value.ToString();
    }

    private void controlEnergyBar()
    {
        energyBar.Find("EnergyBarFill").GetComponent<SpriteRenderer>().color = battery.currentBatteryColor(false);   
        energyBar.localScale = new Vector3(cameraWidth * (battery.currentBattery()/100), 1, 0); 
    }
}
